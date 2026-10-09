using Common.Communication;
using Common.Domain;

namespace Client
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            txtSifra.PasswordChar = '*';
            txtKorIme.Text = "mijat";
            txtSifra.Text = "12345";

            try
            {
                Communication.Instance.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ne mogu da se povežem na server: " + ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtKorIme.Text) ||
                    string.IsNullOrWhiteSpace(txtSifra.Text))
                {
                    MessageBox.Show("Unesite korisničko ime i šifru.");
                    return;
                }

                Prodavac p = new Prodavac
                {
                    KorisnickoIme = txtKorIme.Text.Trim(),
                    Sifra = txtSifra.Text.Trim()
                };

                Response response = Communication.Instance.LoginProdavac(p);

                if (response.ExceptionMessage != null)
                {
                    MessageBox.Show(response.ExceptionMessage);
                    return;
                }

                Prodavac ulogovani = (Prodavac)response.Result;

                if (ulogovani == null)
                {
                    MessageBox.Show("Neispravno korisničko ime ili šifra.");
                    return;
                }

                // ✔ uspešan login
                FrmMain main = new FrmMain(ulogovani);
                this.Hide();
                main.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom logina: " + ex.Message);
            }
        }

    }
}
