using APS3_CacaPalavras.Model;
using APS3_CacaPalavras.View;
using System;
using System.Windows.Forms;

namespace APS3_CacaPalavras
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //criando tela de acesso
            FormAcesso frmAcesso = new FormAcesso();

            //validando dialogo do frmLogin
            DialogResult dialogResultLogin = frmAcesso.ShowDialog();
            
            //verificando dialogo frmLogin
            if(dialogResultLogin == DialogResult.OK)
            {   //verificando se foi criado obj usuário sessão
                if(UsuarioLogado.Logado == true && UsuarioLogado.User != null)
                {   //iniciando aplicação 
                    Application.Run(new FormPrincipal());
                }                
            }
        }
    }
}
