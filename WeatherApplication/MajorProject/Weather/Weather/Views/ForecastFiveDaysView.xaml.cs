using errorHandling;
using System;
using System.Collections.Generic;
using Weather.Classes;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Weather.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ForecastFiveDaysView : Page
    {
        private async void Forecast()
        {
            string homeCityID;
            CityToID.Instance.australianCities.TryGetValue(Preferences.Instance.HomeCity, out homeCityID);
                WeatherAPI api = new WeatherAPI();
                IList<IList<WeatherRawData>> WeatherData = api.GetforecastWeather(homeCityID).Result;

                if (WeatherData == null)
                {
                    ForeCastProgressRing.IsActive = false;
                    if (api.errType == "Internet")
                    {
                        ErrorText.Text = "No response: Please check your internet connection";
                        return;
                    }
                    else if (api.errType == "WebsiteError")
                    {
                        ErrorText.Text = "Reponse error: Please contact support for further information";
                        return;
                    }
                    else if(api.errType == "APIParameterChange")
                    {
                        ErrorText.Text = "Response Error: please contact support for further information";
                        return;
                    }
                }
              
                LocationText.Text = Preferences.Instance.HomeCity;

                Classes.Weather DayOne = new Classes.Weather();
                Classes.Weather DayTwo = new Classes.Weather();
                Classes.Weather DayThree = new Classes.Weather();
                Classes.Weather DayFour = new Classes.Weather();
                Classes.Weather DayFive = new Classes.Weather();

                CalculateWeatherDay CalculateWeather = new CalculateWeatherDay();

                //****Convert each day to useful data
                //Day One

                DateTime DayOneDate = WeatherData[0][0].DateOfforecast;
                DayOne = CalculateWeather.CalculateUsefulWeather(WeatherData[0]);
                DateDayOne.Text = WeatherData[0][0].DisplayDate;
                DayOneMaxTemp.Text = string.Format("Max: {0} °C", DayOne.MaxTemp.ToString());
                DayOneMinTemp.Text = string.Format("Min: {0} °C", DayOne.MinTemp.ToString());
                DayOneAverageHumidity.Text = string.Format("Humidity: {0} %", DayOne.AverageHumidity.ToString());
                BitmapImage bitmapImageDayOne = new BitmapImage();
                ///File licenses/credit here
                /// 1/ <a href="https://pngtree.com/free-backgrounds">free background photos from pngtree.com</a>
                /// 2/ sourced from: https://www.flashcardsforkindergarten.com/weather-flashcards/
                /// 3/ https://africanaprincess.wordpress.com/2018/08/22/fog/
                ///
                Uri imageFileDayOne = new Uri(string.Format("ms-appx:///Assets//{0}", DayOne.WeatherType));
                bitmapImageDayOne.UriSource = imageFileDayOne;
                WeatherImageDayOne.Source = bitmapImageDayOne;
                DayOneAverageWindSpeed.Text = string.Format("Pressure: {0} hPa", DayOne.AveragePressure);
                DayOneTotalRainfall.Text = string.Format("Expected Rainfall: {0:0.00} mm", DayOne.TotalRainfall);


                //Day Two
                DateTime DayTwoDate = WeatherData[1][0].DateOfforecast;
                DayTwo = CalculateWeather.CalculateUsefulWeather(WeatherData[1]);
                DateDayTwo.Text = WeatherData[1][1].DisplayDate;
                DayTwoMaxTemp.Text = string.Format("Max: {0} °C", DayTwo.MaxTemp.ToString());
                DayTwoMinTemp.Text = string.Format("Min: {0} °C", DayTwo.MinTemp.ToString());
                DayTwoAverageHumidity.Text = string.Format("Humidity: {0} %", DayTwo.AverageHumidity.ToString());
                BitmapImage bitmapImageDayTwo = new BitmapImage();
                Uri imageFileDayTwo = new Uri(string.Format("ms-appx:///Assets//{0}", DayTwo.WeatherType));
                bitmapImageDayTwo.UriSource = imageFileDayTwo;
                WeatherImageDayTwo.Source = bitmapImageDayTwo;
                DayTwoAverageWindSpeed.Text = string.Format("Pressure: {0} hPa", DayTwo.AveragePressure);
                DayTwoTotalRainfall.Text = string.Format("Expected Rainfall: {0:0.00} mm", DayTwo.TotalRainfall);



            //Day Three
            DateTime DayThreeDate = WeatherData[2][0].DateOfforecast;
                DayThree = CalculateWeather.CalculateUsefulWeather(WeatherData[2]);
                DateDayThree.Text = WeatherData[2][0].DisplayDate;
                DayThreeMaxTemp.Text = string.Format("Max: {0} °C", DayThree.MaxTemp.ToString());
                DayThreeMinTemp.Text = string.Format("Min: {0} °C", DayThree.MinTemp.ToString());
                DayThreeAverageHumidity.Text = string.Format("Humidity: {0} %", DayThree.AverageHumidity.ToString());
                BitmapImage bitmapImageDayThree = new BitmapImage();
                Uri imageFileDayThree = new Uri(string.Format("ms-appx:///Assets//{0}", DayThree.WeatherType));
                bitmapImageDayThree.UriSource = imageFileDayThree;
                WeatherImageDayThree.Source = bitmapImageDayThree;
                DayThreeAverageWindSpeed.Text = string.Format("Pressure: {0} hPa", DayThree.AveragePressure);
                DayThreeTotalRainfall.Text = string.Format("Expected Rainfall: {0:0.00} mm", DayThree.TotalRainfall);




            //Day Four
            DateTime DayFourDate = WeatherData[3][0].DateOfforecast;
                DayFour = CalculateWeather.CalculateUsefulWeather(WeatherData[3]);
                DateDayFour.Text = WeatherData[3][0].DisplayDate;
                DayFourMaxTemp.Text = string.Format("Max: {0} °C", DayFour.MaxTemp.ToString());
                DayFourMinTemp.Text = string.Format("Min: {0} °C", DayFour.MinTemp.ToString());
                DayFourAverageHumidity.Text = string.Format("Humidity: {0} %", DayFour.AverageHumidity.ToString());
                BitmapImage bitmapImageDayFour = new BitmapImage();
                Uri imageFileDayFour = new Uri(string.Format("ms-appx:///Assets//{0}", DayFour.WeatherType));
                bitmapImageDayFour.UriSource = imageFileDayFour;
                WeatherImageDayFour.Source = bitmapImageDayFour;
                DayFourAverageWindSpeed.Text = string.Format("Pressure: {0} hPa", DayFour.AveragePressure);
                DayFourTotalRainfall.Text = string.Format("Expected Rainfall: {0:0.00} mm", DayFour.TotalRainfall);



            //Day Five
            DateTime DayFiveDate = WeatherData[4][0].DateOfforecast;
                DayFive = CalculateWeather.CalculateUsefulWeather(WeatherData[4]);
                DateDayFive.Text = WeatherData[4][0].DisplayDate;
                DayFiveMaxTemp.Text = string.Format("Max: {0} °C", DayFive.MaxTemp.ToString());
                DayFiveMinTemp.Text = string.Format("Min: {0} °C", DayFive.MinTemp.ToString());
                DayFiveAverageHumidity.Text = string.Format("Humidity: {0} %", DayFive.AverageHumidity.ToString());
                BitmapImage bitmapImageDayFive = new BitmapImage();
                Uri imageFileDayFive = new Uri(string.Format("ms-appx:///Assets//{0}", DayFive.WeatherType));
                bitmapImageDayFive.UriSource = imageFileDayFive;
                WeatherImageDayFive.Source = bitmapImageDayFive;
                DayFiveAverageWindSpeed.Text = string.Format("Pressure: {0} hPa", DayFive.AveragePressure);
                DayFiveTotalRainfall.Text = string.Format("Expected Rainfall: {0:.00} mm", DayFive.TotalRainfall);



            ForeCastProgressRing.IsActive = false;
            Logger.Instance.LogSuccessFullLoad();
        }
        public ForecastFiveDaysView()
        {
            this.InitializeComponent();
            RequestedTheme = Preferences.Instance.ElementTheme;
            if (Preferences.Instance.Theme == "Dark")
            {
                Background = new SolidColorBrush(Colors.Black);

            }
            else
            {
                Background = new SolidColorBrush(Colors.LightBlue);
            }
            Forecast();
        }

    }
}
