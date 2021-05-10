using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codibook.MVVM.Model
{

    public class WeatherModel : INotifyPropertyChanged
    {
        private Items ITEMS;
        public Items Items { get { return ITEMS; } set { ITEMS = value; OnPropertyChanged("Items"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }

    public class Item : INotifyPropertyChanged
    {

        private string BaseDate;
        private string BaseTime;
        private string Category;
        private string Time;
        private string Value;

        public string baseDate { get { return BaseDate; } set { BaseDate = value; OnPropertyChanged("baseDate"); } }
        public string baseTime { get { return BaseTime; } set { BaseTime = value; OnPropertyChanged("baseTime"); } }
        public string category { get { return Category; } set { Category = value; OnPropertyChanged("category");} }
        public string fcstTime { get { return Time; } set { Time = value; OnPropertyChanged("fcstTime"); } }
        public string fcstValue { get { return Value; } set { Value = value; OnPropertyChanged("fcstValue"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class Items : INotifyPropertyChanged
    {
        private IList<Item> ITEM;
        public IList<Item> item { get { return ITEM; } set { ITEM = value; OnPropertyChanged("item"); } }

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
