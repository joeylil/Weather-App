using errorHandling;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Weather.Classes;
using Windows.Networking.Connectivity;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Weather.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UnitedKingdomCurrentWeatherView : Page
    {
        public UnitedKingdomCurrentWeatherView()
        {                      
            this.InitializeComponent();
            RequestedTheme = Preferences.Instance.ElementTheme;
            Background = Preferences.Instance.Theme == "Dark" ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.LightBlue);
            CurrentUKWeather();           
        }

        private void CurrentUKWeather()
        {
            ObservableCollection<CurrentWeather> weathers = new ObservableCollection<CurrentWeather>();
            foreach (KeyValuePair<string, string> city in CityToID.Instance.unitedkingdomCities)
            {
                WeatherAPI api = new WeatherAPI();
                CurrentWeather weather = api.GetCurrentWeather(city.Value).Result;
                if (weather == null)
                {
                    UKCurrentWeatherProgressRing.IsActive = false;
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

                try
                {
                    string checker = weather.WeatherDescription;
                }
                catch (NullReferenceException)
                {
                    UKCurrentWeatherProgressRing.IsActive = false;
                    ErrorText.Text = "Response Error: please contact support for further information";
                    return;
                }
                weather.Location = city.Key;
                weathers.Add(weather);


                UKCurrentWeatherProgressRing.IsActive = false;
                listview.ItemsSource = weathers;
                Logger.Instance.LogSuccessFullLoad();
            }
        }      
    }
}
