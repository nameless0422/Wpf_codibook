using codibook.MVVM.View.PopUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace codibook.MVVM.ViewModel.PopUpViewModel.PopUpCommands
{
    public class ItemPopupCategoryCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            ItemPopup itemPopup = parameter as ItemPopup;
            if (itemPopup == null) return true;
            ItemPopupViewModel itemPopupVM = itemPopup.Resources["PopUpVM"] as ItemPopupViewModel;
            return itemPopupVM == null ? true : !(itemPopupVM.IsCategoryPopup);
        }

        public void Execute(object parameter)
        {
            ItemPopup itemPopup = parameter as ItemPopup;
            ItemPopupViewModel itemPopupVM = itemPopup.Resources["PopUpVM"] as ItemPopupViewModel;
            ItemPopupCategoryPopup categoryPopup = new ItemPopupCategoryPopup();
            categoryPopup.Resources["ItemPopupVM"] = itemPopupVM;
            CategoryViewModel categoryVM = categoryPopup.Resources["CategoryVM"] as CategoryViewModel;
            categoryVM.category = itemPopupVM.Category;
            itemPopupVM.IsCategoryPopup = true;
            categoryPopup.Show();
        }
    }
}
