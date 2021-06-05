using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codibook.MVVM.Model
{
    public class ItemModel : INotifyPropertyChanged
    {
        private int X;
        public int x
        {
            get { return X; }
            set
            {
                X = value;
                OnPropertyChanged("x");
            }
        }


        private int item_id;
        public int Item_ID
        {
            get { return item_id; }
            set
            {
                item_id = value;
                OnPropertyChanged("Item_ID");
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

        private string link;
        public string Link
        {
            get { return link; }
            set
            { 
                link = value;
                OnPropertyChanged("Link");
            }
        }

        private int price;
        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        private int liked;
        public int Liked
        {
            get { return liked; }
            set
            {
                liked = value;
                OnPropertyChanged("Liked");
            }
        }

        private int temp;
        public int Temp
        {
            get { return temp; }
            set
            {
                temp = value;
                OnPropertyChanged("Temp");
            }
        }

        private string shop_name;
        public string Shop_Name
        {
            get { return shop_name; }
            set
            {
                shop_name = value;
                OnPropertyChanged("Shop_Name");
            }
        }

        private ObservableCollection<string> category;
        public ObservableCollection<string> Category
        {
            get { return category; }
            set 
            {
                category = value;
                OnPropertyChanged("Category");
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

        public ItemModel(int idx,string name, int price, int temp, string link, int liked)
        {
            Item_ID = idx;
            Name = name;
            Price = price;
            Temp = temp;
            Link = link;
            Liked = liked;
        }
    }
}
