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
    public partial class TradingPlatformWin : Window
    {
        private Steam_Entities steam = new Steam_Entities();
        public TradingPlatformWin()
        {
            InitializeComponent();
            TradingPlatformTable.ItemsSource = steam.Trading_Platform.ToList();
            ItemsComboBox.ItemsSource = steam.Items.ToList();
            ItemsComboBox.DisplayMemberPath = "Name_Item";
            SellerComboBox.ItemsSource = steam.Account.ToList();
            SellerComboBox.DisplayMemberPath = "Name_Account";
            CustomerComboBox.ItemsSource = steam.Account.ToList();
            CustomerComboBox.DisplayMemberPath = "Name_Account";
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Trading_Platform table = new Trading_Platform();
            table.Price = Convert.ToInt32(Price.Text);
            table.Item_ID = (ItemsComboBox.SelectedItem as Items).ID_Item;
            table.Seller_ID = (SellerComboBox.SelectedItem as Account).ID_Account;
            table.Customer_ID = (CustomerComboBox.SelectedItem as Account).ID_Account;

            steam.Trading_Platform.Add(table);

            steam.SaveChanges();
            TradingPlatformTable.ItemsSource = steam.Trading_Platform.ToList();
        }
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            var selected = TradingPlatformTable.SelectedItem as Trading_Platform;
            selected.Price = Convert.ToInt32(Price.Text);
            selected.Item_ID = (ItemsComboBox.SelectedItem as Items).ID_Item;
            selected.Seller_ID = (SellerComboBox.SelectedItem as Account).ID_Account;
            selected.Customer_ID = (CustomerComboBox.SelectedItem as Account).ID_Account;

            steam.SaveChanges();
            TradingPlatformTable.ItemsSource = steam.Trading_Platform.ToList();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            steam.Trading_Platform.Remove(TradingPlatformTable.SelectedItem as Trading_Platform);

            steam.SaveChanges();
            TradingPlatformTable.ItemsSource = steam.Trading_Platform.ToList();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminMain adm = new AdminMain();
            adm.Show();
            this.Close();
        }

        private void TradingPlatformTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TradingPlatformTable.SelectedItem != null && TradingPlatformTable.SelectedItem is Trading_Platform)
            {
                var seldev = TradingPlatformTable.SelectedItem as Trading_Platform;
                Price.Text = seldev.Price.ToString();
            }
        }
    }
}
