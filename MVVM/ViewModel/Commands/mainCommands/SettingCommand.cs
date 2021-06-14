using codibook.MVVM.View.PopUp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace codibook.MVVM.ViewModel.Commands.mainCommands
{
    public class SettingCommand : ICommand
    {
        string configCityName;
        public string ConfigCityName
        {
            get
            {
                return configCityName;
            }

            set
            {
                configCityName = value;
            }
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            MainViewModel mainViewModel = parameter as MainViewModel;
            if (mainViewModel == null) return true;
            if(mainViewModel.SettingCheck == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            MainViewModel mainViewModel = parameter as MainViewModel;

            LoadConfiguration();
            if (settingCityValue != string.Empty)
            {
                configCityName = settingCityValue;
            }

            else
            {
                WeatherAPI weatherAPI = new WeatherAPI();
                settingCityValue = weatherAPI.cityname;
                SaveConfiguration();

                configCityName = settingCityValue;
            }

            SettingPopUp settingPopUp = new SettingPopUp(mainViewModel);
            settingPopUp.Show();
            mainViewModel.SettingCheck = true;
        }

        // using configurationManager
        public string settingCityValue = string.Empty;

        public void SaveConfiguration()
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var appSettings = configFile.AppSettings.Settings;

                if (appSettings["PropertyName"] == null)
                {
                    appSettings.Add("PropertyName", settingCityValue);
                }

                else
                {
                    appSettings.Remove("PropertyName");
                    appSettings.Add("PropertyName", settingCityValue);
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }

            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("configuration error exception occur!");
            }
        }

        public void LoadConfiguration()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result;

                result = appSettings["PropertyName"] ?? string.Empty;

                if (result != string.Empty)
                {
                    settingCityValue = result;
                }
            }

            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("configuration error exception occur!");
            }
        }
    }
}
