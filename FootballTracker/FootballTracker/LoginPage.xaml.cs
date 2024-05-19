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
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FootballTracker
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDb.db");
            var db = new SQLiteConnection(dbPath);

            var hashedPassword = HashPassword(password.Text);

            var query = db.Table<User>().Where(u => u.Email == email.Text && u.Password == hashedPassword);

            if (query.Any())
            {
                var user = query.FirstOrDefault();
                App.IsUserLoggedIn = true;
                App.UserName = user.UserName; 
                App.Current.MainPage = new Tabbed();
                
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await DisplayAlert("Błąd", "Błędny adres email lub hasło", "Ok", "Zamknij");

                    if (result)
                        App.Current.MainPage = new LoginPage();

                    else
                    App.Current.MainPage = new Tabbed();
                });
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            App.Current.MainPage = new RegisterPage();
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}