using WoWonder.NiceArt.Models;

namespace WoWonder.Helpers.Chat.Editor
{
    public interface IFilterListener
    {
        void OnFilterSelected(PhotoFilter photoFilter);
    }
}