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
    public static class DBConnecter
    {

        // User 데이터를 받아 전체 아이템 리스트를 받아온다.
        public static ObservableCollection<ItemModel> getItemList(User user)
        {
            ObservableCollection<ItemModel> itemlist = new ObservableCollection<ItemModel>();

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
                                string query1 = "SELECT * FROM item WHERE USER_ID ='" + user.User_ID + "';";

                                MySqlCommand sqlCom1 = new MySqlCommand(query1, con);

                                MySqlDataReader reader1 = sqlCom1.ExecuteReader();

                                while (reader1.Read())
                                {
                                    itemlist.Add(new ItemModel((int)reader1["ITEM_ID"],reader1["NAME"] as string, (int)reader1["PRICE"], (int)reader1["TEMP"], reader1["LINK"] as string, (int)reader1["LIKED"]));
                                }
                                reader1.Close();
                                for (int i = 0; i < itemlist.Count; i++)
                                {
                                    string query2 = "SELECT CATEGORY FROM category WHERE USER_ID ='" + user.User_ID + "' AND ITEM_ID='" + itemlist[i].Item_ID + "';";
                                    MySqlCommand sqlCom2 = new MySqlCommand(query2, con);
                                    MySqlDataReader reader2 = sqlCom2.ExecuteReader();
                                    ObservableCollection<string> category = new ObservableCollection<string>();
                                    while (reader2.Read())
                                    {
                                        category.Add(reader2["CATEGORY"] as string);
                                    }
                                    reader2.Close();
                                    itemlist[i].Category = category;
                                }
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

        // User 데이터를 받아 temp +- 3의 범위 내의 아이템을 받아온다.
        public static ObservableCollection<ItemModel> getItemList(User user, int temp)
        {

            ObservableCollection<ItemModel> itemlist = new ObservableCollection<ItemModel>();

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
                                string query1 = "SELECT * FROM item WHERE USER_ID ='" + user.User_ID + "';";

                                MySqlCommand sqlCom1 = new MySqlCommand(query1, con);

                                MySqlDataReader reader1 = sqlCom1.ExecuteReader();

                                while (reader1.Read())
                                {
                                    
                                    if ((int)reader1["TEMP"] <= temp + 3 || (int)reader1["TEMP"] >= temp - 3) {
                                       
                                        itemlist.Add(new ItemModel((int)reader1["ITEM_ID"], reader1["NAME"] as string, (int)reader1["PRICE"], (int)reader1["TEMP"], reader1["LINK"] as string, (int)reader1["LIKED"]));
                                    } 
                                }
                                reader1.Close();
                                for (int i = 0; i < itemlist.Count(); i++) {
                                    ObservableCollection<string> category = new ObservableCollection<string>();
                                    string query2 = "SELECT CATEGORY FROM category WHERE USER_ID ='" + user.User_ID + "' AND ITEM_ID='" + itemlist[i].Item_ID + "';";
                                    MySqlCommand sqlCom2 = new MySqlCommand(query2, con);
                                    MySqlDataReader reader2 = sqlCom2.ExecuteReader();
                                    while (reader2.Read())
                                    {
                                        category.Add(reader2["CATEGORY"] as string);
                                    }
                                    reader2.Close();
                                    itemlist[i].Category = category;
                                }
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

        /*
        User 데이터를 받고, 검색할 keyword를 받고, mode를 받는다.
        mode가 0이라면 이름을 통해 검색한다.
        mode가 1이라면 카테고리를 통해 검색한다.
        */
        public static ObservableCollection<ItemModel> getItemList(User user, string keyword, int mode)
        {
            ObservableCollection<ItemModel> itemlist = new ObservableCollection<ItemModel>();
            if (mode == 0)
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
                                    string query1 = "SELECT * FROM item WHERE USER_ID ='" + user.User_ID + "' AND NAME='" + keyword + "';";

                                    MySqlCommand sqlCom1 = new MySqlCommand(query1, con);

                                    MySqlDataReader reader1 = sqlCom1.ExecuteReader();

                                    while (reader1.Read())
                                    {
                                        itemlist.Add(new ItemModel((int)reader1["ITEM_ID"], reader1["NAME"] as string, (int)reader1["PRICE"], (int)reader1["TEMP"], reader1["LINK"] as string, (int)reader1["LIKED"]));
                                    }

                                    reader1.Close();

                                    for (int i = 0; i<itemlist.Count(); i++)
                                    {
                                        ObservableCollection<string> category = new ObservableCollection<string>();
                                        string query2 = "SELECT CATEGORY FROM category WHERE USER_ID ='" + user.User_ID + "' AND ITEM_ID='" + itemlist[i].Item_ID + "';";
                                        MySqlCommand sqlCom2 = new MySqlCommand(query2, con);
                                        MySqlDataReader reader2 = sqlCom2.ExecuteReader();
                                        while (reader2.Read())
                                        {
                                            category.Add(reader2["CATEGORY"] as string);
                                        }
                                        reader2.Close();
                                        itemlist[i].Category = category;
                                    }
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
            else if (mode == 1)
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

                                    List<int> IDList = new List<int>();
                                    while (reader1.Read())
                                    {
                                        if (!IDList.Contains((int)reader1["ITEM_ID"]))
                                        {
                                            IDList.Add((int)reader1["ITEM_ID"]);
                                        }
                                    }
                                    reader1.Close();

                                    for (int i = 0; i < IDList.Count(); i++) {
                                        string query2 = "SELECT * FROM item WHERE ITEM_ID='" + IDList[i] + "';";
                                        MySqlCommand sqlCom2 = new MySqlCommand(query2, con);
                                        MySqlDataReader reader2 = sqlCom2.ExecuteReader();
                                        while (reader2.Read())
                                        { 
                                            itemlist.Add(new ItemModel(int.Parse(user.User_ID), reader2["NAME"] as string, (int)reader2["PRICE"], (int)reader2["TEMP"], reader2["LINK"] as string, (int)reader2["LIKED"]));
                                        }
                                        reader2.Close();
                                    }

                                    for (int i = 0; i < itemlist.Count(); i++)
                                    {
                                        ObservableCollection<string> category = new ObservableCollection<string>();
                                        string query3 = "SELECT CATEGORY FROM category WHERE USER_ID ='" + user.User_ID + "' AND ITEM_ID='" + itemlist[i].Item_ID + "';";
                                        MySqlCommand sqlCom3 = new MySqlCommand(query3, con);
                                        MySqlDataReader reader3 = sqlCom3.ExecuteReader();
                                        while (reader3.Read())
                                        {
                                            category.Add(reader3["CATEGORY"] as string);
                                        }
                                        reader3.Close();
                                        itemlist[i].Category = category;
                                    }

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

        // 단일 아이템 받아오기
        // itemID를 바탕으로
        public static ItemModel getItem(int itemID)
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
                                    result = new ItemModel((int)reader["ITEM_ID"], reader["NAME"] as string, (int)reader["PRICE"], (int)reader["TEMP"], reader["LINK"] as string, (int)reader["LIKED"]);
                                }
                                reader.Close();

                                ObservableCollection<string> category = new ObservableCollection<string>();
                                string query2 = "SELECT CATEGORY FROM category WHERE ITEM_ID='" + result.Item_ID + "';";
                                MySqlCommand sqlCom2 = new MySqlCommand(query2, con);
                                MySqlDataReader reader2 = sqlCom2.ExecuteReader();
                                while (reader2.Read())
                                {
                                    category.Add(reader2["CATEGORY"] as string);
                                }
                                reader2.Close();
                                result.Category = category;
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
        public static ItemModel setItem(User user, ItemModel item)
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


        // User 데이터를 받는다.
        // db에서 모든 아이템을 받아온다.
        public static ObservableCollection<LookBookModel> getLookBookList(User user)
        {
            ObservableCollection<LookBookModel> result = new ObservableCollection<LookBookModel>();

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
                                string query1 = "SELECT * FROM LookBook WHERE USER_ID='" + user.User_ID + "';";
                                MySqlCommand sqlCom = new MySqlCommand(query1, con);
                                MySqlDataReader reader = sqlCom.ExecuteReader();
                                while (reader.Read())
                                {
                                    result.Add(new LookBookModel((int)reader["LOOKBOOK_ID"], reader["NAME"] as string));
                                }
                                reader.Close();
                                for(int i=0; i < result.Count(); i++)
                                {
                                    string query2 = "SELECT * FROM LookBook_item WHERE LOOKBOOK_ID='" + result[i].IDX +"';";
                                    MySqlCommand sqlCom2 = new MySqlCommand(query2, con);
                                    MySqlDataReader reader2 = sqlCom2.ExecuteReader();
                                    ObservableCollection<ItemModel> items = new ObservableCollection<ItemModel>();
                                    List<int> item_IDs = new List<int>();
                                    while (reader2.Read())
                                    {
                                        item_IDs.Add((int)reader2["ITEM_ID"]);
                                    }
                                    reader2.Close();
                                    con.Close();
                                    client.Disconnect();
                                    for (int j = 0; j < item_IDs.Count(); j++)
                                    {
                                        items.Add(getItem(item_IDs[j]));
                                    }
                                    result[i].ItemList = items;
                                    result[i].setTotalPrice();
                                    if (result[i].ItemList.Count() >= 3)
                                    {
                                        for(int j = 0; j < 3; j++)
                                        {
                                            result[i].ItemList[j].x = j;
                                            result[i].Top_Three_Item.Add(result[i].ItemList[j]);
                                        }
                                    }
                                    else
                                    {
                                        for(int j = 0; j < result[i].ItemList.Count(); j++)
                                        {
                                            result[i].ItemList[j].x = j;
                                            result[i].Top_Three_Item.Add(result[i].ItemList[j]);
                                        }
                                    }
                                }
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

        // User 데이터를 받고, keyword를 받는다.
        // 이름을 통해 검색한다.
        public static ObservableCollection<LookBookModel> getLookBookList(User user, string keyword)
        {
            ObservableCollection<LookBookModel> result = null;

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
                                string query1 = "SELECT * FROM LookBook WHERE USER_ID='" + user.User_ID + "' AND NAME='" + keyword +"';";
                                MySqlCommand sqlCom = new MySqlCommand(query1, con);
                                MySqlDataReader reader = sqlCom.ExecuteReader();
                                while (reader.Read())
                                {
                                    result.Add(new LookBookModel((int)reader["LOOKBOOK_ID"], reader["NAME"] as string));
                                }
                                reader.Close();
                                for (int i = 0; i < result.Count(); i++)
                                {
                                    string query2 = "SELECT * FROM LookBook_item WHERE LOOKBOOK_ID='" + result[i].IDX + "';";
                                    MySqlCommand sqlCom2 = new MySqlCommand(query2, con);
                                    MySqlDataReader reader2 = sqlCom2.ExecuteReader();
                                    ObservableCollection<ItemModel> items = new ObservableCollection<ItemModel>();
                                    while (reader2.Read())
                                    {
                                        items.Add(getItem((int)reader2["ITEM_ID"]));
                                    }
                                    result[i].ItemList = items;
                                    reader2.Close();
                                }
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
        
        // 단일 룩북 데이터 받아오기
        public static LookBookModel getLookBook(int lookbookID)
        {
            LookBookModel result = null;
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

                                string query1 = "SELECT * FROM LookBook WHERE LOOKBOOK_ID=" + lookbookID + ";";
                                MySqlCommand sqlCom1 = new MySqlCommand(query1, con);
                                MySqlDataReader reader1 = sqlCom1.ExecuteReader();
                                while (reader1.Read())
                                {
                                    result = new LookBookModel(lookbookID,reader1["NAME"] as string);
                                }
                                reader1.Close();

                                ObservableCollection<ItemModel> list = new ObservableCollection<ItemModel>();
                                string query2 = "SELECT * FROM LookBook_item WHERE LOOKBOOK_ID=" + lookbookID + ";";
                                MySqlCommand sqlCom2 = new MySqlCommand(query2, con);
                                MySqlDataReader reader2 = sqlCom2.ExecuteReader();
                                while (reader2.Read())
                                {
                                    list.Add(getItem((int)reader2["ITEM_ID"]));
                                }
                                reader2.Close();
                                result.ItemList = list;
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

        // 단일 룩북데이터 db에 저장후 LookBook_ID 받아오기
        public static LookBookModel setLookBook(User user, LookBookModel LB)
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

                                // 항목 중복체크
                                string query1 = "SELECT COUNT(*) FROM LookBook WHERE USER_ID=" + user.User_ID + " AND NAME='" + LB.Name + "';";
                                MySqlCommand sqlCom = new MySqlCommand(query1, con);
                                if (int.Parse(sqlCom.ExecuteScalar().ToString()) != 0)
                                {
                                    MessageBox.Show("이미 같은 이름의 항목이 존재합니다!");
                                    return LB;
                                }

                                // db에 데이터 INSERT
                                query1 = "INSERT INTO LookBook (NAME, USER_ID) VALUES ('" + LB.Name + "'," + user.User_ID + ");";
                                sqlCom = new MySqlCommand(query1, con);
                                sqlCom.ExecuteNonQuery();

                                // IDX 받아오기, LookBook_item 테이블에 item id 넣기
                                query1 = "SELECT * FROM LookBook WHERE USER_ID=" + user.User_ID + " AND NAME='" + LB.Name +  "';";
                                sqlCom = new MySqlCommand(query1, con);
                                MySqlDataReader reader = sqlCom.ExecuteReader();
                                while (reader.Read())
                                {
                                    LB.IDX = (int)reader["LOOKBOOK_ID"];
                                }
                                reader.Close();
                                // LookBook_item 테이블에 데이터 저장
                                for (int i = 0; i < LB.ItemList.Count; i++)
                                {
                                    string query2 = "INSERT INTO LookBook_item (ITEM_ID, LOOKBOOK_ID) VALUES (" + LB.ItemList[i].Item_ID + "," + LB.IDX + ");";
                                    MySqlCommand sqlCom2 = new MySqlCommand(query2, con);
                                    sqlCom2.ExecuteNonQuery();
                                }
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
            return LB;
        }

    }
}
