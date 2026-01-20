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

namespace Presentacion._01_Administracion
{
    public partial class frmEditEmpleado : Form
    {
        public frmEditEmpleado()
        {
            InitializeComponent();
        }

        private int _idCargo;

        CargoLN oln = new CargoLN();

        private void mostrarCargos()
        {
            comboBox1.DataSource = oln.ShowCargo();
            comboBox1.SelectedIndex = 0;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "IdCargo";
        }



        public EmpleadoE CrearObjeto()
        {
            int cod = Convert.ToInt32(textBox1.Text);
            int idCargo = (int)comboBox1.SelectedValue;
            string cedula = textBox2.Text;
            string nombre = textBox3.Text;
            string apellido = textBox4.Text;
            string ciudad = textBox5.Text;
            string direccion = textBox6.Text;
            string telefono = textBox7.Text;
            string correo = textBox8.Text;
            EmpleadoE ca = new EmpleadoE(cod, idCargo, cedula, nombre, apellido, ciudad, direccion, telefono, correo);
            return ca;
        }
        public bool ValidarDatos()
        {
            bool value = true;
            if (textBox1.Text.Trim().Length == 0 && textBox2.Text.Trim().Length == 0 && textBox3.Text.Trim().Length == 0 &&
                textBox4.Text.Trim().Length == 0 && textBox5.Text.Trim().Length == 0 && textBox6.Text.Trim().Length == 0)
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

        public void setDatos(EmpleadoE op)
        {
            textBox1.Text = op.Codigo.ToString();
            _idCargo = op.IdCargo;
            textBox2.Text = op.Cedula;
            textBox3.Text = op.Nombre;
            textBox4.Text = op.Apellido;
            textBox5.Text = op.Ciudad;
            textBox6.Text = op.Direccion;
            textBox7.Text = op.Telefono;
            textBox8.Text = op.Correo;
        }

        private void frmEditEmpleado_Load(object sender, EventArgs e)
        {
            mostrarCargos();
            comboBox1.SelectedValue = _idCargo;
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
