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

namespace Курсилио
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();
            Gridetsky.ItemsSource = Клубная_музыкаEntities.GetContext().Жанр.ToList();
            a1.ItemsSource = Клубная_музыкаEntities.GetContext().Исполнители.ToList();
            a2.ItemsSource = Клубная_музыкаEntities.GetContext().Композиторы.ToList();
            a3.ItemsSource = Клубная_музыкаEntities.GetContext().Инструменты.ToList();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            var a = Gridetsky.SelectedItems.Cast<Жанр>().ToList();
            Клубная_музыкаEntities.GetContext().Жанр.AddRange(a);
            Клубная_музыкаEntities.GetContext().SaveChanges();
            Gridetsky.ItemsSource = Клубная_музыкаEntities.GetContext().Жанр.ToList();
        }

        private void red_Click(object sender, RoutedEventArgs e)
        {
            Gridetsky.SelectedItems.Cast<Жанр>().ToList();
            Клубная_музыкаEntities.GetContext().SaveChanges();
            Gridetsky.ItemsSource = Клубная_музыкаEntities.GetContext().Жанр.ToList();
        }

        private void smert_Click(object sender, RoutedEventArgs e)
        {
            var a = Gridetsky.SelectedItems.Cast<Жанр>().ToList();
            Клубная_музыкаEntities.GetContext().Жанр.RemoveRange(a);
            Клубная_музыкаEntities.GetContext().SaveChanges();
            Gridetsky.ItemsSource = Клубная_музыкаEntities.GetContext().Жанр.ToList();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Вход a = new Вход();
            a.Show();
            Close();
        }

        private void rep_user_Click(object sender, RoutedEventArgs e)
        {
            Report a = new Report();
            a.ShowDialog();
        }

        private void rep_game_Click(object sender, RoutedEventArgs e)
        {
            Report1 b = new Report1();
            b.Show();
        }
    }
}
