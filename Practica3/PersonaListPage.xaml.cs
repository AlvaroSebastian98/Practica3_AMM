using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonaListPage : ContentPage
    {
        public PersonaListPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtPersonaId = -1;
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PersonaItemPage
            {
                BindingContext = new PersonaItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //((App)App.Current).ResumeAtPersonaId = (e.SelectedItem as PersonaItem).ID;
            //Debug.WriteLine("setting ResumeAtPersonaId = " + (e.SelectedItem as PersonaItem).ID);
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new PersonaItemPage
                {
                    BindingContext = e.SelectedItem as PersonaItem
                });
            }
        }
    }
}
