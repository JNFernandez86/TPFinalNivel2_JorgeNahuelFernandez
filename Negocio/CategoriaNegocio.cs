using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization.Configuration;
using Logica;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listarCategoria()
        {
            AccesoADatos datos = new AccesoADatos();
            List<Categoria> list = new List<Categoria>();
            string query = ("select Id, Descripcion from CATEGORIAS;");

            try
            {
                datos.cargarConsulta(query);
                datos.leerDatos();

                while (datos.da.Read())
                {
                    Categoria aux = new Categoria();
                    aux.IdCategoria = (int)datos.da["Id"];
                    aux.Descripcion = (string)datos.da["Descripcion"];
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
        public void nuevaCategoria(Categoria cat)

        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.cargarConsulta("INSERT INTO CATEGORIAS (Descripcion) values (@categoria)");
                datos.cargarParametros("@categoria", cat.Descripcion);
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
    }
}
