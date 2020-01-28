using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Classes
{
    public class WeatherRawData
    {

        public String DisplayDate
        {
            get
            {
                return string.Format("{0}\n{1}", DateOfforecast.DayOfWeek, DateOfforecast.ToString("dd-MM-yyyy"));
            }
        }

        [JsonProperty("main")]
        private Main _mainData;

        public Main MainData
        {
            get { return _mainData; }
            set
            {
                _mainData = value;
            }
        }


        [JsonProperty("weather")]
        private List<WeatherInfo> _weatherInfo;

        public List<WeatherInfo> WeatherInfo
        {
            get { return _weatherInfo; }
            set
            {
                _weatherInfo = value;
            }
        }   

        [JsonProperty("rain")]
        private Rain _rainFall;

        public Rain RainFall
        {
            get { return _rainFall; }
            set
            {
                _rainFall = value;
            }
        }

        [JsonProperty("dt_txt")]
        public DateTime DateOfforecast { set; get; }
    }
}
