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

namespace Presentacion._03_Procesamiento
{
    public partial class frmAdminLoteFaenado : Form
    {
        public frmAdminLoteFaenado()
        {
            InitializeComponent();
        }

        LoteFaenadoLN oln = new LoteFaenadoLN();
        
        public void ListarLotesFaneados()
        {
            dataGridView1.DataSource = oln.ShowLoteFaenado();
        }
        public void Nuevo()
        {
            try
            {
                frmEditLoteFaenado frmca = new frmEditLoteFaenado();
                frmca.Text = "Insertar LoteFaenado";
                frmca.label1.Text = "Registro LoteFaenado";
                frmca.ShowDialog();
                if (frmca.DialogResult == DialogResult.OK)
                {
                    Lote_FaenadoE ca = frmca.CrearObjeto();
                    oln.InsertLoteFaenado(ca);
                    frmca.Close();
                    ListarLotesFaneados();
                    timer1.Start();
                    toolStripStatusLabel1.Text = "Ingreso Correcto de LoteFaenado";
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Error Insertar de LoteFaenado: " + ex.Message;
            }
        }
        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var ress = MessageBox.Show("Desea Eliminar el Lote Faenado?", "Eliminar LoteFaenado", MessageBoxButtons.YesNo);
                    if (ress == DialogResult.Yes)
                    {
                        Lote_FaenadoE obj = dataGridView1.CurrentRow.DataBoundItem as Lote_FaenadoE;
                        oln.DeleteLoteFaenado(obj);
                        ListarLotesFaneados();
                        timer1.Start();
                        toolStripStatusLabel1.Text = "Lote Faenado Eliminado.";

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
                toolStripStatusLabel1.Text = "Error al Eliminar Lote Faenado: " + ex.Message;
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

        private void frmAdminLoteFaenado_Load(object sender, EventArgs e)
        {
            Estilo.PintarGrilla(this.dataGridView1);
            ListarLotesFaneados();
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            Eliminar();
        }
    }
}
