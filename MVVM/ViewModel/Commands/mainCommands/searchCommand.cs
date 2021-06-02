using codibook.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace codibook.MVVM.ViewModel.Commands.mainCommands
{
    public class searchCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            MainWindow window = parameter as MainWindow;
            return window.Search_Box.Text.Length >= 3;
        }

        public void Execute(object parameter)
        {
            MainWindow window = parameter as MainWindow;
            MainViewModel vm = window.Resources["MainVM"] as MainViewModel;
            vm.Search_Text = window.Search_Box.Text;
            window.Mainframe.Navigate(new SearchViewPage());
            
        }
    }
}
