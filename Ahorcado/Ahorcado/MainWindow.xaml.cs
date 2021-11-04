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
        string palabraadivinar;
        string[] caracterespalabra;
        int cuentaaciertos;
        double vidas;
        double dificultad;
        int seleccion;
        string usadas;
        bool dificultadseleccionada;
        private string[] palabras = { "piedra", "castaña", "casa", "agua", "ventana", "ordenador", "raton", "queso", "torre", "lunes", "martes", "miercoles", "jueves", "viernes", "sabado", "domingo" };
        private string[] pistas = { "está en el suelo", "La clase de AD de hoy", "se puede residir en ella", "en el mar hay mucha", "normalmente tiene un marco y un vidrio", "equipo informático", "periférico y animal", "alimento lácteo", "parte de un ordenador o estructura vertical", "dia de la semana odiado por un gato naranja", "dia de la semana con nombre de un planeta", "día que siempre está enmedio", "verdadero día de enmedio", "dia más esperado", "penúltimo día", "dia de hacer el vago" };

        public MainWindow()
        {
            InitializeComponent();
            IniciarPartida();
            NuevaPartidaBoton.IsEnabled = false;
        }

        private void NuevaPartidaBoton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Quieres reiniciar la partida?", "Ahorcado", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    IniciarPartida();
                    NuevaPartidaBoton.IsEnabled = false;
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void CaracterButton_Click(object sender, RoutedEventArgs e)
        {
            if (dificultadseleccionada) CompruebaCaracter((sender as Button).Tag.ToString());
        }

        public void ActualizaImagen()
        {
            imagen.Source = new BitmapImage(new Uri("/img/" + (11 - Math.Round(vidas)) + ".jpg", UriKind.RelativeOrAbsolute));
        }
        public void CrearBotones()
        {
            string tag;
            Button BotonCaracter;
            int c = 0, r = 0;
            for (int i = 0; i < 26; i++)
            {
                tag = Convert.ToChar(65 + i).ToString();
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
            try
            {
                for (int i = 0; i < palabraadivinar.Length; i++)
                {

                    if (palabraadivinar[i] == char.Parse(entrada.ToLower()) && !usadas.Contains(entrada)) { caracterespalabra[i] = entrada; contiene = true; ActualizaPalabra(); cuentaaciertos++; }
                    MarcaLetraUsada(entrada);

                }
            }catch (Exception) { MessageBox.Show("Has introducido un carácter erróneo", "Ahorcado", MessageBoxButton.OKCancel); vidas--; }

            if (!contiene)
            {
                vidas = vidas - dificultad;
                if (vidas > 1)
                {
                    ActualizaImagen();
                }
                else { FinPartida(); }
            }
            else usadas = usadas + entrada;
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
            imagen.Source = new BitmapImage(new Uri("/img/10.jpg", UriKind.RelativeOrAbsolute));
            rendirsebutotn.IsEnabled = false;
            pistabutton.IsEnabled = false;
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
            rendirsebutotn.IsEnabled = true;
            NuevaPartidaBoton.IsEnabled = true;
            foreach (Button boton in contenedorbotones.Children)
            {
                boton.IsEnabled = true;
            }
        }
        public void EjecutaVictoria()
        {
            rendirsebutotn.IsEnabled = false;
            pistabutton.IsEnabled = false;
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
            try
            {
                SalidaTextBlock.Text = "";
                for (int i = 0; i < caracterespalabra.Length; i++)
                {
                    SalidaTextBlock.Text = SalidaTextBlock.Text + " " + caracterespalabra[i];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Has introducido un carácter erróneo", "Ahorcado", MessageBoxButton.OKCancel);
            }

        }
        public void IniciarPartida()
        {
            rendirsebutotn.IsEnabled = false;
            pistabutton.IsEnabled = false;
            Random random = new Random();
            usadas = "";
            vidas = 11;
            cuentaaciertos = 0;
            dificultadseleccionada = false;
            SalidaTextBlock.Visibility = Visibility.Hidden;
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
            try
            {
                if (dificultadseleccionada)
                {
                    if (e.Key == Key.Oem3) CompruebaCaracter("Ñ");
                    else CompruebaCaracter(e.Key.ToString());
                }
            }
            catch (FormatException) { vidas--; }

        }

        private void DificultadButton_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Tag.ToString())
            {
                case "Facil":
                    dificultad = 1;
                    dificultadseleccionada = true;
                    pistabutton.IsEnabled = true;
                    ActivarTeclas();
                    EsconderDificultad();
                    rendirsebutotn.IsEnabled = true;
                    SalidaTextBlock.Visibility = Visibility.Visible;
                    break;
                case "Medio":
                    dificultad = 1.5;
                    pistabutton.IsEnabled = true;
                    dificultadseleccionada = true;
                    ActivarTeclas();
                    EsconderDificultad();
                    SalidaTextBlock.Visibility = Visibility.Visible;
                    break;
                case "Dificil":
                    dificultad = 2;
                    dificultadseleccionada = true;
                    ActivarTeclas();
                    EsconderDificultad();
                    SalidaTextBlock.Visibility = Visibility.Visible;
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
            NuevaPartidaBoton.IsEnabled = false;
            FinPartida();
        }

        private void PistaButton_Click(object sender, RoutedEventArgs e)
        {
            string pista = pistas[seleccion];
            MessageBox.Show(pista, "Ahorcado");
            if (dificultad == 1.5) pistabutton.IsEnabled = false;
        }
    }
}
