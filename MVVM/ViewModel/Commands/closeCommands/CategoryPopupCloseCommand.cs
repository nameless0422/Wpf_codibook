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
    public class CategoryPopupCloseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ItemPopupCategoryPopup categoryPopup = parameter as ItemPopupCategoryPopup;
            CategoryViewModel categoryVM = categoryPopup.Resources["CategoryVM"] as CategoryViewModel;
            ItemPopupViewModel itemPopupVM = categoryPopup.Resources["ItemPopupVM"] as ItemPopupViewModel;
            itemPopupVM.IsCategoryPopup = false;
            categoryPopup.Close();
        }
    }
}
