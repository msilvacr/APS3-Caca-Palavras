using APS3_CacaPalavras.ModelConnection;
using APS3_CacaPalavras.ModelControl;
using System;
using System.Data;
using System.Windows.Forms;

namespace APS3_CacaPalavras.Model
{
    public class Jogo
    {
        //DEFININDO CONSTANTES DE QTD DE PALAVRAS E TAMANHO DE MATRIZ POR NIVEL DE DIFICULDADE { 0 = FACIL, 1 = MÉDIO, 2 = DIFICIL, 3 = INSANO }
        private static readonly int[] QTD_PALAVRAS_POR_NIVEL = new int[4] { 8, 10, 12, 14 };
        private static readonly int[] TAMANHO_MATRIZ_POR_NIVEL = new int[4] { 14, 16, 18, 25 };

        //atributos
        private int idJogo;
        private Usuario user;
        private char[,] matrizJogo;
        private int nivelDificuldade;
        private DateTime dtJogo;
        private Palavra[] palavras;
        private Boolean statusJogo;
        private TimeSpan duracaoJogo;

        //gets sets
        public int IdJogo { get { return idJogo; } set { idJogo = value; } }
        public Usuario User { get { return user; } set { user = value; } }
        public int NivelDificuldade { get { return nivelDificuldade; } set { nivelDificuldade = value; } }
        public char[,] MatrizJogo { get { return matrizJogo; } set { matrizJogo = value; } }
        public DateTime DtJogo { get { return dtJogo; } set { dtJogo = value; } }
        public Palavra[] Palavras { get { return palavras; } set { palavras = value; } }
        public Boolean StatusJogo { get { return statusJogo; } set { statusJogo = value; } }
        public TimeSpan DuracaoJogo { get { return duracaoJogo; } set { duracaoJogo = value; } }

        public static int QtdPalavrasPorDificuldade(int i){
            return QTD_PALAVRAS_POR_NIVEL[i];
        }
        public static int TamanhoMatrizPorDificuldade(int i){
            return TAMANHO_MATRIZ_POR_NIVEL[i];
        }
    }

    public static class JogoExecucao
    {
        public static Jogo jogo;
    }

    //INICIAR NOVO JOGO
    public class NovoJogo
    {
        //NOVO JOGO
        public static void gerarJogo()
        {
            //passando valor referente as const qtdPalavrasPorDificuldade, tamanhoMatrizPorDificuldade
            carregarPalavrasJogo(Jogo.QtdPalavrasPorDificuldade(JogoExecucao.jogo.NivelDificuldade), Jogo.TamanhoMatrizPorDificuldade(JogoExecucao.jogo.NivelDificuldade)); ;

            gerarMatrizJogo(JogoExecucao.jogo.NivelDificuldade);

            //ENQUANTO AS TENTATIVAS FOREM FALHAS -> REPITA:
            while(!MatrizJogo.Gerar(JogoExecucao.jogo.Palavras, JogoExecucao.jogo.MatrizJogo));

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
                Palavra palavra = new Palavra(dataTable.Rows[i].Field<Int32>(0), dataTable.Rows[i].Field<string>(1));
                palavras[i] = palavra;
            }


            //executando ordenador de palavras com crescente = false
            JogoExecucao.jogo.Palavras = ordenarPalavrasPorTamanho(palavras, false);
        }

        private static bool possuiPalavrasDuplicadas(Palavra[] palavras)
        {
            for(int i = 0; i < palavras.Length; i ++)
            {
                for(int j = 0; i < palavras.Length; j++)
                {
                    if(palavras[i].TextoPalavra == palavras[j].TextoPalavra)
                    {
                        string s = string.Format("TEMPOS UM PROBLEMA: POR ALGUM MOTIVO AS PALAVRAS ESTÃO DUPLICADAS: {0} == {1}", palavras[i].TextoPalavra, palavras[j].TextoPalavra);
                        MessageBox.Show(s);
                        return true;
                    }
                }
            }
            return false;
        }

        //ordenador de obj do tipo palavra a partir do tamanho do TEXTO DA PALAVRA
        private static Palavra[] ordenarPalavrasPorTamanho(Palavra[] palavras, bool crescente)
        {
            //ORDENANDO EM ORDEM DECRESCENTE 
            for (int i = 0; i < palavras.Length; i++)
            {
                for (int j = 0; j < palavras.Length; j++)
                {
                    //CASO CRESCENTE = TRUE
                    if (crescente)
                    {
                        if (palavras[i].TextoPalavra.Length < palavras[j].TextoPalavra.Length)
                        {
                            //usando variavel aux e ordenando palavras
                            Palavra aux = palavras[j];

                            palavras[j] = palavras[i];

                            palavras[i] = aux;
                        }
                    }
                    //CASO CRESCENTE != TRUE
                    else
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
            }
            return palavras;
        }

        private static void gerarMatrizJogo(int dificuldade)
        {
            JogoExecucao.jogo.MatrizJogo = new char[Jogo.TamanhoMatrizPorDificuldade(dificuldade), Jogo.TamanhoMatrizPorDificuldade(dificuldade)];
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
