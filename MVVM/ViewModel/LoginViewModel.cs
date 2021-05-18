using codibook.MVVM.ViewModel.Commands.loginCommands;
using codibook.MVVM.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codibook.MVVM.ViewModel
{
    public class LoginViewModel
    {
        public loginCommand loginCommandProperty { get; set; }
        public registerCommand registerCommandProperty { get; set; }


        public LoginViewModel()
        {
            loginCommandProperty = new loginCommand();
            registerCommandProperty = new registerCommand();
        }

    }
}
