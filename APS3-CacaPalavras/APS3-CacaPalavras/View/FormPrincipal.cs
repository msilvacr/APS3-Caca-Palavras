using APS3_CacaPalavras.Model;
using APS3_CacaPalavras.ModelConnection;
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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            IniciarForm();
        }

        //atributos
        public static int dificuldade;

        //eventos 

        //btnContinuar
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            this.ContinuarJogo();
        }
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
            if(TelaPrincipal.ValidarJogoNaoFinalizado(UsuarioLogado.User.IdUsuario))
            {
                DialogResult dialog = MessageBox.Show("Caso queira criar um novo jogo, o jogo anterior não finalizado será perdido\nTem certeza que deseja continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (dialog == DialogResult.Yes)
                {
                    if (this.ExcluirJogoNaoFinalizado(UsuarioLogado.User.IdUsuario))
                    {
                        this.NovoJogo();
                    }
                }
            }
            else
            {
                this.NovoJogo();
            }
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

        private void IniciarForm()
        {
            //inserindo nome do usuário logado ao text do form
            this.Text = "Woopy! - Welcome " + UsuarioLogado.User.Nome;

            //verificando se o usuário logado possui jogo em aberto
            if (TelaPrincipal.ValidarJogoNaoFinalizado(UsuarioLogado.User.IdUsuario))
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

        private void ContinuarJogo()
        {
            JogoExecucao.jogo.User = UsuarioLogado.User;

        }

        private void NovoJogo()
        {
            //Criando novo jogo
            Jogo jogo = new Jogo();

            //adicionando usuário
            jogo.User = UsuarioLogado.User;

            //recebendo dificuldade do novo jogo
            this.Visible = false;
            FormDificuldade formDificuldade = new FormDificuldade();
            formDificuldade.ShowDialog();

            if(dificuldade > -1)
            {
                //adicionando dificuldade
                jogo.NivelDificuldade = FormPrincipal.dificuldade;

                //adicionando obj jogo à classe estática de controle
                JogoExecucao.jogo = jogo;


                //criando novo jogo
                Model.NovoJogo.gerarJogo();

                //chamando formJogo
                FormJogo formJogo = new FormJogo();

                this.Visible = false;

                formJogo.ShowDialog();

                this.Visible = true;
            }
        }

        private void Finalizar()
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza que deseja sair?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (dialogResult == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private bool ExcluirJogoNaoFinalizado(int idUsuario)
        {
            DBConn dBConn = new DBConn();
            dBConn.LimparParametros();

            dBConn.AdicionarParametros("@IDUsuario", idUsuario);

            string result = dBConn.ExecutarManipulacao(CommandType.StoredProcedure, "uspJogoExluirJogoNaoFinalizado").ToString();

            if (result == "Excluido com sucesso")
                return true;
            else
            {
                MessageBox.Show(result);
                return false;
            }
        }

        private void FormPrincipal_VisibleChanged(object sender, EventArgs e)
        {
            IniciarForm();
        }
    }
} 
