using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjVentaHeredada4700237
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnCredito_Click(object sender, EventArgs e)
        {
            frmCredito frmCre = new frmCredito();
            frmCre.Show();
        }

        private void btnContado_Click(object sender, EventArgs e)
        {
            frmContado frmc = new frmContado();
            frmc.Show();
        }
    }
}
