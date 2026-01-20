using Entidades._02_Produccion;
using Entidades._03_Procesamiento;
using Logica._01_Administracion;
using Logica._02_Produccion;
using Logica._03_Procesamiento;
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

namespace Presentacion._03_Procesamiento
{
    public partial class frmEditOrden : Form
    {
        public frmEditOrden()
        {
            InitializeComponent();
        }
        EmpleadoLN oln = new EmpleadoLN();
        LoteLN olne = new LoteLN();

        private void MostrarFaenadores()
        {
            comboBox2.DisplayMember = "NombresApellidos";
            comboBox2.ValueMember = "Codigo";
            comboBox2.DataSource = oln.ShowEmpleadoPorTipo("Faenador");

        }
        private void MostrarLotes()
        {
            comboBox1.DisplayMember = "Codigo";
            comboBox1.ValueMember = "IdLote";
            comboBox1.DataSource = olne.ShowLote();

        }
        public Orden_FaenadoE CrearObjeto()
        {
            int cod = Convert.ToInt32(textBox1.Text);
            int idLote = (int)comboBox1.SelectedValue;
            int idEmpleado = (int)comboBox2.SelectedValue;
            DateTime fechaFaena= dateTimePicker1.Value;
            int avesProcesadas = int.Parse(textBox2.Text);
            decimal pesoTotal = decimal.Parse(textBox3.Text);
            Orden_FaenadoE ca = new Orden_FaenadoE(cod, idLote, idEmpleado, fechaFaena, avesProcesadas, pesoTotal);
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
        private void actualizarStock()
        {
            if (comboBox1.SelectedValue != null && !(comboBox1.SelectedValue is LoteE))
            {
                int id = Convert.ToInt32(comboBox1.SelectedValue);

                LoteE lote = olne.obtenerporId(id);

                if (lote != null)
                {
                    textBox6.Text = lote.StockActual.ToString();
                }
            }
        }
        private void frmEditOrden_Load(object sender, EventArgs e)
        {
            MostrarLotes();
            MostrarFaenadores();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarStock();
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
