using LearningApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LearningApp
{
    public partial class App : Application
    {
        public static bool isValid = false;
        public static string AuthToken = string.Empty;
        public static LoginResponse LoginResponse;
        public static LoggedonUser LoggedonUser;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LearningApp.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            isValid = false;
            LoginResponse = null;
            LoggedonUser = null;
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
