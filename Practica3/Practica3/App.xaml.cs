using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        static PersonaDatabase database;
        public App()
        {
            //InitializeComponent();

            Resources = new ResourceDictionary();
            Resources.Add("primaryGreen", Color.FromHex("91CA47"));
            Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));

            var nav = new NavigationPage(new PersonaListPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
            nav.BarTextColor = Color.White;

            MainPage = nav;

            //MainPage = new MainPage();
        }
        public static PersonaDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new PersonaDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PersonaSQLite.db3"));
                }
                return database;
            }
        }

        public int ResumeAtPersonaId { get; set; }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
