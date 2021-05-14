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
            this.USERS = new List<User>();
            for (int i = 0; i < users.USERS.Count(); i++)
            {
                this.USERS.Add(new User(users.USERS[i].ID, users.USERS[i].Password, users.USERS[i].User_ID, users.USERS[i].Time));
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

        public User(string id_, string password_)
        {
            time = DateTime.Now.ToString("yyyyMMddHHmmss");
            ID = id_;
            Password = (password_.GetHashCode() & 0x7fffffff).ToString();
            User_ID = ((id_ + time).GetHashCode() & 0x7fffffff).ToString();
        }

        // 복사용
        public User(string id_, string password_, string user_id_, string time_)
        {
            Time = time_;
            ID = id_;
            Password = password_;
            User_ID = user_id_;
        }
        // 복사 생성자
        public User(User user)
        {
            this.ID = user.ID;
            this.Password = user.Password;
            this.Time = user.Time;
            this.User_ID = user.User_ID;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        private string id;
        private string password;
        private string user_id;
        private string time;

        public string Time
        {
            get { return time; }
            set 
            { 
                time = value;
                OnPropertyChanged("Time");
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
            get { return password; }
            set 
            { 
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public string User_ID
        {
            get { return user_id; }
            set 
            {
                user_id = value;
                OnPropertyChanged("User_ID");
            }
        }
    }
}
