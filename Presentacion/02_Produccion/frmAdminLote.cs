using Entidades._02_Produccion;
using Logica;
using Logica._02_Produccion;
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
    public partial class frmAdminLote : Form
    {
        public frmAdminLote()
        {
            InitializeComponent();
        }
        
        LoteLN olne = new LoteLN();
        GalponLN olnex = new GalponLN();

        public void ListarLote()
        {
            dataGridView1.DataSource = olne.ShowLote();   
        }
        public void Nuevo()
        {
           
            frmEditLote frmca = new frmEditLote();
            frmca.Text = "Insertar Lote";
            frmca.label1.Text = "Registro Lote de Aves";
            frmca.ShowDialog();
            if (frmca.DialogResult == DialogResult.OK)
            {
                try
                {
                    LoteE ca = frmca.CrearObjeto();
                    olne.InsertLote(ca);
                    olnex.actualizarGalpon(ca.IdGalpon, "Ocupado");
                    frmca.Close();
                    ListarLote();
                    timer1.Start();
                    toolStripStatusLabel1.Text = "Ingreso Correcto de Lote";
                }
                catch (LogicaExcepciones ex)
                {
                    timer1.Interval = 5000;
                    timer1.Start();
                    toolStripStatusLabel1.Text = ex.Message;
                }
                    
            }
         
        }

        public void Actualizar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    frmEditLote formcat = new frmEditLote();
                    formcat.Text = "Modificar Lote";
                    formcat.label1.Text = "Modificar Lote de Aves";
                    LotePersonalizado oeVista = dataGridView1.CurrentRow.DataBoundItem as LotePersonalizado;
                    LoteE obj = olne.obtenerObjeto(oeVista);
                    formcat.setDatos(obj);
                    formcat.ShowDialog();
                    if (formcat.DialogResult == DialogResult.OK)
                    {
                        try
                        {
                            LoteE op = formcat.CrearObjeto();
                            olne.UpdateLote(op);
                            if (op.Estado == "Cerrado")
                            {
                                olnex.actualizarGalpon(op.IdGalpon, "Disponible");
                            }
                            if (op.IdGalpon != obj.IdGalpon)
                            {
                                olnex.actualizarGalpon(op.IdGalpon, "Ocupado");
                                olnex.actualizarGalpon(obj.IdGalpon, "Disponible");
                            }
                            ListarLote();
                            timer1.Start();
                            toolStripStatusLabel1.Text = "Lote actualizado correctamente.";
                        } catch (LogicaExcepciones ex) 
                        {
                            timer1.Interval = 5000;
                            timer1.Start();
                            toolStripStatusLabel1.Text = ex.Message;

                        }
                    }
                }
                else
                {
                    timer1.Start();
                    toolStripStatusLabel1.Text = "Seleccione la fila a modificar.";
                }
            }
            catch (Exception ex)
            {
                timer1.Start();
                toolStripStatusLabel1.Text = "Error al modificar Lote: " + ex.Message;
            }
        }

        public void Eliminar()
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var ress = MessageBox.Show("Desea Eliminar el Lote", "Eliminar Lote", MessageBoxButtons.YesNo);
                    if (ress == DialogResult.Yes)
                    {
                        LotePersonalizado oeVista = dataGridView1.CurrentRow.DataBoundItem as LotePersonalizado;
                        LoteE obj = olne.obtenerObjeto(oeVista);
                        olne.DeleteLote(obj);
                        olnex.actualizarGalpon(obj.IdGalpon, "Disponible");
                        ListarLote();
                        timer1.Start();
                        toolStripStatusLabel1.Text = "Lote Eliminado.";

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
                toolStripStatusLabel1.Text = "Error al Eliminar Lote: " + ex.Message;
            }
        }


        private void frmAdminLote_Load(object sender, EventArgs e)
        {
            Estilo.PintarGrilla(this.dataGridView1);
            ListarLote();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
