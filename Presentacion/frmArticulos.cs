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
       private ConexionBD nueva = new ConexionBD();

        private void btnConectar_Click(object sender, EventArgs e)
        {
       
            try
            {
                nueva.abrirConexion();
                MessageBox.Show("Se ha conectado a la BD");

            }catch(Exception ex)
            {
                MessageBox.Show("No se encuentra el servidor de la BD");
            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            try
            {
                nueva.cerraConexion();
                    MessageBox.Show("Se ha desconectado a la BD");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {

        }
    }
}
