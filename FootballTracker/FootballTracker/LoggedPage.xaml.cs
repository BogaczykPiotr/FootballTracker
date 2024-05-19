using FootballTracker.Entities;
using FootballTracker.Models;
using FootballTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FootballTracker
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoggedPage : ContentPage
	{
		public LoggedPage ()
		{
            InitializeComponent();
            InitializeData();


        }

        private async void InitializeData()
        {
            var favoriteTeam = (int)Application.Current.Properties["FavoriteTeam"]; // 123123123123

            IApiService apiService = new ApiService();

            var team = await apiService.GetTeamName(favoriteTeam);

            user.Text = App.UserName;

            BindingContext = team;
        }


    }
}