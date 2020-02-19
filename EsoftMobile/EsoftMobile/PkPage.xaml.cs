using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EsoftMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PkPage : ContentPage
    {
        public PkPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        protected override void OnAppearing()
        {
            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
            using (ApplicationContext db = new ApplicationContext(dbPath))
            {
                PkList.ItemsSource = db.Sobities.Where(x => x.Type == "Показ");
            }
            base.OnAppearing();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }


        private async void PkList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Sobitie selectedSobitie = e.SelectedItem as Sobitie;
            if (selectedSobitie != null)
            {
                // Снимаем выделение
                PkList.SelectedItem = null;
                // Переходим на страницу редактирования элемента 
                await Navigation.PushAsync(new SobitieSelected(selectedSobitie));
            }
        }

    }
}