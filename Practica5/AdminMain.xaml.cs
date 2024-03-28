using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    public partial class AdminMain : Window
    {
        private Steam_Entities steam = new Steam_Entities();
        public AdminMain()
        {
            InitializeComponent();
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            AccountWin account = new AccountWin();
            account.Show();
            this.Close();
        }

        private void AccountGameWin_Click(object sender, RoutedEventArgs e)
        {
            AccountGameWin accountGameWin = new AccountGameWin();
            accountGameWin.Show();
            this.Close();
        }

        private void Games_Click(object sender, RoutedEventArgs e)
        {
            GamesWin games = new GamesWin();
            games.Show();
            this.Close();
        }

        private void DevelopersWin_Click(object sender, RoutedEventArgs e)
        {
            DevelopersWin developersWin = new DevelopersWin();
            developersWin.Show();
            this.Close();
        }

        private void PublishersWin_Click(object sender, RoutedEventArgs e)
        {
            PublishersWin publishersWin = new PublishersWin();  
            publishersWin.Show();
            this.Close();
        }

        private void TagsWin_Click(object sender, RoutedEventArgs e)
        {
            TagsWin tagsWin = new TagsWin();
            tagsWin.Show();
            this.Close();
        }

        private void ItemsWin_Click(object sender, RoutedEventArgs e)
        {
            ItemsWin itemsWin = new ItemsWin();
            itemsWin.Show();
            this.Close();
        }

        private void DiscountsWin_Click(object sender, RoutedEventArgs e)
        {
            DiscountsWin dis = new DiscountsWin();
            dis.Show();
            this.Close();
        }

        private void ReviewsWin_Click(object sender, RoutedEventArgs e)
        {
            ReviewsWin reviewsWin = new ReviewsWin();  
            reviewsWin.Show();
            this.Close();
        }

        private void PurchasesWin_Click(object sender, RoutedEventArgs e)
        {
            PurchasesWin pur = new PurchasesWin();
            pur.Show();
            this.Close();
        }

        private void TradingPlatformWin_Click(object sender, RoutedEventArgs e)
        {
            TradingPlatformWin tradingPlatformWin = new TradingPlatformWin();
            tradingPlatformWin.Show();
            this.Close();
        }

        private void NewUser_Click(object sender, RoutedEventArgs e)
        {
            NewUserWin newUserWin = new NewUserWin();
            newUserWin.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(steam.Database.Connection.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("BackupSteamDatabase", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Резервная копия базы данных успешно создана.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании резервной копии базы данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
