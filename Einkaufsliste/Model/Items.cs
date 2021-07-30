using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;

namespace Einkaufsliste.Model
{
    public class Items : INotifyPropertyChanged
    {
        // MODEL


        private string name;
        private double quantity;
        private bool inShoppingCart;


        public Items()
        {

        }


        [PrimaryKey, AutoIncrement]
        public string Name
        {
            get => name;
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }

        public double Quantify
        {
            get => quantity;
            set
            {
                quantity = value;
                NotifyPropertyChanged();
            }
        }

        public bool InShoppingCart
        {
            get => inShoppingCart;
            set
            {
                inShoppingCart = value;
                NotifyPropertyChanged();
            }
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
