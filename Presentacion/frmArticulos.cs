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
        public frmArticulos()
        {
            InitializeComponent();
        }
       private AccesoDatos nueva = new AccesoDatos();

        private void btnConectar_Click(object sender, EventArgs e)
        {
       
           
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            NegocioArticulos articulos = new NegocioArticulos();

            articulos.ListarArticulos();
            
        }
    }
}
