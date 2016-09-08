using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Sql;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;

namespace Pokiemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string constring = "datasource=127.0.0.1; port=3307; username=root; password=usbw;";

        public MainWindow()
        {
            InitializeComponent();
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri("http://www.pixelstalk.net/wp-content/uploads/2016/02/Pokemon-Backgrounds-for-desktop.jpg", UriKind.Absolute));
            this.Background = myBrush;

            
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (tbUser.Text.Length > 7 || tbPass.Password.Length > 8)
            {
                if (tbUser.Text != "Username" || tbPass.Password != "Password")
                {
                    //string constring = "datasource=127.0.0.1; port=3307; username=root; password=usbw;";
                    string Query = "INSERT INTO pokemon_db.users(Username, Password, Mail)VALUES('" + tbUser.Text + "','" + tbPass.Password + "','" + tbMail.Text + "') ; ";
                    MySqlConnection conDatabase = new MySqlConnection(constring);
                    MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
                    MySqlDataReader myReader;

                    try
                    {

                        conDatabase.Open();
                        myReader = cmdDatabase.ExecuteReader();
                        MessageBox.Show("Gebruiker aangemaakt!");
                        tbPass.Clear();
                        tbUser.Clear();
                        tbMail.Clear();
                        while (myReader.Read())
                        {

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Vergeet natuurlijk niet je eigen gegevens te verzinnen.");
                }
            }
            else
            {
                MessageBox.Show("Vul bij zowel gebruikersnaam als wachtwoord minimaal 8 tekens in.");
            }

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            

            try
            {
                if (!(tbUser2.Text == string.Empty))
                {
                    if (!(tbPass2.Password == string.Empty))
                    {
                        
                        string Query = "SELECT * FROM pokemon_db.users where Username = '" + tbUser2.Text + "'and Password = '" + tbPass2.Password + "'";
                        MySqlConnection con = new MySqlConnection(constring);
                        MySqlCommand cmd = new MySqlCommand(Query, con);
                        MySqlDataReader dbr;
                        con.Open();
                        dbr = cmd.ExecuteReader();
                        int count = 0;
                        while (dbr.Read())
                        {
                            count = count + 1;
                        }
                        if (count == 1)
                        {
                            MessageBox.Show("username and password is correct");
                        }
                        
                        else
                        {
                            MessageBox.Show(" username and password incorrect");
                        }
                    }
                    else
                    {
                        MessageBox.Show(" password empty");
                    }
                }

                else
                {
                    MessageBox.Show(" username empty", "login page");
                }

                

            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);

            }

        }
    }
}


