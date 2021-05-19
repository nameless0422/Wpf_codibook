using codibook.MVVM.View.PopUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace codibook.MVVM.ViewModel.Commands.mainCommands
{
    public class UserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            MainViewModel mainViewModel = parameter as MainViewModel;
            if (mainViewModel == null) return true;
            if (mainViewModel.UserCheck == true)
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
            UserPopUp userPopUp = new UserPopUp(mainViewModel);
            userPopUp.Show();
            mainViewModel.UserCheck = true;
        }
    }
}
