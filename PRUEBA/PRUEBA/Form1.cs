using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PRUEBA
{
    public partial class Form1 : Form
    {

        private static int currentUserId; // email or ID
        private static int currentUserIdRol;
        private static string currentUserName;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Correo = TxtCorreo.Text;
            string Contrasena = TxtCont.Text;

            // Validar que se ingresen ambos campos
            if (TxtCorreo.Text == "" || TxtCorreo.Text == "")
            {
                MessageBox.Show("Ingrese su correo y contraseña", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var obj = new EnlaceDB();
                var tablas = new DataTable();
                tablas = obj.getDataEmp("", "");

                if (tablas.Rows.Count == 0)
                {
                    MessageBox.Show("No existe ese empleado / admin", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (tablas.Rows[0][1].ToString() == "1")
                    {
                        var menu = new Usuarios();
                        menu.ShowDialog();

                    }
                    else
                    {
                        string nombre = tablas.Rows[0][0].ToString();
                        string ide = tablas.Rows[0][2].ToString();

                        var menue = new Clientes(nombre, ide);
                        menue.ShowDialog();
                    }
                }

            }
        }
    }
}