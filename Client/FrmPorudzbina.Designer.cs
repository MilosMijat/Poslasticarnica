namespace Client
{
    partial class FrmPorudzbina
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
            txtDatum = new TextBox();
            groupBox1 = new GroupBox();
            checkBox1 = new CheckBox();
            txtAdresa = new TextBox();
            label4 = new Label();
            btnKreiraj = new Button();
            cmbProdavac = new ComboBox();
            dataGridView1 = new DataGridView();
            groupBox2 = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label2 = new Label();
            label3 = new Label();
            cmbMusterija = new ComboBox();
            btnobrisi = new Button();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            lblID = new Label();
            btnDodaj = new Button();
            txtCena = new TextBox();
            label8 = new Label();
            txtIznos = new TextBox();
            label9 = new Label();
            txtKolicina = new TextBox();
            label7 = new Label();
            label6 = new Label();
            cmbPoslastica = new ComboBox();
            txtUkIznos = new TextBox();
            label5 = new Label();
            btnSacuvaj = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 34);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 0;
            label1.Text = "Datum:";
            // 
            // txtDatum
            // 
            txtDatum.Location = new Point(121, 31);
            txtDatum.Name = "txtDatum";
            txtDatum.Size = new Size(123, 23);
            txtDatum.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(txtAdresa);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(32, 64);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(212, 107);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dostava";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(17, 32);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(68, 19);
            checkBox1.TabIndex = 13;
            checkBox1.Text = "Dostava";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // txtAdresa
            // 
            txtAdresa.Location = new Point(17, 76);
            txtAdresa.Name = "txtAdresa";
            txtAdresa.Size = new Size(184, 23);
            txtAdresa.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 57);
            label4.Name = "label4";
            label4.Size = new Size(105, 15);
            label4.TabIndex = 10;
            label4.Text = "Adresa za dostavu:";
            // 
            // btnKreiraj
            // 
            btnKreiraj.Location = new Point(261, 129);
            btnKreiraj.Name = "btnKreiraj";
            btnKreiraj.Size = new Size(207, 42);
            btnKreiraj.TabIndex = 3;
            btnKreiraj.Text = "Kreiraj Porudzbinu";
            btnKreiraj.UseVisualStyleBackColor = true;
            btnKreiraj.Click += btnKreiraj_Click;
            // 
            // cmbProdavac
            // 
            cmbProdavac.FormattingEnabled = true;
            cmbProdavac.Location = new Point(326, 71);
            cmbProdavac.Name = "cmbProdavac";
            cmbProdavac.Size = new Size(142, 23);
            cmbProdavac.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(503, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(323, 401);
            dataGridView1.TabIndex = 5;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButton2);
            groupBox2.Controls.Add(radioButton1);
            groupBox2.Location = new Point(261, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(207, 53);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Način Plaćanja";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(84, 22);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(61, 19);
            radioButton2.TabIndex = 11;
            radioButton2.TabStop = true;
            radioButton2.Text = "Kartica";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(9, 22);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(43, 19);
            radioButton1.TabIndex = 10;
            radioButton1.TabStop = true;
            radioButton1.Text = "Keš";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(261, 74);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 6;
            label2.Text = "Prodavac:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(261, 103);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 8;
            label3.Text = "Mušterija:";
            // 
            // cmbMusterija
            // 
            cmbMusterija.FormattingEnabled = true;
            cmbMusterija.Location = new Point(326, 100);
            cmbMusterija.Name = "cmbMusterija";
            cmbMusterija.Size = new Size(142, 23);
            cmbMusterija.TabIndex = 7;
            // 
            // btnobrisi
            // 
            btnobrisi.Location = new Point(503, 448);
            btnobrisi.Name = "btnobrisi";
            btnobrisi.Size = new Size(160, 43);
            btnobrisi.TabIndex = 9;
            btnobrisi.Text = "IZBRIŠI";
            btnobrisi.UseVisualStyleBackColor = true;
            btnobrisi.Click += btnobrisi_Click;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = SystemColors.ActiveBorder;
            groupBox3.Controls.Add(groupBox4);
            groupBox3.Controls.Add(btnDodaj);
            groupBox3.Controls.Add(txtCena);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(txtIznos);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(txtKolicina);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(cmbPoslastica);
            groupBox3.Location = new Point(32, 192);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(436, 250);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Stavke Porudzbine";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lblID);
            groupBox4.Location = new Point(35, 22);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(209, 44);
            groupBox4.TabIndex = 14;
            groupBox4.TabStop = false;
            groupBox4.Text = "ID Porudžbine:";
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(98, 19);
            lblID.Name = "lblID";
            lblID.Size = new Size(12, 15);
            lblID.TabIndex = 20;
            lblID.Text = "/";
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(100, 188);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(144, 43);
            btnDodaj.TabIndex = 13;
            btnDodaj.Text = "DODAJ";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // txtCena
            // 
            txtCena.Location = new Point(100, 130);
            txtCena.Name = "txtCena";
            txtCena.Size = new Size(144, 23);
            txtCena.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(35, 133);
            label8.Name = "label8";
            label8.Size = new Size(37, 15);
            label8.TabIndex = 17;
            label8.Text = "Cena:";
            // 
            // txtIznos
            // 
            txtIznos.Location = new Point(100, 159);
            txtIznos.Name = "txtIznos";
            txtIznos.Size = new Size(144, 23);
            txtIznos.TabIndex = 16;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(35, 162);
            label9.Name = "label9";
            label9.Size = new Size(37, 15);
            label9.TabIndex = 15;
            label9.Text = "Iznos:";
            // 
            // txtKolicina
            // 
            txtKolicina.Location = new Point(100, 101);
            txtKolicina.Name = "txtKolicina";
            txtKolicina.Size = new Size(144, 23);
            txtKolicina.TabIndex = 14;
            txtKolicina.TextChanged += txtKolicina_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(35, 104);
            label7.Name = "label7";
            label7.Size = new Size(52, 15);
            label7.TabIndex = 13;
            label7.Text = "Količina:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(35, 75);
            label6.Name = "label6";
            label6.Size = new Size(62, 15);
            label6.TabIndex = 14;
            label6.Text = "Poslastica:";
            // 
            // cmbPoslastica
            // 
            cmbPoslastica.FormattingEnabled = true;
            cmbPoslastica.Location = new Point(100, 72);
            cmbPoslastica.Name = "cmbPoslastica";
            cmbPoslastica.Size = new Size(144, 23);
            cmbPoslastica.TabIndex = 13;
            cmbPoslastica.SelectedIndexChanged += cmbPoslastica_SelectedIndexChanged;
            // 
            // txtUkIznos
            // 
            txtUkIznos.Location = new Point(726, 419);
            txtUkIznos.Name = "txtUkIznos";
            txtUkIznos.Size = new Size(100, 23);
            txtUkIznos.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(530, 422);
            label5.Name = "label5";
            label5.Size = new Size(81, 15);
            label5.TabIndex = 10;
            label5.Text = "Ukupan Iznos:";
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(669, 448);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(157, 43);
            btnSacuvaj.TabIndex = 12;
            btnSacuvaj.Text = "SAČUVAJ";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // FrmPorudzbina
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 514);
            Controls.Add(btnSacuvaj);
            Controls.Add(txtUkIznos);
            Controls.Add(label5);
            Controls.Add(groupBox3);
            Controls.Add(btnobrisi);
            Controls.Add(label3);
            Controls.Add(cmbMusterija);
            Controls.Add(label2);
            Controls.Add(groupBox2);
            Controls.Add(dataGridView1);
            Controls.Add(cmbProdavac);
            Controls.Add(btnKreiraj);
            Controls.Add(groupBox1);
            Controls.Add(txtDatum);
            Controls.Add(label1);
            Name = "FrmPorudzbina";
            Text = "FrmPorudzbina";
            Load += FrmPorudzbina_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtDatum;
        private GroupBox groupBox1;
        private TextBox txtAdresa;
        private Label label4;
        private Button btnKreiraj;
        private ComboBox cmbProdavac;
        private DataGridView dataGridView1;
        private GroupBox groupBox2;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label2;
        private Label label3;
        private ComboBox cmbMusterija;
        private Button btnobrisi;
        private GroupBox groupBox3;
        private TextBox txtUkIznos;
        private Label label5;
        private Button btnSacuvaj;
        private Button btnDodaj;
        private Label lblID;
        private TextBox txtCena;
        private Label label8;
        private TextBox txtIznos;
        private Label label9;
        private TextBox txtKolicina;
        private Label label7;
        private Label label6;
        private ComboBox cmbPoslastica;
        private CheckBox checkBox1;
        private GroupBox groupBox4;
    }
}