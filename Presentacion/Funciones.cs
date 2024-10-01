using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Presentacion
{
    public class Funciones
    {
       #region Funciones para ComboBox
        public void cargarComboBox(ComboBox secundario, ComboBox principal,TextBox txt)
        {

            if (principal.SelectedItem.ToString() == "Precio")
            {
                secundario.Items.Clear();
                secundario.Items.Add("Igual a");
                secundario.Items.Add("Mayor a");
                secundario.Items.Add("Menor a");
            }
            else
            {
                secundario.Items.Clear();
                secundario.Items.Add("Contiene");
                secundario.Items.Add("Termina con");
                secundario.Items.Add("Comienza con");
            }
            secundario.Enabled = true;            
            txt.Text = string.Empty;
            txt.Enabled = false;
        }
        public void cargarComboBox(ComboBox combo)
        {
            CategoriaNegocio negocioCategoria = new CategoriaNegocio();
            MarcaNegocio negocioMarca = new MarcaNegocio();
            string nombre = "";

            try
            {
                nombre = combo.Name;

                if (combo.Name == "cboMarca")
                {
                    // combo.DataSource = null;
                    combo.DataSource = negocioMarca.listarMarca();
                    combo.ValueMember = "IdMarca";
                    combo.DisplayMember = "Descripcion";
                }
                else
                {
                    combo.DataSource = null;
                    combo.DataSource = negocioCategoria.listarCategoria();
                    combo.ValueMember = "IdCategoria";
                    combo.DisplayMember = "Descripcion";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
       #region Funciones para el manejo de imagenes
        public void copiarImagenes(DirectoryInfo resources, DirectoryInfo carpetaDestino)
        {
            //copia las imagenes de la carpeta resource del proyecto a la carpeta creada para alaojar las imagenes "C:\Imagenes\"
            foreach (FileInfo fi in resources.GetFiles())
            {
                fi.CopyTo(Path.Combine(carpetaDestino.ToString(), fi.Name), true);
            }

        }
        public void cargarImagen(string imagen, PictureBox pbx)
        {
            //Carga la imagen dependiendo del URL en el campo ImagenURL:
            string url = setearCarpetaRecursos();
            string nophotoavaiable = url + "no-photo-available.png";
            string error404 = url + "error-4041.jpg";
            try
            {
                if (imagen == null || imagen == string.Empty)
                {
                    pbx.Load(nophotoavaiable);
                }
                else
                {
                    pbx.Load(imagen);
                }
            }
            catch (FileNotFoundException)
            {
                pbx.Load(nophotoavaiable);
            }
            catch (WebException)
            {
                pbx.Load(error404);
            }
            catch (ArgumentException)
            {
                pbx.Load(error404);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
       #region Funciones KeyPress
        //Funciones para controlar el ingreso solo texto o solo números con el cáracter de la coma (,)
        public KeyPressEventArgs IsLetter(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) | Char.IsWhiteSpace(e.KeyChar) | char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            return e;
        }
        public KeyPressEventArgs Isnumeric(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) | char.IsControl(e.KeyChar) | char.ToString(e.KeyChar) == ",")
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            return e;
        }
        #endregion
       #region Otras
        public string setearCarpetaRecursos()
        {
            //Función que crea el directorio para guardar las imagenes del proyecto
            string carpeta_recursos = @"Resources\";
            string ruta = System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            string url = System.IO.Path.Combine(ruta, carpeta_recursos);
            return url;
        }
        public void seteoDatagridview(DataGridView dgv)
        {
            //vista de/los datagridview
            dgv.Columns["UrlImagen"].Visible = false;
            dgv.Columns["IdArticulo"].Visible = false;
            dgv.Columns["Precio"].DefaultCellStyle.Format = "c";
            dgv.RowHeadersWidth = (int)(dgv.Width * 0.04);
            dgv.Columns[1].Width = (int)(dgv.Width * 0.08);
            dgv.Columns[2].Width = (int)(dgv.Width * 0.20);
            dgv.Columns[3].Width = (int)(dgv.Width * 0.40);
            dgv.Columns[4].Width = (int)(dgv.Width * 0.1);
            dgv.Columns[5].Width = (int)(dgv.Width * 0.1);
            dgv.Columns[7].Width = (int)(dgv.Width * 0.125);

        }
        public bool validarRadioButtomActivo(RadioButton radiobtn)
        {
            //Funcion que chequea si un control RadioButton esta activo
            if (radiobtn.Checked)
                return true;
            else
                return false;
        }

        #endregion

    }
}
