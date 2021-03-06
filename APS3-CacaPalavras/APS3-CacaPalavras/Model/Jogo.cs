﻿using APS3_CacaPalavras.ModelConnection;
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
        private static readonly int[] TAMANHO_MATRIZ_POR_NIVEL = new int[4] { 10, 14, 18, 24 };

        //atributos
        private int idJogo;
        private int idMatriz;
        private Usuario user;
        private char[,] matrizJogo;
        private int nivelDificuldade;
        private DateTime dtJogo;
        private Palavra[] palavras;
        private Boolean statusJogo;
        private TimeSpan duracaoJogo;

        //gets sets
        public int IdJogo { get { return idJogo; } set { idJogo = value; } }
        public int IdMatriz { get { return idMatriz; } set { idMatriz = value; } }
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
            //Inserindo data do jogo
            JogoExecucao.jogo.DtJogo = DateTime.Now;
            //Inserindo status do jogo
            JogoExecucao.jogo.StatusJogo = false;
            //Inserindo duração inicial 
            JogoExecucao.jogo.DuracaoJogo = new TimeSpan(0);

            //passando valor referente as const qtdPalavrasPorDificuldade, tamanhoMatrizPorDificuldade
            carregarPalavrasJogo(Jogo.QtdPalavrasPorDificuldade(JogoExecucao.jogo.NivelDificuldade), Jogo.TamanhoMatrizPorDificuldade(JogoExecucao.jogo.NivelDificuldade)); ;

            gerarMatrizJogo(JogoExecucao.jogo.NivelDificuldade);

            //ENQUANTO AS TENTATIVAS FOREM FALHAS -> REPITA:
            while(!MatrizJogo.Gerar(JogoExecucao.jogo.Palavras, JogoExecucao.jogo.MatrizJogo));

            if (InserirJogoDB(JogoExecucao.jogo))
            {
                if(InserirMatrizDB(JogoExecucao.jogo))
                {
                    if (InserirPalavraJogo(JogoExecucao.jogo))
                    {
                        if (InserirCelulaMatriz(JogoExecucao.jogo))
                        {
                            if(inserirCelulaPalavra(JogoExecucao.jogo))
                            {
                                if (inserirCelulaInicialPalavra(JogoExecucao.jogo))
                                {
                                    MessageBox.Show("O jogo foi criado e salvo com sucesso!", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Falha ao criar jogo...");
                JogoExecucao.jogo = null;
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

        //INSERIR JOGO BD
        private static bool InserirJogoDB(Jogo jogo)
        {
            //criando novo obj de conexão com DB
            DBConn dbconn = new DBConn();

            dbconn.LimparParametros();

            dbconn.AdicionarParametros("@IDUsuario", JogoExecucao.jogo.User.IdUsuario);
            dbconn.AdicionarParametros("@NivelDificuldade", JogoExecucao.jogo.NivelDificuldade);
            dbconn.AdicionarParametros("@DTJogo", JogoExecucao.jogo.DtJogo);
            dbconn.AdicionarParametros("@StatusJogo", Convert.ToInt16(JogoExecucao.jogo.StatusJogo));

            TimeSpan dJogo = JogoExecucao.jogo.DuracaoJogo;
            string duracao = string.Format("{0}:{1}:{2}", dJogo.Hours, dJogo.Minutes, dJogo.Seconds);

            dbconn.AdicionarParametros("@Duracao", duracao);

            string idJogo = dbconn.ExecutarManipulacao(CommandType.StoredProcedure, "uspJogoInserir").ToString();

            if (idJogo == "O usuário possui um jogo não finalizado")
            {
                MessageBox.Show("Deu erro aqui, ainda tem jogo aberto pra esse usuároi");
                return false;
            }
            else
            {
                JogoExecucao.jogo.IdJogo = Convert.ToInt32(idJogo);
                return true;
            }
        }

        //INSERIR MATRIZ DO JOGO DB
        private static bool InserirMatrizDB(Jogo jogo)
        {
            //criando novo obj de conexão com DB
            DBConn dbconn = new DBConn();

            dbconn.LimparParametros();

            dbconn.AdicionarParametros("@IDJogo", JogoExecucao.jogo.IdJogo);
            dbconn.AdicionarParametros("@TamanhoX", JogoExecucao.jogo.MatrizJogo.GetLength(0));
            dbconn.AdicionarParametros("@TamanhoY", JogoExecucao.jogo.MatrizJogo.GetLength(1));

            string idMatriz = dbconn.ExecutarManipulacao(CommandType.StoredProcedure, "uspMatrizJogoInserir").ToString();

            if (idMatriz  == "O jogo em questão já possui matriz")
            {
                MessageBox.Show("O jogo já possui mamtriz no DB");
                return false;
            }
            else
            {
                JogoExecucao.jogo.IdMatriz = Convert.ToInt32(idMatriz);
                return true;
            }
        }

        private static bool InserirPalavraJogo(Jogo jogo)
        {
            DBConn dBConn = new DBConn();
            for (int i = 0; i < jogo.Palavras.Length; i++)
            {
                dBConn.LimparParametros();

                dBConn.AdicionarParametros("@IDJogo", jogo.IdJogo);
                dBConn.AdicionarParametros("@IDPalavra", jogo.Palavras[i].IdPalavra);
                dBConn.AdicionarParametros("@StatusPalavra", Convert.ToInt16(jogo.Palavras[i].StatusPalavra));
                dBConn.AdicionarParametros("@Cor", jogo.Palavras[i].CorPalavra);

                try
                {
                    string result = dBConn.ExecutarManipulacao(CommandType.StoredProcedure, "uspPalavraJogoInserir").ToString();
                    if (result == "Este jogo já contém esta palavra")
                    {
                        MessageBox.Show(result);
                        MessageBox.Show("Deu ruim aqui");
                    }
                    else
                    {
                        jogo.Palavras[i].IdPalavraJogo = Convert.ToInt32(result);
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            return true;
        }

        private static bool InserirCelulaMatriz(Jogo jogo)
        {
            DBConn dBConn = new DBConn();

            for(int x = 0; x < jogo.MatrizJogo.GetLength(0); x ++)
            {
                for (int y = 0; y < jogo.MatrizJogo.GetLength(1); y++)
                {
                    dBConn.LimparParametros();

                    dBConn.AdicionarParametros("@IDMatriz", jogo.IdMatriz);
                    dBConn.AdicionarParametros("@PosicaoX", x);
                    dBConn.AdicionarParametros("@PosicaoY", y);
                    dBConn.AdicionarParametros("@Caracter", jogo.MatrizJogo[x,y]);

                    string result = dBConn.ExecutarManipulacao(CommandType.StoredProcedure, "uspCelulaMatrizInserir").ToString();

                    if (result == "Esta matriz já contem valor para a celula")
                    {
                        MessageBox.Show("Deu algum problema aqui na inserção da celula no DB");
                        return false;
                    }                  
                }
            }
            return true;
        }

        private static bool inserirCelulaPalavra(Jogo jogo)
        {
            DBConn dBConn = new DBConn();
            for(int i = 0; i < jogo.Palavras.Length; i ++)
            {
                for (int j = 0; j < jogo.Palavras[i].PosicaoPalavra.GetLength(0); j++)
                {
                    dBConn.LimparParametros();

                    dBConn.AdicionarParametros("@IDPalavraJogo", jogo.Palavras[i].IdPalavraJogo);
                    dBConn.AdicionarParametros("@IDMatriz", jogo.IdMatriz);
                    dBConn.AdicionarParametros("@PosicaoX", jogo.Palavras[i].PosicaoPalavra[j, 0]);
                    dBConn.AdicionarParametros("@PosicaoY", jogo.Palavras[i].PosicaoPalavra[j, 1]);

                    string result = dBConn.ExecutarManipulacao(CommandType.StoredProcedure, "uspCelulaPalavrInserir").ToString();
                    
                    if (result == "Não existe celula com as posições informadas")
                    {
                        MessageBox.Show("deu ruim alguma coisa aqui na inserção das posições da palavra");
                    }
                }
            }
            return true;
        }

        private static bool inserirCelulaInicialPalavra(Jogo jogo)
        {
            DBConn dBConn = new DBConn();
            for(int i = 0; i < jogo.Palavras.Length; i++)
            {
                dBConn.LimparParametros();

                dBConn.AdicionarParametros("@IDPalavraJogo", jogo.Palavras[i].IdPalavraJogo);
                dBConn.AdicionarParametros("@IDMatriz", jogo.IdMatriz);
                dBConn.AdicionarParametros("@PosicaoX", jogo.Palavras[i].CelulaInicial[0, 0]);
                dBConn.AdicionarParametros("@PosicaoY", jogo.Palavras[i].PosicaoPalavra[0, 1]);

                string result = dBConn.ExecutarManipulacao(CommandType.StoredProcedure, "uspCelulaPalavrInserirCelulaInicial").ToString();

                if (result == "Não existe celula com as posições informadas")
                {
                    MessageBox.Show("deu ruim alguma coisa aqui na inserção das posições da palavra");
                }
            }
            return true;
        }


    }

    //CONTINUAR UM JOGO JÁ INICIADO
    public class ContinuarJogo
    {
        public static void CarregarJogo()
        {

            consultarJogoEMatrizDB();
            consultarPalavrasJogo();
            consultarCelulasMatriz();
            consultarCelulasPalavra();

        }

        private static void consultarJogoEMatrizDB()
        {
            DBConn dBConn = new DBConn();

            dBConn.LimparParametros();

            dBConn.AdicionarParametros("IDUsuario", JogoExecucao.jogo.User.IdUsuario);

            DataTable consulta = dBConn.ExecutarConsulta(CommandType.StoredProcedure, "cspConsultarJogoNaoFinalizado");

            JogoExecucao.jogo.IdJogo = Convert.ToInt32(consulta.Rows[0]["IDJogo"]);

            JogoExecucao.jogo.IdMatriz = Convert.ToInt32(consulta.Rows[0]["IDJogo"]);

            JogoExecucao.jogo.NivelDificuldade = Convert.ToInt32(consulta.Rows[0]["NivelDificuldade"]);

            JogoExecucao.jogo.DtJogo = Convert.ToDateTime(consulta.Rows[0]["DTJogo"]);

            JogoExecucao.jogo.StatusJogo = Convert.ToBoolean(consulta.Rows[0]["StatusJogo"]);


            JogoExecucao.jogo.DuracaoJogo = (TimeSpan)consulta.Rows[0]["Duracao"];

            int auxTamanhoX = Convert.ToInt32(consulta.Rows[0]["TamanhoX"]);
            int auxTamanhoY = Convert.ToInt32(consulta.Rows[0]["TamanhoY"]);

            JogoExecucao.jogo.MatrizJogo = new char[auxTamanhoX, auxTamanhoY];

        }

        private static void consultarPalavrasJogo()
        {
            DBConn dBConn = new DBConn();

            dBConn.LimparParametros();

            dBConn.AdicionarParametros("IDJogo", JogoExecucao.jogo.IdJogo);

            DataTable consulta = dBConn.ExecutarConsulta(CommandType.StoredProcedure, "cspPalavraJogoConsultar");

            Palavra[] palavras = new Palavra[consulta.Rows.Count];

            int i = 0; //contador

            foreach (DataRow row in consulta.Rows)
            {
                Palavra palavra = new Palavra();

                palavra.IdPalavraJogo = Convert.ToInt32(row["IDPalavraJogo"]);
                palavra.IdJogo = Convert.ToInt32(row["IDJogo"]);
                palavra.IdPalavra = Convert.ToInt32(row["IDPalavra"]);
                palavra.StatusPalavra = Convert.ToBoolean(row["StatusPalavra"]);
                palavra.CorPalavra = row["Cor"].ToString();

                dBConn.LimparParametros();

                dBConn.AdicionarParametros("IDPalavra", palavra.IdPalavra);

                DataTable resultado = dBConn.ExecutarConsulta(CommandType.StoredProcedure, "cspPalavraConsultar");

                palavra.TextoPalavra = resultado.Rows[0]["Palavra"].ToString();

                palavras[i++] = palavra;
            }
            JogoExecucao.jogo.Palavras = palavras;
        }

        private static void consultarCelulasMatriz()
        {
            DBConn dBConn = new DBConn();

            dBConn.LimparParametros();

            dBConn.AdicionarParametros("IDMatriz", JogoExecucao.jogo.IdMatriz);

            DataTable consulta = dBConn.ExecutarConsulta(CommandType.StoredProcedure, "cspCelulaMatrizConsultar");


            char[,] auxMatriz = new char[JogoExecucao.jogo.MatrizJogo.GetLength(0), JogoExecucao.jogo.MatrizJogo.GetLength(1)];

            foreach (DataRow row in consulta.Rows)
            {
                int auxX = Convert.ToInt32(row["PosicaoX"]);
                int auxY = Convert.ToInt32(row["PosicaoY"]);

                auxMatriz[auxX, auxY] = Convert.ToChar(row["Caracter"]);

            }

            JogoExecucao.jogo.MatrizJogo = auxMatriz;

        }

        private static void consultarCelulasPalavra()
        {
            DBConn dBConn = new DBConn();

            foreach (Palavra p in JogoExecucao.jogo.Palavras)
            {
                dBConn.LimparParametros();

                dBConn.AdicionarParametros("@IDPalavraJogo", p.IdPalavraJogo);

                DataTable consulta = dBConn.ExecutarConsulta(CommandType.StoredProcedure, "cspCelulaPalavraConsultar");

                int[,] posicao = new int[consulta.Rows.Count, 2];

                int i = 0;

                foreach (DataRow row in consulta.Rows)
                {
                    int auxX = Convert.ToInt32(row["PosicaoX"]);
                    int auxY = Convert.ToInt32(row["PosicaoY"]);

                    posicao[i, 0] = auxX;
                    posicao[i, 1] = auxY;

                   Boolean deu = (Boolean)row["CelulaInicial"];
                    if (deu)
                    {
                        p.CelulaInicial[0, 0] = auxX;
                        p.CelulaInicial[0, 1] = auxY;
                    }
                    i++; 
                }
                p.PosicaoPalavra = posicao;
            }

            Palavra[] aqui = JogoExecucao.jogo.Palavras;
        }


    }
}




