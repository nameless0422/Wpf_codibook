using codibook.MVVM.ViewModel.Commands.closeCommands;
using codibook.MVVM.ViewModel.Commands.titlebarCommands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codibook.MVVM.ViewModel.PopUpViewModel
{
    public class CategoryViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> category_;
        public ObservableCollection<string> category
        {
            get { return category_; }
            set
            {
                category_ = value;
                OnPropertyChanged("category");
            }
        }

        public CategoryPopupTitleBarCommand categoryPopupTitleBarCommandProperty { get; set; }

        public CategoryPopupCloseCommand categoryPopupCloseCommandProperty { get; set; }

        public CategoryViewModel()
        {
            category = new ObservableCollection<string>();
            categoryPopupTitleBarCommandProperty = new CategoryPopupTitleBarCommand();
            categoryPopupCloseCommandProperty = new CategoryPopupCloseCommand();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
