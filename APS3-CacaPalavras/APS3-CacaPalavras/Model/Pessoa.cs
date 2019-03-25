using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS3_CacaPalavras.Model
{
    class Pessoa
    {
        //atriubutos
        private string nome;
        private DateTime dtNascimento;
        private string[] telefone;

        //construtor
        public Pessoa(string nome, DateTime dtNascimento, string[] telefone)
        {
            this.nome = nome;
            this.dtNascimento = dtNascimento;
            this.telefone = telefone;
        }

        //gets e sets
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public DateTime DtNascimento
        {
            get { return dtNascimento; }
            set { dtNascimento = value; }
        }
        public string[] Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
    }
}
