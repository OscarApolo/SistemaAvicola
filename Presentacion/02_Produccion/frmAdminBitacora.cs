using Entidades._01_Administracion;
using Entidades._02_Produccion;
using Logica._02_Produccion;
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

namespace Presentacion._02_Produccion
{
    public partial class frmAdminBitacora : Form
    {
        public frmAdminBitacora()
        {
            InitializeComponent();
        }

        BitacoraLN olne = new BitacoraLN();

        public void listarBitacoras()
        {
            dataGridView1.DataSource = olne.ShowBitacora();
        }
        public void Nuevo()
        {
            try
            {
                frmEditBitacoras frmca = new frmEditBitacoras();
                frmca.Text = "Insertar Bitacora";
                frmca.label1.Text = "Registro Bitacora";
                frmca.ShowDialog();
                if (frmca.DialogResult == DialogResult.OK)
                {
                    BitacoraDiariaE ca = frmca.CrearObjeto();
                    olne.actualizarStock(ca.IdLote, ca.Mortalidad);
                    olne.InsertBitacora(ca);
                    frmca.Close();
                    listarBitacoras();
                    timer1.Start();
                    toolStripStatusLabel1.Text = "Ingreso Correcto de Bitacora";
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Error Insertar de Bitacora: " + ex.Message;
            }
        }
        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var ress = MessageBox.Show("Desea Eliminar la Bitacora?", "Eliminar Bitacora", MessageBoxButtons.YesNo);
                    if (ress == DialogResult.Yes)
                    {
                        BitacoraDiariaPer oeVista = dataGridView1.CurrentRow.DataBoundItem as BitacoraDiariaPer;
                        BitacoraDiariaE obj = olne.obtenerObjeto(oeVista);
                        olne.DeleteBitacora(obj);
                        listarBitacoras();
                        timer1.Start();
                        toolStripStatusLabel1.Text = "Bitacora Eliminada.";

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
                toolStripStatusLabel1.Text = "Error al Eliminar Bitacora: " + ex.Message;
            }
        }


        private void frmAdminBitacora_Load(object sender, EventArgs e)
        {
            Estilo.PintarGrilla(this.dataGridView1);
            listarBitacoras();
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
