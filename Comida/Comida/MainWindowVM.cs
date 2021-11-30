using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comida
{


    class MainWindowVM : INotifyPropertyChanged
    {
        public ObservableCollection<Plato> platos;

        public ObservableCollection<Plato> Platos
        {
            get { return platos; }
            set
            {
                platos = value;
                NotifyPropertyChanged("Platos");
            }
        }

        private Plato platoSeleccionado;

        public Plato PlatoSeleccionado
        {
            get { return platoSeleccionado; }
            set
            {
                platoSeleccionado = value;
                NotifyPropertyChanged("PlatoSeleccionado");
            }
        }

        public string[] tipos = new string[] { "Americana", "Mexicana", "China" };

        public string[] Tipos {
            get { return tipos; }
            set
            {
                tipos = value;
                NotifyPropertyChanged("Tipos");
            }
        }

        public MainWindowVM()
        {
            platos = Plato.GetSamples(@"C:\Users\alumno\source\repos\Comida\Comida\FotosPlatos");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void borrarPlato() 
        {
            PlatoSeleccionado = null;
        }
    }
}