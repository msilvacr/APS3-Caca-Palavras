using APS3_CacaPalavras.Model;
using APS3_CacaPalavras.ModelControl;
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
    public partial class FormTelaPrincipal : Form
    {
        public FormTelaPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            CarregarForm();
        }

        //eventos 

        //btnContinuar
        private void btnContinuar_MouseEnter(object sender, EventArgs e)
        {
            this.btnContinuar.ForeColor = Color.FromArgb(58, 65, 84);
            this.btnContinuar.BackColor = Color.FromArgb(255, 255, 255);
        }
        private void btnContinuar_MouseLeave(object sender, EventArgs e)
        {
            this.btnContinuar.BackColor = Color.FromArgb(58, 65, 84);
            this.btnContinuar.ForeColor = Color.FromArgb(255, 255, 255);
        }

        //btnNovoJogo
        private void btnNovoJogo_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormDificuldade formDificuldade = new FormDificuldade();
            formDificuldade.ShowDialog();
        }
        private void btnNovoJogo_MouseEnter(object sender, EventArgs e)
        {
            this.btnNovoJogo.BackColor = Color.FromArgb(255, 255, 255);
            this.btnNovoJogo.ForeColor = Color.Green;
        }
        private void btnNovoJogo_MouseLeave_1(object sender, EventArgs e)
        {
            this.btnNovoJogo.BackColor = Color.Green;
            this.btnNovoJogo.ForeColor = Color.FromArgb(255, 255, 255);
        }

        //btnSair
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Finalizar();
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


        //métodos
        private void Finalizar()
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja sair?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if(dialogResult == DialogResult.Yes)
            {
                this.Dispose();
            }
        }   
        
        private void CarregarForm()
        {
            //inserindo nome do usuário logado ao text do form
            this.Text = "Woopy! - Welcome " + UsuarioLogado.User.Nome;

            //verificando se o usuário logado possui jogo em aberto
            if (ControleFormPrincipal.ValidarJogoNaoFinalizado(UsuarioLogado.User.IdUsuario))
            {
                this.btnContinuar.Enabled = true;
                this.btnContinuar.ForeColor = Color.White;
            }
            else
            {
                this.btnContinuar.Enabled = false;
                this.btnContinuar.ForeColor = Color.White;
            }
        }

    }
} 
