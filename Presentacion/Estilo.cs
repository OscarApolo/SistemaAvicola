using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public class Estilo
    {
        // Colores extraídos exactamente de tu diseño
        private static Color RojoVino = Color.FromArgb(138, 28, 34);
        private static Color Dorado = Color.FromArgb(212, 175, 55);
        private static Color GrisAlterno = Color.FromArgb(240, 240, 240);
        private static Color NegroTexto = Color.Black;

        public static void PintarGrilla(DataGridView dgv)
        {
            // --- 1. CONFIGURACIÓN GENERAL ---
            dgv.EnableHeadersVisualStyles = false; // Vital para que se vea el rojo
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Ajuste automático
            dgv.BackgroundColor = SystemColors.AppWorkspace; // O Color.White, según prefieras el fondo externo

            // --- 2. ESTILO DE ENCABEZADOS (Header) ---
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = RojoVino;               // Tu Rojo (138, 28, 34)
            headerStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            headerStyle.ForeColor = Dorado;                 // Tu Dorado (212, 175, 55)
            headerStyle.Padding = new Padding(0, 0, 0, 2);
            headerStyle.WrapMode = DataGridViewTriState.True;
            // Opcional: Evita que el encabezado se ponga azul al hacerle clic
            headerStyle.SelectionBackColor = RojoVino;
            headerStyle.SelectionForeColor = Dorado;

            dgv.ColumnHeadersDefaultCellStyle = headerStyle;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // --- 3. ESTILO DE FILAS (Celdas normales) ---
            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            rowStyle.BackColor = SystemColors.Window;       // Blanco
            rowStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
            rowStyle.ForeColor = SystemColors.ControlText;  // Negro por defecto

            // Aquí está la magia de la selección:
            rowStyle.SelectionBackColor = Dorado;           // Fondo Dorado al seleccionar
            rowStyle.SelectionForeColor = NegroTexto;       // Texto Negro al seleccionar
            rowStyle.WrapMode = DataGridViewTriState.False;

            dgv.DefaultCellStyle = rowStyle;

            // --- 4. FILAS ALTERNAS (Efecto Zebra) ---
            dgv.AlternatingRowsDefaultCellStyle.BackColor = GrisAlterno; // (240, 240, 240)
        }
    }
}
