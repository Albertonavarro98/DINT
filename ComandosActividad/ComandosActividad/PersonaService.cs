using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandosActividad
{
    class PersonaService : ObservableCollection
    {
        public ObservableCollection<Persona> personaLista;
        public ObservableCollection<Nacionalidad> nacionalidadLista;
        public NacionalidadService NS;

        public ObservableCollection<Persona> GetPersonaLista()
        {
            nacionalidadLista = NS.GetNacionalidadLista();
            personaLista = new ObservableCollection<Persona>();
            personaLista.Add(new Persona("paco", 15, nacionalidadLista[3]));
            personaLista.Add(new Persona("pedro", 35, nacionalidadLista[2]));
            personaLista.Add(new Persona("paula", 85, nacionalidadLista[5]));
            personaLista.Add(new Persona("luisa", 2, nacionalidadLista[1]));
            personaLista.Add(new Persona("joaquin", 45, nacionalidadLista[0]));
            personaLista.Add(new Persona("perico", 75, nacionalidadLista[2]));
            personaLista.Add(new Persona("aaaa", 65, nacionalidadLista[3]));
            personaLista.Add(new Persona("bbbbb", 5, nacionalidadLista[5]));
            personaLista.Add(new Persona("ccccc", 35, nacionalidadLista[4]));

            return personaLista;
        }

        public ObservableCollection<string> CargarPersonasTexto()
        {
            ObservableCollection<string> peronsastexto = new ObservableCollection<string>();
            foreach (Persona p in personaLista) 
            {
                peronsastexto.Add(p.PersonaToString());
            }

            return peronsastexto;
        }

    }
}
