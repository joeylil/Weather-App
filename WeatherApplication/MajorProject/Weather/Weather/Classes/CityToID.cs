using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Classes
{
    class CityToID
    {
        private static CityToID _instance = null;
        public Dictionary<string, string> australianCities = new Dictionary<string, string>
        {
            {"Adelaide","7839644"},
            {"Brisbane", "2172517"},
            {"Canberra", "2172517"},
            {"Darwin","7839402"},
            {"Hobart","2163355"},
            {"Perth", "2063523"},
            {"Melbourne","7839805"},
            {"Sydney","2154855"},
        };

        public Dictionary<string, string> unitedkingdomCities = new Dictionary<string, string>
        {
            {"Birmingham","2655603"},
            {"Bradford ", "2654993"},
            {"Bristol ", "2654675"},
            {"Leeds ","2644688"},
            {"London ","2643743"},
            {"Manchester ","2643123"},
            {"Newcastle ", "2641673"},
            {"Sheffield ","2638077"},
            {"Sunderland ","2636531"},
            {"Wolverhampton  ","2633691"},
        };

        public static CityToID Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CityToID();
                }
                return _instance;
            }
        }
    }
}
