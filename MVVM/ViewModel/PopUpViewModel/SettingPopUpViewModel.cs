﻿using codibook.MVVM.ViewModel.Commands.closeCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codibook.MVVM.ViewModel.PopUpViewModel
{
    public class SettingPopUpViewModel
    {
        public SettingPopUpCloseCommand closeCommand { get; set; }
        public SettingPopUpViewModel()
        {
            closeCommand = new SettingPopUpCloseCommand();
        }
    }
}