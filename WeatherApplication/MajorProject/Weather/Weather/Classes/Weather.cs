using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Classes
{
    public class Weather
    {
        public Weather() { }
        public Weather(int minTemp, int maxTemp, int averageHumidity, int averagePressure, float totalRainfall, string weatherType)
        {
            this.MaxTemp = maxTemp;
            this.MinTemp = minTemp;
            this.AverageHumidity = averageHumidity;
            this.AveragePressure = averagePressure;
            this.TotalRainfall = totalRainfall;
            this.WeatherType = weatherType;
        }

        private int _maxTemp;

        public int MaxTemp
        {
            get
            {
                return _maxTemp;
            }
            set
            {
                _maxTemp = value;
            }
        }

        private int _minTemp;

        public int MinTemp
        {
            get
            {
                return _minTemp;
            }
            set
            {
                _minTemp = value;
            }
        }

        private int _averageHumidity;

        public int AverageHumidity
        {
            get
            {
                return _averageHumidity;
            }
            set
            {
                _averageHumidity = value;
            }
        }

        private int _averagePressure;

        public int AveragePressure
        {
            get
            {
                return _averagePressure;
            }
            set
            {
                _averagePressure = value;
            }
        }

        private float _totalRainfall;

        public float TotalRainfall
        {
            get
            {
                return _totalRainfall;
            }
            set
            {
                _totalRainfall = value;
            }
        }

        private string _weatherType;

        public string WeatherType
        {
            get
            {
                return _weatherType;
            }
            set
            {
                _weatherType = value;
            }
        }
    }
}
