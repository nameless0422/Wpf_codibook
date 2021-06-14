using codibook.Classes;
using codibook.MVVM.Model;
using codibook.MVVM.View;
using codibook.MVVM.View.PopUp;
using codibook.MVVM.ViewModel.PopUpViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace codibook.MVVM.ViewModel.Commands.itemViewCommands
{
    public class OpenItemCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            ItemID_ItemPage_Class data = parameter as ItemID_ItemPage_Class;
            ItemViewModel vm = data._ItemViewPage.Resources["ItemVM"] as ItemViewModel;
            return vm == null ? true : !(vm.IsItemPopup);
        }

        public void Execute(object parameter)
        {
            ItemID_ItemPage_Class data = parameter as ItemID_ItemPage_Class;
            ItemViewModel vm = data._ItemViewPage.Resources["ItemVM"] as ItemViewModel;
            ItemPopup popup = new ItemPopup();
            popup.Resources["ItemVM"] = vm;
            vm.IsItemPopup = true;
            ItemPopupViewModel popUpVM = popup.Resources["PopUpVM"] as ItemPopupViewModel;
            ItemModel model = DBConnecter.getItem(data.ItemID);
            popUpVM.Shop_Name = model.Shop_Name;
            popUpVM.Name = model.Name;
            popUpVM.Link = model.Link;
            popUpVM.Item_ID = model.Item_ID;
            popUpVM.Price = model.Price;
            if(model.Liked == 1)
            {
                popUpVM.Liked = true;
            }else
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
