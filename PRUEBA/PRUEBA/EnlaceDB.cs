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

        private static void conectar()
        {
            //string cnn = ConfigurationManager.AppSettings["desarrollo1"];
            string cnn = ConfigurationManager.ConnectionStrings["Grupo03"].ToString(); //esto hace la conexion al app config usando Grupo03
            _conexion = new SqlConnection(cnn); //esta variable hace una instacia para la conexion
            _conexion.Open(); //hace la conexion a la base de datos usando las credenciales del cnn y _conexion
        }

        private static void desconectar()
        {
            _conexion.Close();
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

        public DataTable getDataEmp(string correo, string contra)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "spLogin";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                _comandosql.Parameters.Add("@Correo", SqlDbType.VarChar).Value = correo;
                _comandosql.Parameters.Add("@Contra1", SqlDbType.VarChar).Value = contra;
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
