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

namespace codibook.MVVM.ViewModel
{
    public class ItemViewModel
    {
        public User user { get; set; }
        public ObservableCollection<ItemModel> recommand_four { get; set; }

        public ObservableCollection<ItemModel> recommandsList { get; set; }

        public ObservableCollection<ItemModel> items { get; set; }

        public AddItemButtonCommand addItemButtonCommandProperty { get; set; }

        public ItemDoubleClickCommand itemDoubleClickCommandProperty { get; set; }

        public bool IsItemPopup;
        public ItemViewModel()
        {
            items = new ObservableCollection<ItemModel>();
            recommand_four = new ObservableCollection<ItemModel>();
            recommandsList = new ObservableCollection<ItemModel>();
            addItemButtonCommandProperty = new AddItemButtonCommand();
            itemDoubleClickCommandProperty = new ItemDoubleClickCommand();
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