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

namespace _2._1.AdivinaNumero
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int numeroadivinar;
        Random rand = new Random();

        public MainWindow()
        {
            InitializeComponent();
            numeroadivinar = rand.Next(0,100);
        }

        private void comprobar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.Parse(entrada.Text) == numeroadivinar) { resultado.Text = "Enhorabuena, lo has adivinado"; }
                else if (int.Parse(entrada.Text) < numeroadivinar) { resultado.Text = "Error, el númeor es mayor"; }
                else if (int.Parse(entrada.Text) > numeroadivinar) { resultado.Text = "Error, el númnero es menor"; }
            }
            catch (Exception)
            {
                resultado.Text = "Error, formato no esperado";
            }
            
        }
        private void reiniciar_Click(object sender, RoutedEventArgs e)
        {
            numeroadivinar = rand.Next(0, 100);
        }
    }
}
