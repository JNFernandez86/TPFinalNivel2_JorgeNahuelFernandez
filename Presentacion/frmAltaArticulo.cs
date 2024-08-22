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
        private Articulos articulo = null;
        NegocioArticulos negocioArt;
        private string query;

        public frmAltaArticulo()
        {
            InitializeComponent();
            
        }

        public frmAltaArticulo(Articulos art)
        {
            InitializeComponent();
            this.articulo = art;
            Text = "Modifcar Articulos";
            btnAceptar.Text = "Actualizar Artículos";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            NegocioArticulos negocioArt = new NegocioArticulos();

            query = "Select * from Categorias";
            //cmbCategoria = llenarcmb(cmbCategoria, query);
            cmbCategoria.DataSource = negocioArt.ListarArticulos(query);
            cmbCategoria.ValueMember = "Id";
            cmbCategoria.DisplayMember = "Descripcion";
        }
        //private ComboBox llenarcmb(ComboBox cbo, string ssql)
        //{
        //    negocioArt = new NegocioArticulos();
            
        //    cbo.DataSource = negocioArt.ListarCategorias(ssql);

        //    return cbo;
        //}
    }
}
