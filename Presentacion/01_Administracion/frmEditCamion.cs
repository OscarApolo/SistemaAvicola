using Entidades._01_Administracion;
using Logica._01_Administracion;
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

namespace Presentacion._01_Administracion
{
    public partial class frmEditCamion : Form
    {
        public frmEditCamion()
        {
            InitializeComponent();
        }
        private int _idEmpleado;

        EmpleadoLN oln = new EmpleadoLN();

        private void mostrarChoferes()
        {
            comboBox1.DataSource = oln.ShowEmpleadoPorTipo("Chofer");
            comboBox1.SelectedIndex = 0;
            comboBox1.DisplayMember = "NombresApellidos";
            comboBox1.ValueMember = "Codigo";
        }



        public CamionE CrearObjeto()
        {
            int cod = Convert.ToInt32(textBox1.Text);
            int idEmpleado = (int)comboBox1.SelectedValue;
            string placa = textBox2.Text;
            string marca = textBox3.Text;
            decimal capacidadKg = decimal.Parse(textBox4.Text);
            CamionE ca = new CamionE(cod, idEmpleado, placa, marca, capacidadKg);
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

        public void setDatos(CamionE op)
        {
            textBox1.Text = op.IdCamion.ToString();
            _idEmpleado = op.IdEmpleado;
            textBox2.Text = op.Placa;
            textBox3.Text = op.Marca;
            textBox4.Text = op.CapacidadKG.ToString();
        }

        private void frmEditCamion_Load(object sender, EventArgs e)
        {
            mostrarChoferes();
            comboBox1.SelectedValue = _idEmpleado;
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
