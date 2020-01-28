using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Weather.Classes
{
    public sealed class Preferences
    {
        private static Preferences _instance = null;

        public  static Preferences Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Preferences();
                }
                return _instance;
            }
        }
        
        private string _theme = "Dark";

        public string Theme
        {
            get
            {
                return _theme;
            }
            set
            {
                _theme = value;
            }
        }

        private string _homePage = "Forecast";

        public string HomePage
        {
            get
            {
                return _homePage;
            }
            set
            {
                _homePage = value;
            }
        }

        private string _homeCity = "Perth";

        public string HomeCity
        {
            get
            {
                return _homeCity;
            }
            set
            {
                _homeCity = value;
            }
        }

        public Windows.UI.Xaml.ElementTheme ElementTheme
        {
            get
            {
                if (Theme == "Light")
                {
                    return Windows.UI.Xaml.ElementTheme.Light;
                }
                else if (Theme == "Dark")
                {
                    return Windows.UI.Xaml.ElementTheme.Dark;
                }
                else
                {
                    return Windows.UI.Xaml.ElementTheme.Default;
                }
            }           
        }


        public async Task Load()
        {
            //get path to localfolder
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            //create file to save /open if exists
            StorageFile saveFile = await storageFolder.CreateFileAsync("preferences.txt", CreationCollisionOption.OpenIfExists);
            // Read serialized tasks list:
            string serializedTasksList = await FileIO.ReadTextAsync(saveFile);
            // Deserialize JSON list if exists
            if (serializedTasksList != null && serializedTasksList != "")
            {
                PreferenceData loadPref = new PreferenceData();
                loadPref = JsonConvert.DeserializeObject<PreferenceData>(serializedTasksList);
            }
        }

        public async void Save()
        {
            //get path to localfolder
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            //create file to save /open if exists
            StorageFile saveFile = await storageFolder.CreateFileAsync("preferences.txt", CreationCollisionOption.OpenIfExists);
            // serialize the task list
            string serializedTasksList = JsonConvert.SerializeObject(Instance);
            //write tasks to file
            await FileIO.WriteTextAsync(saveFile, serializedTasksList);
        }
    }
}
