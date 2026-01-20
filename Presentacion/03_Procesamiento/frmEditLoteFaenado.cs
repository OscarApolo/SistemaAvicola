using Entidades._02_Produccion;
using Entidades._03_Procesamiento;
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
    public partial class frmEditLoteFaenado : Form
    {
        public frmEditLoteFaenado()
        {
            InitializeComponent();
        }
        OrdenLN oln = new OrdenLN();
        LoteFaenadoLN olne = new LoteFaenadoLN();
        
        private void mostrarOrdenFaena()
        {
            comboBox1.DisplayMember = "IdOrden";
            comboBox1.ValueMember = "IdOrden";
            comboBox1.DataSource = oln.ShowOrdenFaenado();
        }
        public Lote_FaenadoE CrearObjeto()
        {
            int cod = Convert.ToInt32(textBox1.Text);
            int idOrden = (int) comboBox1.SelectedValue;
            int cantFaenada = int.Parse(textBox2.Text);
            decimal pesoTotal = decimal.Parse(textBox3.Text);
            DateTime fechVencimiento = dateTimePicker1.Value;

            
            Lote_FaenadoE ca = new Lote_FaenadoE(cod, idOrden, cantFaenada, pesoTotal, fechVencimiento, cantFaenada);
            return ca;
        }
        public bool ValidarDatos()
        {
            bool value = true;
            if (textBox1.Text.Trim().Length == 0 && textBox2.Text.Trim().Length == 0 && textBox3.Text.Trim().Length == 0)
            {
                value = false;
            }
            int cantAntesFaena = int.Parse(textBox6.Text);
            int cantFinal = int.Parse(textBox2.Text);
            if(cantFinal > cantAntesFaena)
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
                    MessageBox.Show(
                        "La cantidad final no puede exceder el ingreso inicial a faena.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void actualizarStock()
        {
            if (comboBox1.SelectedValue != null && !(comboBox1.SelectedValue is Orden_FaenadoE))
            {
                int id = Convert.ToInt32(comboBox1.SelectedValue);

                Orden_FaenadoE loteFaenado = olne.obtenerporId(id);

                if (loteFaenado != null)
                {
                    textBox6.Text = loteFaenado.AvesProcesadas.ToString();
                }
            }
        }

        private void frmEditLoteFaenado_Load(object sender, EventArgs e)
        {
            mostrarOrdenFaena();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarStock();
        }
    }
}
