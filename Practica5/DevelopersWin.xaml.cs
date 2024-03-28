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
    public partial class DevelopersWin : Window
    {
        private Steam_Entities steam = new Steam_Entities();
        public DevelopersWin()
        {
            InitializeComponent();
            DevelopersTable.ItemsSource = steam.Developers.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Developers table = new Developers();
            table.Name_Developer = NameDev.Text;
            
            steam.Developers.Add(table);

            steam.SaveChanges();
            DevelopersTable.ItemsSource = steam.Developers.ToList();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            var selected = DevelopersTable.SelectedItem as Developers;

            selected.Name_Developer = NameDev.Text;

            steam.SaveChanges();
            DevelopersTable.ItemsSource = steam.Developers.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            steam.Developers.Remove(DevelopersTable.SelectedItem as Developers);

            steam.SaveChanges();
            DevelopersTable.ItemsSource = steam.Developers.ToList();

        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminMain adm = new AdminMain();
            adm.Show();
            this.Close();
        }

        private void DevelopersTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DevelopersTable.SelectedItem != null && DevelopersTable.SelectedItem is Developers)
            {
                var seldev = DevelopersTable.SelectedItem as Developers;
                NameDev.Text = seldev.Name_Developer;
            }
        }
    }
}