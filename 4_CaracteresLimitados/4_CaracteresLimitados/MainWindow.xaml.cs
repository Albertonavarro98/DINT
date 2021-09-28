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

/*
 El número máximo de caracteres será 140.
• Cuando se haya alcanzado el máximo de caracteres el usuario ya no podrá
editar el texto.
• El cuadro de texto debe permitir saltos de línea.
 
 
 */
namespace _4_CaracteresLimitados
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

        private void EntradaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EntradaTextBox.MaxLength = 140;
            if (EntradaTextBox.Text.Length == 140)
            {
                EntradaTextBox.IsReadOnly = true;
            }
            else { EntradaTextBox.IsReadOnly = false; }
            CantidadCaracteresLabel.Content = EntradaTextBox.Text.Length + "/140  ";
        }
    }
}
