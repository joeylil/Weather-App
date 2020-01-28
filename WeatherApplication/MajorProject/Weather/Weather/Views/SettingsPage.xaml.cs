using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Weather.Classes;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class SettingsPage : Page
    {

        public SettingsPage()
        {           
            this.InitializeComponent();
            PreferencesViews preferenceView = new PreferencesViews();
            if (Preferences.Instance != null)
            {
                HomeCityComboBox.SelectedIndex = preferenceView.PerthCities.IndexOf(Preferences.Instance.HomeCity);
                ThemeComboBox.SelectedIndex = preferenceView.Themes.IndexOf(Preferences.Instance.Theme);
                HomePageComboBox.SelectedIndex = preferenceView.Pages.IndexOf(Preferences.Instance.HomePage);
            }
            RequestedTheme = Preferences.Instance.ElementTheme;
            if (Preferences.Instance.Theme == "Dark")
            {
                Background = new SolidColorBrush(Colors.Black);

            }
            else
            {
                Background = new SolidColorBrush(Colors.LightBlue);
            }
            DataContext = new PreferencesViews();
        }

        private void SavePreferences(object sender, RoutedEventArgs e)
        {
            try
            {
                Preferences.Instance.Theme = ThemeComboBox.SelectedValue.ToString();
                Preferences.Instance.HomeCity = HomeCityComboBox.SelectedValue.ToString();
                Preferences.Instance.HomePage = HomePageComboBox.SelectedValue.ToString();
            }
            catch (NullReferenceException)
            {
                if (ThemeComboBox.SelectedItem == null)
                {
                    ThemeRequiredText.Visibility = Visibility.Visible;
                }
                else
                {
                    ThemeRequiredText.Visibility = Visibility.Collapsed;

                }

                if (HomeCityComboBox.SelectedItem == null)
                {
                    HomeCityRequiredText.Visibility = Visibility.Visible;
                }
                else
                {
                    HomeCityRequiredText.Visibility = Visibility.Collapsed;

                }

                if (HomePageComboBox.SelectedItem == null)
                {
                    HomePageRequiredText.Visibility = Visibility.Visible;
                }
                else
                {
                    HomePageRequiredText.Visibility = Visibility.Collapsed;

                }
                return;
            }
            Preferences.Instance.Save();
            //reload frame to update theme
            Frame.Navigate(GetType());
        }
    }
}
