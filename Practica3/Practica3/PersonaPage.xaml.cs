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
    public partial class PersonaPage : ContentPage
    {
        public PersonaPage()
        {
            InitializeComponent();
        }
        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (Persona)BindingContext;
            await App.Database.SaveItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (Persona)BindingContext;
            await App.Database.DeleteItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}