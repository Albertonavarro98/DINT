using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas
{
    class MainWindowVM : ObservableObject
    {
        readonly JsonService serviciojson = new JsonService();
        OpenFileDialogMultipleFilesSample dialogo = new OpenFileDialogMultipleFilesSample();

        private Pelicula peliculaActual;
        public Partida partidaActual;

        public Partida PartidaActual
        {
            get { return partidaActual; }
            set { SetProperty(ref partidaActual, value); }
        }
        public Pelicula PeliculaActual
        {
            get { return peliculaActual; }
            set { SetProperty(ref peliculaActual, value); }
        }

        private ObservableCollection<Pelicula> peliculas;

        public ObservableCollection<Pelicula> Peliculas
        {
            get { return peliculas; }
            set { SetProperty(ref peliculas, value); }
        }

        public MainWindowVM()
        {
            peliculas = serviciojson.Importar("C:/Users/alumno/source/repos/Peliculas/Peliculas/Datos/peliculas.json");
            ObservableCollection<Pelicula> peliculasAcertadas = new ObservableCollection<Pelicula>();
            PartidaActual = new Partida(0, peliculas, peliculasAcertadas);
            PosicionActual = 1;
            Totalpelis = peliculas.Count();
            PeliculaActual = Peliculas[PosicionActual - 1];

        }

        public void IncrementarPuntuacion(int sumador)
        {
            PartidaActual.Puntuacion = PartidaActual.Puntuacion + sumador;
        }

        public string[] generos = new string[] { "Comedia", "Drama" , "Acción", "Terror", "Ciencia-Ficción" };

        public string[] niveles = new string[] { "Difícil", "Fácil", "Medio" };

        public string[] Niveles
        {
            get { return niveles; }
            set { SetProperty(ref niveles, value); }
        }

        public void Guardar() 
        {
            serviciojson.Exportar(dialogo.SaveDialog(), peliculas);
        }

        public void Importar() 
        {
            serviciojson.Importar(dialogo.OpenDialog());
        }


        private Pelicula peliSeleccionada;

        public Pelicula PeliSeleccionada
        {
            get { return peliSeleccionada; }
            set{ SetProperty(ref peliSeleccionada, value); }
        }

        public string[] Generos
        {
            get { return generos; }
            set { SetProperty(ref generos, value); }
        }

        private int totalpelis;
        private int posicionActual;

        public int PosicionActual { get => posicionActual; set { SetProperty(ref posicionActual, value); } }
        public int Totalpelis { get => totalpelis; set { SetProperty(ref totalpelis, value); } }
        public void Avanzar() { if (PosicionActual < Totalpelis) { PosicionActual++; PeliculaActual = Peliculas[PosicionActual - 1]; } }
        public void Retroceder() { if (PosicionActual > 1) { PosicionActual--; PeliculaActual = Peliculas[PosicionActual - 1]; } }

    }
}
