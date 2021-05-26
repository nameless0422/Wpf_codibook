using codibook.MVVM.Model;
using MySql.Data.MySqlClient;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace codibook.Classes
{
    public class DBConnecter
    {

        // User 데이터를 받고, 검색할 keyword를 받고, mode를 받는다.
        // keyword가 빈 문자열이면 db에서 모든 아이템을 받아온다.
        // mode가 0이라면 이름을 통해 검색한다.
        // mode가 1이라면 카테고리를 통해 검색한다.
        public ObservableCollection<ItemModel> getItemList(User user, string keyword, int mode)
        {
            ObservableCollection<ItemModel> itemlist = new ObservableCollection<ItemModel>();
            if (keyword.Equals(string.Empty))
            {
                try
                {
                    // ssh 접속
                    using (var client = new SshClient("106.10.57.242", 5000, "root", "qawzsx351"))
                    {
                        client.Connect();
                        if (client.IsConnected)
                        {
                            try
                            {
                                // 내부 db 접속을 위한 포트포워딩
                                var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                                client.AddForwardedPort(portForwarded);
                                portForwarded.Start();

                                // db 접속
                                using (MySqlConnection con = new MySqlConnection("SERVER=localhost;PORT=3306;UID=root;PASSWORD=qawzsx351;DATABASE=codibook;SslMode=None"))
                                {
                                    con.Open();
                                    string query1 = "SELECT * FROM item WHERE USER_ID ='"+user.User_ID+"';";
                                    
                                    MySqlCommand sqlCom1 = new MySqlCommand(query1, con);
                                    
                                    MySqlDataReader reader1 = sqlCom1.ExecuteReader();
                                      
                                    while (reader1.Read())
                                    {
                                        ObservableCollection<string> category = new ObservableCollection<string>();
                                        string query2 = "SELECT CATEGORY FROM category WHERE USER_ID ='" + user.User_ID+"' AND ='"+reader1["ITEM_ID"] as string+"';";
                                        MySqlCommand sqlCom2 = new MySqlCommand(query2, con);
                                        MySqlDataReader reader2 = sqlCom2.ExecuteReader();
                                        while (reader2.Read())
                                        {
                                            category.Add(reader2["CATEGORY"] as string);
                                        }
                                        reader2.Close();
                                        itemlist.Add(new ItemModel(reader1["NAME"] as string,(int)reader1["PRICE"],(int)reader1["TEMP"],reader1["LINK"] as string, (int)reader1["LIKED"], category));
                                    }
                                    reader1.Close();
                                    con.Close();
                                    client.Disconnect();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Client cannot be reached...");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return itemlist;
            }
            else
            {   if (mode == 0) {
                    try
                    {
                        // ssh 접속
                        using (var client = new SshClient("106.10.57.242", 5000, "root", "qawzsx351"))
                        {
                            client.Connect();
                            if (client.IsConnected)
                            {
                                try
                                {
                                    // 내부 db 접속을 위한 포트포워딩
                                    var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                                    client.AddForwardedPort(portForwarded);
                                    portForwarded.Start();

                                    // db 접속
                                    using (MySqlConnection con = new MySqlConnection("SERVER=localhost;PORT=3306;UID=root;PASSWORD=qawzsx351;DATABASE=codibook;SslMode=None"))
                                    {
                                        con.Open();
                                        string query1 = "SELECT * FROM item WHERE USER_ID ='" + user.User_ID + "' AND NAME='" + keyword + "';";

                                        MySqlCommand sqlCom1 = new MySqlCommand(query1, con);

                                        MySqlDataReader reader1 = sqlCom1.ExecuteReader();

                                        while (reader1.Read())
                                        {
                                            ObservableCollection<string> category = new ObservableCollection<string>();
                                            string query2 = "SELECT CATEGORY FROM category WHERE USER_ID ='" + user.User_ID + "' AND ='" + reader1["ITEM_ID"] as string + "';";
                                            MySqlCommand sqlCom2 = new MySqlCommand(query2, con);
                                            MySqlDataReader reader2 = sqlCom2.ExecuteReader();
                                            while (reader2.Read())
                                            {
                                                category.Add(reader2["CATEGORY"] as string);
                                            }
                                            reader2.Close();
                                            itemlist.Add(new ItemModel(reader1["NAME"] as string, (int)reader1["PRICE"], (int)reader1["TEMP"], reader1["LINK"] as string, (int)reader1["LIKED"], category));
                                        }

                                        reader1.Close();
                                        con.Close();
                                        client.Disconnect();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Client cannot be reached...");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    return itemlist;
                }
                else if(mode == 1)
                {
                    try
                    {
                        // ssh 접속
                        using (var client = new SshClient("106.10.57.242", 5000, "root", "qawzsx351"))
                        {
                            client.Connect();
                            if (client.IsConnected)
                            {
                                try
                                {
                                    // 내부 db 접속을 위한 포트포워딩
                                    var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                                    client.AddForwardedPort(portForwarded);
                                    portForwarded.Start();

                                    // db 접속
                                    using (MySqlConnection con = new MySqlConnection("SERVER=localhost;PORT=3306;UID=root;PASSWORD=qawzsx351;DATABASE=codibook;SslMode=None"))
                                    {
                                        con.Open();

                                        string query1 = "SELECT * FROM category WHERE USER_ID ='" + user.User_ID + "' AND CATEGORY='" + keyword + "';";
                                        MySqlCommand sqlCom1 = new MySqlCommand(query1, con);
                                        MySqlDataReader reader1 = sqlCom1.ExecuteReader();

                                        while (reader1.Read()) {
                                            string selectedID = reader1["ITEM_ID"] as string;

                                            string query2 = "SELECT * FROM item WHERE USER_ID ='" + user.User_ID + "' AND ITEM_ID='" + selectedID + "';";
                                            MySqlCommand sqlCom2 = new MySqlCommand(query2, con);
                                            MySqlDataReader reader2 = sqlCom2.ExecuteReader();


                                            while (reader2.Read())
                                            {
                                                ObservableCollection<string> category = new ObservableCollection<string>();
                                                string query3 = "SELECT CATEGORY FROM category WHERE USER_ID ='" + user.User_ID + "' AND ='" + reader2["ITEM_ID"] as string + "';";
                                                MySqlCommand sqlCom3 = new MySqlCommand(query3, con);
                                                MySqlDataReader reader3 = sqlCom3.ExecuteReader();
                                                while (reader3.Read())
                                                {
                                                    category.Add(reader3["CATEGORY"] as string);
                                                }
                                                reader3.Close();
                                                itemlist.Add(new ItemModel(reader2["NAME"] as string, (int)reader2["PRICE"], (int)reader2["TEMP"], reader2["LINK"] as string, (int)reader2["LIKED"], category));
                                            }
                                            reader2.Close();
                                        }
                                        reader1.Close();
                                        con.Close();
                                        client.Disconnect();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Client cannot be reached...");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    return itemlist;
                }
                return itemlist;
            }
        }

        // 단일 아이템 받아오기
        // itemID를 바탕으로
        public ItemModel getItem(int itemID)
        {
            ItemModel result = null;
            try
            {
                // ssh 접속
                using (var client = new SshClient("106.10.57.242", 5000, "root", "qawzsx351"))
                {
                    client.Connect();
                    if (client.IsConnected)
                    {
                        try
                        {
                            // 내부 db 접속을 위한 포트포워딩
                            var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                            client.AddForwardedPort(portForwarded);
                            portForwarded.Start();

                            // db 접속
                            using (MySqlConnection con = new MySqlConnection("SERVER=localhost;PORT=3306;UID=root;PASSWORD=qawzsx351;DATABASE=codibook;SslMode=None"))
                            {
                                con.Open();
                                string query1 = "SELECT * FROM item WHERE ITEM_ID='" + itemID + "';";
                                MySqlCommand sqlCom = new MySqlCommand(query1, con);
                                MySqlDataReader reader = sqlCom.ExecuteReader();
                                while (reader.Read())
                                {
                                    ObservableCollection<string> category = new ObservableCollection<string>();
                                    string query2 = "SELECT CATEGORY FROM category WHERE ITEM_ID-'" + reader["ITEM_ID"] as string + "';";
                                    MySqlCommand sqlCom2 = new MySqlCommand(query2, con);
                                    MySqlDataReader reader2 = sqlCom2.ExecuteReader();
                                    while (reader2.Read())
                                    {
                                        category.Add(reader2["CATEGORY"] as string);
                                    }
                                    reader2.Close();
                                    result = new ItemModel(reader["NAME"] as string, (int)reader["PRICE"], (int)reader["TEMP"], reader["LINK"] as string, (int)reader["LIKED"], category);
                                }
                                reader.Close();
                                con.Close();
                                client.Disconnect();

                            }


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Client cannot be reached...");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        // 단일 아이템 데이터 db에 저장후 ITEM_ID 받아오기
        public ItemModel setItem(User user, ItemModel item)
        {
            try
            {
                // ssh 접속
                using (var client = new SshClient("106.10.57.242", 5000, "root", "qawzsx351"))
                {
                    client.Connect();
                    if (client.IsConnected)
                    {
                        try
                        {
                            // 내부 db 접속을 위한 포트포워딩
                            var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                            client.AddForwardedPort(portForwarded);
                            portForwarded.Start();

                            // db 접속
                            using (MySqlConnection con = new MySqlConnection("SERVER=localhost;PORT=3306;UID=root;PASSWORD=qawzsx351;DATABASE=codibook;SslMode=None"))
                            {
                                con.Open();
                                string query1 = "INSERT INTO item (USER_ID, NAME, LINK, PRICE, LIKED, TEMP) VALUES (" + user.User_ID + ", '" + item.Name + "', '" + item.Link + "', " + item.Price + ", " + item.Liked + ", " + item.Temp + ");";
                                MySqlCommand sqlCom = new MySqlCommand(query1, con);
                                sqlCom.ExecuteNonQuery();
                                query1 = "SELECT * FROM item WHERE USER_ID=" + user.User_ID +" AND LINK='" + item.Link + "';";
                                sqlCom = new MySqlCommand(query1, con);
                                MySqlDataReader reader = sqlCom.ExecuteReader();
                                while (reader.Read())
                                {
                                    item.Item_ID = (int)reader["ITEM_ID"];
                                }
                                reader.Close();
                                con.Close();
                                client.Disconnect();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Client cannot be reached...");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return item;
        }
    }
}
