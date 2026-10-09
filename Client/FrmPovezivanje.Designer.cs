namespace Client
{
    partial class FrmPovezivanje
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
            label1 = new Label();
            cmbProdavac = new ComboBox();
            cmbStrucnaSprema = new ComboBox();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            txtStepen = new TextBox();
            txtDatum = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 62);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 0;
            label1.Text = "Prodavac:";
            // 
            // cmbProdavac
            // 
            cmbProdavac.FormattingEnabled = true;
            cmbProdavac.Location = new Point(166, 59);
            cmbProdavac.Name = "cmbProdavac";
            cmbProdavac.Size = new Size(148, 23);
            cmbProdavac.TabIndex = 1;
            // 
            // cmbStrucnaSprema
            // 
            cmbStrucnaSprema.FormattingEnabled = true;
            cmbStrucnaSprema.Location = new Point(166, 88);
            cmbStrucnaSprema.Name = "cmbStrucnaSprema";
            cmbStrucnaSprema.Size = new Size(148, 23);
            cmbStrucnaSprema.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 88);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 2;
            label2.Text = "Strucna sprema:";
            // 
            // button1
            // 
            button1.Location = new Point(68, 175);
            button1.Name = "button1";
            button1.Size = new Size(246, 36);
            button1.TabIndex = 4;
            button1.Text = "Povezi";
            button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(68, 121);
            label3.Name = "label3";
            label3.Size = new Size(132, 15);
            label3.TabIndex = 5;
            label3.Text = "Stepen Strucne Spreme:";
            // 
            // txtStepen
            // 
            txtStepen.Location = new Point(266, 117);
            txtStepen.Name = "txtStepen";
            txtStepen.Size = new Size(48, 23);
            txtStepen.TabIndex = 6;
            // 
            // txtDatum
            // 
            txtDatum.Location = new Point(166, 146);
            txtDatum.Name = "txtDatum";
            txtDatum.Size = new Size(148, 23);
            txtDatum.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(68, 150);
            label4.Name = "label4";
            label4.Size = new Size(89, 15);
            label4.TabIndex = 7;
            label4.Text = "Datum sticanja:";
            // 
            // FrmPovezivanje
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtDatum);
            Controls.Add(label4);
            Controls.Add(txtStepen);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(cmbStrucnaSprema);
            Controls.Add(label2);
            Controls.Add(cmbProdavac);
            Controls.Add(label1);
            Name = "FrmPovezivanje";
            Text = "FrmPovezivanje";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbProdavac;
        private ComboBox cmbStrucnaSprema;
        private Label label2;
        private Button button1;
        private Label label3;
        private TextBox txtStepen;
        private TextBox txtDatum;
        private Label label4;
    }
}