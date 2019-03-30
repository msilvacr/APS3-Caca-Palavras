using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APS3_CacaPalavras.View
{
    public partial class FormAcesso : Form
    {
        public FormAcesso()
        {
            InitializeComponent();
        }

        //eventos
        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            this.btnLogin.ForeColor = Color.FromArgb(58, 65, 84);
            this.btnLogin.BackColor = Color.FromArgb(255, 255, 255);
        }
        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            this.btnLogin.BackColor = Color.FromArgb(58, 65, 84);
            this.btnLogin.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void btnSair_MouseEnter(object sender, EventArgs e)
        {
            this.btnSair.BackColor = Color.FromArgb(255, 255, 255);
            this.btnSair.ForeColor = Color.FromArgb(217, 81, 51);
        }
        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.btnSair.ForeColor = Color.FromArgb(255, 255, 255);
            this.btnSair.BackColor = Color.FromArgb(217, 81, 51);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
