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
    public partial class TagsWin : Window
    {
        private Steam_Entities steam = new Steam_Entities();
        public TagsWin()
        {
            InitializeComponent();
            TagsTable.ItemsSource = steam.Tags.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Tags table = new Tags();
            table.Name_Tag = NameTag.Text;

            steam.Tags.Add(table);

            steam.SaveChanges();
            TagsTable.ItemsSource = steam.Tags.ToList();
        }
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            var selected = TagsTable.SelectedItem as Tags;

            selected.Name_Tag = NameTag.Text;

            steam.SaveChanges();
            TagsTable.ItemsSource = steam.Tags.ToList();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            steam.Tags.Remove(TagsTable.SelectedItem as Tags);

            steam.SaveChanges();
            TagsTable.ItemsSource = steam.Tags.ToList();

        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminMain adm = new AdminMain();
            adm.Show();
            this.Close();
        }

        private void TagsTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TagsTable.SelectedItem != null && TagsTable.SelectedItem is Tags)
            {
                var seldev = TagsTable.SelectedItem as Tags;
                NameTag.Text = seldev.Name_Tag;
            }
        }
    }
}
