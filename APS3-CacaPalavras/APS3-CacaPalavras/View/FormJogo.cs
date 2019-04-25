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
            this.PopularTabelaFormatarTabela();
        }

        private void IniciarJogo()
        {

        }
        private void CriarJogo()
        {

        }




        /// <summary>
        /// TESTES ABAIXO
        /// </summary>


        public int i = 0; //contador de eventos
        public int[] firstCell = null; //armazena a primeira posição na tabela que foi selecionada [x,y]
        int[] auxCell = null; //armazena [x, y] da celula mais distante da firstCell

        private void PopularTabelaFormatarTabela()
        {

            int size = 30;
            dataGridJogo.RowTemplate.Height = size;

            for (int p = 0; p < 14; p++)
            {
                dataGridJogo.Columns.Add(Convert.ToString(p), "");
                dataGridJogo.Columns[Convert.ToInt32(p)].Width = size;
                dataGridJogo.Columns[Convert.ToInt32(p)].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridJogo.Columns[Convert.ToInt32(p)].Resizable = DataGridViewTriState.False;
            }
            //popular
            for (int p = 0; p < 14; p++)
            {
                dataGridJogo.Rows.Add();
            }
            for (int i = 0; i < dataGridJogo.Rows.Count; ++i)
            {
                for (int c = 0; c < dataGridJogo.Columns.Count; c++)
                {
                    dataGridJogo.Rows[i].Cells[c].Value = string.Format("{0}, {1}", i, c);
                }

            }

            //formatar
            dataGridJogo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridJogo.AllowUserToResizeRows = false;
        }


        private void dataGridJogo_SelectionChanged(object sender, EventArgs e)
        {
            this.Text = "";
            //contador de celulas verificadas no foreach
            int teste = 0;


            //verificando se já foi definida a celula inicial
            if (dataGridJogo.SelectedCells.Count == 1)
            {
                firstCell = new int[] { Convert.ToInt16(dataGridJogo.CurrentCell.RowIndex), Convert.ToInt16(dataGridJogo.CurrentCell.ColumnIndex) };
            }

            else
            {
                //definindo a firstCell como celula aux para verificacão
                auxCell = new int[2] { firstCell[0], firstCell[1] };

                //loop nas celulas selecionadas para encontrar celula mais distante 
                foreach (DataGridViewCell celulaVolta in dataGridJogo.SelectedCells)
                {
                    teste++;
                    int distX = Math.Abs(celulaVolta.RowIndex - firstCell[0]);
                    int distXAnt = Math.Abs(auxCell[0] - firstCell[0]);

                    int distY = Math.Abs(celulaVolta.ColumnIndex - firstCell[1]);
                    int distYAnt = Math.Abs(auxCell[1] - firstCell[1]);

                    //Verificando se a distância para x é maior e se a distância para y é maior ou igual a da celula selecionada atualmente, em relação à firstCell
                    if (distX > distXAnt && distX > distYAnt && celulaVolta.ColumnIndex == firstCell[1])
                    {
                        auxCell[0] = celulaVolta.RowIndex;
                        auxCell[1] = celulaVolta.ColumnIndex;

                        this.Text = string.Format("[{0}, {1}] - Vertical", auxCell[0], auxCell[1]);
                    }
                    if (distY > distYAnt && distY > distXAnt && celulaVolta.RowIndex == firstCell[0])
                    {
                        auxCell[0] = celulaVolta.RowIndex;
                        auxCell[1] = celulaVolta.ColumnIndex;

                        this.Text = string.Format("[{0}, {1}] - Horizontal", auxCell[0], auxCell[1]);
                    }
                    if (distX >= distXAnt && distY >= distYAnt && distX == distY)
                    {
                        auxCell[0] = celulaVolta.RowIndex;
                        auxCell[1] = celulaVolta.ColumnIndex;

                        this.Text = string.Format("[{0}, {1}] - Diagonal", auxCell[0], auxCell[1]);
                    }
                }
            }
        }
    }
}
