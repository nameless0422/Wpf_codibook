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
using System.Text.RegularExpressions;

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
                MainWindow mainWindow;
                User user;

                // ssh 접속
                using (var client = new SshClient("106.10.57.242", 5000, "root", "qawzsx351"))
                {
                    client.Connect();
                    if (client.IsConnected)
                    {
                        try
                        {
                            // 내부 db 접속을 위한 포트포워딩
                            var portForwarded = new ForwardedPortLocal("localhost", 3306, "106.10.57.242", 5001);
                            client.AddForwardedPort(portForwarded);
                            portForwarded.Start();

                            // db 접속
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
                                user = new User(this.ID_BOX.Text, this.Password_BOX.Password);
                                string query1 = "SELECT COUNT(*) FROM user WHERE ID='" + this.ID_BOX.Text + "' AND PASSWORD='" + user.Password + "'";
                                MySqlCommand sqlCom = new MySqlCommand(query1, con);
                                if (sqlCom.ExecuteScalar().ToString().Equals("1"))
                                {
                                    con.Close();
                                    client.Disconnect();
                                    mainWindow = new MainWindow(user);
                                    mainWindow.Show();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("로그인 정보가 잘못되었습니다.");
                                    return;
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
        }

        private void Register_Click(object sender, RoutedEventArgs e)
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
                            var portForwarded = new ForwardedPortLocal("localhost", 3306 , "106.10.57.242", 5001);
                            client.AddForwardedPort(portForwarded);
                            portForwarded.Start();

                            // db 접속
                            using (MySqlConnection con = new MySqlConnection("SERVER=localhost;PORT=3307;UID=root;PASSWORD=qawzsx351;DATABASE=codibook;SslMode=None"))
                            {
                                con.Open();
                                MySqlCommand sqlCom;
                                string query1 = "SELECT COUNT(*) FROM user WHERE ID='"+ this.ID_BOX.Text +"'";
                                sqlCom = new MySqlCommand(query1, con);
                                object query1_result = sqlCom.ExecuteScalar();
                                if(int.Parse(query1_result.ToString()) != 0)
                                {
                                    MessageBox.Show("이미 존재하는 id입니다.");
                                    return;
                                }
                                
                                if (this.ID_BOX.Text.Equals(string.Empty) || this.ID_BOX.Text.Length <= 5)
                                {
                                    MessageBox.Show("id는 6글자 이상이어야 햡니다.");
                                    return;
                                }
                                else if(!CheckEnglish(this.ID_BOX.Text)) 
                                {
                                    MessageBox.Show("id는 6글자 이상이어야 햡니다.");
                                    return;
                                }
                                if (this.Password_BOX.Password.Equals(string.Empty) || this.Password_BOX.Password.Length <= 7) 
                                {
                                    MessageBox.Show("password는 8글자 이상이어야 햡니다.");
                                    return;
                                }
                                // 조건에 어긋나지 않으면 새로운 유저 객체를 만들어서 그 값을 서버에 저장한다.
                                User user = new User(this.ID_BOX.Text, this.Password_BOX.Password);
                                string query2 = "INSERT INTO user VALUE ("+ user.User_ID +", '" + user.ID + "', '"+ user.Password +"', '" + user.Time + "');";
                                sqlCom = new MySqlCommand(query2, con);
                                sqlCom.ExecuteNonQuery();
                                con.Close();
                                client.Disconnect();
                                MainWindow mainWindow = new MainWindow(user);
                                mainWindow.Show();
                                this.Close();
                            }
                            
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

        // 문자열 체크용
        public static bool CheckEnglish(string letter)

        {
            Regex engRegex = new Regex(@"[a-zA-Z]");

            return engRegex.IsMatch(letter);
        }
    }

}


