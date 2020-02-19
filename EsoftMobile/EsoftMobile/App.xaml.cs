using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;

namespace EsoftMobile
{
    public partial class App : Application
    {
        public const string DBFILENAME = "EsoftMobileBD.db";
        public App()
        {
            InitializeComponent();
            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(DBFILENAME);
            using (var db = new ApplicationContext(dbPath))
            {
                // Создаем бд, если она отсутствует
                db.Database.EnsureCreated();
            }  
            MainPage = new NavigationPage(new MainPage());
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

