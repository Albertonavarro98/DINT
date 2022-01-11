using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaComponentes1
{
    class MainWindowVM : ObservableObject
    {
        private int actual;

        public int Actual
        {
            get { return actual; }
            set { SetProperty(ref actual, value); }
        }

        public RelayCommand SiguienteCommand { get; }

        public MainWindowVM()
        {
            Actual = 0;
            SiguienteCommand = new RelayCommand(Avanzar);
        }

        private void Avanzar()
        {
            Actual++;
        }
    }
}
