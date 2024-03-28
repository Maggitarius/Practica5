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

namespace Practica5
{
    public partial class MainWindow : Window
    {
        private Steam_Entities steam = new Steam_Entities();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = Login1.Text;
            var password = Password1.Password;
            if (login == "admin" && password == "987654321")
            {
                AdminMain adminMain = new AdminMain();
                adminMain.Show();
                this.Close();
            }
            else if (login == "user" && password == "123456789")
            {
                UserMain userMain = new UserMain(); 
                userMain.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ты лох, введи нормально!");
            }
        }
    }
}