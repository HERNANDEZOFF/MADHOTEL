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
        private static string currentUserName;
        private static string currentUserId;

        public string getCurrentUserName()
        {
            return currentUserName;
        }

        public string getCurrentUserId()
        {
            return currentUserId;
        }

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
                tablas = obj.getDataEmp(1,TxtCorreo.Text,"","","","",DateTime.Now,"","","","","","",0,TxtCont.Text,"",DateTime.Now,"",DateTime.Now,"L");

                if (tablas.Rows.Count == 0)
                {
                    MessageBox.Show("No existe ese empleado / admin", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (tablas.Rows[0][1].ToString() == "1")
                    {
                        string nombre = tablas.Rows[0][0].ToString();
                        currentUserName = nombre;

                        string ide = tablas.Rows[0][3].ToString();
                        currentUserId = ide;

                        var menu = new MenuAdmin();
                        menu.ShowDialog();

                    }
                    else
                    {
                        string nombre = tablas.Rows[0][0].ToString();
                        currentUserName = nombre;

                        string ide = tablas.Rows[0][3].ToString();
                        currentUserId = ide;

                        var menue = new Clientes();
                        menue.ShowDialog();
                    }
                }

            }
        }
    }
}