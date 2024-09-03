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
using Logica;
using Negocio;

namespace Presentacion
{
    public partial class frmAltaArticulo : Form
    {
        private Articulo articulo = null;
        ArticuloNegocio negocioArt;
        private string query;

        public frmAltaArticulo()
        {
            InitializeComponent();
            
        }

        public frmAltaArticulo(Articulo art)
        {
            InitializeComponent();
            this.articulo = art;
            Text = "Modificar Articulos";
            btnAceptar.Text = "Actualizar Artículos";
        }

      
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            
            try
            {
                cargarCombobox();
                if (articulo != null) 
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtImagenURL.Text = articulo.UrlImagen;
                    cboMarca.SelectedValue = articulo.Marca;
                    cboCategoria.SelectedValue = articulo.Categoria;
                    txtPrecio.Text = articulo.Precio.ToString("c");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
            
        }

        private void cargarCombobox()
        {
            CategoriaNegocio negocioCategoria = new CategoriaNegocio();
            MarcaNegocio negocioMarca = new MarcaNegocio();
            cboCategoria.DataSource = negocioCategoria.listarcat();
            cboCategoria.ValueMember = "Id_Categoria";
            cboCategoria.DisplayMember = "Descripcion";
            cboMarca.DataSource = negocioMarca.listarMarca();
            cboMarca.ValueMember = "IdMarca";
            cboMarca.DisplayMember = "Descripcion";
            //cboCategoria.SelectedIndex = -1;
            //cboMarca.SelectedIndex = -1;
            //cboMarca.Visible = false;
            //cboCategoria.Visible = false;
            

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            negocioArt = new ArticuloNegocio();


            try
            {
                if (articulo == null)
                    articulo = new Articulo();


                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                articulo.UrlImagen = txtImagenURL.Text;
                articulo.Precio = Convert.ToDecimal(txtPrecio.Text);

                if (articulo.Codigo != string.Empty)
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

                throw ex;
            }
            Close();

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            //if (txtCodigo.Text == string.Empty)
            //{
            //    cboCategoria.Visible = false;
            //    cboMarca.Visible = false;
            //}
            //else
            //{
            //    cboCategoria.Visible = true;
            //    cboMarca.Visible = true;
            //}
        }
    }
}
