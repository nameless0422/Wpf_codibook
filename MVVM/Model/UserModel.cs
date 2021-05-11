using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codibook.MVVM.Model
{
    public class UserModel : INotifyPropertyChanged
    {
        private List<User> users;
        public List<User> USERS
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged("USERS");
            }
        }

        public UserModel(UserModel users)
        {
            for (int i = 0; i < users.USERS.Count(); i++)
            {
                this.USERS.Add(new User(users.USERS[i].Name, users.USERS[i].ID, users.USERS[i].Password, users.USERS[i].User_ID, users.USERS[i].Time));
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

    public class User : INotifyPropertyChanged
    {

        public User(string name_, string id_, string password_)
        {
            time = DateTime.Now.ToString("HHmmss");
            Name = name_;
            ID = id_;
            Password = password_;
            User_ID = id_ + password_ + time;
        }

        // 복사용
        public User(string name_, string id_, string password_, string user_id_, string time_)
        {
            Time = time_;
            Name = name_;
            ID = id_;
            Password = password_;
            User_ID = user_id_;
        }

        private string name;
        private string id;
        private int password;
        private int user_id;
        private string time;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string Time
        {
            get { return time; }
            set 
            { 
                time = value;
                OnPropertyChanged("Time");
            }
        }

        public string Name
        {
            get { return name; }
            set 
            { 
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string ID
        {
            get { return id; }
            set 
            { 
                id = value;
                OnPropertyChanged("ID");
            }
        }

        public string Password
        {
            get { return password.ToString(); }
            set 
            { 
                password = value.GetHashCode();
                OnPropertyChanged("Password");
            }
        }

        public string User_ID
        {
            get { return user_id.ToString(); }
            set 
            { 
                user_id = value.GetHashCode();
                OnPropertyChanged("User_ID");
            }
        }
    }
}
