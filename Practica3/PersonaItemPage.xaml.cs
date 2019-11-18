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
    public partial class PersonaItemPage : ContentPage
    {
        public PersonaItemPage()
        {
            InitializeComponent();
        }
        async void OnSaveClicked(object sender, EventArgs e)
        {
            var personaItem = (PersonaItem)BindingContext;
            await App.Database.SaveItemAsync(personaItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var personaItem = (PersonaItem)BindingContext;
            await App.Database.DeleteItemAsync(personaItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        //void OnSpeakClicked(object sender, EventArgs e)
        //{
        //    var todoItem = (PersonaItem)BindingContext;
        //    DependencyService.Get<ITextToSpeech>().Speak(todoItem.Name + " " + todoItem.Notes);
        //}
    }
}
