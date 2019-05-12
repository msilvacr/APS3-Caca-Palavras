using APS3_CacaPalavras.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static APS3_CacaPalavras.Model.Palavra;

namespace APS3_CacaPalavras.Model
{
    class MatrizJogo
    {
        private static readonly string abcd = "ABCDEFGHIJKLMNOPQRSTUVWXYZÇ";

        public static bool Gerar(Palavra[] palavras, char[,] matriz)
        {
            Random rdn = new Random();

            int nPalavras = 0;
            int tentativas = 0;

            for (int i = 0; i < palavras.Length; i++)
            {
                tentativas = 0;

                //definindo número max de tentativas 
                while (true)
                {
                    tentativas += 1;
                    //gerando direcao e posicao inicial 
                    DirecaoECelulaInicialPalavra dl = gerarDirecaoELocalAleatorios(matriz.GetLength(0), JogoExecucao.jogo.NivelDificuldade);

                    //verificando se a direcao e a posicao inicial são 
                    if (verificarDirecao(dl, matriz, palavras[i].TextoPalavra))
                    {
                        nPalavras++;
                        palavras[i].CelulaInicial = dl.CelulaInicial;
                        CoordenadasPalavraEMatriz coordenadas = inserirCoordenadas(dl, palavras[i], matriz);

                        matriz = coordenadas.Matriz;

                        palavras[i].PosicaoPalavra = coordenadas.CoordenadaPalavra;

                        if (nPalavras == palavras.Length)
                        {
                            matriz = preencherEspacosMatriz(matriz, rdn);

                            JogoExecucao.jogo.MatrizJogo = matriz;
                            JogoExecucao.jogo.Palavras = palavras;

                            return true;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        tentativas++;

                        if (tentativas >= 1000000)
                        {
                            MessageBox.Show("ESSA RODADA FOI FALHA, TENTEI MAIS DE 1000X MONTAR A MATRIZ, MAS NÃO OBTIVE SUCESSO :(");
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        private static char[,] preencherEspacosMatriz(char[,] matriz, Random rdn)
        {
            for(int x = 0; x < matriz.GetLength(0); x++)
            {
                for (int y = 0; y < matriz.GetLength(0); y++)
                {
                    if(matriz[x,y] == '\0')
                    {
                        matriz[x, y] = gerarCharAleatorio(rdn);
                    }
                }
            }
            return matriz;
        }

        private static char gerarCharAleatorio(Random rdn)
        {
            int index = rdn.Next(abcd.Length);

            return abcd[index];
        }

        private static CoordenadasPalavraEMatriz inserirCoordenadas(DirecaoECelulaInicialPalavra dl, Palavra palavra, char[,] matriz)
        {
            CoordenadasPalavraEMatriz coordenadas = new CoordenadasPalavraEMatriz();
            //criando obj coordenada palavra com tamanho de linhas igual ao de letras da palavra
            coordenadas.CoordenadaPalavra = new int[palavra.TextoPalavra.Length, 2];

            for (int i = 0; i < palavra.TextoPalavra.Length; i++)
            {
                matriz[dl.CelulaInicial[0, 0] + (i * dl.X), dl.CelulaInicial[0, 1] + (i * dl.Y)] = palavra.TextoPalavra[i];

                coordenadas.CoordenadaPalavra[i, 0] = dl.CelulaInicial[0, 0] + (i * dl.X);
                coordenadas.CoordenadaPalavra[i, 1] = dl.CelulaInicial[0, 1] + (i * dl.Y);
            }
            coordenadas.Matriz = matriz;

            return coordenadas;
        }

        private static char[,] inserirPalavraMatriz(DirecaoECelulaInicialPalavra dl, char[,] matriz, string palavra)
        {

            for (int i = 0; i < palavra.Length; i++)
            {
                matriz[dl.CelulaInicial[0, 0] + (i * dl.X), dl.CelulaInicial[0, 1] + (i * dl.Y)] = palavra[i];
            }

            return matriz;
        }

        private static bool verificarDirecao(DirecaoECelulaInicialPalavra dl, char[,] matriz, string palavra)
        {

            //CALCULA QUAL SERÁ A ULTIMA CELULA A SER PREENCHIDA PELA PALAVRA DE ACORDO COM O TAMANHO E A POSIÇAO DELA 
            int[,] ultP = new int[1, 2] { { dl.CelulaInicial[0, 0] + (dl.X * palavra.Length), dl.CelulaInicial[0, 1] + (dl.Y * palavra.Length) } };

            //VERIFICANDO SE O X E Y DA ULTIMA CELULA QUE A PALAVRA IRÁ PREENCHER SÃO MAIORES MENORES QUE O TAMANHO MAX DA MATRZ
            if (ultP[0, 0] > matriz.GetLength(0) || ultP[0, 1] > matriz.GetLength(1))
            {
                return false;
            }
            //VERIFICANDO SE O X E Y DA ULTIMA CELULA QUE A PALAVRA IRÁ PREENCHER SÃO MAIORES QUE 0 
            else if (ultP[0, 0] < 0 || ultP[0, 1] < 0)
            {
                return false;
            }
            else
            {   //VERIFICANDO VALORES NAS CELULAS
                for (int i = 0; i < palavra.Length; i++)
                {
                    //pegando posicao x da celula
                    int xCelula = dl.CelulaInicial[0, 0] + (i * dl.X);
                    int yCelula = dl.CelulaInicial[0, 1] + (i * dl.Y);

                    //pegando valor da célula
                    char valorCelulaMatriz = matriz[xCelula, yCelula];

                    //VERIFICANDO SE A CELULA POSSUI VALOR NULO ('\0') EQUIVALE AO STRING.EMPTY PARA CHARS
                    if (valorCelulaMatriz != '\0')
                    {
                        //VERIFICANDO SE O VALOR DA CÉLULA É IGUAL AO VALOR DO CHAR EM DETERMINADA POSICAO DA PALAVRA
                        if (valorCelulaMatriz != palavra[i])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private static DirecaoECelulaInicialPalavra gerarDirecaoELocalAleatorios(int tamanhoMatriz, int nivelDificuldade)
        {
            //gerando obj direcao + celulaInicial
            DirecaoECelulaInicialPalavra direcaoECelulaInicial = new DirecaoECelulaInicialPalavra();

            //gerando direcao aleatória
            Random random = new Random();

            switch (nivelDificuldade)
            {
                case 0:
                    //direcaoECelulaInicial.Direcao = (Direction)values.GetValue(random.Next(values.Length));
                    direcaoECelulaInicial.Direcao = (Direction)Enum.ToObject(typeof(Direction), random.Next(0, 2));
                    break;
                case 1:
                    //direcaoECelulaInicial.Direcao = (Direction)values.GetValue(random.Next(values.Length));
                    direcaoECelulaInicial.Direcao = (Direction)Enum.ToObject(typeof(Direction), random.Next(0, 4));
                    break;
                case 2:
                    //direcaoECelulaInicial.Direcao = (Direction)values.GetValue(random.Next(values.Length));
                    direcaoECelulaInicial.Direcao = (Direction)Enum.ToObject(typeof(Direction), random.Next(0, 6));
                    break;
                case 3:
                    //direcaoECelulaInicial.Direcao = (Direction)values.GetValue(random.Next(values.Length));
                    direcaoECelulaInicial.Direcao = (Direction)Enum.ToObject(typeof(Direction), random.Next(0, 8));
                    break;

                default:
                    MessageBox.Show("O jogo não possui nível de difiduldade");
                    break;

            }


            //gerando posicao inicial aleatória com base no tamanho da matriz
            direcaoECelulaInicial.CelulaInicial = new int[1,2] { { random.Next(tamanhoMatriz), random.Next(tamanhoMatriz) } };

            //
            ///INSERINDO VALORES PARA X E Y DE ACORDO COM A DIRECAO
            switch (direcaoECelulaInicial.Direcao)
            {
                case (Direction.Cima):
                    direcaoECelulaInicial.X = -1;
                    direcaoECelulaInicial.Y = 0;
                    break;
                case (Direction.CimaDireita):
                    direcaoECelulaInicial.X = -1;
                    direcaoECelulaInicial.Y = 1;
                    break;
                case (Direction.Direita):
                    direcaoECelulaInicial.X = 0;
                    direcaoECelulaInicial.Y = 1;
                    break;
                case (Direction.BaixoDireita):
                    direcaoECelulaInicial.X = 1;
                    direcaoECelulaInicial.Y = 1;
                    break;
                case (Direction.Baixo):
                    direcaoECelulaInicial.X = 1;
                    direcaoECelulaInicial.Y = 0;
                    break;
                case (Direction.BaixoEsquerda):
                    direcaoECelulaInicial.X = 1;
                    direcaoECelulaInicial.Y = -1;
                    break;
                case (Direction.Esquerda):
                    direcaoECelulaInicial.X = 0;
                    direcaoECelulaInicial.Y = -1;
                    break;
                case (Direction.CimaEsquerda):
                    direcaoECelulaInicial.X = -1;
                    direcaoECelulaInicial.Y = -1;
                    break;

                default:
                    direcaoECelulaInicial.X = 0;
                    direcaoECelulaInicial.Y = 0;
                    MessageBox.Show("Alguma coisa deu errado no Switch de MatrizJogo.verificarDirecao");
                    break;
            }
            ///
            //

            //retornando LocalDirecaoPalavra
            return direcaoECelulaInicial;
        }
    }

    //classe auxiliar
    class CoordenadasPalavraEMatriz
    {
        private char[,] matriz;
        private int[,] coordenadaPalavra;

        public char[,] Matriz { get => matriz; set => matriz = value; }
        public int[,] CoordenadaPalavra { get => coordenadaPalavra; set => coordenadaPalavra = value; }
    }
    //classe auxiliar 
    class DirecaoECelulaInicialPalavra
    {
        private Direction direcao;
        private int[,] celulaInicial;
        private int x;
        private int y;

        public DirecaoECelulaInicialPalavra()
        {
        }

        public Direction Direcao { get => direcao; set => direcao = value; }
        public int[,] CelulaInicial { get => celulaInicial; set => celulaInicial = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
    }
}
