using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codibook.MVVM.Model
{
    public class ItemModel : INotifyPropertyChanged
    {

        private string link;
        public string Link
        {
            get { return link; }
            set
            { 
                link = value;
                OnPropertyChanged("Link");
            }
        }
        private int liked;
        public int Liked
        {
            get { return liked; }
            set
            {
                liked = value;
                OnPropertyChanged("");
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

        public ItemModel(string link, int liked, List<string> category)
        {
            Link = link;
            Liked = liked;
            Category = new ObservableCollection<string>();
            for(int i = 0; i < category.Count(); i++)
            {
                Category.Add(category[i]);
            }
        }
    }
}
