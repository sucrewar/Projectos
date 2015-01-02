using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MRZCV
{
    public partial class Form5 : Form
    {
        public static string[] mrz = null;
        public static string[] user_id = null;
        public static string descricao = "", status = "", tipo = "";
        public Form5()
        {
            InitializeComponent();
            System.Windows.Forms.MessageBox.Show("Se Puser o nº da guia de transporte, tem que escolher a transportadora", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            comboBox1.Enabled = true;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void Form5_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString())
            {
                case ("1")://F1
                    button1.PerformClick();
                    break;

                case ("2")://F2
                    button2.PerformClick();
                    break;



            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "")
            {
                comboBox1.Enabled = false;
                string transportadora = "";
                string dados = textBox1.Text;
                string n_lote = textBox2.Text;
                string n_transportadora = textBox3.Text;
                if (dados != "")
                {
                    comboBox1.Enabled = false;
                    if (dados.Length != 1)
                    {

                        if (dados.Length <= 95)
                        {

                            mrz = Regex.Split(dados, "\r\n");
                            textBox1.Text = String.Empty;

                        }
                        else if (dados.Length > 95)
                        {
                            Log.log(":: TAMANHO MRZ'S INVALIDO", Log.ERROR);
                            System.Windows.Forms.MessageBox.Show("Tamanho MRZ invalido", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox1.Text = String.Empty;
                        }
                    }
                    else if (dados.Length == 1)
                    {
                        textBox1.Text = String.Empty;
                    }
                }
                else if (dados != "")
                {
                    Log.log("::MRZ não selecionado para retirar PEP", Log.PROCESS);
                }

               if (n_transportadora != "")
               {
                   comboBox1.Enabled = true;
                   transportadora = comboBox1.Text.ToString();
                   
               }
                
                
                
                String user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                user_id = user.Split('\\');

                MRZCV.Webservices.re_imprimir(user_id[1], transportadora, n_transportadora, mrz[0], mrz[1], n_lote, "PECV", out descricao, out status, out tipo);
                System.Windows.Forms.MessageBox.Show(descricao, "DESCRIÇÂO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (status == "NOK")
                {
                    Log.log("USER::" + user_id[1] + "::RE-IMPRESSÃO::STATUS::" + status, Log.PROCESS);
                    Log.log("USER::" + user_id[1] + "::RE-IMPRESSÃO::DESCRIÇÃO::" + descricao, Log.PROCESS);
                }
                else if (status == "OK")
                {
                    Log.log("USER::" + user_id[1] + "::RE-IMPRESSÃO::STATUS::" + status, Log.PROCESS);
                    Log.log("USER::" + user_id[1] + "::RE-IMPRESSÃO::DESCRIÇÃO::" + descricao, Log.PROCESS);
                    this.Hide();
                    Form1 frm = new Form1();
                    frm.Show(this);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Nenhum campo preenchido!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show(this);
        }
    }
}