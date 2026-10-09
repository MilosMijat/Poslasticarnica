using Server;

namespace PoslasticarnicaNova
{
    public partial class ServerForm : Form
    {
        private Server.Server server;
        public ServerForm()
        {
            InitializeComponent();
            btnPokreni.Enabled = true;
            btnZaustavi.Enabled = false;
            lblServer.Text = "Server ceka na pokretanje";
            lblServer.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void btnPokreni_Click(object sender, EventArgs e)
        {
            server = new Server.Server();
            btnPokreni.Enabled = false;
            btnZaustavi.Enabled = true;
            lblServer.Text = "Server je pokrenut";
            lblServer.TextAlign = ContentAlignment.MiddleCenter;
            server.Start();
        }

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            btnPokreni.Enabled = true;
            btnZaustavi.Enabled = false;
            lblServer.Text = "Server je zaustavljen";
            lblServer.TextAlign = ContentAlignment.MiddleCenter;
            server.Stop();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {

        }

        private void ServerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
