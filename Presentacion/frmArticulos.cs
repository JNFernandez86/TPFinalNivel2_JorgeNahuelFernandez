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
    public partial class frmArticulos : Form
    {
        private AccesoDatos nueva = new AccesoDatos();
        private List<Articulos> ListaArt = new List<Articulos>();
        public frmArticulos()
        {
            InitializeComponent();
        }

        public void ocultarColumnas()
        {
            dgvArticulos.Columns[0].Visible = false;
            dgvArticulos.Columns[6].Visible = false;
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {


        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            

        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            NegocioArticulos negocioArt = new NegocioArticulos();

            try
            {
                ListaArt = negocioArt.ListarArticulos();
                dgvArticulos.DataSource = ListaArt;
                ocultarColumnas();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }



        }

        private void pbxImagenArticulo_Click(object sender, EventArgs e)
        {
            
        }
    }
}

