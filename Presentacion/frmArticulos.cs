using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Configuration;
using Logica;
using Negocio;
using System.IO;

namespace Presentacion
{
    public partial class frmArticulos : Form
    {
        #region Variables Globales
        
        private List<Articulo> ListaArt;
        Articulo seleccionado;
        Funciones func = new Funciones();

        #endregion
        public frmArticulos()
        {
            InitializeComponent();
        }

        #region Funciones Locales
        public void crearDirectorio()
        {
            try
            {
                string ruta = @"C:\Imagenes"
;               string bkp = @"C:\Imagenes\temp";
                if (!Directory.Exists(ruta))
                    Directory.CreateDirectory(ruta);
                    if(!Directory.Exists(bkp))
                    Directory.CreateDirectory(bkp);


            }
            catch (Exception)
            {

                throw;
            }
        }
        public void cargar()
        {
            
            ArticuloNegocio negocioArt = new ArticuloNegocio();
                       
            try
            {
                crearDirectorio();
                txtBusqueda.Enabled = true; 
                ListaArt = negocioArt.mostrar();
                dgvArticulos.DataSource = ListaArt;
                func.seteoDatagridview(dgvArticulos);
                pbxImagenArticulo.Load();
                txtBusqueda.Enabled = true;
                lblAyudaCampo.Visible = false;
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
            }
            catch (SqlException)
            {
                MessageBox.Show("No posee conexión a la base de datos o la base de datos no existe, Comuniquese con el departamento de IT");
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
            seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmAltaArticulo frm = new frmAltaArticulo(seleccionado);
            frm.ShowDialog();
            cargar();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                Articulo seleccion = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
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
            try
            {
                if (dgvArticulos.CurrentRow != null)
                {
                    Articulo select = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    func.cargarImagen(select.UrlImagen, pbxImagenArticulo);
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
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
                gbxFiltroAvanzado.Visible = true;
                func.cargarComboBox(cboCriterio, rdbNombre, txtBusqueda);
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
                txtBusqueda.Text = string.Empty;
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
            Application.Exit();
            this.Dispose();
        }
        #endregion
        private bool validarRadioButtomActivo()
        {
                if (rdbNombre.Checked || rdbDescripcion.Checked || rdbDescripcion.Checked)
                    return true;
                else 
                    return false;
        }
        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }
    }
}

