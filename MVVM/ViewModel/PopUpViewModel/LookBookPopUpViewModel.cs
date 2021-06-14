using codibook.MVVM.ViewModel.Commands.closeCommands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codibook.MVVM.ViewModel.PopUpViewModel
{
    public class LookBookPopUpViewModel : INotifyPropertyChanged
    {
        public LookBookPopUpCloseCommand closeCommand { get; set; }
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

        public LookBookPopUpViewModel()
        {
            isreadonly = true;
            closeCommand = new LookBookPopUpCloseCommand();
        }
    }
}
