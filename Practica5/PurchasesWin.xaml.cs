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
    public partial class PurchasesWin : Window
    {
        private Steam_Entities steam = new Steam_Entities();
        public PurchasesWin()
        {
            InitializeComponent();
            PurchasesTable.ItemsSource = steam.Purchases.ToList();
            AccountComboBox.ItemsSource = steam.Account.ToList();
            AccountComboBox.DisplayMemberPath = "Name_Account";
            GamesComboBox.ItemsSource = steam.Games.ToList();
            GamesComboBox.DisplayMemberPath = "Name_Game";
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Purchases table = new Purchases();
            table.Account_ID = (AccountComboBox.SelectedItem as Account).ID_Account;
            table.Game_ID = (GamesComboBox.SelectedItem as Games).ID_Game;

            steam.Purchases.Add(table);

            steam.SaveChanges();
            PurchasesTable.ItemsSource = steam.Purchases.ToList();
        }
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            var selected = PurchasesTable.SelectedItem as Account_Game;
            selected.Account_ID = (AccountComboBox.SelectedItem as Account).ID_Account;
            selected.Game_ID = (GamesComboBox.SelectedItem as Games).ID_Game;

            steam.SaveChanges();
            PurchasesTable.ItemsSource = steam.Purchases.ToList();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            steam.Account_Game.Remove(PurchasesTable.SelectedItem as Account_Game);

            steam.SaveChanges();
            PurchasesTable.ItemsSource = steam.Purchases.ToList();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminMain adm = new AdminMain();
            adm.Show();
            this.Close();
        }
    }
}
