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
        //rivate string cadena = (@"server=.;database=CATALOGO_DB; integrated security=true");
        private SqlConnection conexion;


        private SqlCommand cmd;
        private SqlDataReader lector;

        public AccesoDatos()
        {
            conexion = new SqlConnection(cadena);
            cmd = new SqlCommand();
        }
        public void desconectar() 
        {
            if(lector != null) 
            conexion.Close();
        }
       
        public void setarconsulta(string consulta)
        {
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = consulta;
        }
      

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public void ejecutarLectura()
        {
  
            cmd.Connection = conexion;
            try
            {
                conexion.Open ();
                lector = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
      

