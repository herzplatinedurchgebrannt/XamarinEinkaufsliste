using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Einkaufsliste.ViewModel
{
    public class EinkaufViewModel : INotifyPropertyChanged
    {
        // VIEWMODEL
        private string name;

        public string Name {

            get => name;

            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }

        public EinkaufViewModel()
        {
            Name = "lalala";

            //var app = Application.Current as App;
        }

        private DelegateCommand _addCommand;
        public DelegateCommand addCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new DelegateCommand(Add,

                        () =>
                        {
                            return true;
                        }
                        );
                }
                return _addCommand;
            }
        }



        public void Add() {
            Console.WriteLine("Pressed");
            //App.Current.MainPage.DisplayAlert("jo","jo","jo");
            
            Name = "Pressed";
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Private Helpers

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {

            if (PropertyChanged != null)
            {

                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }
        #endregion

    }


}
