using FootballTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FootballTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            InitializeData();
            

            
        }
        private async void InitializeData()
        {
            var favoriteTeam = 33; //(int)Application.Current.Properties["FavoriteTeam"];

            IApiService apiService = new ApiService();

            var team = await apiService.GetMatchByFavTeam(favoriteTeam);

            var previousMatch1 = team[0];
            var previousMatch2 = team[1];
            var nextMatch = team[2];

            
            prevMatch.BindingContext = previousMatch1;
            prevMatch2.BindingContext = previousMatch1;
            nMatch.BindingContext = previousMatch1;
        }
    }
}