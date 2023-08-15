using Ejercicio3_2.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio3_2
{
    public partial class App : Application
    {
        static Services.DataBase db;
        
        public static Services.DataBase instance
        {
            get
            {
                if (db == null)
                {
                    string dbName = "tarea.db3";
                    string dbPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    string dbFullPath = Path.Combine(dbPath, dbName);
                    db = new Services.DataBase(dbFullPath);
                }

                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new VAddStud());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
