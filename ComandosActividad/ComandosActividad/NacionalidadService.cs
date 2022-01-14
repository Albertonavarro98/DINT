using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandosActividad
{
    class NacionalidadService : ObservableCollection
    {
        public ObservableCollection<Nacionalidad> nacionalidadLista;

        public ObservableCollection<Nacionalidad> GetNacionalidadLista()
        {
            nacionalidadLista = new ObservableCollection<Nacionalidad>();
            nacionalidadLista.Add(new Nacionalidad("Japones"));
            nacionalidadLista.Add(new Nacionalidad("Español"));
            nacionalidadLista.Add(new Nacionalidad("Frances"));
            nacionalidadLista.Add(new Nacionalidad("Turco"));
            nacionalidadLista.Add(new Nacionalidad("Ruso"));
            nacionalidadLista.Add(new Nacionalidad("Polaco"));
            
            return nacionalidadLista;
        }


    }
}
