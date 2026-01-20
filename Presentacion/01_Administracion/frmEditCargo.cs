using Entidades._01_Administracion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion._01_Administracion
{
    public partial class frmEditCargo : Form
    {
        public frmEditCargo()
        {
            InitializeComponent();
        }

        public CargoE CrearObjeto()
        {
            int cod = Convert.ToInt32(textBox1.Text);
            string nombre = textBox2.Text;
            string descri = textBox3.Text;
            CargoE ca = new CargoE(cod, nombre, descri);
            return ca;
        }
        public bool ValidarDatos()
        {
            bool value = true;
            if (textBox1.Text.Trim().Length == 0 && textBox2.Text.Trim().Length == 0 && textBox3.Text.Trim().Length == 0)
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

        public void setDatos(CargoE op)
        {
            textBox1.Text = op.IdCargo.ToString();
            textBox2.Text = op.Nombre;
            textBox3.Text = op.Descripcion;
        }


        private void frmEditCargo_Load(object sender, EventArgs e)
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
