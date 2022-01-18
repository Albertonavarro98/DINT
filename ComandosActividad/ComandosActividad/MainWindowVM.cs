using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ComandosActividad
{
    class MainWindowVM : ObservableObject
    {
        private UserControl actual;

        public RelayCommand AbrirAñadirPersonaCommand { get; }

        public RelayCommand AbrirListaPersonaCommand { get; }

        public RelayCommand AbrirAñadirNacionalidadCommand { get; }
        private readonly ServicioNavegacion sn;

        public UserControl Actual
        {
            get { return actual; }
            set { SetProperty(ref actual, value); }
        }

        public MainWindowVM()
        {
            sn = new ServicioNavegacion();
            AbrirAñadirNacionalidadCommand = new RelayCommand(Abrir_AñadirNacionalidad);
            AbrirAñadirPersonaCommand = new RelayCommand(Abrir_AñadirPersona);
            AbrirListaPersonaCommand = new RelayCommand(Abrir_ListaPersona);
        }

        private void Abrir_AñadirNacionalidad()
        {
            sn.AbrirVentanaNuevaNacionalidad();
        }
        private void Abrir_ListaPersona()
        {
            actual = sn.AbrirListaPersonas();
        }
        private void Abrir_AñadirPersona()
        {
            actual = sn.AbrirNuevaPersona();
        }
    }
}
