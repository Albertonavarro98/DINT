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

                switch (char.Parse(operadorTextBox.Text))
                {
                    case '+':
                        resultadoTextBox.Text = "" + (int.Parse(operando1TextBox.Text) + int.Parse(operando2TextBox.Text));
                        break;
                    case '*':
                        resultadoTextBox.Text = "" + (int.Parse(operando1TextBox.Text) * int.Parse(operando2TextBox.Text));
                        break;
                    case 'x':
                        resultadoTextBox.Text = "" + (int.Parse(operando1TextBox.Text) * int.Parse(operando2TextBox.Text));
                        break;
                    default:
                        resultadoTextBox.Text = "Operador no esperado";
                        break;
                }
            }
            catch (Exception)
            {
                resultadoTextBox.Text = "Valor en un campo no esperado";
            }
        }
        private void Limpiar_Click(object sender, RoutedEventArgs e)
        {
            resultadoTextBox.Clear();
            operando2TextBox.Clear();
            operando1TextBox.Clear();
            operadorTextBox.Clear();
        }
        private void Introducir_Operador(object sender, RoutedEventArgs e)
        {
            try 
            {
                    if (char.Parse(operadorTextBox.Text) == '+' || char.Parse(operadorTextBox.Text) == '*' || char.Parse(operadorTextBox.Text) == 'x') { calcular.IsEnabled = true; }
                    else { calcular.IsEnabled = false; 
            } 
            } catch(Exception) { calcular.IsEnabled = false; }
            
            
        }
    }
}
