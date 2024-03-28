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
    public partial class DiscountsWin : Window
    {
        private Steam_Entities steam = new Steam_Entities();
        public DiscountsWin()
        {
            InitializeComponent();
            DiscountsTable.ItemsSource = steam.Discounts.ToList();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Discounts table = new Discounts();
            table.Percentage_Discount = Convert.ToDecimal(Percentage.Text);
            table.Discount_Start_Date = Start.Text;
            table.Discount_End_Date = End.Text;

            steam.Discounts.Add(table);

            steam.SaveChanges();
            DiscountsTable.ItemsSource = steam.Discounts.ToList();
        }
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            var selected = DiscountsTable.SelectedItem as Discounts;

            selected.Percentage_Discount = Convert.ToDecimal(Percentage.Text);
            selected.Discount_Start_Date = Start.Text;
            selected.Discount_End_Date = End.Text;

            steam.SaveChanges();
            DiscountsTable.ItemsSource = steam.Discounts.ToList();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            steam.Discounts.Remove(DiscountsTable.SelectedItem as Discounts);

            steam.SaveChanges();
            DiscountsTable.ItemsSource = steam.Discounts.ToList();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminMain adm = new AdminMain();
            adm.Show();
            this.Close();
        }

        private void DiscountsTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DiscountsTable.SelectedItem != null && DiscountsTable.SelectedItem is Discounts)
            {
                var sel = DiscountsTable.SelectedItem as Discounts;
                Percentage.Text = sel.Percentage_Discount.ToString();
                Start.Text = sel.Discount_Start_Date;
                End.Text = sel.Discount_End_Date;
            }
        }
    }
}
