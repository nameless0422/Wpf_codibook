using codibook.MVVM.View.PopUp;
using codibook.MVVM.ViewModel.PopUpViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace codibook.MVVM.ViewModel.PopUpViewModel.PopUpCommands
{
    public class EditMessageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            UserPopUp userPopUp = parameter as UserPopUp;
            UserPopUpViewModel vm = userPopUp.Resources["PopUpVM"] as UserPopUpViewModel;
            //true
            if (vm.IsReadOnly)
            {
                vm.IsReadOnly = false;
            }
            else
            //false
            {
                vm.IsReadOnly = true;
            }
        }
    }
}
