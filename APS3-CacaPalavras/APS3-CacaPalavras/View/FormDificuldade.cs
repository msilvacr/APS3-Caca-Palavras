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
    public partial class FormDificuldade : Form
    {
        public FormDificuldade()
        {
            InitializeComponent();
        }

        //eventos
        //btnDificil
        private void btnDificil_Click(object sender, EventArgs e)
        {
            Selecao(3);
        }
        private void btnDificil_MouseEnter(object sender, EventArgs e)
        {
            this.btnDificil.BackColor = Color.FromArgb(255, 255, 255);
            this.btnDificil.ForeColor = Color.FromArgb(217, 81, 51);
        }
        private void btnDificil_MouseLeave(object sender, EventArgs e)
        {
            this.btnDificil.ForeColor = Color.FromArgb(255, 255, 255);
            this.btnDificil.BackColor = Color.FromArgb(217, 81, 51);

        }


        //btnNormal
        private void btnNormal_Click(object sender, EventArgs e)
        {
            Selecao(2);
        }
        private void btnNormal_MouseEnter(object sender, EventArgs e)
        {
            this.btnNormal.ForeColor = Color.FromArgb(58, 65, 84);
            this.btnNormal.BackColor = Color.FromArgb(255, 255, 255);
        }
        private void btnNormal_MouseLeave(object sender, EventArgs e)
        {
            this.btnNormal.BackColor = Color.FromArgb(58, 65, 84);
            this.btnNormal.ForeColor = Color.FromArgb(255, 255, 255);
        }


        //btnFacil
        private void btnFacil_Click(object sender, EventArgs e)
        {
            Selecao(1);
        }
        private void btnFacil_MouseEnter(object sender, EventArgs e)
        {
            this.btnFacil.BackColor = Color.FromArgb(255, 255, 255);
            this.btnFacil.ForeColor = Color.Green;
        }
        private void btnFacil_MouseLeave(object sender, EventArgs e)
        {
            this.btnFacil.BackColor = Color.Green;
            this.btnFacil.ForeColor = Color.FromArgb(255, 255, 255);

        }


        //métodos
        private void Selecao(int dfc)
        {
            FormTelaPrincipal.dificuldade = dfc;
            this.Dispose();
        }
    }
}
