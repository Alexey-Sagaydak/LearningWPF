using System.Collections.ObjectModel;

namespace ListBoxWithIcons
{
    public interface IListItem
    {
        string Description { get; set; }
        ObservableCollection<string> Images { get; set; }
        string Title { get; set; }

        void InitializeObject(string title, string description);
        void LoadImages(params string[] imagePaths);
        void RemoveImageByPath(string imagePath);
    }
}
