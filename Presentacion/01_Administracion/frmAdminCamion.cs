using Entidades._01_Administracion;
using Logica._01_Administracion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion._01_Administracion
{
    public partial class frmAdminCamion : Form
    {
        public frmAdminCamion()
        {
            InitializeComponent();
        }
        CamionLN olne = new CamionLN();

        public void listarCamion()
        {
            dataGridView1.DataSource = olne.ShowCamion();
        }

        public void Nuevo()
        {
            try
            {
                frmEditCamion frmca = new frmEditCamion();
                frmca.Text = "Insertar Camion";
                frmca.label1.Text = "Registro Camion";
                frmca.ShowDialog();
                if (frmca.DialogResult == DialogResult.OK)
                {
                    CamionE ca = frmca.CrearObjeto();
                    olne.InsertCamion(ca);
                    frmca.Close();
                    listarCamion();
                    timer1.Start();
                    toolStripStatusLabel1.Text = "Ingreso Correcto de Camion";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //toolStripStatusLabel1.Text = "Error Insertar de Camion" + ex.Message;
            }
        }

        public void Actualizar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    frmEditCamion formcat = new frmEditCamion();
                    formcat.Text = "Modificar Camion";
                    formcat.label1.Text = "Modificar Camion";
                    CamionPersonalizado oeVista = dataGridView1.CurrentRow.DataBoundItem as CamionPersonalizado;
                    CamionE obj = olne.obtenerObjeto(oeVista);
                    formcat.setDatos(obj);
                    formcat.ShowDialog();
                    if (formcat.DialogResult == DialogResult.OK)
                    {
                        CamionE op = formcat.CrearObjeto();
                        olne.UpdateCamion(op);
                        listarCamion();
                        timer1.Start();
                        toolStripStatusLabel1.Text = "Camion actualizado correctamente.";
                    }
                }
                else
                {
                    toolStripStatusLabel1.Text = "Seleccione la fila a modificar.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //toolStripStatusLabel1.Text = "Error al modificar Camion: " + ex.Message;
            }
        }

        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var ress = MessageBox.Show("Desea Eliminar el Camion", "Eliminar Camion", MessageBoxButtons.YesNo);
                    if (ress == DialogResult.Yes)
                    {
                        CamionPersonalizado oeVista = dataGridView1.CurrentRow.DataBoundItem as CamionPersonalizado;
                        CamionE obj = olne.obtenerObjeto(oeVista);
                        olne.DeleteCamion(obj);
                        listarCamion();
                        timer1.Start();
                        toolStripStatusLabel1.Text = "Camion Eliminado.";

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
                toolStripStatusLabel1.Text = "Error al Eliminar Camion: " + ex.Message;
            }
        }

        private void frmAdminCamion_Load(object sender, EventArgs e)
        {
            Estilo.PintarGrilla(this.dataGridView1);
            listarCamion();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "...";
            timer1.Stop();
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
