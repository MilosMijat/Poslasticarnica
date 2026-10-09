using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmPorudzbina : Form
    {
        private readonly Prodavac? ulogovaniProdavac;
        private int kreiranaPorudzbinaId;
        private int porudzbinaId;
        private readonly Porudzbina? porudzbinaZaIzmenu;
        private readonly bool editMode;
        private List<Poslastica> svePoslastice = new List<Poslastica>();
        private readonly BindingList<StavkaPorudzbine> stavke = new BindingList<StavkaPorudzbine>();

        public FrmPorudzbina(Prodavac? prodavac)
        {
            InitializeComponent();
            ulogovaniProdavac = prodavac;
            txtAdresa.Enabled = false;
            radioButton1.Checked = true;
            groupBox3.Enabled = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = stavke;
            dataGridView1.Columns.Clear();

            DataGridViewTextBoxColumn colNaziv = new DataGridViewTextBoxColumn();
            colNaziv.HeaderText = "Poslastica";
            colNaziv.DataPropertyName = "Poslastica"; // vezujemo objekat
            colNaziv.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns.Add(colNaziv);

            DataGridViewTextBoxColumn colKolicina = new DataGridViewTextBoxColumn();
            colKolicina.HeaderText = "Količina";
            colKolicina.DataPropertyName = "Kolicina";

            dataGridView1.Columns.Add(colKolicina);

            DataGridViewTextBoxColumn colIznos = new DataGridViewTextBoxColumn();
            colIznos.HeaderText = "Iznos";
            colIznos.DataPropertyName = "Iznos";

            dataGridView1.Columns.Add(colIznos);
        }

        public FrmPorudzbina(Porudzbina porudzbina) : this(porudzbina?.Prodavac)
        {
            porudzbinaZaIzmenu = porudzbina ?? throw new ArgumentNullException(nameof(porudzbina));
            editMode = true;
        }

        private void FrmPorudzbina_Load(object sender, EventArgs e)
        {
            try
            {
                List<Prodavac> prodavci = Communication.Instance.VratiSveProdavce();
                cmbProdavac.DataSource = prodavci;

                cmbProdavac.DisplayMember = "ImePrezime"; // ili "Ime" / "Prezime" ako imaš
                cmbProdavac.ValueMember = "Id";

                List<Musterija> musterije = Communication.Instance.VratiSveMusterije();
                cmbMusterija.DataSource = musterije;

                // Najbolje: u Musterija override ToString() => "Ime Prezime"
                cmbMusterija.DisplayMember = "ImePrezime"; // ili ostavi prazno i koristi ToString
                cmbMusterija.ValueMember = "Id";

                if (ulogovaniProdavac != null && !editMode)
                {
                    cmbProdavac.SelectedValue = ulogovaniProdavac.Id;
                }

                if (editMode)
                {
                    UcitajPoslastice();
                    PopuniFormuZaIzmenu();
                }
            }
            catch (Exception)
            {
                txtAdresa.Enabled = checkBox1.Checked;
                if (!checkBox1.Checked)
                    txtAdresa.Text = "";
            }
        }

        private void PopuniFormuZaIzmenu()
        {
            if (porudzbinaZaIzmenu == null)
                return;

            txtDatum.Text = porudzbinaZaIzmenu.Datum.ToString("dd.MM.yyyy.");
            cmbProdavac.SelectedValue = porudzbinaZaIzmenu.Prodavac.Id;
            cmbMusterija.SelectedValue = porudzbinaZaIzmenu.Musterija.Id;
            txtUkIznos.Text = porudzbinaZaIzmenu.UkupanIznos.ToString("0.00");
            lblID.Text = porudzbinaZaIzmenu.Id.ToString();

            porudzbinaId = porudzbinaZaIzmenu.Id;
            kreiranaPorudzbinaId = porudzbinaZaIzmenu.Id;
            groupBox3.Enabled = true;
            btnKreiraj.Enabled = false;
            btnKreiraj.Text = "Porudžbina učitana";
            btnSacuvaj.Enabled = true;
            btnSacuvaj.Text = "Sačuvaj izmene";

            bool imaDostavu = !string.IsNullOrWhiteSpace(porudzbinaZaIzmenu.AdresaZaDostavu);
            checkBox1.Checked = imaDostavu;
            txtAdresa.Text = porudzbinaZaIzmenu.AdresaZaDostavu ?? string.Empty;
            txtAdresa.Enabled = imaDostavu;

            radioButton1.Checked = porudzbinaZaIzmenu.NacinPlacanja == "Kes";
            radioButton2.Checked = porudzbinaZaIzmenu.NacinPlacanja == "Kartica";

            UcitajStavkeZaPostojecuPorudzbinu();
            PripremiStavkeUI();
        }

        private void UcitajStavkeZaPostojecuPorudzbinu()
        {
            if (porudzbinaZaIzmenu == null)
                return;

            stavke.Clear();

            Porudzbina zahtev = new Porudzbina
            {
                Id = porudzbinaZaIzmenu.Id,
                Prodavac = porudzbinaZaIzmenu.Prodavac,
                Musterija = porudzbinaZaIzmenu.Musterija
            };

            List<StavkaPorudzbine> postojeceStavke = Communication.Instance.VratiStavkePorudzbine(zahtev);
            if (postojeceStavke == null)
                return;

            foreach (StavkaPorudzbine stavka in postojeceStavke)
            {
                stavke.Add(stavka);
            }

            AzurirajUkupanIznos();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtAdresa.Enabled = !txtAdresa.Enabled;
        }

        private void btnKreiraj_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TryProcitajPorudzbinuSaForme(out Porudzbina porudzbina))
                {
                    return;
                }

                if (editMode)
                {
                    Communication.Instance.AzurirajUkupanIznosPorudzbine(porudzbina);
                    txtUkIznos.Text = porudzbina.UkupanIznos.ToString("0.00");
                    MessageBox.Show("Izmene porudžbine su sačuvane.");
                    return;
                }

                // 5) Poziv servera -> vraća ID
                int id = Communication.Instance.KreirajPorudzbinu(porudzbina);

                if (id <= 0)
                {
                    MessageBox.Show("Porudžbina nije kreirana.");
                    return;
                }

                kreiranaPorudzbinaId = id;

                // 6) Enable stavke i upiši ID
                groupBox3.Enabled = true;
                lblID.Text = id.ToString();

                porudzbinaId = id;
                UcitajPoslastice();
                //OsveziGridIUkupanIznos();
                PripremiStavkeUI();

                MessageBox.Show($"Porudžbina uspešno kreirana.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri kreiranju porudžbine: " + ex.Message);
            }
        }

        private void PripremiStavkeUI()
        {
            // default vrednosti
            txtKolicina.Text = "1";
            txtCena.Text = "0";
            txtIznos.Text = "0";

            // ako postoji bar jedna poslastica, setuj cenu za prvu
            if (cmbPoslastica.SelectedItem != null)
                PostaviCenuIIznos();
        }

        //private void OsveziGridIUkupanIznos()
        //{
        //    // Uzmi sve stavke iz baze za ovu porudžbinu
        //    Porudzbina p = new Porudzbina { Id = porudzbinaId, Prodavac = new Prodavac(), Musterija = new Musterija { Grad = new Grad() } };
        //    var stavke = Communication.Instance.VratiStavkePorudzbine(p);
        //    stavke ??= new List<StavkaPorudzbine>();

        //    // Prikaz u gridu (ne prikazuj cele objekte)
        //    dataGridView1.AutoGenerateColumns = true;
        //    dataGridView1.DataSource = stavke.Select(s => new
        //    {
        //        Poslastica = s.Poslastica?.Naziv,
        //        Kolicina = s.Kolicina,
        //        Cena = s.Iznos,
        //        Iznos = s.Iznos * s.Kolicina
        //    }).ToList();

        //    // Ukupan iznos
        //    AzurirajUkupanIznos();

        //    // (opciono) ažuriraj porudžbinu ukupan iznos u bazi – ako imaš SO za update
        //    // Communication.Instance.AzurirajUkupanIznos(porudzbinaId, uk);
        //}

        private void UcitajPoslastice()
        {
            svePoslastice = Communication.Instance.VratiSvePoslastice();
            cmbPoslastica.DataSource = svePoslastice;

            // koristi tvoj display property ako ga imaš; u suprotnom "Naziv"
            cmbPoslastica.DisplayMember = "Naziv";
            cmbPoslastica.ValueMember = "Id";
        }

        private void cmbPoslastica_SelectedIndexChanged(object sender, EventArgs e)
        {
            PostaviCenuIIznos();
        }

        private void PostaviCenuIIznos()
        {
            if (cmbPoslastica.SelectedItem is not Poslastica poslastica)
                return;

            // cena iz poslastice
            double cena = poslastica.Cena;

            // količina (fallback 1)
            int kolicina = 1;
            if (int.TryParse(txtKolicina.Text.Trim(), out int k))
                kolicina = Math.Max(1, k);

            double iznos = cena * kolicina;

            txtCena.Text = cena.ToString("0.00");
            txtIznos.Text = iznos.ToString("0.00");
        }

        private void txtKolicina_TextChanged(object sender, EventArgs e)
        {
            // dozvoli samo broj i validiraj > 0
            if (!int.TryParse(txtKolicina.Text.Trim(), out int kolicina))
            {
                // ako je prazno, ne diraj još (npr. user briše)
                if (string.IsNullOrWhiteSpace(txtKolicina.Text))
                    return;

                MessageBox.Show("Količina mora biti ceo broj.");
                txtKolicina.Text = "1";
                txtKolicina.SelectionStart = txtKolicina.Text.Length;
                return;
            }

            if (kolicina <= 0)
            {
                MessageBox.Show("Količina mora biti veća od 0.");
                txtKolicina.Text = "1";
                txtKolicina.SelectionStart = txtKolicina.Text.Length;
                return;
            }

            PostaviCenuIIznos();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                if (porudzbinaId <= 0)
                {
                    MessageBox.Show("Prvo morate kreirati porudžbinu.");
                    return;
                }

                if (cmbPoslastica.SelectedItem is not Poslastica poslastica)
                {
                    MessageBox.Show("Izaberite poslasticu.");
                    return;
                }

                if (!int.TryParse(txtKolicina.Text.Trim(), out int kolicina) || kolicina <= 0)
                {
                    MessageBox.Show("Količina mora biti veća od 0.");
                    return;
                }

                double cena = poslastica.Cena; // ako je poslastica.Cena double, ovo je safe

                // (opciono) Ako hoćeš da spajaš iste poslastice umesto da pravi duplikate:
                // var postojeca = stavke.FirstOrDefault(s => s.Poslastica.Id == poslastica.Id);
                // if (postojeca != null) { postojeca.Kolicina += kolicina; dataGridView1.Refresh(); ... }

                StavkaPorudzbine sp = new StavkaPorudzbine
                {
                    Kolicina = kolicina,
                    Iznos = cena * kolicina, // ✅ ovo je "cena u trenutku kupovine"
                    Porudzbina = new Porudzbina { Id = porudzbinaId, Prodavac = (Prodavac)cmbProdavac.SelectedItem, Musterija = (Musterija)cmbMusterija.SelectedItem },
                    Poslastica = poslastica
                };

                stavke.Add(sp);

                AzurirajUkupanIznos();

                // reset
                txtKolicina.Text = "1";
                PostaviCenuIIznos();
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri dodavanju stavke: " + ex.Message);
            }
        }

        private void AzurirajUkupanIznos()
        {
            double uk = stavke.Sum(s => s.Iznos);
            txtUkIznos.Text = uk.ToString("0.00");
        }

        private bool TryProcitajPorudzbinuSaForme(out Porudzbina porudzbina)
        {
            porudzbina = null;

            if (cmbProdavac.SelectedItem == null)
            {
                MessageBox.Show("Izaberite prodavca.");
                return false;
            }

            if (cmbMusterija.SelectedItem == null)
            {
                MessageBox.Show("Izaberite mušteriju.");
                return false;
            }

            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Izaberite način plaćanja (Keš/Kartica).");
                return false;
            }

            if (!DateTime.TryParseExact(
                    txtDatum.Text.Trim(),
                    "dd.MM.yyyy.",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime datum))
            {
                MessageBox.Show("Datum mora biti u formatu dd.MM.yyyy.");
                return false;
            }

            string nacinPlacanja = radioButton1.Checked ? "Kes" : "Kartica";
            string adresa = checkBox1.Checked && !string.IsNullOrWhiteSpace(txtAdresa.Text)
                ? txtAdresa.Text.Trim()
                : null;

            double ukupanIznos = stavke.Count > 0 ? stavke.Sum(s => s.Iznos) : 0;
            if (editMode && porudzbinaZaIzmenu != null && stavke.Count == 0)
            {
                ukupanIznos = porudzbinaZaIzmenu.UkupanIznos;
            }

            porudzbina = new Porudzbina
            {
                Id = porudzbinaId,
                Datum = datum,
                UkupanIznos = ukupanIznos,
                NacinPlacanja = nacinPlacanja,
                AdresaZaDostavu = adresa,
                Prodavac = (Prodavac)cmbProdavac.SelectedItem,
                Musterija = (Musterija)cmbMusterija.SelectedItem
            };

            return true;
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            try
            {
                if (editMode)
                {
                    if (!TryProcitajPorudzbinuSaForme(out Porudzbina izmenjenaPorudzbina))
                    {
                        return;
                    }

                    List<StavkaPorudzbine> izmenjeneStavke = stavke.Select(s => new StavkaPorudzbine
                    {
                        Kolicina = s.Kolicina,
                        Iznos = s.Iznos,
                        Poslastica = s.Poslastica,
                        Porudzbina = new Porudzbina
                        {
                            Id = izmenjenaPorudzbina.Id,
                            Prodavac = izmenjenaPorudzbina.Prodavac,
                            Musterija = izmenjenaPorudzbina.Musterija
                        }
                    }).ToList();

                    izmenjenaPorudzbina.UkupanIznos = izmenjeneStavke.Sum(s => s.Iznos);
                    izmenjenaPorudzbina.Stavke = izmenjeneStavke;

                    Communication.Instance.SacuvajIzmenePorudzbine(izmenjenaPorudzbina);
                    txtUkIznos.Text = izmenjenaPorudzbina.UkupanIznos.ToString("0.00");
                    MessageBox.Show("Porudžbina i stavke su uspešno sačuvane.");
                    return;
                }

                if (porudzbinaId <= 0)
                {
                    MessageBox.Show("Prvo morate kreirati porudžbinu.");
                    return;
                }

                if (stavke.Count == 0)
                {
                    MessageBox.Show("Nema stavki za čuvanje.");
                    return;
                }

                double ukupno = stavke.Sum(s => s.Iznos);

                // Snimi sve stavke odjednom samo za novu porudžbinu.
                Communication.Instance.SacuvajStavkePorudzbine(stavke.ToList());

                if (!TryProcitajPorudzbinuSaForme(out Porudzbina p))
                {
                    return;
                }
                p.UkupanIznos = ukupno;

                Communication.Instance.AzurirajUkupanIznosPorudzbine(p);

                txtUkIznos.Text = ukupno.ToString("0.00");
                MessageBox.Show("Stavke su sačuvane i ukupan iznos je ažuriran.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri čuvanju stavki: " + ex.Message);
            }
        }

        private void btnobrisi_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Izaberite stavku za brisanje.");
                    return;
                }

                // ako DataSource = BindingList<StavkaPorudzbine>
                var selected = dataGridView1.CurrentRow.DataBoundItem as StavkaPorudzbine;
                if (selected == null)
                {
                    MessageBox.Show("Ne mogu da pročitam selektovanu stavku.");
                    return;
                }

                stavke.Remove(selected);
                AzurirajUkupanIznos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri brisanju stavke: " + ex.Message);
            }
        }
    }
}
