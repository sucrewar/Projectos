using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;

namespace MRZCV
{
    class Imprimir
    {
       // public Array dados_imprimir;
        public void ordem_imprime()
         {
           

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.PrintReceiptPage);
            pd.PrinterSettings.PrinterName = @Properties.Settings.Default.nome_impressora;
            pd.DocumentName = "OBS PRINT ";
            pd.PrinterSettings.DefaultPageSettings.PrinterResolution.X = 595;
            pd.PrinterSettings.DefaultPageSettings.PrinterResolution.Y = 841;
           // pd.DefaultPageSettings.Margins.Right = 5 ;
            Margins margins = new Margins(100, 100, 595, 841);
            pd.DefaultPageSettings.Margins = margins;
            pd.Print();

        
        }

        private void PrintReceiptPage(object sender, PrintPageEventArgs e)
        {
            //string MSG_TESTE =" I have everything initialized.I don't want to create the methods as static. I read over the specifics of my assignment again and";




            //int tamanho_message = message.Length;
            int y, x;
            // Print receipt
            int tamanho_letra = Form1.tipo_linha;
            //int tamanho_letra = 9;
            Font myFont = new Font("FlamaSef", tamanho_letra);
            y = e.MarginBounds.Y;
            x = e.MarginBounds.X;
            int d = 150;
            int r = 155;
            string[] observacoes = Form1.observacoes;
            
             int o = observacoes.Length;

                 for (int i = 0; i < o; i++)
                 {
                     e.Graphics.DrawString(observacoes[i], myFont, Brushes.Black, d, r);
                     r = r + 15;
                 }

        }

        public void ordem_imprime_tamanho6()
        {


            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.PrintReceiptPage_tamanho6);
            pd.PrinterSettings.PrinterName = @Properties.Settings.Default.nome_impressora;
            pd.DocumentName = "OBS PRINT ";
            pd.PrinterSettings.DefaultPageSettings.PrinterResolution.X = 595;
            pd.PrinterSettings.DefaultPageSettings.PrinterResolution.Y = 841;
            // pd.DefaultPageSettings.Margins.Right = 5 ;
            Margins margins = new Margins(100, 100, 595, 841);
            pd.DefaultPageSettings.Margins = margins;
            pd.Print();


        }

        private void PrintReceiptPage_tamanho6(object sender, PrintPageEventArgs e)
        {
            //string MSG_TESTE =" I have everything initialized.I don't want to create the methods as static. I read over the specifics of my assignment again and";




            //int tamanho_message = message.Length;
            int y, x;
            // Print receipt
            int tamanho_letra = Form1.tipo_linha;
            //int tamanho_letra = 9;
            Font myFont = new Font("FlamaSef", tamanho_letra);
            y = e.MarginBounds.Y;
            x = e.MarginBounds.X;
            int d = 150;
            int r = 155;
            string[] observacoes = Form1.observacoes;

            int o = observacoes.Length;

            for (int i = 0; i < o; i++)
            {
                e.Graphics.DrawString(observacoes[i], myFont, Brushes.Black, d, r);
                r = r + 10;
            }

        }

        public void ordem_imprime_tamanho4()
        {


            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.PrintReceiptPage_tamanho4);
            pd.PrinterSettings.PrinterName = @Properties.Settings.Default.nome_impressora;
            pd.DocumentName = "OBS PRINT ";
            pd.PrinterSettings.DefaultPageSettings.PrinterResolution.X = 595;
            pd.PrinterSettings.DefaultPageSettings.PrinterResolution.Y = 841;
            // pd.DefaultPageSettings.Margins.Right = 5 ;
            Margins margins = new Margins(100, 100, 595, 841);
            pd.DefaultPageSettings.Margins = margins;
            pd.Print();


        }

        private void PrintReceiptPage_tamanho4(object sender, PrintPageEventArgs e)
        {
            //string MSG_TESTE =" I have everything initialized.I don't want to create the methods as static. I read over the specifics of my assignment again and";




            //int tamanho_message = message.Length;
            int y, x;
            // Print receipt
            int tamanho_letra = Form1.tipo_linha;
            //int tamanho_letra = 9;
            Font myFont = new Font("FlamaSef", tamanho_letra);
            y = e.MarginBounds.Y;
            x = e.MarginBounds.X;
            int d = 150;
            int r = 155;
            string[] observacoes = Form1.observacoes;

            int o = observacoes.Length;

            for (int i = 0; i < o; i++)
            {
                e.Graphics.DrawString(observacoes[i], myFont, Brushes.Black, d, r);
                r = r + 8;
            }

        }




    }
}
