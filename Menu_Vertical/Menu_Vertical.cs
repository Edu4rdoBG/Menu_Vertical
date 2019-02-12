using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu_Vertical
{
    public partial class Menu_Vertical : Form
    {
        public Menu_Vertical()
        {
            InitializeComponent();
        }
        bool isCollapsed = true;
        #region Metodo para mover ventana 
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnlTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
        #region Sombra de ventana
        private const int CSDropShadow = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CSDropShadow;
                return cp;
            }
        }
        #endregion
        private void btnVentas_Click(object sender, EventArgs e)
        {
            timeAnimacion.Start();
        }
        #region Animacion del menu "Ventas"
        private void timeAnimacion_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                pnlVentas.Height += 10;
                if (pnlVentas.Size == pnlVentas.MaximumSize)
                {
                    timeAnimacion.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                pnlVentas.Height -= 10;
                if (pnlVentas.Size == pnlVentas.MinimumSize)
                {
                    timeAnimacion.Stop();
                    isCollapsed = true;
                }
            }
        }
        #endregion
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGithub_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Edu4rdoBG");
        }
    }
}
