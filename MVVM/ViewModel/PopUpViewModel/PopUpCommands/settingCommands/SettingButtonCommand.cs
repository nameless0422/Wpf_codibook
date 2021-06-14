using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace codibook.MVVM.ViewModel.PopUpViewModel.PopUpCommands.settingCommands
{
    public class SettingButtonCommand : ICommand
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

        public event EventHandler CanExecuteChanged;

        public SettingButtonCommand(WeatherAPI weatherAPI)
        {
            WeatherAPI = weatherAPI;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            cityName = parameter.ToString();
            WeatherAPI.Changecityname(cityName);
        }
    }
}
