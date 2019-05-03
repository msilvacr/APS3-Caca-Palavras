using APS3_CacaPalavras.ModelConnection;
using APS3_CacaPalavras.ModelControl;
using System;
using System.Data;
using System.Windows.Forms;

namespace APS3_CacaPalavras.Model
{
    public class Jogo
    {
        //atributos
        private int idJogo;
        private Usuario user;
        private string[,] matrizJogo;
        private int nivelDificuldade;
        private DateTime dtJogo;
        private Palavra[] palavras;
        private Boolean statusJogo;
        private TimeSpan duracaoJogo;

        //gets sets
        public int IdJogo { get { return idJogo; } set { idJogo = value; } }
        public Usuario User { get { return user; } set { user = value; } }
        public int NivelDificuldade { get { return nivelDificuldade; } set { nivelDificuldade = value; } }
        public string[,] MatrizJogo { get { return matrizJogo; } set { matrizJogo = value; } }
        public DateTime DtJogo { get { return dtJogo; } set { dtJogo = value; } }
        public Palavra[] Palavras { get { return palavras; } set { palavras = value; } }
        public Boolean StatusJogo { get { return statusJogo; } set { statusJogo = value; } }
        public TimeSpan DuracaoJogo { get { return duracaoJogo; } set { duracaoJogo = value; } }


    }

    public static class JogoExecucao
    {
        public static Jogo jogo;
    }

    //INICIAR NOVO JOGO
    public class NovoJogo
    {
        //NOVO JOGO
        public static void novoJogo()
        {
            //aqui é definido a quantidade e o tamanho das palavras que estarão presentes no jogo
            carregarPalavrasJogo(definirQtdPalavras(), definirTamanhoMatriz());
        }

        //definindo a quantidade de palavras estarão presentes no jogo de acordo com o nível de dificuldade
        private static int definirQtdPalavras()
        {
            switch (JogoExecucao.jogo.NivelDificuldade)
            {
                case 3: //dificil
                    return 10;
                case 2: //médio
                    return 10;
                case 1: //facil
                    return 8;
                default://aconteceu algum erro
                    MessageBox.Show("Alguma coisa deu errado no dificuldade do jogo... valor inconsistente");
                    return 0;
            }
        }

        //criando obj matriz e definindo seu tamanho de acordo com o nível de dificuldade
        private static int definirTamanhoMatriz()
        {
            if (JogoExecucao.jogo.NivelDificuldade == 3)
            {
                JogoExecucao.jogo.MatrizJogo = new string[18, 18];
                return 18;
            }       //médio
            else if (JogoExecucao.jogo.NivelDificuldade == 2)
            {
                JogoExecucao.jogo.MatrizJogo = new string[14, 14];
                return 14;
            }       //fácil
            else
            {
                JogoExecucao.jogo.MatrizJogo = new string[10, 10];
                return 10;
            }
        }

        //Sorteia as palavras que estarão presentes no jogo
        private static void carregarPalavrasJogo(int quantidadePalavras, int tamanhoMax)
        {
            Palavra[] palavras = new Palavra[quantidadePalavras];

            DBConn dBConn = new DBConn();

            dBConn.LimparParametros();

            dBConn.AdicionarParametros("@Quantidade", quantidadePalavras);
            dBConn.AdicionarParametros("@TamanhoMax", tamanhoMax);

            DataTable dataTable = dBConn.ExecutarConsulta(System.Data.CommandType.StoredProcedure, "uspPalavraConsultarPalavrasJogo");

            for (int i = 0; i < quantidadePalavras; i++)
            {
                Palavra palavra = new Palavra();

                palavra.IdPalavra = dataTable.Rows[i].Field<Int32>(0);
                palavra.TextoPalavra = dataTable.Rows[i].Field<string>(1);

                palavras[i] = palavra;
            }
            JogoExecucao.jogo.Palavras = ordenarPalavrasPorTamanho(palavras);
        }

        //ordenador de obj do tipo palavra a partir do tamanho do TEXTO DA PALAVRA
        private static Palavra[] ordenarPalavrasPorTamanho(Palavra[] palavras)
        {
            for (int i = 0; i < palavras.Length; i++)
            {
                for (int j = 0; j < palavras.Length; j++)
                {
                    if (palavras[i].TextoPalavra.Length > palavras[j].TextoPalavra.Length)
                    {
                        //usando variavel aux e ordenando palavras
                        Palavra aux = palavras[j];

                        palavras[j] = palavras[i];

                        palavras[i] = aux;
                    }
                }
            }

            for (int x = 0; x < palavras.Length; x++)
            {
                MessageBox.Show(String.Format("{0}º = O tamanho da palavra é: {1}", x, palavras[x].TextoPalavra.Length));
            }

            return palavras;
        }

        private static void gerarMatriz()
        {

        }
    }

    //CONTINUAR UM JOGO JÁ INICIADO
    public class ContinuarJogo
    {

    }

    //EXCLUIR JOGO 
    public class ExcluirJogo
    {

    }
}
