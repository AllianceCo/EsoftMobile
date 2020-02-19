using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EsoftMobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            if (CallS.IsToggled == true)
            {
                VsS.IsEnabled = false;
                PkS.IsEnabled = false;
                OffOnUI(true);
                ColorUIElements("#696969");
            }
            else
            {
                VsS.IsEnabled = true;
                PkS.IsEnabled = true;
                OffOnUI(false);
                ColorUIElements("#696969");
            }
        }

        private void CallS_Toggled(object sender, ToggledEventArgs e)
        {
            if (CallS.IsToggled == true)
            {
                VsS.IsEnabled = false;
                PkS.IsEnabled = false;
                OffOnUI(true);
                ColorUIElements("#696969");
            }
            else
            {
                VsS.IsEnabled = true;
                PkS.IsEnabled = true;
                OffOnUI(false);
                ColorUIElements("#696969");
            }
        }

        private void VsS_Toggled(object sender, ToggledEventArgs e)
        {
            if (VsS.IsToggled == true)
            {
                CallS.IsEnabled = false;
                PkS.IsEnabled = false;
                OffOnUI(true);
                ColorUIElements("#f5be7d");
            }
            else
            {
                CallS.IsEnabled = true;
                PkS.IsEnabled = true;
                OffOnUI(false);
                ColorUIElements("#696969");
            }
        }

        private void PkS_Toggled(object sender, ToggledEventArgs e)
        {
            if (PkS.IsToggled == true)
            {
                VsS.IsEnabled = false;
                CallS.IsEnabled = false;
                OffOnUI(true);
                ColorUIElements("#f06f6f");
            }
            else
            {
                VsS.IsEnabled = true;
                CallS.IsEnabled = true;
                OffOnUI(false);
                ColorUIElements("#696969");
            }
        }
        private void OffOnUI(Boolean s)
        {
            Phone.IsEnabled = s;
            Comment.IsEnabled = s;
            FIO.IsEnabled = s;
            Name.IsEnabled = s;
            DateS.IsEnabled = s;
            Save.IsEnabled = s;
        }
        private void ColorUIElements(string color)
        {
            Phone.PlaceholderColor = Color.FromHex(color);
            Comment.PlaceholderColor = Color.FromHex(color);
            FIO.PlaceholderColor = Color.FromHex(color);
            Name.PlaceholderColor = Color.FromHex(color);
            Phone.TextColor = Color.FromHex(color);
            Comment.TextColor = Color.FromHex(color);
            FIO.TextColor = Color.FromHex(color);
            Name.TextColor = Color.FromHex(color);
            DateS.TextColor = Color.FromHex(color);
            Save.BackgroundColor = Color.FromHex(color);
        }

        private async void TodayNavigation_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new TodayPage());
        }

        private async void VsNavigation_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VsPage());
        }

        private async void CallsNavigation_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CallsPage());
        }

        private async void PkNavigation_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PkPage());
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            string type = "";
            if (PkS.IsToggled == true)
            {
                type = "Показ";
            }
            if (VsS.IsToggled == true)
            {
                type = "Встреча";
            }
            if (CallS.IsToggled == true)
            {
                type = "Звонок";
            }
            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
            using (ApplicationContext db = new ApplicationContext(dbPath))
            {
                try
                {
                    db.Sobities.Add(new Sobitie
                    {
                        Name = Name.Text,
                        Type = type,
                        Date = DateS.Date,
                        Comment = Comment.Text,
                        Phone = Int32.Parse(Phone.Text),
                        FIO = FIO.Text
                    });
                    db.SaveChanges();
                }
                catch
                {
                    DisplayAlert("Ошибка", "Не все данные заполненны или заполнены не верно", "ок");
                }
            }
            Name.Text = "";
            Comment.Text = "";
            Phone.Text = "";
            FIO.Text = "";
        }
    }
}
