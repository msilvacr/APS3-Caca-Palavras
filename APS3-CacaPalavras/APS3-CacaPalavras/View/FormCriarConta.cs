using System;
using System.Drawing;
using System.Windows.Forms;

namespace APS3_CacaPalavras.View
{
    public partial class FormCriarConta : Form
    {
        //inicializando componente 
        public FormCriarConta()
        {
            InitializeComponent();
        }
        private void FormCriarConta_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(345, 425);
            this.CenterToScreen();

            this.panelSteps1.Visible = true;
            this.panelSteps2.Visible = false;
            this.panelSteps3.Visible = false;

            this.panelSteps1.Location = new System.Drawing.Point(7, 84);
            this.panelSteps2.Location = new System.Drawing.Point(7, 84);
            this.panelSteps3.Location = new System.Drawing.Point(7, 84);
        }

        //steps1
        private void btnProximoSteps1_Click(object sender, EventArgs e)
        {
            if (txtNomeSteps1.Text != string.Empty && txtDtNascimentoSteps1.Text != string.Empty && txtTelefoneSteps1.Text != "(  )       -")
            {
                this.panelSteps1.Visible = false;
                this.panelSteps2.Visible = true;
                this.panelSteps3.Visible = false;
            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                this.txtNomeSteps1.Focus();
                this.labelNomeSteps1.ForeColor = System.Drawing.Color.Red;
            }
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
        private void btnProximoSteps2_Click(object sender, EventArgs e)
        {
            if (txtEmailSteps2.Text != string.Empty && txtConfirmarEmailSteps2.Text != string.Empty)
            {
                if (txtEmailSteps2.Text == txtConfirmarEmailSteps2.Text)
                {
                    this.panelSteps1.Visible = false;
                    this.panelSteps2.Visible = false;
                    this.panelSteps3.Visible = true;
                }
                else
                {
                    MessageBox.Show("Os emails não conferem.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    this.txtEmailSteps2.Focus();
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
            this.panelSteps1.Visible = true;
            this.panelSteps2.Visible = false;
            this.panelSteps3.Visible = false;
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
        private void btnFinalizarSteps3_Click(object sender, EventArgs e)
        {
            if(txtSenhaSteps3.Text != string.Empty && txtConfirmarSenhaSteps3.Text != string.Empty)
            {
                if(txtSenhaSteps3.Text == txtConfirmarSenhaSteps3.Text)
                {

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
                labelSenhaSteps3.ForeColor = Color.Red;
                labelConfirmarSenhaSteps3.ForeColor = Color.Red;
            }
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
            this.panelSteps1.Visible = false;
            this.panelSteps2.Visible = true;
            this.panelSteps3.Visible = false;
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
        private void CriarUsuario()
        {

        }
        

    }
}
