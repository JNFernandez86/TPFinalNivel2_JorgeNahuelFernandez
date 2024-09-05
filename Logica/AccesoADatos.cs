using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Logica
{
    public class AccesoADatos
    {
        private string basedatos = ("server=.;database=CATALOGO_DB; integrated security=true");
        //private string basedatos = ("Data Source=192.168.0.13;Initial Catalog=CATALOGO_DB; User ID=Administrador;Password=Soporte00");
        private SqlConnection conexion;
        private SqlCommand cmd;
        private SqlDataReader lector;

        public AccesoADatos()
        {
            conexion = new SqlConnection(basedatos);
            cmd = new SqlCommand();
        }
        public SqlDataReader da
        {
            get { return lector; }
        }

        private void abrirConexion()
        {
            
            cmd.Connection = conexion;
            if(conexion.State == ConnectionState.Closed)
                conexion.Open();
        }
        public void cerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
        }
        
        public void cargarConsulta(string ssql)
        {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = ssql;
        }
        public void leerDatos()
        {
            try
            {
                abrirConexion();
                lector = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public void ejecutarProceso()
        {
            try
            {
                abrirConexion();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void cargarParametros(string nombre, object valor)
        {
            cmd.Parameters.AddWithValue(nombre, valor);
        }

    }
}
