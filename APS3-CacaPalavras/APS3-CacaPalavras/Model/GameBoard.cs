﻿using APS3_CacaPalavras.ModelConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APS3_CacaPalavras.Model
{
    class GameBoard
    {
        //auxiliares 
        public static int[] primeiraCelula = null; //armazena a primeira posição na tabela que foi selecionada [x,y]
        public static int[] celulaMaisDistante = null; //armazena [x, y] da celula mais distante da firstCell
        public static int[] celulaMaisDistanteMovimento = null; //armazena a celula mais distante no eixo x, y, ou em diagonal, em relação a firstCell
        public static string sentidoDoMovimento = null; //armazena a orientação do movimento {V, H, D}

        public static object DBconn { get; private set; }

        //métodos do jogo

        //PALAVRA
        public static bool VerificarEAtualizarPalavra(int[,] selecao)
        {
            for (int i = 0; i < JogoExecucao.jogo.Palavras.Length; i++)
            {
                if (JogoExecucao.jogo.Palavras[i].StatusPalavra == false)
                {
                    if (JogoExecucao.jogo.Palavras[i].TextoPalavra.Length == selecao.GetLength(0))
                    {
                        int[,] posicaoPalavra = JogoExecucao.jogo.Palavras[i].PosicaoPalavra;

                        //aplicando mesma ordenação para ambas as matrizes
                        posicaoPalavra = ordenarMatriz(posicaoPalavra);
                        selecao = ordenarMatriz(selecao);

                        //verificando se as matrizes são iguais
                        var equal = selecao.Rank == posicaoPalavra.Rank &&
                        Enumerable.Range(0, selecao.Rank).All(dimension => selecao.GetLength(dimension) == posicaoPalavra.GetLength(dimension)) &&
                        selecao.Cast<int>().SequenceEqual(posicaoPalavra.Cast<int>());

                        if(Convert.ToBoolean(equal))
                        {
                            JogoExecucao.jogo.Palavras[i].StatusPalavra = true;
                            atualizarPalavraDB(JogoExecucao.jogo.Palavras[i]);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private static void atualizarPalavraDB(Palavra palavra)
        {
            DBConn dBconn = new DBConn();

            dBconn.LimparParametros();

            dBconn.AdicionarParametros("@IDPalavraJogo", palavra.IdPalavraJogo);
            dBconn.AdicionarParametros("@StatusPalavra", Convert.ToInt16(true));

            string result = dBconn.ExecutarManipulacao(CommandType.StoredProcedure, "uspPalavraJogoAtualizarStatus").ToString();


        }

        public static int[,] ordenarMatriz(int[,] matriz)
        {
            //ordenando y
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for(int j = 0; j < matriz.GetLength(0); j++)
                {
                    if (matriz[i, 1] > matriz[j, 1])
                    {
                        int auxX = matriz[j, 0];
                        int auxY = matriz[j, 1];

                        matriz[j, 0] = matriz[i, 0];
                        matriz[j, 1] = matriz[i, 1];

                        matriz[i, 0] = auxX;
                        matriz[i, 1] = auxY;
                    }
                }
            }
            
            //ordenando x
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for(int j =0; j < matriz.GetLength(0); j++)
                {
                    if(matriz[i,0] > matriz[j,0])
                    {
                        int auxX = matriz[j, 0];
                        int auxY = matriz[j, 1];

                        matriz[j, 0] = matriz[i, 0];
                        matriz[j, 1] = matriz[i, 1];

                        matriz[i, 0] = auxX;
                        matriz[i, 1] = auxY;
                    }
                }
            }

            return matriz;
        }


        //JOGO
        public static void atualizarDuracaoJogo()
        {
            DBConn dBConn = new DBConn();

            dBConn.LimparParametros();

            dBConn.AdicionarParametros("@IDJogo", JogoExecucao.jogo.IdJogo);

            TimeSpan dJogo = JogoExecucao.jogo.DuracaoJogo;
            string strDuracao = string.Format("{0}:{1}:{2}", dJogo.Hours, dJogo.Minutes, dJogo.Seconds);

            dBConn.AdicionarParametros("@Duracao", strDuracao);

            string result = dBConn.ExecutarManipulacao(CommandType.StoredProcedure, "uspJogoAtualizarDuracao").ToString();

            if(result == "O Jogo não existe")
            {
                MessageBox.Show("Deu merda aqui");
            }
        }

        public static void verificarConclusaoJogo()
        {

        }

        public static void concluirJogo()
        {
            DBConn dBConn = new DBConn();

            dBConn.LimparParametros();

            dBConn.AdicionarParametros("@IDJogo", JogoExecucao.jogo.IdJogo);

            dBConn.AdicionarParametros("@StatusJogo", Convert.ToInt16(JogoExecucao.jogo.StatusJogo));

            string result = dBConn.ExecutarManipulacao(CommandType.StoredProcedure, "uspJogoAtualizarStatus").ToString();

            if(result == "O Jogo não existe")
            {
                MessageBox.Show("Deu ruim aqui");
            }


        }


        
        
        //MATRIZ
        public static DataGridView PopularGrid(DataGridView dataGridJogo, char[,] matriz)
        {
            
            //inserindo colunas
            for (int p = 0; p < matriz.GetLength(1); p++)
            {
                dataGridJogo.Columns.Add(Convert.ToString(p), "");
            }
            //inserindo linhas
            for (int p = 0; p < matriz.GetLength(0); p++)
            {
                dataGridJogo.Rows.Add();
            }
            //inserindo valor às celulas
            for (int i = 0; i < dataGridJogo.Rows.Count; ++i)
            {
                for (int c = 0; c < dataGridJogo.Columns.Count; c++)
                {
                    dataGridJogo.Rows[i].Cells[c].Value = matriz[i,c];
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

        public static DataGridView AtualizarCoresGrid(DataGridView datagridataGridJogo, Palavra[] palavras)
        {
            for (int i = 0; i < palavras.Length; i++)
            {

                if(palavras[i].StatusPalavra == true)
                {
                    string auxCorPalavra = palavras[i].CorPalavra;

                    int r = 0;
                    int g = 0;
                    int b = 0;

                    string auxR = "";
                    string auxG = "";
                    string auxB = "";

                    foreach (char c in auxCorPalavra)
                    {
                        if(c != ',')
                        {
                            auxR += c;
                            auxCorPalavra = auxCorPalavra.Substring(1);
                        }
                        else
                        {
                            auxCorPalavra = auxCorPalavra.Substring(1);
                            r = Convert.ToInt32(auxR);
                            break;
                        }
                    }
                    foreach (char c in auxCorPalavra)
                    {
                        if (c != ',')
                        {
                            auxG += c;
                            auxCorPalavra = auxCorPalavra.Substring(1);
                        }
                        else
                        {
                            auxCorPalavra = auxCorPalavra.Substring(1);
                            g = Convert.ToInt32(auxG);
                            break;
                        }
                    }
                    foreach (char c in auxCorPalavra)
                    {
                        if (c != ',')
                        {
                            auxB += c;
                            auxCorPalavra = auxCorPalavra.Substring(1);
                        }
                        else
                        {
                            b = Convert.ToInt32(auxB);
                            break;
                        }
                    }

                    Color cor = Color.FromArgb(r, g, b);

                    for ( int j = 0; j < palavras[i].PosicaoPalavra.GetLength(0); j ++)
                    {
                        datagridataGridJogo.Rows[palavras[i].PosicaoPalavra[j, 0]].Cells[palavras[i].PosicaoPalavra[j, 1]].Style.BackColor = cor;
                    }
                }
            }
            return datagridataGridJogo;
        }

        public static void IdentificarMov(DataGridView dataGridJogo)
        {
            //verificando se já foi definida a celula inicial
            if (primeiraCelula != null)

            {
                //definindo a firstCell como celula aux para verificacão
                celulaMaisDistanteMovimento = new int[2] { primeiraCelula[0], primeiraCelula[1] };

                //loop nas celulas selecionadas para encontrar celula mais distante 
                foreach (DataGridViewCell celulaVolta in dataGridJogo.SelectedCells)
                {
                    int distX = Math.Abs(celulaVolta.RowIndex - primeiraCelula[0]);
                    int distXAnt = Math.Abs(celulaMaisDistanteMovimento[0] - primeiraCelula[0]);

                    int distY = Math.Abs(celulaVolta.ColumnIndex - primeiraCelula[1]);
                    int distYAnt = Math.Abs(celulaMaisDistanteMovimento[1] - primeiraCelula[1]);

                    //Verificando se a distância para x é maior e se a distância para y é maior ou igual a da celula selecionada atualmente, em relação à firstCell
                    if (distX > distXAnt && distX > distYAnt && celulaVolta.ColumnIndex == primeiraCelula[1])
                    {
                        celulaMaisDistanteMovimento[0] = celulaVolta.RowIndex;
                        celulaMaisDistanteMovimento[1] = celulaVolta.ColumnIndex;
                        sentidoDoMovimento = "V";
                    }
                    else if (distY > distYAnt && distY > distXAnt && celulaVolta.RowIndex == primeiraCelula[0])
                    {
                        celulaMaisDistanteMovimento[0] = celulaVolta.RowIndex;
                        celulaMaisDistanteMovimento[1] = celulaVolta.ColumnIndex;
                        sentidoDoMovimento = "H";
                    }
                    else if (distX >= distXAnt && distY >= distYAnt && distX == distY)
                    {
                        celulaMaisDistanteMovimento[0] = celulaVolta.RowIndex;
                        celulaMaisDistanteMovimento[1] = celulaVolta.ColumnIndex;
                        sentidoDoMovimento = "D";
                    }
                }
            }
        }

        public static DataGridView SelecionarCelulasMovOrientacao(DataGridView dataGridJogo)
        {
            if (sentidoDoMovimento == "H")
            {
                for (int i = 0; i < Math.Abs(primeiraCelula[1] - celulaMaisDistanteMovimento[1]); i++)
                {
                    if (primeiraCelula[1] - celulaMaisDistanteMovimento[1] < 0)
                    {
                        dataGridJogo.Rows[primeiraCelula[0]].Cells[primeiraCelula[1] + i].Selected = true;
                    }
                    else
                    {
                        dataGridJogo.Rows[primeiraCelula[0]].Cells[primeiraCelula[1] - i].Selected = true;
                    }
                }
            }
            else if (sentidoDoMovimento == "V")
            {
                for (int i = 0; i < Math.Abs(primeiraCelula[0] - celulaMaisDistanteMovimento[0]); i++)
                {
                    if (primeiraCelula[0] - celulaMaisDistanteMovimento[0] < 0)
                    {
                        dataGridJogo.Rows[primeiraCelula[0] + i].Cells[primeiraCelula[1]].Selected = true;
                    }
                    else
                    {
                        dataGridJogo.Rows[primeiraCelula[0] - i].Cells[primeiraCelula[1]].Selected = true;
                    }
                }
            }
            else if (sentidoDoMovimento == "D")
            {
                int auxX = celulaMaisDistanteMovimento[0] - primeiraCelula[0];
                int auxY = celulaMaisDistanteMovimento[1] - primeiraCelula[1];

                int aux = Math.Abs(primeiraCelula[0] - celulaMaisDistanteMovimento[0]);


                for (int i = 0; i < aux; i++)
                {
                    if (auxX < 0 && auxY > 0)// /\  >>
                    {
                        dataGridJogo.Rows[primeiraCelula[0] - i].Cells[primeiraCelula[1] + i].Selected = true;
                    }
                    else if (auxX < 0 && auxY < 0)//   /\  <<
                    {
                        dataGridJogo.Rows[primeiraCelula[0] - i].Cells[primeiraCelula[1] - i].Selected = true;
                    }
                    else if (auxX > 0 && auxY > 0)//    \/  >>
                    {
                        dataGridJogo.Rows[primeiraCelula[0] + i].Cells[primeiraCelula[1] + i].Selected = true;
                    }
                    else if (auxX > 0 && auxY < 0)//   \/  <<
                    {
                        dataGridJogo.Rows[primeiraCelula[0] + i].Cells[primeiraCelula[1] - i].Selected = true;
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
                if (sentidoDoMovimento == "D")
                {

                    int cellX = Math.Abs(cell.RowIndex - primeiraCelula[0]);
                    int cellY = Math.Abs(cell.ColumnIndex - primeiraCelula[1]);
                    if (cellX != cellY)
                    {
                        cell.Selected = false;
                    }
                }
                else if (sentidoDoMovimento == "V")
                {
                    if (cell.ColumnIndex != primeiraCelula[1])
                        cell.Selected = false;
                }
                else if (sentidoDoMovimento == "H")
                {
                    if (cell.RowIndex != primeiraCelula[0])
                        cell.Selected = false;
                }
            }
            return dataGridJogo;
        }
    }
}
