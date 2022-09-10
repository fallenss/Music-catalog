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

namespace Курсилио
{
    

    /// <summary>
    /// Логика взаимодействия для Вход.xaml
    /// </summary>
    public partial class Вход : Window
    {
        public Вход()
        {
            InitializeComponent();

        }

        private void nic_TextChanged(object sender, TextChangedEventArgs e)
        {

        }




        private void pas_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        private void vhod_Click(object sender, RoutedEventArgs e)
        {
            bool temp = false;
            if (nic.Text == "" | pas.Password == "")
            {
                nic.ToolTip = "Нормально впиши";
                pas.ToolTip = "Нормально впиши";
            }
            else
            {
                bool res = false;
                
                
                foreach (var item in Клубная_музыкаEntities.GetContext().Пользователи) //Берёт все строки из таблицы Пользователи
                {
                    if (item.Никнейм == nic.Text & item.Пароль == pas.Password) // Ищет совпадения с текстбоксом и строкой в бд
                    {
                        res = true;
                    }
                    
                    if (res == true) //Если оба совпадают открывает основную форму (Info это статик класс для передачи инфы между формами, необязателен)
                    {
                        temp = true;
                        MainWindow mainWindow = new MainWindow();
                        info.name = nic.Text;
                        info.password = pas.Password;
                        info.id_user = item.ID;
                        mainWindow.Show();
                        Close();
                        break;
                    }
                }
                if (temp != true) //Проверка на фальшифку
                {
                    MessageBox.Show("Никнейм или пароль неверные, повтори попытку.", "Ошибка!");
                }
                

            }
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            if (nic.Text == "" | pas.Password == "")
            {
                
                reg.ToolTip = "Нормально впиши логин и пароль.";
            }
            else
            {
                bool res = true;
                
                Пользователи Новичёк = new Пользователи // Создаёт новый объект таблицы бд Пользователи
                {
                    Никнейм = nic.Text,
                    Пароль = pas.Password,
                };
                foreach (var item in Клубная_музыкаEntities.GetContext().Пользователи)
                {
                    if (item.Никнейм == nic.Text)
                    {
                        res = false;
                    }
                   
                    if (res == false )
                    {
                        MessageBox.Show("Никнейм занят, выбирай другой", "Ошибка!");
                        break;
                    }
                }
                if (res == true)
                {
                    Клубная_музыкаEntities.GetContext().Пользователи.Add(Новичёк); //Добавляет новую строку в таблицу Пользователи
                    Клубная_музыкаEntities.GetContext().SaveChanges(); //Оно и ясно
                    MessageBox.Show("Регистрация успешно завершена, авторизуйся.", "Успешно!");
                }
                

            }
        }

        private void pas_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AdminLog_Click(object sender, RoutedEventArgs e)
        {
            if (nic.Text == "" | pas.Password == "")
            {
                nic.ToolTip = "Нормально впиши";
                pas.ToolTip = "Нормально впиши";
            }

            if (nic.Text == "admin" & nic.Text == "admin")
            {
                AdminPanel adminpanel = new AdminPanel();
                adminpanel.Show();
                Close();
            }
        }
    }
}
