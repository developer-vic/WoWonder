//##############################################
//Cᴏᴘʏʀɪɢʜᴛ 2020 DᴏᴜɢʜᴏᴜᴢLɪɢʜᴛ Codecanyon Item 19703216
//Elin Doughouz >> https://www.facebook.com/Elindoughouz
//====================================================

//For the accuracy of the icon and logo, please use this website " https://appicon.co " and add images according to size in folders " mipmap " 

using System.Collections.Generic;
using WoWonder.Activities.NativePost.Extra;
using WoWonder.Helpers.Model;
using WoWonderClient;

namespace WoWonder
{
    internal static class AppSettings
    {
        /// <summary>
        /// Deep Links To App Content
        /// you should add your website without http in the analytic.xml file >> ../values/analytic.xml .. line 5
        /// <string name="ApplicationUrlWeb">stam-il.com</string>
        /// </summary>
        public static string TripleDesAppServiceProvider = "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";

        //Main Settings >>>>>
        //*********************************************************
        public static string Version = "3.6";
        public static string ApplicationName = "Posty";
        public static string DatabaseName = "Posty"; 

        // Friend system = 0 , follow system = 1
        public static int ConnectivitySystem = 1;
         
        //Main Colors >>
        //*********************************************************
        public static string MainColor = "#031cfc";
         
        //Language Settings >> http://www.lingoes.net/en/translator/langcode.htm
        //*********************************************************
        public static bool FlowDirectionRightToLeft = false;
        public static string Lang = ""; //Default language ar

        //Set Language User on site from phone 
        public static bool SetLangUser = true; 

        //Notification Settings >>
        //*********************************************************
        public static bool ShowNotification = true;
        public static string OneSignalAppId = "c4c50d34-28e6-4aff-bde8-da51859d1069";
        public static string MsgOneSignalAppId = "c4c50d34-28e6-4aff-bde8-da51859d1069";

        // WalkThrough Settings >>
        //*********************************************************
        public static bool ShowWalkTroutPage = true;

        //Main Messenger settings
        //*********************************************************
        public static bool MessengerIntegration = true;
        public static bool ShowDialogAskOpenMessenger = false; 
        public static string MessengerPackageName = "com.wowondermessenger.app"; //APK name on Google Play

        //AdMob >> Please add the code ad in the Here and analytic.xml 
        //*********************************************************
        public static ShowAds ShowAds = ShowAds.AllUsers;

        //Three times after entering the ad is displayed
        public static int ShowAdInterstitialCount = 5;
        public static int ShowAdRewardedVideoCount = 5;
        public static int ShowAdNativeCount = 40;
        public static int ShowAdAppOpenCount = 3;

        public static bool ShowAdMobBanner = true;
        public static bool ShowAdMobInterstitial = true;
        public static bool ShowAdMobRewardVideo = true;
        public static bool ShowAdMobNative = true;
        public static bool ShowAdMobNativePost = true;
        public static bool ShowAdMobAppOpen = true;
        public static bool ShowAdMobRewardedInterstitial = true;

        public static string AdInterstitialKey = "ca-app-pub-9059538765638516/6645720629";
        public static string AdRewardVideoKey = "ca-app-pub-9059538765638516/8673365587";
        public static string AdAdMobNativeKey = "ca-app-pub-9059538765638516/5687862175";
        public static string AdAdMobAppOpenKey = "ca-app-pub-9059538765638516/2375303127";
        public static string AdRewardedInterstitialKey = "ca-app-pub-9059538765638516/1253793147";

        //FaceBook Ads >> Please add the code ad in the Here and analytic.xml 
        //*********************************************************
        public static bool ShowFbBannerAds = false;
        public static bool ShowFbInterstitialAds = false;
        public static bool ShowFbRewardVideoAds = false;
        public static bool ShowFbNativeAds = false;

        //YOUR_PLACEMENT_ID
        public static string AdsFbBannerKey = "250485588986218_554026418632132";
        public static string AdsFbInterstitialKey = "250485588986218_554026125298828";
        public static string AdsFbRewardVideoKey = "250485588986218_554072818627492";
        public static string AdsFbNativeKey = "250485588986218_554706301897477";

        //Colony Ads >> Please add the code ad in the Here 
        //*********************************************************  
        public static bool ShowColonyBannerAds = false;
        public static bool ShowColonyInterstitialAds = false;
        public static bool ShowColonyRewardAds = false;

        public static string AdsColonyAppId = "appff22269a7a0a4be8aa";
        public static string AdsColonyBannerId = "vz85ed7ae2d631414fbd";
        public static string AdsColonyInterstitialId = "vz39712462b8634df4a8";
        public static string AdsColonyRewardedId = "vz32ceec7a84aa4d719a";
        //********************************************************* 

        public static bool EnableRegisterSystem = true;

        /// <summary>
        /// true => Only over 18 years old
        /// false => all 
        /// </summary> 
        public static bool ShowBirthdayInRegister = true; //#New
        public static bool IsUserYearsOld = true;
        public static bool AddAllInfoPorfileAfterRegister = true;

        //Set Theme Full Screen App
        //*********************************************************
        public static bool EnableFullScreenApp = false;

        //Code Time Zone (true => Get from Internet , false => Get From #CodeTimeZone )
        //*********************************************************
        public static bool AutoCodeTimeZone = true;
        public static string CodeTimeZone = "UTC";

        //Error Report Mode
        //*********************************************************
        public static bool SetApisReportMode = false;

        //Social Logins >>
        //If you want login with facebook or google you should change id key in the analytic.xml file 
        //Facebook >> ../values/analytic.xml .. line 10-11 
        //Google >> ../values/analytic.xml .. line 15 
        //*********************************************************
        public static bool EnableSmartLockForPasswords = false;

        public static bool ShowFacebookLogin = false;
        public static bool ShowGoogleLogin = false;

        public static readonly string ClientId = "449865329971-ebictldf5vqshglovau2sec7klp0p0tt.apps.googleusercontent.com";

        //########################### 

        //Main Slider settings
        //*********************************************************
        public static PostButtonSystem PostButton = PostButtonSystem.ReactionDefault;
        public static ToastTheme ToastTheme = ToastTheme.Custom;

        public static BottomNavigationSystem NavigationBottom = BottomNavigationSystem.Default;

        /// <summary>
        /// None : To disable Reels video on the app 
        /// </summary>
        public static ReelsPosition ReelsPosition = ReelsPosition.Tab;
        public static bool ShowYouTubeReels = false; //#New


        public static bool ShowBottomAddOnTab = true;


        public static long RefreshAppAPiSeconds = 30000; //#New


        public static bool ShowAlbum = true;
        public static bool ShowArticles = true;
        public static bool ShowPokes = true;
        public static bool ShowCommunitiesGroups = true;
        public static bool ShowCommunitiesPages = true;
        public static bool ShowMarket = true;
        public static bool ShowPopularPosts = true;
        /// <summary>
        /// if selected false will remove boost post and get list Boosted Posts
        /// </summary>
        public static bool ShowBoostedPosts = true;
        public static bool ShowBoostedPages = true;
        public static bool ShowMovies = true;
        public static bool ShowNearBy = true;
        public static bool ShowStory = true;
        public static bool ShowSavedPost = true;
        public static bool ShowUserContacts = true;
        public static bool ShowJobs = true;
        public static bool ShowCommonThings = true;
        public static bool ShowFundings = true;
        public static bool ShowMyPhoto = true;
        public static bool ShowMyVideo = true;
        public static bool ShowGames = true;
        public static bool ShowMemories = true;
        public static bool ShowOffers = true;
        public static bool ShowNearbyShops = true;

        public static bool ShowSuggestedPage = true;
        public static bool ShowSuggestedGroup = true;
        public static bool ShowSuggestedUser = true;

        //count times after entering the Suggestion is displayed
        public static int ShowSuggestedPageCount = 90;
        public static int ShowSuggestedGroupCount = 70;
        public static int ShowSuggestedUserCount = 50;

        //allow download or not when share
        public static bool AllowDownloadMedia = true;

        public static bool ShowAdvertise = true;

        /// <summary>
        /// https://rapidapi.com/api-sports/api/covid-193
        /// you can get api key and host from here https://prnt.sc/wngxfc 
        /// </summary>
        public static bool ShowInfoCoronaVirus = true;
        public static string KeyCoronaVirus = "164300ef98msh0911b69bed3814bp131c76jsneaca9364e61f";
        public static string HostCoronaVirus = "covid-193.p.rapidapi.com";

        public static bool ShowLive = false;
        public static string AppIdAgoraLive = "663dbfd76c874c90b9cf48129993a735";

        //Events settings
        //*********************************************************  
        public static bool ShowEvents = true;
        public static bool ShowEventGoing = true;
        public static bool ShowEventInvited = true;
        public static bool ShowEventInterested = true;
        public static bool ShowEventPast = true;

        // Story >>
        //*********************************************************
        //Set a story duration >> Sec
        public static long StoryImageDuration = 7;
        public static long StoryVideoDuration = 30;

        /// <summary>
        /// If it is false, it will appear only for the specified time in the value of the StoryVideoDuration
        /// </summary>
        public static bool ShowFullVideo = false;

        public static bool EnableStorySeenList = true;
        public static bool EnableReplyStory = true;
        
        //*********************************************************

        /// <summary>
        ///  Currency
        /// CurrencyStatic = true : get currency from app not api 
        /// CurrencyStatic = false : get currency from api (default)
        /// </summary>
        public static readonly bool CurrencyStatic = false;
        public static readonly string CurrencyIconStatic = "$";
        public static readonly string CurrencyCodeStatic = "USD";
        public static readonly string CurrencyFundingPriceStatic = "$";

        //Profile settings
        //*********************************************************
        public static bool ShowGift = true;
        public static bool ShowWallet = true;
        public static bool ShowGoPro = true;
        public static bool ShowAddToFamily = true;

        public static bool ShowUserGroup = false;
        public static bool ShowUserPage = false;
        public static bool ShowUserImage = true;
        public static bool ShowUserSocialLinks = false;

        public static CoverImageStyle CoverImageStyle = CoverImageStyle.CenterCrop;

        /// <summary>
        /// The default value comes from the site .. in case it is not available, it is taken from these values
        /// </summary>
        public static string WeeklyPrice = "10";
        public static string MonthlyPrice = "20";
        public static string YearlyPrice = "170";
        public static string LifetimePrice = "10000";

        //Native Post settings
        //********************************************************* 
        public static bool ShowTextWithSpace = true;

        public static bool ShowTextShareButton = false;
        public static bool ShowShareButton = true;

        public static int AvatarPostSize = 60;
        public static int ImagePostSize = 200;
        public static string PostApiLimitOnScroll = "22";

        public static string PostApiLimitOnBackground = "12";

        public static bool AutoPlayVideo = true;

        public static bool EmbedDeepSoundPostType = true;
        public static VideoPostTypeSystem EmbedFacebookVideoPostType = VideoPostTypeSystem.EmbedVideo;
        public static VideoPostTypeSystem EmbedVimeoVideoPostType = VideoPostTypeSystem.EmbedVideo;
        public static VideoPostTypeSystem EmbedPlayTubeVideoPostType = VideoPostTypeSystem.Link;
        public static VideoPostTypeSystem EmbedTikTokVideoPostType = VideoPostTypeSystem.Link;
        public static VideoPostTypeSystem EmbedTwitterPostType = VideoPostTypeSystem.Link;
        public static bool ShowSearchForPosts = true;
        public static bool EmbedLivePostType = true;

        //new posts users have to scroll back to top
        public static bool ShowNewPostOnNewsFeed = true;
        public static bool ShowAddPostOnNewsFeed = false;
        public static bool ShowCountSharePost = true;

        public static WRecyclerView.VolumeState DefaultVolumeVideoPost = WRecyclerView.VolumeState.On;
        
        /// <summary>
        /// Post Privacy
        /// ShowPostPrivacyForAllUser = true : all posts user have icon Privacy 
        /// ShowPostPrivacyForAllUser = false : just my posts have icon Privacy (default)
        /// </summary>
        public static bool ShowPostPrivacyForAllUser = false;

        public static bool ShowFullScreenVideoPost = true;

        public static bool EnableVideoCompress = true;
        public static bool EnableFitchOgLink = true;

        //Trending page
        //*********************************************************   
        public static bool ShowTrendingPage = true;

        public static bool ShowProUsersMembers = true;
        public static bool ShowPromotedPages = true;
        public static bool ShowTrendingHashTags = true;
        public static bool ShowLastActivities = true;
        public static bool ShowShortcuts = true;
        public static bool ShowFriendsBirthday = true;
        public static bool ShowAnnouncement = true;

        /// <summary>
        /// https://www.weatherapi.com
        /// </summary>
        public static WeatherType WeatherType = WeatherType.Celsius;
        public static bool ShowWeather = true;
        public static string KeyWeatherApi = "b6534c16353c4e9c80782134223005";

        /// <summary>
        /// https://openexchangerates.org
        /// #Currency >> Your currency
        /// #Currencies >> you can use just 3 from those : USD,EUR,DKK,GBP,SEK,NOK,CAD,JPY,TRY,EGP,SAR,JOD,KWD,IQD,BHD,DZD,LYD,AED,QAR,LBP,OMR,AFN,ALL,ARS,AMD,AUD,BYN,BRL,BGN,CLP,CNY,MYR,MAD,ILS,TND,YER
        /// </summary>
        public static bool ShowExchangeCurrency = true;
        public static string KeyCurrencyApi = "de25bd8b4c9d4726b802156f419ea93f";
        public static string ExCurrency = "USD";
        public static string ExCurrencies = "EUR,GBP,TRY";
        public static readonly List<string> ExCurrenciesIcons = new List<string>() { "€", "£", "₺" };

        //********************************************************* 

        /// <summary>
        /// you can edit video using FFMPEG 
        /// </summary>
        public static bool EnableVideoEditor = true;


        public static bool ShowUserPoint = true;

        //Add Post
        public static AddPostSystem AddPostSystem = AddPostSystem.AllUsers;

        public static bool ShowGalleryImage = true;
        public static bool ShowGalleryVideo = true;
        public static bool ShowMention = true;
        public static bool ShowLocation = true;
        public static bool ShowFeelingActivity = true;
        public static bool ShowFeeling = true;
        public static bool ShowListening = true;
        public static bool ShowPlaying = true;
        public static bool ShowWatching = true;
        public static bool ShowTraveling = true;
        public static bool ShowGif = true;
        public static bool ShowFile = true;
        public static bool ShowMusic = true;
        public static bool ShowPolls = true;
        public static bool ShowColor = true;
        public static bool ShowVoiceRecord = true;

        public static bool ShowAnonymousPrivacyPost = true;

        //Advertising 
        public static bool ShowAdvertisingPost = true;

        //Settings Page >> General Account
        public static bool ShowSettingsGeneralAccount = true;
        public static bool ShowSettingsAccount = true;
        public static bool ShowSettingsSocialLinks = true;
        public static bool ShowSettingsPassword = true;
        public static bool ShowSettingsBlockedUsers = true;
        public static bool ShowSettingsDeleteAccount = true;
        public static bool ShowSettingsTwoFactor = false;
        public static bool ShowSettingsManageSessions = true;
        public static bool ShowSettingsVerification = true;

        public static bool ShowSettingsSocialLinksFacebook = true;
        public static bool ShowSettingsSocialLinksTwitter = true;
        public static bool ShowSettingsSocialLinksGoogle = true;
        public static bool ShowSettingsSocialLinksVkontakte = true;
        public static bool ShowSettingsSocialLinksLinkedin = true;
        public static bool ShowSettingsSocialLinksInstagram = true;
        public static bool ShowSettingsSocialLinksYouTube = true;

        //Settings Page >> Privacy
        public static bool ShowSettingsPrivacy = true;
        public static bool ShowSettingsNotification = true;

        //Settings Page >> Tell a Friends (Earnings)
        public static bool ShowSettingsInviteFriends = true;

        public static bool ShowSettingsShare = true;
        public static bool ShowSettingsMyAffiliates = true;
        public static bool ShowWithdrawals = true;

        /// <summary>
        /// if you want this feature enabled go to Properties -> AndroidManefist.xml and remove comments from below code
        /// Just replace it with this 5 lines of code
        /// <uses-permission android:name="android.permission.READ_CONTACTS" />
        /// <uses-permission android:name="android.permission.READ_PHONE_NUMBERS" />
        /// </summary>
        public static bool InvitationSystem = true;

        //Settings Page >> Help && Support
        public static bool ShowSettingsHelpSupport = true;

        public static bool ShowSettingsHelp = true;
        public static bool ShowSettingsReportProblem = true;
        public static bool ShowSettingsAbout = true;
        public static bool ShowSettingsPrivacyPolicy = true;
        public static bool ShowSettingsTermsOfUse = true;

        public static bool ShowSettingsRateApp = true;
        public static int ShowRateAppCount = 5;

        public static bool ShowSettingsUpdateManagerApp = false;

        public static bool ShowSettingsInvitationLinks = true;
        public static bool ShowSettingsMyInformation = true;

        public static bool ShowSuggestedUsersOnRegister = true;

        //Set Theme Tab
        //*********************************************************

        /// <summary>
        /// if select : AlwaysDark or AlwaysLight >> can user change theme in settings 
        /// </summary>
        public static TabTheme SetTabDarkTheme = TabTheme.Light;
        public static MoreTheme MoreTheme = MoreTheme.Card;

        //Bypass Web Errors  
        //*********************************************************
        public static bool TurnTrustFailureOnWebException = true;
        public static bool TurnSecurityProtocolType3072On = true;

        //*********************************************************
        public static bool RenderPriorityFastPostLoad = false;

        /// <summary>
        /// if you want this feature enabled go to Properties -> AndroidManefist.xml and remove comments from below code
        /// <uses-permission android:name="com.android.vending.BILLING" />
        /// </summary>
        public static bool ShowInAppBilling = false;

        /// <summary>
        /// Paypal and google pay using Braintree Gateway https://www.braintreepayments.com/
        /// 
        /// Add info keys in Payment Methods : https://prnt.sc/1z5bffc & https://prnt.sc/1z5b0yj
        /// To find your merchant ID :  https://prnt.sc/1z59dy8
        ///
        /// Tokenization Keys : https://prnt.sc/1z59smv
        /// </summary>
        public static bool ShowPaypal = true;
        public static string MerchantAccountId = "test";

        public static string SandboxTokenizationKey = "sandbox_kt2f6mdh_hf4c******";
        public static string ProductionTokenizationKey = "production_t2wns2y2_dfy45******";

        public static bool ShowBankTransfer = true;
        public static bool ShowCreditCard = true;

        //********************************************************* 
        public static bool ShowCashFree = true;

        /// <summary>
        /// Currencies : http://prntscr.com/u600ok
        /// </summary>
        public static string CashFreeCurrency = "INR";

        //********************************************************* 

        /// <summary>
        /// If you want RazorPay you should change id key in the analytic.xml file
        /// razorpay_api_Key >> .. line 24 
        /// </summary>
        public static bool ShowRazorPay = true;

        /// <summary>
        /// Currencies : https://razorpay.com/accept-international-payments
        /// </summary>
        public static string RazorPayCurrency = "USD";

        public static bool ShowPayStack = true;
        public static bool ShowPaySera = false;  //#Next Version   

        //********************************************************* 
        
        //Chat
        //*********************************************************  
        public static SystemGetLastChat LastChatSystem = SystemGetLastChat.Default;
        public static InitializeWoWonder.ConnectionType ConnectionTypeChat = InitializeWoWonder.ConnectionType.RestApi;
        public static string PortSocketServer = "443";

        //Chat Window Activity >>
        //*********************************************************
        //if you want this feature enabled go to Properties -> AndroidManefist.xml and remove comments from below code
        //Just replace it with this 5 lines of code
        /*
         <uses-permission android:name="android.permission.READ_CONTACTS" />
         <uses-permission android:name="android.permission.READ_PHONE_NUMBERS" /> 
         */
        public static bool ShowButtonContact = true;
        /////////////////////////////////////

        public static bool ShowButtonCamera = true;
        public static bool ShowButtonImage = true;
        public static bool ShowButtonVideo = true;
        public static bool ShowButtonAttachFile = true;
        public static bool ShowButtonColor = true;
        public static bool ShowButtonStickers = true;
        public static bool ShowButtonMusic = true;
        public static bool ShowButtonGif = true;
        public static bool ShowButtonLocation = true;

        public static bool OpenVideoFromApp = true;
        public static bool OpenImageFromApp = true;

        //Record Sound Style & Text 
        public static bool ShowButtonRecordSound = true;

        // Options List Message
        public static bool EnableReplyMessageSystem = true;
        public static bool EnableForwardMessageSystem = true;
        public static bool EnableFavoriteMessageSystem = true;
        public static bool EnablePinMessageSystem = true;
        public static bool EnableReactionMessageSystem = true;

        public static bool ShowNotificationWithUpload = true;

        /// <summary>
        /// https://dashboard.stipop.io/
        /// you can get api key from here https://prnt.sc/26ofmq9
        /// </summary>
        public static string StickersApikey = "0a441b19287cad752e87f6072bb914c0";

        //List Chat >>
        //*********************************************************
        public static bool EnableChatPage = true;
        public static bool EnableChatGroup = true;

        // Options List Chat
        public static bool EnableChatArchive = true;
        public static bool EnableChatPin = true;
        public static bool EnableChatMute = true;
        public static bool EnableChatMakeAsRead = true;


        // Video/Audio Call Settings >>
        //*********************************************************
        public static bool EnableAudioVideoCall = true;

        public static bool EnableAudioCall = true;
        public static bool EnableVideoCall = true;

        public static SystemCall UseLibrary = SystemCall.Agora;


        //Last Messages Page >>
        //*********************************************************
        public static bool ShowOnlineOfflineMessage = true;

        public static int RefreshChatActivitiesSeconds = 3500; // 3 Seconds
        public static int MessageRequestSpeed = 4000; // 3 Seconds

        public static ColorMessageTheme ColorMessageTheme = ColorMessageTheme.Default;

        //Settings Page >> General Account
        public static bool ShowSettingsWallpaper = true;

        //Options chat heads (Bubbles) 
        //*********************************************************
        public static bool ShowChatHeads = true;
        public static bool ShowSettingsFingerprintLock = true;

        //Always , Hide , FullScreen
        public static string DisplayModeSettings = "Always";

        //Default , Left  , Right , Nearest , Fix , Thrown
        public static string MoveDirectionSettings = "Right";

        //Circle , Rectangle
        public static string ShapeSettings = "Circle";

        // Last position
        public static bool IsUseLastPosition = true;

    }
}