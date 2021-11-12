using Superheroes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhéroes
{
    class MainWindowVistaModelo : INotifyPropertyChanged
    {
        private List<Superheroe> lista;
        private int totalHeroes;
        private int posicionActual;
        private Superheroe superheroeactual;

        public MainWindowVistaModelo()
        {
            lista = Superheroe.GetSamples();
            Superheroeactual = lista[0];
            PosicionActual = 1;
            TotalHeroes = lista.Count();
        }

        public Superheroe Superheroeactual { get => superheroeactual; set { superheroeactual = value; NotifyPropertyChanged("Superheroeactual");} }
        public int PosicionActual { get => posicionActual; set { posicionActual = value; NotifyPropertyChanged("PosicionActual"); } }
        public int TotalHeroes { get => totalHeroes; set { totalHeroes = value; NotifyPropertyChanged("TotalHeroes"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Avanzar() { if (PosicionActual < TotalHeroes) { PosicionActual++; Superheroeactual = lista[PosicionActual - 1]; } }
        public void Retroceder() { if (PosicionActual > 1) { PosicionActual--; Superheroeactual = lista[PosicionActual - 1]; } }
    }
}
