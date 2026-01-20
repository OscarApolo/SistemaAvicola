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
    public partial class frmAdminRaza : Form
    {
        public frmAdminRaza()
        {
            InitializeComponent();
        }

        RazaLN olne = new RazaLN();

        public void ListarRazas()
        {
            dataGridView1.DataSource = olne.ShowRaza(); 
        }
        public void Nuevo()
        {
            try
            {
                frmEditRaza frmca = new frmEditRaza();
                frmca.Text = "Insertar RazaAve";
                frmca.label1.Text = "Registro Raza Ave";
                frmca.ShowDialog();
                if (frmca.DialogResult == DialogResult.OK)
                {
                    RazaAveE ca = frmca.CrearObjeto();
                    olne.InsertRaza(ca);
                    frmca.Close();
                    ListarRazas();
                    timer1.Start();
                    toolStripStatusLabel1.Text = "Ingreso Correcto de Raza Ave";
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Error Insertar de Raza Ave" + ex.Message;
            }
        }

        public void Actualizar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    frmEditRaza formcat = new frmEditRaza();
                    formcat.Text = "Modificar RazaAve";
                    formcat.label1.Text = "Modificar Raza Ave";
                    RazaAveE obj = dataGridView1.CurrentRow.DataBoundItem as RazaAveE;
                    formcat.setDatos(obj);
                    formcat.ShowDialog();
                    if (formcat.DialogResult == DialogResult.OK)
                    {
                        RazaAveE op = formcat.CrearObjeto();
                        olne.UpdateRaza(op);
                        ListarRazas();
                        timer1.Start();
                        toolStripStatusLabel1.Text = "Raza Ave actualizado correctamente.";
                    }
                }
                else
                {
                    toolStripStatusLabel1.Text = "Seleccione la fila a modificar.";
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Error al modificar RazaAve: " + ex.Message;
            }
        }

        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var ress = MessageBox.Show("Desea Eliminar la Raza Ave", "Eliminar Raza Ave", MessageBoxButtons.YesNo);
                    if (ress == DialogResult.Yes)
                    {
                        RazaAveE obj = dataGridView1.CurrentRow.DataBoundItem as RazaAveE;
                        olne.DeleteRaza(obj);
                        ListarRazas();
                        timer1.Start();
                        toolStripStatusLabel1.Text = "RazaAve Eliminada.";

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
                toolStripStatusLabel1.Text = "Error al Eliminar RazaAve: " + ex.Message;
            }
        }

        private void frmAdminRaza_Load(object sender, EventArgs e)
        {
            Estilo.PintarGrilla(this.dataGridView1);
            ListarRazas();
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Actualizar();
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

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            Eliminar();
        }
    }
}
