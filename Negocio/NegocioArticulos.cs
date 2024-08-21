using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;
using System.Data.SqlClient;
using System.Security.AccessControl;

namespace Negocio
{
    public class NegocioArticulos
    {
        AccesoDatos datos = new AccesoDatos();
        SqlDataReader dr;
        
        public List<Articulos> ListarArticulos()
        {   
            List<Articulos> art = new List<Articulos>();
            //Articulos articulos = new Articulos();


            try
            {
                string sql = "SELECT Id,Codigo, Nombre, Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio FROM ARTICULOS";
                datos.crearComando(sql);
                dr = datos.reader;

                while (dr.Read()) 
                {
                    Articulos articulos = new Articulos();
                    articulos.Id_articulos = (int)dr["Id"];
                    articulos.Codigo = (string)dr["Codigo"];
                    articulos.Nombre = (string)dr["Nombre"];
                    articulos.Descripcion = (string)dr["Descripcion"];
                    articulos.Marca = (int)dr["IdMarca"];
                    articulos.Categoria = (int)dr["IdCategoria"];
                    articulos.UrlImagen = (string)dr["ImagenUrl"];
                    articulos.Precio = (decimal)dr["Precio"];
                    art.Add(articulos);
                }
                
                return art;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.desconectar();
            }
           


        }

        public void agregarArticulos()
        {

        }
        public void actualizarArticulos()
        {

        }

        public void eliminarArticulos()
        {

        }
    }
}
