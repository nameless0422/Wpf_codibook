using codibook.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace codibook.MVVM.ViewModel.Commands.mainCommands
{
    public class ToMaxOrNormalCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MainWindow mainWindow = parameter as MainWindow;
            if (mainWindow.WindowState == System.Windows.WindowState.Maximized)
            {
                mainWindow.WindowState = System.Windows.WindowState.Normal;
            }
            else if (mainWindow.WindowState == System.Windows.WindowState.Normal)
            {
                mainWindow.WindowState = System.Windows.WindowState.Maximized;
            }
        }
    }
}
