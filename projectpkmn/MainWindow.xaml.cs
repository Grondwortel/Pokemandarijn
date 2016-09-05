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
using System.IO;

namespace projectpkmn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string username, password;

        public MainWindow()
        {
            InitializeComponent();
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri("http://wallpapercave.com/wp/HolPrzE.jpg", UriKind.Absolute));
            this.Background = myBrush;
        }

        private void tbUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        // This will be the piece of code that makes us able to login.
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sr = new System.IO.StreamReader("C:\\" + tbRegUser.Text + "\\login.ID");
                username = sr.ReadLine();
                password = sr.ReadLine();
                sr.Close();

                if (username == tbUser.Text && password == tbPass.Text)
                {
                    
                    pickYourOption form_pickYourOption = new pickYourOption();
                    form_pickYourOption.Show();
                    
                }
                else
                    MessageBox.Show("This is not correct");

            }
            catch (System.IO.DirectoryNotFoundException )
            {
                MessageBox.Show("Alles gaat mis");
            }
        }

        // This will be the piece of code that will make us able to register.
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sw = new System.IO.StreamWriter("C:\\" + tbRegUser.Text + "\\login.ID");
                sw.Write(tbRegUser.Text + "\n" + tbRegPass.Text);               
                sw.Close();
            }
            catch (System.IO.DirectoryNotFoundException ) 
            {
                System.IO.Directory.CreateDirectory("C:\\" + tbRegUser.Text);
                var sw = new System.IO.StreamWriter("C:\\" + tbRegUser.Text + "\\login.ID");
                sw.Write(tbRegUser.Text + "\n" + tbRegPass.Text);
                sw.Close();
            }
        }

        // This opens a new form that helps us to recover a password.
        private void btnPassForgot_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
