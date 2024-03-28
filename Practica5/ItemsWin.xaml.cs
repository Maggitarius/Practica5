using System;
using System.Collections;
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
    public partial class ItemsWin : Window
    {
        private Steam_Entities steam = new Steam_Entities();
        public ItemsWin()
        {
            InitializeComponent();
            ItemsTable.ItemsSource = steam.Items.ToList();
            GameComboBox.ItemsSource = steam.Games.ToList();
            GameComboBox.DisplayMemberPath = "Name_Game";
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Items table = new Items();
            table.Name_Item = NameI.Text;
            table.Type_Item = TypeI.Text;
            table.Price = Convert.ToDecimal(Price.Text);
            table.Game_ID = (GameComboBox.SelectedItem as Games).ID_Game;

            steam.Items.Add(table);

            steam.SaveChanges();
            ItemsTable.ItemsSource = steam.Items.ToList();
        }
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            var selected = ItemsTable.SelectedItem as Items;
            selected.Name_Item = NameI.Text;
            selected.Type_Item = TypeI.Text;
            selected.Price = Convert.ToDecimal(Price.Text);
            selected.Game_ID = (GameComboBox.SelectedItem as Games).ID_Game;

            steam.SaveChanges();
            ItemsTable.ItemsSource = steam.Items.ToList();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            steam.Items.Remove(ItemsTable.SelectedItem as Items);

            steam.SaveChanges();
            ItemsTable.ItemsSource = steam.Items.ToList();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminMain adm = new AdminMain();
            adm.Show();
            this.Close();
        }

        private void ItemsTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ItemsTable.SelectedItem != null && ItemsTable.SelectedItem is Items)
            {
                var sel = ItemsTable.SelectedItem as Items;
                NameI.Text = sel.Name_Item;
                TypeI.Text = sel.Type_Item;
                Price.Text = sel.Price.ToString();
            }
        }
    }
}
