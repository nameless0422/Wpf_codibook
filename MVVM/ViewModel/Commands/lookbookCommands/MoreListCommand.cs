using codibook.MVVM.View.PopUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace codibook.MVVM.ViewModel.Commands.lookbookCommands
{
    public class MoreListCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            LookBookViewModel lookBookViewModel = parameter as LookBookViewModel;
            if (lookBookViewModel == null) return true;
            if (lookBookViewModel.MoreListCheck == true)
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
            LookBookViewModel lookBookViewModel = parameter as LookBookViewModel;
            AddListPopUp addListPopUp = new AddListPopUp(lookBookViewModel);
            addListPopUp.Show();
            lookBookViewModel.MoreListCheck = true;
        }
    }

}
