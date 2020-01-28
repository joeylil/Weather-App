using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Classes
{
    class PreferencesViews
    {
        public List<string> Pages { get; set; }
        public List<string> Themes { get; set; }
        public List<string> PerthCities { get; set; }
        public PreferencesViews()
        {
            PerthCities = new List<string>()
            {
                "Adelaide",
                "Brisbane",
                "Canberra",
                "Darwin",
                "Hobart",
                "Melbourne",
                "Perth",
                "Sydney"
            };

            Themes = new List<string>()
            {
                "Dark",
                "Light"
            };

            Pages = new List<string>()
            {
                "Forecast",
                "Australian Current Weather",
                "United Kingdom Current Weather"
            };
        }

    }
}
