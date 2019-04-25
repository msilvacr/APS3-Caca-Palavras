using System;

namespace APS3_CacaPalavras.Model
{
    class Jogo
    {
        //atributos
        int idJogo;
        Usuario user;
        int nivelDificuldade;
        DateTime dtJogo;
        Palavra[] palavras;
        Boolean statusJogo;
        TimeSpan duracaoJogo;

        //gets sets
        public int IdJogo{ get { return idJogo; } set { idJogo = value; } }
        public Usuario User { get { return user; } set { user = value; } }
        public int NivelDificuldade { get { return nivelDificuldade; } set { nivelDificuldade = value; } }
        public DateTime DtJogo { get { return dtJogo; } set { dtJogo = value; } }
        public Palavra[] Palavras { get { return palavras; } set { palavras = value; } }
        public Boolean StatusJogo { get { return statusJogo; } set { statusJogo = value; } }
        public TimeSpan DuracaoJogo { get { return duracaoJogo; } set { duracaoJogo = value; } }
    }
}
