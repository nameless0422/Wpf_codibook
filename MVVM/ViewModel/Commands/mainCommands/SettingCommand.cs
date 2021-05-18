using codibook.MVVM.View.PopUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace codibook.MVVM.ViewModel.Commands.mainCommands
{
    public class SettingCommand : ICommand
    {
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
            SettingPopUp settingPopUp = new SettingPopUp();
            settingPopUp.Show();
            mainViewModel.SettingCheck = true;
        }
    }
}
