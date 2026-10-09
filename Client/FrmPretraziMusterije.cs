using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmPretraziMusterije : Form
    {
        private List<Grad> gradovi = new List<Grad>();
        private List<Musterija> sveMusterije = new List<Musterija>();
        private List<Musterija> pronadjeneMusterije = new List<Musterija>();

        public FrmPretraziMusterije()
        {
            InitializeComponent();
            Load += FrmPretraziMusterije_Load;
            btnPretrazi.Click += btnPretrazi_Click;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            rbFizicko.CheckedChanged += TipMusterije_CheckedChanged;
            rbPravno.CheckedChanged += TipMusterije_CheckedChanged;
        }

        private void FrmPretraziMusterije_Load(object? sender, EventArgs e)
        {
            try
            {
                gradovi = Communication.Instance.VratiSveGradove();
                sveMusterije = Communication.Instance.VratiSveMusterije();

                List<Grad> gradoviZaPrikaz = new List<Grad>
                {
                    new Grad { Id = 0, Naziv = "Svi gradovi" }
                };
                gradoviZaPrikaz.AddRange(gradovi);

                cmbGrad.DataSource = null;
                cmbGrad.DataSource = gradoviZaPrikaz;
                cmbGrad.DisplayMember = "Naziv";
                cmbGrad.ValueMember = "Id";
                cmbGrad.SelectedIndex = 0;

                rbFizicko.Checked = true;
                PripremiGrid();
                OsveziLabeleZaTipMusterije();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska pri ucitavanju forme: " + ex.Message);
            }
        }

        private void TipMusterije_CheckedChanged(object? sender, EventArgs e)
        {
            OsveziLabeleZaTipMusterije();
            PripremiGrid();
        }

        private void OsveziLabeleZaTipMusterije()
        {
            if (rbPravno.Checked)
            {
                label1.Text = "Naziv:";
                label2.Text = "PIB:";
                return;
            }

            label1.Text = "Ime:";
            label2.Text = "Prezime:";
        }

        private void btnPretrazi_Click(object? sender, EventArgs e)
        {
            try
            {
                IEnumerable<Musterija> upit = sveMusterije;

                string prviKriterijum = txtIme.Text.Trim();
                string drugiKriterijum = txtPrezime.Text.Trim();
                string brojTelefona = txtBrojTelefona.Text.Trim();

                if (rbPravno.Checked)
                {
                    upit = upit.Where(m => m.JePravnoLice);

                    if (!string.IsNullOrWhiteSpace(prviKriterijum))
                    {
                        upit = upit.Where(m => !string.IsNullOrWhiteSpace(m.NazivPravnogLica) &&
                                               m.NazivPravnogLica.Contains(prviKriterijum, StringComparison.OrdinalIgnoreCase));
                    }

                    if (!string.IsNullOrWhiteSpace(drugiKriterijum))
                    {
                        upit = upit.Where(m => !string.IsNullOrWhiteSpace(m.PIB) &&
                                               m.PIB.Contains(drugiKriterijum, StringComparison.OrdinalIgnoreCase));
                    }
                }
                else
                {
                    upit = upit.Where(m => !m.JePravnoLice);

                    if (!string.IsNullOrWhiteSpace(prviKriterijum))
                    {
                        upit = upit.Where(m => !string.IsNullOrWhiteSpace(m.Ime) &&
                                               m.Ime.Contains(prviKriterijum, StringComparison.OrdinalIgnoreCase));
                    }

                    if (!string.IsNullOrWhiteSpace(drugiKriterijum))
                    {
                        upit = upit.Where(m => !string.IsNullOrWhiteSpace(m.Prezime) &&
                                               m.Prezime.Contains(drugiKriterijum, StringComparison.OrdinalIgnoreCase));
                    }
                }

                if (!string.IsNullOrWhiteSpace(brojTelefona))
                {
                    upit = upit.Where(m => !string.IsNullOrWhiteSpace(m.BrojTelefona) &&
                                           m.BrojTelefona.Contains(brojTelefona, StringComparison.OrdinalIgnoreCase));
                }

                if (cmbGrad.SelectedItem is Grad grad && grad.Id > 0)
                {
                    upit = upit.Where(m => m.Grad != null && m.Grad.Id == grad.Id);
                }

                pronadjeneMusterije = upit.ToList();

                if (pronadjeneMusterije.Count == 0)
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Nema musterija koje odgovaraju zadatom kriterijumu.");
                    return;
                }

                dataGridView1.DataSource = pronadjeneMusterije.Select(m => new
                {
                    m.Id,
                    PrviPodatak = m.JePravnoLice ? m.NazivPravnogLica : m.Ime,
                    DrugiPodatak = m.JePravnoLice ? m.PIB : m.Prezime,
                    m.BrojTelefona,
                    Grad = m.Grad != null ? m.Grad.Naziv : string.Empty
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska pri pretrazi musterija: " + ex.Message);
            }
        }

        private void PripremiGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.HeaderText = "ID";
            colId.DataPropertyName = "Id";
            dataGridView1.Columns.Add(colId);

            DataGridViewTextBoxColumn colPrviPodatak = new DataGridViewTextBoxColumn();
            colPrviPodatak.HeaderText = rbPravno.Checked ? "Naziv" : "Ime";
            colPrviPodatak.DataPropertyName = "PrviPodatak";
            dataGridView1.Columns.Add(colPrviPodatak);

            DataGridViewTextBoxColumn colDrugiPodatak = new DataGridViewTextBoxColumn();
            colDrugiPodatak.HeaderText = rbPravno.Checked ? "PIB" : "Prezime";
            colDrugiPodatak.DataPropertyName = "DrugiPodatak";
            dataGridView1.Columns.Add(colDrugiPodatak);

            DataGridViewTextBoxColumn colTelefon = new DataGridViewTextBoxColumn();
            colTelefon.HeaderText = "Broj telefona";
            colTelefon.DataPropertyName = "BrojTelefona";
            dataGridView1.Columns.Add(colTelefon);

            DataGridViewTextBoxColumn colGrad = new DataGridViewTextBoxColumn();
            colGrad.HeaderText = "Grad";
            colGrad.DataPropertyName = "Grad";
            colGrad.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns.Add(colGrad);
        }

        private void dataGridView1_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= pronadjeneMusterije.Count)
                    return;

                FrmMusterija forma = new FrmMusterija(pronadjeneMusterije[e.RowIndex]);
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    sveMusterije = Communication.Instance.VratiSveMusterije();
                    btnPretrazi_Click(null, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska pri otvaranju musterije: " + ex.Message);
            }
        }
    }
}
