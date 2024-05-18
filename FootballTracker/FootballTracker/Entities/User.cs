using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTracker.Entities
{
    class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FavoriteTeam { get; set; }
        public string LogoUrl { get; set; }
    }
}
