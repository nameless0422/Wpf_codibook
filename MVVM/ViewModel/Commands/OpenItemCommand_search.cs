using codibook.Classes;
using codibook.MVVM.Model;
using codibook.MVVM.View.PopUp;
using codibook.MVVM.View.SearchViewListPages;
using codibook.MVVM.ViewModel.PopUpViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace codibook.MVVM.ViewModel.Commands
{
    public class OpenItemCommand_search : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            SearchItemPage searchItemPage = parameter as SearchItemPage;
            if (searchItemPage == null) return true;
            ItemViewModel vm = searchItemPage.Resources["ItemVM"] as ItemViewModel;
            return vm == null ? true : !(vm.IsItemPopup);
        }

        public void Execute(object parameter)
        {
            SearchItemPage searchItemPage = parameter as SearchItemPage;
            ItemViewModel vm = searchItemPage.Resources["ItemVM"] as ItemViewModel;
            ItemPopup popup = new ItemPopup();
            popup.Resources["ItemVM"] = vm;
            vm.IsItemPopup = true;
            ItemPopupViewModel popUpVM = popup.Resources["PopUpVM"] as ItemPopupViewModel;
            //TODO 내일 한다. 응애
            ItemModel model = DBConnecter.getItem(1);
            popUpVM.Shop_Name = model.Shop_Name;
            popUpVM.Memo = model.Memo;
            popUpVM.Name = model.Name;
            popUpVM.Link = model.Link;
            popUpVM.Item_ID = model.Item_ID;
            popUpVM.Price = model.Price;
            if (model.Liked == 1)
            {
                popUpVM.Liked = true;
            }
            else
            {
                popUpVM.Liked = false;
            }
            popUpVM.Temp = model.Temp;
            popUpVM.Image = model.Image;
            popUpVM.Category = model.Category;
            popup.Show();
        }
    }
}
