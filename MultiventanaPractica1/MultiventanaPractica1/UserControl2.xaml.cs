using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MultiventanaPractica1
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        private UserControl2VM uscvm2;
        public UserControl2()
        {
            InitializeComponent();
            uscvm2 = new UserControl2VM();
            this.DataContext = uscvm2;
        }
    }
}
