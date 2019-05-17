using APS3_CacaPalavras.Model;
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
    public partial class FormJogoControles : Form
    {
        private readonly int SIZE_OF_HEIGHT_COLUNS_GRID = 33;

        bool pausado = false;

        FormJogoMatriz FormJogoMatriz;

        public FormJogoControles(FormJogoMatriz formJogoMatriz)
        {
            InitializeComponent();
            timerJogo.Start();
            this.FormJogoMatriz = formJogoMatriz;
            this.popularGrid();
        }


        //eventos
        private void timerJogo_Tick(object sender, EventArgs e)
        {
            JogoExecucao.jogo.DuracaoJogo = JogoExecucao.jogo.DuracaoJogo + TimeSpan.FromSeconds(1);

            txtDuracao.Text = JogoExecucao.jogo.DuracaoJogo.ToString(@"hh\:mm\:ss");
        }

        private void FormJogoControles_Load(object sender, EventArgs e)
        {
            this.dataGridPalavrasJogo.ClearSelection();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if(!pausado)
            {
                pausar();
            }
            else
            {
                despausar();
            }
        }

        private void dataGridPalavrasJogo_CurrentCellChanged(object sender, EventArgs e)
        {
            this.dataGridPalavrasJogo.ClearSelection();
        }

        private void dataGridPalavrasJogo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.dataGridPalavrasJogo.ClearSelection();
        }


        //métodos
        public void pausar()
        {
            this.pausado = true;
            btnPause.Text = "Continuar";
            timerJogo.Stop();
            FormJogoMatriz.dataGridJogo.ForeColor = Color.White;
            FormJogoMatriz.Enabled = false;
        }

        public void despausar()
        {
            this.pausado = false;
            btnPause.Text = "Pausar";
            timerJogo.Start();
            FormJogoMatriz.dataGridJogo.ForeColor = Color.Black;
            FormJogoMatriz.Enabled = true;
        }

        private void popularGrid()
        {
            for(int i = 0; i < JogoExecucao.jogo.Palavras.Length; i++)
            {
                dataGridPalavrasJogo.Rows.Add();

                dataGridPalavrasJogo.Rows[i].Height = SIZE_OF_HEIGHT_COLUNS_GRID;

                dataGridPalavrasJogo.Rows[i].Cells[0].Value = JogoExecucao.jogo.Palavras[i].TextoPalavra;

                dataGridPalavrasJogo.Rows[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public void atualizarCoresGrid()
        {
            foreach(Palavra p in JogoExecucao.jogo.Palavras)
            {
                if (p.StatusPalavra == true)
                {
                    for(int i = 0; i < dataGridPalavrasJogo.Rows.Count; i++)
                    {
                        if(p.TextoPalavra == dataGridPalavrasJogo.Rows[i].Cells[0].Value.ToString())
                        {
                            dataGridPalavrasJogo.Rows[i].Cells[0].Style.ForeColor = Color.Green;
                            dataGridPalavrasJogo.Rows[i].Cells[0].Style.Font = new Font("Microsoft Sans Serif", 17, FontStyle.Bold);
                        }
                    }
                }
            }
        }

    }
}
