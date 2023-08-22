using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListBoxWithIcons
{
    public class ListManager : IListManager
    {
        public ObservableCollection<IListItem> ListItems { get; private set; }

        public ListManager()
        {
            ListItems = new ObservableCollection<IListItem>();
        }

        public void AddListItem(IListItem listItem)
        {
            ListItems.Add(listItem);
        }

        public void RemoveImageByPath(IListItem listItem, string imagePath)
        {
            listItem.RemoveImageByPath(imagePath);
        }

        public void RemoveListItem(IListItem listItem)
        {
            ListItems.Remove(listItem);
        }
    }
}
