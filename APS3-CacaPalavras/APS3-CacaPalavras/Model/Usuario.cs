using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS3_CacaPalavras.Model
{
    class Usuario: Pessoa
    {
        //atributos
        private int idUsuario = 0;
        private string email;
        private string senha;
        
        //construtor
        public Usuario(string nome, DateTime dtNascimento, string[] telefone, int idUsuario, string email, string senha): base(nome, dtNascimento, telefone)
        {
            this.idUsuario = idUsuario;
            this.email = email;
            this.senha = senha;
        }
        public Usuario() { }

        //gets and sets
        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
    }
}
