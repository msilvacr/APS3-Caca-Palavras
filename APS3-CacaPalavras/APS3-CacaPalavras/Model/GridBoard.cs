using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APS3_CacaPalavras.Model
{
    class GridBoard
    {
        /// <summary>
        /// CONFIG MOV
        /// </summary>

        public static int[] firstCell = null; //armazena a primeira posição na tabela que foi selecionada [x,y]
        public static int[] distCell = null; //armazena [x, y] da celula mais distante da firstCell
        public static int[] distMovCell = null; //armazena a celula mais distante no eixo x, y, ou em diagonal, em relação a firstCell
        public static string movSentido = null; //armazena a orientação do movimento {V, H, D}

        //métodos
        public static DataGridView PopularGrid(DataGridView dataGridJogo)
        {
            int qtdXY = 13;
            //inserindo colunas
            for (int p = 0; p < qtdXY; p++)
            {
                dataGridJogo.Columns.Add(Convert.ToString(p), "");
            }
            //inserindo linhas
            for (int p = 0; p < qtdXY; p++)
            {
                dataGridJogo.Rows.Add();
            }
            //inserindo valor às celulas
            for (int i = 0; i < dataGridJogo.Rows.Count; ++i)
            {
                for (int c = 0; c < dataGridJogo.Columns.Count; c++)
                {
                    dataGridJogo[i, c].Value = string.Format("{0}, {1}", i, c);
                }
            }
            //definindo todas as celulas como readOnly
            for (int i = 0; i < dataGridJogo.Rows.Count; ++i)
            {
                for (int c = 0; c < dataGridJogo.Columns.Count; c++)
                {
                    dataGridJogo[i, c].ReadOnly = true;
                }
            }
            //redimensionar colunas
            foreach (DataGridViewColumn c in dataGridJogo.Columns)
                c.Width = dataGridJogo.Width / dataGridJogo.Columns.Count;

            foreach (DataGridViewRow r in dataGridJogo.Rows)
                r.Height = dataGridJogo.Height / dataGridJogo.Rows.Count;

            return dataGridJogo;
        }

        public static void IdentificarMov(DataGridView dataGridJogo)
        {
            //verificando se já foi definida a celula inicial
            if (firstCell != null)

            {
                //definindo a firstCell como celula aux para verificacão
                distMovCell = new int[2] { firstCell[0], firstCell[1] };

                //loop nas celulas selecionadas para encontrar celula mais distante 
                foreach (DataGridViewCell celulaVolta in dataGridJogo.SelectedCells)
                {
                    int distX = Math.Abs(celulaVolta.RowIndex - firstCell[0]);
                    int distXAnt = Math.Abs(distMovCell[0] - firstCell[0]);

                    int distY = Math.Abs(celulaVolta.ColumnIndex - firstCell[1]);
                    int distYAnt = Math.Abs(distMovCell[1] - firstCell[1]);

                    //Verificando se a distância para x é maior e se a distância para y é maior ou igual a da celula selecionada atualmente, em relação à firstCell
                    if (distX > distXAnt && distX > distYAnt && celulaVolta.ColumnIndex == firstCell[1])
                    {
                        distMovCell[0] = celulaVolta.RowIndex;
                        distMovCell[1] = celulaVolta.ColumnIndex;
                        movSentido = "V";
                    }
                    else if (distY > distYAnt && distY > distXAnt && celulaVolta.RowIndex == firstCell[0])
                    {
                        distMovCell[0] = celulaVolta.RowIndex;
                        distMovCell[1] = celulaVolta.ColumnIndex;
                        movSentido = "H";
                    }
                    else if (distX >= distXAnt && distY >= distYAnt && distX == distY)
                    {
                        distMovCell[0] = celulaVolta.RowIndex;
                        distMovCell[1] = celulaVolta.ColumnIndex;
                        movSentido = "D";
                    }
                }
            }
        }

        public static DataGridView SelecionarCelulasMovOrientacao(DataGridView dataGridJogo)
        {
            if (movSentido == "H")
            {
                for (int i = 0; i < Math.Abs(firstCell[1] - distMovCell[1]); i++)
                {
                    if (firstCell[1] - distMovCell[1] < 0)
                    {
                        dataGridJogo.Rows[firstCell[0]].Cells[firstCell[1] + i].Selected = true;
                    }
                    else
                    {
                        dataGridJogo.Rows[firstCell[0]].Cells[firstCell[1] - i].Selected = true;
                    }
                }
            }
            else if (movSentido == "V")
            {
                for (int i = 0; i < Math.Abs(firstCell[0] - distMovCell[0]); i++)
                {
                    if (firstCell[0] - distMovCell[0] < 0)
                    {
                        dataGridJogo.Rows[firstCell[0] + i].Cells[firstCell[1]].Selected = true;
                    }
                    else
                    {
                        dataGridJogo.Rows[firstCell[0] - i].Cells[firstCell[1]].Selected = true;
                    }
                }
            }
            else if (movSentido == "D")
            {
                int auxX = distMovCell[0] - firstCell[0];
                int auxY = distMovCell[1] - firstCell[1];

                int aux = Math.Abs(firstCell[0] - distMovCell[0]);


                for (int i = 0; i < aux; i++)
                {
                    if (auxX < 0 && auxY > 0)// /\  >>
                    {
                        dataGridJogo.Rows[firstCell[0] - i].Cells[firstCell[1] + i].Selected = true;
                    }
                    else if (auxX < 0 && auxY < 0)//   /\  <<
                    {
                        dataGridJogo.Rows[firstCell[0] - i].Cells[firstCell[1] - i].Selected = true;
                    }
                    else if (auxX > 0 && auxY > 0)//    \/  >>
                    {
                        dataGridJogo.Rows[firstCell[0] + i].Cells[firstCell[1] + i].Selected = true;
                    }
                    else if (auxX > 0 && auxY < 0)//   \/  <<
                    {
                        dataGridJogo.Rows[firstCell[0] + i].Cells[firstCell[1] - i].Selected = true;
                    }
                }
                //MessageBox.Show("DEU ALGO ERRADO");
            }
            return dataGridJogo;
        }

        public static DataGridView DeselecionarCelulasNaoMovOrientacao(DataGridView dataGridJogo)
        {
            foreach (DataGridViewCell cell in dataGridJogo.SelectedCells)
            {
                if (movSentido == "D")
                {

                    int cellX = Math.Abs(cell.RowIndex - firstCell[0]);
                    int cellY = Math.Abs(cell.ColumnIndex - firstCell[1]);
                    if (cellX != cellY)
                    {
                        cell.Selected = false;
                    }
                }
                else if (movSentido == "V")
                {
                    if (cell.ColumnIndex != firstCell[1])
                        cell.Selected = false;
                }
                else if (movSentido == "H")
                {
                    if (cell.RowIndex != firstCell[0])
                        cell.Selected = false;
                }
            }
            return dataGridJogo;
        }
    }
}
