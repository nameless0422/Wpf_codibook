using codibook.MVVM.View.PopUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace codibook.MVVM.ViewModel.PopUpViewModel.PopUpCommands.settingCommands
{
    public class SaveButtonCommand : ICommand
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
        public WeatherAPI WeatherAPI { get; set; }

        public SaveButtonCommand(WeatherAPI weatherAPI)
        {
            WeatherAPI = weatherAPI;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            cityName = parameter.ToString();
            WeatherAPI.Changecityname(cityName);
            SettingPopUp settingPopUp = parameter as SettingPopUp;
            settingPopUp.viewModel.SettingCheck = false;
            settingPopUp.Close();
        }
    }
}
