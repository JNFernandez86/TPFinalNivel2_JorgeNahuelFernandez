using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
        public frmArticulos()
        {
            InitializeComponent();
        }

        #region Variables Globales
        private Funciones func;
        private AccesoADatos nueva = new AccesoADatos();
        private List<Articulo> ListaArt = new List<Articulo>();
        Articulo seleccion;
        private ArticuloNegocio negocioArt;
        private string query;
        #endregion

        #region Funciones Locales

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
            func = new Funciones();
            negocioArt = new ArticuloNegocio();
            try
            {
                txtBusqueda.Enabled = true; 
                ListaArt = negocioArt.mostrar();
                dgvArticulos.DataSource = ListaArt;
                func.seteoDatagridview(dgvArticulos);
                pbxImagenArticulo.Load(ListaArt[0].UrlImagen);
                txtBusqueda.Enabled = true;
                lblAyuda.Visible = false;
            }
            catch (SqlException)
            {
                MessageBox.Show("Error al conectarse a la base! Comuniquese con el departamento de IT");
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void buscarAvanzado()
        {
            ArticuloNegocio neg = new ArticuloNegocio();
            try
            {
                string campo = "";
                string criterio = "";

                if (rdbNombre.Checked == true)
                    campo = "Nombre";
                else if (rdbDescripcion.Checked == true)
                    campo = "Descripcion";
                else
                    campo = "Precio";

                criterio = cboCriterio.SelectedItem.ToString();
                dgvArticulos.DataSource = neg.buscar(txtBusqueda.Text, campo, criterio);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region Eventos de Botones
        private void frmArticulos_Load(object sender, EventArgs e)
        {
            cargar();
            gbxFiltroAvanzado.Visible = false;
            txtBusqueda.Enabled = true;
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
                if (dgvArticulos.CurrentRow != null)
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
        #endregion

        #region Eventos otros controles
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
            ArticuloNegocio negocio = new ArticuloNegocio();

            if (txtBusqueda.Text.Length > 2)
            {
                if (chbFiltroAvanzado.Checked == false)
                    dgvArticulos.DataSource = negocio.buscar(txtBusqueda.Text, null, null);
                else
                    buscarAvanzado();  
            }
            else
            {
                dgvArticulos.DataSource = negocio.mostrar();
            }
        }
        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rdbPrecio.Checked == true)
            {
                func.Isnumeric(e);
            }
        }
        private void rdbNombre_CheckedChanged(object sender, EventArgs e)
        {
            bool activo = validarRadioButtomActivo();
            Funciones func = new Funciones();
            if (activo == true)
            {
                func.cargarComboBox(cboCriterio, rdbNombre, txtBusqueda);
            }
            else 
            {
                cboCriterio.Enabled = false;
            }
        }
        private void rdbDescripcion_CheckedChanged(object sender, EventArgs e)
        {
            Funciones func = new Funciones();
            func.cargarComboBox(cboCriterio, rdbDescripcion, txtBusqueda);
        }
        private void rdbPrecio_CheckedChanged(object sender, EventArgs e)
        {
            Funciones func = new Funciones();
            func.cargarComboBox(cboCriterio, rdbPrecio, txtBusqueda);
        }
        private void chbFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {

            if (chbFiltroAvanzado.Checked == true)
            {
                validarRdb();
                gbxFiltroAvanzado.Visible = true;
                txtBusqueda.Enabled = false;
                lblCampo.Focus();
            }
            else
            {
                gbxFiltroAvanzado.Visible = false;
                txtBusqueda.Enabled = true;
                cargar();
            }
        }
        private void cboCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCriterio.SelectedIndex != -1)
            {
                txtBusqueda.Enabled = true;
                txtBusqueda.Focus();
            }
            else
            {
                txtBusqueda.Enabled = false;
                cargar();
            }
        }
        private void llbSalir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        #endregion
        private void txtBusqueda_EnabledChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Enabled == false)
            {
                
            }
        }
        private bool validarRadioButtomActivo()
        {
                if (rdbNombre.Checked || rdbDescripcion.Checked || rdbDescripcion.Checked)
                    return true;
                else 
                    return false;
        }

        private void validarRdb()
        {
            RadioButton radioc = Container.Components.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (radioc != null) 
            {
                cboCriterio.Enabled = true;
            }
            else
            {
                txtBusqueda.Enabled = false;
            }
        }
    }
}

