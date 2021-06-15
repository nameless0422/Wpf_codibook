using codibook.Classes;
using codibook.MVVM.Model;
using codibook.MVVM.View.PopUp;
using codibook.MVVM.ViewModel.PopUpViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace codibook.MVVM.ViewModel.Commands.closeCommands
{
    public class SearchItemPopupCloseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SearchItemPopup popup = parameter as SearchItemPopup;
            ItemViewModel vm = popup.Resources["ItemVM"] as ItemViewModel;
            ItemPopupViewModel popVM = popup.Resources["PopUpVM"] as ItemPopupViewModel;
            ItemModel model = new ItemModel(popVM.Item_ID, popVM.Name, popVM.Shop_Name, popVM.Price, popVM.Temp, popVM.Link, popVM.Memo, popVM.Liked ? 1 : 2);
            model.Category = popVM.Category;
            DBConnecter.updateItem(model);
            vm.setItemlist(popVM.Name,0);
            vm.searchItemPage.itemListView.ItemsSource = vm.items;
            vm.IsItemPopup = false;
            popup.Close();
        }
    }
}
