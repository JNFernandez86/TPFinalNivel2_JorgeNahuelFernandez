using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;

namespace Negocio
{
    public class ArticuloNegocio
    {
        AccesoADatos datos = new AccesoADatos();
        private string query;
        public List<Articulo> mostrar()
        {
            List<Articulo> list = new List<Articulo>();
            query = ("select a.CODIGO,a.NOMBRE, a.Descripcion,m.Descripcion Marca, m.Id IdMarca, c.Descripcion Categoria, m.id IdCategoria ,ImagenUrl, Precio " +
                "from ARTICULOS a " +
                "INNER JOIN MARCAS m ON m.Id = a.IdMarca " +
                "INNER JOIN CATEGORIAS c on c.Id = a.IdCategoria");
            try
            {
                datos.cargarConsulta(query);

                datos.leerDatos();

                while (datos.da.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Codigo = (string)datos.da["Codigo"];
                    aux.Nombre = (string)datos.da["Nombre"];
                    aux.Descripcion = (string)datos.da["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.IdMarca = (int)datos.da["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.da["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id_Categoria = (int)datos.da["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.da["Categoria"];
                    aux.Precio = (decimal)datos.da["Precio"];
                    if (!(datos.da["ImagenUrl"] is DBNull))
                        aux.UrlImagen = aux.UrlImagen = (string)datos.da["ImagenUrl"];

                    list.Add(aux);
                }

                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                datos.cerrarConexion();
            }
        }
        public void agregarArticulo()
        {
            
        }
    }
}
