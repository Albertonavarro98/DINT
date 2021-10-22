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

namespace Ahorcado
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Encoding ascii = Encoding.ASCII;
        Random random = new Random();
        string palabraadivinar;
        string[] caracterespalabra;
        int cuentaaciertos;
        double vidas;
        bool dificultadseleccionada;
        double dificultad;
        char error;
        int seleccion;
        Char[] letras = new Char[27];
        public String[] palabras = { "piedra", "casa", "agua", "ventana", "ordenador", "raton", "queso", "torre", "lunes", "martes", "miercoles", "jueves", "viernes", "sabado", "domingo" };
        public String[] pistas = { "está en el suelo", "se puede residir en ella", "cae 'a mares'", "ventana", "ordenador", "raton", "queso", "torre", "lunes", "martes", "miercoles", "jueves", "viernes", "sabado", "domingo" };

        public MainWindow()
        {
            InitializeComponent();
            IniciarPartida();
        }

        private void NuevaPartidaBoton_Click(object sender, RoutedEventArgs e)
        {
            IniciarPartida();
        }

        private void CaracterButton_Click(object sender, RoutedEventArgs e)
        {
            CompruebaCaracter((sender as Button).Tag.ToString());
        }

        public void ActualizaImagen()
        {
            imagen.Source = new BitmapImage(new Uri("/img/" + (11 - Math.Round(vidas)) + ".jpg", UriKind.RelativeOrAbsolute));
            if((11 - Math.Round(vidas)) > 10) imagen.Source = new BitmapImage(new Uri("/img/10.jpg", UriKind.RelativeOrAbsolute));
        }
        public void CrearBotones()
        {
            string tag;
            Button BotonCaracter;
            int c = 0, r = 0;
            for (int i = 0; i < 26; i++)
            {
                letras[i] = Convert.ToChar(65 + i);
                tag = letras[i] + "";
                BotonCaracter = new Button
                {
                    Content = tag,
                    Tag = tag,
                    Style = (Style)this.Resources["Teclas"],
                };
                if (i <= 8) { c = i; }
                else if (i > 8 && i <= 17) { r = 1; c = i - 9; }
                else if (i > 17) { r = 2; c = i - 18; }
                Grid.SetColumn(BotonCaracter, 9 - (9 - c));
                Grid.SetRow(BotonCaracter, r);
                contenedorbotones.Children.Add(BotonCaracter);
            }
            letras[26] = 'Ñ';
            BotonCaracter = new Button
            {
                Content = "Ñ",
                Tag = "Ñ",
                Style = (Style)this.Resources["Teclas"],
            };
            Grid.SetColumn(BotonCaracter, 8);
            Grid.SetRow(BotonCaracter, 2);
            contenedorbotones.Children.Add(BotonCaracter);
        }



        public void CompruebaCaracter(string entrada)
        {

            bool contiene = false;

            for (int i = 0; i < palabraadivinar.Length; i++)
            {
                try
                {

                    if (palabraadivinar[i] == char.Parse(entrada.ToLower())) { caracterespalabra[i] = entrada; contiene = true; ActualizaPalabra(); cuentaaciertos++; }
                    MarcaLetraUsada(entrada);
                }
                catch (Exception) { }
            }

            if (!contiene)
            {
                vidas = vidas - dificultad;
                if (vidas > 0)
                {
                    ActualizaImagen();
                }
                else { FinPartida(); }
            }
            if (cuentaaciertos == palabraadivinar.Length) { EjecutaVictoria(); }

        }
        public void MarcaLetraUsada(string entrada)
        {
            foreach (Button boton in contenedorbotones.Children)
            {
                if (boton.Tag.Equals(entrada.ToUpper()))
                {
                    boton.IsEnabled = false;
                }
            }
        }
        public void FinPartida()
        {
            SalidaTextBlock.Text = "Has perdido, pulsa reiniciar";
            Mensaje("Has perdido" + ", la palabra era: " + palabraadivinar);
            DesactivaTeclas();
        }
        public void DesactivaTeclas()
        {
            foreach (Button boton in contenedorbotones.Children)
            {
                boton.IsEnabled = false;
            }
        }
        public void ActivarTeclas()
        {
            foreach (Button boton in contenedorbotones.Children)
            {
                boton.IsEnabled = true;
            }
        }
        public void EjecutaVictoria()
        {
            SalidaTextBlock.Text = "ENHORABUENAA!!";
            foreach (Button boton in contenedorbotones.Children)
            {
                boton.Content = ":)";
                boton.IsEnabled = false;
            }
            Mensaje("Muy bien!, lo has conseguido!!");
            imagen.Source = new BitmapImage(new Uri("/img/0.jpg", UriKind.RelativeOrAbsolute));
        }
        public void ActualizaPalabra()
        {
            SalidaTextBlock.Text = "";
            for (int i = 0; i < caracterespalabra.Length; i++)
            {
                SalidaTextBlock.Text = SalidaTextBlock.Text + " " + caracterespalabra[i];
            }
        }
        public void IniciarPartida()
        {
            vidas = 11;
            cuentaaciertos = 0;
            MostrarDificultad();
            ActualizaImagen();
            CrearBotones();
            DesactivaTeclas();
            seleccion = random.Next(0, palabras.Length);
            palabraadivinar = palabras[seleccion];
            SalidaTextBlock.Text = "";
            caracterespalabra = new string[palabraadivinar.Length];
            for (int i = 0; i < palabraadivinar.Length; i++)
            {
                caracterespalabra[i] = "_";
            }
            ActualizaPalabra();
        }


        private void Ahorcado_KeyDown(object sender, KeyEventArgs e)
        {
            CompruebaCaracter(e.Key.ToString());
        }

        private void DificultadButton_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Tag.ToString())
            {
                case "Facil":
                    dificultad = 1;
                    dificultadseleccionada = true;
                    ActivarTeclas();
                    EsconderDificultad();
                    break;
                case "Medio":
                    dificultad = 1.5;
                    dificultadseleccionada = true;
                    ActivarTeclas();
                    EsconderDificultad();
                    break;
                case "Dificil":
                    dificultad = 2;
                    dificultadseleccionada = true;
                    ActivarTeclas();
                    EsconderDificultad();
                    break;
            }
        }
        public void EsconderDificultad()
        {
            foreach (Button boton in ContenedorDificultades.Children)
            {
                boton.IsEnabled = false;
                boton.Visibility = Visibility.Hidden;
            }
        }
        public void MostrarDificultad()
        {
            foreach (Button boton in ContenedorDificultades.Children)
            {
                boton.IsEnabled = true;
                boton.Visibility = Visibility.Visible;
            }
        }
        public void Mensaje(string mensaje)
        {
            MessageBoxResult result = MessageBox.Show(mensaje + ". Te gustaría reintentarlo?", "Ahorcado", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    IniciarPartida();
                    break;
                case MessageBoxResult.No:
                    Close();
                    break;
                case MessageBoxResult.Cancel:
                    
                    break;
            }
        }

        private void RendirseButton_Click(object sender, RoutedEventArgs e)
        {
            EsconderDificultad();
            FinPartida();
        }

        private void PistaButton_Click(object sender, RoutedEventArgs e)
        {
            string pista = pistas[seleccion];
            MessageBox.Show("Hello, world!", "My App");
        }
    }
}
