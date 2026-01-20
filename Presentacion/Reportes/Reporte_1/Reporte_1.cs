using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Reportes.Reporte_1
{
    public partial class Reporte_1 : Form
    {
        public Reporte_1()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            try
            {
                DSDatos ds = new DSDatos();
                var adapter = new DSDatosTableAdapters.dtRendimientoTableAdapter();
                adapter.Fill(ds.dtRendimiento);
                if (ds.dtRendimiento.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para mostrar");
                    return;
                }
                CRRendimiento reporte = new CRRendimiento();
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
