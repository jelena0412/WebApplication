using System;
using System.Web.UI;
using BusinessLayer;
using DataLayer.Models;

namespace VirutelniKuvar
{
    public partial class Registracija : System.Web.UI.Page
    {
        private readonly KorisnikBusiness korisnikBusiness = new KorisnikBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegistrujSe_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (tbLozinka.Text != tbPotvrdaLozinke.Text)
                {
                    Response.Write("<script>alert('Lozinke se ne poklapaju.');</script>");
                }
                else
                {
                    Korisnik k = new Korisnik
                    {
                        ime = tbIme.Text,
                        prezime = tbPrezime.Text,
                        korisnicko_ime = tbKorisnickoIme.Text,
                        lozinka = tbLozinka.Text,
                        mejl = tbEmail.Text,
                        broj_telefona = tbBrojTelefona.Text
                    };

                    korisnikBusiness.InsertUser(k);
                    Response.Write("<script>alert('Registracija je uspesna!');</script>");

                    tbIme.Text = "";
                    tbPrezime.Text = "";
                    tbKorisnickoIme.Text = "";
                    tbLozinka.Text = "";
                    tbPotvrdaLozinke.Text = "";
                    tbEmail.Text = "";
                    tbBrojTelefona.Text = "";

                    Response.Redirect("~/Prijava.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Sva polja moraju biti popunjena!');</script>");
            }
        }

    }
}
