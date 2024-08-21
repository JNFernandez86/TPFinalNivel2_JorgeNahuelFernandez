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
        //private string cadena = ("Data Source=192.168.0.13;Initial Catalog=CATALOGO_DB; User ID=Administrador;Password=Soporte00");
        //rivate string cadena = (@"server=.;database=CATALOGO_DB; integrated security=true");
        private SqlConnection conexion;


        private SqlCommand cmd;
        private SqlDataReader Reader;

        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.;database=CATALOGO_DB; integrated security=true");
            cmd = new SqlCommand();
        }
        public void desconectar() 
        {
            if(Reader != null) 
            conexion.Close();
        }
       
        public void setarconsulta(string consulta)
        {
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = consulta;
        }
      

        public SqlDataReader reader
        {
            get { return Reader; }
        }

        public SqlCommand crearComando()
        {
                   
            
            cmd.Connection = conexion;
            try
            {
                conexion.Open ();
            }
            catch (Exception ex)
            {

                throw ex;
            }
                   
           return cmd;

        }

    }
}
      

