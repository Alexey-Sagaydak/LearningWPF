using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Phone selectedPhone;
        public ObservableCollection<Phone> Phones { get; set; }

        #region Commands

        private RelayCommand addCommand;
        private RelayCommand removeCommand;
        private RelayCommand doubleCommand;

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (
                        addCommand = new RelayCommand(obj =>
                            {
                                Phone phone = new Phone();
                                Phones.Insert(0, phone);
                                SelectedPhone = phone;
                            }
                        )
                    );
            }
        }

        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (
                        removeCommand = new RelayCommand(
                            obj =>
                                {
                                    Phone phone = obj as Phone;
                                    if (phone != null)
                                        Phones.Remove(phone);
                                },
                            (obj) => Phones.Count() > 0
                        )
                    );
            }
        }

        public RelayCommand DoubleCommand
        {
            get
            {
                return doubleCommand ??
                    (
                        doubleCommand = new RelayCommand(
                            obj =>
                            {
                                Phone phone = obj as Phone;
                                if (phone != null)
                                {
                                    Phone phoneCopy = new Phone(phone.Title, phone.Company, phone.Price);
                                    Phones.Insert(0, phoneCopy);
                                }
                            }
                        )
                    );
            }
        }

        #endregion

        public Phone SelectedPhone
        {
            get => selectedPhone;
            set
            {
                selectedPhone = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public ApplicationViewModel()
        {
            Phones = new ObservableCollection<Phone>
            {
                new Phone("IPhone 13", "Apple", 70000),
                new Phone("Galaxy S23", "Samsung", 90000),
                new Phone("Pixel 4A", "Google", 32000)
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
