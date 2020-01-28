using errorHandling;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace Weather.Classes
{
    public class WeatherAPI
    {
        public bool isTest;
        public string errType ="";

        //hard coded API calls
        private  string currentWeatherTestData = "{\"coord\":{\"lon\":138.6,\"lat\":-34.92},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04d\"}],\"base\":\"stations\",\"main\":{\"temp\":16.7,\"pressure\":1016,\"humidity\":63,\"temp_min\":14.44,\"temp_max\":18.33},\"visibility\":10000,\"wind\":{\"speed\":7.7,\"deg\":230},\"clouds\":{\"all\":75},\"dt\":1575334803,\"sys\":{\"type\":1,\"id\":9566,\"country\":\"AU\",\"sunrise\":1575314712,\"sunset\":1575366324},\"timezone\":37800,\"id\":7839644,\"name\":\"Adelaide\",\"cod\":200}";
        private readonly string forecastWeatherData = "{\"cod\":\"200\",\"message\":0,\"cnt\":40,\"list\":[{\"dt\":1575352800,\"main\":{\"temp\":8.92,\"temp_min\":8.42,\"temp_max\":8.92,\"pressure\":988,\"sea_level\":988,\"grnd_level\":987,\"humidity\":82,\"temp_kf\":0.5},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":63},\"wind\":{\"speed\":11.99,\"deg\":256},\"rain\":{\"3h\":1.69},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-03 06:00:00\"},{\"dt\":1575363600,\"main\":{\"temp\":8.68,\"temp_min\":8.31,\"temp_max\":8.68,\"pressure\":992,\"sea_level\":992,\"grnd_level\":991,\"humidity\":72,\"temp_kf\":0.37},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":67},\"wind\":{\"speed\":13.43,\"deg\":255},\"rain\":{\"3h\":1.13},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-03 09:00:00\"},{\"dt\":1575374400,\"main\":{\"temp\":7.82,\"temp_min\":7.57,\"temp_max\":7.82,\"pressure\":996,\"sea_level\":996,\"grnd_level\":994,\"humidity\":70,\"temp_kf\":0.25},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10n\"}],\"clouds\":{\"all\":47},\"wind\":{\"speed\":11.94,\"deg\":253},\"rain\":{\"3h\":0.38},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2019-12-03 12:00:00\"},{\"dt\":1575385200,\"main\":{\"temp\":6.87,\"temp_min\":6.75,\"temp_max\":6.87,\"pressure\":997,\"sea_level\":997,\"grnd_level\":996,\"humidity\":75,\"temp_kf\":0.12},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"clouds\":{\"all\":9},\"wind\":{\"speed\":9.15,\"deg\":273},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2019-12-03 15:00:00\"},{\"dt\":1575396000,\"main\":{\"temp\":7.48,\"temp_min\":7.48,\"temp_max\":7.48,\"pressure\":997,\"sea_level\":997,\"grnd_level\":995,\"humidity\":73,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10n\"}],\"clouds\":{\"all\":24},\"wind\":{\"speed\":9.38,\"deg\":268},\"rain\":{\"3h\":0.13},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2019-12-03 18:00:00\"},{\"dt\":1575406800,\"main\":{\"temp\":8.43,\"temp_min\":8.43,\"temp_max\":8.43,\"pressure\":998,\"sea_level\":998,\"grnd_level\":996,\"humidity\":68,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":37},\"wind\":{\"speed\":9.88,\"deg\":265},\"rain\":{\"3h\":0.13},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-03 21:00:00\"},{\"dt\":1575417600,\"main\":{\"temp\":10.58,\"temp_min\":10.58,\"temp_max\":10.58,\"pressure\":997,\"sea_level\":997,\"grnd_level\":995,\"humidity\":56,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":67},\"wind\":{\"speed\":9.43,\"deg\":265},\"rain\":{\"3h\":0.13},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-04 00:00:00\"},{\"dt\":1575428400,\"main\":{\"temp\":10.98,\"temp_min\":10.98,\"temp_max\":10.98,\"pressure\":996,\"sea_level\":996,\"grnd_level\":995,\"humidity\":62,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":96},\"wind\":{\"speed\":10.86,\"deg\":273},\"rain\":{\"3h\":0.06},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-04 03:00:00\"},{\"dt\":1575439200,\"main\":{\"temp\":11.87,\"temp_min\":11.87,\"temp_max\":11.87,\"pressure\":997,\"sea_level\":997,\"grnd_level\":995,\"humidity\":58,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":81},\"wind\":{\"speed\":9.75,\"deg\":265},\"rain\":{\"3h\":0.06},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-04 06:00:00\"},{\"dt\":1575450000,\"main\":{\"temp\":10.55,\"temp_min\":10.55,\"temp_max\":10.55,\"pressure\":998,\"sea_level\":998,\"grnd_level\":997,\"humidity\":64,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":86},\"wind\":{\"speed\":8.46,\"deg\":260},\"rain\":{\"3h\":0.06},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-04 09:00:00\"},{\"dt\":1575460800,\"main\":{\"temp\":9.95,\"temp_min\":9.95,\"temp_max\":9.95,\"pressure\":999,\"sea_level\":999,\"grnd_level\":997,\"humidity\":68,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10n\"}],\"clouds\":{\"all\":83},\"wind\":{\"speed\":6.99,\"deg\":279},\"rain\":{\"3h\":0.06},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2019-12-04 12:00:00\"},{\"dt\":1575471600,\"main\":{\"temp\":10.47,\"temp_min\":10.47,\"temp_max\":10.47,\"pressure\":998,\"sea_level\":998,\"grnd_level\":996,\"humidity\":68,\"temp_kf\":0},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04n\"}],\"clouds\":{\"all\":100},\"wind\":{\"speed\":8.29,\"deg\":277},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2019-12-04 15:00:00\"},{\"dt\":1575482400,\"main\":{\"temp\":11.23,\"temp_min\":11.23,\"temp_max\":11.23,\"pressure\":996,\"sea_level\":996,\"grnd_level\":994,\"humidity\":70,\"temp_kf\":0},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04n\"}],\"clouds\":{\"all\":97},\"wind\":{\"speed\":7.16,\"deg\":311},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2019-12-04 18:00:00\"},{\"dt\":1575493200,\"main\":{\"temp\":12.27,\"temp_min\":12.27,\"temp_max\":12.27,\"pressure\":994,\"sea_level\":994,\"grnd_level\":993,\"humidity\":71,\"temp_kf\":0},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}],\"clouds\":{\"all\":95},\"wind\":{\"speed\":8.21,\"deg\":302},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-04 21:00:00\"},{\"dt\":1575504000,\"main\":{\"temp\":13.02,\"temp_min\":13.02,\"temp_max\":13.02,\"pressure\":994,\"sea_level\":994,\"grnd_level\":992,\"humidity\":74,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":91},\"wind\":{\"speed\":8.78,\"deg\":285},\"rain\":{\"3h\":0.25},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-05 00:00:00\"},{\"dt\":1575514800,\"main\":{\"temp\":14.16,\"temp_min\":14.16,\"temp_max\":14.16,\"pressure\":993,\"sea_level\":993,\"grnd_level\":991,\"humidity\":66,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":97},\"wind\":{\"speed\":8.66,\"deg\":281},\"rain\":{\"3h\":0.31},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-05 03:00:00\"},{\"dt\":1575525600,\"main\":{\"temp\":11.86,\"temp_min\":11.86,\"temp_max\":11.86,\"pressure\":994,\"sea_level\":994,\"grnd_level\":993,\"humidity\":75,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":84},\"wind\":{\"speed\":8.48,\"deg\":247},\"rain\":{\"3h\":0.44},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-05 06:00:00\"},{\"dt\":1575536400,\"main\":{\"temp\":11.21,\"temp_min\":11.21,\"temp_max\":11.21,\"pressure\":996,\"sea_level\":996,\"grnd_level\":995,\"humidity\":71,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":76},\"wind\":{\"speed\":8.88,\"deg\":251},\"rain\":{\"3h\":0.19},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-05 09:00:00\"},{\"dt\":1575547200,\"main\":{\"temp\":10.91,\"temp_min\":10.91,\"temp_max\":10.91,\"pressure\":998,\"sea_level\":998,\"grnd_level\":996,\"humidity\":71,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10n\"}],\"clouds\":{\"all\":79},\"wind\":{\"speed\":6.26,\"deg\":275},\"rain\":{\"3h\":0.25},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2019-12-05 12:00:00\"},{\"dt\":1575558000,\"main\":{\"temp\":9.89,\"temp_min\":9.89,\"temp_max\":9.89,\"pressure\":997,\"sea_level\":997,\"grnd_level\":996,\"humidity\":72,\"temp_kf\":0},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04n\"}],\"clouds\":{\"all\":74},\"wind\":{\"speed\":7.31,\"deg\":278},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2019-12-05 15:00:00\"},{\"dt\":1575568800,\"main\":{\"temp\":10.13,\"temp_min\":10.13,\"temp_max\":10.13,\"pressure\":996,\"sea_level\":996,\"grnd_level\":995,\"humidity\":73,\"temp_kf\":0},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04n\"}],\"clouds\":{\"all\":68},\"wind\":{\"speed\":8.93,\"deg\":290},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2019-12-05 18:00:00\"},{\"dt\":1575579600,\"main\":{\"temp\":11.03,\"temp_min\":11.03,\"temp_max\":11.03,\"pressure\":997,\"sea_level\":997,\"grnd_level\":995,\"humidity\":71,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":79},\"wind\":{\"speed\":10.42,\"deg\":269},\"rain\":{\"3h\":0.19},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-05 21:00:00\"},{\"dt\":1575590400,\"main\":{\"temp\":11.2,\"temp_min\":11.2,\"temp_max\":11.2,\"pressure\":997,\"sea_level\":997,\"grnd_level\":996,\"humidity\":67,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":69},\"wind\":{\"speed\":10.97,\"deg\":265},\"rain\":{\"3h\":0.5},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-06 00:00:00\"},{\"dt\":1575601200,\"main\":{\"temp\":11.07,\"temp_min\":11.07,\"temp_max\":11.07,\"pressure\":998,\"sea_level\":998,\"grnd_level\":996,\"humidity\":69,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":84},\"wind\":{\"speed\":11.42,\"deg\":266},\"rain\":{\"3h\":0.38},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-06 03:00:00\"},{\"dt\":1575612000,\"main\":{\"temp\":10.36,\"temp_min\":10.36,\"temp_max\":10.36,\"pressure\":999,\"sea_level\":999,\"grnd_level\":998,\"humidity\":75,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":89},\"wind\":{\"speed\":10.7,\"deg\":264},\"rain\":{\"3h\":0.5},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-06 06:00:00\"},{\"dt\":1575622800,\"main\":{\"temp\":10.15,\"temp_min\":10.15,\"temp_max\":10.15,\"pressure\":1001,\"sea_level\":1001,\"grnd_level\":1000,\"humidity\":76,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":87},\"wind\":{\"speed\":11.64,\"deg\":258},\"rain\":{\"3h\":0.69},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-06 09:00:00\"},{\"dt\":1575633600,\"main\":{\"temp\":9.9,\"temp_min\":9.9,\"temp_max\":9.9,\"pressure\":1004,\"sea_level\":1004,\"grnd_level\":1003,\"humidity\":75,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10n\"}],\"clouds\":{\"all\":94},\"wind\":{\"speed\":10.13,\"deg\":255},\"rain\":{\"3h\":0.69},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2019-12-06 12:00:00\"},{\"dt\":1575644400,\"main\":{\"temp\":9.8,\"temp_min\":9.8,\"temp_max\":9.8,\"pressure\":1005,\"sea_level\":1005,\"grnd_level\":1003,\"humidity\":71,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03n\"}],\"clouds\":{\"all\":33},\"wind\":{\"speed\":9.98,\"deg\":256},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2019-12-06 15:00:00\"},{\"dt\":1575655200,\"main\":{\"temp\":10.21,\"temp_min\":10.21,\"temp_max\":10.21,\"pressure\":1006,\"sea_level\":1006,\"grnd_level\":1003,\"humidity\":69,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03n\"}],\"clouds\":{\"all\":36},\"wind\":{\"speed\":9.37,\"deg\":263},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2019-12-06 18:00:00\"},{\"dt\":1575666000,\"main\":{\"temp\":11.23,\"temp_min\":11.23,\"temp_max\":11.23,\"pressure\":1007,\"sea_level\":1007,\"grnd_level\":1005,\"humidity\":66,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03d\"}],\"clouds\":{\"all\":44},\"wind\":{\"speed\":9.08,\"deg\":258},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-06 21:00:00\"},{\"dt\":1575676800,\"main\":{\"temp\":12.29,\"temp_min\":12.29,\"temp_max\":12.29,\"pressure\":1007,\"sea_level\":1007,\"grnd_level\":1006,\"humidity\":74,\"temp_kf\":0},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04d\"}],\"clouds\":{\"all\":60},\"wind\":{\"speed\":7.89,\"deg\":241},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-07 00:00:00\"},{\"dt\":1575687600,\"main\":{\"temp\":13.64,\"temp_min\":13.64,\"temp_max\":13.64,\"pressure\":1008,\"sea_level\":1008,\"grnd_level\":1006,\"humidity\":67,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":78},\"wind\":{\"speed\":8.31,\"deg\":244},\"rain\":{\"3h\":0.06},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-07 03:00:00\"},{\"dt\":1575698400,\"main\":{\"temp\":14.02,\"temp_min\":14.02,\"temp_max\":14.02,\"pressure\":1010,\"sea_level\":1010,\"grnd_level\":1008,\"humidity\":63,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":50},\"wind\":{\"speed\":8.37,\"deg\":231},\"rain\":{\"3h\":0.06},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-07 06:00:00\"},{\"dt\":1575709200,\"main\":{\"temp\":12.88,\"temp_min\":12.88,\"temp_max\":12.88,\"pressure\":1013,\"sea_level\":1013,\"grnd_level\":1011,\"humidity\":67,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":7.06,\"deg\":239},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-07 09:00:00\"},{\"dt\":1575720000,\"main\":{\"temp\":11.6,\"temp_min\":11.6,\"temp_max\":11.6,\"pressure\":1015,\"sea_level\":1015,\"grnd_level\":1013,\"humidity\":71,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"clouds\":{\"all\":1},\"wind\":{\"speed\":6.95,\"deg\":230},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2019-12-07 12:00:00\"},{\"dt\":1575730800,\"main\":{\"temp\":11.14,\"temp_min\":11.14,\"temp_max\":11.14,\"pressure\":1016,\"sea_level\":1016,\"grnd_level\":1014,\"humidity\":72,\"temp_kf\":0},\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02n\"}],\"clouds\":{\"all\":15},\"wind\":{\"speed\":6.67,\"deg\":228},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2019-12-07 15:00:00\"},{\"dt\":1575741600,\"main\":{\"temp\":10.74,\"temp_min\":10.74,\"temp_max\":10.74,\"pressure\":1017,\"sea_level\":1017,\"grnd_level\":1015,\"humidity\":72,\"temp_kf\":0},\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02n\"}],\"clouds\":{\"all\":11},\"wind\":{\"speed\":4.24,\"deg\":233},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2019-12-07 18:00:00\"},{\"dt\":1575752400,\"main\":{\"temp\":10.19,\"temp_min\":10.19,\"temp_max\":10.19,\"pressure\":1019,\"sea_level\":1019,\"grnd_level\":1017,\"humidity\":76,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03d\"}],\"clouds\":{\"all\":33},\"wind\":{\"speed\":1.69,\"deg\":262},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-07 21:00:00\"},{\"dt\":1575763200,\"main\":{\"temp\":11.27,\"temp_min\":11.27,\"temp_max\":11.27,\"pressure\":1020,\"sea_level\":1020,\"grnd_level\":1019,\"humidity\":79,\"temp_kf\":0},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04d\"}],\"clouds\":{\"all\":55},\"wind\":{\"speed\":4.59,\"deg\":164},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-08 00:00:00\"},{\"dt\":1575774000,\"main\":{\"temp\":12.08,\"temp_min\":12.08,\"temp_max\":12.08,\"pressure\":1020,\"sea_level\":1020,\"grnd_level\":1019,\"humidity\":81,\"temp_kf\":0},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}],\"clouds\":{\"all\":100},\"wind\":{\"speed\":6.69,\"deg\":164},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2019-12-08 03:00:00\"}],\"city\":{\"id\":2163355,\"name\":\"Hobart\",\"coord\":{\"lat\":-42.8794,\"lon\":147.3294},\"country\":\"AU\",\"timezone\":39600,\"sunrise\":1575311217,\"sunset\":1575365628}}";

        public async Task<CurrentWeather> GetCurrentWeather(string cityID)
        {
            string responseString = "";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(string.Format("http://api.openweathermap.org/data/2.5/weather?id={0}&units=metric&appid=1f9a24c86c0b6155d4126ccb7ee6e61a", cityID)).ConfigureAwait(false);
                    if (isTest)
                    {
                        responseString = currentWeatherTestData;
                    }
                    else
                    {
                        responseString = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (HttpRequestException)
            {
                ConnectionProfile connections = NetworkInformation.GetInternetConnectionProfile();
                bool isInternetConnected = connections != null && connections.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess;
                if (isInternetConnected)
                {
                    errType = "WebsiteError";
                    Logger.Instance.LogWebsiteError();
                    return null;
                }
                else
                {
                    errType = "Internet";
                    Logger.Instance.LogInternetError();
                    return null;
                }
            }

            return Newtonsoft.Json.JsonConvert.DeserializeObject<CurrentWeather>(responseString);
        }

        public async Task<IList<IList<WeatherRawData>>> GetforecastWeather(string cityID)
        {
            string responseString = "";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(string.Format("http://api.openweathermap.org/data/2.5/forecast?id={0}&appid=1f9a24c86c0b6155d4126ccb7ee6e61a&units=metric", cityID)).ConfigureAwait(false);
                    if (isTest)
                    {
                        responseString = forecastWeatherData;
                    }
                    else
                    {
                        responseString = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (HttpRequestException)
            {
                ConnectionProfile connections = NetworkInformation.GetInternetConnectionProfile();
                bool isInternetConnected = connections != null && connections.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess;
                if (isInternetConnected)
                {
                    errType = "WebsiteError";
                    Logger.Instance.LogWebsiteError();
                    return null;
                }
                else
                {
                    errType = "Internet";
                    Logger.Instance.LogInternetError();
                    return null;
                }
            }

            JObject weather = JObject.Parse(responseString);
            try
            {
                IList<JToken> weatherResult = weather["list"].ToList();


                IList<WeatherRawData> DayOneRawData = new List<WeatherRawData>();
                IList<WeatherRawData> DayTwoRawData = new List<WeatherRawData>();
                IList<WeatherRawData> DayThreeRawData = new List<WeatherRawData>();
                IList<WeatherRawData> DayFourRawData = new List<WeatherRawData>();
                IList<WeatherRawData> DayFiveRawData = new List<WeatherRawData>();

                int i = 0;
                foreach (JToken result in weatherResult)
                {
                    WeatherRawData searchResult = result.ToObject<WeatherRawData>();
                    if (i < 7)
                    {
                        DayOneRawData.Add(searchResult);
                    }
                    else if (i < 15)
                    {
                        DayTwoRawData.Add(searchResult);
                    }
                    else if (i < 23)
                    {
                        DayThreeRawData.Add(searchResult);
                    }
                    else if (i < 31)
                    {
                        DayFourRawData.Add(searchResult);
                    }
                    else if (i <= 39)
                    {
                        DayFiveRawData.Add(searchResult);
                    }
                    i++;
                }

                List<IList<WeatherRawData>> compList = new List<IList<WeatherRawData>>
                {
                    DayOneRawData,
                    DayTwoRawData,
                    DayThreeRawData,
                    DayFourRawData,
                    DayFiveRawData
                };

                return compList;
            }
            catch (ArgumentNullException)
            {
                errType = "APIParameterChange";
                return null;
            }
        }
    }
}


