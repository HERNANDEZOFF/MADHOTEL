using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRUEBA
{
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }
        //BOTON PARA VENTANA EMPLEADO
        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios myForm = new Usuarios();
            myForm.Show();
        }
        //BOTON PARA VENTANA TIPO HABITACION
        private void habitacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Habitacion myForm2 =new Habitacion();
            myForm2.Show();
        }
        //BOTON PARA VENTANANA HOTEL
        private void hotelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hotel myForm3 = new Hotel();
            myForm3.Show();
        }
    }
}
