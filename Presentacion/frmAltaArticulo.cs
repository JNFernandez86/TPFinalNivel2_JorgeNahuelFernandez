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
        private Articulo articulo = null;
        private Funciones func = new Funciones();
        private OpenFileDialog archivo = null;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
           try
            {
                func.cargarComboBox(cboMarca);
                func.cargarComboBox(cboCategoria);
             
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

                if (archivo != null && !(txtImagenURL.Text.ToUpper().Contains("HTTP")))
                {
                    string nombrearchivo = (ConfigurationManager.AppSettings["Imagenes"] + archivo.SafeFileName);
                    if (!File.Exists(nombrearchivo))
                    {
                        File.Copy(archivo.FileName, ConfigurationManager.AppSettings["Imagenes"] + archivo.SafeFileName);
                    }
                }

                if (articulo.IdArticulo != 0)
                {
                    negocioArt.modificarArticulo(articulo);
                    MessageBox.Show("Artículo Modificado exitosamente");
                }
                else
                {
                    negocioArt.agregarArticulo(articulo);
                    MessageBox.Show("Articulo agregado exitosamente");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            Close();
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
            func.cargarImagen(txtImagenURL.Text,pbxImagen);
        }
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

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones func = new Funciones();
            func.Isnumeric(e);
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "png|*.png;|jpg|*.jpg";
            if(archivo.ShowDialog() == DialogResult.OK)
            {
                txtImagenURL.Text = archivo.FileName;
                func.cargarImagen(archivo.FileName,pbxImagen);
            }
        }
    }
}
