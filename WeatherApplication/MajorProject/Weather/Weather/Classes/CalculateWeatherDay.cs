using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Classes
{
    public class CalculateWeatherDay
    {
        public Weather CalculateUsefulWeather(IList<WeatherRawData> weathers)
        {
            
            float max = int.MinValue;
            float min = int.MaxValue;
            int averagePressure = 0;
            int averageHumidity = 0;
            float totalRainfall = 0;
            int numberOfDays = weathers.Count;
            List<string> weatherTypes = new List<string>();

            foreach (WeatherRawData weather in weathers)
            {
                if (weather.MainData.Temperature > max)
                {
                    max = weather.MainData.Temperature;
                }
                if (weather.MainData.Temperature < min)
                {
                    min = weather.MainData.Temperature;
                }
                averageHumidity += weather.MainData.Humidity;
                averagePressure += weather.MainData.Pressure;
                weatherTypes.Add(weather.WeatherInfo[0].WeatherType);
                try
                {
                    totalRainfall += weather.RainFall.RainVolumeOverPast3Hours;
                }
                catch (NullReferenceException)
                {
                    continue;
                }
            }
            var weatherTypesCount = weatherTypes.GroupBy(i => i);
            int maxCount = 0;
            string weatherType = "";
            foreach (var group in weatherTypesCount)
            {
                if (group.Count() > maxCount)
                {
                    weatherType = group.Key;
                    maxCount = group.Count();
                }
            }
            weatherType += ".jpg";
            Weather DaysWeather = new Weather( (int)Math.Round(min), (int)Math.Round(max), averageHumidity / numberOfDays, averagePressure / numberOfDays, totalRainfall, weatherType);
            return DaysWeather;
        }
    }
}
