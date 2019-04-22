using System;
using System.Drawing;
using System.Windows.Forms;
using APS3_CacaPalavras.Model;

namespace APS3_CacaPalavras.View
{
    public partial class FormCriarConta : Form
    {
        //criando obj usuário
        Usuario user = new Usuario();

        //inicializando componente 
        public FormCriarConta()
        {
            InitializeComponent();
        }
        private void FormCriarConta_Load(object sender, EventArgs e)
        {
            //definindo dialogResult do formulário
            this.DialogResult = DialogResult.None;

            //redefinindo tamanho e centralizando componente
            this.Size = new System.Drawing.Size(345, 425);
            this.CenterToScreen();

            //enterando visibilidade dos paineis
            this.panelSteps1.Visible = true;
            this.panelSteps2.Visible = false;
            this.panelSteps3.Visible = false;

            //redefinindo tamanho dos paineis
            this.panelSteps1.Location = new System.Drawing.Point(7, 84);
            this.panelSteps2.Location = new System.Drawing.Point(7, 84);
            this.panelSteps3.Location = new System.Drawing.Point(7, 84);

            this.txtNomeSteps1.Focus();
        }

        //steps1
        private void txtNomeSteps1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtDtNascimentoSteps1.Focus();
            }
        }
        private void txtDtNascimentoSteps1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtTelefoneSteps1.Focus();
            }
        }
        private void txtTelefoneSteps1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.avancarSteps2();
            }
        }

        private void btnProximoSteps1_Click(object sender, EventArgs e)
        {
            this.avancarSteps2();
        }
        private void btnProximoSteps1_MouseEnter(object sender, EventArgs e)
        {
            this.btnProximoSteps1.ForeColor = Color.FromArgb(58, 65, 84);
            this.btnProximoSteps1.BackColor = Color.FromArgb(255, 255, 255);
        }
        private void btnProximoSteps1_MouseLeave(object sender, EventArgs e)
        {
            this.btnProximoSteps1.BackColor = Color.FromArgb(58, 65, 84);
            this.btnProximoSteps1.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void btnCancelarSteps1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnCancelarSteps1_MouseEnter(object sender, EventArgs e)
        {
            this.btnCancelarSteps1.BackColor = Color.FromArgb(255, 255, 255);
            this.btnCancelarSteps1.ForeColor = Color.FromArgb(217, 81, 51);
        }
        private void btnCancelarSteps1_MouseLeave(object sender, EventArgs e)
        {
            this.btnCancelarSteps1.ForeColor = Color.FromArgb(255, 255, 255);
            this.btnCancelarSteps1.BackColor = Color.FromArgb(217, 81, 51);
        }

        //steps2
        private void txtEmailSteps2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtConfirmarEmailSteps2.Focus();
            }
        }
        private void txtConfirmarEmailSteps2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.avancarSteps3();
            }
        }

        private void btnProximoSteps2_Click(object sender, EventArgs e)
        {
            this.avancarSteps3();
        }
        private void btnProximoSteps2_MouseEnter(object sender, EventArgs e)
        {
            this.btnProximoSteps2.ForeColor = Color.FromArgb(58, 65, 84);
            this.btnProximoSteps2.BackColor = Color.FromArgb(255, 255, 255);
        }
        private void btnProximoSteps2_MouseLeave(object sender, EventArgs e)
        {
            this.btnProximoSteps2.BackColor = Color.FromArgb(58, 65, 84);
            this.btnProximoSteps2.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void btnVoltarSteps2_Click(object sender, EventArgs e)
        {
            this.voltarSteps1();
        }
        private void btnVoltarSteps2_MouseEnter(object sender, EventArgs e)
        {
            this.btnVoltarSteps2.BackColor = Color.FromArgb(255, 255, 255);
            this.btnVoltarSteps2.ForeColor = Color.FromArgb(217, 81, 51);
        }
        private void btnVoltarSteps2_MouseLeave(object sender, EventArgs e)
        {
            this.btnVoltarSteps2.ForeColor = Color.FromArgb(255, 255, 255);
            this.btnVoltarSteps2.BackColor = Color.FromArgb(217, 81, 51);
        }

        //steps3
        private void txtSenhaSteps3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.txtConfirmarSenhaSteps3.Focus();
            }
        }
        private void txtConfirmarSenhaSteps3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.avancarStepsFinal();
                string result = UsuarioControle.CadastrarUsuario(user);

                if (result == "Já existe um usuário cadastrado com este e-mail")
                {
                    MessageBox.Show(result, "Falha!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    this.voltarSteps2();
                }
                else
                {
                    MessageBox.Show("Usuário criado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                }
            }
        }

        private void btnFinalizarSteps3_Click(object sender, EventArgs e)
        {
            this.avancarStepsFinal();
            string result = UsuarioControle.CadastrarUsuario(user);
        }
        private void btnFinalizarSteps3_MouseEnter(object sender, EventArgs e)
        {
            this.btnFinalizarSteps3.ForeColor = Color.FromArgb(58, 65, 84);
            this.btnFinalizarSteps3.BackColor = Color.FromArgb(255, 255, 255);
        }
        private void btnFinalizarSteps3_MouseLeave(object sender, EventArgs e)
        {
            this.btnFinalizarSteps3.BackColor = Color.FromArgb(58, 65, 84);
            this.btnFinalizarSteps3.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void btnVoltarSteps3_Click(object sender, EventArgs e)
        {
            this.voltarSteps2();
        }
        private void btnVoltarSteps3_MouseEnter(object sender, EventArgs e)
        {
            this.btnVoltarSteps3.BackColor = Color.FromArgb(255, 255, 255);
            this.btnVoltarSteps3.ForeColor = Color.FromArgb(217, 81, 51);
        }
        private void btnVoltarSteps3_MouseLeave(object sender, EventArgs e)
        {
            this.btnVoltarSteps3.ForeColor = Color.FromArgb(255, 255, 255);
            this.btnVoltarSteps3.BackColor = Color.FromArgb(217, 81, 51);
        }


        //métodos         
        private void avancarSteps2()
        {
            if (txtNomeSteps1.Text != string.Empty && txtDtNascimentoSteps1.Text != string.Empty && txtTelefoneSteps1.Text != "(  )       -")
            {
                //setando valores no obj Usuario
                user.Nome = this.txtNomeSteps1.Text;
                user.DtNascimento = Convert.ToDateTime(this.txtDtNascimentoSteps1.Text);
                user.Telefone = this.txtTelefoneSteps1.Text;

                this.panelSteps1.Visible = false;
                this.panelSteps2.Visible = true;
                this.panelSteps3.Visible = false;

                this.txtEmailSteps2.Focus();
            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                this.txtNomeSteps1.Focus();
                this.txtNomeSteps1.SelectAll();
                this.labelNomeSteps1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void avancarSteps3()
        {
            if (txtEmailSteps2.Text != string.Empty && txtConfirmarEmailSteps2.Text != string.Empty)
            {
                if (txtEmailSteps2.Text == txtConfirmarEmailSteps2.Text)
                {
                    //setando valores no obj Usuario
                    user.Email = this.txtEmailSteps2.Text;

                    this.panelSteps1.Visible = false;
                    this.panelSteps2.Visible = false;
                    this.panelSteps3.Visible = true;

                    this.txtSenhaSteps3.Focus();
                }
                else
                {
                    MessageBox.Show("Os emails não conferem.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    this.txtEmailSteps2.Focus();
                    this.txtEmailSteps2.SelectAll();
                    this.labelEmailSteps2.ForeColor = System.Drawing.Color.Red;
                    this.labelConfirmarEmailSteps2.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                this.txtEmailSteps2.Focus();
            }
        }

        private void avancarStepsFinal()
        {
            if (txtSenhaSteps3.Text != string.Empty && txtConfirmarSenhaSteps3.Text != string.Empty)
            {
                if (txtSenhaSteps3.Text == txtConfirmarSenhaSteps3.Text)
                {
                    //setando valores no obj Usuario
                    user.Senha = this.txtSenhaSteps3.Text;
                }
                else
                {
                    MessageBox.Show("As senhas não conferem.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                }
            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtSenhaSteps3.Focus();
                this.txtSenhaSteps3.SelectAll();
                labelSenhaSteps3.ForeColor = Color.Red;
                labelConfirmarSenhaSteps3.ForeColor = Color.Red;
            }
        }

        private void voltarSteps1()
        {
            this.panelSteps1.Visible = true;
            this.panelSteps2.Visible = false;
            this.panelSteps3.Visible = false;

            this.txtNomeSteps1.Focus();
        }

        private void voltarSteps2()
        {
            this.panelSteps1.Visible = false;
            this.panelSteps2.Visible = true;
            this.panelSteps3.Visible = false;

            this.txtEmailSteps2.Focus();
            this.txtEmailSteps2.SelectAll();

            this.txtSenhaSteps3.Text = string.Empty;
            this.txtConfirmarSenhaSteps3.Text = string.Empty;       
        }
    }
}
