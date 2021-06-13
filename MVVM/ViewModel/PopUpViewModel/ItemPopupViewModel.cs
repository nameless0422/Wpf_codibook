using codibook.Classes;
using codibook.MVVM.Model;
using codibook.MVVM.ViewModel.Commands.closeCommands;
using codibook.MVVM.ViewModel.Commands.titlebarCommands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace codibook.MVVM.ViewModel.PopUpViewModel
{
    public class ItemPopupViewModel : INotifyPropertyChanged
    {
        public ItemPopupCloseCommand ItemPopupCloseCommandProperty { get; set; }
        public ItemPopupTitleBarCommand ItemPopupTitleBarCommandProperty { get; set; }

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

        public ItemPopupViewModel()
        {
            ItemPopupCloseCommandProperty = new ItemPopupCloseCommand();
            ItemPopupTitleBarCommandProperty = new ItemPopupTitleBarCommand();
        }
    }
}
