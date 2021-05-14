using codibook.MVVM.Model;
using codibook.MVVM.View;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static codibook.MVVM.ViewModel.MariaDB;

namespace codibook.MVVM.ViewModel
{

    public class MainViewModel : INotifyPropertyChanged
    {
        private string search_text;

        public string Search_Text
        {
            get { return search_text; }
            set
            {
                search_text = value;
                OnPropertyChanged("Search_Text");
            }
        }

        ItemViewModel itemViewModel;
        LookBookViewModel lookBookViewModel;
        public MariaDbAccess mariaDB_access;

        public MainViewModel()
        {
            mariaDB_access = new MariaDbAccess();
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

    public class MariaDB
    {
        public class MariaDbAccess
        {

            public void MariaDB_Select(string a)
            {

                /// <summary>
                /// DB 연결 스트링
                /// </summary>
                string connectionString = "Server=106.10.57.242;Port=5000;Database=codibook;Uid=root;Pwd=qawzsx351";

                MySqlConnection conn = new MySqlConnection(connectionString);
                MySqlCommand cmd = conn.CreateCommand();
                string sql = a;
                cmd.CommandText = sql;
                try
                {
                    conn.Open();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                }
            }

        }
    }
}
