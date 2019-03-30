using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS3_CacaPalavras.Model
{
    static class Usuario
    {
        //atributos
        private static int idUsuario = 0;
        private static string email;
        private static string senha;
        private static Pessoa pessoa;

        //metodos
        public static void Login(int idUsuario, string email, string senha, Pessoa pessoa)
        {
            Usuario.idUsuario = idUsuario;
            Usuario.email = email;
            Usuario.senha = senha;
            Usuario.pessoa = pessoa;
        }

        public static void Logout()
        {
            Usuario.idUsuario = 0;
            Usuario.email = null;
            Usuario.senha = null;
            Usuario.pessoa = null;
        }
    }
}
