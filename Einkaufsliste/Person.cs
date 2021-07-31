using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace Einkaufsliste
{
    public class Person : INotifyPropertyChanged
    {
        private double quantity;
        private TextDecorations decoration;

        public Person()
        {
            decoration = TextDecorations.None;
            quantity = 1;
        }

        // SQLite stuff
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }

        [MaxLength(255)]

        public string Name { get; set; }


        public double Quantity
        {
            get => quantity;
            set
            {
                quantity = value;
                NotifyPropertyChanged();
            }
        }

        // text decoration effect
        public TextDecorations Decoration
        {
            get => decoration;
            set
            {
                decoration = value;
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