using Entidades._01_Administracion;
using Entidades._03_Procesamiento;
using Entidades._04_Comercializacion;
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

namespace Presentacion._04_Comercializacion
{
    public partial class frmEditCliente : Form
    {
        public frmEditCliente()
        {
            InitializeComponent();
        }
        public ClienteE CrearObjeto()
        {
            int cod = Convert.ToInt32(textBox1.Text);
            string razonSocial = textBox2.Text;
            string cedula = textBox3.Text;
            string ciudad = textBox4.Text;
            string direccion = textBox5.Text;
            string telefono = textBox6.Text;
            ClienteE ca = new ClienteE(cod, razonSocial, cedula, ciudad, direccion, telefono);
            return ca;
        }
        public bool ValidarDatos()
        {
            bool value = true;
            if (textBox1.Text.Trim().Length == 0 && textBox2.Text.Trim().Length == 0 && textBox3.Text.Trim().Length == 0
                && textBox4.Text.Trim().Length == 0 && textBox5.Text.Trim().Length == 0)
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
        public void setDatos(ClienteE op)
        {
            textBox1.Text = op.IdCliente.ToString();
            textBox2.Text = op.RazonSocial;
            textBox3.Text = op.Cedula;
            textBox4.Text = op.Ciudad;
            textBox5.Text = op.Direccion;
            textBox6.Text = op.Telefono;
        }

        private void frmEditCliente_Load(object sender, EventArgs e)
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

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
