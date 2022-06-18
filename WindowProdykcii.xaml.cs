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

namespace Sklad_mebeli
{
    /// <summary>
    /// Логика взаимодействия для WindowProdykcii.xaml
    /// </summary>
    public partial class WindowProdykcii : Window
    {
        public WindowProdykcii()
        {
            InitializeComponent();
            Update();
        }
        public void Update()
        {
            DataBase.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            List<Gotovaya_prodykcia> gotovaya_Prodykcias = DataBase.GetContext().Gotovaya_prodykcia.ToList();
            if (!String.IsNullOrWhiteSpace(poisk.Text))
                gotovaya_Prodykcias = gotovaya_Prodykcias.Where(p => p.Nazvanie.Contains(poisk.Text) || p.Shirina.Contains(poisk.Text)).ToList();
            switch (Sortirovka.SelectedIndex)
            {
                case 0:
                    gotovaya_Prodykcias = gotovaya_Prodykcias.OrderBy(p => p.Nazvanie).ToList();
                    break;
                case 1:
                    gotovaya_Prodykcias = gotovaya_Prodykcias.OrderByDescending(p => p.Nazvanie).ToList();
                    break;
                case 2:
                    gotovaya_Prodykcias = gotovaya_Prodykcias.OrderBy(p => p.Shirina).ToList();
                    break;
                case 3:
                    gotovaya_Prodykcias = gotovaya_Prodykcias.OrderByDescending(p => p.Shirina).ToList();
                    break; //Сортировка
            }
            listBox.ItemsSource = gotovaya_Prodykcias;
        }


        private void poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void Sortirovka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItems.Count != 0) // проверка, выделен ли элемент в списке
            {
                List<Gotovaya_prodykcia> gotovaya_Prodykcias = listBox.SelectedItems.OfType<Gotovaya_prodykcia>().ToList();
                MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хоите удалить?", "Удаление", MessageBoxButton.YesNoCancel);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    DataBase.GetContext().Gotovaya_prodykcia.RemoveRange(gotovaya_Prodykcias);
                    DataBase.GetContext().SaveChanges();
                    Update();
                }
            }
        } 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dobavlenie_prodykcii addUpdateForm = new Dobavlenie_prodykcii();
            addUpdateForm.Owner = this;
            addUpdateForm.Show();
        } 

        private void Redactirovanie_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                Dobavlenie_prodykcii addUpdateForm = new Dobavlenie_prodykcii(listBox.SelectedItem as Gotovaya_prodykcia);
                addUpdateForm.Owner = this;
                addUpdateForm.Show();
            }
        } // Переход на окно добавления/редактирования

        private void Назад_Click(object sender, RoutedEventArgs e)
        {
            IQueryable<Sotrydniki> sotrydnikis = DataBase.GetContext().Sotrydniki;
            WindowMaterialov addUpdateForm = new WindowMaterialov(sotrydnikis.First());
            addUpdateForm.Owner = this;
            addUpdateForm.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            QR_code window = new QR_code(but.Tag);
            window.Show();
        }
    }
}
