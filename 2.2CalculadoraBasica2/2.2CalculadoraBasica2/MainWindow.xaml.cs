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

namespace _2._2CalculadoraBasica2
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
        private void Calcular_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                switch (char.Parse(operador.Text))
                {
                    case '+':
                        resultado.Text = "" + (int.Parse(operando1.Text) + int.Parse(operando2.Text));
                        break;
                    case '*':
                        resultado.Text = "" + (int.Parse(operando1.Text) * int.Parse(operando2.Text));
                        break;
                    case 'x':
                        resultado.Text = "" + (int.Parse(operando1.Text) * int.Parse(operando2.Text));
                        break;
                    default:
                        resultado.Text = "Operador no esperado";
                        break;
                }
            }
            catch (Exception)
            {
                resultado.Text = "Valor en un campo no esperado";
            }
        }
        private void Limpiar_Click(object sender, RoutedEventArgs e)
        {
            resultado.Clear();
            operando2.Clear();
            operando1.Clear();
            operador.Clear();
        }
        private void Introducir_Operador(object sender, RoutedEventArgs e)
        {
            try 
            {
                    if (char.Parse(operador.Text) == '+' || char.Parse(operador.Text) == '*' || char.Parse(operador.Text) == 'x') { calcular.IsEnabled = true; }
                    else { calcular.IsEnabled = false; 
            } 
            } catch(Exception) { calcular.IsEnabled = false; }
            
            
        }
    }
}
