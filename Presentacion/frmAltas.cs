using Logica;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmAltas : Form
    {

        
        
        string tabla1;
        public frmAltas()
        {
            InitializeComponent();
        }
        public frmAltas(string tipo)
        {
            
            InitializeComponent();
            if(tipo == "Categoria")
            {
                Text = "Agregar Categoría";
                tabla1 = "Categoria";
            }
            else
            {
                Text = "Agregar Marca";
                tabla1 = "Marca";
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAltas_Load(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negociocategoria = new CategoriaNegocio();
            MarcaNegocio negociomarcas = new MarcaNegocio();
            Marca marcanueva = new Marca();
            Categoria catNueva = new Categoria();

            try
            {
                if (tabla1 == "Categoria")
                {
                    catNueva.Descripcion = txtDescripcion.Text;
                    negociocategoria.nuevaCategoria(catNueva);
                    MessageBox.Show("Categoría Agregada");
                    Close();
                }
                else 
                {
                    marcanueva.Descripcion = txtDescripcion.Text;
                    negociomarcas.nuevaMarca(marcanueva);
                    MessageBox.Show("Marca Agregada");
                    Close();
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (txtDescripcion.Text.Length >= 3)
                btnAgregar.Enabled = true;

            else
                btnAgregar.Enabled = false;

        }
    }
}
