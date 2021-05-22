using codibook.MVVM.ViewModel.Commands.loginCommands;
using codibook.MVVM.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using codibook.MVVM.ViewModel.Commands.closeCommands;
using codibook.MVVM.ViewModel.Commands.titlebarCommands;

namespace codibook.MVVM.ViewModel
{
    public class LoginViewModel
    {
        public loginCommand loginCommandProperty { get; set; }
        public registerCommand registerCommandProperty { get; set; }
        public LoginCloseCommand loginCloseCommandProperty { get; set; }
        public ToMiniCommand toMiniCommandProperty { get; set; }
        public LoginTitleBarCommand loginTitleBarCommandProperty { get; set; }

        public LoginViewModel()
        {
            loginCommandProperty = new loginCommand();
            registerCommandProperty = new registerCommand();
            loginCloseCommandProperty = new LoginCloseCommand();
            toMiniCommandProperty = new ToMiniCommand();
            loginTitleBarCommandProperty = new LoginTitleBarCommand();
        }

    }
}
