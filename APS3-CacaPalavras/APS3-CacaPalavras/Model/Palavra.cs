using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS3_CacaPalavras.Model
{

    public class Palavra
    {
        private static Random rdn = new Random();
        //private static readonly int MAX_LENGTH = 22;
        //private static readonly int MIN_LENGTH = 3;

        //enum de direções
        public enum Direction { Baixo, Direita, Cima, Esquerda, BaixoDireita, CimaDireita, BaixoEsquerda, CimaEsquerda };       
        
        //atributos
        private int idPalavraJogo; //id único da palavra no jogo
        private int idJogo; //jogo que a palavra pertence
        private int idPalavra; //palavra a que se refere
        private string textoPalavra;
        private int[,] celulaInicial = new int[1, 2];
        Direction direcaoPalavra;
        private int[,] posicaoPalavra; //posição da palavra na matriz 
        private string corPalavra;
        private bool statusPalavra;

        //construct
        public Palavra() { }

        public Palavra(int idPalavra, string textoPalavra)
        {
            this.IdPalavra = idPalavra;
            this.TextoPalavra = textoPalavra;
            this.CorPalavra = Palavra.sortearCorRGB(rdn);
        }

        public Palavra(int idPalavraJogo, int idJogo, int idPalavra, string textoPalavra, int[,] posicaoPalavra, string corPalavra, bool statusPalavra)
        {
            this.IdPalavraJogo = idPalavraJogo;
            this.idJogo = idJogo;
            this.IdPalavra = idPalavra;
            this.textoPalavra = textoPalavra;
            this.posicaoPalavra = posicaoPalavra;
            this.corPalavra = corPalavra;
            this.statusPalavra = statusPalavra;
        }


        //get sets
        public int IdPalavraJogo { get { return idPalavraJogo; } set { idPalavraJogo = value; } }
        public int IdPalavra { get { return idPalavra; } set { idPalavra = value; } }
        public int IdJogo { get { return idJogo; } set { idJogo = value; } }
        public string TextoPalavra { get { return textoPalavra; } set { textoPalavra = value; } }
        public int[,] CelulaInicial { get { return celulaInicial; } set { celulaInicial = value; } }
        public Direction DirecaoPalavra { get { return direcaoPalavra; } set { direcaoPalavra = value; } }
        public int[,] PosicaoPalavra { get { return posicaoPalavra; } set { posicaoPalavra = value; } }
        public string CorPalavra{ get { return corPalavra; } set { corPalavra = value; } }
        public bool StatusPalavra { get { return statusPalavra; } set { statusPalavra = value; } }


        private static string sortearCorRGB(Random rdn)
        {

            int[] aux = new int[3] { rdn.Next(0, 230), rdn.Next(20, 240), rdn.Next(35, 255) };


            List<int> listNumbers = new List<int>();

            int number;
            for (int i = 0; i < 3; i++)
            {
                do
                {
                    number = rdn.Next(0, 3);
                } while (listNumbers.Contains(number));
                listNumbers.Add(number);
            }


            int r = aux[listNumbers[0]];
            int g = aux[listNumbers[1]];
            int b = aux[listNumbers[2]];

            return String.Format("{0},{1},{2}", r, g, b);
        }
    }
}
