using codibook.Classes;
using codibook.MVVM.Model;
using codibook.MVVM.ViewModel.Commands.closeCommands;
using codibook.MVVM.ViewModel.Commands.itemViewCommands;
using codibook.MVVM.ViewModel.Commands.titlebarCommands;
using codibook.MVVM.ViewModel.PopUpViewModel.PopUpCommands;
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

        public EditItemCommand editItemCommandProperty { get; set; }

        public EditItemMemoCommand editItemMemoCommandProperty { get; set; }

        public ItemPopupCategoryCommand itemPopupCategoryCommandProperty { get; set; }

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

        private bool liked;
        public bool Liked
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

        private bool isreadonly_memo;
        public bool IsReadOnly_Memo
        {
            get { return isreadonly_memo; }
            set
            {
                isreadonly_memo = value;
                OnPropertyChanged("IsReadOnly_Memo");
            }
        }

        public bool IsCategoryPopup;

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
            isreadonly = true;
            isreadonly_memo = true;
            IsCategoryPopup = false;
            ItemPopupCloseCommandProperty = new ItemPopupCloseCommand();
            ItemPopupTitleBarCommandProperty = new ItemPopupTitleBarCommand();
            editItemCommandProperty = new EditItemCommand();
            editItemMemoCommandProperty = new EditItemMemoCommand();
            itemPopupCategoryCommandProperty = new ItemPopupCategoryCommand();
        }
    }
}
