﻿using APS3_CacaPalavras.ModelConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APS3_CacaPalavras.Model
{
    static class UsuarioControle
    {
        public static string AutenticarUsuario(string email, string senha)
        {
            //criando obj conexão
            DBConn dBConn = new DBConn();
            
            try
            {
                dBConn.LimparParametros();

                dBConn.AdicionarParametros("@Email", email);
                dBConn.AdicionarParametros("@Senha", senha);

                string idUsuario = dBConn.ExecutarManipulacao(CommandType.StoredProcedure, "uspUsuarioAutenticar").ToString();

                return idUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void LogarUsuario(string email, string senha)
        {
            try
            {
                //criando obj conexão
                DBConn dBConn = new DBConn();

                //limpando parâmetros
                dBConn.LimparParametros();
                //inserindo novos valores aos novos parâmetros
                dBConn.AdicionarParametros("@Email", email);
                dBConn.AdicionarParametros("@Senha", senha);

                //consultando informações de usuário
                DataTable dataTable = dBConn.ExecutarConsulta(CommandType.StoredProcedure, "uspUsuarioConsultar");

                //tratando informações do usuário
                string auxNome = Convert.ToString(dataTable.Rows[0]["Nome"]);
                DateTime auxDTNascimento = Convert.ToDateTime(dataTable.Rows[0]["DTNascimento"]);
                string auxTelefone = Convert.ToString(dataTable.Rows[0]["Telefone"]);
                int auxIDDUsuario = Convert.ToInt32(dataTable.Rows[0]["IDUsuario"]);
                string auxEmail = Convert.ToString(dataTable.Rows[0]["Email"]);

                //criando usuário tipo
                Usuario user = new Usuario(auxNome, auxDTNascimento, auxTelefone, auxIDDUsuario, auxEmail);

                //inserindo informações do usuário na classe estática 
                UsuarioLogado.Login(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        

        public static void DeslogarUsuario()
        {
            UsuarioLogado.Logout();        
        }

        public static string CadastrarUsuario(Usuario user)
        {
            //criando obj conexão
            DBConn dBConn = new DBConn();

            try
            {
                dBConn.LimparParametros();

                dBConn.AdicionarParametros("@Email", user.Email);
                dBConn.AdicionarParametros("@Senha", user.Senha);
                dBConn.AdicionarParametros("@Nome", user.Nome);
                dBConn.AdicionarParametros("@DTNascimento", user.DtNascimento);
                dBConn.AdicionarParametros("@Telefone", user.Telefone);

                string idUsuario = dBConn.ExecutarManipulacao(CommandType.StoredProcedure, "uspUsuarioInserir").ToString();

                return idUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string ExcluirCadastroUsuario()
        {
            return "a";
        }

        public static void AlterarUsuario()
        {

        }
    }
}