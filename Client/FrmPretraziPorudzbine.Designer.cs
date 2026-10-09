namespace Client
{
    partial class FrmPretraziPorudzbine
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            txtDatum = new TextBox();
            groupBox1 = new GroupBox();
            txtAdresa = new TextBox();
            groupBox2 = new GroupBox();
            rbKartica = new RadioButton();
            rbKes = new RadioButton();
            label2 = new Label();
            label3 = new Label();
            cmbProdavac = new ComboBox();
            cmbMusterija = new ComboBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(240, 21);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(712, 331);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 24);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 1;
            label1.Text = "Datum:";
            // 
            // txtDatum
            // 
            txtDatum.Location = new Point(84, 21);
            txtDatum.Name = "txtDatum";
            txtDatum.Size = new Size(133, 23);
            txtDatum.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtAdresa);
            groupBox1.Location = new Point(26, 58);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(197, 76);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Adresa za dostavu";
            // 
            // txtAdresa
            // 
            txtAdresa.Location = new Point(6, 37);
            txtAdresa.Name = "txtAdresa";
            txtAdresa.Size = new Size(185, 23);
            txtAdresa.TabIndex = 4;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbKartica);
            groupBox2.Controls.Add(rbKes);
            groupBox2.Location = new Point(26, 150);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(197, 76);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Nacin placanja";
            // 
            // rbKartica
            // 
            rbKartica.AutoSize = true;
            rbKartica.Location = new Point(97, 38);
            rbKartica.Name = "rbKartica";
            rbKartica.Size = new Size(61, 19);
            rbKartica.TabIndex = 7;
            rbKartica.TabStop = true;
            rbKartica.Text = "Kartica";
            rbKartica.UseVisualStyleBackColor = true;
            // 
            // rbKes
            // 
            rbKes.AutoSize = true;
            rbKes.Location = new Point(19, 38);
            rbKes.Name = "rbKes";
            rbKes.Size = new Size(43, 19);
            rbKes.TabIndex = 6;
            rbKes.TabStop = true;
            rbKes.Text = "Keš";
            rbKes.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 279);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 6;
            label2.Text = "Musterija:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 243);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 7;
            label3.Text = "Prodavac:";
            // 
            // cmbProdavac
            // 
            cmbProdavac.FormattingEnabled = true;
            cmbProdavac.Location = new Point(94, 240);
            cmbProdavac.Name = "cmbProdavac";
            cmbProdavac.Size = new Size(123, 23);
            cmbProdavac.TabIndex = 8;
            // 
            // cmbMusterija
            // 
            cmbMusterija.FormattingEnabled = true;
            cmbMusterija.Location = new Point(94, 276);
            cmbMusterija.Name = "cmbMusterija";
            cmbMusterija.Size = new Size(123, 23);
            cmbMusterija.TabIndex = 9;
            // 
            // button1
            // 
            button1.Location = new Point(26, 305);
            button1.Name = "button1";
            button1.Size = new Size(191, 47);
            button1.TabIndex = 10;
            button1.Text = "Pretrazi";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FrmPretraziPorudzbine
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(977, 372);
            Controls.Add(button1);
            Controls.Add(cmbMusterija);
            Controls.Add(cmbProdavac);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(txtDatum);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "FrmPretraziPorudzbine";
            Text = "FrmPretraziPorudzbine";
            Load += FrmPretraziPorudzbine_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private TextBox txtDatum;
        private GroupBox groupBox1;
        private TextBox txtAdresa;
        private GroupBox groupBox2;
        private RadioButton rbKartica;
        private RadioButton rbKes;
        private Label label2;
        private Label label3;
        private ComboBox cmbProdavac;
        private ComboBox cmbMusterija;
        private Button button1;
    }
}