﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codibook.MVVM.Model
{
    public class LookBookModel : INotifyPropertyChanged
    {
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
        private List<ItemModel> ItemList;
        public LookBookModel(string name, List<ItemModel> itemlist)
        {
            Name = name;
            ItemList = new List<ItemModel>();
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
