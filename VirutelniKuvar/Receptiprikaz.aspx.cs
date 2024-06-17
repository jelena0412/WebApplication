using BusinessLayer;
using System;
using System.Web.UI.WebControls;

namespace VirutelniKuvar
{
    public partial class Receptiprikaz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRecepti();
            }
        }

        private void LoadRecepti()
        {
            ReceptBusiness receptBusiness = new ReceptBusiness();
            var recepti = receptBusiness.GetAllRecepti();
            RepeaterRecepti.DataSource = recepti;
            RepeaterRecepti.DataBind();
        }
        protected void RedirectToUnosRecepta(object sender, EventArgs e)
        {
            Response.Redirect("~/ReceptUnos.aspx");
        }

        protected void PrikaziDetalje(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            Panel panelDetalji = (Panel)item.FindControl("PanelDetalji");

            if (panelDetalji != null)
            {
                panelDetalji.Visible = !panelDetalji.Visible;
            }
        }
        
    }
}
