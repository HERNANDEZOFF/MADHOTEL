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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }
        Form1 form = new Form1();  //TRAE NOMBRE Y EL ID DEL USUARIO

        //CREA EMPLEADOS
        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (txtcorreo.Text==""|| txtnombre.Text==""||txtapellido1.Text==""||txtapellido2.Text==""|| txtnomina.Text==""|| txtcalle.Text==""||
                txtnum.Text==""|| txtcol.Text==""|| txtcod.Text==""||txttel.Text==""||txtcel.Text==""||txtcont.Text=="")
            {
                MessageBox.Show("Porfavor llene todos los campos", ("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var obj = new EnlaceDB();   

                obj.AgEmpleado(1, txtcorreo.Text, txtnombre.Text, txtapellido1.Text, txtapellido2.Text, txtnomina.Text, dtNacimiento.Value, txtcalle.Text,
                    txtnum.Text, txtcol.Text, txtcod.Text, txttel.Text, txtcel.Text, 2, txtcont.Text, label14.Text, dtalta.Value, label14.Text, dtmod.Value, "A");
                MessageBox.Show("EXITO", "EMPLEADO CREADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                var tablaAc = new DataTable();
                tablaAc = obj.ConsultaTabla("SPEmpleado");
                dataGridView1.DataSource = tablaAc;
                txtcorreo.Text = "";
                txtnombre.Text = "";
                txtapellido1.Text = "";
                txtapellido2.Text = "";
                txtnomina.Text = "";
                txtcalle.Text = "";
                txtnum.Text = "";
                txtcol.Text = "";
                txtcod.Text = "";
                txttel.Text = "";
                txtcont.Text = "";
            }
        }

        //CARGA LA INFO
        private void Usuarios_Load_1(object sender, EventArgs e)
        {
            var obj = new EnlaceDB();
            var tabla = new DataTable();

            string cadena = form.getCurrentUserName();
            label14.Text = cadena;

            tabla = obj.ConsultaTabla("SPEmpleado");
            dataGridView1.DataSource = tabla;
        }

        //EDITA EMPLEADOS
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtcorreo.Text == "" || txtnombre.Text == "" || txtapellido1.Text == "" || txtapellido2.Text == "" || txtnomina.Text == "" || txtcalle.Text == "" ||
                  txtnum.Text == "" || txtcol.Text == "" || txtcod.Text == "" || txttel.Text == "" || txtcel.Text == "" || txtcont.Text == "")
            {
                MessageBox.Show("Porfavor llene todos los campos", ("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int ID = int.Parse(txtid.Text);

                var obj = new EnlaceDB();
                var checar = new EnlaceDB();
                var tablaChecar = new DataTable();
                tablaChecar = checar.ConsultaTabla2("S", int.Parse(txtid.Text));

                obj.AgEmpleado(ID, txtcorreo.Text, txtnombre.Text, txtapellido1.Text, txtapellido2.Text, txtnomina.Text, dtNacimiento.Value, txtcalle.Text,
                    txtnum.Text, txtcol.Text, txtcod.Text, txttel.Text, txtcel.Text, 2, txtcont.Text, label14.Text, dtalta.Value, label14.Text, dtmod.Value, "M");
                MessageBox.Show("EXITO", "EMPLEADO  Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                var tablaAc2 = new DataTable();
                tablaAc2 = obj.ConsultaTabla("SPEmpleado");
                dataGridView1.DataSource = tablaAc2;
            }
        }

        //TRAE LOS DATOS DEL DATAGRID
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtcorreo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtnombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtapellido1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtapellido2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtnomina.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            //dtNacimiento.Value = dataGridView1.CurrentRow.Cells[6];
            DateTime fecha = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[6].Value);
            dtNacimiento.Value = fecha;
            txtcalle.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtnum.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtcol.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txtcod.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            txttel.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            txtcel.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            DateTime fecha2 = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[13].Value);
            dtalta.Value = fecha2;
            txtcont.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            DateTime fecha3 = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[17].Value);
            dtmod.Value = fecha3;
        }

        //DESACTIVA AL EMPLEADO
        private void btndes_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                MessageBox.Show("Porfavor ponga un numero", ("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var resp = new DialogResult();
                resp = MessageBox.Show("Estas bien seguro de que quieres dar de baja temporal al empleado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    int desactivar = int.Parse(txtid.Text);
                    var Depa = new EnlaceDB();
                    var tabla = new DataTable();
                    tabla = Depa.ConsultaTabla2("B", desactivar);

                    var des1 = new EnlaceDB();
                    var redes = new DataTable();

                    redes = des1.ConsultaTabla("SPEmpleado");
                    dataGridView1.DataSource = redes;

                    MessageBox.Show("Empleado dado de baja!", ("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        //REACTIVA AL EMPLEADO
        private void btnact_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                MessageBox.Show("Porfavor ponga un numero", ("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var resp = new DialogResult();
                resp = MessageBox.Show("Estas bien seguro de que quieres dar de alta al empleado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    int desactivar = int.Parse(txtid.Text);
                    var Depa = new EnlaceDB();
                    var tabla = new DataTable();
                    tabla = Depa.ConsultaTabla2("R", desactivar);

                    var des1 = new EnlaceDB();
                    var redes = new DataTable();

                    redes = des1.ConsultaTabla("SPEmpleado");
                    dataGridView1.DataSource = redes;

                    MessageBox.Show("Empleado Reactivado!", ("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        //ELIMINA EMPLEADOS
        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                MessageBox.Show("Porfavor selecciona un empleado", ("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var resp = new DialogResult();
                resp = MessageBox.Show("Estas bien seguro de eliminar al empleado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    int desactivar = int.Parse(txtid.Text);
                    var Depa = new EnlaceDB();
                    var tabla = new DataTable();
                    tabla = Depa.ConsultaTabla2("E", desactivar);

                    var des1 = new EnlaceDB();
                    var redes = new DataTable();

                    redes = des1.ConsultaTabla("SPEmpleado");
                    dataGridView1.DataSource = redes;

                    MessageBox.Show("Empleado Eliminado!", ("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    txtcorreo.Text = "";
                    txtnombre.Text = "";
                    txtapellido1.Text = "";
                    txtapellido2.Text = "";
                    txtnomina.Text = "";
                    txtcalle.Text = "";
                    txtnum.Text = "";
                    txtcol.Text = "";
                    txtcod.Text = "";
                    txttel.Text = "";
                    txtcont.Text = "";
                }
            }
        }
    }
}
