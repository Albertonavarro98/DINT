using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandosActividad
{
    class Persona : ObservableObject
    {
        private string nombre;
        private int edad;
        private Nacionalidad nacionalidad;

        public Persona(string nombre, int edad, Nacionalidad nacionalidad)
        {
            Nombre = nombre;
            Edad = edad;
            Nacionalidad = nacionalidad;
        }

        public Nacionalidad Nacionalidad 
        {
            get { return nacionalidad; }
            set { SetProperty(ref nacionalidad, value); }
        }

        public string Nombre
        {
            get { return nombre; }
            set { SetProperty(ref nombre, value); }
        }

        public int Edad
        {
            get { return edad; }
            set { SetProperty(ref edad, value); }
        }
        

        public string PersonaToString() 
        {
            return nombre + " - " + edad + " - " + nacionalidad;
        }
    }
}
