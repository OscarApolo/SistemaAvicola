using Entidades._04_Comercializacion;
using Logica._03_Procesamiento;
using Logica._04_Comercializacion;
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
    public partial class frmAdminDetalleVenta : Form
    {
        public frmAdminDetalleVenta()
        {
            InitializeComponent();
        }
        DetalleLN olne = new DetalleLN();
        
        public void listarDetalle()
        {
            dataGridView1.DataSource = olne.ShowDetalleVenta();
        }
        public void Nuevo()
        {
            try
            {
                frmEditDetalle frmca = new frmEditDetalle();
                frmca.Text = "Insertar DetalleVenta";
                frmca.label1.Text = "Registro DetalleVenta";
                frmca.ShowDialog();
                if (frmca.DialogResult == DialogResult.OK)
                {
                    DetalleVentaE ca = frmca.CrearObjeto();
                    olne.actualizarStock(ca.IdProducto, ca.CantVendida);
                    olne.InsertDetalle(ca);
                    frmca.Close();
                    listarDetalle();
                    timer1.Start();
                    toolStripStatusLabel1.Text = "Ingreso Correcto de DetalleVenta";
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Error Insertar de DetalleVenta: " + ex.Message;
            }
        }
        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var ress = MessageBox.Show("Desea Eliminar el Detalle de venta?", "Eliminar DetalleVenta", MessageBoxButtons.YesNo);
                    if (ress == DialogResult.Yes)
                    {
                        DetallePersonalizado oeVista = dataGridView1.CurrentRow.DataBoundItem as DetallePersonalizado;
                        DetalleVentaE obj = olne.obtenerObjeto(oeVista);
                        olne.DeleteDetalle(obj);
                        listarDetalle();
                        timer1.Start();
                        toolStripStatusLabel1.Text = "DetalleVenta Eliminada.";

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
                toolStripStatusLabel1.Text = "Error al Eliminar DetalleVenta: " + ex.Message;
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


        private void frmAdminDetalleVenta_Load(object sender, EventArgs e)
        {
            Estilo.PintarGrilla(this.dataGridView1);
            listarDetalle();
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
