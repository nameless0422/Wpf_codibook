using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Renci.SshNet;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using codibook.MVVM.Model;
using MySql.Data.MySqlClient;

namespace codibook.MVVM.View
{
    /// <summary>
    /// LoginPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginWindow : Window
    {

        public LoginWindow()
        {
            InitializeComponent();

        }
        
        
        // 타이틀바 드래그
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        // 최소화
        private void ToMiniButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        // 닫기
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var client = new SshClient("106.10.57.242", 5000, "root", "qawzsx351"))
                {
                    client.Connect();
                    if (client.IsConnected)
                    {
                        try
                        {
                            var portForwarded = new ForwardedPortLocal("localhost", 3306, "106.10.57.242", 5001);
                            client.AddForwardedPort(portForwarded);
                            portForwarded.Start();

                            using (MySqlConnection con = new MySqlConnection("SERVER=localhost;PORT=3307;UID=root;PASSWORD=qawzsx351;DATABASE=codibook;SslMode=None"))
                            {
                                con.Open();
                                if (this.ID_BOX.Text.Equals(string.Empty) || this.ID_BOX.Text.Length <= 5)
                                {
                                    MessageBox.Show("id는 6글자 이상이어야 햡니다.");
                                    return;
                                }
                                if (this.Password_BOX.Password.Equals(string.Empty) || this.Password_BOX.Password.Length <= 7)
                                {
                                    MessageBox.Show("password는 8글자 이상이어야 햡니다.");
                                    return;
                                }
                                User user = new User(this.ID_BOX.Text, this.Password_BOX.Password);
                                string query = "";
                                MySqlCommand sqlCom = new MySqlCommand(query, con);
                                sqlCom.ExecuteNonQuery();
                                con.Close();
                            }
                            client.Disconnect();
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Close();
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
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                using (var client = new SshClient("106.10.57.242", 5000, "root", "qawzsx351")) 
                {
                    client.Connect();
                    if (client.IsConnected)
                    {
                        try
                        {
                            var portForwarded = new ForwardedPortLocal("localhost", 3306 , "106.10.57.242", 5001);
                            client.AddForwardedPort(portForwarded);
                            portForwarded.Start();

                            using (MySqlConnection con = new MySqlConnection("SERVER=localhost;PORT=3307;UID=root;PASSWORD=qawzsx351;DATABASE=codibook;SslMode=None"))
                            {
                                con.Open();
                                if(this.ID_BOX.Text.Equals(string.Empty) || this.ID_BOX.Text.Length <= 5)
                                {
                                    MessageBox.Show("id는 6글자 이상이어야 햡니다.");
                                    return;
                                }
                                if (this.Password_BOX.Password.Equals(string.Empty) || this.Password_BOX.Password.Length <= 7) 
                                {
                                    MessageBox.Show("password는 8글자 이상이어야 햡니다.");
                                    return;
                                }
                                User user = new User(this.ID_BOX.Text, this.Password_BOX.Password);
                                string query = "INSERT INTO user VALUE ("+ user.User_ID +", '" + user.ID + "', '"+ user.Password +"', '" + user.Time + "');";
                                MySqlCommand sqlCom = new MySqlCommand(query, con);
                                sqlCom.ExecuteNonQuery();
                                con.Close();
                            }
                            client.Disconnect();
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Close();
                        }catch (Exception ex)
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

        }
    }
}
