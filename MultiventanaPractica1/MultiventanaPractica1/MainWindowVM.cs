using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MultiventanaPractica1
{
    class MainWindowVM : ObservableObject
    {
        private UserControl opcion;

        public RelayCommand AbrirCC1 { get; }

        public RelayCommand AbrirCC2 { get; }

        public UserControl Opcion
        {
            get { return opcion; }
            set { SetProperty(ref opcion, value); }
        }
        public RelayCommand AbrirHijaCommand { get;  }
        private ServicioNavegacion sn;

        public MainWindowVM()
        {
            AbrirHijaCommand = new RelayCommand(AbrirHija);
            AbrirCC1 = new RelayCommand(AbrirUC1);
            AbrirCC2 = new RelayCommand(AbrirUC2);
            sn = new ServicioNavegacion();
        }

        private void AbrirHija() 
        {
            sn.AbrirVentanaHija();
        }
        private void AbrirUC1() 
        {
            opcion = sn.Abrir1();
        }
        private void AbrirUC2() 
        {
            opcion = sn.Abrir2();
        }
    }
}
