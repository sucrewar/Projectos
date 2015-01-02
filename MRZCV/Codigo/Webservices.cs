using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MRZCV
{
    class Webservices
    {
        public static Array lista_dados;
        public static string user = Properties.Settings.Default.user;
        public static string password = Properties.Settings.Default.pw;
        public static string pass = ""; 
        public void desencriptar ()
        {
            MRZCV.Encriptar desencript = new Encriptar();
            pass = desencript.Decrypt(password);
            Console.WriteLine("password::" + pass);
            
        }
        internal static BasicHttpBinding CreateWebServiceInstance()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.SendTimeout = TimeSpan.FromMinutes(1);
            binding.OpenTimeout = TimeSpan.FromMinutes(1);
            binding.CloseTimeout = TimeSpan.FromMinutes(1);
            binding.ReceiveTimeout = TimeSpan.FromMinutes(10);
            binding.AllowCookies = false;
            binding.BypassProxyOnLocal = false;
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            binding.MessageEncoding = WSMessageEncoding.Text;
            binding.TextEncoding = System.Text.Encoding.UTF8;
            binding.TransferMode = TransferMode.Buffered;
            binding.UseDefaultWebProxy = true;
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            binding.ReaderQuotas.MaxStringContentLength = Int32.MaxValue;
            binding.MaxReceivedMessageSize = Int32.MaxValue;
            return binding;
        }

        public static void validar_user(string id_user, out string descricao, out string destino,out string[] lista, out string lote, out string status, out string tipo, out string total)
        {
            descricao = "";
            destino = "";
            lista = null;
            lote = "";
            status = "";
            tipo = "";
            total = "";
            try
            {



                Uri uri = new Uri(Properties.Settings.Default.caminho_validauser);
                var address = new EndpointAddress(uri, EndpointIdentity.CreateSpnIdentity("CaboVerde"));
                MRZCV.validar_user.ZWS_PEP_VALIDA_UTILIZADORClient wsclient = new validar_user.ZWS_PEP_VALIDA_UTILIZADORClient(CreateWebServiceInstance(), address);
                MRZCV.validar_user.ZF_PEP_VALIDA_UTILIZADORRequest req = new validar_user.ZF_PEP_VALIDA_UTILIZADORRequest();
                MRZCV.validar_user.ZF_PEP_VALIDA_UTILIZADOR request = new validar_user.ZF_PEP_VALIDA_UTILIZADOR();
                request.USER = id_user;
                req.ZF_PEP_VALIDA_UTILIZADOR = request;
                wsclient.ClientCredentials.UserName.UserName = user;
                wsclient.ClientCredentials.UserName.Password = pass;

                MRZCV.validar_user.ZF_PEP_VALIDA_UTILIZADORResponse res = wsclient.ZF_PEP_VALIDA_UTILIZADOR(request);
                descricao = res.DESCRICAO;
                destino = res.DESTINO;
                //receber lista em falta
                lista = res.LISTA;
                lote = res.LOTE;
                status = res.STATUS;
                tipo = res.TIPO;
                total = res.TOTAL;
                Console.WriteLine("descriçao:" + descricao);
                Console.WriteLine("destino:" + destino);
                Console.WriteLine("lote" + lote);
                Console.WriteLine("status:" + status);
                Console.WriteLine("tipo:" + tipo);
                Console.WriteLine("total:" + total);
                lista_dados = lista;

            }
           catch (Exception d)
            {
                Console.WriteLine(d.Message);
                Console.WriteLine(d.StackTrace);
                Log.log("CONTROLO QUALIDADE|VALIDAR USER::" + d.StackTrace.ToString(), Log.DEBUG);
                Log.log("CONTROLO QUALIDADE|VALIDAR USER::" + d.Message.ToString(), Log.DEBUG);
            }
            
        }
       
        public static void dados_personalizar(string id_user, string mrz1, string mrz2, string tipo, out string altura, out string ano_nascimento, out string apelido, out string assinatura, out string data_emissao, out string data_exp, out string descricao, out string dia_nascimento, out string entidadeemite, out string estado, out string foto, out string foto_chip, out string local_nascimento, out string mes_nascimento, out string mrz1_out, out string mrz2_out, out string nacionalidade, out string nacionalidade_abv, out string nome_proprio, out string n_id, out string[] observacoes, out string sexo, out string tipo_out, out string tipo_doc, out string versao_doc, out byte tipo_linha)
        {

            altura = "";
            ano_nascimento = "";
            apelido = "";
            assinatura = "";
            data_emissao = "";
            data_exp = "";
            descricao = "";
            entidadeemite = "";
            dia_nascimento = "";
            estado = "";
            foto = "";
            foto_chip = "";
            local_nascimento = "";
            mes_nascimento = "";
            mrz1_out = "";
            mrz2_out = "";
            nacionalidade = "";
            nacionalidade_abv = "";
            nome_proprio = "";
            n_id = "";
            observacoes = null;
            sexo = "";
            tipo_out = "";
            tipo_doc = "";
            versao_doc = "";
            tipo_linha = 0;
          //  List<string> lista_obs = new List<string>();
            try
            {



                Uri uri = new Uri(Properties.Settings.Default.caminho_dados_perso);
                var address = new EndpointAddress(uri, EndpointIdentity.CreateSpnIdentity("CaboVerde"));
                MRZCV.dados_perso.ZWS_PEP_ENVIO_DADOS_PERSONALIZClient wsclient = new dados_perso.ZWS_PEP_ENVIO_DADOS_PERSONALIZClient(CreateWebServiceInstance(), address);
                MRZCV.dados_perso.ZF_PEP_ENVIO_DADOS_PERSONALIZRequest req = new dados_perso.ZF_PEP_ENVIO_DADOS_PERSONALIZRequest();
                MRZCV.dados_perso.ZF_PEP_ENVIO_DADOS_PERSONALIZ request = new dados_perso.ZF_PEP_ENVIO_DADOS_PERSONALIZ();
                request.USER = id_user;
                request.MRZ1_IN = mrz1;
                request.MRZ2_IN = mrz2;
                request.TIPO_IN = tipo;
                req.ZF_PEP_ENVIO_DADOS_PERSONALIZ = request;
                wsclient.ClientCredentials.UserName.UserName = user;
                wsclient.ClientCredentials.UserName.Password = pass;
                

                MRZCV.dados_perso.ZF_PEP_ENVIO_DADOS_PERSONALIZResponse res = wsclient.ZF_PEP_ENVIO_DADOS_PERSONALIZ(request);
                altura = res.ALTURA;
                ano_nascimento = res.ANONASCIMENTO;
                apelido = res.APELIDO;
                assinatura = res.ASSINATURA;
                data_emissao = res.DATAEMISSAO;
                data_exp = res.DATAVALIDADE;
                descricao = res.DESCRICAO;
                dia_nascimento = res.DIANASCIMENTO;
                entidadeemite = res.EMISSORAUTORIDADE;
                estado = res.ESTADO;
                foto = res.FOTOGRAFIA;
                foto_chip = res.FOTOGRAFIACHIP;
                local_nascimento = res.LOCALNASCIMENTO;
                mes_nascimento = res.MESNASCIMENTO;
                mrz1_out = res.MRZ1_OUT;
                mrz2_out = res.MRZ2_OUT;
                nacionalidade = res.NACIONALIDADE;
                nacionalidade_abv = res.NACIONALIDADEABV;
                nome_proprio = res.NOMEPROPRIO;
                n_id = res.NUMEROIDENTIFICACAO;
                observacoes = res.OBSERVACOES;
                sexo = res.SEXO;
                tipo_out = res.TIPO_OUT;
                tipo_doc = res.TIPODOCUMENTO;
                versao_doc = res.VERSAODOCUMENTO;
                tipo_linha = res.T_LINHA;
               
               

                Console.WriteLine("altura:" + altura);
                Console.WriteLine("ano nascimento :" + ano_nascimento);
               // Console.WriteLine("assinatura" + assinatura);
                Console.WriteLine("data emissao:" + data_emissao);
                Console.WriteLine("data expiração:" + data_exp);
                Console.WriteLine("descriçao:" + descricao);
                Console.WriteLine("dia_nascimento:" + dia_nascimento);
                Console.WriteLine("entidade emissora" + entidadeemite);
                Console.WriteLine("status:" + estado);
               // Console.WriteLine("foto:" +foto);
              //  Console.WriteLine("foto_chip:" + foto_chip);
                Console.WriteLine("local nascimento:" + local_nascimento);
                Console.WriteLine("mes nascimento:" + mes_nascimento);
                Console.WriteLine("mrz1" + mrz1_out);
                Console.WriteLine("mrz2:" + mrz2_out);
                Console.WriteLine("nacionalidade:" + nacionalidade);
                Console.WriteLine("nacionalidade abreviada:" + nacionalidade_abv);
                Console.WriteLine("nome proprio:" + nome_proprio);
                Console.WriteLine("numero de identificacao:" + n_id);
                int tamanho = observacoes.Length;
                for (int i = 0; i < tamanho; i++ )
                {
                    Console.WriteLine("observações" + observacoes[i]);
                }
                Console.WriteLine("sexo:" + sexo);
                Console.WriteLine("tipo:" + tipo_out);
                Console.WriteLine("tipo documento:" +tipo_doc);
                Console.WriteLine("Versao documento:" +versao_doc);
                Console.WriteLine("Tipo Linha Observações :" + tipo_linha);


            }
            catch (Exception d)
            {
                Console.WriteLine(d.Message);
                Console.WriteLine(d.StackTrace);
                Log.log("CONTROLO QUALIDADE|DADOS PERSONALIZAÇÃO::" + d.StackTrace.ToString(), Log.DEBUG);
                Log.log("CONTROLO QUALIDADE|DADOS PERSONALIZAÇÃO::" + d.Message.ToString(), Log.DEBUG);
            }


        }

        public static void status_cont_qualidade(string user_id, string mrz1, string mrz2,string descricao, string status_in, string tipo_in, string ver_chip, out string descricao_out, out string destino, out string lote, out string quantidade, out string status_out, out Array lista)
        {
            //em falta receber lista 
            descricao_out = "";
            destino = "";
            lote = "";
            quantidade = "";
            status_out = "";
            lista = null;
            try
            {



                Uri uri = new Uri(Properties.Settings.Default.caminho_qualidade);
                var address = new EndpointAddress(uri, EndpointIdentity.CreateSpnIdentity("CaboVerde"));
                MRZCV.Status_qualidade.ZWS_PEP_ENVIO_STATUS_CONT_QUALClient wsclient = new Status_qualidade.ZWS_PEP_ENVIO_STATUS_CONT_QUALClient(CreateWebServiceInstance(), address);
                MRZCV.Status_qualidade.ZF_PEP_ENVIO_STATUS_CONT_QUALRequest req = new Status_qualidade.ZF_PEP_ENVIO_STATUS_CONT_QUALRequest();
                MRZCV.Status_qualidade.ZF_PEP_ENVIO_STATUS_CONT_QUAL request = new Status_qualidade.ZF_PEP_ENVIO_STATUS_CONT_QUAL();
                request.USER = user_id;
                request.MRZ1 = mrz1;
                request.MRZ2 = mrz2;
                request.STATUS_IN = status_in;
                request.TIPO = tipo_in;
                request.VERIFICACAOCHIP = ver_chip;
                request.DESCRICAO_IN = descricao;
                request.HOST = System.Environment.MachineName;
                req.ZF_PEP_ENVIO_STATUS_CONT_QUAL = request;
                wsclient.ClientCredentials.UserName.UserName = user;
                wsclient.ClientCredentials.UserName.Password = pass;

                MRZCV.Status_qualidade.ZF_PEP_ENVIO_STATUS_CONT_QUALResponse res = wsclient.ZF_PEP_ENVIO_STATUS_CONT_QUAL(request);
                descricao_out = res.DESCRICAO_OUT;
                destino = res.DESTINO;
                lote = res.LOTE;
                quantidade = res.QUANTIDADE;
                status_out = res.STATUS_OUT;
                lista = res.LISTA;

                Console.WriteLine("descricao:" + descricao_out);
                Console.WriteLine("destino :" + destino);
                Console.WriteLine("lote" + lote);
                Console.WriteLine("quantidade:" + quantidade);
                Console.WriteLine("status:" + status_out);

           }
            catch (Exception d)
            {
                Console.WriteLine(d.Message);
                Console.WriteLine(d.StackTrace);
                Log.log("CONTROLO QUALIDADE::" + d.StackTrace.ToString(), Log.DEBUG);
                Log.log("CONTROLO QUALIDADE::" + d.Message.ToString(), Log.DEBUG);
            }
        }

        public static void fecho_caixa(string user_id,string tipo_in, string lote_in, out string descricao_out, out string status_out)
        {
            descricao_out ="";
            status_out = "";
            try
            {



                Uri uri = new Uri(Properties.Settings.Default.caminho_fecho_caixa);
                var address = new EndpointAddress(uri, EndpointIdentity.CreateSpnIdentity("CaboVerde"));
                MRZCV.Fechar_caixa.ZWS_PEP_FECHAR_CAIXAClient wsclient = new Fechar_caixa.ZWS_PEP_FECHAR_CAIXAClient(CreateWebServiceInstance(), address);
                MRZCV.Fechar_caixa.ZF_PEP_FECHAR_CAIXARequest req = new Fechar_caixa.ZF_PEP_FECHAR_CAIXARequest();
                MRZCV.Fechar_caixa.ZF_PEP_FECHAR_CAIXA request = new Fechar_caixa.ZF_PEP_FECHAR_CAIXA();
                request.USER = user_id;
                request.TIPO = tipo_in;
                request.LOTE_IN = lote_in;
                request.HOST = System.Environment.MachineName;

                req.ZF_PEP_FECHAR_CAIXA = request;
                wsclient.ClientCredentials.UserName.UserName = user;
                wsclient.ClientCredentials.UserName.Password = pass;

                MRZCV.Fechar_caixa.ZF_PEP_FECHAR_CAIXAResponse response = wsclient.ZF_PEP_FECHAR_CAIXA(request);
                descricao_out = response.DESCRICAO;
                status_out = response.STATUS;

                Console.WriteLine("descricao:" + descricao_out);
                Console.WriteLine("status:" + status_out);
            }
            catch (Exception d)
            {
                Console.WriteLine(d.Message);
                Console.WriteLine(d.StackTrace);
                Log.log("CONTROLO QUALIDADE|FECHO CAIXA::" + d.StackTrace.ToString(), Log.DEBUG);
                Log.log("CONTROLO QUALIDADE|FECHO CAIXA::" + d.Message.ToString(), Log.DEBUG);
            }
                    

           
           
           }

        public static void fecho_sesao(string user_id, string transportadora, string tipo_in, out string descircao_out, out string status_out)
        {
            descircao_out = "";
            status_out = "";
            try
            {



                Uri uri = new Uri(Properties.Settings.Default.caminho_fecho_sesao);
                var address = new EndpointAddress(uri, EndpointIdentity.CreateSpnIdentity("CaboVerde"));
                MRZCV.Fechar_sessao.ZWS_PEP_FECHAR_SESSAOClient wsclient = new Fechar_sessao.ZWS_PEP_FECHAR_SESSAOClient(CreateWebServiceInstance(), address);
                MRZCV.Fechar_sessao.ZF_PEP_FECHAR_SESSAORequest req = new Fechar_sessao.ZF_PEP_FECHAR_SESSAORequest();
                MRZCV.Fechar_sessao.ZF_PEP_FECHAR_SESSAO request = new Fechar_sessao.ZF_PEP_FECHAR_SESSAO();
                request.USER = user_id;
                request.TRANSPORTADORA = transportadora;
                request.TIPO = tipo_in;
                request.HOST = System.Environment.MachineName;

                req.ZF_PEP_FECHAR_SESSAO = request;

                wsclient.ClientCredentials.UserName.UserName = user;
                wsclient.ClientCredentials.UserName.Password = pass;

                MRZCV.Fechar_sessao.ZF_PEP_FECHAR_SESSAOResponse response = wsclient.ZF_PEP_FECHAR_SESSAO(request);

                descircao_out = response.DESCRICAO;
                status_out = response.STATUS;

                Console.WriteLine("descricao:" + descircao_out);
                Console.WriteLine("status:" + status_out);
            }
            catch (Exception d)
            {
                Console.WriteLine(d.Message);
                Console.WriteLine(d.StackTrace);
                Log.log("CONTROLO QUALIDADE|FECHO SESSÃO::" + d.StackTrace.ToString(), Log.DEBUG);
                Log.log("CONTROLO QUALIDADE|FECHO SESSÃO::" + d.Message.ToString(), Log.DEBUG);
            }
            }

        public static void re_imprimir (string user_id,string transportadora,string expedicao, string mrz1_in, string mrz2_in, string lote_in, string tipo_in, out string descricao_out, out string status_out, out string tipo_out)
        {
            descricao_out = "";
            status_out = "";
            tipo_out ="";
            try
            {


                Uri uri = new Uri(Properties.Settings.Default.caminho_reimprimir);
                var address = new EndpointAddress(uri, EndpointIdentity.CreateSpnIdentity("CaboVerde"));
                MRZCV.Re_imprimir.ZWS_PEP_REIMPRESSAOClient wsclient = new Re_imprimir.ZWS_PEP_REIMPRESSAOClient(CreateWebServiceInstance(), address);
                MRZCV.Re_imprimir.ZF_PEP_REIMPRESSAORequest req = new Re_imprimir.ZF_PEP_REIMPRESSAORequest();
                MRZCV.Re_imprimir.ZF_PEP_REIMPRESSAO request = new Re_imprimir.ZF_PEP_REIMPRESSAO();
                request.USER = user_id;
                request.MRZ1 = mrz1_in;
                request.MRZ2 = mrz2_in;
                request.LOTE_IN = lote_in;
                request.TIPO_IN = tipo_in;
                request.TRANSPORTADORA = transportadora;
                request.GUIA_EXPEDICAO = expedicao;
                request.HOST = System.Environment.MachineName;

                
                req.ZF_PEP_REIMPRESSAO = request;
                wsclient.ClientCredentials.UserName.UserName = user;
                wsclient.ClientCredentials.UserName.Password = pass;

                MRZCV.Re_imprimir.ZF_PEP_REIMPRESSAOResponse response = wsclient.ZF_PEP_REIMPRESSAO(request);
                descricao_out = response.DESCRICAO;
                status_out = response.STATUS;
                tipo_out = response.TIPO_OUT;

                Console.WriteLine("descricao:" + descricao_out);
                Console.WriteLine("status out:" + status_out);
                Console.WriteLine("tipo_out:" + tipo_out);
            }
            catch (Exception d)
            {
                Console.WriteLine(d.Message);
                Console.WriteLine(d.StackTrace);
                Log.log("CONTROLO QUALIDADE|RE IMPRIMIR::" + d.StackTrace.ToString(), Log.DEBUG);
                Log.log("CONTROLO QUALIDADE|RE IMPRIMIR::" + d.Message.ToString(), Log.DEBUG);
            }

            }

        public static void retirar_pep (string user_id,string tipo_in,string[] lista_dados, out string total, out string status, out string lote, out string destino, out string descricao )
        {
            total ="";
            status = "";
            lote = "";
            destino = "";
            descricao = "";
            try
            {



                Uri uri = new Uri(Properties.Settings.Default.caminho_retirar_pep);
                var address = new EndpointAddress(uri, EndpointIdentity.CreateSpnIdentity("CaboVerde"));
                MRZCV.Retirar_pep.ZWS_PEP_RETIRAR_PEPClient wsclient = new Retirar_pep.ZWS_PEP_RETIRAR_PEPClient(CreateWebServiceInstance(), address);
                MRZCV.Retirar_pep.ZF_PEP_RETIRAR_PEPRequest req = new Retirar_pep.ZF_PEP_RETIRAR_PEPRequest();
                MRZCV.Retirar_pep.ZF_PEP_RETIRAR_PEP request = new Retirar_pep.ZF_PEP_RETIRAR_PEP();

                request.LISTA_IN = lista_dados;
                request.TIPO = tipo_in;
                request.USER = user_id;

                req.ZF_PEP_RETIRAR_PEP = request;

                wsclient.ClientCredentials.UserName.UserName = user;
                wsclient.ClientCredentials.UserName.Password = pass;

                MRZCV.Retirar_pep.ZF_PEP_RETIRAR_PEPResponse response = wsclient.ZF_PEP_RETIRAR_PEP(request);
                total = response.TOTAL;
                status = response.STATUS;
                lote = response.LOTE;
                destino = response.DESTINO;
                descricao = response.DESCRICAO;
            }
            catch (Exception d)
            {
                Console.WriteLine(d.Message);
                Console.WriteLine(d.StackTrace);
                Log.log("CONTROLO QUALIDADE|RETIRAR PEP::" + d.StackTrace.ToString(), Log.DEBUG);
                Log.log("CONTROLO QUALIDADE|RETIRAR PEP::" + d.Message.ToString(), Log.DEBUG);
            }
        }

    }
        }
    

