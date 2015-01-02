using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MRZCV
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string logs_path = Properties.Settings.Default.caminho_log;
            string logs_filename_prefix = "Pagina_de_Observações";
            bool debug_flag = true;
            bool resposta = true; 
            Log log = new Log(logs_path, logs_filename_prefix, debug_flag);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MRZCV.Webservices dese = new Webservices();
            dese.desencriptar();
            Form1 frm = new Form1();
            resposta = frm.validar_user_form1();
            if (resposta == true)
            {
                Application.Run(new Form1());
            }
            else
            {
             Log.log("AUTENTICAÇÃO REJEITADA", Log.PROCESS);
            }
         
            log.close();

        
        }

    }
}
