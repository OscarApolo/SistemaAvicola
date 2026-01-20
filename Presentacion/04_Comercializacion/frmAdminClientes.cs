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
    public partial class frmAdminClientes : Form
    {
        public frmAdminClientes()
        {
            InitializeComponent();
        }
        ClienteLN oln = new ClienteLN();
        
        public void listarClientes()
        {
            dataGridView1.DataSource = oln.ShowClientes();
        }
        public void Nuevo()
        {
            try
            {
                frmEditCliente frmca = new frmEditCliente();
                frmca.Text = "Insertar Cliente";
                frmca.label1.Text = "Registro Cliente";
                frmca.ShowDialog();
                if (frmca.DialogResult == DialogResult.OK)
                {
                    ClienteE ca = frmca.CrearObjeto();
                    oln.InsertCliente(ca);
                    frmca.Close();
                    listarClientes();
                    timer1.Start();
                    toolStripStatusLabel1.Text = "Ingreso Correcto de Cliente";
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Error Insertar de Cliente" + ex.Message;
            }
        }

        public void Actualizar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    frmEditCliente formcat = new frmEditCliente();
                    formcat.Text = "Modificar Cliente";
                    formcat.label1.Text = "Modificar Cliente";
                    ClienteE obj = dataGridView1.CurrentRow.DataBoundItem as ClienteE;
                    formcat.setDatos(obj);
                    formcat.ShowDialog();
                    if (formcat.DialogResult == DialogResult.OK)
                    {
                        ClienteE op = formcat.CrearObjeto();
                        oln.UpdateCliente(op);
                        listarClientes();
                        timer1.Start();
                        toolStripStatusLabel1.Text = "Cliente actualizado correctamente.";
                    }
                }
                else
                {
                    toolStripStatusLabel1.Text = "Seleccione la fila a modificar.";
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Error al modificar Cliente: " + ex.Message;
            }
        }

        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var ress = MessageBox.Show("Desea Eliminar el Cliente", "Eliminar Cliente", MessageBoxButtons.YesNo);
                    if (ress == DialogResult.Yes)
                    {
                        ClienteE obj = dataGridView1.CurrentRow.DataBoundItem as ClienteE;
                        oln.DeleteCliente(obj);
                        listarClientes();
                        timer1.Start();
                        toolStripStatusLabel1.Text = "Cliente Eliminado.";

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
                toolStripStatusLabel1.Text = "Error al Eliminar Cliente: " + ex.Message;
            }
        }
        private void frmAdminClientes_Load(object sender, EventArgs e)
        {
            Estilo.PintarGrilla(this.dataGridView1);
            listarClientes();
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
