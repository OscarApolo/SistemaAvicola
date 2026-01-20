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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        UsuarioLN logica = new UsuarioLN();

        private void Autenticar()
        {
            try
            {
                string user = textBox1.Text;
                string pass = textBox2.Text;

                UsuarioE usuarioValido = logica.Autenticar(user, pass);
                if (usuarioValido != null)
                {
                    MessageBox.Show("¡Bienvenido al Sistema Avicola!", "Acceso Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmMenu menu = new frmMenu();
                    this.Hide();
                    menu.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un errro: " + ex.Message);
            }

            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Autenticar();
        }
    }
}
