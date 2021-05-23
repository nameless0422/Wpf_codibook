using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using codibook.MVVM.Model;
using System.Windows;
using System.Collections.ObjectModel;

namespace codibook.MVVM.ViewModel
{
    class ItemViewModel
    {
        public User user { get; set; }
        public ObservableCollection<ItemModel> items { get; set; }
        public ItemViewModel()
        {
            items = new ObservableCollection<ItemModel>();
        }

        public void setUser(User U)
        {
            user = U;
        }

        public void addItem(ItemModel I)
        {
            items.Add(I);
        }

    }

}