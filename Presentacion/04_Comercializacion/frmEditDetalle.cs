using Entidades._02_Produccion;
using Entidades._03_Procesamiento;
using Entidades._04_Comercializacion;
using Logica._03_Procesamiento;
using Logica._04_Comercializacion;
using Presentacion._03_Procesamiento;
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
    public partial class frmEditDetalle : Form
    {
        public frmEditDetalle()
        {
            InitializeComponent();
        }
        LoteFaenadoLN oln = new LoteFaenadoLN();
        VentaLN olne = new VentaLN();

        private void mostrarFacturas()
        {
            comboBox1.DisplayMember = "NroFac";
            comboBox1.ValueMember = "IdVenta";
            comboBox1.DataSource = olne.ShowVentas();
        }

        private void mostrarIdsLote()
        {
            comboBox2.DisplayMember = "IdProducto";
            comboBox2.ValueMember = "IdProducto";
            comboBox2.DataSource = oln.ShowLoteFaenado();
        }
        public DetalleVentaE CrearObjeto()
        {
            int cod = Convert.ToInt32(textBox1.Text);
            int idVenta = (int)comboBox1.SelectedValue;
            int idProducto = (int)comboBox2.SelectedValue;
            int cantVendida = int.Parse(textBox2.Text);
            decimal pUnitario = decimal.Parse(textBox3.Text);
            decimal subtotal = decimal.Parse(textBox4.Text);
            DetalleVentaE ca = new DetalleVentaE(cod, idVenta, idProducto, cantVendida, pUnitario, subtotal);
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
            if (comboBox2.SelectedValue != null && !(comboBox2.SelectedValue is Lote_FaenadoE))
            {
                int id = Convert.ToInt32(comboBox2.SelectedValue);

                Lote_FaenadoE lote = oln.obtenerLoteFaenadoporId(id);

                if (lote != null)
                {
                    textBox5.Text = lote.StockActual.ToString();
                }
            }
        }


        private void frmEditDetalle_Load(object sender, EventArgs e)
        {
            mostrarFacturas();
            mostrarIdsLote();
            textBox4.Text = "0.00";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarStock();
        }

        private void calcularSubtotal()
        {
            if(int.TryParse(textBox2.Text, out int cantidad))
            {
                textBox4.Text = (cantidad * 7.50).ToString("N2");

            } else
            {
                textBox4.Text = "0.00";
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            calcularSubtotal();
        }
    }
}
