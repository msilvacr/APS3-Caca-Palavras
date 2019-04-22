namespace APS3_CacaPalavras.Model
{
    static class UsuarioLogado
    {
        private static bool logado = false;
        private static Usuario user = null;

        //get set
        public static bool Logado
        {
            get { return logado; }
            set { logado = value; }
        }

        public static Usuario User
        {
            get { return user; }
            set { user = value; }
        }

        //metodos
        public static void Login(Usuario usuario)
        {
            UsuarioLogado.logado = true;
            UsuarioLogado.user = usuario;
        }

        public static void Logout()
        {
            UsuarioLogado.logado = false;
            UsuarioLogado.user = null;
        }
    }
}
