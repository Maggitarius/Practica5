using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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
using System.Xml.Linq;
using System.Xml;

namespace Practica5
{
    public partial class AccountWin : Window
    {
        private Steam_Entities steam = new Steam_Entities();
        public AccountWin()
        {
            InitializeComponent();
            AccountTable.ItemsSource = steam.Account.ToList();
            ReviewComboBox.ItemsSource = steam.Reviews.ToList();
            ReviewComboBox.DisplayMemberPath = "Text_Review";
            AutComboBox.ItemsSource = steam.Authorization_Table.ToList();
            AutComboBox.DisplayMemberPath = "Login_Authorization";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Account table = new Account();
            table.Name_Account = NameA.Text;
            table.Email = EmailA.Text;
            table.Registration_Date = RegistrationA.Text;
            table.Review_ID = (ReviewComboBox.SelectedItem as Reviews).ID_Review;
            table.Authorization_ID = (AutComboBox.SelectedItem as Authorization_Table).ID_Authorization;

            steam.Account.Add(table);

            steam.SaveChanges();
            AccountTable.ItemsSource = steam.Account.ToList();
        }
        private void Change_Click(object sender, RoutedEventArgs e)
        {
                var selected = AccountTable.SelectedItem as Account;

                selected.Name_Account = NameA.Text;
                selected.Email = EmailA.Text;
                selected.Registration_Date = RegistrationA.Text;
                selected.Review_ID = (ReviewComboBox.SelectedItem as Reviews).ID_Review;
                selected.Authorization_ID = (AutComboBox.SelectedItem as Authorization_Table).ID_Authorization;

                steam.SaveChanges();
                AccountTable.ItemsSource = steam.Account.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            steam.Account.Remove(AccountTable.SelectedItem as Account);

            steam.SaveChanges();
            AccountTable.ItemsSource = steam.Account.ToList();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminMain adm = new AdminMain();
            adm.Show();
            this.Close();
        }

        private void AccountTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AccountTable.SelectedItem != null && AccountTable.SelectedItem is Account)
            {
                var selacc = AccountTable.SelectedItem as Account;
                NameA.Text = selacc.Name_Account;
                EmailA.Text = selacc.Email;
                RegistrationA.Text = selacc.Registration_Date;
            }
        }
    }
}
