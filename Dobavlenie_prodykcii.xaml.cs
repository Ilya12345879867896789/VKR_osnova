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
    /// Логика взаимодействия для Dobavlenie_prodykcii.xaml
    /// </summary>
    public partial class Dobavlenie_prodykcii : Window
    {
        public Gotovaya_prodykcia gotovaya_Prodykcia { get; set; }
        bool isAdd = false;
        public Dobavlenie_prodykcii(Gotovaya_prodykcia gotovaya_Prodykcia)
        {
            InitializeComponent();
            this.gotovaya_Prodykcia = gotovaya_Prodykcia;
            DataContext = gotovaya_Prodykcia;
        }
        public Dobavlenie_prodykcii()
        {
            InitializeComponent();
            isAdd = true;
           gotovaya_Prodykcia = new Gotovaya_prodykcia();
            DataContext = gotovaya_Prodykcia;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isAdd == true)
                    DataBase.GetContext().Gotovaya_prodykcia.Add(gotovaya_Prodykcia);
                DataBase.GetContext().SaveChanges();
                (this.Owner as WindowProdykcii).Update();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // Добавление продукции
    }
}
