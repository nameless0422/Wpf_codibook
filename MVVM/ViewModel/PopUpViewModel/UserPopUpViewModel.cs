using codibook.MVVM.Model;
using codibook.MVVM.ViewModel.Commands.closeCommands;
using codibook.MVVM.ViewModel.Commands.mainCommands;
using codibook.MVVM.ViewModel.PopUpViewModel;
using codibook.MVVM.ViewModel.PopUpViewModel.PopUpCommands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codibook.MVVM.ViewModel.PopUpViewModel
{
    public class UserPopUpViewModel : INotifyPropertyChanged
    {
        private string search_user;
        public string Search_User
        {
            get { return search_user; }
            set
            {
                search_user = value;
                OnPropertyChanged("Search_User");
            }
        }

        public UserPopUpCloseCommand closeCommand { get; set; }
        public searchCommand SearchCommandProperty { get; set; }
        public EditMessageCommand editMessageCommand { get; set; }

        public UserPopUpViewModel userVM;
        public UserPopUpViewModel UserVM { get; set; }

        private bool isreadonly;
        public bool IsReadOnly
        {
            get { return isreadonly; }
            set
            {
                isreadonly = value;
                OnPropertyChanged("IsReadOnly");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public UserPopUpViewModel()
        {
            isreadonly = true;
            closeCommand = new UserPopUpCloseCommand();
            SearchCommandProperty = new searchCommand();
            editMessageCommand = new EditMessageCommand();
        }
    }
}
