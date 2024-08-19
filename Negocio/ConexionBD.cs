using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

using Logica;

namespace Negocio
{
    public class ConexionBD
    {
        private SqlConnection conexion = new SqlConnection("Data Source=192.168.0.13;Initial Catalog=CATALOGO_DB; User ID=Administrador;Password=Soporte00");


        public void abrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            
        }
        public void cerraConexion()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
      

