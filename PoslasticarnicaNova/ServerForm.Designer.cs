namespace PoslasticarnicaNova
{
    partial class ServerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnPokreni = new Button();
            btnZaustavi = new Button();
            lblServer = new Label();
            SuspendLayout();
            // 
            // btnPokreni
            // 
            btnPokreni.Location = new Point(52, 90);
            btnPokreni.Name = "btnPokreni";
            btnPokreni.Size = new Size(112, 37);
            btnPokreni.TabIndex = 0;
            btnPokreni.Text = "POKRENI";
            btnPokreni.UseVisualStyleBackColor = true;
            btnPokreni.Click += btnPokreni_Click;
            // 
            // btnZaustavi
            // 
            btnZaustavi.Location = new Point(270, 90);
            btnZaustavi.Name = "btnZaustavi";
            btnZaustavi.Size = new Size(112, 37);
            btnZaustavi.TabIndex = 1;
            btnZaustavi.Text = "ZAUSTAVI";
            btnZaustavi.UseVisualStyleBackColor = true;
            btnZaustavi.Click += btnZaustavi_Click;
            // 
            // lblServer
            // 
            lblServer.AutoSize = true;
            lblServer.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblServer.Location = new Point(52, 32);
            lblServer.Name = "lblServer";
            lblServer.Size = new Size(198, 35);
            lblServer.TabIndex = 2;
            lblServer.Text = "Status servera:";
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 284);
            Controls.Add(lblServer);
            Controls.Add(btnZaustavi);
            Controls.Add(btnPokreni);
            Name = "ServerForm";
            Text = "Server";
            FormClosed += ServerForm_FormClosed;
            Load += ServerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPokreni;
        private Button btnZaustavi;
        private Label lblServer;
    }
}
