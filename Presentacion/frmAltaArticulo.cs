using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public void cargarComboBox()
        {

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
        }
        
    }
}
