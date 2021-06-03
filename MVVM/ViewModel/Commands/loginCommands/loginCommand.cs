using codibook.MVVM.Model;
using codibook.MVVM.View;
using MySql.Data.MySqlClient;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace codibook.MVVM.ViewModel.Commands.loginCommands
{
    public class loginCommand : ICommand
    {
        public loginCommand() { 
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            LoginWindow window = parameter as LoginWindow;

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
                            var portForwarded = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
                            client.AddForwardedPort(portForwarded);
                            portForwarded.Start();

                            // db 접속
                            using (MySqlConnection con = new MySqlConnection("SERVER=localhost;PORT=3306;UID=root;PASSWORD=qawzsx351;DATABASE=codibook;SslMode=None"))
                            {
                                con.Open();
                                if (window.ID_BOX.Text.Equals(string.Empty) || window.ID_BOX.Text.Length <= 5)
                                {
                                    MessageBox.Show("id는 6글자 이상이어야 햡니다.");
                                    return;
                                }
                                if (window.Password_BOX.Password.Equals(string.Empty) || window.Password_BOX.Password.Length <= 7)
                                {
                                    MessageBox.Show("password는 8글자 이상이어야 햡니다.");
                                    return;
                                }
                                if (!CheckEnglish(window.ID_BOX.Text))
                                {
                                    MessageBox.Show("id에는 영어가 포함되어야 합니다.");
                                    return;
                                }
                                user = new User(window.ID_BOX.Text, (window.Password_BOX.Password.GetHashCode() & 0x7fffffff).ToString(),"","");
                                string query1 = "SELECT COUNT(*) FROM user WHERE ID='" + window.ID_BOX.Text + "' AND PASSWORD='" + user.Password + "'";
                                MySqlCommand sqlCom = new MySqlCommand(query1, con);
                                if (sqlCom.ExecuteScalar().ToString().Equals("1"))
                                {
                                    string query2 = "SELECT * FROM user WHERE ID='" + window.ID_BOX.Text + "' AND PASSWORD='" + user.Password + "'";
                                    MySqlCommand sqlCom2 = new MySqlCommand(query2, con);
                                    MySqlDataReader reader = sqlCom2.ExecuteReader();
                                    while (reader.Read())
                                    {
                                        user.User_ID = ((int)reader["USER_ID"]).ToString();
                                        user.Time = reader["TIME"] as string;
                                    }
                                    con.Close();
                                    client.Disconnect();
                                    mainWindow = new MainWindow();
                                    (mainWindow.Resources["MainVM"] as MainViewModel).user = user;
                                    mainWindow.Mainframe.Navigate(new ItemViewPage(mainWindow.Resources["MainVM"] as MainViewModel));
                                    mainWindow.Show();
                                    window.Close();
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


        // 문자열 체크용
        public static bool CheckEnglish(string letter)

        {
            Regex engRegex = new Regex(@"[a-zA-Z]");

            return engRegex.IsMatch(letter);
        }
    }
}
