using Windows.ApplicationModel.Core;
using Windows.Storage;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System;

namespace errorHandling
{
    public sealed class Logger
    {
        private Logger() { }
        private static Logger instance = null;

        private int LogAPIChange = 0;
        private int LogInternetErr = 0;
        private int LogSuccess = 0;
        private int LogWebsiteErr = 0;
        


        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }

        public async Task<StorageFile> FileExists()
        {
            var folder = ApplicationData.Current.LocalFolder;
            try
            {
                var checkFile = await ApplicationData.Current.LocalFolder.GetFileAsync("log.txt");
                return checkFile;
            }
            catch (FileNotFoundException)
            {
                var file = await folder.CreateFileAsync("log.txt", CreationCollisionOption.FailIfExists);
                return file;
            }
        }
        
        public Task WriteToTxt(string err)
        {
            return Task.Run(async () =>
            {
                var file = await FileExists();

                await FileIO.AppendTextAsync(file, err + "\n");
            });
        }

        public void LogAPINameChange()
        {
            LogAPIChange++;
            string err = "**** API error: API may have changed ";
            Debug.WriteLine(err + "{0}", LogAPIChange);
            WriteToTxt(err + "(" + LogAPIChange.ToString() + ")").Wait();
                LogStatistics();
        }

        public void LogWebsiteError()
        {
            LogWebsiteErr++;
            string err = "**** Website error: Website may have moved ";
            Debug.WriteLine(err + "({0})", LogWebsiteErr);
            WriteToTxt(err + "(" + LogWebsiteErr.ToString() + ")").Wait();
            LogStatistics();
        }

        public void LogInternetError()
        {
            LogInternetErr++;
            string err = "**** Internet Error: Internet is down ";
            Debug.WriteLine(err + "({0})", LogInternetErr);
            WriteToTxt(err + "(" + LogInternetErr.ToString() + ")").Wait();
        }


        public void LogSuccessFullLoad()
        {
            LogSuccess++;
            string err = "**** Information: Successful Load ";
            Debug.WriteLine(err + "({0})", LogSuccess);
            WriteToTxt(err + "(" + LogSuccess.ToString() + ")").Wait();
        }

        public void LogStatistics()
        {

            Debug.WriteLine("**** API Name Change Errors: {0}\n**** Internet Errors: {1}\n**** WebsiteErr: {2}\n**** SuccessFullLoads: {3}", LogAPIChange, LogInternetErr, LogWebsiteErr, LogSuccess);
        }

    }
}

