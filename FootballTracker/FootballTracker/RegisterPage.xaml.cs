using FootballTracker.Entities;
using FootballTracker.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FootballTracker
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
        private string _selectedTeam;
		public RegisterPage ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDb.db");
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<User>();

            var teamId = 0;

            switch (_selectedTeam)
            {
                case "Real Madryt":
                    teamId = 541;
                    break;

                case "FC Barcelona":
                    teamId = 529;
                    break;

                case "Manchester United":
                    teamId = 33;
                    break;

                case "Bayern Monachium":
                    teamId = 157;
                    break;

                case "Paris Saint Germain":
                    teamId = 85;
                    break;
            }

            var hashedPassword = HashPassword(password.Text);

            var item = new User()
            {
                Email = email.Text,
                UserName = userName.Text,
                Password = hashedPassword,
                FavoriteTeam = teamId
            };

            db.Insert(item);
            Application.Current.Properties["FavoriteTeam"] = item.FavoriteTeam;
            await Application.Current.SavePropertiesAsync();
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await DisplayAlert("Sukces", "Użytkownik został zarejestrowany", "Ok", "Zamknij");

                if (result)
                    Application.Current.MainPage = new LoginPage();

            });
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        private void teams_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;

            int selectedIndex = picker.SelectedIndex;

            _selectedTeam = picker.Items[selectedIndex];

        }
    }
}