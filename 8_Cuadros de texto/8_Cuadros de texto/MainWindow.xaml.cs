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

namespace _8_Cuadros_de_texto
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

        
        private void NombreApellidoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "f1" && (sender as RadioButton).Tag.ToString() == "NombreTextBox")
            {
                NombreLabel.Visibility = Visibility.Visible;
            }

            if (e.Key.ToString() == "f1" && (sender as RadioButton).Tag.ToString() == "ApellidoTextBox")
            {
                ApellidoLabel.Visibility = Visibility.Visible;
            }
        }

        private void EdadTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "f2")
            {
                if((EdadTextBox.Text).)
                else { NombreLabel.Visibility = Visibility.Visible; }

            }
        }
    }
}
