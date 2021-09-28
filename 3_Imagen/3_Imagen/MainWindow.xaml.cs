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

namespace _3_Imagen
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void OpacidadAltaRadioButton_Checked(object sender, RoutedEventArgs e) => Imagen1.Opacity = 1;
        

        private void OpacidadMediaRadioButton_Checked(object sender, RoutedEventArgs e) => Imagen1.Opacity = 0.5;
        

        private void OpacidadBajaRadioButton_Checked(object sender, RoutedEventArgs e)=> Imagen1.Opacity = 0.10;
        

        private void RellenoAjusteCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Imagen1.Height = 375;
            Imagen1.Width = 550;
        }

        private void UniformeAjusteCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Imagen1.Height = 375;
            Imagen1.Width = 250;
        }

        private void RellenoUniformeAjusteCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Imagen1.Height = 750;
            Imagen1.Width = 550;
        }

        private void SinAjusteCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Imagen1.Height = 580;
            Imagen1.Width = 874;
        }
    }
}
