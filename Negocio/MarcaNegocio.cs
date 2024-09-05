using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listarMarca()
        {
            AccesoADatos datos = new AccesoADatos();
            List<Marca> list_m = new List<Marca>();
            string query = ("Select Id, Descripcion From Marcas");

            try
            {
                datos.cargarConsulta(query);
                datos.leerDatos();

                while (datos.da.Read())
                {
                    Marca aux = new Marca();
                    aux.IdMarca = (int)datos.da["Id"];
                    aux.Descripcion = (string)datos.da["Descripcion"];
                    list_m.Add(aux);

                }
                return list_m;
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
        public void nuevaMarca(Marca marca)
        {
            AccesoADatos datos = new AccesoADatos();


            try
            {
                datos.cargarConsulta("INSERT INTO MARCAS (Descripcion) values (@marca)");
                datos.cargarParametros("@marca", marca.Descripcion);
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
