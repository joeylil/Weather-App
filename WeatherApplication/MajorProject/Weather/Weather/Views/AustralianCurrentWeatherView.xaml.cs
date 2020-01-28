using errorHandling;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using Weather.Classes;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Connectivity;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Weather.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AustralianCurrentWeatherView : Page
    {
        private void CurrentWeather()
        {
            ObservableCollection<CurrentWeather> weathers = new ObservableCollection<CurrentWeather>();
                foreach (KeyValuePair<string, string> city in CityToID.Instance.australianCities)
                {
                    WeatherAPI api = new WeatherAPI();
                    CurrentWeather weather = api.GetCurrentWeather(city.Value).Result;
                    if (weather == null)
                    {
                        AustralianCurrentWeatherProgressRing.IsActive = false;
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
                        else if (api.errType == "APIParameterChange")
                        {
                            ErrorText.Text = "Response Error: please contact support for further information";
                            return;
                        }
                    }
                //check if deserializing of json data is yielded useful information
                try
                {                 
                    string checker = weather.WeatherDescription;
                }
                catch(NullReferenceException)
                {
                    AustralianCurrentWeatherProgressRing.IsActive = false;
                    ErrorText.Text = "Response Error: please contact support for further information";
                    return;
                }
                    weather.Location = city.Key;
                    weathers.Add(weather);
                }
            

            AustralianCurrentWeatherProgressRing.IsActive = false;
            listview.ItemsSource = weathers;
            Logger.Instance.LogSuccessFullLoad();
        }

        public AustralianCurrentWeatherView()
        {
            InitializeComponent();
            RequestedTheme = Preferences.Instance.ElementTheme;
            if (Preferences.Instance.Theme == "Dark")
            {
                Background = new SolidColorBrush(Colors.Black);

            }
            else
            {
                Background = new SolidColorBrush(Colors.LightBlue);
            }
            CurrentWeather();
        }
    }
}
