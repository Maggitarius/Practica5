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
    public partial class NewUserWin : Window
    {
        private Steam_Entities steam = new Steam_Entities();
        public NewUserWin()
        {
            InitializeComponent();
            AuthorizationTable.ItemsSource = steam.Authorization_Table.ToList();
            RoleComboBox.ItemsSource = steam.Roles.ToList();
            RoleComboBox.DisplayMemberPath = "Name_Role";
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Authorization_Table table = new Authorization_Table();
            table.Login_Authorization = Login.Text;
            table.Password_Authorization = Password.Text;
            table.Role_ID = (RoleComboBox.SelectedItem as Roles).ID_Role;

            steam.Authorization_Table.Add(table);

            steam.SaveChanges();
            AuthorizationTable.ItemsSource = steam.Authorization_Table.ToList();
        }
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            var selected = AuthorizationTable.SelectedItem as Authorization_Table;
            selected.Login_Authorization = Login.Text;
            selected.Password_Authorization = Password.Text;
            selected.Role_ID = (RoleComboBox.SelectedItem as Roles).ID_Role;

            steam.SaveChanges();
            AuthorizationTable.ItemsSource = steam.Authorization_Table.ToList();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            steam.Authorization_Table.Remove(AuthorizationTable.SelectedItem as Authorization_Table);

            steam.SaveChanges();
            AuthorizationTable.ItemsSource = steam.Authorization_Table.ToList();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminMain adm = new AdminMain();
            adm.Show();
            this.Close();
        }
    }
}
