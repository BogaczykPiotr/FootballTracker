
using FootballTracker.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FootballTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchesPage : ContentPage
    {
        public MatchesPage()
        {
            InitializeComponent();
            LoadMatches();
        }

        private async void LoadMatches()
        {
            IApiService apiService = new ApiService();
            var matches = await apiService.GetMatches();
            listView.ItemsSource = matches;
        }

        

       
    }
}