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

namespace _4_TextoFormato
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
            SalidaTextBlock.Text = EntradaTextBox.Text;
        }

        private void NegritaCheck_Checked(object sender, RoutedEventArgs e) => SalidaTextBlock.FontWeight = FontWeights.Bold;

        private void CursivaCheck_Checked(object sender, RoutedEventArgs e) => SalidaTextBlock.FontStyle = FontStyles.Italic;

        private void ColoresRadio(object sender, RoutedEventArgs e)
        {
            if (VerdeRadioButton.IsChecked == true) { SalidaTextBlock.Foreground = Brushes.Green; }
            else if (RojoRadioButton.IsChecked == true) { SalidaTextBlock.Foreground = Brushes.Red; }
            if (AzulRadioButton.IsChecked == true) { SalidaTextBlock.Foreground = Brushes.Blue; }
        }
    }
}
