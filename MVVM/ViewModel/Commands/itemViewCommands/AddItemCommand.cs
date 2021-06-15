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
    public class AddItemCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ItemViewPage itemViewPage = parameter as ItemViewPage;
            ItemViewModel vm = itemViewPage.Resources["ItemVM"] as ItemViewModel;
            AddItemPopup popup = new AddItemPopup();
            popup.Resources["ItemVM"] = vm;
            vm.IsItemPopup = true;
            ItemPopupViewModel popUpVM = popup.Resources["PopUpVM"] as ItemPopupViewModel;
            ItemModel model = new ItemModel();
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
