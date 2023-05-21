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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }
        Form1 form = new Form1(); //TRAE NOMBRE Y EL ID DEL USUARIO
        
        //CREA CLIENTES
        private void button1_Click(object sender, EventArgs e)
        {
            if(txtNom.Text==""|| txtAp.Text==""||txtAm.Text==""||txtRfc.Text==""||txtCorreo.Text==""||
                cbRef.Text==""|| cbEstado.Text == "")
            {
                MessageBox.Show("Porfavor llene todos los campos", ("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var obj = new EnlaceDB();

                //int adminUserId = Convert.ToInt32(label9.Text);


                obj.AgCliente(1, txtNom.Text, txtAp.Text, txtAm.Text, txtRfc.Text, txtCorreo.Text, cbRef.Text,
                       dtNacimiento.Value, cbEstado.Text, txtid.Text, "A");
                MessageBox.Show("EXITO", "Cliente CREADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                var tablaAc = new DataTable();
                tablaAc = obj.ConsultaTabla("SPCliente");
                dataGridView1.DataSource = tablaAc;
                txtNom.Text = "";
                txtAp.Text = "";
                txtAm.Text = "";
                txtRfc.Text = "";
                txtCorreo.Text ="";
                cbRef.Text = "";
                cbEstado.Text = "";
            }
        }

        //CARGAN LA INFO
        private void Clientes_Load_1(object sender, EventArgs e)
        {
            var obj = new EnlaceDB();
            var tabla = new DataTable();

            string cadena = form.getCurrentUserName();
            label9.Text = cadena;

            string cadena1 = form.getCurrentUserId();
            txtid.Text = cadena1;

            tabla = obj.ConsultaTabla("SPCliente");
            dataGridView1.DataSource = tabla;
        }
        
        //TRAE DATOS DEL DATAGRID
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNom.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtAp.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtAm.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtRfc.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtCorreo.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            cbRef.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            cbEstado.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        //EDITA CLIENTE
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtNom.Text == "" || txtAp.Text == "" || txtAm.Text == "" || txtRfc.Text == "" || txtCorreo.Text == "" ||
               cbRef.Text == "" || cbEstado.Text == "")
            {
                MessageBox.Show("Porfavor llene todos los campos", ("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int ID = int.Parse(txtid2.Text);

                var obj = new EnlaceDB();
                var checar = new EnlaceDB();
                var tablaChecar = new DataTable();
                tablaChecar = checar.ConsultaTabla2("S", int.Parse(txtid2.Text));

                obj.EditCliente(ID, txtNom.Text, txtAp.Text, txtAm.Text, txtRfc.Text, txtCorreo.Text, cbRef.Text,
                      dtNacimiento.Value, cbEstado.Text, label9.Text,dtMod.Value ,"M");
                MessageBox.Show("EXITO", "Cliente Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                var tablaAc2 = new DataTable();
                tablaAc2 = obj.ConsultaTabla("SPCliente");
                dataGridView1.DataSource = tablaAc2;

                txtNom.Text = "";
                txtAp.Text = "";
                txtAm.Text = "";
                txtRfc.Text = "";
                txtCorreo.Text = "";
                cbRef.Text = "";
                cbEstado.Text = "";
            }
        }

        //ELIMINA CLIENTE
        private void button3_Click(object sender, EventArgs e)
        {
            if (txtid2.Text == "")
            {
                MessageBox.Show("Porfavor ponga un numero", ("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var resp = new DialogResult();
                resp = MessageBox.Show("Estas bien seguro de eliminar al cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    int desactivar = int.Parse(txtid2.Text);
                    var Depa = new EnlaceDB();
                    var tabla = new DataTable();
                    tabla = Depa.ConsultaTablaC("B", desactivar);

                    var des1 = new EnlaceDB();
                    var redes = new DataTable();

                    redes = des1.ConsultaTabla("SPCliente");
                    dataGridView1.DataSource = redes;

                    MessageBox.Show("Cliente Eliminado!", ("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNom.Text = "";
                    txtAp.Text = "";
                    txtAm.Text = "";
                    txtRfc.Text = "";
                    txtCorreo.Text = "";
                    cbRef.Text = "";
                    cbEstado.Text = "";
                }
            }
        }
    }
}
