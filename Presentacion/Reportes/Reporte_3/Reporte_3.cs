using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Reportes.Reporte_3
{
    public partial class Reporte_3 : Form
    {
        public Reporte_3()
        {
            InitializeComponent();
        }

        private void ImprimirReporte()
        {
            try
            {
                DateTime fechaInicio = dateTimePicker1.Value;
                DateTime fechaFin = dateTimePicker2.Value;

                DSDatos ds = new DSDatos();
                var adapter = new DSDatosTableAdapters.dtDetalleTableAdapter();

                adapter.Fill(ds.dtDetalle, fechaInicio, fechaFin);

                if (ds.dtDetalle.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron ventas en ese rango de fechas.");
                    return;
                }

                CRDetalle reporte = new CRDetalle();
                reporte.SetDataSource(ds);

                crystalReportViewer1.ReportSource = reporte;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImprimirReporte();
        }
    }
}
