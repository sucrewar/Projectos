namespace MRZCV
{
    partial class Form6
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            this.retirar_select = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.retirar = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.voltar_inico = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // retirar_select
            // 
            this.retirar_select.Location = new System.Drawing.Point(66, 293);
            this.retirar_select.Name = "retirar_select";
            this.retirar_select.Size = new System.Drawing.Size(124, 40);
            this.retirar_select.TabIndex = 10;
            this.retirar_select.Text = "Retirar Selecionados";
            this.retirar_select.UseVisualStyleBackColor = true;
            this.retirar_select.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(86, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Selecionar os passaportes a retirar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(-2, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(482, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "Passaporte Electrónico de Cabo Verde";
            // 
            // retirar
            // 
            this.retirar.Location = new System.Drawing.Point(207, 293);
            this.retirar.Name = "retirar";
            this.retirar.Size = new System.Drawing.Size(105, 40);
            this.retirar.TabIndex = 11;
            this.retirar.Text = "Retirar Todos";
            this.retirar.UseVisualStyleBackColor = true;
            this.retirar.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(66, 105);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(371, 139);
            this.checkedListBox1.TabIndex = 12;
            // 
            // voltar_inico
            // 
            this.voltar_inico.Location = new System.Drawing.Point(335, 293);
            this.voltar_inico.Name = "voltar_inico";
            this.voltar_inico.Size = new System.Drawing.Size(102, 39);
            this.voltar_inico.TabIndex = 13;
            this.voltar_inico.Text = "voltar_inico";
            this.voltar_inico.UseVisualStyleBackColor = true;
            this.voltar_inico.Click += new System.EventHandler(this.voltar_inico_Click);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(495, 355);
            this.Controls.Add(this.voltar_inico);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.retirar);
            this.Controls.Add(this.retirar_select);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form6";
            this.Text = "Passaporte Electronico- Retirar PEP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button retirar_select;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button retirar;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button voltar_inico;
    }
}