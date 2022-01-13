using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiventanaPractica1
{
    class ServicioNavegacion
    {
        public void AbrirVentanaHija() 
        {
            Hija1 hija1 = new Hija1();
            hija1.ShowDialog();
        }

        public UserControl1 Abrir1() 
        {
            return new UserControl1();
        }
        public UserControl2 Abrir2() 
        {
            return new UserControl2();
        }
    }
}
