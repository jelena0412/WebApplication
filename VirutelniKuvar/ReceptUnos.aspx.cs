using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using DataLayer.Models;
using BusinessLayer;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using PresentationLayer;

namespace VirutelniKuvar
{
    public partial class ReceptUnos : System.Web.UI.Page
    {
        private ReceptRepository receptRepository = new ReceptRepository();
        readonly Korisnik korisnik = new Korisnik();
        readonly Sastojak sastojak = new Sastojak();
        readonly Recept recept = new Recept();
        readonly KorisnikBusiness korisnikBusiness = new KorisnikBusiness();
        readonly ReceptBusiness receptBusiness = new ReceptBusiness();
        readonly StavkaBusiness stavkaBusiness = new StavkaBusiness();
        readonly SastojakBusiness sastojakBusiness = new SastojakBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        protected void btnUnesiRecept_Click(object sender, EventArgs e)
        {
            try
            {
                Korisnik k = new Korisnik();
                string korim = UserL.TrenutnoKorisnickoIme;
                string loz = UserL.TrenutnaLozinka;



                if (string.IsNullOrEmpty(korim) || string.IsNullOrEmpty(loz))
                {
                    Response.Write("Greška: Korisničko ime i lozinka su obavezni podaci.");

                    return;
                }

                int idKorisnika = korisnikBusiness.dajIDKorisnika(korim, loz);

                if (idKorisnika <= 0)
                {
                    Response.Write("Greska: Korisnik nije pronadjen");
                    return;
                }

                Recept r = new Recept
                {
                    Naziv = txtNaziv.Text,
                    Opis = txtOpis.Text,
                    Komentar = txtKomentar.Text,
                    Ocena = Convert.ToInt32(txtOcena.Text),
                    Id_korisnika = idKorisnika


                };
                int insertedReceptId = receptBusiness.InsertRecept(r);

                if (insertedReceptId > 0)
                {
                    Recipes.PostaviTrenutniIDRecepta(insertedReceptId);

                    Response.Write("Recept uspešno dodat!");
                    
                }
                else
                {
                    Response.Write("Greška: Umetanje recepta nije uspelo.");
                }


            }
            catch (Exception ex)
            {
                Response.Write("Greška: " + ex.Message);
            }
        }

        protected void btnUnesiSastojak_Click(object sender, EventArgs e)
        {
            try
            {
                Sastojak s = new Sastojak

                {
                    naziv_sastojka = txtNazivSastojka1.Text,
                    mera = txtMera1.Text

                };

                int sastojakID = sastojakBusiness.InsertSastojak(s);

                if (sastojakID > 0)
                {
                    Sastojci.PostaviTrenutniSastojak(sastojakID);

                    if (Recipes.TrenutniIDRecepta > 0)
                    {
                        Stavka st = new Stavka
                        {
                            kolicina = txtKolicina1.Text,
                            id_sastojka = Sastojci.TrenutniIDSastojka,
                            id_recepta = Recipes.TrenutniIDRecepta
                        };
                        stavkaBusiness.InsertStavke(st);
                        txtNazivSastojka1.Text = string.Empty;
                        txtMera1.Text = string.Empty;
                        txtKolicina1.Text = string.Empty;
                        Console.WriteLine("Izbrisano");
                    }
                    else
                    {
                        Response.Write("Greška: Ne postoji validan ID recepta.");
                    }
                }
                else
                {
                    Response.Write("Greška: Neuspešno dodavanje sastojka.");
                }





            }
            catch (Exception ex)
            {
                Response.Write("Greška: " + ex.Message);
            }

        }


    }
}


