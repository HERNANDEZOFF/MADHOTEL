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
    public partial class Habitacion : Form
    {
        private EnlaceDB enlaceDB;

        public Habitacion()
        {
            InitializeComponent();
            enlaceDB = new EnlaceDB();
        }
        Form1 form = new Form1();  //TRAE NOMBRE Y EL ID DEL USUARIO

        //CARGA TODA LA INFORMACION QUE NECESITAMOS PARA ESTA VENTANA
        private void Habitacion_Load(object sender, EventArgs e)
        {
            var obj = new EnlaceDB();
            var tabla = new DataTable();
            var tablita = obj.ConsultaVista();

            cbHotel.DataSource = tablita;
            cbHotel.DisplayMember = "Nombre";
            cbHotel.ValueMember = "IdHotel";
            cbHotel.ValueMember = "CantHabitaciones";
            cbHotel.SelectedIndexChanged += new EventHandler(cbHotel_SelectedIndexChanged);


            string cadena = form.getCurrentUserName();
            label12.Text = cadena;

            string cadena1 = form.getCurrentUserId();
            txtid.Text = cadena1;

            tabla = obj.ConsultaTabla("SPTipoHab");
            dataGridView1.DataSource = tabla;

        }
        
        //TRAE INFORMACION AL SELECCIONAR EL HOTEL
        private void cbHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbHotel.SelectedItem != null)
            {
                var hotelSeleccionado = (DataRowView)cbHotel.SelectedItem;
                txtid2.Text = hotelSeleccionado["IdHotel"].ToString();

                // Obtener la cantidad de habitaciones del hotel seleccionado
                int idHotel = Convert.ToInt32(txtid2.Text);
                ObtenerCantidadHabitaciones(idHotel);

                int cantHabitaciones = Convert.ToInt32(hotelSeleccionado["CantHabitaciones"]);
                txtchab.Text = cantHabitaciones.ToString();
            }
        }
        
        //SOLO SIRVE PARA TRAERME LA CANTIDAD DE CUARTOS QUE HAY
        private void ObtenerCantidadHabitaciones(int idHotel){}

        //DA DE ALTA EL TIPO DE HABITACION PARA EL HOTEL
        private void button1_Click(object sender, EventArgs e)
        {
            if(txtTipoHab.Text == "" || txtCanCama.Text == "" || cbtipocama.Text == "" || txtprecio.Text == "" || txtcanper.Text == "" ||
                cbHotel.Text == "" || txtame.Text == "" || txtcarac.Text == ""||txtcanthab.Text=="")
            {
                MessageBox.Show("Porfavor llene todos los campos", ("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var obj = new EnlaceDB();

                decimal precio = decimal.Parse(txtprecio.Text);

                obj.AgTipHab(1, txtTipoHab.Text, txtCanCama.Text, cbtipocama.Text,precio, txtcanper.Text,txtcanthab.Text ,txtcarac.Text, txtame.Text,
                   dtalta.Value, txtid.Text, txtid2.Text,cbHotel.Text,txtchab.Text,"A");
                MessageBox.Show("EXITO", "Tipo Habitacion CREADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                var tablaAc = new DataTable();
                tablaAc = obj.ConsultaTabla("SPTipoHab");
                dataGridView1.DataSource = tablaAc;

                txtTipoHab.Text = "";
                txtCanCama.Text = "";
                cbtipocama.Text = "";
                txtprecio.Text = "";
                txtcanper.Text = "";
                cbHotel.Text = "";
                txtame.Text = "";
                txtcarac.Text = "";
                txtcanthab.Text = "";
            }
        }

        //MUESTRA Y SIRVE PARA TRAERME LA INFO DEL DTG
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtid3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTipoHab.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtCanCama.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cbtipocama.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtprecio.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtcanper.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtcanthab.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtcarac.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtame.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            DateTime fecha = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[9].Value);
            txtid.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            txtid2.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            cbHotel.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            txtchab.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
        }

        //EDITAR EL TIPO DE HABITACION
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtTipoHab.Text == "" || txtCanCama.Text == "" || cbtipocama.Text == "" || txtprecio.Text == "" || txtcanper.Text == "" ||
                cbHotel.Text == "" || txtame.Text == "" || txtcarac.Text == "" || txtcanthab.Text == "")
            {
                MessageBox.Show("Porfavor llene todos los campos", ("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var obj = new EnlaceDB();

                decimal precio = decimal.Parse(txtprecio.Text);

                int ID = int.Parse(txtid3.Text);

                obj.EditTipHab(ID, txtTipoHab.Text, txtCanCama.Text, cbtipocama.Text, precio, txtcanper.Text, txtcanthab.Text, txtcarac.Text, txtame.Text,
                   dtalta.Value, txtid2.Text, cbHotel.Text, txtchab.Text, "M");
                MessageBox.Show("EXITO", "Tipo Habitacion CREADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                var tablaAc = new DataTable();
                tablaAc = obj.ConsultaTabla("SPTipoHab");
                dataGridView1.DataSource = tablaAc;

                txtTipoHab.Text = "";
                txtCanCama.Text = "";
                cbtipocama.Text = "";
                txtprecio.Text = "";
                txtcanper.Text = "";
                cbHotel.Text = "";
                txtame.Text = "";
                txtcarac.Text = "";
                txtcanthab.Text = "";
            }
        }
        
        //ELIMINA EL TIPO DE HABITACION
        private void button3_Click(object sender, EventArgs e)
        {
            if (txtid3.Text == "")
            {
                MessageBox.Show("Porfavor selecciona un tipo de habitacion", ("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var resp = new DialogResult();
                resp = MessageBox.Show("Estas bien seguro de eliminar este tipo de habitacion?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    int desactivar = int.Parse(txtid3.Text);
                    int idHotel = int.Parse(txtid2.Text);
                    var Depa = new EnlaceDB();
                    var tabla = new DataTable();
                    tabla = Depa.ConsultaTablaTH("E", idHotel, desactivar);

                    var des1 = new EnlaceDB();
                    var redes = new DataTable();

                    redes = des1.ConsultaTabla("SPTipoHab");
                    dataGridView1.DataSource = redes;

                    MessageBox.Show("Hotel Eliminado!", ("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                    txtTipoHab.Text = "";
                    txtCanCama.Text = "";
                    cbtipocama.Text = "";
                    txtprecio.Text = "";
                    txtcanper.Text = "";
                    cbHotel.Text = "";
                    txtame.Text = "";
                    txtcarac.Text = "";
                    txtcanthab.Text = "";
                }
            }
        }

    }
}
