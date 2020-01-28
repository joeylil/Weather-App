using Microsoft.VisualStudio.TestTools.UnitTesting;
using Weather.Classes;
using System.Runtime;


namespace TestSuite
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CurrentWeathercalls()
        {
            CurrentWeather TestWeather = new CurrentWeather();

            WeatherAPI api = new WeatherAPI();
            api.isTest = true;
            var CurrentWeather = api.GetCurrentWeather("7839644").Result;
            Assert.AreEqual(CurrentWeather.MainData.Temp, "16.7");
            Assert.AreEqual(CurrentWeather.MainData.Humidity, "63");
            Assert.AreEqual(CurrentWeather.MainData.Humidity, "63");
            Assert.AreEqual(CurrentWeather.MainData.TemperatureMax, "18.33");
            Assert.AreEqual(CurrentWeather.MainData.TemperatureMin, "14.44");
            Assert.AreEqual(CurrentWeather.WeatherData[0].Description, "broken clouds");
            Assert.AreEqual(CurrentWeather.WeatherData[0].Main, "Clouds");
        }

        [TestMethod]
        public void forecastTempTests()
        {
            WeatherAPI api = new WeatherAPI();
            api.isTest = true;
            var forecastWeather = api.GetforecastWeather("2163355").Result;
            Assert.AreEqual(forecastWeather[0][0].MainData.Temperature, 9);
            Assert.AreEqual(forecastWeather[0][0].MainData.Temperature, 9);
            Assert.AreEqual(forecastWeather[2][6].MainData.Temperature, 11);
            Assert.AreEqual(forecastWeather[2][6].MainData.Temperature, 11);
            Assert.AreEqual(forecastWeather[1][3].MainData.Temperature, 10);
            Assert.AreEqual(forecastWeather[3][7].MainData.Temperature, 12);
            Assert.AreEqual(forecastWeather[4][3].MainData.Temperature, 12);
        }

        [TestMethod]
        public void forecastHumidityTests()
        {
            WeatherAPI api = new WeatherAPI();
            api.isTest = true;
            var forecastWeather = api.GetforecastWeather("2163355").Result;
            Assert.AreEqual(forecastWeather[0][1].MainData.Humidity, 72);
            Assert.AreEqual(forecastWeather[1][3].MainData.Humidity, 68);
            Assert.AreEqual(forecastWeather[1][6].MainData.Humidity, 71);
            Assert.AreEqual(forecastWeather[3][5].MainData.Humidity, 69);
            Assert.AreEqual(forecastWeather[4][5].MainData.Humidity, 72);
        }

        [TestMethod]
        public void forecastRainfallTests()
        {
            WeatherAPI api = new WeatherAPI();
            api.isTest = true;
            var forecastWeather = api.GetforecastWeather("2163355").Result;
            Assert.AreEqual(forecastWeather[0][1].RainFall.RainVolumeOverPast3Hours, 1.13f);
            Assert.AreEqual(forecastWeather[0][4].RainFall.RainVolumeOverPast3Hours, 0.13f);
            Assert.AreEqual(forecastWeather[2][2].RainFall.RainVolumeOverPast3Hours, 0.19f);
            Assert.AreEqual(forecastWeather[2][7].RainFall.RainVolumeOverPast3Hours, 0.5f);
            Assert.AreEqual(forecastWeather[4][2].RainFall, null);
            Assert.AreEqual(forecastWeather[4][8].RainFall, null);
        }

        [TestMethod]
        public void forecastWeatherTypeTests()
        {
            WeatherAPI api = new WeatherAPI();
            api.isTest = true;
            var forecastWeather = api.GetforecastWeather("2163355").Result;
            Assert.AreEqual(forecastWeather[0][1].WeatherInfo[0].WeatherType, "Rain");
            Assert.AreEqual(forecastWeather[0][4].WeatherInfo[0].WeatherType, "Rain");
            Assert.AreEqual(forecastWeather[2][2].WeatherInfo[0].WeatherType, "Rain");
            Assert.AreEqual(forecastWeather[2][7].WeatherInfo[0].WeatherType, "Rain");
            Assert.AreEqual(forecastWeather[4][2].WeatherInfo[0].WeatherType, "Clear");
            Assert.AreEqual(forecastWeather[4][8].WeatherInfo[0].WeatherType, "Clouds");
        }

        [TestMethod]
        public void forecastCallCounts()
        {
            WeatherAPI api = new WeatherAPI();
            api.isTest = true;
            var forecastWeather = api.GetforecastWeather("2163355").Result;
            Assert.AreEqual(forecastWeather[0].Count, 7);
            Assert.AreEqual(forecastWeather[1].Count, 8);
            Assert.AreEqual(forecastWeather[2].Count, 8);
            Assert.AreEqual(forecastWeather[3].Count, 8);
            Assert.AreEqual(forecastWeather[4].Count, 9);
        }

        [TestMethod]
        public void forecastWeatherCalculations()
        {
            WeatherAPI api = new WeatherAPI();
            api.isTest = true;
            var forecastWeather = api.GetforecastWeather("2163355").Result;
            CalculateWeatherDay CalculateWeather = new CalculateWeatherDay();
            Weather.Classes.Weather WeatherDay = new Weather.Classes.Weather();
            WeatherDay = CalculateWeather.CalculateUsefulWeather(forecastWeather[0]);           
            Assert.AreEqual(WeatherDay.MaxTemp, 11);
            Assert.AreEqual(WeatherDay.MinTemp, 7);
            Assert.AreEqual((int)WeatherDay.TotalRainfall, 3);
            Assert.AreEqual(WeatherDay.WeatherType, "Rain.jpg");
            Assert.AreEqual(WeatherDay.AveragePressure, 995);
            Assert.IsTrue(WeatherDay.MaxTemp >= WeatherDay.MinTemp);
            Assert.IsTrue(WeatherDay.AverageHumidity <= 100);
        }
    }
}
