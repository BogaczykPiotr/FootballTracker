
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

            var swipeGesture = new SwipeGestureRecognizer();
            swipeGesture.Swiped += OnSwiped;
            DateSlider.GestureRecognizers.Add(swipeGesture);
        }

        private async void LoadMatches()
        {
            IApiService apiService = new ApiService();
            var matches = await apiService.GetMatches();
            listView.ItemsSource = matches;
        }

        void OnSwiped(object sender, SwipedEventArgs e)
        {
            if (e.Direction == SwipeDirection.Left)
            {
                // Przesuń slider w lewo
                DateSlider.TranslateTo(-100, 0, 500, Easing.Linear);
            }
            else if (e.Direction == SwipeDirection.Right)
            {
                // Przesuń slider w prawo
                DateSlider.TranslateTo(100, 0, 500, Easing.Linear);
            }
        }

       
    }
}