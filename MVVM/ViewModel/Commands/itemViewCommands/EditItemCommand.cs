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
    public class EditItemCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.GetType() == typeof(ItemPopup))
            {
                ItemPopup itemPopup = parameter as ItemPopup;
                ItemPopupViewModel vm = itemPopup.Resources["PopUpVM"] as ItemPopupViewModel;
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
            }else if(parameter.GetType() == typeof(SearchItemPopup))
            {
                SearchItemPopup itemPopup = parameter as SearchItemPopup;
                ItemPopupViewModel vm = itemPopup.Resources["PopUpVM"] as ItemPopupViewModel;
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
}
