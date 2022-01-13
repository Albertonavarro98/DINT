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

namespace MultiventanaPractica1
{
    /// <summary>
    /// Lógica de interacción para Hija1.xaml
    /// </summary>
    public partial class Hija1 : Window
    {
        private HijaVM hvm;
        public Hija1()
        {
            InitializeComponent();
            hvm = new HijaVM();
            this.DataContext = hvm;
        }

        private void AceptarButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
