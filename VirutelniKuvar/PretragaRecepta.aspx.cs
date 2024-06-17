using System;
using System.Web.UI;
using BusinessLayer;
using DataLayer.Models;
using System.Collections.Generic;

namespace VirutelniKuvar
{
    public partial class PretragaRecepta : System.Web.UI.Page
    {
        private readonly ReceptBusiness receptBusiness = new ReceptBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string nazivRecepta = Request.QueryString["search"];
                if (!string.IsNullOrEmpty(nazivRecepta))
                {
                    txtNazivRecepta.Text = nazivRecepta;
                    PretragaRecepata(nazivRecepta);
                }
            }
        }

        protected void btnPretraga_Click(object sender, EventArgs e)
        {
            string nazivRecepta = txtNazivRecepta.Text;

            if (!string.IsNullOrEmpty(nazivRecepta))
            {
                PretragaRecepata(nazivRecepta);
            }
            else
            {
                gvRecepti.DataSource = null;
                gvRecepti.DataBind();
            }
        }

        private void PretragaRecepata(string nazivRecepta)
        {
            List<Recept> recepti = receptBusiness.PretragaRecepataPoNazivu(nazivRecepta);
            gvRecepti.DataSource = recepti;
            gvRecepti.DataBind();
        }
    }
}
