using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Classes
{
    class PreferenceData
    {
        [JsonProperty("Theme")]
        private string Theme
        {
            set
            {
                Preferences.Instance.Theme = value;
            }
        }

        [JsonProperty("HomePage")]
        private string HomePage
        {
            set
            {
                Preferences.Instance.HomePage = value;
            }
        }

        [JsonProperty("HomeCity")]
        private string HomeCity
        {
            set
            {
                Preferences.Instance.HomeCity = value;
            }
        }
    }
}
