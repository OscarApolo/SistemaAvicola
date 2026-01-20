using Entidades._01_Administracion;
using Entidades._04_Comercializacion;
using Logica._04_Comercializacion;
using Presentacion._01_Administracion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion._04_Comercializacion
{
    public partial class frmAdminVentas : Form
    {
        public frmAdminVentas()
        {
            InitializeComponent();
        }

        VentaLN oln = new VentaLN();
        public void listar()
        {
            dataGridView1.DataSource = oln.ShowVentas();
        }
        public void Nuevo()
        {
            try
            {
                frmEditVentas frmca = new frmEditVentas();
                frmca.Text = "Insertar Venta";
                frmca.label1.Text = "Registro Venta";
                frmca.ShowDialog();
                if (frmca.DialogResult == DialogResult.OK)
                {
                    VentaE ca = frmca.CrearObjeto();
                    oln.InsertVenta(ca);
                    frmca.Close();
                    listar();
                    timer1.Start();
                    toolStripStatusLabel1.Text = "Ingreso Correcto de Venta";
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Error Insertar de Venta" + ex.Message;
            }
        }
        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var ress = MessageBox.Show("Desea Eliminar la venta?", "Eliminar Venta", MessageBoxButtons.YesNo);
                    if (ress == DialogResult.Yes)
                    {
                        VentaPersonalizada oeVista = dataGridView1.CurrentRow.DataBoundItem as VentaPersonalizada;
                        VentaE obj = oln.obtenerObjeto(oeVista);
                        oln.DeleteEmpleado(obj);
                        listar();
                        timer1.Start();
                        toolStripStatusLabel1.Text = "Venta Eliminada.";

                    }
                    else
                    {
                        timer1.Start();
                        toolStripStatusLabel1.Text = "Eliminacion Cancelada.";
                    }

                }
                else
                {
                    timer1.Start();
                    toolStripStatusLabel1.Text = "Seleccione la fila a Eliminar.";
                }
            }
            catch (Exception ex)
            {
                timer1.Start();
                toolStripStatusLabel1.Text = "Error al Eliminar Venta: " + ex.Message;
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void frmAdminVentas_Load(object sender, EventArgs e)
        {
            Estilo.PintarGrilla(this.dataGridView1);
            listar();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "...";
            timer1.Stop();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            Eliminar();
        }
    }
}
