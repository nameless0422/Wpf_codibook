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
        public SettingPopUpCloseCommand closeCommand { get; set; }
        public SettingButtonCommand settingButtonCommand { get; set; }
        public WeatherAPI WeatherAPI { get; set; }
        
        public SettingPopUpViewModel()
        {
            WeatherAPI = new WeatherAPI();
            closeCommand = new SettingPopUpCloseCommand();
            settingButtonCommand = new SettingButtonCommand(WeatherAPI);
        }
        
    }
}
