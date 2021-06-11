using codibook.MVVM.View;
using codibook.MVVM.View.PopUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace codibook.MVVM.ViewModel.Commands.itemViewCommands
{
    public class AddItemButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            ItemViewModel vm = parameter as ItemViewModel;
            return vm == null ? true : !(vm.IsItemPopup);
        }

        public void Execute(object parameter)
        {
            ItemViewModel vm = parameter as ItemViewModel;
            vm.IsItemPopup = true;
        }
    }
}
