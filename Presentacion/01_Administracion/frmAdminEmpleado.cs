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
    public partial class frmAdminEmpleado : Form
    {
        public frmAdminEmpleado()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        EmpleadoLN olne = new EmpleadoLN();

        public void listarEmpleado()
        {
            dataGridView1.DataSource = olne.ShowEmpleado();
        }

        public void Nuevo()
        {
            try
            {
                frmEditEmpleado frmca = new frmEditEmpleado();
                frmca.Text = "Insertar Empleado";
                frmca.label1.Text = "Registro Empleado";
                frmca.ShowDialog();
                if (frmca.DialogResult == DialogResult.OK)
                {
                    EmpleadoE ca = frmca.CrearObjeto();
                    olne.InsertEmpleado(ca);
                    frmca.Close();
                    listarEmpleado();
                    timer1.Start();
                    toolStripStatusLabel1.Text = "Ingreso Correcto de Empleado";
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Error Insertar de Empleado" + ex.Message;
            }
        }

        public void Actualizar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    frmEditEmpleado formcat = new frmEditEmpleado();
                    formcat.Text = "Modificar Empleado";
                    formcat.label1.Text = "Modificar Empleado";
                    EmpleadoPersonalizado oeVista = dataGridView1.CurrentRow.DataBoundItem as EmpleadoPersonalizado;
                    EmpleadoE obj = olne.obtenerObjeto(oeVista); 
                    formcat.setDatos(obj);
                    formcat.ShowDialog();
                    if (formcat.DialogResult == DialogResult.OK)
                    {
                        EmpleadoE op = formcat.CrearObjeto();
                        olne.UpdateEmpleado(op);
                        listarEmpleado();
                        timer1.Start();
                        toolStripStatusLabel1.Text = "Empleado actualizado correctamente.";
                    }
                }
                else
                {
                    toolStripStatusLabel1.Text = "Seleccione la fila a modificar.";
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Error al modificar Empleado: " + ex.Message;
            }
        }

        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var ress = MessageBox.Show("Desea Eliminar el Empleado", "Eliminar Empleado", MessageBoxButtons.YesNo);
                    if (ress == DialogResult.Yes)
                    {
                        EmpleadoPersonalizado oeVista = dataGridView1.CurrentRow.DataBoundItem as EmpleadoPersonalizado;
                        EmpleadoE obj = olne.obtenerObjeto(oeVista);
                        olne.DeleteEmpleado(obj);
                        listarEmpleado();
                        timer1.Start();
                        toolStripStatusLabel1.Text = "Empleado Eliminado.";

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
                toolStripStatusLabel1.Text = "Error al Eliminar Empleado: " + ex.Message;
            }
        }


        private void frmAdminEmpleado_Load(object sender, EventArgs e)
        {
            listarEmpleado();
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
    }
}
