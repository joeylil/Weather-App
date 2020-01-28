using System;
using System.Threading.Tasks;
using Weather.Classes;
using Weather.Views;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Weather
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WeatherTypePage : Page
    {

        public WeatherTypePage()
        {
            LoadPage();
            this.InitializeComponent();
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                ContentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;

                switch (item.Tag.ToString())
                {
                    case "Forecast":
                        ContentFrame.Navigate(typeof(ForecastFiveDaysView));
                        break;
                    case "Australian Weather":
                        ContentFrame.Navigate(typeof(AustralianCurrentWeatherView));
                        break;
                    case "United Kingdom Weather":
                        ContentFrame.Navigate(typeof(UnitedKingdomCurrentWeatherView));
                        break;
                }
            }
        }

        private async Task LoadPage()
        {
            await Preferences.Instance.Load();

            RequestedTheme = Preferences.Instance.ElementTheme;
            if(Preferences.Instance.Theme == "Dark")
            {
                Background = new SolidColorBrush(Colors.Black);

            }
            else
            {
                Background = new SolidColorBrush(Colors.LightBlue);
            }

            //load home page based on preferences, default forecast
            switch (Preferences.Instance.HomePage)
            {
                case "Forecast":
                    ContentFrame.Navigate(typeof(ForecastFiveDaysView));
                    break;
                case "Australian Current Weather":
                    ContentFrame.Navigate(typeof(AustralianCurrentWeatherView));
                    break;
                case "United Kingdom Current Weather":
                    ContentFrame.Navigate(typeof(UnitedKingdomCurrentWeatherView));
                    break;
                default:
                    ContentFrame.Navigate(typeof(ForecastFiveDaysView));
                    break;
            }
        }
    }
}
