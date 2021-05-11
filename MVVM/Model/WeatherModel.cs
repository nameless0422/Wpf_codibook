using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codibook.MVVM.Model
{

    public class WeatherModel : INotifyPropertyChanged
    {
        private Response response;
        public Response Response { get { return response; } set { response = value; OnPropertyChanged("Response"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public WeatherModel()
        {

        }

        public WeatherModel(Items items)
        {
            this.Response = new Response();
            this.Response.body = new Body();
            this.Response.body.items = new Items();
            this.Response.body.items.item = new List<Item>();
            for(int i = 0; i < items.item.Count(); i++)
            {
                this.Response.body.items.item.Add(new Item ( items.item[i].baseDate, items.item[i].baseTime, items.item[i].category, items.item[i].fcstDate, items.item[i].fcstTime, items.item[i].fcstValue, items.item[i].nx, items.item[i].ny));
            }
            
        }

    }
    public class Header
    {
        public string resultCode { get; set; }
        public string resultMsg { get; set; }
    }

    public class Item
    {
        public string baseDate { get; set; }
        public string baseTime { get; set; }
        public string category { get; set; }
        public string fcstDate { get; set; }
        public string fcstTime { get; set; }
        public string fcstValue { get; set; }
        public int nx { get; set; }
        public int ny { get; set; }
        public Item(string BaseDate, string BaseTime, string Category, string Date, string Time, string Value, int x, int y)
        {
            this.baseDate = BaseDate;
            this.baseTime = BaseTime;
            this.category = Category;
            this.fcstDate = Date;
            this.fcstTime = Time;
            this.fcstValue = Value;
            this.nx = x;
            this.ny = y;
        }
    }

    public class Items
    {
        public List<Item> item { get; set; }
    }

    public class Body
    {
        public string dataType { get; set; }
        public Items items { get; set; }
        public int pageNo { get; set; }
        public int numOfRows { get; set; }
        public int totalCount { get; set; }
    }

    public class Response
    {
        public Header header { get; set; }
        public Body body { get; set; }
    }

}
