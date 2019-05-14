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
    public partial class FormJogoMatriz : Form
    {
        FormJogoControles formJogoControles;

        public FormJogoMatriz()
        {
            this.formJogoControles = formJogoControles = new FormJogoControles(this);

            InitializeComponent();
        }

        private void FrmJogo_Load(object sender, EventArgs e)
        {

            iniciarFormControles();

            //alterando fonte do grid a partir do nível de dificuldade
            alterarFonteGridPorDificuldade();

            //populando datagrid
            dataGridJogo = GameBoard.PopularGrid(dataGridJogo, JogoExecucao.jogo.MatrizJogo);
            dataGridJogo = GameBoard.AtualizarCoresGrid(dataGridJogo, JogoExecucao.jogo.Palavras);
            dataGridJogo.ClearSelection();
        }


        //eventos
        private void dataGridJogo_SelectionChanged(object sender, EventArgs e)
        {
            GameBoard.IdentificarMov(dataGridJogo);
            GameBoard.SelecionarCelulasMovOrientacao(dataGridJogo);
            GameBoard.DeselecionarCelulasNaoMovOrientacao(dataGridJogo);
        }

        private void dataGridJogo_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (GameBoard.primeiraCelula != null)
                {
                    GameBoard.celulaMaisDistante = new int[2] { e.RowIndex, e.ColumnIndex };
                }
            }
        }

        private void dataGridJogo_MouseUp(object sender, MouseEventArgs e)
        {
            GameBoard.primeiraCelula = null;
            GameBoard.celulaMaisDistante = null;
            GameBoard.celulaMaisDistanteMovimento = null;
            GameBoard.sentidoDoMovimento = null;

            verificarPalavraSelecionada();
            dataGridJogo.ClearSelection();

            GameBoard.atualizarDuracaoJogo();

        }

        private void dataGridJogo_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (GameBoard.primeiraCelula == null)
            {
                GameBoard.primeiraCelula = new int[2] { e.RowIndex, e.ColumnIndex };
            }
        }

        private void FormJogoMatriz_LocationChanged(object sender, EventArgs e)
        {
            formJogoControles.SetDesktopLocation(this.Location.X + this.Width - 7, this.Location.Y + 1);
            formJogoControles.Focus();
        }

        private void FormJogoMatriz_FormClosing(object sender, FormClosingEventArgs e)
        {
            GameBoard.atualizarDuracaoJogo();
            formJogoControles.Dispose();
            this.Dispose();
        }


        //métodos
        private void alterarFonteGridPorDificuldade()
        {
            switch (JogoExecucao.jogo.NivelDificuldade)
            {
                case 0:
                    this.dataGridJogo.Font = new Font("Serif", 12);
                    break;
                case 1:
                    this.dataGridJogo.Font = new Font("Serif", 11);
                    break;
                case 2:
                    this.dataGridJogo.Font = new Font("Serif", 10);
                    break;
                case 3:
                    this.dataGridJogo.Font = new Font("Serif", 8);
                    break;
                default:
                    break;
            }

        }

        private void verificarPalavraSelecionada()
        {
            if (dataGridJogo.SelectedCells.Count > 0)
            {
                for (int i = 0; i < JogoExecucao.jogo.Palavras.Length; i++)
                {
                    if (JogoExecucao.jogo.Palavras[i].StatusPalavra == false)
                    {
                        if (GameBoard.VerificarEAtualizarPalavra(gerarSelecaoPalavra()))
                        {
                            dataGridJogo = GameBoard.AtualizarCoresGrid(dataGridJogo, JogoExecucao.jogo.Palavras);
                            formJogoControles.atualizarCoresGrid();
                            verificarConclusaoJogo();
                        }
                    }
                }
            }
        }

        private int[,] gerarSelecaoPalavra()
        {
            int[,] selecao = new int[dataGridJogo.SelectedCells.Count, 2];

            int i = 0;
            foreach(DataGridViewCell cell in dataGridJogo.SelectedCells)
            {
                selecao[i, 0] = cell.RowIndex;
                selecao[i, 1] = cell.ColumnIndex;
                i++;
            }
            return selecao;
        }

        private void iniciarFormControles()
        {
            this.SetDesktopLocation(this.Location.X - formJogoControles.Width / 2, this.Location.Y);

            //criando e configurando form de controles do jogo
            formJogoControles.SetDesktopLocation(this.Location.X + this.Width - 7, this.Location.Y + 1);
            formJogoControles.StartPosition = FormStartPosition.Manual;
            formJogoControles.Show();
        }

        private void verificarConclusaoJogo()
        {
            bool conclusao = true;

            for(int i = 0; i < JogoExecucao.jogo.Palavras.Length; i++)
            {
                if (JogoExecucao.jogo.Palavras[i].StatusPalavra == false)
                {
                    conclusao = false;
                }
            }
            if(conclusao)
            {
                ConcluirJogo();
            }
        }

        private void ConcluirJogo()
        {
            formJogoControles.pausar();

            JogoExecucao.jogo.StatusJogo = true;

            GameBoard.concluirJogo();

            TimeSpan duracaoJogoTotal = JogoExecucao.jogo.DuracaoJogo;
            string strDuracao = string.Format("{0}:{1}:{2}", duracaoJogoTotal.Hours, duracaoJogoTotal.Minutes, duracaoJogoTotal.Seconds);

            MessageBox.Show("O jogo foi concluído em: " + duracaoJogoTotal, "Parabens!", MessageBoxButtons.OK, MessageBoxIcon.Information);


            this.Dispose();
        }

    }
}
