using Entidades._02_Produccion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Presentacion._02_Produccion
{
    public partial class frmEditGalpon : Form
    {
        public frmEditGalpon()
        {
            InitializeComponent();
        }
        public GalponE CrearObjeto()
        {
            int cod = Convert.ToInt32(textBox1.Text);
            string nombre = textBox2.Text;
            int capMaxima = int.Parse(textBox3.Text);
            string ubicacion = textBox4.Text;
            string estado = comboBox1.SelectedItem.ToString();
            GalponE ca = new GalponE(cod, nombre, capMaxima, ubicacion, estado);
            return ca;
        }
        public bool ValidarDatos()
        {
            bool value = true;
            if (textBox1.Text.Trim().Length == 0 && textBox2.Text.Trim().Length == 0 && textBox3.Text.Trim().Length == 0 &&
                textBox4.Text.Trim().Length == 0)
            {
                value = false;
            }
            return value;
        }
        public void Guardar()
        {
            try
            {
                if (ValidarDatos())
                {
                    this.DialogResult = DialogResult.OK;

                }
                else
                    MessageBox.Show("Los campos con (*) son obligatorios");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void setDatos(GalponE op)
        {
            textBox1.Text = op.IdGalpon.ToString();
            textBox2.Text = op.Nombre;
            textBox3.Text = op.CapMaxima.ToString();
            textBox4.Text = op.Ubicacion;
            comboBox1.SelectedItem = op.Estado;
        }

        private void frmEditGalpon_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
