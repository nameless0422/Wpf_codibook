using codibook.MVVM.View.PopUp;
using codibook.MVVM.ViewModel.PopUpViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace codibook.MVVM.ViewModel.Commands.itemViewCommands
{
    public class EditItemMemoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ItemPopup itemPopup = parameter as ItemPopup;
            ItemPopupViewModel vm = itemPopup.Resources["PopUpVM"] as ItemPopupViewModel;
            //true
            if (vm.IsReadOnly_Memo)
            {
                vm.IsReadOnly_Memo = false;
            }
            else
            //false
            {
                vm.IsReadOnly_Memo = true;
            }
        }
    }
}
