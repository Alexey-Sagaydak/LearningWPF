using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ListBoxWithIcons
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IListManager _listManager;
        private IListItem _selectedItem;

        public ObservableCollection<IListItem> ListItems => _listManager.ListItems;

        public IListItem SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public ICommand RemoveImageCommand { get; }

        public MainWindowViewModel()
        {
            _listManager = new ListManager();

            RemoveImageCommand = new RelayCommand(RemoveImage, CanRemoveImage);

            CreateListOfItems();
        }

        public void CreateListOfItems()
        {
            string[] descriptions =
            {
                "Description 1",
                "Description 2",
                "Description 3",
                "Description 4",
                "Description 5"
            };

            string[] titles =
            {
                "Title 1",
                "Title 2",
                "Title 3",
                "Title 4",
                "Title 5"
            };

            for (int i = 0; i < 5; i++)
            {
                string[] paths = new string[10];

                for (int j = 0; j < 10; j++)
                {
                    paths[j] = $"../Images/3D Smile {i}{j}.gif";
                }

                IListItem tempListItem = new ListItem(titles[i], descriptions[i], paths);
                _listManager.AddListItem(tempListItem);
            }
        }

        private bool CanRemoveImage(object parameter)
        {
            return SelectedItem != null && parameter is string imagePath && SelectedItem.Images.Contains(imagePath);
        }

        private void RemoveImage(object parameter)
        {
            if (parameter is string imagePath)
            {
                _listManager.RemoveImageByPath(SelectedItem, imagePath);
                OnPropertyChanged(nameof(ListItems));
            }
        }
    }
}
