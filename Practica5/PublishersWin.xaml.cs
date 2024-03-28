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
    public partial class PublishersWin : Window
    {
        private Steam_Entities steam = new Steam_Entities();
        public PublishersWin()
        {
            InitializeComponent();
            PublisherTable.ItemsSource = steam.Publishers.ToList();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Publishers table = new Publishers();
            table.Name_Publisher = NamePub.Text;

            steam.Publishers.Add(table);

            steam.SaveChanges();
            PublisherTable.ItemsSource = steam.Publishers.ToList();
        }
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            var selected = PublisherTable.SelectedItem as Publishers;

            selected.Name_Publisher = NamePub.Text;

            steam.SaveChanges();
            PublisherTable.ItemsSource = steam.Publishers.ToList();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            steam.Publishers.Remove(PublisherTable.SelectedItem as Publishers);

            steam.SaveChanges();
            PublisherTable.ItemsSource = steam.Publishers.ToList();

        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminMain adm = new AdminMain();
            adm.Show();
            this.Close();
        }

        private void PublisherTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PublisherTable.SelectedItem != null && PublisherTable.SelectedItem is Publishers)
            {
                var seldev = PublisherTable.SelectedItem as Publishers;
                NamePub.Text = seldev.Name_Publisher;
            }
        }
    }
}