using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Einkaufsliste.ViewModel;
using Xamarin.Forms;
using SQLite;
using System.Collections.ObjectModel;

namespace Einkaufsliste
{
    /*
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }*/

    public partial class MainPage : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Person> _recipes;

        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = new EinkaufViewModel();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        void Entry_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            //App.Current.MainPage.DisplayAlert(entry.Text, "jo", "jo");
        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Person>();

            var recipes = await _connection.Table<Person>().ToListAsync();
            _recipes = new ObservableCollection<Person>(recipes);
            recipeListView.ItemsSource = _recipes;

            base.OnAppearing();
            //collectionView.ItemsSource = await App.Database.GetPeopleAsync();
        }

        /*
        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(ageEntry.Text))
            {
                await App.Database.SavePersonAsync(new Person
                {
                    Name = nameEntry.Text,
                    Age = int.Parse(ageEntry.Text)
                });

                nameEntry.Text = ageEntry.Text = string.Empty;
                collectionView.ItemsSource = await App.Database.GetPeopleAsync();
            }
        }*/

        // add new item
        async void OnAdd(System.Object sender, System.EventArgs e)
        {
            if (entry.Text != "")
            {
                var recipe = new Person { Name = entry.Text /* + System.DateTime.Now.Ticks */ };

                foreach (Person i in _recipes)
                {
                    // Check if new Einkauf is already in collection
                    if (i.Name == recipe.Name)
                    {
                        entry.Text = "";
                        return;
                    }
                }
                await _connection.InsertAsync(recipe);
                _recipes.Add(recipe);
                entry.Text = "";
            }
        }

        // demo function, not used, updates db
        async void OnUpdate(System.Object sender, System.EventArgs e)
        {
            var recipe = _recipes[0];
            recipe.Name += "Updated";
            await _connection.UpdateAsync(recipe);
        }

        // clears db + list
        async void OnDelete(System.Object sender, System.EventArgs e)
        {
            // Delete all entries
            //var recipe = _recipes[0];

            // clear database
            await _connection.DeleteAllAsync<Person>();

            // clear listview
            _recipes.Clear();
        }

        // deletes single item, timer necessary for better UI
        async void recipeListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var contact = e.Item as Person;
            
            //DisplayAlert("Tapped ", contact.ID.ToString(), "OK");

            await _connection.DeleteAsync(contact);

            _recipes.Remove(contact);
        }

        // not used atm
        void recipeListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var contact = e.SelectedItem as Person;

            //DisplayAlert("Selected", contact.Name, "OK");
        }
    }
}
