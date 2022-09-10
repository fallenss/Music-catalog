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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Курсилио
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Клубная_музыкаEntities dataEntities = new Клубная_музыкаEntities();
        public MainWindow()
        {
            InitializeComponent();
            Window_Loaded();
            DataContext = dataEntities;
            ComboGenre.SelectedIndex = 0;
            ComboRating.SelectedIndex = 0;
            var currentGames = Клубная_музыкаEntities.GetContext().Жанр.ToList();
            LViewGames.ItemsSource = currentGames;
        }
        private void Window_Loaded()
        {
            

        }




        private void LViewMusics_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (LViewGames.SelectedItem == null) return;
            Жанр в = LViewGames.SelectedItem as Жанр;
            info.id_game = в.ID_жанра;
                Music aboba = new Music(new Жанр
            {
                Название = в.Название,
                История = в.История,
                Рейтинг = в.Рейтинг,
                Звучание = в.Звучание,
                ID_инструмента = в.ID_инструмента,
                ID_исполнителя = в.ID_исполнителя,
                ID_композитора = в.ID_композитора,
                Популярность = в.Популярность,
                картинка = в.картинка,
                Количество_оценок = в.Количество_оценок,
                Дата_создания = в.Дата_создания,
            });
            aboba.ShowDialog();

        }

        private void Findless()
        {
            var abobus = Клубная_музыкаEntities.GetContext().Жанр.ToList();

            if (ComboRating.SelectedIndex > 0)
            {
                double rate = 0;
                switch (ComboRating.SelectedIndex)
                {
                    case 1:
                        {
                            rate = 1;
                        }
                        break;
                    case 2:
                        {
                            rate = 2;
                        }
                        break;
                    case 3:
                        {
                            rate = 3;
                        }
                        break;
                    case 4:
                        {
                            rate = 4;
                        }
                        break;
                    default:
                        rate = 0;
                        break;

                }
                abobus = abobus.Where(p => p.Рейтинг>rate).ToList();
            }

            if (ComboGenre.SelectedIndex > 0)
            {
                abobus = abobus.Where(p => p.Популярность.Contains(ComboGenre.Text)).ToList();
            }

            abobus = abobus.Where(p => p.Название.ToLower().Contains(Find.Text.ToLower())).ToList();

            abobus = abobus.Where(p => p.История.ToLower().Contains(Find_Copy.Text.ToLower())).ToList();

            LViewGames.ItemsSource = abobus;
        }

        private void Find_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Find.Text != "Поиск по названию:")
            {
                Findless();
            }
        }

        private void FindCopy_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Find_Copy.Text != "Поиск по продюсерам:")
            {
                Findless();
            }
        }

        private void ComboGenre_GotFocus(object sender, RoutedEventArgs e)
        {
            Findless();
        }

        private bool IsToggle;
        private void Find_GotFocus(object sender, RoutedEventArgs e)
        {
   
        }

        private void Find_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            if (!IsToggle)
            {
                Thickness margin = Find.Margin;
                margin.Right += 1300;
                this.Find.BeginAnimation(FrameworkElement.MarginProperty, new ThicknessAnimation(margin, TimeSpan.FromSeconds(0.10)));
                IsToggle = true;
            }
            else
            {
                Thickness margin = Find.Margin;
                margin.Right -= 1300;
                this.Find.BeginAnimation(FrameworkElement.MarginProperty, new ThicknessAnimation(margin, TimeSpan.FromSeconds(0.2)));
                IsToggle = false;
            }
        }

        private void ComboRating_GotFocus(object sender, RoutedEventArgs e)
        {
            Findless();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Вход abobus = new Вход();
            abobus.Show();
            Close();
        }

     
    }
}
