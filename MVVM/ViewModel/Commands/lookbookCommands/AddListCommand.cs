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
            return true;
        }

        public void Execute(object parameter)
        {
            LookBookViewModel lookBookViewModel = parameter as LookBookViewModel;
            AddListPopUp addListPopUp = new AddListPopUp(lookBookViewModel);
            addListPopUp.Show();
        }
    }
}
