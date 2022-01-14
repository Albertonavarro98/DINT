using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandosActividad
{
    class Nacionalidad : ObservableObject
    {
        private string nacionalidadNombre;

        public string NacionalidadNombre
        {
            get { return nacionalidadNombre; }
            set { SetProperty(ref nacionalidadNombre, value); }
            
        }

        public Nacionalidad(string _nacionalidadNombre)
        {
            this.nacionalidadNombre = _nacionalidadNombre;
        }
    }
}
