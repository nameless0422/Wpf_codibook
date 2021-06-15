using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using codibook.MVVM.Model;
using System.Windows;
using System.Collections.ObjectModel;
using codibook.Classes;
using codibook.MVVM.ViewModel.Commands.itemViewCommands;
using System.ComponentModel;
using codibook.MVVM.View;
using codibook.MVVM.View.SearchViewListPages;

namespace codibook.MVVM.ViewModel
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        public User user { get; set; }
        public ObservableCollection<ItemModel> recommand_four { get; set; }

        public ObservableCollection<ItemModel> recommandsList { get; set; }

        public ObservableCollection<ItemModel> items { get; set; }

        public OpenItemCommand OpenItemCommandProperty { get; set; }

        public OpenSearchItemCommand OpenSearchItemCommandProperty { get; set; }

        public AddItemCommand AddItemCommandProperty { get; set; }

        public SearchItemPage searchItemPage { get; set; }

        public ItemViewPage itemViewPage { get; set; }

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

        public bool IsItemPopup;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ItemViewModel()
        {
            items = new ObservableCollection<ItemModel>();
            recommand_four = new ObservableCollection<ItemModel>();
            recommandsList = new ObservableCollection<ItemModel>();
            OpenItemCommandProperty = new OpenItemCommand();
            OpenSearchItemCommandProperty = new OpenSearchItemCommand();
            AddItemCommandProperty = new AddItemCommand();
            IsItemPopup = false;
        }

        public void setUser(User U)
        {
            user = U;
        }

        public void addItem(ItemModel I)
        {
            items.Add(DBConnecter.setItem(user,I));
        }

        public void setItemlist()
        {
            items = DBConnecter.getItemList(user);
        }

        public void setItemlist(string keyword, int mode)
        {
            items = DBConnecter.getItemList(user,keyword,mode);
        }

        public void updateWeatherRecommands(int temp)
        {
            recommandsList = DBConnecter.getItemList(user, temp);
        }



    }

}