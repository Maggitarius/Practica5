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

namespace Practica5
{
    public partial class UserMain : Window
    {
        public UserMain()
        {
            InitializeComponent();
        }
        private void GamesBuy_Click(object sender, RoutedEventArgs e)
        {
            GamesBuyWin gamesBuyWin = new GamesBuyWin();
            gamesBuyWin.Show();
            this.Close();
        }
    }
}
