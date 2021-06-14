using codibook.MVVM.ViewModel.Commands.closeCommands;
using codibook.MVVM.ViewModel.PopUpViewModel.PopUpCommands.settingCommands;
using codibook.MVVM.ViewModel.Commands.mainCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace codibook.MVVM.ViewModel.PopUpViewModel
{
    public class SettingPopUpViewModel
    {
        private string cityName;
        public string CityName
        {
            get
            {
                return cityName;
            }
            set
            {
                cityName = value;
            }
        }

        public SettingPopUpCloseCommand closeCommand { get; set; }
        public SettingButtonCommand settingButtonCommand { get; set; }
        public SaveButtonCommand saveButtonCommand { get; set; }
        public SettingCommand settingCommand { get; set; }
        public WeatherAPI WeatherAPI { get; set; }
        
        public SettingPopUpViewModel()
        {
            WeatherAPI = new WeatherAPI();
            closeCommand = new SettingPopUpCloseCommand();
            settingButtonCommand = new SettingButtonCommand(WeatherAPI);
            saveButtonCommand = new SaveButtonCommand(WeatherAPI);
            settingCommand = new SettingCommand();
            cityName = settingCommand.ConfigCityName;
        }
        
    }
}
