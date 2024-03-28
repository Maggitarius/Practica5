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
    public partial class ReviewsWin : Window
    {
        private Steam_Entities steam = new Steam_Entities();
        public ReviewsWin()
        {
            InitializeComponent();
            ReviewsTable.ItemsSource = steam.Reviews.ToList();
            GameComboBox.ItemsSource = steam.Games.ToList();
            GameComboBox.DisplayMemberPath = "Name_Game";
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Reviews table = new Reviews();
            table.Estimation = Convert.ToInt32(EstimationR.Text);
            table.Text_Review = Text_Review.Text;
            table.Game_ID = (GameComboBox.SelectedItem as Games).ID_Game;

            steam.Reviews.Add(table);

            steam.SaveChanges();
            ReviewsTable.ItemsSource = steam.Reviews.ToList();
        }
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            var selected = ReviewsTable.SelectedItem as Reviews;
            selected.Estimation = Convert.ToInt32(EstimationR.Text);
            selected.Text_Review = Text_Review.Text;
            selected.Game_ID = (GameComboBox.SelectedItem as Games).ID_Game;

            steam.SaveChanges();
            ReviewsTable.ItemsSource = steam.Reviews.ToList();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            steam.Reviews.Remove(ReviewsTable.SelectedItem as Reviews);

            steam.SaveChanges();
            ReviewsTable.ItemsSource = steam.Reviews.ToList();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminMain adm = new AdminMain();
            adm.Show();
            this.Close();
        }

        private void ReviewsTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReviewsTable.SelectedItem != null && ReviewsTable.SelectedItem is Reviews)
            {
                var seldev = ReviewsTable.SelectedItem as Reviews;
                EstimationR.Text = seldev.Estimation.ToString();
                Text_Review.Text = seldev.Text_Review;
            }
        }
    }
}
