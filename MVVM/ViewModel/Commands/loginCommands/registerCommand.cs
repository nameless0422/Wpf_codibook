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
    public class registerCommand : ICommand
    {
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

                                string query1 = "SELECT COUNT(*) FROM user WHERE ID='" + window.ID_BOX.Text + "'";
                                MySqlCommand sqlCom = new MySqlCommand(query1, con);
                                object query1_result = sqlCom.ExecuteScalar();
                                if (int.Parse(query1_result.ToString()) != 0)
                                {
                                    MessageBox.Show("이미 존재하는 id입니다.");
                                    return;
                                }

                                if (window.ID_BOX.Text.Equals(string.Empty) || window.ID_BOX.Text.Length <= 5)
                                {
                                    MessageBox.Show("id는 6글자 이상이어야 햡니다.");
                                    return;
                                }
                                else if (!CheckEnglish(window.ID_BOX.Text))
                                {
                                    MessageBox.Show("id는 6글자 이상이어야 햡니다.");
                                    return;
                                }
                                if (window.Password_BOX.Password.Equals(string.Empty) || window.Password_BOX.Password.Length <= 7)
                                {
                                    MessageBox.Show("password는 8글자 이상이어야 햡니다.");
                                    return;
                                }
                                // 조건에 어긋나지 않으면 새로운 유저 객체를 만들어서 그 값을 서버에 저장한다.
                                User user = new User(window.ID_BOX.Text, window.Password_BOX.Password);
                                string query2 = "INSERT INTO user VALUE (" + user.User_ID + ", '" + user.ID + "', '" + user.Password + "', '" + user.Time + "');";
                                sqlCom = new MySqlCommand(query2, con);
                                sqlCom.ExecuteNonQuery();
                                con.Close();
                                client.Disconnect();
                                MainWindow mainWindow = new MainWindow(user);
                                mainWindow.Show();
                                window.Close();
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
