using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MRZCV
{
    public partial class Form6 : Form
    {
        public static string[] user_id = null;
        public static string[] dados = null;
        public Form6()
        {
            InitializeComponent();
            int tamanho = Form1.lote_user.Length;
            for (int i = 0; i < tamanho; i++)
            {
                checkedListBox1.Items.Add(Form1.lote_user[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count != 0)
            {
                dados = new string[checkedListBox1.CheckedItems.Count];
                for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                {

                    dados[i] = checkedListBox1.CheckedItems[i].ToString();
                    Console.WriteLine("dados:" + dados[i]);
                }

                string total = "", status = "", lote = "", destino = "", descricao = "";
                String user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                user_id = user.Split('\\');
                MRZCV.Webservices.retirar_pep(user_id[1], Form1.tipo_out, dados, out total, out status, out lote, out destino, out descricao);
                System.Windows.Forms.MessageBox.Show(status, "STATUS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (status == "NOK")
                {
                    Log.log("USER::" + user_id[1] + "::RETIRAR_PEP::STATUS::" + status, Log.PROCESS);
                    Log.log("USER::" + user_id[1] + "::RETIRAR_PEP::DESCRIÇÃO" + descricao, Log.PROCESS);
                }
                else if (status == "OK")
                {
                    Log.log("USER::" + user_id[1] + "::RETIRAR PEP::STATUS::" + status, Log.PROCESS);
                    Log.log("USER::" + user_id[1] + "::RETIRAR PEP::STATUS::" + descricao, Log.PROCESS);
                }

            }
            else
            {
                System.Windows.Forms.MessageBox.Show("NENHUMA ESCOLHA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] result = new string[10];
            
            Form1.lote_user = Form1.lote_user.Except(dados).ToArray();
            for (int i = 0; i < Form1.lote_user.Length; i++)
            {
               Console.WriteLine("DADOS::::"+Form1.lote_user[i]);
            }
            this.Hide();
            Form1 frm = new Form1();
            frm.Show(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string total = "", status = "", lote = "", destino = "", descricao = "";
            String user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            user_id = user.Split('\\');
            MRZCV.Webservices.retirar_pep(user_id[1], Form1.tipo_out, Form1.lote_user, out total, out status, out lote, out destino, out descricao);
            System.Windows.Forms.MessageBox.Show(status, "STATUS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (status == "NOK")
            {
                Log.log("USER::" + user_id[1] + "::RETIRAR_PEP::STATUS::" + status, Log.PROCESS);
                Log.log("USER::" + user_id[1] + "::RETIRAR_PEP::DESCRIÇÃO" + descricao, Log.PROCESS);
            }
            else if (status == "OK")
            {
                Log.log("USER::" + user_id[1] + "::RETIRAR PEP::STATUS::" + status, Log.PROCESS);
                Log.log("USER::" + user_id[1] + "::RETIRAR PEP::STATUS::" + descricao, Log.PROCESS);
            }
            this.Hide();
            Form1 frm = new Form1();
            frm.Show(this);
        }

        private void voltar_inico_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show(this);
        }


    }
}
