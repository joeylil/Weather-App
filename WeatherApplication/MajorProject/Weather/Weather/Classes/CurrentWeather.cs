using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Weather.Classes
{
    public class CurrentWeather
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string HardCodedWeather
        {
            get
            {
                return "{\"coord\":{\"lon\":138.6,\"lat\":-34.92},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04d\"}],\"base\":\"stations\",\"main\":{\"temp\":16.7,\"pressure\":1016,\"humidity\":63,\"temp_min\":14.44,\"temp_max\":18.33},\"visibility\":10000,\"wind\":{\"speed\":7.7,\"deg\":230},\"clouds\":{\"all\":75},\"dt\":1575334803,\"sys\":{\"type\":1,\"id\":9566,\"country\":\"AU\",\"sunrise\":1575314712,\"sunset\":1575366324},\"timezone\":37800,\"id\":7839644,\"name\":\"Adelaide\",\"cod\":200}";
            }
        }

        public string WeatherDescription
        {
            get
            {
                return WeatherData[0].Description;
            }
        }

        public BitmapImage WeatherMain
        {
            get
            {
                BitmapImage bitmapImage = new BitmapImage();
                Uri imageUri = new Uri(string.Format("ms-appx:///Assets//{0}.jpg", WeatherData[0].Main));              
                bitmapImage.UriSource = imageUri;
                return bitmapImage;
            }
        }

        public string DisplayMaxTemp
        {
            get
            {
                return string.Format("Max: {0} °C", MainData.TemperatureMax);
            }
        }

        public string DisplayMinTemp
        {
            get
            {
                return string.Format("Min: {0} °C", MainData.TemperatureMin);
            }
        }

        public string DisplayTemp
        {
            get
            {
                return string.Format("{0} °C", MainData.Temp);
            }
        }

        public string DisplayWeatherDescription
        {
            get
            {
                string DisplayWeather = WeatherData[0].Description;
                return char.ToUpper(DisplayWeather[0]) + DisplayWeather.Substring(1);
            }
        }

        public string DisplayHumidity
        {
            get
            {
                return string.Format("Humidity:\n   {0}%", MainData.Humidity);
            }
        }

        public string DisplayPressure
        {
            get
            {
                return string.Format("Pressure:\n{0} hPa", MainData.Pressure);
            }
        }


        [JsonProperty("weather")]
        private List<WeatherInfo> _weatherData;

        public List<WeatherInfo> WeatherData
        {
            get
            {
                return _weatherData;
            }
            set
            {
                _weatherData = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WeatherData"));
            }
        }

        [JsonProperty("main")]
        Main _mainData;

        public Main MainData
        {
            get
            {
                return _mainData;
            }
            set
            {
                _mainData = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MainData"));
            }
        }

        private string _location;

        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }

        public class WeatherInfo
        {
            [JsonProperty("main")]
            private string _main;

            public string Main
            {
                get
                {
                    return _main;
                }
                set
                {
                    _main = value;
                }
            }

            [JsonProperty("description")]
            private string _description;

            public string Description
            {
                get
                {
                    return _description;
                }
                set
                {
                    _description = value;
                }
            }
        }

        public class Main
        {
            [JsonProperty("temp")]
            private string _temp;

            public string Temp
            {
                get
                {
                    return _temp;
                }
                set
                {
                    _temp = value;
                }
            }

            [JsonProperty("pressure")]
            private string _pressure;

            public string Pressure
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
            private string _Humidity;

            public string Humidity
            {
                get
                {
                    return _Humidity;
                }
                set
                {
                    _Humidity = value;
                }
            }

            [JsonProperty("temp_Min")]
            private string _TemperatureMin;

            public string TemperatureMin
            {
                get
                {
                    return _TemperatureMin;
                }
                set
                {
                    _TemperatureMin = value;
                }
            }

            [JsonProperty("temp_Max")]
            private string _TemperatureMax;

            public string TemperatureMax
            {
                get
                {
                    return _TemperatureMax;
                }
                set
                {
                    _TemperatureMax = value;
                }
            }
        }
    }
}
