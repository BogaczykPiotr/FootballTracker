using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTracker.Models
{
    public class Match
    {
        public string Home { get; set; }
        public string HomeLogo { get; set; }
        public string GoalHome { get; set; }
        public string Away { get; set; }
        public string AwayLogo { get; set; }
        public string GoalAway{ get; set; }
        public string Time { get; set; }
    }

}
