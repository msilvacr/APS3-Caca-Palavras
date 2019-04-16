using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APS3_CacaPalavras.Model;
using APS3_CacaPalavras.ModelConnection;

namespace APS3_CacaPalavras.Controller
{
    static class ModelFrmLogin
    {
        public static bool EfetuarLogin(string email, string senha)
        {
            return true;
        }
        public static void EfetuarLogOut()
        {
            UsuarioLogado.Logout();
        }
    }
}
