using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.Mensajes
{
    public class MensajePersonaNueva : ValueChangedMessage<Persona>
    {
        public MensajePersonaNueva(Persona persona) : base(persona) { }
    }

    class MensajeNacionalidadNueva : ValueChangedMessage<string> 
    {
        MensajeNacionalidadNueva(string nacionalidad) : base(nacionalidad) { }
    }

    public class MensajePersonaSeleccionada : RequestMessage<Persona> {}
}
