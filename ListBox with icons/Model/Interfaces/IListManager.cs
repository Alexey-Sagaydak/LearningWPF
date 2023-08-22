using System.Collections.ObjectModel;

namespace ListBoxWithIcons
{
    public interface IListManager
    {
        ObservableCollection<IListItem> ListItems { get; }

        void AddListItem(IListItem listItem);
        void RemoveImageByPath(IListItem listItem, string imagePath);
        void RemoveListItem(IListItem listItem);
    }
}
