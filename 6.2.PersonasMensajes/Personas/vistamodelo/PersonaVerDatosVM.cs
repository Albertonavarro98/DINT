using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using Personas.Mensajes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.vistamodelo
{
    class PersonaVerDatosVM : ObservableObject
    {
        private Persona personaActual;

        public Persona PersonaActual
        {
            get { return personaActual; }
            set { SetProperty(ref personaActual, value); }
        }
        public PersonaVerDatosVM()
        {
            PersonaActual = WeakReferenceMessenger.Default.Send<MensajePersonaSeleccionada>();
        }
    }
}
