using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
            query = ("select a.Id, a.CODIGO,a.NOMBRE, a.Descripcion,m.Descripcion Marca, m.Id IdMarca, c.Descripcion Categoria, m.id IdCategoria ,ImagenUrl, Precio " +
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

                    aux.IdArticulo = (int)datos.da["Id"];
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
        public void agregarArticulo(Articulo prop)
        {
            datos = new AccesoADatos();
            query = ("INSERT INTO ARTICULOS(Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) " +
                "VALUES (@code,@name,@description,@idMarca,@idCategoria,@imagenUrl,@price);");
            

            try
            {
                datos.cargarConsulta(query);
                datos.cargarParametros("@code", prop.Codigo);
                datos.cargarParametros("@name", prop.Nombre);
                datos.cargarParametros("@description", prop.Descripcion);
                datos.cargarParametros("@idMarca", prop.Marca.IdMarca);
                datos.cargarParametros("@idCategoria", prop.Categoria.Id_Categoria);
                datos.cargarParametros("@imagenUrl", prop.UrlImagen);
                datos.cargarParametros("@price", prop.Precio);
                datos.ejecutarProceso();

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
        public void modificarArticulo(Articulo prop)
            
        {
            datos = new AccesoADatos();
            query = ("UPDATE ARTICULOS SET Nombre=@name,Descripcion=@description,@IdMarca=idMarca,@IdCategoria=@idcategoria,ImagenUrl=@imagenUrl,Precio=@price  " +
                " WHERE Id=@idArticulo");


            try
            {
                datos.cargarConsulta(query);
                
                datos.cargarParametros("@code", prop.Codigo);
                datos.cargarParametros("@name", prop.Nombre);
                datos.cargarParametros("@description", prop.Descripcion);
                datos.cargarParametros("@idMarca", prop.Marca.IdMarca);
                datos.cargarParametros("@idCategoria", prop.Categoria.Id_Categoria);
                datos.cargarParametros("@imagenUrl", prop.UrlImagen);
                datos.cargarParametros("@price", prop.Precio);
                datos.cargarParametros("@idArticulo", prop.IdArticulo);
                datos.ejecutarProceso();

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

        public void eliminarArticulo(int codigo)
        {
            datos = new AccesoADatos();
            query = "DELETE FROM ARTICULOS WHERE Id=@IdArticulo";

            try
            {
                datos.cargarConsulta(query);
                datos.cargarParametros("@IdArticulo",codigo);
                datos.ejecutarProceso();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }
        public List<Articulo> buscar(string busqueda,string campo, string criterio)
        {
            List<Articulo> listArticulo = new List<Articulo>();
            query = "select a.Id, a.CODIGO,a.NOMBRE, a.Descripcion,m.Descripcion Marca, m.Id IdMarca, c.Descripcion Categoria, m.id IdCategoria ,ImagenUrl, Precio " +
                "from ARTICULOS a INNER JOIN MARCAS m ON m.Id = a.IdMarca INNER JOIN CATEGORIAS c on c.Id = a.IdCategoria " +
                "WHERE ";

            try
            {
                if (string.IsNullOrEmpty(campo) || string.IsNullOrEmpty(criterio))
                {
                    query += "a.NOMBRE LIKE '%" + busqueda + "%' OR a.Descripcion like '%" + busqueda + "%'";
                }
                else
                {
                    ;
                    switch (campo)
                    {
                        case "Precio":
                            query += "Precio";

                            switch (criterio)
                            {
                                case "Mayor a":
                                    query += " > " + busqueda;
                                    break;
                                case "Menor a":
                                    query += " < " + busqueda;
                                    break;
                                case "Igual a":
                                    query += " = " + busqueda;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "Nombre":
                            query += GetQueryString(campo, criterio, busqueda);

                            break;
                        case "Descripcion":
                            campo = "a.Descripcion";
                            query += GetQueryString(campo, criterio, busqueda);
                            break;
                        default:
                            break;

                    }

                }
                datos.cargarConsulta(query);
                datos.leerDatos();

                while (datos.da.Read())
                {
                    Articulo nuevo = new Articulo();

                    nuevo.IdArticulo = (int)datos.da["Id"];
                    nuevo.Codigo = (string)datos.da["Codigo"];
                    nuevo.Nombre = (string)datos.da["Nombre"];
                    nuevo.Descripcion = (string)datos.da["Descripcion"];
                    nuevo.Marca = new Marca();
                    nuevo.Marca.IdMarca = (int)datos.da["IdMarca"];
                    nuevo.Marca.Descripcion = (string)datos.da["Marca"];
                    nuevo.Categoria = new Categoria();
                    nuevo.Categoria.Id_Categoria = (int)datos.da["IdCategoria"];
                    nuevo.Categoria.Descripcion = (string)datos.da["Categoria"];
                    nuevo.Precio = (decimal)datos.da["Precio"];
                    if (!(datos.da["ImagenUrl"] is DBNull))
                        nuevo.UrlImagen = nuevo.UrlImagen = (string)datos.da["ImagenUrl"];

                    listArticulo.Add(nuevo);
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
            
            return listArticulo;
        }
    public string GetQueryString(string txt, string criterio, string variable)
        {
            switch (criterio) 
            {
                case "Comienza con":
                    txt += " like '" + variable + "%'";
                    return txt;
                case "Termina con":
                    txt += " like '%" + variable + "'";
                    return txt;
                case "Contiene":
                    txt +=  " like '%" + variable + "%'";
                    return txt;
                default:
                    return txt;

            }

        }
    }
    
}
