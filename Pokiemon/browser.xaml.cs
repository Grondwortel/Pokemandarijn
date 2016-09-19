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
using System.Windows.Shapes;

namespace Pokiemon
{
    /// <summary>
    /// Interaction logic for browser.xaml
    /// </summary>
    public partial class browser : Window
    {
        public browser()
        {
            InitializeComponent();
            this.webBrowser.Navigate("file:///C:/Users/leonn/Desktop/phplogin/index.html");
        }
    }
}
