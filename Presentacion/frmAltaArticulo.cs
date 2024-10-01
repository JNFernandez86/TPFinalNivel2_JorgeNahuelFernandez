using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using Logica;
using Negocio;


namespace Presentacion
{
    public partial class frmAltaArticulo : Form
    {
        #region Variables Globales
        private Articulo articulo = null;
        private Funciones func = new Funciones();
        private OpenFileDialog archivo = null;
        #endregion
        public frmAltaArticulo()
        {
            InitializeComponent(); 
        }
        public frmAltaArticulo(Articulo art)
        {
            InitializeComponent();
            this.articulo = art;
            Text = "Modificar Articulos";
            btnAceptar.Text = "Actualizar";
        }

        #region Funciones Principales
        //Carga del formulario Alta articulo cuando se carga
        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
           try
            {
                //llenado con las opciones de combobox
                func.cargarComboBox(cboMarca);
                func.cargarComboBox(cboCategoria);
                cboCategoria.Enabled = false;
                cboMarca.Enabled = false;
             
                //Obtención de datos del articulo seleccionado en el form Artículos
                if (articulo != null) 
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtImagenURL.Text = articulo.UrlImagen;
                    func.cargarImagen(articulo.UrlImagen,pbxImagen);
                    cboCategoria.SelectedValue = articulo.Categoria.IdCategoria;
                    cboMarca.SelectedValue = articulo.Marca.IdMarca;
                    txtPrecio.Text = articulo.Precio.ToString("##.##");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocioArt = new ArticuloNegocio();

            try
            {
                if (articulo == null)
                    articulo = new Articulo();

                articulo.Codigo = txtCodigo.Text.ToUpper();
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                articulo.UrlImagen = txtImagenURL.Text;
                articulo.Precio = Convert.ToDecimal(txtPrecio.Text);

                if (articulo.IdArticulo != 0)
                {
                    controlImagen();
                    negocioArt.modificarArticulo(articulo);
                   
                    MessageBox.Show("Artículo Modificado exitosamente");
                }
                else
                {
                    controlImagen();
                    negocioArt.agregarArticulo(articulo);
                    
                    MessageBox.Show("Articulo agregado exitosamente");
                }
                                     
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error, comuniquese con el Administrador del sistema");
            }
            Close();
        }

        private void controlImagen()
        {
            try
            {
                if ((archivo != null && archivo.FileName != string.Empty ) && !(txtImagenURL.Text.ToUpper().Contains("HTTP")))
                {
                   
                        string nombrearchivo = (ConfigurationManager.AppSettings["Imagenes"] + archivo.SafeFileName);
                        if (!File.Exists(nombrearchivo))
                        {
                            File.Copy(archivo.FileName, ConfigurationManager.AppSettings["Imagenes"] + archivo.SafeFileName);
                        }
 
                }
            }

            catch (Exception)
            { 
                MessageBox.Show("Error, comuniquese con el Administrador del sistema");
            }
           
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Eventos de botones 
        
        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            string tabla = "Categoria";
            frmAltas altas = new frmAltas(tabla);
            altas.ShowDialog();
            func.cargarComboBox(cboCategoria);
        }
        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            string tabla = "Marca";
            frmAltas altas = new frmAltas(tabla);
            altas.ShowDialog();
            func.cargarComboBox(cboMarca);
        }
        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "png|*.png*|jpg|*.jpg*|jpeg|*.jpeg";
            if (archivo.ShowDialog() == DialogResult.OK)
            {
                txtImagenURL.Text = (ConfigurationManager.AppSettings["Imagenes"] + archivo.SafeFileName);
                func.cargarImagen(archivo.FileName, pbxImagen);
            }
            else
            {
                txtImagenURL.Text = "C:\\Imagenes\\no-photo-available.png";
            }
        }
        #endregion

        #region Otros Eventos 
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.Isnumeric(e);
        }
        
        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                cboCategoria.Enabled = false;
                cboMarca.Enabled = false;
            }
            else
            {
                cboCategoria.Enabled = true;
                cboMarca.Enabled = true;
            }
        }
        private void txtImagenURL_Leave(object sender, EventArgs e)
        {
            func.cargarImagen(txtImagenURL.Text, pbxImagen);
        }

        #endregion
    }
}
