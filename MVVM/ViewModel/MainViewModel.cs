using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace codibook.MVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string search_text;

        public string Search_Text
        {
            get { return search_text; }
            set
            {
                search_text = value;
                OnPropertyChanged("Search_Text");
            }
        }
        public MainViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}
