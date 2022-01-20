using Personas.vistas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Personas
{
    class NavigationService
    {
        private static readonly UserControl listadoPersonas = new ListadoPersonasUserControl();

        public NavigationService()
        {
            
        }

        public UserControl ObtenerNuevaPersona()
        {
            return new NuevaPersonaUserControl();
        }

        public UserControl ObtenerListadoPersonas()
        {
            return listadoPersonas;
        }

        public bool? AbrirDialogoNacionalidad()
        {
            DialogoNacionalidad dialogo = new DialogoNacionalidad();
            return dialogo.ShowDialog();
        }

        internal UserControl ObtenerDatosPersonas()
        {
            return new PersonaVerDatos();
        }
    }
}
