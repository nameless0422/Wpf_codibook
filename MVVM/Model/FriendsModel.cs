using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace codibook.MVVM.Model
{
    public class FriendsModel : INotifyPropertyChanged
    {
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

        private string user_name;
        public string User_Name
        {
            get { return user_name; }
            set
            {
                user_name = value;
                OnPropertyChanged("User_Name");
            }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged("Message");
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

        public FriendsModel()
        {

        }

        public FriendsModel(string user_name, string message)
        {
            User_Name = user_name;
            Message = message;
        }
    }
}
