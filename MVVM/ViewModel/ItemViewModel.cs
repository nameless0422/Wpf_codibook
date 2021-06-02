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

namespace codibook.MVVM.ViewModel
{
    public class ItemViewModel
    {
        public User user { get; set; }
        public ObservableCollection<ItemModel> recommands { get; set; }
        public ObservableCollection<ItemModel> items { get; set; }
        public ItemViewModel()
        {
            items = new ObservableCollection<ItemModel>();
            recommands = new ObservableCollection<ItemModel>();
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
            recommands = DBConnecter.getItemList(user, temp);
        }



    }

}