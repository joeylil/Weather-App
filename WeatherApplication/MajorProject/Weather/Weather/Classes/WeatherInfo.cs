using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Classes
{
    public class WeatherInfo
    {
        [JsonProperty("main")]
        private string _weatherType;

        public string WeatherType
        {
            get { return _weatherType; }
            set
            {
                _weatherType = value;
            }
        }
    }
}
