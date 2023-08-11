using System.ComponentModel;

namespace MVVM
{
    public class Phone : INotifyPropertyChanged
    {
        private string title;
        private string company;
        private int price;

        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Company
        {
            get => company;
            set
            {
                company = value;
                OnPropertyChanged("Company");
            }
        }

        public int Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public Phone()
        {
            Title = string.Empty;
            Company = string.Empty;
            Price = 0;
        }

        public Phone(string title, string company, int price)
        {
            Title = title;
            Company = company;
            Price = price;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}