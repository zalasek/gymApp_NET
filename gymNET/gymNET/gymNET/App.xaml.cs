using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gymNET
{
    public partial class App : Application
    {
        public static DataManager DataManager { get; private set; }
        public App ()
        {
            InitializeComponent();

            DataManager = new DataManager(new RestService());
            MainPage = new NavigationPage(new AllTrainingsPage());
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

