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
    public partial class FormJogo : Form
    {


        public FormJogo()
        {
            InitializeComponent();
        }

        private void FrmJogo_Load(object sender, EventArgs e)
        {
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
                if (GameBoard.firstCell != null)
                {
                    GameBoard.distCell = new int[2] { e.RowIndex, e.ColumnIndex };
                }
            }
        }

        private void dataGridJogo_MouseUp(object sender, MouseEventArgs e)
        {
            GameBoard.firstCell = null;
            GameBoard.distCell = null;
            GameBoard.distMovCell = null;
            GameBoard.movSentido = null;
        }
        private void dataGridJogo_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (GameBoard.firstCell == null)
            {
                GameBoard.firstCell = new int[2] { e.RowIndex, e.ColumnIndex };
            }
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

        private void dataGridJogo_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            for(int i = 0; i < JogoExecucao.jogo.Palavras.Length; i++)
            {
                if(JogoExecucao.jogo.Palavras[i].StatusPalavra == false)
                {
                    if(GameBoard.VerificarEAtualizarPalavra(gerarSelecaoPalavra()))
                    {
                        dataGridJogo = GameBoard.AtualizarCoresGrid(dataGridJogo, JogoExecucao.jogo.Palavras);
                    }
                }
            }
            dataGridJogo.ClearSelection();
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

        private void verificarConclusaoJogo()
        {

        }
        private void ConcluirJogo()
        {

        }
    }
}
