using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Xml.Linq;

namespace Practica5
{
    public partial class AccountGameWin : Window
    {
        private Steam_Entities steam = new Steam_Entities();
        public AccountGameWin()
        {
            InitializeComponent();
            AccountGameTable.ItemsSource = steam.Account_Game.ToList();
            AccountComboBox.ItemsSource = steam.Account.ToList();
            AccountComboBox.DisplayMemberPath = "Name_Account";
            GamesComboBox.ItemsSource = steam.Games.ToList();
            GamesComboBox.DisplayMemberPath = "Name_Game";
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Account_Game table = new Account_Game();
            table.Account_ID = (AccountComboBox.SelectedItem as Account).ID_Account;
            table.Game_ID = (GamesComboBox.SelectedItem as Games).ID_Game;

            steam.Account_Game.Add(table);

            steam.SaveChanges();
            AccountGameTable.ItemsSource = steam.Account_Game.ToList();
        }
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            var selected = AccountGameTable.SelectedItem as Account_Game;
            selected.Account_ID = (AccountComboBox.SelectedItem as Account).ID_Account;
            selected.Game_ID = (GamesComboBox.SelectedItem as Games).ID_Game;

            steam.SaveChanges();
            AccountGameTable.ItemsSource = steam.Account_Game.ToList();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            steam.Account_Game.Remove(AccountGameTable.SelectedItem as Account_Game);

            steam.SaveChanges();
            AccountGameTable.ItemsSource = steam.Account_Game.ToList();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminMain adm = new AdminMain();
            adm.Show();
            this.Close();
        }
    }
}