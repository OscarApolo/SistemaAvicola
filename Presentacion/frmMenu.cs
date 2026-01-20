using Presentacion._01_Administracion;
using Presentacion._02_Produccion;
using Presentacion._03_Procesamiento;
using Presentacion._04_Comercializacion;
using Presentacion.Reportes;
using Presentacion.Reportes.Reporte_1;
using Presentacion.Reportes.Reporte_2;
using Presentacion.Reportes.Reporte_3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void abrirFormularioEnPanel(Form formularioHijo)
        {
            // 1. PAUSAR EL PINTADO DEL PANEL
            // Esto congela la imagen actual para que no se vea el "hueco" blanco
            pictureBox1.Visible = false;
            this.panel.Visible = true;
            this.panel.SuspendLayout();

            // 2. Limpiar el formulario anterior
            if (this.panel.Controls.Count > 0)
            {
                // Usar Dispose es más limpio que RemoveAt
                this.panel.Controls[0].Dispose();
            }

            // 3. Configurar el nuevo formulario
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            // 4. Agregarlo y mostrarlo
            this.panel.Controls.Add(formularioHijo);
            this.panel.Tag = formularioHijo;
            formularioHijo.Show();

            // 5. REANUDAR EL PINTADO
            // Ahora que todo está listo, Windows actualiza la imagen de golpe
            this.panel.ResumeLayout();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormularioEnPanel(new frmAdminEmpleado());
        }

        private void cargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormularioEnPanel(new frmAdminCargo());
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void camionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormularioEnPanel(new frmAdminCamion());
        }

        private void galponToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormularioEnPanel(new frmAdminGalpon());
        }

        private void razaAveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormularioEnPanel(new frmAdminRaza());
        }

        private void loteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormularioEnPanel(new frmAdminLote());
        }

        private void bitacoraDiariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormularioEnPanel(new frmAdminBitacora());
        }

        private void ordenFaenadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormularioEnPanel(new frmAdminOrdenFaena());
        }

        private void loteFaenadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormularioEnPanel(new frmAdminLoteFaenado());
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormularioEnPanel(new frmAdminClientes());
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormularioEnPanel(new frmAdminVentas());
        }

        private void detalleVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormularioEnPanel(new frmAdminDetalleVenta());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Ocultamos el panel (Esto quita la "sábana blanca" de en medio)
            this.panel.Visible = false;

            // 2. Aseguramos que el PictureBox se vea
            pictureBox1.Visible = true;
            pictureBox1.BringToFront();

            // 3. (Opcional) Limpieza de memoria
            // Si quieres borrar lo que había en el panel para liberar RAM:
            if (this.panel.Controls.Count > 0)
            {
                this.panel.Controls[0].Dispose();
            }
        }

        private void reporte1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormularioEnPanel(new Reporte_1());
        }

        private void rPVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormularioEnPanel(new Reporte_2());
        }

        private void rPHistorialVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormularioEnPanel(new Reporte_3());
        }
    }
}
