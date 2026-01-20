using Entidades._02_Produccion;
using Logica._01_Administracion;
using Logica._02_Produccion;
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
    public partial class frmEditBitacoras : Form
    {
        public frmEditBitacoras()
        {
            InitializeComponent();
        }


        EmpleadoLN oln = new EmpleadoLN();
        LoteLN olne = new LoteLN();

        private void MostrarGalponeros()
        {
            comboBox1.DisplayMember = "NombresApellidos";
            comboBox1.ValueMember = "Codigo";
            comboBox1.DataSource = oln.ShowEmpleadoPorTipo("Galponero");

        }
        private void MostrarLotes()
        {
            comboBox2.DisplayMember = "Codigo";
            comboBox2.ValueMember = "IdLote";
            comboBox2.DataSource = olne.ShowLote();

        }
        public BitacoraDiariaE CrearObjeto()
        {
            int cod = Convert.ToInt32(textBox1.Text);
            int idEmpleado = (int) comboBox1.SelectedValue;
            int idLote = (int) comboBox2.SelectedValue;
            DateTime fecha = dateTimePicker1.Value;
            int mortalidad = int.Parse(textBox2.Text);
            decimal alimento = decimal.Parse(textBox3.Text);
            decimal pesoPromedio = decimal.Parse(textBox4.Text);
            string observaciones = textBox5.Text;
            BitacoraDiariaE ca = new BitacoraDiariaE(cod, idEmpleado, idLote, fecha, mortalidad, alimento, pesoPromedio, observaciones);
            return ca;
        }
        public bool ValidarDatos()
        {
            bool value = true;
            if (textBox1.Text.Trim().Length == 0 && textBox2.Text.Trim().Length == 0 && textBox3.Text.Trim().Length == 0 &&
                textBox4.Text.Trim().Length == 0 && textBox5.Text.Trim().Length == 0)
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

        private void frmEditBitacoras_Load(object sender, EventArgs e)
        {
            MostrarGalponeros();
            MostrarLotes();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void actualizarStockDisponible()
        {
            if (comboBox2.SelectedValue != null && !(comboBox2.SelectedValue is LoteE))
            {
                int id = Convert.ToInt32(comboBox2.SelectedValue);

                LoteE lote = olne.obtenerporId(id);

                if (lote != null)
                {
                    textBox6.Text = lote.StockActual.ToString();
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarStockDisponible();
        }
    }
}
