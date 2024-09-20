using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public class Funciones
    {
        public void cargarComboBox(ComboBox cmb, RadioButton rdb, TextBox txt)
        {
            
            if (rdb.Checked == true && rdb.Text == "Precio")
            {
                cmb.Items.Clear();
                cmb.Items.Add("Igual a");
                cmb.Items.Add("Mayor a");
                cmb.Items.Add("Menor a");
            }
            else
            {
                cmb.Items.Clear();
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
        public void cargarComboBox(ComboBox combo)
        {
            CategoriaNegocio negocioCategoria = new CategoriaNegocio();
            MarcaNegocio negocioMarca = new MarcaNegocio();
            string nombre = "";

            try
            {
                nombre = combo.Name;
                
                if(combo.Name == "cboMarca")
                {
                   // combo.DataSource = null;
                    combo.DataSource = negocioMarca.listarMarca();
                    combo.ValueMember = "IdMarca";
                    combo.DisplayMember = "Descripcion";
                }
                else
                {
                    combo.DataSource = null;
                    combo.DataSource = negocioCategoria.listarCategoria();
                    combo.ValueMember = "IdCategoria";
                    combo.DisplayMember = "Descripcion";
                }
                  //combo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void seteoDatagridview(DataGridView dgv)
        {
            dgv.Columns["UrlImagen"].Visible = false;
            dgv.Columns["IdArticulo"].Visible = false;
            dgv.Columns["Precio"].DefaultCellStyle.Format = "c";
            dgv.RowHeadersWidth = (int)(dgv.Width * 0.04);
            dgv.Columns[1].Width = (int)(dgv.Width * 0.05);
            dgv.Columns[2].Width = (int)(dgv.Width * 0.20);
            dgv.Columns[3].Width = (int)(dgv.Width * 0.40);
            dgv.Columns[4].Width = (int)(dgv.Width * 0.075);
            dgv.Columns[5].Width = (int)(dgv.Width * 0.075);
            dgv.Columns[7].Width = (int)(dgv.Width * 0.15);
        }

        public KeyPressEventArgs IsLetter(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) | Char.IsWhiteSpace(e.KeyChar) | char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            return e;
        }

        public KeyPressEventArgs Isnumeric(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) | char.IsControl(e.KeyChar) | char.ToString(e.KeyChar) == ",")
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            return e;
        }
        public void cargarImagen(string imagen, PictureBox pbx)
        {
            string url = "https://archive.org/download/no-photo-available/no-photo-available.png";
            try
            {
                if (imagen == null || imagen == string.Empty)
                {
                    pbx.Load(url);
                }
                else
                {
                    pbx.Load(imagen);
                }
               
            }
            catch (FileNotFoundException) 
            {
                pbx.Load(url);
            }
           
            catch (WebException)
            {
               
                pbx.Load("https://www.adslzone.net/app/uploads-adslzone.net/2016/08/error-404.jpg");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
    }
}
