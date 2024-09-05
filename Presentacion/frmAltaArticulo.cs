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
using static System.Net.Mime.MediaTypeNames;

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

        private void cargarImagen(string img)
        {
            try
            {
                pbxImagen.Load(img);
            }
            catch (Exception ex)
            {

                pbxImagen.Load("https://static.thenounproject.com/png/261694-200.png");
            }
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
                cboCategoria.SelectedIndex = -1;
                if (articulo != null) 
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtImagenURL.Text = articulo.UrlImagen;
                    cargarImagen(articulo.UrlImagen);
                    cboMarca.SelectedValue = articulo.Marca.IdMarca;
                    cboCategoria.SelectedValue = articulo.Categoria.Id_Categoria;
                    txtPrecio.Text = articulo.Precio.ToString("##.##");
                    
                }
                else
                {
                    cboCategoria.Enabled = false;
                    cboMarca.Enabled = false;
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

            try
            {
                cboCategoria.DataSource = negocioCategoria.listarcat();
                cboCategoria.ValueMember = "Id_Categoria";
                cboCategoria.DisplayMember = "Descripcion";
                cboMarca.DataSource = negocioMarca.listarMarca();
                cboMarca.ValueMember = "IdMarca";
                cboMarca.DisplayMember = "Descripcion";
                
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.ToString());
            }
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
            cargarImagen(txtImagenURL.Text);
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            string tabla = "Categoria";
            frmAltas altas = new frmAltas(tabla);
            altas.ShowDialog();
            cargarCombobox();

        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            string tabla = "Marca";
            frmAltas altas = new frmAltas(tabla);
            altas.ShowDialog();
            cargarCombobox();
        }
    }
}
