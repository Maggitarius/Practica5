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
    public partial class GamesWin : Window
    {
        private Steam_Entities steam = new Steam_Entities();
        public GamesWin()
        {
            InitializeComponent();
            GamesTable.ItemsSource = steam.Games.ToList();
            DevelopersComboBox.ItemsSource = steam.Developers.ToList();
            DevelopersComboBox.DisplayMemberPath = "Name_Developer";
            PublishersComboBox.ItemsSource = steam.Publishers.ToList();
            PublishersComboBox.DisplayMemberPath = "Name_Publisher";
            TagsComboBox.ItemsSource = steam.Tags.ToList();
            TagsComboBox.DisplayMemberPath = "Name_Tag";
            DiscountsComboBox.ItemsSource = steam.Discounts.ToList();
            DiscountsComboBox.DisplayMemberPath = "Percentage_Discount";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Games table = new Games();
            table.Name_Game = NameG.Text;
            table.Realise_date = Realise.Text;
            table.Description_Game = Description.Text;
            table.Price = Convert.ToDecimal(Price.Text);
            table.Developer_ID = (DevelopersComboBox.SelectedItem as Developers).ID_Developer;
            table.Publisher_ID = (PublishersComboBox.SelectedItem as Publishers).ID_Publisher;
            table.Tag_ID = (TagsComboBox.SelectedItem as Tags).ID_Tag;
            table.Discount_ID = (DiscountsComboBox.SelectedItem as Discounts).ID_Discount;

            steam.Games.Add(table);

            steam.SaveChanges();
            GamesTable.ItemsSource = steam.Games.ToList();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            var selected = GamesTable.SelectedItem as Games;

            selected.Name_Game = NameG.Text;
            selected.Realise_date = Realise.Text;
            selected.Description_Game = Description.Text;
            selected.Price = Convert.ToDecimal(Price.Text);
            selected.Developer_ID = (DevelopersComboBox.SelectedItem as Developers).ID_Developer;
            selected.Publisher_ID = (PublishersComboBox.SelectedItem as Publishers).ID_Publisher;
            selected.Tag_ID = (TagsComboBox.SelectedItem as Tags).ID_Tag;
            selected.Discount_ID = (DiscountsComboBox.SelectedItem as Discounts).ID_Discount;

            steam.SaveChanges();
            GamesTable.ItemsSource = steam.Games.ToList();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            steam.Games.Remove(GamesTable.SelectedItem as Games);

            steam.SaveChanges();
            GamesTable.ItemsSource = steam.Games.ToList();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminMain adm = new AdminMain();
            adm.Show();
            this.Close();
        }

        private void GamesTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GamesTable.SelectedItem != null && GamesTable.SelectedItem is Games) 
            {
                var selgame = GamesTable.SelectedItem as Games;
                NameG.Text = selgame.Name_Game;
                Realise.Text = selgame.Realise_date;
                Description.Text = selgame.Description_Game;
                Price.Text = selgame.Price.ToString();
            }
        }
    }
}
