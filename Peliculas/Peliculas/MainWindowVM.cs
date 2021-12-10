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
        
        private Pelicula pelicualaActual;

        public Pelicula PelicualaActual
        {
            get { return pelicualaActual; }
            set { SetProperty(ref pelicualaActual, value); }
        }

        private ObservableCollection<Pelicula> peliculas;

        public ObservableCollection<Pelicula> Pelicualas
        {
            get { return peliculas; }
            set { SetProperty(ref peliculas, value); }
        }

        public MainWindowVM()
        {
            //peliculas = Pelicula.GetSamples(@"C:\Users\alumno\source\repos\Comida\Comida\FotosPlatos");
            Partida partida = new Partida();
        }

        public string[] generos = new string[] { "comedia", "drama" , "acción", "terror", "ciencia-ficción" };

        public string[] Generos
        {
            get { return generos; }
            set { SetProperty(ref generos, value); }
        }

    }
}
