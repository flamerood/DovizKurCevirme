namespace DovizKurCevir
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label3 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.rbEURO = new System.Windows.Forms.RadioButton();
            this.rbUSD = new System.Windows.Forms.RadioButton();
            this.rbTL = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCalistir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(39, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 16);
            this.label3.TabIndex = 33;
            this.label3.Text = "GİRİLEN DEĞER";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(284, 72);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(161, 81);
            this.txtResult.TabIndex = 32;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(42, 75);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(100, 20);
            this.txtValue.TabIndex = 31;
            // 
            // rbEURO
            // 
            this.rbEURO.AutoSize = true;
            this.rbEURO.Location = new System.Drawing.Point(183, 121);
            this.rbEURO.Name = "rbEURO";
            this.rbEURO.Size = new System.Drawing.Size(56, 17);
            this.rbEURO.TabIndex = 30;
            this.rbEURO.TabStop = true;
            this.rbEURO.Text = "EURO";
            this.rbEURO.UseVisualStyleBackColor = true;
            // 
            // rbUSD
            // 
            this.rbUSD.AutoSize = true;
            this.rbUSD.Location = new System.Drawing.Point(183, 98);
            this.rbUSD.Name = "rbUSD";
            this.rbUSD.Size = new System.Drawing.Size(48, 17);
            this.rbUSD.TabIndex = 29;
            this.rbUSD.TabStop = true;
            this.rbUSD.Text = "USD";
            this.rbUSD.UseVisualStyleBackColor = true;
            // 
            // rbTL
            // 
            this.rbTL.AutoSize = true;
            this.rbTL.Location = new System.Drawing.Point(183, 75);
            this.rbTL.Name = "rbTL";
            this.rbTL.Size = new System.Drawing.Size(38, 17);
            this.rbTL.TabIndex = 28;
            this.rbTL.TabStop = true;
            this.rbTL.Text = "TL";
            this.rbTL.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(180, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "KUR BİÇİMİ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(281, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "KUR DEĞERİ";
            // 
            // btnCalistir
            // 
            this.btnCalistir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCalistir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCalistir.Location = new System.Drawing.Point(323, 212);
            this.btnCalistir.Name = "btnCalistir";
            this.btnCalistir.Size = new System.Drawing.Size(122, 27);
            this.btnCalistir.TabIndex = 25;
            this.btnCalistir.Text = "ÇALIŞTIR";
            this.btnCalistir.UseVisualStyleBackColor = true;
            this.btnCalistir.Click += new System.EventHandler(this.btnCalistir_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 277);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.rbEURO);
            this.Controls.Add(this.rbUSD);
            this.Controls.Add(this.rbTL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCalistir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Döviz Kur Çevirme";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.RadioButton rbEURO;
        private System.Windows.Forms.RadioButton rbUSD;
        private System.Windows.Forms.RadioButton rbTL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCalistir;
    }
}