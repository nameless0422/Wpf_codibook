using codibook.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

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

        private BitmapImage image;
        public BitmapImage Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged("Image");
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
                try
                {
                    Image = htmlParser.LoadImage(htmlParser.GetOgImage(value));
                }
                catch (Exception e) 
                {
                    return;
                }
            }
        }

        private string memo;
        public string Memo
        {
            get { return memo; }
            set
            {
                memo = value;
                OnPropertyChanged("Memo");
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

        public bool Liked_
        {
            get 
            {
                return liked == 1;
            }
            set
            {
                if (value)
                {
                    Liked = 1;
                }
                else
                {
                    Liked = 0;
                }
                OnPropertyChanged("Liked_");
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

        public ItemModel()
        {
            Item_ID = 0;
            Name = "";
            Price = 0;
            Temp = 0;
            Link = "";
            Memo = "";
            Liked = 0;
            Shop_Name = "";
            Category = new ObservableCollection<string>();
        }

        public ItemModel(int idx, string name, string shop_name, int price, int temp, string link, string memo, int liked)
        {
            Item_ID = idx;
            Name = name;
            Price = price;
            Temp = temp;
            Link = link;
            Memo = memo;
            Liked = liked;
            Shop_Name = shop_name;
        }

        public void setNameByLink()
        {
            Name = htmlParser.GetOgTitle(Link);
        }
    }
}
