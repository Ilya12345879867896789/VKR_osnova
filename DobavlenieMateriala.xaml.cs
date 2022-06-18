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
    /// Логика взаимодействия для DobavlenieMateriala.xaml
    /// </summary>
    public partial class DobavlenieMateriala : Window
    {
        public Materiali materiali { get; set; }
        bool isAdd = false;
        public DobavlenieMateriala(Materiali materiali)
        {
            InitializeComponent();
            this.materiali = materiali;
            DataContext = materiali;
        }

        public DobavlenieMateriala()
        {
            InitializeComponent();
            isAdd = true;
            materiali = new Materiali();
            DataContext = materiali;
        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isAdd == true)
                    DataBase.GetContext().Materiali.Add(materiali);
                DataBase.GetContext().SaveChanges();
                (this.Owner as WindowMaterialov).UpdateData(); 
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
