using Entidades._02_Produccion;
using Entidades._03_Procesamiento;
using Logica._02_Produccion;
using Logica._03_Procesamiento;
using Presentacion._02_Produccion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion._03_Procesamiento
{
    public partial class frmAdminOrdenFaena : Form
    {
        public frmAdminOrdenFaena()
        {
            InitializeComponent();
        }
        LoteLN oln = new LoteLN();
        OrdenLN olne = new OrdenLN();
        GalponLN olnex = new GalponLN();

        public void ListarOrden()
        {
            dataGridView1.DataSource = olne.ShowOrdenFaenado(); 
        }

        public void Nuevo()
        {
            try
            {
                frmEditOrden frmca = new frmEditOrden();
                frmca.Text = "Insertar OrdenFaena";
                frmca.label1.Text = "Registro OrdenFaena";
                frmca.ShowDialog();
                if (frmca.DialogResult == DialogResult.OK)
                {
                    Orden_FaenadoE ca = frmca.CrearObjeto();
                    olne.actualizarStockFaena(ca.IdLote, ca.AvesProcesadas);
                    olnex.actualizarGalpon(oln.obtenerporId(ca.IdLote).IdGalpon, "Disponible");
                    olne.InsertOrden(ca);
                    frmca.Close();
                    ListarOrden();
                    timer1.Start();
                    toolStripStatusLabel1.Text = "Ingreso Correcto de OrdenFaena";
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Error Insertar de OrdenFaena: " + ex.Message;
            }
        }
        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var ress = MessageBox.Show("Desea Eliminar la Orden_Faena?", "Eliminar OrdenFaena", MessageBoxButtons.YesNo);
                    if (ress == DialogResult.Yes)
                    {
                        OrdenPersonalizado oeVista = dataGridView1.CurrentRow.DataBoundItem as OrdenPersonalizado;
                        Orden_FaenadoE obj = olne.obtenerObjeto(oeVista);
                        olne.DeleteOrden(obj);
                        ListarOrden();
                        timer1.Start();
                        toolStripStatusLabel1.Text = "OrdenFaena Eliminada.";

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
                toolStripStatusLabel1.Text = "Error al Eliminar Orden_Faena: " + ex.Message;
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

        private void frmAdminOrdenFaena_Load(object sender, EventArgs e)
        {
            Estilo.PintarGrilla(this.dataGridView1);
            ListarOrden();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "...";
            timer1.Stop();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Eliminar();
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
