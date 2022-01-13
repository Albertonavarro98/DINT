using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiventanaPractica1
{
    class UserControl2VM : ObservableObject
    {
        private string texto;

        public string Texto
        {
            get { return texto; }
            set { SetProperty(ref texto, value); }
        }
        public UserControl2VM()
        {
            texto = "soy el user control 1";
        }
    }
}
