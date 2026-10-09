namespace Client
{
    partial class FrmMain
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
            menuStrip1 = new MenuStrip();
            porudzbinaToolStripMenuItem = new ToolStripMenuItem();
            dodajToolStripMenuItem = new ToolStripMenuItem();
            pToolStripMenuItem = new ToolStripMenuItem();
            musterijaToolStripMenuItem = new ToolStripMenuItem();
            dodajToolStripMenuItem1 = new ToolStripMenuItem();
            pretraziToolStripMenuItem = new ToolStripMenuItem();
            strucnaSpremaToolStripMenuItem = new ToolStripMenuItem();
            dodajToolStripMenuItem2 = new ToolStripMenuItem();
            poveziToolStripMenuItem = new ToolStripMenuItem();
            poslasticeToolStripMenuItem = new ToolStripMenuItem();
            dodajToolStripMenuItem3 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { porudzbinaToolStripMenuItem, musterijaToolStripMenuItem, strucnaSpremaToolStripMenuItem, poslasticeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 31);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // porudzbinaToolStripMenuItem
            // 
            porudzbinaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dodajToolStripMenuItem, pToolStripMenuItem });
            porudzbinaToolStripMenuItem.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            porudzbinaToolStripMenuItem.Name = "porudzbinaToolStripMenuItem";
            porudzbinaToolStripMenuItem.Size = new Size(104, 27);
            porudzbinaToolStripMenuItem.Text = "Porudzbina";
            // 
            // dodajToolStripMenuItem
            // 
            dodajToolStripMenuItem.Name = "dodajToolStripMenuItem";
            dodajToolStripMenuItem.Size = new Size(144, 28);
            dodajToolStripMenuItem.Text = "Dodaj";
            dodajToolStripMenuItem.Click += dodajToolStripMenuItem_Click;
            // 
            // pToolStripMenuItem
            // 
            pToolStripMenuItem.Name = "pToolStripMenuItem";
            pToolStripMenuItem.Size = new Size(144, 28);
            pToolStripMenuItem.Text = "Pretrazi";
            pToolStripMenuItem.Click += pToolStripMenuItem_Click;
            // 
            // musterijaToolStripMenuItem
            // 
            musterijaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dodajToolStripMenuItem1, pretraziToolStripMenuItem });
            musterijaToolStripMenuItem.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            musterijaToolStripMenuItem.Name = "musterijaToolStripMenuItem";
            musterijaToolStripMenuItem.Size = new Size(96, 27);
            musterijaToolStripMenuItem.Text = "Musterija";
            // 
            // dodajToolStripMenuItem1
            // 
            dodajToolStripMenuItem1.Name = "dodajToolStripMenuItem1";
            dodajToolStripMenuItem1.Size = new Size(144, 28);
            dodajToolStripMenuItem1.Text = "Dodaj";
            dodajToolStripMenuItem1.Click += dodajToolStripMenuItem1_Click;
            // 
            // pretraziToolStripMenuItem
            // 
            pretraziToolStripMenuItem.Name = "pretraziToolStripMenuItem";
            pretraziToolStripMenuItem.Size = new Size(144, 28);
            pretraziToolStripMenuItem.Text = "Pretrazi";
            pretraziToolStripMenuItem.Click += pretraziToolStripMenuItem_Click;
            // 
            // strucnaSpremaToolStripMenuItem
            // 
            strucnaSpremaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dodajToolStripMenuItem2, poveziToolStripMenuItem });
            strucnaSpremaToolStripMenuItem.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            strucnaSpremaToolStripMenuItem.Name = "strucnaSpremaToolStripMenuItem";
            strucnaSpremaToolStripMenuItem.Size = new Size(147, 27);
            strucnaSpremaToolStripMenuItem.Text = "Strucna Sprema";
            // 
            // dodajToolStripMenuItem2
            // 
            dodajToolStripMenuItem2.Name = "dodajToolStripMenuItem2";
            dodajToolStripMenuItem2.Size = new Size(127, 28);
            dodajToolStripMenuItem2.Text = "Dodaj";
            dodajToolStripMenuItem2.Click += dodajToolStripMenuItem2_Click;
            // 
            // poveziToolStripMenuItem
            // 
            poveziToolStripMenuItem.Name = "poveziToolStripMenuItem";
            poveziToolStripMenuItem.Size = new Size(127, 28);
            poveziToolStripMenuItem.Text = "Povezi";
            poveziToolStripMenuItem.Click += poveziToolStripMenuItem_Click;
            // 
            // poslasticeToolStripMenuItem
            // 
            poslasticeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dodajToolStripMenuItem3 });
            poslasticeToolStripMenuItem.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            poslasticeToolStripMenuItem.Name = "poslasticeToolStripMenuItem";
            poslasticeToolStripMenuItem.Size = new Size(97, 27);
            poslasticeToolStripMenuItem.Text = "Poslastice";
            // 
            // dodajToolStripMenuItem3
            // 
            dodajToolStripMenuItem3.Name = "dodajToolStripMenuItem3";
            dodajToolStripMenuItem3.Size = new Size(180, 28);
            dodajToolStripMenuItem3.Text = "Dodaj";
            dodajToolStripMenuItem3.Click += dodajToolStripMenuItem3_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.IndianRed;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmMain";
            Text = "FrmMain";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem porudzbinaToolStripMenuItem;
        private ToolStripMenuItem dodajToolStripMenuItem;
        private ToolStripMenuItem musterijaToolStripMenuItem;
        private ToolStripMenuItem pToolStripMenuItem;
        private ToolStripMenuItem dodajToolStripMenuItem1;
        private ToolStripMenuItem pretraziToolStripMenuItem;
        private ToolStripMenuItem strucnaSpremaToolStripMenuItem;
        private ToolStripMenuItem dodajToolStripMenuItem2;
        private ToolStripMenuItem poveziToolStripMenuItem;
        private ToolStripMenuItem poslasticeToolStripMenuItem;
        private ToolStripMenuItem dodajToolStripMenuItem3;
    }
}