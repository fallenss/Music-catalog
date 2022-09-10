using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Курсилио
{
    static class info
    {
        public static string name { get; set; }
        public static string password { get; set; }
        public static string report { get; set; }
        public static int id_user { get; set; }
        public static int id_game { get; set; }
    }
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
    }
}
