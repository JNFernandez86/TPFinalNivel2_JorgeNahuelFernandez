using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public class Funciones
    {
        public void cargarcombobox(ComboBox cmb, RadioButton rdb, TextBox txt)
        {
            cmb.Items.Clear();
            if (rdb.Checked == true && rdb.Text == "Precio")
            {
                cmb.Items.Add("Igual a");
                cmb.Items.Add("Mayor a");
                cmb.Items.Add("Menor a");
                
            }
            else
            {
                cmb.Items.Add("Contiene");
                cmb.Items.Add("Termina con");
                cmb.Items.Add("Comienza con");
            }
            cmb.Enabled = true;
            cmb.Text = "Seleccione la opción";
            cmb.Focus();
            txt.Text = string.Empty;
            txt.Enabled = false;
        }
        public void seteoDatagridview(DataGridView dgv)
        {
            dgv.Columns["UrlImagen"].Visible = false;
            dgv.Columns["IdArticulo"].Visible = false;
            dgv.Columns["Precio"].DefaultCellStyle.Format = "c";
            dgv.RowHeadersVisible = false;
            dgv.Columns[1].Width = (int)(dgv.Width * 0.05);
            dgv.Columns[2].Width = (int)(dgv.Width * 0.20);
            dgv.Columns[3].Width = (int)(dgv.Width * 0.35);
            dgv.Columns[4].Width = (int)(dgv.Width * 0.10);
            dgv.Columns[5].Width = (int)(dgv.Width * 0.10);
            dgv.Columns[7].Width = (int)(dgv.Width * 0.10);
        }

    }
}
