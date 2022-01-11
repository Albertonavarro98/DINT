using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas
{
    class Partida : ObservableObject
    {
        public int puntuacion;
        ObservableCollection<Pelicula> peliculasPartida;
        ObservableCollection<Pelicula> peliculasAcertadas;

        public int Puntuacion
        {
            get { return puntuacion; }
            set { SetProperty(ref puntuacion, value); }
        }

        public ObservableCollection<Pelicula> PeliculasPartida
        {
            get { return peliculasPartida; }
            set { SetProperty(ref peliculasPartida, value); }
        }

        public ObservableCollection<Pelicula> PeliculasAcertadas
        {
            get { return peliculasAcertadas; }
            set { SetProperty(ref peliculasAcertadas, value); }
        }

        public Partida(int _Puntuacion, ObservableCollection<Pelicula> _peliculasPartida, ObservableCollection<Pelicula> _peliculasAcertadas)
        {
            puntuacion = _Puntuacion;
            this.peliculasPartida = _peliculasPartida;
            this.peliculasAcertadas = _peliculasAcertadas;
        }
        
    }

}