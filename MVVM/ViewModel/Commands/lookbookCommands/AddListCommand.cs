using codibook.MVVM.View.PopUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace codibook.MVVM.ViewModel.Commands.lookbookCommands
{
    public class AddListCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            LookBookViewModel lookBookViewModel = parameter as LookBookViewModel;
            if (lookBookViewModel == null) return true;
            if (lookBookViewModel.AddListCheck == true)
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
            LookBookPopUp lookBookPopUp = new LookBookPopUp(lookBookViewModel);
            lookBookPopUp.Show();
            lookBookViewModel.AddListCheck = true;
        }
    }
}
