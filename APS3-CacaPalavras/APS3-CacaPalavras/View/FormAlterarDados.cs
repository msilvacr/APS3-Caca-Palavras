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
    public partial class FormAlterarDados : Form
    {
        public FormAlterarDados()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            IniciarForm();
        }

        private void IniciarForm()
        {
            //inserindo nome do usuário logado ao text do form
            this.Text = "Woopy! - Cadastro: " + UsuarioLogado.User.Nome;

            this.txtNome.Text = UsuarioLogado.User.Nome;
            this.txtDtNascimento.Text = UsuarioLogado.User.DtNascimento.ToString();
            this.txtTelefone.Text = UsuarioLogado.User.Telefone;

            txtNome.ReadOnly = true;
            txtTelefone.ReadOnly = true;
        }


        //btnSalvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SalvarDados();
        }
        private void btnSalvar_MouseEnter_1(object sender, EventArgs e)
        {
            this.btnSalvar.ForeColor = Color.FromArgb(58, 65, 84);
            this.btnSalvar.BackColor = Color.FromArgb(255, 255, 255);
        }
        private void btnSalvar_MouseLeave_1(object sender, EventArgs e)
        {
            this.btnSalvar.BackColor = Color.FromArgb(58, 65, 84);
            this.btnSalvar.ForeColor = Color.FromArgb(255, 255, 255);
        }

        //btnCancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }
        private void btnCancelar_MouseEnter(object sender, EventArgs e)
        {
            this.btnCancelar.BackColor = Color.FromArgb(255, 255, 255);
            this.btnCancelar.ForeColor = Color.FromArgb(217, 81, 51);
        }
        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            this.btnCancelar.ForeColor = Color.FromArgb(255, 255, 255);
            this.btnCancelar.BackColor = Color.FromArgb(217, 81, 51);
        }

        //txtNome
        private void txtNome_Enter(object sender, EventArgs e)
        {
            txtNome.ReadOnly = false;
        }
        private void txtNome_Leave(object sender, EventArgs e)
        {
            txtNome.ReadOnly = true;
        }

        //txtTelefone
        private void txtTelefone_Enter(object sender, EventArgs e)
        {
            txtTelefone.ReadOnly = false;
        }
        private void txtTelefone_Leave(object sender, EventArgs e)
        {
            txtTelefone.ReadOnly = true;
        }



        //métodos
        private void SalvarDados()
        {
            if (txtNome.Text != UsuarioLogado.User.Nome || txtDtNascimento.Text != UsuarioLogado.User.DtNascimento.ToString() || txtTelefone.Text != UsuarioLogado.User.Telefone)
            {
                DBConn dBConn = new DBConn();

                dBConn.LimparParametros();

                dBConn.AdicionarParametros("@IDUsuario", UsuarioLogado.User.IdUsuario);
                dBConn.AdicionarParametros("@Nome", txtNome.Text);
                dBConn.AdicionarParametros("@DTNascimento", txtDtNascimento.Text);
                dBConn.AdicionarParametros("@Telefone", txtTelefone.Text);

                string resultado = dBConn.ExecutarManipulacao(CommandType.StoredProcedure, "cspAlterarDadosCadastro").ToString();

                if (resultado == "Sucesso!")
                {
                    MessageBox.Show("Informações alteradas com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);




                    UsuarioLogado.User.Telefone = txtTelefone.Text;
                    UsuarioLogado.User.Nome = txtNome.Text;
                    UsuarioLogado.User.DtNascimento = Convert.ToDateTime(txtDtNascimento.Text);

                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show(resultado);
                }
            }
        }
    }
} 
