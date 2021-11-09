using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Superheroes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int posicion=0;
        static List<Superheroe> superheroes = Superheroe.GetSamples();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = superheroes[posicion];
            PosicionActualLabel.Content = posicion+1;
        }

        private void ButtonFlechaAtras_Click(object sender, RoutedEventArgs e)
        {
            if (posicion > 0) { posicion--; }
            PosicionActualLabel.Content = posicion+1;
            DataContext = superheroes[posicion];
        }
        private void ButtonFlechaAlante_Click(object sender, RoutedEventArgs e)
        {
            if (posicion >= 0 && posicion < 2) { posicion++; }
            PosicionActualLabel.Content = posicion+1;
            DataContext = superheroes[posicion];
        }
       

    }
   
}
  
        