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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sklad_mebeli
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Vhod_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(login.Text))
            {
                if (!String.IsNullOrEmpty(password.Password))
                {
                    IQueryable<Avtorizacia> avtorizacias = DataBase.GetContext().Avtorizacia.Where(p => p.Login == login.Text && p.Parol == password.Password);
                    if (avtorizacias.Count() == 1)
                    {
                        MessageBox.Show("Добро пожаловать!");
                        IQueryable<Sotrydniki> sotrydnikis = DataBase.GetContext().Sotrydniki;
                        WindowMaterialov windowMaterialov = new WindowMaterialov(sotrydnikis.First());
                        windowMaterialov.Show();
                        this.Close();
                    }
                    else MessageBox.Show("Неверный логин или пароль!");
                }
            }
        }
    }
}
