using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization.Configuration;
using Logica;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listarcat()
        {
            AccesoADatos datos = new AccesoADatos();
            List<Categoria> list = new List<Categoria>();
            string query = ("Select Id, Descripcion From Categorias");

            try
            {
                datos.cargarConsulta(query);
                datos.leerDatos();

                while (datos.da.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id_Categoria = (int)datos.da["Id"];
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
    }
}
