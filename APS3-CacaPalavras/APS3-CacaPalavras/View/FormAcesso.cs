using System;
using System.Drawing;
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

        private void labelCadastrese_MouseEnter(object sender, EventArgs e)
        {
            labelCadastrese.Font = new Font(labelCadastrese.Font, FontStyle.Bold);
        }
        private void labelCadastrese_MouseLeave(object sender, EventArgs e)
        {
            labelCadastrese.Font = new Font(labelCadastrese.Font, FontStyle.Regular);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
            FormCriarConta frmCriarConta = new FormCriarConta();
            frmCriarConta.ShowDialog();
            this.Visible = true;
        }


    }
}
