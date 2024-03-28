using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace Practica5
{
    public partial class GamesBuyWin : Window
    {
        private Steam_Entities steam = new Steam_Entities();
        public GamesBuyWin()
        {
            InitializeComponent();
            GamesTable.ItemsSource = steam.Games.ToList();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Games selectedgame = GamesTable.SelectedItem as Games;

            if (selectedgame != null)
            {
                BuyGame(selectedgame);
            }
            else
            {
                MessageBox.Show("Выберай игру", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BuyGame(Games game)
        {
            try
            {
                string check = GenerateCheck(game);

                SaveCheckToFile(check);

                MessageBox.Show("Все прошло четенька, гоняй в новуй игрульку");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибочка вышла");
            }
        }

        private string GenerateCheck(Games game)
        {
            string check = $"<Steam>\nКассовый чек №{game.ID_Game}\n\n{game.Name_Game} - {game.Price}\n\nИтог к оплате:{game.Price}\n";
            return check;
        }


        private void SaveCheckToFile(string check)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                Title = "Сохранить чек"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, check);
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            UserMain user = new UserMain();
            user.Show();
            this.Close();
        }
    }
}
