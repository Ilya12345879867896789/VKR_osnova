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
    /// Логика взаимодействия для WindowMaterialov.xaml
    /// </summary>
    public partial class WindowMaterialov : Window
    {
        private Sotrydniki Sotrydniki;
        public WindowMaterialov(Sotrydniki sotrydniki) //Отображение фамили имени и отчества входящего
        {
            InitializeComponent();
            this.Sotrydniki = sotrydniki;
            Familia.Content = sotrydniki.Familia;
            Ima.Content = sotrydniki.Ima;
            Otchestvo.Content = sotrydniki.Otchestvo;
            UpdateData();
        }
        public void UpdateData()
        {
            DataBase.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            List<Materiali> materialis = DataBase.GetContext().Materiali.ToList(); //Отоброжение 
            if (!String.IsNullOrWhiteSpace(poisk.Text)) //Поиск
            {
                materialis = materialis.Where(p => p.Pliti_drevestno_sryjechnie.Contains(poisk.Text) || p.MDF.Contains(poisk.Text) || p.DVP.Contains(poisk.Text) || p.Oblicovanniy_shpon.Contains(poisk.Text)).ToList();
            }
            switch (Sortirovka.SelectedIndex) //Сортировка
            {
                case 0:
                    materialis = materialis.OrderBy(p => p.Massiv_drevisini).ToList();
                    break;
                case 1:
                    materialis = materialis.OrderByDescending(p => p.Massiv_drevisini).ToList();
                    break;
                case 2:
                    materialis = materialis.OrderBy(p => p.Pliti_drevestno_sryjechnie).ToList();
                    break;
                case 3:
                    materialis = materialis.OrderByDescending(p => p.Pliti_drevestno_sryjechnie).ToList();
                    break;
            }
            ListMateriala.ItemsSource = materialis;
        }

        private void poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void Sortirovka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void product_Click(object sender, RoutedEventArgs e)
        {
            WindowProdykcii windowProdykcii = new WindowProdykcii();
            windowProdykcii.Show();
            this.Close();
        }

        private void Vihod_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Del_Click(object sender, RoutedEventArgs e) //Удаление
        {
            if (ListMateriala.SelectedItems.Count != 0) // проверка, выделен ли элемент в списке
            {
                List<Materiali> materialis = ListMateriala.SelectedItems.OfType<Materiali>().ToList();
                MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хоите удалить?", "Удаление", MessageBoxButton.YesNoCancel);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    DataBase.GetContext().Materiali.RemoveRange(materialis);
                    DataBase.GetContext().SaveChanges();
                    UpdateData();
                }

            }
        }

        private void Dobav_Click(object sender, RoutedEventArgs e)
        {
            DobavlenieMateriala addUpdateForm = new DobavlenieMateriala();
            addUpdateForm.Owner = this;
            addUpdateForm.Show();
        }

        private void Redact_Click(object sender, RoutedEventArgs e)//Редактирование
        {
            if (ListMateriala.SelectedItem != null)
            {
                DobavlenieMateriala addUpdateForm = new DobavlenieMateriala(ListMateriala.SelectedItem as Materiali);
                addUpdateForm.Owner = this;
                addUpdateForm.Show();
            }
        }

        private void Filtr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }
        //IQueryable<Materiali> materialis = DataBase.GetContext().Materiali;
        //DobavlenieMateriala addUpdateForm = new DobavlenieMateriala(materialis.First());
    }
}
