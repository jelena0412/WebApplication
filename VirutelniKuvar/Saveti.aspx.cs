using System;
using System.Web.UI;

namespace VirutelniKuvar
{
    public partial class Saveti : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblPoruka.Text = "";
            }
        }

        protected void btnGlasaj_Click(object sender, EventArgs e)
        {
            
            lblPoruka.Text = "Hvala što ste glasali!";

            rblOdgovori.ClearSelection();
            rblDrugoPitanje.ClearSelection();
        }
    }
}
