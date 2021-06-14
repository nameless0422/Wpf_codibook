using codibook.MVVM.View;
using codibook.MVVM.View.SearchViewListPages;
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
            SearchViewPage searchPage = new SearchViewPage();
            SearchItemPage searchItemPage = new SearchItemPage();
            searchPage.DataContext = vm;
            searchItemPage.DataContext = vm.itemVM;
            vm.itemVM.setItemlist(vm.Search_Text,0);
            searchItemPage.itemListView.ItemsSource = vm.itemVM.items;
            searchPage.listframe.Navigate(searchItemPage);
            window.Mainframe.Navigate(searchPage);
            
        }
    }
}
