using codibook.MVVM.ViewModel.Commands.closeCommands;
using codibook.MVVM.ViewModel.Commands.titlebarCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codibook.MVVM.ViewModel.PopUpViewModel
{
    public class ItemPopupViewModel
    {
        public ItemPopupCloseCommand ItemPopupCloseCommandProperty { get; set; }
        public ItemPopupTitleBarCommand ItemPopupTitleBarCommandProperty { get; set; }
        public ItemPopupViewModel()
        {
            ItemPopupCloseCommandProperty = new ItemPopupCloseCommand();
            ItemPopupTitleBarCommandProperty = new ItemPopupTitleBarCommand();
        }
    }
}
