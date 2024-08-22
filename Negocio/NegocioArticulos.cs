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
      
        string sql;
        
        public List<Articulos> ListarArticulos(string ssql)
        {   
            List<Articulos> art = new List<Articulos>();
            //Articulos articulos = new Articulos();

         try
            {
                datos.setarconsulta("select * from Articulos");
                datos.ejecutarLectura();

                while (datos.Lector.Read()) 
                {
                    Articulos articulos = new Articulos();

                    articulos.Id = (int)datos.Lector["Id"];
                    articulos.Codigo = (string)datos.Lector["Codigo"];
                    articulos.Nombre = (string)datos.Lector["Nombre"];
                    articulos.Descripcion = (string)datos.Lector["Descripcion"];
                    articulos.Marca = (int)datos.Lector["IdMarca"];
                    articulos.Categoria = (int)datos.Lector["IdCategoria"];
                    articulos.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    articulos.Precio = (decimal)datos.Lector["Precio"];
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

        //public 

    }
}
