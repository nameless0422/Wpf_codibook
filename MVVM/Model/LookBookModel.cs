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

        public int X;
        private int x
        {
            get { return X; }
            set
            {
                X = value;
                OnPropertyChanged("x");
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

        private int totalprice; 
        public string TotalPrice 
        { 
            get { return "Total Price : " + totalprice.ToString(); }
            set
            {
                totalprice = int.Parse(value);
                OnPropertyChanged("TotalPrice");
            } 
        }

        public ObservableCollection<ItemModel> ItemList { get; set; }
        public ObservableCollection<ItemModel> Top_Three_Item { get; set; }

        public LookBookModel(int id,string name)
        {
            IDX = id;
            Name = name;
            ItemList = new ObservableCollection<ItemModel>();
            Top_Three_Item = new ObservableCollection<ItemModel>();
            TotalPrice = "0";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void setTotalPrice()
        {
            for(int i=0; i< ItemList.Count(); i++)
            {
                totalprice += ItemList[i].Price;
            }
        }
    }
}
