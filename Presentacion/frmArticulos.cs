using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Logica;
using Negocio;

namespace Presentacion
{
    public partial class frmArticulos : Form
    {
        private AccesoADatos nueva = new AccesoADatos();
        private List<Articulo> ListaArt = new List<Articulo>();
        Articulo seleccion;
        private ArticuloNegocio negocioArt;
        private string query;
        

        public frmArticulos()
        {
            InitializeComponent();
        }

        public void seteoDatagridview()
        {
            dgvArticulos.Columns["UrlImagen"].Visible = false;
            dgvArticulos.Columns["IdArticulo"].Visible = false;
            dgvArticulos.Columns["Precio"].DefaultCellStyle.Format = "c";
            dgvArticulos.RowHeadersVisible = false;
            dgvArticulos.Columns[1].Width = 50;
            dgvArticulos.Columns[2].Width = 120;
            dgvArticulos.Columns[3].Width = 350;
            dgvArticulos.Columns[4].Width = 75;
            dgvArticulos.Columns[5].Width = 75;
            dgvArticulos.Columns[7].Width = 90;
        }

        public void cargarImagen(string imagen)
        {
            try
            {
                pbxImagenArticulo.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxImagenArticulo.Load("https://static.thenounproject.com/png/261694-200.png");
                
            }
        }

        public void cargar()
        {
            negocioArt = new ArticuloNegocio();
            try
            {

                ListaArt = negocioArt.mostrar();
                dgvArticulos.DataSource = ListaArt;
                seteoDatagridview();
                gbxFiltroAvanzado.Visible = false;
                pbxImagenArticulo.Load(ListaArt[0].UrlImagen);
                btnBuscar.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

      public void cargarcombobox()
        {
            if (rdbPrecio.Checked == true)
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Igual a ");
                cboCriterio.Items.Add("Mayor a ");
                cboCriterio.Items.Add("Menor a ");
            }
            else
            {
                
                cboCriterio.Items.Add("Contiene ");
                cboCriterio.Items.Add("Termina con ");
                cboCriterio.Items.Add("Comienza con ");
            }

        }
  
        private void frmArticulos_Load(object sender, EventArgs e)
        {
            cargar();
        }

       private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaArticulo frm = new frmAltaArticulo();
            frm.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
           
            try
            {
                if(dgvArticulos.CurrentRow != null)
                {
                    seleccion = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    frmAltaArticulo frm = new frmAltaArticulo(seleccion);
                    frm.ShowDialog();
                    cargar();
                }
                else
                {
                    MessageBox.Show("No ha seleccionado ningún artículo");
                }
            }
           
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }         

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (dgvArticulos.CurrentRow != null)
                {

                    DialogResult rta = MessageBox.Show("Esta por eliminar un artículo, Desea Continuar?", "Alerta, ELIMINANDO...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (rta == DialogResult.Yes)
                    {
                        MessageBox.Show("Eliminado");
                        negocio.eliminarArticulo(seleccion.IdArticulo);
                        cargar();
                    }
                }
                else
                    
                    MessageBox.Show("No ha seleccionado ningún artículo");

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            Articulo elem = new Articulo();
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo select = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                cargarImagen(select.UrlImagen);
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if(txtBusqueda.Text.Length > 2)
            {
                btnBuscar.Enabled = true;
            }
            else
            {
                btnBuscar.Enabled =false;
            }
        }
          
              

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((chbFiltroAvanzado.Checked))
                {
                    if(!(rdbNombre.Checked || rdbDescripcion.Checked || rdbPrecio.Checked))
                    {
                        MessageBox.Show("No ha seleccionado ningún Campo, por favor de seleccionar uno");
                    }
                   
                    
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show( ex.ToString());
            }

        }

        private void rdbNombre_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chbFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            if (chbFiltroAvanzado.Checked)
            {
                gbxFiltroAvanzado.Visible = true;

            }
            else
            {
                gbxFiltroAvanzado.Visible = false;
            }
        }

        private void gbxABM_Enter(object sender, EventArgs e)
        {

        }
    }
}

