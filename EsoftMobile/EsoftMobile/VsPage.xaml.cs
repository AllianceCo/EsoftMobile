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
    public partial class VsPage : ContentPage
    {
        public VsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        protected override void OnAppearing()
        {
            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
            using (ApplicationContext db = new ApplicationContext(dbPath))
            {
                VsList.ItemsSource = db.Sobities.Where(x => x.Type == "Встреча");
            }
            base.OnAppearing();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        private void Delete_Clicked(object sender, EventArgs e)
        {

        }

        private async void VsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Sobitie selectedSobitie = e.SelectedItem as Sobitie;
            if (selectedSobitie != null)
            {
                // Снимаем выделение
                VsList.SelectedItem = null;
                // Переходим на страницу редактирования элемента 
                await Navigation.PushAsync(new SobitieSelected(selectedSobitie));
            }
        }
    }
}