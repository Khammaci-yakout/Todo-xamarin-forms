using System;
using System.IO;
using Xamarin.Forms;
using TodoProject.Data;


namespace TodoProject
{
    public partial class App : Application
    {
        static TodoDatabase database;
        public static TodoDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TodoDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoProject.db"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new TodoPage()) { BarBackgroundColor = Color.FromHex("#800080"), BarTextColor = Color.White };
        }
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
