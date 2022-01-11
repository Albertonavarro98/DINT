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

namespace Peliculas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowVM vm = new MainWindowVM();
        public MainWindow()
        {
            InitializeComponent(); 
            this.DataContext = vm;
        }

        private void ButtonFlechaAtras_Click(object sender, RoutedEventArgs e)
        {
            vm.Retroceder();
            VisibilidadCheckBox.IsChecked = false;
        }
        private void ButtonFlechaAlante_Click(object sender, RoutedEventArgs e)
        {
            vm.Avanzar();
            VisibilidadCheckBox.IsChecked = false;
        }

        private void ComprobarButton_Click(object sender, RoutedEventArgs e)
        {
            int sumador = 2;
            if ((bool)VisibilidadCheckBox.IsChecked) { sumador = 1; }

            bool acertada = false;
            foreach (Pelicula peli in vm.PartidaActual.PeliculasAcertadas) 
            {
                if (peli.Titulo == EntradaText.Text) { 
                    acertada = true;
                    if (vm.PeliculaActual.Titulo.Equals(EntradaText.Text)) { MessageBox.Show("Esa película ya ha sido introducida", "Juego Peliculas"); } 
                }
            }
            if (vm.PeliculaActual.Titulo.Equals(EntradaText.Text) && !acertada)
            {
                vm.IncrementarPuntuacion(sumador);
                vm.PartidaActual.PeliculasAcertadas.Add(vm.PeliculaActual);
            }
            else 
            {
                MessageBox.Show("Error, no es correcta la respuesta", "Juego Peliculas");
            }
        }

        private void CargarJSONButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                vm.Importar();
            }
            catch (Exception) { MessageBox.Show("Error al importar JSON", "Juego Peliculas"); }
        }

        private void GuardarJSONButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                vm.Guardar();
            }
            catch (Exception) { MessageBox.Show("Error al Guardar", "Juego Peliculas"); }
        }

        private void AñadirPeliculaButton_Click(object sender, RoutedEventArgs e)
        {
            try {

                Pelicula pelinueva = new Pelicula();
                vm.Peliculas.Add(pelinueva);
                vm.PeliSeleccionada = pelinueva;
            }
            catch (Exception) { MessageBox.Show("Error en la película introducida", "Juego Peliculas"); }
        }

        private void EditarPeliNueva(Pelicula pelinueva)
        {
            bool existe = false;
            foreach (Pelicula peli in vm.Peliculas)
            {
                if (peli.Titulo.Equals(TituloTB.Text) && peli.Pista.Equals(PistaTB.Text) && peli.Cartel.Equals(ImagenTB.Text) && peli.Nivel.Equals(DificultadCB.SelectedItem.ToString()) && peli.Genero.Equals(GeneroTB.SelectedItem.ToString()))
                {
                    MessageBox.Show("Esa pelicula ya existe", "Juego Peliculas");
                    existe = true;
                    vm.Peliculas.Remove(pelinueva);
                }
            }
            if (!existe)
            {
                vm.Peliculas.Add(new Pelicula(TituloTB.Text, PistaTB.Text, ImagenTB.Text, DificultadCB.SelectedItem.ToString(), GeneroTB.SelectedItem.ToString()));
            }
        }

        private void EditarPeliculaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                vm.Peliculas.Add(new Pelicula(TituloTB.Text, PistaTB.Text, ImagenTB.Text, DificultadCB.SelectedItem.ToString(), GeneroTB.SelectedItem.ToString()));
                vm.Peliculas.Remove(vm.PeliSeleccionada);
            }
            catch (Exception) { MessageBox.Show("Elemento no seleccionado", "Juego Peliculas"); }
        }

        private void EliminarPeliculaButton_Click(object sender, RoutedEventArgs e)
        {
            vm.Peliculas.Remove(vm.PeliSeleccionada);
        }

        private void ExaminarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                vm.Importar();
            }
            catch (Exception) { MessageBox.Show("Error al importar", "Juego Peliculas"); }
        }
    }
}
