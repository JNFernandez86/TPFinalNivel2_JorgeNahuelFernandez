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
        //private SqlConnection conexion = new SqlConnection("Data Source=192.168.0.13;Initial Catalog=CATALOGO_DB; User ID=Administrador;Password=Soporte00");
        private string cadena = "server=.;database=CATALOGO_DB; integrated security=true";
        private SqlConnection conexion;
        private SqlCommand cmd;
        private SqlDataReader reader;

        public void conectar()
        {
            conexion = new SqlConnection(cadena);
            conexion.Open();
        }
        public void desconectar() 
        { 
            conexion.Close(); 
        }
        
        public 


    }
}
      

