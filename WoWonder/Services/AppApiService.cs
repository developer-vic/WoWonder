﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.App.Job;
using Android.Content;
using Android.OS;
using Java.Lang;
using Newtonsoft.Json;
using WoWonder.Activities.Chat.MsgTabbes;
using WoWonder.Activities.Chat.MsgTabbes.Fragment;
using WoWonder.Activities.NativePost.Post;
using WoWonder.Activities.Tabbes;
using WoWonder.Helpers.Controller;
using WoWonder.Helpers.Model;
using WoWonder.Helpers.Utils;
using WoWonder.SocketSystem;
using WoWonder.SQLite;
using WoWonderClient;
using WoWonderClient.Classes.Message;
using WoWonderClient.Classes.Posts;
using WoWonderClient.Requests;
using Exception = Java.Lang.Exception;

namespace WoWonder.Services
{
    [Service(Exported = false, Permission = "android.permission.BIND_JOB_SERVICE")]
    public class AppApiService : JobService
    {
        public static JobService Instance;
        public static JobParameters JobParameters;

        public override void OnCreate()
        {
            try
            {
                base.OnCreate();
                //Toast.MakeText(Application.Context, "OnCreate", ToastLength.Short)?.Show();
                new Handler(Looper.MainLooper).PostDelayed(new AppUpdaterHelper(new Handler(Looper.MainLooper)), AppSettings.RefreshAppAPiSeconds);
            }
            catch (Exception e)
            {
                Methods.DisplayReportResultTrack(e);
            }
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            try
            {
                base.OnStartCommand(intent, flags, startId);

                new Handler(Looper.MainLooper).PostDelayed(new AppUpdaterHelper(new Handler(Looper.MainLooper)), AppSettings.RefreshAppAPiSeconds);
                //Toast.MakeText(Application.Context, "OnStartCommand", ToastLength.Short)?.Show();

                return StartCommandResult.Sticky;
            }
            catch (Exception e)
            {
                Methods.DisplayReportResultTrack(e);
                return StartCommandResult.NotSticky;
            }
        }

        public override bool OnStartJob(JobParameters jobParams)
        {
            //Toast.MakeText(Application.Context, "On Start Job " + Methods.AppLifecycleObserver.AppState, ToastLength.Short)?.Show();

            Instance = this;
            JobParameters = jobParams;
            new Handler(Looper.MainLooper).PostDelayed(new AppUpdaterHelper(new Handler(Looper.MainLooper)), AppSettings.RefreshAppAPiSeconds);

            // Our task will run in background, we will take care of notifying the finish.
            return true;
        }

        public override bool OnStopJob(JobParameters jobParams)
        {
            //Toast.MakeText(Application.Context, "On Stop Job 321" + Methods.AppLifecycleObserver.AppState, ToastLength.Short)?.Show();
            // I want it to reschedule so returned true, if we would have returned false, then job would have ended here.
            // It would not fire onStartJob() when constraints are re satisfied.

            new Handler(Looper.MainLooper).PostDelayed(new AppUpdaterHelper(new Handler(Looper.MainLooper)), AppSettings.RefreshAppAPiSeconds);

            return false;
        }
    }

    public static class ChatJobInfo
    {
        public static void ScheduleJob(Context context)
        {
            try
            {
                ComponentName serviceComponent = new ComponentName(context, Class.FromType(typeof(AppApiService)));

                JobInfo jobInfo;
                if (Build.VERSION.SdkInt >= BuildVersionCodes.N)
                {
                    JobInfo.Builder builder = new JobInfo.Builder(1, serviceComponent);
                    builder.SetMinimumLatency(AppSettings.RefreshChatActivitiesSeconds); // wait at least
                    builder.SetOverrideDeadline(100); // maximum delay
                    builder.SetRequiredNetworkType(NetworkType.Unmetered); // require unmetered network
                    //builder.SetRequiresDeviceIdle(true); // the device should be idle
                    builder.SetRequiresCharging(false); // we don't care if the device is charging or not 

                    //if (Build.VERSION.SdkInt == BuildVersionCodes.S)
                    //builder.SetExpedited(true);
                    //#pragma warning disable CS0618
                    //else if (Build.VERSION.SdkInt == BuildVersionCodes.R)
                    //builder.SetImportantWhileForeground(false);
                    //#pragma warning restore CS0618

                    builder.SetPersisted(true);
                    jobInfo = builder?.Build();
                }
                else
                {
                    jobInfo = new JobInfo.Builder(1, serviceComponent)?.SetPeriodic(AppSettings.RefreshChatActivitiesSeconds)?.Build();
                }

                var jobScheduler = (JobScheduler)context.GetSystemService(Context.JobSchedulerService);
                if (jobInfo != null)
                    jobScheduler?.Schedule(jobInfo);
            }
            catch (Exception e)
            {
                Methods.DisplayReportResultTrack(e);
            }
        }

        public static void StopJob(Context context)
        {
            try
            {
                var jobScheduler = (JobScheduler)context.GetSystemService(Context.JobSchedulerService);
                jobScheduler?.CancelAll();
            }
            catch (Exception e)
            {
                Methods.DisplayReportResultTrack(e);
            }
        }
    }
     
    public class AppUpdaterHelper : Java.Lang.Object, IRunnable
    {
        private static Handler MainHandler;

        public AppUpdaterHelper(Handler mainHandler)
        {
            MainHandler = mainHandler;
        }

        public void Run()
        {
            try
            {
                if (string.IsNullOrEmpty(Methods.AppLifecycleObserver.AppState))
                    Methods.AppLifecycleObserver.AppState = "Background";

                //ToastUtils.ShowToast(Application.Context, "AppState " + Methods.AppLifecycleObserver.AppState, ToastLength.Short);

                if (Methods.AppLifecycleObserver.AppState == "Background" && string.IsNullOrEmpty(Current.AccessToken))
                {
                    SqLiteDatabase dbDatabase = new SqLiteDatabase();
                    var login = dbDatabase.Get_data_Login_Credentials();
                    Console.WriteLine(login);
                }

                if (string.IsNullOrEmpty(Current.AccessToken))
                    return;

                if (AppSettings.ConnectionTypeChat == InitializeWoWonder.ConnectionType.Socket)
                {
                    if (UserDetails.Socket == null)
                    {
                        UserDetails.Socket = new WoSocketHandler();
                        UserDetails.Socket?.InitStart();

                        //Connect to socket with access token
                        UserDetails.Socket?.Emit_Join(UserDetails.Username, UserDetails.AccessToken);
                    }
                    else
                    {
                        if (UserDetails.Socket.Client is { Connected: false } || !WoSocketHandler.IsJoined)
                        {
                            //Connect to socket with access token
                            UserDetails.Socket?.Emit_Join(UserDetails.Username, UserDetails.AccessToken);
                        }
                    }
                }
                else
                {
                    if (Methods.CheckConnectivity())
                        PollyController.RunRetryPolicyFunction(new List<Func<Task>> { LoadChatAsync });
                }

                if (Methods.CheckConnectivity())
                {
                    var instance = TabbedMainActivity.GetInstance();
                    if (Methods.AppLifecycleObserver.AppState == "Foreground" && instance != null)
                    {
                        if (instance.NewsFeedTab != null) PollyController.RunRetryPolicyFunction(new List<Func<Task>> { () => instance.NewsFeedTab.LoadStory() });
                        if (instance.NotificationsTab != null) PollyController.RunRetryPolicyFunction(new List<Func<Task>> { () => instance.Get_Notifications() });
                    }

                    PollyController.RunRetryPolicyFunction(new List<Func<Task>> { () => FetchFirstNewsFeedApiPosts(false) });
                }

                MainHandler ??= new Handler(Looper.MainLooper);
                MainHandler?.PostDelayed(new AppUpdaterHelper(new Handler(Looper.MainLooper)), AppSettings.RefreshAppAPiSeconds);
            }
            catch (Exception e)
            {
                //ToastUtils.ShowToast(Application.Context, "ResultSender failed",ToastLength.Short);
                MainHandler ??= new Handler(Looper.MainLooper);
                MainHandler?.PostDelayed(new AppUpdaterHelper(new Handler(Looper.MainLooper)), AppSettings.RefreshAppAPiSeconds);
                Methods.DisplayReportResultTrack(e);
            }
        }


        public static async Task LoadChatAsync()
        {
            try
            {
                //ToastUtils.ShowToast(Application.Context, "StartApiService", ToastLength.Short);
                if (LastChatFragment.ApiRun)
                    return;

                LastChatFragment.ApiRun = true;

                var fetch = "users";
                if (AppSettings.EnableChatGroup)
                    fetch += ",groups";

                if (AppSettings.EnableChatPage)
                    fetch += ",pages";

                var (apiStatus, respond) = await RequestsAsync.Message.GetChatAsync(fetch, "", "0", "25", "0", "25", "0", "25");
                if (apiStatus != 200 || respond is not LastChatObject result || result.Data == null)
                {
                    LastChatFragment.ApiRun = false;
                    //Methods.DisplayReportResult(new Activity(), respond);
                }
                else
                {
                    LastChatFragment.LoadCall(result);
                    var respondList = result.Data.Count;
                    if (respondList > 0)
                    {
                        if (Methods.AppLifecycleObserver.AppState == "Foreground")
                        {
                            MsgTabbedMainActivity.GetInstance()?.OnReceiveResult(JsonConvert.SerializeObject(result));
                        }
                        else
                        {
                            ListUtils.UserList = new ObservableCollection<ChatObject>(result.Data);

                            //Insert All data users to database
                            SqLiteDatabase dbDatabase = new SqLiteDatabase();
                            dbDatabase.Insert_Or_Update_LastUsersChat(Application.Context, ListUtils.UserList, UserDetails.ChatHead);
                            LastChatFragment.ApiRun = false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Methods.DisplayReportResultTrack(e);
                LastChatFragment.ApiRun = false;
            }
        }


        private static bool ByOffset;

        public static async Task FetchFirstNewsFeedApiPosts(bool cash)
        {
            try
            {
                if (!Methods.CheckConnectivity())
                    return;

                string offset = "0";
                if (Methods.AppLifecycleObserver.AppState == "Foreground" && ByOffset)
                {
                    ByOffset = false;

                    var item = TabbedMainActivity.GetInstance()?.NewsFeedTab.PostFeedAdapter?.ListDiffer?.LastOrDefault(a => a.TypeView != PostModelType.Divider && a.TypeView != PostModelType.ViewProgress && a.TypeView != PostModelType.AdMob1 && a.TypeView != PostModelType.AdMob2 && a.TypeView != PostModelType.AdMob3 && a.TypeView != PostModelType.FbAdNative && a.TypeView != PostModelType.AdsPost && a.TypeView != PostModelType.SuggestedPagesBox && a.TypeView != PostModelType.SuggestedGroupsBox && a.TypeView != PostModelType.SuggestedUsersBox && a.TypeView != PostModelType.CommentSection && a.TypeView != PostModelType.AddCommentSection);
                    offset = item?.PostData?.PostId ?? "0";
                }
                else
                {
                    ByOffset = true;
                }

                var (apiStatus, respond) = await RequestsAsync.Posts.GetGlobalPost(AppSettings.PostApiLimitOnBackground, offset);
                if (apiStatus != 200 || respond is not PostObject result)
                {
                    //Methods.DisplayReportResult(ActivityContext, respond);
                }
                else
                {
                    if (result?.Data?.Count > 0)
                    {
                        if (cash)
                        {
                            result.Data.RemoveAll(a => a.Publisher == null && a.UserData == null);
                            SqLiteDatabase dbDatabase = new SqLiteDatabase();
                            //Insert All data to database
                            dbDatabase.InsertOrUpdatePost(JsonConvert.SerializeObject(result));

                            foreach (var post in from post in result.Data let check = ListUtils.NewPostList.FirstOrDefault(a => a?.PostId == post.PostId) where check == null select post)
                            {
                                ListUtils.NewPostList.Add(post);
                            }
                        }
                        else
                        {
                            if (Methods.AppLifecycleObserver.AppState == "Foreground")
                            {
                                TabbedMainActivity.GetInstance()?.NewsFeedTab?.MainRecyclerView?.ApiPostAsync?.LoadDataApi(apiStatus, respond, offset, "Insert");
                            }
                            else
                            {
                                result.Data.RemoveAll(a => a.Publisher == null && a.UserData == null);
                                SqLiteDatabase dbDatabase = new SqLiteDatabase();
                                //Insert All data to database
                                dbDatabase.InsertOrUpdatePost(JsonConvert.SerializeObject(result));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Methods.DisplayReportResultTrack(e);
            }
        }
    }
}