using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListBoxWithIcons
{
    public class ListItem : IListItem
    {
        public string Title { get; set; }
        public ObservableCollection<string> Images { get; set; }
        public string Description { get; set; }

        public ListItem(string title, string description)
        {
            InitializeObject(title, description);
        }

        public ListItem(string title, string description, params string[] imagePaths)
        {
            InitializeObject(title, description);
            LoadImages(imagePaths);
        }

        public void InitializeObject(string title, string description)
        {
            Images = new ObservableCollection<string>();
            Title = title;
            Description = description;
        }

        public void LoadImages(params string[] imagePaths)
        {
            foreach (string imagePath in imagePaths)
            {
                Images.Add(imagePath);
            }
        }

        public void RemoveImageByPath(string imagePath)
        {
            if (Images.Contains(imagePath))
            {
                Images.Remove(imagePath);
            }
        }
    }
}
