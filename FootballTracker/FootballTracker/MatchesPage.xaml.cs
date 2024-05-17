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
    public partial class MatchesPage : ContentPage
    {
        public MatchesPage()
        {
            InitializeComponent();
            var swipeGesture = new SwipeGestureRecognizer();
            swipeGesture.Swiped += OnSwiped;
            DateSlider.GestureRecognizers.Add(swipeGesture);
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