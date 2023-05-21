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
    public partial class Hotel : Form
    {
        public Hotel()
        {
            InitializeComponent();
        }
        Form1 form = new Form1();  //TRAE NOMBRE Y EL ID DEL USUARIO

        //TRAIGO TODA LA INFO QUE REQUIERO A LA VENTANA
        private void Hotel_Load(object sender, EventArgs e)
        {
            var obj = new EnlaceDB();
            var tabla = new DataTable();

            string cadena = form.getCurrentUserName();
            label15.Text = cadena;

            string cadena1 = form.getCurrentUserId();
            txtid.Text = cadena1;

            tabla = obj.ConsultaTabla("SPHotel");
            dataGridView1.DataSource = tabla;
        }

        //CREA EL HOTEL
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNom.Text==""|| txtCiudad.Text==""||txtEstado.Text==""||txtPais.Text==""||txtCalle.Text==""||
                txtNumero.Text==""||txtCod.Text==""||txtPisos.Text==""||txtHabitaciones.Text==""|| txtZona.Text=="" ||
                txtServicios.Text==""||txtAmenidades.Text=="")
            {
                MessageBox.Show("Porfavor llene todos los campos", ("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var obj = new EnlaceDB();

                obj.AgHotel(1, txtNom.Text, txtCiudad.Text, txtEstado.Text, txtPais.Text, txtCalle.Text, txtNumero.Text, txtCod.Text, txtPisos.Text,
                    txtHabitaciones.Text, txtZona.Text, txtServicios.Text, txtAmenidades.Text, tdOp.Value, dtAlta.Value, txtid.Text, "A");
                MessageBox.Show("EXITO", "Hotel CREADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                var tablaAc = new DataTable();
                tablaAc = obj.ConsultaTabla("SPHotel");
                dataGridView1.DataSource = tablaAc;

                txtNom.Text = "";
                txtCiudad.Text = "";
                txtEstado.Text = "";
                txtPais.Text = "";
                txtCalle.Text = "";
                txtNumero.Text = "";
                txtCod.Text = "";
                txtPisos.Text = "";
                txtHabitaciones.Text = "";
                txtZona.Text = "";
                txtServicios.Text = "";
                txtAmenidades.Text = "";
            }

        }

        //EDITA EL HOTEL
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtNom.Text == "" || txtCiudad.Text == "" || txtEstado.Text == "" || txtPais.Text == "" || txtCalle.Text == "" ||
               txtNumero.Text == "" || txtCod.Text == "" || txtPisos.Text == "" || txtHabitaciones.Text == "" || txtZona.Text == "" ||
               txtServicios.Text == "" || txtAmenidades.Text == "")
            {
                MessageBox.Show("Porfavor llene todos los campos", ("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var obj = new EnlaceDB();

                int ID = int.Parse(txtid2.Text);

                obj.EdHotel(ID,txtNom.Text,txtCiudad.Text,txtEstado.Text,txtPais.Text,txtCalle.Text,txtNumero.Text,txtCod.Text,
                    txtPisos.Text,txtHabitaciones.Text,txtZona.Text,txtServicios.Text,txtAmenidades.Text,tdOp.Value,"M");
                MessageBox.Show("EXITO", "Hotel Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                var tablaAc2 = new DataTable();
                tablaAc2 = obj.ConsultaTabla("SPHotel");
                dataGridView1.DataSource = tablaAc2;

                txtNom.Text = "";
                txtCiudad.Text = "";
                txtEstado.Text = "";
                txtPais.Text = "";
                txtCalle.Text = "";
                txtNumero.Text = "";
                txtCod.Text = "";
                txtPisos.Text = "";
                txtHabitaciones.Text = "";
                txtZona.Text = "";
                txtServicios.Text = "";
                txtAmenidades.Text = "";
            }
        }

        //TRAE INFO DE LA DB
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNom.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString(); 
            txtCiudad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtEstado.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtPais.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtCalle.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtNumero.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtCod.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtPisos.Text = Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtHabitaciones.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txtZona.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            txtServicios.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            txtAmenidades.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            DateTime fecha = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[13].Value);
            tdOp.Value = fecha;
            DateTime fecha2 = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[14].Value);
            dtAlta.Value = fecha2;
        }

        //ELIMINA EL HOTEL
        private void button3_Click(object sender, EventArgs e)
        {
            if (txtid2.Text == "")
            {
                MessageBox.Show("Porfavor selecciona un hotel", ("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var resp = new DialogResult();
                resp = MessageBox.Show("Estas bien seguro de eliminar el hotel?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    int desactivar = int.Parse(txtid2.Text);
                    var Depa = new EnlaceDB();
                    var tabla = new DataTable();
                    tabla = Depa.ConsultaTablaH("E",desactivar);

                    var des1 = new EnlaceDB();
                    var redes = new DataTable();

                    redes = des1.ConsultaTabla("SPHotel");
                    dataGridView1.DataSource = redes;

                    MessageBox.Show("Hotel Eliminado!", ("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    txtNom.Text = "";
                    txtCiudad.Text = "";
                    txtEstado.Text = "";
                    txtPais.Text = "";
                    txtCalle.Text = "";
                    txtNumero.Text = "";
                    txtCod.Text = "";
                    txtPisos.Text = "";
                    txtHabitaciones.Text = "";
                    txtZona.Text = "";
                    txtServicios.Text = "";
                    txtAmenidades.Text = "";
                }
            }
        }
    }
}
