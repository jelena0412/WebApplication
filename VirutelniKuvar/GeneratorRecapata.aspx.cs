using DataLayer;
using DataLayer.Models;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;

namespace VirutelniKuvar
{
    public partial class GeneratorRecepata : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGenerisi_Click(object sender, EventArgs e)
        {
            string[] unetiSastojci = txtSastojci.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                                     .Select(s => s.Trim().ToLower())
                                                     .ToArray();

            if (unetiSastojci.Length == 0)
            {
                lblRezultati.Text = "Molimo unesite sastojke.";
                gvRezultati.DataSource = null;
                gvRezultati.DataBind();
                return;
            }

            using (var context = new ApplicationDbContext())
            {
                string sastojciParam = string.Join(",", unetiSastojci.Select((s, i) => $"@p{i}"));
                var parametri = unetiSastojci.Select((s, i) => new SqlParameter($"@p{i}", s)).ToArray();
                var brojSastojakaParam = new SqlParameter("@brojSastojaka", unetiSastojci.Length);

                var recepti = context.Database.SqlQuery<ReceptResult>(
                    $@"SELECT r.Naziv, r.Opis, r.Komentar
                      FROM Recepti r
                      JOIN Stavke s ON r.Id = s.id_recepta
                      JOIN Sastojci st ON s.id_sastojka = st.Id
                      WHERE LOWER(st.naziv_sastojka) IN ({sastojciParam})
                      GROUP BY r.Naziv, r.Opis, r.Komentar, r.Id
                      HAVING COUNT(DISTINCT st.Id) = @brojSastojaka",
                    parametri.Concat(new[] { brojSastojakaParam }).ToArray()
                ).ToList();

                if (recepti.Any())
                {
                    gvRezultati.DataSource = recepti;
                    gvRezultati.DataBind();
                    lblRezultati.Text = "";
                }
                else
                {
                    lblRezultati.Text = "Nema rezultata za unete sastojke.";
                    gvRezultati.DataSource = null;
                    gvRezultati.DataBind();
                }
            }
        }
    }
}
