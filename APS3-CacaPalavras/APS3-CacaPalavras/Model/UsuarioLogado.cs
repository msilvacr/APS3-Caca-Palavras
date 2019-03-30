using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS3_CacaPalavras.Model
{
    static class UsuarioLogado
    {
        private static bool logado = false;
        private static Usuario usuario;

        //metodos
        public static void Login(Usuario usuario)
        {
            UsuarioLogado.logado = true;
            UsuarioLogado.usuario = usuario;
        }

        public static void Logout()
        {
            UsuarioLogado.logado = false;
            UsuarioLogado.usuario = null;
        }
    }
}
