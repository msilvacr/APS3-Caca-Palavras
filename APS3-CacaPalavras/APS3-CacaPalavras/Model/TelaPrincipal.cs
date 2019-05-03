using APS3_CacaPalavras.ModelConnection;
using System;
using System.Data;

namespace APS3_CacaPalavras.ModelControl
{
    public static class TelaPrincipal
    {
        //métodos
        public static bool ValidarJogoNaoFinalizado(int idUsuario)
        {
            DBConn conn = new DBConn();

            conn.LimparParametros();
            conn.AdicionarParametros("@IDUsuario", idUsuario);
            
            string result = conn.ExecutarManipulacao(System.Data.CommandType.StoredProcedure, "uspJogoConsultarJogoNaoFinalizado").ToString();

            if(result == "Não existe")
                return false;
            else
                return true;
        }
    }
}
