using FootballTracker.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FootballTracker
{
    public partial class Tabbed : TabbedPage
    {
        public Tabbed()
        {
            InitializeComponent();
            AddPages();
        }

        private void AddPages()
        {
            if(App.IsUserLoggedIn)
            {
                Children.Add(new NavigationPage(new LoggedPage())
                {
                    Title = "PROFIL",
                    IconImageSource = new FontImageSource
                    {
                        FontFamily = "FASolid",
                        Glyph = "\uf007"
                    }
                });
            }
            else
            {
                Children.Add(new NavigationPage(new LoginPage())
                {
                    Title = "ZALOGUJ",
                    IconImageSource = new FontImageSource
                    {
                        FontFamily = "FASolid",
                        Glyph = "\uf007"
                    }
                });
            }
        }
    }
}
