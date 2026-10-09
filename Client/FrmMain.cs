using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmMain : Form
    {
        private Prodavac ulogovani;
        public FrmMain(Prodavac prodavac)
        {
            InitializeComponent();
            ulogovani = prodavac;
        }

        private void pToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPretraziPorudzbine fpp = new FrmPretraziPorudzbine();
            fpp.ShowDialog();
        }

        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPorudzbina fp = new FrmPorudzbina(ulogovani);
            fp.ShowDialog();
        }

        private void dodajToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmMusterija fm = new FrmMusterija();
            fm.ShowDialog();
        }

        private void pretraziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPretraziMusterije fpm = new FrmPretraziMusterije();
            fpm.ShowDialog();
        }

        private void dodajToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmSS fss = new FrmSS();
            fss.ShowDialog();
        }

        private void poveziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPovezivanje fp = new FrmPovezivanje();
            fp.ShowDialog();
        }

        private void dodajToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmPoslastice fp = new FrmPoslastice();
            fp.ShowDialog();
        }
    }
}
