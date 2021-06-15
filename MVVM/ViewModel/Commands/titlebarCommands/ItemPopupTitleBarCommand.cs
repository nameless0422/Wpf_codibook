using codibook.MVVM.View.PopUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace codibook.MVVM.ViewModel.Commands.titlebarCommands
{
    public class ItemPopupTitleBarCommand : ICommand
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
                itemPopup.DragMove();
            } else if (parameter.GetType() == typeof(SearchItemPopup))
            {
                SearchItemPopup searchItemPopup = parameter as SearchItemPopup;
                searchItemPopup.DragMove();
            }else if (parameter.GetType() == typeof(AddItemPopup))
            {
                AddItemPopup addItemPopup = parameter as AddItemPopup;
                addItemPopup.DragMove();
            }
        }
    }
}
