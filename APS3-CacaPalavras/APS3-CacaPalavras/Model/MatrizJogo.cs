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
        public static void gerar(Palavra[] palavras, char[,] matriz)
        {
            bool gridFull = false;

            int nPalavras = 0;

            while (!gridFull)
            {
                for (int i = 0; i < palavras.Length; i++)
                {
                    int tentativas = 0;

                    while (tentativas < 1000)
                    {
                        //gerando direcao e posicao inicial 
                        DirecaoECelulaInicialPalavra dl = gerarDirecaoELocalAleatorios(matriz.GetLength(0));

                        //verificando se a direcao e a posicao inicial são 
                        if (verificarDirecao(dl, matriz, palavras[i].TextoPalavra))
                        {
                            CoordenadasPalavraEMatriz coordenadas = InserirCoordenadas(dl, palavras[i], matriz);
                            matriz = coordenadas.matriz;
                            palavras[i].PosicaoPalavra = coordenadas.coordenadaPalavra;

                            nPalavras++;

                            if (nPalavras == palavras.Length)
                            {
                                gridFull = true;
                                break;
                            }
                        }
                        else
                        {
                            tentativas++;
                        }
                    }
                }
            }
        }

        private static CoordenadasPalavraEMatriz InserirCoordenadas(DirecaoECelulaInicialPalavra dl, Palavra palavra, char[,] matriz)
        {
            CoordenadasPalavraEMatriz coordenadas = new CoordenadasPalavraEMatriz();

            for (int i = 0; i < palavra.TextoPalavra.Length; i++)
            {
                matriz[dl.local[0, 0] + (i * dl.x), dl.local[0, 1] + (i * dl.y)] = palavra.TextoPalavra[i];
                coordenadas.coordenadaPalavra[0, i] = dl.local[0, 0] + (i * dl.x);
                coordenadas.coordenadaPalavra[1, i] = dl.local[0, 1] + (i * dl.y);
            }
            coordenadas.matriz = matriz;

            return coordenadas;
        }

        private static char[,] inserirPalavraMatriz(DirecaoECelulaInicialPalavra dl, char[,] matriz, string palavra)
        {

            for (int i = 0; i < palavra.Length; i++)
            {
                matriz[dl.local[0, 0] + (i * dl.x), dl.local[0, 1] + (i * dl.y)] = palavra[i];
            }

            return matriz;
        }

        private static bool verificarDirecao(DirecaoECelulaInicialPalavra dl, char[,] matriz, string palavra)
        {
            bool direcaoEPossivel = true;

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                //pegando posicao x da celula
                int xCelula = dl.local[0, 0] + (i * dl.x);
                int yCelula = dl.local[0, 1] + (i * dl.y);
                //pegando valor da célula
                char valorCelulaMatriz = matriz[xCelula, yCelula];

                if (char.IsWhiteSpace(valorCelulaMatriz))
                {
                    MessageBox.Show(string.Format("Posição [{0}, {1}] da matriz está vazia!", xCelula, yCelula));
                }
                else if (valorCelulaMatriz == palavra[i])
                {
                    MessageBox.Show(string.Format("O TEXTO Posição [{0}, {1}] da matriz É IGUAL AO DA PALAVRA  {2} == {3}!", xCelula, yCelula, valorCelulaMatriz, palavra[i]));
                }
                else
                {
                    direcaoEPossivel = false;
                    break;
                }
            }

            return direcaoEPossivel;
        }

        private static DirecaoECelulaInicialPalavra gerarDirecaoELocalAleatorios(int tamanhoMatriz)
        {
            //gerando obj direcao + local
            DirecaoECelulaInicialPalavra direcaoLocal = new DirecaoECelulaInicialPalavra();

            //gerando direcao aleatória do enum Palavra.Direction
            Array values = Enum.GetValues(typeof(Direction));
            Random random = new Random();
            direcaoLocal.direcao = (Direction)values.GetValue(random.Next(values.Length));

            //gerando posicao inicial aleatória com base no tamanho da matriz
            int[] local = new int[2] { random.Next(tamanhoMatriz), random.Next(tamanhoMatriz) };

            //
            ///INSERINDO VALORES PARA X E Y DE ACORDO COM A DIRECAO
            switch (direcaoLocal.direcao)
            {
                case (Direction.Cima):
                    direcaoLocal.x = -1;
                    direcaoLocal.y = 0;
                    break;
                case (Direction.CimaDireita):
                    direcaoLocal.x = -1;
                    direcaoLocal.y = 1;
                    break;
                case (Direction.Direita):
                    direcaoLocal.x = 0;
                    direcaoLocal.y = 1;
                    break;
                case (Direction.BaixoDireita):
                    direcaoLocal.x = 1;
                    direcaoLocal.y = 1;
                    break;
                case (Direction.Baixo):
                    direcaoLocal.x = 1;
                    direcaoLocal.y = 0;
                    break;
                case (Direction.BaixoEsquerda):
                    direcaoLocal.x = 1;
                    direcaoLocal.y = -1;
                    break;
                case (Direction.Esquerda):
                    direcaoLocal.x = 0;
                    direcaoLocal.y = -1;
                    break;
                case (Direction.CimaEsquerda):
                    direcaoLocal.x = -1;
                    direcaoLocal.y = -1;
                    break;

                default:
                    direcaoLocal.x = 0;
                    direcaoLocal.y = 0;
                    MessageBox.Show("Alguma coisa deu errado no Switch de MatrizJogo.verificarDirecao");
                    break;
            }
            ///
            //

            //retornando LocalDirecaoPalavra
            return direcaoLocal;
        }
    }

    //classe auxiliar
    class MatrizEPalavras
    {
    }
    //classe auxiliar
    class CoordenadasPalavraEMatriz
    {
        public char[,] matriz;
        public int[,] coordenadaPalavra;
    }
    //classe auxiliar 
    class DirecaoECelulaInicialPalavra
    {
        public int[,] local;
        public Direction direcao;
        public int x;
        public int y;
    }
}
