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
using System.Windows.Threading;

namespace Курсилио
{
    /// <summary>
    /// Логика взаимодействия для Music.xaml
    /// </summary>
    public partial class Music : Window
    {
        bool play = false;
        Жанр жарик { get; set; }
        static bool a = false;
        DispatcherTimer timer = null;
        private MediaPlayer player = new MediaPlayer();
        public Music(Жанр p)
        {
            InitializeComponent();          
            жарик = p;
            this.DataContext = жарик; // заполнение всех полей
            foreach (var amogus in Клубная_музыкаEntities.GetContext().Композиторы)
            {
                if (amogus.ID_композитора == p.ID_композитора)
                {
                    komp.Text = "Композитор: " + amogus.Псевдоним_композитора;
                }
            }
            foreach (var amogus in Клубная_музыкаEntities.GetContext().Исполнители)
            {
                if (amogus.ID_исполнителя == p.ID_исполнителя)
                {
                    isp.Text = "Исполнитель: " +amogus.Псевдоним_исполнителя;
                }
            }
            foreach (var amogus in Клубная_музыкаEntities.GetContext().Инструменты)
            {
                if (amogus.ID_инструмента == p.ID_инструмента)
                {
                    instr.Text = "Инструмент: " +amogus.Наименование_инструмента;
                }
            }
            foreach (var amogus in Клубная_музыкаEntities.GetContext().лого) // подгрузка лого
            {
                if (amogus.id == p.картинка)
                {
                    MemoryStream mem = new MemoryStream(amogus.screen);
                    var bmp = new BitmapImage();
                    bmp.BeginInit();
                    bmp.CacheOption = BitmapCacheOption.OnLoad;
                    bmp.StreamSource = mem;
                    bmp.EndInit();
                    bmp.Freeze();
                    Logo.Source = bmp;
                }
            } 


            myMediaElement.Source = new Uri(@"D:\Archive\Illumination\3-4 круг\СКУбиДУ\Курсилиус\Курсилио\Курсилио\Tracks\" + p.Название + ".mp3");
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += timer_Tick;
            //timer.Start();
            
           //string put1 =  @"D:\Archive\Illumination\3 круг\СКУбиДУ\Курсилиус\Курсилио\Курсилио\Trailers\" + p.Название + ".mp3"; // трейлер, ну, утром, по крайней мере
            
            //Uri path1 = new Uri(put1);
            //myMediaElement.Source = path1;
            //myMediaElement.Play();

            foreach (var jitem in Клубная_музыкаEntities.GetContext().Оценённые) //Поиск оценки и закрашивание звёзд
            {
                if (jitem.Номер_Жанра == info.id_game & jitem.ID_Пользователя == info.id_user)
                {
                    if (jitem.Оценка == 1)
                    {
                        Jb1.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb2.Style = (Style)Application.Current.Resources["BigFree"];
                        Jb3.Style = (Style)Application.Current.Resources["BigFree"];
                        Jb4.Style = (Style)Application.Current.Resources["BigFree"];
                        Jb5.Style = (Style)Application.Current.Resources["BigFree"];
                    }
                    else if (jitem.Оценка == 2)
                    {
                        Jb1.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb2.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb3.Style = (Style)Application.Current.Resources["BigFree"];
                        Jb4.Style = (Style)Application.Current.Resources["BigFree"];
                        Jb5.Style = (Style)Application.Current.Resources["BigFree"];
                    }
                    else if (jitem.Оценка == 3)
                    {
                        Jb1.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb2.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb3.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb4.Style = (Style)Application.Current.Resources["BigFree"];
                        Jb5.Style = (Style)Application.Current.Resources["BigFree"];
                    }
                    else if (jitem.Оценка == 4)
                    {
                        Jb1.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb2.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb3.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb4.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb5.Style = (Style)Application.Current.Resources["BigFree"];
                    }
                    else if (jitem.Оценка == 5)
                    {
                        Jb1.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb2.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb3.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb4.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb5.Style = (Style)Application.Current.Resources["BigFull"];
                    }
                }
            }
        }


        void player_MediaFailed(object sender, ExceptionEventArgs e)
        {
            MessageBox.Show("Ошибка во время открытия файла.");
        }

        private void window_Closed(object sender, EventArgs e)
        {
            player.Close(); // При закрытии окна освобождаем объект MediaPlayer
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (myMediaElement.Source != null)
            {
                if (myMediaElement.NaturalDuration.HasTimeSpan)
                {
                    lblStatus.Content = String.Format("{0} / {1}", myMediaElement.Position.ToString(@"mm\:ss"), myMediaElement.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
                    timelineSlider.Value = myMediaElement.Position.TotalSeconds;
                }
            }
            else
                lblStatus.Content = "No file selected...";
        }


        //void OnMouseDownBackMedia(object sender, MouseButtonEventArgs args)
        //{
        //    TimeSpan ts = new TimeSpan(0, 0, 10);
        //    myMediaElement.Position -= ts;
        //}
        //void OnMouseDownSecondMedia(object sender, MouseButtonEventArgs args)
        //{
        //    TimeSpan ts = new TimeSpan(0, 0, 10);
        //    myMediaElement.Position += ts;
        //}

        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            myMediaElement.Volume = (double)volumeSlider.Value;
        }

      

        private void SeekToMediaPosition(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            myMediaElement.Position = TimeSpan.FromSeconds(timelineSlider.Value);
        }

        
        //private void media_MediaOpened(object sender, RoutedEventArgs e)
        //{
        //    timelineSlider.Value = myMediaElement.Position.TotalSeconds;          
        //}
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            player.MediaFailed += new EventHandler<ExceptionEventArgs>(player_MediaFailed);
            //player.Open(new Uri(@"D:\Right Version ♂ (Моя оборона).wav"));
            //player.Play(); // Метод Play не выбрасывает исключений, для отлова ошибок нужно делать обработчики на события
            StopStart((Button)e.OriginalSource);
            InitializePropertyValues();
        }
        void StopStart(Button buttom)
        {
            myMediaElement.Play();
            if (a != true)
            {
                myMediaElement.Play();
                buttom.Style = (Style)Application.Current.Resources["Stop"];
                a = true;
                timer.Start();
            }
            else
            {
                myMediaElement.Pause();
                buttom.Style = (Style)Application.Current.Resources["Start"];
                a = false;
                timer.Stop();
            }
        }
        void InitializePropertyValues()
        {
            myMediaElement.Volume = (double)volumeSlider.Value;
            // myMediaElement.SpeedRatio = 1;
        }
        //private void ComboBox_LostMouseCapture(object sender, MouseEventArgs e)
        //{
        //    myMediaElement.Pause();
        //    if (SpeedRotate.SelectedIndex == 0)
        //    {
        //        myMediaElement.SpeedRatio = 0.25;
        //    }
        //    if (SpeedRotate.SelectedIndex == 1)
        //    {
        //        myMediaElement.SpeedRatio = 0.5;
        //    }
        //    if (SpeedRotate.SelectedIndex == 2)
        //    {
        //        myMediaElement.SpeedRatio = 0.75;
        //    }
        //    if (SpeedRotate.SelectedIndex == 3)
        //    {
        //        myMediaElement.SpeedRatio = 1;
        //    }
        //    if (SpeedRotate.SelectedIndex == 4)
        //    {
        //        myMediaElement.SpeedRatio = 1.5;
        //    }
        //    if (SpeedRotate.SelectedIndex == 5)
        //    {
        //        myMediaElement.SpeedRatio = 2;
        //    }
        //    myMediaElement.Play();
        //}
        private void Element_MediaEnded(object sender, EventArgs e)
        {
            myMediaElement.Stop();
        }

        private void MyMediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (myMediaElement.NaturalDuration.HasTimeSpan)
            {
                timelineSlider.Maximum = myMediaElement.NaturalDuration.TimeSpan.TotalSeconds;
            }
        }
       
        private void Jb1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (((Button)e.OriginalSource).Content.ToString() == Convert.ToString(1))
            {
                Jb1.Style = (Style)Application.Current.Resources["BigFull"];
                Jb2.Style = (Style)Application.Current.Resources["BigFree"];
                Jb3.Style = (Style)Application.Current.Resources["BigFree"];
                Jb4.Style = (Style)Application.Current.Resources["BigFree"];
                Jb5.Style = (Style)Application.Current.Resources["BigFree"];
            }
            else if (((Button)e.OriginalSource).Content.ToString() == Convert.ToString(2))
            {
                Jb1.Style = (Style)Application.Current.Resources["BigFull"];
                Jb2.Style = (Style)Application.Current.Resources["BigFull"];
                Jb3.Style = (Style)Application.Current.Resources["BigFree"];
                Jb4.Style = (Style)Application.Current.Resources["BigFree"];
                Jb5.Style = (Style)Application.Current.Resources["BigFree"];
            }
            else if (((Button)e.OriginalSource).Content.ToString() == Convert.ToString(3))
            {
                Jb1.Style = (Style)Application.Current.Resources["BigFull"];
                Jb2.Style = (Style)Application.Current.Resources["BigFull"];
                Jb3.Style = (Style)Application.Current.Resources["BigFull"];
                Jb4.Style = (Style)Application.Current.Resources["BigFree"];
                Jb5.Style = (Style)Application.Current.Resources["BigFree"];
            }
            else if (((Button)e.OriginalSource).Content.ToString() == Convert.ToString(4))
            {
                Jb1.Style = (Style)Application.Current.Resources["BigFull"];
                Jb2.Style = (Style)Application.Current.Resources["BigFull"];
                Jb3.Style = (Style)Application.Current.Resources["BigFull"];
                Jb4.Style = (Style)Application.Current.Resources["BigFull"];
                Jb5.Style = (Style)Application.Current.Resources["BigFree"];
            }
            else if (((Button)e.OriginalSource).Content.ToString() == Convert.ToString(5))
            {
                Jb1.Style = (Style)Application.Current.Resources["BigFull"];
                Jb2.Style = (Style)Application.Current.Resources["BigFull"];
                Jb3.Style = (Style)Application.Current.Resources["BigFull"];
                Jb4.Style = (Style)Application.Current.Resources["BigFull"];
                Jb5.Style = (Style)Application.Current.Resources["BigFull"];
            }
        }

        private void Jb1_Click(object sender, RoutedEventArgs e)
        {
            bool res = true;


            Оценённые rate = new Оценённые
            {
                Номер_Жанра = info.id_game,
                ID_Пользователя = info.id_user,
                Оценка = 1,
            };
            foreach (var jitem in Клубная_музыкаEntities.GetContext().Оценённые)
            {
                if (jitem.Номер_Жанра == rate.Номер_Жанра & jitem.ID_Пользователя == rate.ID_Пользователя)
                {
                    jitem.Оценка = rate.Оценка;
                    res = false;
                }
            }

            if (res == false)
            {
                int rating = 0;
                foreach (var item in Клубная_музыкаEntities.GetContext().Оценённые)
                {
                    if (item.Номер_Жанра == rate.Номер_Жанра)
                    {
                        rating += item.Оценка;
                    }
                }
                double ratingTRUE = Convert.ToDouble(rating);
                foreach (var item in Клубная_музыкаEntities.GetContext().Жанр)
                {
                    if (item.ID_жанра == rate.Номер_Жанра)
                    {
                        item.Рейтинг = ratingTRUE / Convert.ToDouble(item.Количество_оценок);
                        ra.Text = Convert.ToString(Math.Round(item.Рейтинг, 1));
                        ko.Text = Convert.ToString(item.Количество_оценок);
                        break;
                    }
                }
                MessageBox.Show("1Оценка отредактирована...", "Успешно!");
            }

            if (res == true)
            {
                Клубная_музыкаEntities.GetContext().Оценённые.Add(rate);
                int rating = 0;
                foreach (var item in Клубная_музыкаEntities.GetContext().Оценённые)
                {
                    if (item.Номер_Жанра == rate.Номер_Жанра)
                    {
                        rating += item.Оценка;
                    }
                }
                double ratingTRUE = Convert.ToDouble(rating);
                ratingTRUE += rate.Оценка;
                foreach (var item in Клубная_музыкаEntities.GetContext().Жанр)
                {
                    if (item.ID_жанра == rate.Номер_Жанра)
                    {
                        item.Рейтинг = ratingTRUE / (++item.Количество_оценок);
                        ra.Text = Convert.ToString(Math.Round(item.Рейтинг, 1));
                        ko.Text = Convert.ToString(item.Количество_оценок);
                        break;
                    }
                }
                MessageBox.Show("Спасибо за оценку!", "Успешно!");
            }
            Клубная_музыкаEntities.GetContext().SaveChanges();
        }

        private void Jb2_Click(object sender, RoutedEventArgs e)
        {
            bool res = true;


            Оценённые rate = new Оценённые
            {
                Номер_Жанра = info.id_game,
                ID_Пользователя = info.id_user,
                Оценка = 2,
            };
            foreach (var jitem in Клубная_музыкаEntities.GetContext().Оценённые)
            {
                if (jitem.Номер_Жанра == rate.Номер_Жанра & jitem.ID_Пользователя == rate.ID_Пользователя)
                {
                    jitem.Оценка = rate.Оценка;
                    res = false;
                }
            }

            if (res == false)
            {
                int rating = 0;
                foreach (var item in Клубная_музыкаEntities.GetContext().Оценённые)
                {
                    if (item.Номер_Жанра == rate.Номер_Жанра)
                    {
                        rating += item.Оценка;
                    }
                }
                double ratingTRUE = Convert.ToDouble(rating);
                foreach (var item in Клубная_музыкаEntities.GetContext().Жанр)
                {
                    if (item.ID_жанра == rate.Номер_Жанра)
                    {
                        item.Рейтинг = ratingTRUE / Convert.ToDouble(item.Количество_оценок);
                        ra.Text = Convert.ToString(Math.Round(item.Рейтинг, 1));
                        ko.Text = Convert.ToString(item.Количество_оценок);
                        break;
                    }
                }
                MessageBox.Show("2Оценка отредактирована...", "Успешно!");
            }

            if (res == true)
            {
                Клубная_музыкаEntities.GetContext().Оценённые.Add(rate);
                int rating = 0;
                foreach (var item in Клубная_музыкаEntities.GetContext().Оценённые)
                {
                    if (item.Номер_Жанра == rate.Номер_Жанра)
                    {
                        rating += item.Оценка;
                    }
                }
                double ratingTRUE = Convert.ToDouble(rating);
                ratingTRUE += rate.Оценка;
                foreach (var item in Клубная_музыкаEntities.GetContext().Жанр)
                {
                    if (item.ID_жанра == rate.Номер_Жанра)
                    {
                        item.Рейтинг = ratingTRUE / (++item.Количество_оценок);
                        ra.Text = Convert.ToString(Math.Round(item.Рейтинг, 1));
                        ko.Text = Convert.ToString(item.Количество_оценок);
                        break;
                    }
                }
                MessageBox.Show("Спасибо за оценку!", "Успешно!");
            }
            Клубная_музыкаEntities.GetContext().SaveChanges();
        }

        private void Jb3_Click(object sender, RoutedEventArgs e)
        {
            bool res = true;


            Оценённые rate = new Оценённые
            {
                Номер_Жанра = info.id_game,
                ID_Пользователя = info.id_user,
                Оценка = 3,
            };
            foreach (var jitem in Клубная_музыкаEntities.GetContext().Оценённые)
            {
                if (jitem.Номер_Жанра == rate.Номер_Жанра & jitem.ID_Пользователя == rate.ID_Пользователя)
                {
                    jitem.Оценка = rate.Оценка;
                    res = false;
                }
            }

            if (res == false)
            {
                int rating = 0;
                foreach (var item in Клубная_музыкаEntities.GetContext().Оценённые)
                {
                    if (item.Номер_Жанра == rate.Номер_Жанра)
                    {
                        rating += item.Оценка;
                    }
                }
                double ratingTRUE = Convert.ToDouble(rating);
                foreach (var item in Клубная_музыкаEntities.GetContext().Жанр)
                {
                    if (item.ID_жанра == rate.Номер_Жанра)
                    {
                        item.Рейтинг = ratingTRUE / Convert.ToDouble(item.Количество_оценок);
                        ra.Text = Convert.ToString(Math.Round(item.Рейтинг, 1));
                        ko.Text = Convert.ToString(item.Количество_оценок);
                        break;
                    }
                }
                MessageBox.Show("2Оценка отредактирована...", "Успешно!");
            }

            if (res == true)
            {
                Клубная_музыкаEntities.GetContext().Оценённые.Add(rate);
                int rating = 0;
                foreach (var item in Клубная_музыкаEntities.GetContext().Оценённые)
                {
                    if (item.Номер_Жанра == rate.Номер_Жанра)
                    {
                        rating += item.Оценка;
                    }
                }
                double ratingTRUE = Convert.ToDouble(rating);
                ratingTRUE += rate.Оценка;
                foreach (var item in Клубная_музыкаEntities.GetContext().Жанр)
                {
                    if (item.ID_жанра == rate.Номер_Жанра)
                    {
                        item.Рейтинг = ratingTRUE / (++item.Количество_оценок);
                        ra.Text = Convert.ToString(Math.Round(item.Рейтинг, 1));
                        ko.Text = Convert.ToString(item.Количество_оценок);
                        break;
                    }
                }
                MessageBox.Show("Спасибо за оценку!", "Успешно!");
            }
            Клубная_музыкаEntities.GetContext().SaveChanges();
        }

        private void Jb4_Click(object sender, RoutedEventArgs e)
        {
            bool res = true;


            Оценённые rate = new Оценённые
            {
                Номер_Жанра = info.id_game,
                ID_Пользователя = info.id_user,
                Оценка = 4,
            };
            foreach (var jitem in Клубная_музыкаEntities.GetContext().Оценённые)
            {
                if (jitem.Номер_Жанра == rate.Номер_Жанра & jitem.ID_Пользователя == rate.ID_Пользователя)
                {
                    jitem.Оценка = rate.Оценка;
                    res = false;
                }
            }

            if (res == false)
            {
                int rating = 0;
                foreach (var item in Клубная_музыкаEntities.GetContext().Оценённые)
                {
                    if (item.Номер_Жанра == rate.Номер_Жанра)
                    {
                        rating += item.Оценка;
                    }
                }
                double ratingTRUE = Convert.ToDouble(rating);
                foreach (var item in Клубная_музыкаEntities.GetContext().Жанр)
                {
                    if (item.ID_жанра == rate.Номер_Жанра)
                    {
                        item.Рейтинг = ratingTRUE / Convert.ToDouble(item.Количество_оценок);
                        ra.Text = Convert.ToString(Math.Round(item.Рейтинг, 1));
                        ko.Text = Convert.ToString(item.Количество_оценок);
                        break;
                    }
                }
                MessageBox.Show("2Оценка отредактирована...", "Успешно!");
            }

            if (res == true)
            {
                Клубная_музыкаEntities.GetContext().Оценённые.Add(rate);
                int rating = 0;
                foreach (var item in Клубная_музыкаEntities.GetContext().Оценённые)
                {
                    if (item.Номер_Жанра == rate.Номер_Жанра)
                    {
                        rating += item.Оценка;
                    }
                }
                double ratingTRUE = Convert.ToDouble(rating);
                ratingTRUE += rate.Оценка;
                foreach (var item in Клубная_музыкаEntities.GetContext().Жанр)
                {
                    if (item.ID_жанра == rate.Номер_Жанра)
                    {
                        item.Рейтинг = ratingTRUE / (++item.Количество_оценок);
                        ra.Text = Convert.ToString(Math.Round(item.Рейтинг, 1));
                        ko.Text = Convert.ToString(item.Количество_оценок);
                        break;
                    }
                }
                MessageBox.Show("Спасибо за оценку!", "Успешно!");
            }
            Клубная_музыкаEntities.GetContext().SaveChanges();
        }

        private void Jb5_Click(object sender, RoutedEventArgs e)
        {
            bool res = true;


            Оценённые rate = new Оценённые
            {
                Номер_Жанра = info.id_game,
                ID_Пользователя = info.id_user,
                Оценка = 5,
            };
            foreach (var jitem in Клубная_музыкаEntities.GetContext().Оценённые)
            {
                if (jitem.Номер_Жанра == rate.Номер_Жанра & jitem.ID_Пользователя == rate.ID_Пользователя)
                {
                    jitem.Оценка = rate.Оценка;
                    res = false;
                }
            }

            if (res == false)
            {
                int rating = 0;
                foreach (var item in Клубная_музыкаEntities.GetContext().Оценённые)
                {
                    if (item.Номер_Жанра == rate.Номер_Жанра)
                    {
                        rating += item.Оценка;
                    }
                }
                double ratingTRUE = Convert.ToDouble(rating);
                foreach (var item in Клубная_музыкаEntities.GetContext().Жанр)
                {
                    if (item.ID_жанра == rate.Номер_Жанра)
                    {
                        item.Рейтинг = ratingTRUE / Convert.ToDouble(item.Количество_оценок);
                        ra.Text = Convert.ToString(Math.Round(item.Рейтинг, 1));
                        ko.Text = Convert.ToString(item.Количество_оценок);
                        break;
                    }
                }
                MessageBox.Show("Оценка отредактирована...", "Успешно!");
            }

            if (res == true)
            {
                Клубная_музыкаEntities.GetContext().Оценённые.Add(rate);
                int rating = 0;
                foreach (var item in Клубная_музыкаEntities.GetContext().Оценённые)
                {
                    if (item.Номер_Жанра == rate.Номер_Жанра)
                    {
                        rating += item.Оценка;
                    }
                }
                double ratingTRUE = Convert.ToDouble(rating);
                ratingTRUE += rate.Оценка;
                foreach (var item in Клубная_музыкаEntities.GetContext().Жанр)
                {
                    if (item.ID_жанра == rate.Номер_Жанра)
                    {
                        item.Рейтинг = ratingTRUE / (++item.Количество_оценок);
                        ra.Text = Convert.ToString(Math.Round(item.Рейтинг, 1));
                        ko.Text = Convert.ToString(item.Количество_оценок);
                        break;
                    }
                }
                MessageBox.Show("Спасибо за оценку!", "Успешно!");
            }
            Клубная_музыкаEntities.GetContext().SaveChanges();
        }
    }
}
