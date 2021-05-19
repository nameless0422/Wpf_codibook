using codibook.MVVM.View.PopUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace codibook.MVVM.ViewModel.Commands.closeCommands
{
    public class SettingPopUpCloseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SettingPopUp settingPopUp = parameter as SettingPopUp;
            settingPopUp.viewModel.SettingCheck = false;
            settingPopUp.Close();
        }
    }
}
