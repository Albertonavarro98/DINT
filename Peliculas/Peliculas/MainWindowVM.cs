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
        JsonService serviciojson = new JsonService();
        
        private Pelicula peliculaActual;

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
            peliculas = serviciojson.Importar("../../Datos/peliculas.json");
            Partida partida = new Partida();
            PosicionActual = 1;
            Totalpelis = peliculas.Count();
            PeliculaActual = Peliculas[PosicionActual - 1];
        }

        public string[] generos = new string[] { "Comedia", "Drama" , "Acción", "Terror", "Ciencia-Ficción" };

        public string[] Generos
        {
            get { return generos; }
            set { SetProperty(ref generos, value); }
        }

        private int totalpelis;
        private int posicionActual;

        public int PosicionActual { get => posicionActual; set { SetProperty(ref posicionActual, value); ; } }
        public int Totalpelis { get => totalpelis; set { SetProperty(ref totalpelis, value); } }
        public void Avanzar() { if (PosicionActual < Totalpelis) { PosicionActual++; PeliculaActual = Peliculas[PosicionActual - 1]; } }
        public void Retroceder() { if (PosicionActual > 1) { PosicionActual--; PeliculaActual = Peliculas[PosicionActual - 1]; } }

    }
}
