using APS3_CacaPalavras.Properties;
using System.Data;
using System.Data.SqlClient;

namespace APS3_CacaPalavras.ModelConnection
{
    class DBConn
    {
        //criando conexao
        private SqlConnection CriarConexao()
        {
            return new SqlConnection(Settings.Default.stringConexao);
        }

        //Parâmetros que vão para o banco de dados
        private SqlParameterCollection sqlParameterCollection = new SqlCommand().Parameters;

        //Limpa parâmetros da minha coleção
        public void LimparParametros()
        {
            sqlParameterCollection.Clear();
        }

        //adicionando parâmetros
        public void AdicionarParametros(string nomeParametro, object valorParametro)
        {
            sqlParameterCollection.Add(new SqlParameter(nomeParametro, valorParametro));
        }

        //Executa inserts, updates e deletes
        public object ExecutarManipulacao(CommandType commandType, string nomeStoredProcedureOuTextoSql)
        {
            //criando conexão
            SqlConnection sqlConnection = CriarConexao();
            //abrindo conexão
            sqlConnection.Open();
            //criando comando que vai transportar a informação
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            //inserindo informações no comando command (commandType e commandText)
            sqlCommand.CommandType = commandType;
            sqlCommand.CommandText = nomeStoredProcedureOuTextoSql;
            sqlCommand.CommandTimeout = 120; //timeOut (em segundos)

            //adicionando os parâmetros no comando
            foreach(SqlParameter sqlParameter in sqlParameterCollection)
            {
                sqlCommand.Parameters.Add(sqlParameter);
            }




            return new object();
        }
    }
}
