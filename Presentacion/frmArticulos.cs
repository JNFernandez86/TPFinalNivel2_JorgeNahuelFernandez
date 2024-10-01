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
        private void crearDirectorio()
        {
            string folderimages = @"C:\Imagenes";
            DirectoryInfo ruta = new DirectoryInfo(func.setearCarpetaRecursos());
            DirectoryInfo archivo = new DirectoryInfo(folderimages);

            try
            {
                if (!Directory.Exists(folderimages))
                {
                    Directory.CreateDirectory(folderimages);
                }

                func.copiarImagenes(ruta, archivo);

            }
            catch (Exception)
            {

                MessageBox.Show("No se ha podido crear la carpeta para alojar las imágenes");
            }
        }
        private void cargar()
        {
            ArticuloNegocio negocioArt = new ArticuloNegocio();
            try
            {
                txtBusqueda.Enabled = true;
                ListaArt = negocioArt.mostrar();
                dgvArticulos.DataSource = ListaArt;
                func.seteoDatagridview(dgvArticulos);
                txtBusqueda.Enabled = true;
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
        private void cargaComboCampo()
        {
            cboCampo.Items.Clear();
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripción");
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Categoría");
            cboCampo.Items.Add("Precio");
        }
        private void buscarAvanzado()
        {
            ArticuloNegocio neg = new ArticuloNegocio();
            try
            {
            
                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();

                dgvArticulos.DataSource = neg.buscar(txtBusqueda.Text, campo, criterio);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region Eventos Principales
        private void frmArticulos_Load(object sender, EventArgs e)
        {
            cargar();
            crearDirectorio();
            gbxFiltroAvanzado.Visible = false;
            txtBusqueda.Enabled = true;
            btnBuscar.Visible = false;

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
        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
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
        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboCampo.SelectedIndex != -1)
            {
                func.cargarComboBox(cboCriterio, cboCampo, txtBusqueda);
                cboCriterio.Enabled = true;
                txtBusqueda.Focus();
            }
            else
            {
                cboCriterio.Enabled = false;

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
                {
                    btnBuscar.Enabled = true;
                }
            }
            else
            {
                dgvArticulos.DataSource = negocio.mostrar();
                btnBuscar.Enabled=false;
            }
        }
        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (chbFiltroAvanzado.Checked == true)
            {
                if (cboCampo.SelectedItem.ToString() == "Precio")
                    func.Isnumeric(e);

                if (cboCampo.SelectedItem.ToString() == "Categoría" || cboCampo.SelectedItem.ToString() == "Marca")
                    func.IsLetter(e);
            }

        }

        private void chbFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            //Habilitación de opciones avanzadas para la busqueda con condiciones
            if (chbFiltroAvanzado.Checked == true)
            {
                cargaComboCampo();
                gbxFiltroAvanzado.Visible = true;
                cboCriterio.Enabled = false;
                txtBusqueda.Enabled = false;
                btnBuscar.Visible = true;
                btnBuscar.Enabled = false;
            }
            else
            {
                gbxFiltroAvanzado.Visible = false;
                btnBuscar.Visible = false;
                txtBusqueda.Enabled = true;
                txtBusqueda.Focus();
                cargar();
            }
        }
       
        private void llbSalir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Finalización de applicación
            if(MessageBox.Show("¿Esta seguro que desea cerrar la aplicación?","Fin de Programa",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Gracias por utilizar nuestro sistema de inventario");
                Application.Exit();
                this.Dispose();
            }
           
            
        }
        #endregion

        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == string.Empty)
            {
                MessageBox.Show("Por favor ingrese el texto a buscar");
                if (cboCampo.SelectedIndex == -1)
                {
                    MessageBox.Show("No ha seleccionado ningún elemento del menú de 'Campo'");
                    if (cboCriterio.SelectedIndex != -1)
                    {
                        MessageBox.Show("No ha seleccionado ningún elemento del menú de 'Criterio'");
                    }
                }
            }
                buscarAvanzado();
        }
    }

}