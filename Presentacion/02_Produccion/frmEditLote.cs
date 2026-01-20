using Entidades._01_Administracion;
using Entidades._02_Produccion;
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
    public partial class frmEditLote : Form
    {
        public frmEditLote()
        {
            InitializeComponent();
        }
        GalponLN oln = new GalponLN();
        RazaLN olnex = new RazaLN();

        private int _idGalpon;
        private int _idRaza;

        private void MostrarGalpones()
        {
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "IdGalpon";
            comboBox1.DataSource = oln.ShowGalponesDisponibles(_idGalpon);
            comboBox1.SelectedValue = _idGalpon;


        }

        private void MostrarRazas()
        {
            comboBox2.DataSource = olnex.ShowRaza();
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "IdRaza";
        }
        public LoteE CrearObjeto()
        {
            int idLote = Convert.ToInt32(textBox1.Text);
            int idGalpon = (int)comboBox1.SelectedValue;
            int idRaza = (int)comboBox2.SelectedValue;
            string codigo = textBox2.Text;
            DateTime fechaIngreso = dateTimePicker1.Value;
            int cantInicial = int.Parse(textBox3.Text);
            decimal cosInicial = decimal.Parse(textBox4.Text);
            string estado = comboBox3.SelectedItem.ToString();
            int stockActual = cantInicial;
        
            LoteE ca = new LoteE(idLote, idGalpon, idRaza, codigo, fechaIngreso, cantInicial, cosInicial, estado, stockActual);
            return ca;
        }
        public bool ValidarDatos()
        {
            bool value = true;
            if (textBox1.Text.Trim().Length == 0 && textBox2.Text.Trim().Length == 0 && textBox3.Text.Trim().Length == 0 &&
                textBox3.Text.Trim().Length == 0 && textBox4.Text.Trim().Length == 0)
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

        public void setDatos(LoteE op)
        {
            textBox1.Text = op.IdLote.ToString();
            _idGalpon = op.IdGalpon;
            _idRaza = op.IdRaza;
            textBox2.Text = op.Codigo;
            dateTimePicker1.Value = op.FechaIngreso;
            textBox3.Text = op.CantInicial.ToString();
            textBox4.Text = op.CosInicial.ToString();
            comboBox3.SelectedItem = op.Estado;
 
        }

        private void frmEditLote_Load(object sender, EventArgs e)
        {
            MostrarGalpones();
            MostrarRazas();
            comboBox1.SelectedValue = _idGalpon;
            comboBox2.SelectedValue = _idRaza;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void actualizarCapacidad()
        {
            if (comboBox1.SelectedValue != null && !(comboBox1.SelectedValue is GalponE))
            {
                int id = Convert.ToInt32(comboBox1.SelectedValue);

                GalponE galpon = oln.obtenerObjeto(id);

                if (galpon != null)
                {
                    textBox5.Text = galpon.CapMaxima.ToString();
                }
            }
        }

        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarCapacidad();
        }

        
    }
}
