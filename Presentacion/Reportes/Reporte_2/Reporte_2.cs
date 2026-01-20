using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Reportes.Reporte_2
{
    public partial class Reporte_2 : Form
    {
        public Reporte_2()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            try
            {
                DSDatos ds = new DSDatos();

                var adapter = new DSDatosTableAdapters.dtVentasCruzadasTableAdapter();

                adapter.Fill(ds.dtVentasCruzadas);

                if (ds.dtVentasCruzadas.Rows.Count == 0)
                {
                    MessageBox.Show("No hay ventas registradas.");
                    return;
                }

                CRVentas reporte = new CRVentas();
                reporte.SetDataSource(ds);

                crystalReportViewer1.ReportSource = reporte;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
