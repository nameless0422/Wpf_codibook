using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codibook.MVVM.Model
{
    public class LookBookModel : INotifyPropertyChanged
    {
        private int idx;
        public int IDX
        {
            get { return idx; }
            set
            {
                idx = value;
                OnPropertyChanged("IDX");
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            { 
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public ObservableCollection<ItemModel> ItemList;
        public LookBookModel(string name, ObservableCollection<ItemModel> itemlist)
        {
            Name = name;
            ItemList = new ObservableCollection<ItemModel>();
            for(int i = 0; i < itemlist.Count(); i++)
            {
                ItemList.Add(itemlist[i]);
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

    }
}
