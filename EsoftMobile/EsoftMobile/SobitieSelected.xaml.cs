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
    public partial class SobitieSelected : ContentPage
    {

        public SobitieSelected(Sobitie selectedSobitie)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = selectedSobitie;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
            var sobitie = (Sobitie)BindingContext;
            using (ApplicationContext db = new ApplicationContext(dbPath))
            {
                db.Sobities.Remove(sobitie);
                db.SaveChanges();
            }
            this.Navigation.PopAsync();
        }
    }
}