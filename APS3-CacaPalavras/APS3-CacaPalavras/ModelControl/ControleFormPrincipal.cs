using APS3_CacaPalavras.ModelConnection;
using System;
using System.Data;

namespace APS3_CacaPalavras.ModelControl
{
    static class ControleFormPrincipal
    {
        //atributos
        private static int dificuldade;
        //get set
        public static int Dificuldade
        {
            get { return dificuldade; }
            set { dificuldade = value; }
        }

        //métodos
        public static bool ValidarJogoNaoFinalizado(int idUsuario)
        {
            DBConn conn = new DBConn();

            conn.LimparParametros();
            conn.AdicionarParametros("@IDUsuario", idUsuario);
            
            bool result = Convert.ToBoolean(conn.ExecutarManipulacao(System.Data.CommandType.StoredProcedure, "uspJogoVerificarNaoFinalizado"));

            return result;
        }
    }
}
