using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace PRUEBA
{
    public class EnlaceDB
    {
        static private string _aux { set; get; }
        static private SqlConnection _conexion;
        static private SqlDataAdapter _adaptador = new SqlDataAdapter();
        static private SqlCommand _comandosql = new SqlCommand();
        static private DataTable _tabla = new DataTable();
        static private DataSet _DS = new DataSet();

        public DataTable obtenertabla
        {
            get
            {
                return _tabla;
            }
        }

        //CONEXION AL APPCONFIG
        private static void conectar()
        {
            //string cnn = ConfigurationManager.AppSettings["desarrollo1"];
            string cnn = ConfigurationManager.ConnectionStrings["Grupo03"].ToString(); //esto hace la conexion al app config usando Grupo03
            _conexion = new SqlConnection(cnn); //esta variable hace una instacia para la conexion
            _conexion.Open(); //hace la conexion a la base de datos usando las credenciales del cnn y _conexion
        }

        //HACE LA DESCONECCION A LA BASE DE DATOS
        private static void desconectar()
        {
            _conexion.Close();
        }

        //TRAE LA INFO DE CUALQUIER TABLA QUE SE NECESITE PARA ACTUALIZAR LOS DATAGRID
        public DataTable ConsultaTabla(string SP)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = SP;
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 1);
                parametro1.Value = "S";

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        //TRAE LA INFO QUE OCUPAMOS DE LA VISTA PARA EL HOTEL
        public DataTable ConsultaVista()
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                _comandosql = new SqlCommand("ObtenerHotelNombreId", _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        //TRAE LA INFO DEL EMPLEADO PARA PODER DARLO DE BAJA
        public DataTable ConsultaTabla2(string Accion, int IdEmpleado)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "SPEmpleado";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 1);
                parametro1.Value = Accion;

                var parametro2 = _comandosql.Parameters.Add("@IdEmpleado", SqlDbType.Int);
                parametro2.Value = IdEmpleado;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        //TRAE LA INFO DEL CLIENTE PARA PODER DARLO DE BAJA
        public DataTable ConsultaTablaC(string Accion, int IdEmpleado)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "SPCliente";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 1);
                parametro1.Value = Accion;

                var parametro2 = _comandosql.Parameters.Add("@IdCliente", SqlDbType.Int);
                parametro2.Value = IdEmpleado;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        //TRAE LA INFO DEL HOTEL PARA DARLO DE BAJA
        public DataTable ConsultaTablaH(string Accion, int IdHotel)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "SPHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 1);
                parametro1.Value = Accion;

                var parametro2 = _comandosql.Parameters.Add("@IdHotel", SqlDbType.Int);
                parametro2.Value = IdHotel;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        //TRAE INFO DEL TIPO DE HABITACION PARA ELIMINARLO
        public DataTable ConsultaTablaTH(string Accion, int IdHotel, int IdHabitacion)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "SPTipoHab";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 1);
                parametro1.Value = Accion;

                var parametro2 = _comandosql.Parameters.Add("@IdHotel", SqlDbType.Int);
                parametro2.Value = IdHotel;

                var parametro3 = _comandosql.Parameters.Add("@IdHabitacion", SqlDbType.Int);
                parametro3.Value = IdHabitacion;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public bool Autentificar(string us, string ps)
        {
            bool isValid = false;
            try
            {
                conectar();
                string qry = "SP_ValidaUser"; //asignamos a qry el valor de Sp_validaUser
                _comandosql = new SqlCommand(qry, _conexion); //aqui usamos la conexion y hacemos uso del SP y lo guardamos en comandosql
                _comandosql.CommandType = CommandType.StoredProcedure; //idica el valor de la propiedad sqlcommand a sql que haremos uso del SP
                _comandosql.CommandTimeout = 9000; //establece el tiempo en segundos hasta recibir un error o una respuesta 

                var parametro1 = _comandosql.Parameters.Add("@correo", SqlDbType.Char, 30); //creamos un param sql con un nombre, tipo y tamaño especifico
                parametro1.Value = us; //igualamos el valor de parametro a us
                var parametro2 = _comandosql.Parameters.Add("@Contrasena", SqlDbType.Char, 30); //obtenemos un parametro
                parametro2.Value = ps; //

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(_tabla);

                if(_tabla.Rows.Count > 0) //checa que tenga algo la tabla y cambia el valor del bool
                {
                    isValid = true;
                }

            }
            catch(SqlException e)
            {
                isValid = false;
            }
            finally
            {
                desconectar();
            }

            return isValid;
        } //esta funciona retorna un booleano cuando entre un usuario y es verdadera
        //usado para el login en empleado y admin
        
        //ES EL METODO PARA TRAERME LA INFO DEL EMPLEADO PARA EL LOGIN
        public DataTable getDataEmp(int IdEmpleado, string Correo, string Nombre,string ApPaterno,string ApMaterno,
        string NumNomina, DateTime FechaNacimeinto, string Calle, string Numero, string Colonia,string CodigoPostal,
        string Telefono,string Celular, int IdRolEmp, string Contra1, string UsuarioAlta,DateTime FechaHoraAlta,
        string UsuarioModif, DateTime FechaHoraModif,string Accion)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "SPEmpleado";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@IdEmpleado", SqlDbType.Int);
                parametro1.Value = IdEmpleado;
                var parametro2 = _comandosql.Parameters.Add("@Correo", SqlDbType.VarChar, 30);
                parametro2.Value = Correo;
                var parametro3 = _comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 30);
                parametro3.Value = Nombre;
                var parametro4 = _comandosql.Parameters.Add("@ApPaterno", SqlDbType.VarChar, 30);
                parametro4.Value = ApPaterno;
                var parametro5 = _comandosql.Parameters.Add("@ApMaterno", SqlDbType.VarChar, 30);
                parametro5.Value = ApMaterno;
                var parametro6 = _comandosql.Parameters.Add("@NumNomina", SqlDbType.VarChar, 30);
                parametro6.Value = NumNomina;
                var parametro7 = _comandosql.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime);
                parametro7.Value = FechaNacimeinto;
                var parametro8 = _comandosql.Parameters.Add("@Calle", SqlDbType.VarChar, 100);
                parametro8.Value = Calle;
                var parametro9 = _comandosql.Parameters.Add("@Numero", SqlDbType.VarChar, 100);
                parametro9.Value = Numero;
                var parametro10 = _comandosql.Parameters.Add("@Colonia", SqlDbType.VarChar, 100);
                parametro10.Value = Colonia;
                var parametro11 = _comandosql.Parameters.Add("@CodigoPostal", SqlDbType.VarChar, 100);
                parametro11.Value = CodigoPostal;
                var parametro12 = _comandosql.Parameters.Add("@Telefono", SqlDbType.VarChar, 15);
                parametro12.Value = Telefono;
                var parametro13 = _comandosql.Parameters.Add("@Celular", SqlDbType.VarChar, 15);
                parametro13.Value = Celular;
                var parametro14 = _comandosql.Parameters.Add("@IdRolEmp", SqlDbType.Int);
                parametro14.Value = IdRolEmp;
                var parametro15 = _comandosql.Parameters.Add("@Contra1", SqlDbType.VarChar, 50);
                parametro15.Value = Contra1;
                var parametro16 = _comandosql.Parameters.Add("@UsuarioAlta", SqlDbType.VarChar, 50);
                parametro16.Value = UsuarioAlta;
                var parametro17 = _comandosql.Parameters.Add("@FechaHoraAlta", SqlDbType.DateTime);
                parametro17.Value = FechaHoraAlta;
                var parametro18 = _comandosql.Parameters.Add("@UsuarioModif", SqlDbType.VarChar, 30);
                parametro18.Value = UsuarioModif;
                var parametro19 = _comandosql.Parameters.Add("@FechaHoraModif", SqlDbType.DateTime);
                parametro19.Value = FechaHoraModif;
                var parametro20 = _comandosql.Parameters.Add("@Accion", SqlDbType.Char,1);
                parametro20.Value = Accion;
                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);
            }
            catch(SqlException e){
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        //METODO PARA AGREGAR Y MODIFICAR LOS DATOS DEL EMPLEADOO
        public DataTable AgEmpleado(int IdEmpleado, string Correo, string Nombre, string ApPaterno, string ApMaterno,
        string NumNomina, DateTime FechaNacimeinto, string Calle, string Numero, string Colonia, string CodigoPostal,
        string Telefono, string Celular, int IdRolEmp, string Contra1, string UsuarioAlta, DateTime FechaHoraAlta,
        string UsuarioModif, DateTime FechaHoraModif, string Accion)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "SPEmpleado";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@IdEmpleado", SqlDbType.Int);
                parametro1.Value = IdEmpleado;
                var parametro2 = _comandosql.Parameters.Add("@Correo", SqlDbType.VarChar, 30);
                parametro2.Value = Correo;
                var parametro3 = _comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 30);
                parametro3.Value = Nombre;
                var parametro4 = _comandosql.Parameters.Add("@ApPaterno", SqlDbType.VarChar, 30);
                parametro4.Value = ApPaterno;
                var parametro5 = _comandosql.Parameters.Add("@ApMaterno", SqlDbType.VarChar, 30);
                parametro5.Value = ApMaterno;
                var parametro6 = _comandosql.Parameters.Add("@NumNomina", SqlDbType.VarChar, 30);
                parametro6.Value = NumNomina;
                var parametro7 = _comandosql.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime);
                parametro7.Value = FechaNacimeinto;
                var parametro8 = _comandosql.Parameters.Add("@Calle", SqlDbType.VarChar, 100);
                parametro8.Value = Calle;
                var parametro9 = _comandosql.Parameters.Add("@Numero", SqlDbType.VarChar, 100);
                parametro9.Value = Numero;
                var parametro10 = _comandosql.Parameters.Add("@Colonia", SqlDbType.VarChar, 100);
                parametro10.Value = Colonia;
                var parametro11 = _comandosql.Parameters.Add("@CodigoPostal", SqlDbType.VarChar, 100);
                parametro11.Value = CodigoPostal;
                var parametro12 = _comandosql.Parameters.Add("@Telefono", SqlDbType.VarChar, 15);
                parametro12.Value = Telefono;
                var parametro13 = _comandosql.Parameters.Add("@Celular", SqlDbType.VarChar, 15);
                parametro13.Value = Celular;
                var parametro14 = _comandosql.Parameters.Add("@IdRolEmp", SqlDbType.Int);
                parametro14.Value = IdRolEmp;
                var parametro15 = _comandosql.Parameters.Add("@Contra1", SqlDbType.VarChar, 50);
                parametro15.Value = Contra1;
                var parametro16 = _comandosql.Parameters.Add("@UsuarioAlta", SqlDbType.VarChar, 50);
                parametro16.Value = UsuarioAlta;
                var parametro17 = _comandosql.Parameters.Add("@FechaHoraAlta", SqlDbType.DateTime);
                parametro17.Value = FechaHoraAlta;
                var parametro18 = _comandosql.Parameters.Add("@UsuarioModif", SqlDbType.VarChar, 30);
                parametro18.Value = UsuarioModif;
                var parametro19 = _comandosql.Parameters.Add("@FechaHoraModif", SqlDbType.DateTime);
                parametro19.Value = FechaHoraModif;
                var parametro20 = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 1);
                parametro20.Value = Accion;
                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        //METODO PARA AGREGAR AL CLIENTE
        public DataTable AgCliente(int IdCliente, string Nombre, string ApPaterno, string ApMaterno, string RFC,
        string Correo, string Referencia, DateTime FechaNacimiento, string EstadoCivil, string CreadoPor, string Accion)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "SPCliente";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@IdCliente", SqlDbType.Int);
                parametro1.Value = IdCliente;
                var parametro2 = _comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 30);
                parametro2.Value = Nombre;
                var parametro3 = _comandosql.Parameters.Add("@ApPaterno", SqlDbType.VarChar, 30);
                parametro3.Value = ApPaterno;
                var parametro4 = _comandosql.Parameters.Add("@ApMaterno", SqlDbType.VarChar, 30);
                parametro4.Value = ApMaterno;
                var parametro5 = _comandosql.Parameters.Add("@RFC", SqlDbType.VarChar, 30);
                parametro5.Value = RFC;
                var parametro6 = _comandosql.Parameters.Add("@Correo", SqlDbType.VarChar,30);
                parametro6.Value = Correo;
                var parametro7 = _comandosql.Parameters.Add("@Referencia", SqlDbType.VarChar,33);
                parametro7.Value = Referencia;
                var parametro8 = _comandosql.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime);
                parametro8.Value = FechaNacimiento;
                var parametro9 = _comandosql.Parameters.Add("@EstadoCivil", SqlDbType.VarChar, 30);
                parametro9.Value = EstadoCivil;
                var parametro10 = _comandosql.Parameters.Add("@CreadoPor", SqlDbType.Int);
                parametro10.Value = CreadoPor;
                var parametro11 = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 1);
                parametro11.Value = Accion;
                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        //METODO PARA EDITAR AL CLIENTE
        public DataTable EditCliente(int IdCliente, string Nombre, string ApPaterno, string ApMaterno, string RFC,
        string Correo, string Referencia, DateTime FechaNacimiento, string EstadoCivil, string UsuarioModificacion,
        DateTime FechaModificacion, string Accion)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "SPCliente";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@IdCliente", SqlDbType.Int);
                parametro1.Value = IdCliente;
                var parametro2 = _comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 30);
                parametro2.Value = Nombre;
                var parametro3 = _comandosql.Parameters.Add("@ApPaterno", SqlDbType.VarChar, 30);
                parametro3.Value = ApPaterno;
                var parametro4 = _comandosql.Parameters.Add("@ApMaterno", SqlDbType.VarChar, 30);
                parametro4.Value = ApMaterno;
                var parametro5 = _comandosql.Parameters.Add("@RFC", SqlDbType.VarChar, 30);
                parametro5.Value = RFC;
                var parametro6 = _comandosql.Parameters.Add("@Correo", SqlDbType.VarChar, 30);
                parametro6.Value = Correo;
                var parametro7 = _comandosql.Parameters.Add("@Referencia", SqlDbType.VarChar, 33);
                parametro7.Value = Referencia;
                var parametro8 = _comandosql.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime);
                parametro8.Value = FechaNacimiento;
                var parametro9 = _comandosql.Parameters.Add("@EstadoCivil", SqlDbType.VarChar, 30);
                parametro9.Value = EstadoCivil;
                var parametro10 = _comandosql.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar, 30);
                parametro10.Value = UsuarioModificacion;
                var parametro11 = _comandosql.Parameters.Add("@FechaModificacion", SqlDbType.DateTime);
                parametro11.Value = FechaModificacion;
                var parametro12 = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 1);
                parametro12.Value = Accion;
                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        //METODO PARA DAR DE ALTA HOTEL
        public DataTable AgHotel(int IdHotel, string Nombre, string Ciudad, string Estado, string Pais, string Calle,
        string Numero, string CodigoPostal, string CantPisos, string CantHabitaciones, string ZonaTuristica,
        string Servicios, string Amenidades, DateTime FecOperaciones, DateTime FecAlta, string CreadoPor, string Accion)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "SPHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@IdHotel", SqlDbType.Int);
                parametro1.Value = IdHotel;
                var parametro2 = _comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 30);
                parametro2.Value = Nombre;
                var parametro3 = _comandosql.Parameters.Add("@Ciudad", SqlDbType.VarChar, 100);
                parametro3.Value = Ciudad;
                var parametro4 = _comandosql.Parameters.Add("@Estado", SqlDbType.VarChar, 100);
                parametro4.Value = Estado;
                var parametro5 = _comandosql.Parameters.Add("@Pais", SqlDbType.VarChar, 100);
                parametro5.Value = Pais;
                var parametro6 = _comandosql.Parameters.Add("@Calle", SqlDbType.VarChar, 100);
                parametro6.Value = Calle;
                var parametro7 = _comandosql.Parameters.Add("@Numero", SqlDbType.VarChar, 100);
                parametro7.Value = Numero;
                var parametro8 = _comandosql.Parameters.Add("@CodigoPostal", SqlDbType.VarChar, 100);
                parametro8.Value = CodigoPostal;
                var parametro9 = _comandosql.Parameters.Add("@CantPisos", SqlDbType.VarChar, 100);
                parametro9.Value = CantPisos;
                var parametro10 = _comandosql.Parameters.Add("@CantHabitaciones", SqlDbType.VarChar, 100);
                parametro10.Value = CantHabitaciones;
                var parametro11 = _comandosql.Parameters.Add("@ZonaTuristica", SqlDbType.VarChar, 100);
                parametro11.Value = ZonaTuristica;
                var parametro12 = _comandosql.Parameters.Add("@Servicios", SqlDbType.VarChar, 100);
                parametro12.Value = Servicios;
                var parametro13 = _comandosql.Parameters.Add("@Amenidades", SqlDbType.VarChar, 100);
                parametro13.Value = Amenidades;
                var parametro14 = _comandosql.Parameters.Add("@FecOperaciones", SqlDbType.DateTime);
                parametro14.Value = FecOperaciones;
                var parametro15 = _comandosql.Parameters.Add("@FecAlta", SqlDbType.DateTime);
                parametro15.Value = FecAlta;
                var parametro16 = _comandosql.Parameters.Add("@CreadoPor", SqlDbType.Int);
                parametro16.Value = CreadoPor;
                var parametro17 = _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 1);
                parametro17.Value = Accion;
                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        //METODO PARA EDITAR HOTEL
        public DataTable EdHotel(int IdHotel, string Nombre, string Ciudad, string Estado, string Pais, string Calle,
        string Numero, string CodigoPostal, string CantPisos, string CantHabitaciones, string ZonaTuristica,
        string Servicios, string Amenidades, DateTime FecOperaciones, string Accion)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "SPHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@IdHotel", SqlDbType.Int);
                parametro1.Value = IdHotel;
                var parametro2 = _comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 30);
                parametro2.Value = Nombre;
                var parametro3 = _comandosql.Parameters.Add("@Ciudad", SqlDbType.VarChar, 100);
                parametro3.Value = Ciudad;
                var parametro4 = _comandosql.Parameters.Add("@Estado", SqlDbType.VarChar, 100);
                parametro4.Value = Estado;
                var parametro5 = _comandosql.Parameters.Add("@Pais", SqlDbType.VarChar, 100);
                parametro5.Value = Pais;
                var parametro6 = _comandosql.Parameters.Add("@Calle", SqlDbType.VarChar, 100);
                parametro6.Value = Calle;
                var parametro7 = _comandosql.Parameters.Add("@Numero", SqlDbType.VarChar, 100);
                parametro7.Value = Numero;
                var parametro8 = _comandosql.Parameters.Add("@CodigoPostal", SqlDbType.VarChar, 100);
                parametro8.Value = CodigoPostal;
                var parametro9 = _comandosql.Parameters.Add("@CantPisos", SqlDbType.VarChar, 100);
                parametro9.Value = CantPisos;
                var parametro10 = _comandosql.Parameters.Add("@CantHabitaciones", SqlDbType.VarChar, 100);
                parametro10.Value = CantHabitaciones;
                var parametro11 = _comandosql.Parameters.Add("@ZonaTuristica", SqlDbType.VarChar, 100);
                parametro11.Value = ZonaTuristica;
                var parametro12 = _comandosql.Parameters.Add("@Servicios", SqlDbType.VarChar, 100);
                parametro12.Value = Servicios;
                var parametro13 = _comandosql.Parameters.Add("@Amenidades", SqlDbType.VarChar, 100);
                parametro13.Value = Amenidades;
                var parametro14 = _comandosql.Parameters.Add("@FecOperaciones", SqlDbType.DateTime);
                parametro14.Value = FecOperaciones;
                var parametro15 = _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 1);
                parametro15.Value = Accion;
                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }


        //METODO PARA AGREGAR TIPO DE HABITACION
        public DataTable AgTipHab(int IdHabitacion, string TipoHabitacion, string CantCamas, string TipoCama,
            decimal Precio, string CantPersonas, string CantTipoHab, string Caracteristicas, string Amenidades,
            DateTime FecAlta, string IdEmpleadoHo, string IdHotel, string NombreHotel, string CantHabitaciones, string Accion)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "SPTipoHab";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@IdHabitacion", SqlDbType.Int);
                parametro1.Value = IdHabitacion;
                var parametro2 = _comandosql.Parameters.Add("@TipoHabitacion", SqlDbType.VarChar, 30);
                parametro2.Value = TipoHabitacion;
                var parametro3 = _comandosql.Parameters.Add("@CantCamas", SqlDbType.VarChar, 30);
                parametro3.Value = CantCamas;
                var parametro4 = _comandosql.Parameters.Add("@TipoCama", SqlDbType.VarChar, 100);
                parametro4.Value = TipoCama;
                var parametro5 = _comandosql.Parameters.Add("@Precio", SqlDbType.Money);
                parametro5.Value = Precio;
                var parametro6 = _comandosql.Parameters.Add("@CantPersonas", SqlDbType.VarChar, 30);
                parametro6.Value = CantPersonas;
                var parametro7 = _comandosql.Parameters.Add("@CantTipoHab", SqlDbType.VarChar, 30);
                parametro7.Value = CantTipoHab;
                var parametro8 = _comandosql.Parameters.Add("@Caracteristicas", SqlDbType.VarChar, 30);
                parametro8.Value = Caracteristicas;
                var parametro9 = _comandosql.Parameters.Add("@Amenidades", SqlDbType.VarChar, 30);
                parametro9.Value = Amenidades;
                var parametro10 = _comandosql.Parameters.Add("@FecAlta", SqlDbType.DateTime);
                parametro10.Value = FecAlta;
                var parametro11 = _comandosql.Parameters.Add("@IdEmpleadoHo", SqlDbType.Int);
                parametro11.Value = IdEmpleadoHo;
                var parametro12 = _comandosql.Parameters.Add("@IdHotel", SqlDbType.Int);
                parametro12.Value = IdHotel;
                var parametro13 = _comandosql.Parameters.Add("@NombreHotel", SqlDbType.VarChar, 100);
                parametro13.Value = NombreHotel;
                var parametro14 = _comandosql.Parameters.Add("@CantHabitaciones", SqlDbType.Int);
                parametro14.Value = CantHabitaciones;
                var parametro15 = _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 1);
                parametro15.Value = Accion;
                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        //METODO PARA EDITAR TIPO DE HABITACION
        public DataTable EditTipHab(int IdHabitacion, string TipoHabitacion, string CantCamas, string TipoCama,
            decimal Precio, string CantPersonas, string CantTipoHab, string Caracteristicas, string Amenidades,
            DateTime FecAlta, string IdHotel, string NombreHotel, string CantHabitaciones, string Accion)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "SPTipoHab";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@IdHabitacion", SqlDbType.Int);
                parametro1.Value = IdHabitacion;
                var parametro2 = _comandosql.Parameters.Add("@TipoHabitacion", SqlDbType.VarChar, 30);
                parametro2.Value = TipoHabitacion;
                var parametro3 = _comandosql.Parameters.Add("@CantCamas", SqlDbType.VarChar, 30);
                parametro3.Value = CantCamas;
                var parametro4 = _comandosql.Parameters.Add("@TipoCama", SqlDbType.VarChar, 100);
                parametro4.Value = TipoCama;
                var parametro5 = _comandosql.Parameters.Add("@Precio", SqlDbType.Money);
                parametro5.Value = Precio;
                var parametro6 = _comandosql.Parameters.Add("@CantPersonas", SqlDbType.VarChar, 30);
                parametro6.Value = CantPersonas;
                var parametro7 = _comandosql.Parameters.Add("@CantTipoHab", SqlDbType.VarChar, 30);
                parametro7.Value = CantTipoHab;
                var parametro8 = _comandosql.Parameters.Add("@Caracteristicas", SqlDbType.VarChar, 30);
                parametro8.Value = Caracteristicas;
                var parametro9 = _comandosql.Parameters.Add("@Amenidades", SqlDbType.VarChar, 30);
                parametro9.Value = Amenidades;
                var parametro10 = _comandosql.Parameters.Add("@FecAlta", SqlDbType.DateTime);
                parametro10.Value = FecAlta;
                var parametro11 = _comandosql.Parameters.Add("@IdHotel", SqlDbType.Int);
                parametro11.Value = IdHotel;
                var parametro12 = _comandosql.Parameters.Add("@NombreHotel", SqlDbType.VarChar, 100);
                parametro12.Value = NombreHotel;
                var parametro13 = _comandosql.Parameters.Add("@CantHabitaciones", SqlDbType.Int);
                parametro13.Value = CantHabitaciones;
                var parametro14 = _comandosql.Parameters.Add("@Accion", SqlDbType.VarChar, 1);
                parametro14.Value = Accion;
                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }





        /*
        public DataTable ConsultaTabla(string SP)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = SP;
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Accion", SqlDbType.Char, 1);
                parametro1.Value = "*";

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }
     */

        /*
        public DataTable get_Deptos(string opc)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Gestiona_Deptos";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }
      */

        }
}
