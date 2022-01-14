using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandosActividad
{
    class ListaPersonasVM : ObservableObject
    {
        private PersonaService PS;
        private ObservableCollection<Persona> personas;
        private ObservableCollection<string> personasTexto;

        public ObservableCollection<Persona> Personas
        {
            get { return personas; }
            set { SetProperty(ref personas, value); }
        }

        public ObservableCollection<string> PersonasTexto
        {
            get { return personasTexto; }
            set { SetProperty(ref personasTexto, value); }
        }

        public ListaPersonasVM()
        {
            PS = new PersonaService();
            personas = PS.GetPersonaLista();
            personasTexto = PS.CargarPersonasTexto();
        }


    }
}
