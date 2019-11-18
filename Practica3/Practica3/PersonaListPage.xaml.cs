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

            ((App)App.Current).ResumeAtPersonaId = -1;
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PersonaPage
            {
                BindingContext = new Persona()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
            //Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new PersonaPage
                {
                    BindingContext = e.SelectedItem as Persona
                });
            }
        }
    }
}