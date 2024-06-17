using System;
using System.Media;
using System.Web.UI;
using BusinessLayer;
using DataLayer.Models;

namespace VirutelniKuvar
{
    public partial class Prijava : System.Web.UI.Page
    {
        private readonly KorisnikBusiness korisnikBusiness = new KorisnikBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void btnPrijava_Click(object sender, EventArgs e)
        {
            string korisnicko_ime = txtUsername.Text;
            string lozinka = txtPassword.Text;
          
            if (!string.IsNullOrEmpty(korisnicko_ime) && !string.IsNullOrEmpty(lozinka))
            {
                bool uspesnaPrijava = korisnikBusiness.ProveriPrijavu(korisnicko_ime, lozinka);
                UserL.PostaviTrenutnogKorisnika(korisnicko_ime);
                UserL.PostaviTrenutnogKorisnik(lozinka);

                if (uspesnaPrijava)
                {
                    Session["KorisnickoIme"] = korisnicko_ime;

                    ScriptManager.RegisterStartupScript(this, GetType(), "UspesnaPrijava", "alert('Prijava je uspešna.'); window.location='Default.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "NeispravnaPrijava", "alert('Neispravno korisničko ime ili lozinka.');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PraznaPolja", "alert('Unesite korisničko ime i lozinku.');", true);
            }
        }


        protected void btnRegistracija_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registracija.aspx");
        }
    }
}
