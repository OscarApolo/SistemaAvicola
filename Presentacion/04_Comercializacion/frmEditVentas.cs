using Entidades._01_Administracion;
using Entidades._04_Comercializacion;
using Logica._01_Administracion;
using Logica._04_Comercializacion;
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
    public partial class frmEditVentas : Form
    {
        public frmEditVentas()
        {
            InitializeComponent();
        }
        EmpleadoLN oln = new EmpleadoLN();
        ClienteLN olne = new ClienteLN();
        CamionLN olnex = new CamionLN();
        private void MostrarVendedores()
        {
            comboBox3.DisplayMember = "NombresApellidos";
            comboBox3.ValueMember = "Codigo";
            comboBox3.DataSource = oln.ShowEmpleadoPorTipo("Vendedor");

        }
        private void MostrarClientes()
        {
            comboBox1.DisplayMember = "RazonSocial";
            comboBox1.ValueMember = "IdCliente";
            comboBox1.DataSource = olne.ShowClientes();

        }
        private void MostrarCamiones()
        {
            comboBox2.DisplayMember = "Placa";
            comboBox2.ValueMember = "IdCamion";
            comboBox2.DataSource = olnex.ShowCamion();

        }

        public VentaE CrearObjeto()
        {
            int cod = Convert.ToInt32(textBox1.Text);
            int idCliente= (int) comboBox1.SelectedValue;
            int idCamion = (int)comboBox2.SelectedValue;
            int idEmpleado = (int)comboBox3.SelectedValue;
            string nroFac = textBox2.Text;
            DateTime fecha = dateTimePicker1.Value;
            decimal taotalVenta = decimal.Parse(textBox3.Text);
            string estado = comboBox4.SelectedItem.ToString();
            VentaE ca = new VentaE(cod, idCliente, idCamion, idEmpleado, nroFac, fecha, taotalVenta, estado);
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

        private void frmEditVentas_Load(object sender, EventArgs e)
        {
            MostrarVendedores();
            MostrarClientes();
            MostrarCamiones();
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
