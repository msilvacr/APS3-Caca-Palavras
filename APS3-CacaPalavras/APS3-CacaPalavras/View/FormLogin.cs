using APS3_CacaPalavras.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace APS3_CacaPalavras.View
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        //frmLoad
        private void FormAcesso_Load(object sender, EventArgs e)
        {
            this.txtEmail.Focus();
        }

        //eventos        
        //btnLogin
        private void btnLogin_Click(object sender, EventArgs e)
        {
            iniciarLogin();
        }
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
        
        //btnSair
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        //lblCadastrese
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
            FormCriarConta frmCriarConta = new FormCriarConta();
            frmCriarConta.ShowDialog();
            this.Visible = true;
        }
        private void labelCadastrese_MouseEnter(object sender, EventArgs e)
        {
            labelCadastrese.Font = new Font(labelCadastrese.Font, FontStyle.Bold);
        }
        private void labelCadastrese_MouseLeave(object sender, EventArgs e)
        {
            labelCadastrese.Font = new Font(labelCadastrese.Font, FontStyle.Regular);
        }

        //textboxes
        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtSenha.Focus();
            }
        }
        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                iniciarLogin();
            }
        }


        //métodos
        private void iniciarLogin()
        {
            if (this.txtEmail.Text != string.Empty && this.txtSenha.Text != string.Empty)
            {
                string resultLogin = Usuario.AutenticarUsuario(this.txtEmail.Text, this.txtSenha.Text);


                if (resultLogin == "Login efetuado com sucesso!")
                {
                    Usuario.LogarUsuario(this.txtEmail.Text, this.txtSenha.Text);
                    MessageBox.Show(resultLogin, "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                }
                else
                {
                    if (resultLogin == "Senha incorreta")
                    {
                        this.txtSenha.Focus();
                        this.txtSenha.SelectAll();
                        MessageBox.Show(resultLogin, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        this.txtEmail.Focus();
                        this.txtEmail.SelectAll();
                        MessageBox.Show(resultLogin, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            else
            {
                this.txtEmail.Focus();
            }

        }
    }
}
