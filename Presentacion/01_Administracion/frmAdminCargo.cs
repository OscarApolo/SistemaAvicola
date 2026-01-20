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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Presentacion._01_Administracion
{
    public partial class frmAdminCargo : Form
    {

        CargoLN olne = new CargoLN();
        public frmAdminCargo()
        {
            InitializeComponent();
        }

      
        public void ListarCargo()
        {
            dataGridView1.DataSource = olne.ShowCargo().ToList();
        }

        public void Nuevo()
        {
            try
            {
                frmEditCargo frmca = new frmEditCargo();
                frmca.Text = "Insertar Cargo";
                frmca.label1.Text = "Registro Cargo";
                frmca.ShowDialog();
                if (frmca.DialogResult == DialogResult.OK)
                {
                    CargoE ca = frmca.CrearObjeto();
                    olne.InsertCargo(ca);
                    frmca.Close();
                    ListarCargo();
                    timer1.Start();
                    toolStripStatusLabel1.Text = "Ingreso Correcto de Cargo";
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Error Insertar de Cargo" + ex.Message;
            }
        }

        public void Actualizar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    frmEditCargo formcat = new frmEditCargo();
                    formcat.Text = "Modificar Cargo";
                    formcat.label1.Text = "Modificar Cargo";
                    CargoE obj = dataGridView1.CurrentRow.DataBoundItem as CargoE;
                    formcat.setDatos(obj);
                    formcat.ShowDialog();
                    if (formcat.DialogResult == DialogResult.OK)
                    {
                        CargoE op = formcat.CrearObjeto();
                        olne.UpdateCargo(op);
                        ListarCargo();
                        timer1.Start();
                        toolStripStatusLabel1.Text = "Cargo actualizado correctamente.";
                    }
                }
                else
                {
                    toolStripStatusLabel1.Text = "Seleccione la fila a modificar.";
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Error al modificar Cargo: " + ex.Message;
            }
        }

        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var ress = MessageBox.Show("Desea Eliminar el Cargo", "Eliminar Cargo", MessageBoxButtons.YesNo);
                    if (ress == DialogResult.Yes)
                    {
                        CargoE obj = dataGridView1.CurrentRow.DataBoundItem as CargoE;
                        olne.DeleteCargo(obj);
                        ListarCargo();
                        timer1.Start();
                        toolStripStatusLabel1.Text = "Cargo Eliminado.";

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
                toolStripStatusLabel1.Text = "Error al Eliminar Cargo: " + ex.Message;
            }
        }


        private void frmAdminCargo_Load(object sender, EventArgs e)
        {
            Estilo.PintarGrilla(this.dataGridView1);
            ListarCargo();
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "...";
            timer1.Stop();
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
