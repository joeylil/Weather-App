using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Classes
{
    public class Main
    {
        [JsonProperty("temp")]
        private int _temperature;

        public int Temperature
        {
            get
            {
                return _temperature;
            }
            set
            {
                _temperature = value;
            }
        }

        [JsonProperty("pressure")]
        private int _pressure;

        public int Pressure
        {
            get
            {
                return _pressure;
            }
            set
            {
                _pressure = value;
            }
        }

        [JsonProperty("humidity")]
        private int _humidity;

        public int Humidity
        {
            get
            {
                return _humidity;
            }
            set
            {
                _humidity = value;
            }
        }

        [JsonProperty("temp_Min")]
        private int _temperatureMin;

        public int TemperatureMin
        {
            get
            {
                return _temperatureMin;
            }
            set
            {
                _temperatureMin = value;
            }
        }

        [JsonProperty("temp_Max")]
        private int _temperatureMax;

        public int TemperatureMax
        {
            get
            {
                return _temperatureMax;
            }
            set
            {
                _temperatureMax = value;
            }
        }
    }
}
