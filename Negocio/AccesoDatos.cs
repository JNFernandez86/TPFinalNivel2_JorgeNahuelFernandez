using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

using Logica;
using System.Net.NetworkInformation;

namespace Negocio
{
    public class AccesoDatos
    {
        private string cadena = ("Data Source=192.168.0.13;Initial Catalog=CATALOGO_DB; User ID=Administrador;Password=Soporte00");
        //private string cadena = "server=.;database=CATALOGO_DB; integrated security=true";
        private SqlConnection conexion;
        private SqlCommand cmd;
        private SqlDataReader Reader;

        private void conectar()
        {
            conexion = new SqlConnection(cadena);
            conexion.Open();
        }
        public void desconectar() 
        { 
            conexion.Close(); 
        }

        public SqlDataReader reader
        {
            get { return Reader; }
        }
        public void crearComando(string consulta)
        {
            
            //conexion = new SqlConnection (cadena);
            conectar();
            cmd = new SqlCommand (consulta, conexion);
            Reader = cmd.ExecuteReader();

        }

    }
}
      

