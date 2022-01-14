﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandosActividad
{
    class ServicioNavegacion
    {
        public void AbrirVentanaNuevaNacionalidad()
        {
            AgregarNacionalidad an = new AgregarNacionalidad();
            an.ShowDialog();
        }

        public ListaPersonas AbrirListaPersonas()
        {
            return new ListaPersonas();
        }
        public NuevaPersona AbrirNuevaPersona()
        {
            return new NuevaPersona();
        }
    }
}
