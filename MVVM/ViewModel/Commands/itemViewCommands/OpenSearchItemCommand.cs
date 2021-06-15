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

namespace codibook.MVVM.ViewModel.Commands.itemViewCommands
{
    public class OpenSearchItemCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (parameter == null) return true;
            ItemID_SearchPage_Class itemID_SearchPage_Class = parameter as ItemID_SearchPage_Class;
            ItemViewModel vm = itemID_SearchPage_Class._SearchItemPage.Resources["ItemVM"] as ItemViewModel;
            return vm == null ? true : !(vm.IsItemPopup);
        }

        public void Execute(object parameter)
        {
            ItemID_SearchPage_Class itemID_SearchPage_Class = parameter as ItemID_SearchPage_Class;
            ItemViewModel vm = itemID_SearchPage_Class._SearchItemPage.Resources["ItemVM"] as ItemViewModel;
            SearchItemPopup popup = new SearchItemPopup();
            popup.Resources["ItemVM"] = vm;
            vm.IsItemPopup = true;
            ItemPopupViewModel popUpVM = popup.Resources["PopUpVM"] as ItemPopupViewModel;
            ItemModel model = DBConnecter.getItem(itemID_SearchPage_Class.ItemID);
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
