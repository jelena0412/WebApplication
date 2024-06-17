<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeneratorRecapata.aspx.cs" Inherits="VirutelniKuvar.GeneratorRecepata" MasterPageFile="~/Site.Master"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="NavigationContent" runat="server">
   
    <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-dark">
        <div class="container">
            <a class="navbar-brand" runat="server" href="~/"><h1>Virtuelni kuvar</h1></a>
            <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" title="Toggle navigation" aria-controls="navbarSupportedContent"
                aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse d-sm-inline-flex justify-content-between">
                <ul class="navbar-nav flex-grow-1">
                    <li class="nav-item"><a class="nav-link" runat="server" href="~/">O nama</a></li>
                    <li class="nav-item">
                        <asp:HyperLink runat="server" NavigateUrl="~/Receptiprikaz.aspx" CssClass="nav-link">Recepti</asp:HyperLink>
                    </li>
                    <li class="nav-item"><a class="nav-link" runat="server" href="~/PretragaRecepta.aspx">Pretraga</a></li>
                    <li class="nav-item"><a class="nav-link" runat="server" href="~/Prijava.aspx">Prijava</a></li>
                    <li class="nav-item"><a class="nav-link" runat="server" href="~/GeneratorRecapata.aspx">Moji sastojci</a></li>
                    <li class="nav-item"><a class="nav-link" runat="server" href="~/Statistika.aspx">Statistika</a></li>
                     <li class="nav-item"><a class="nav-link" runat="server" href="~/Saveti.aspx">Saveti i trikovi</a></li>
                </ul>
            </div>
        </div>
    </nav>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Moji sastojci</h1>
        <p>Unesite sastojke koje imate, odvojene zarezom:</p>
        <asp:TextBox ID="txtSastojci" runat="server" TextMode="MultiLine" Rows="5" Width="300px" Placeholder="Unesite sastojke..."></asp:TextBox>
        <br />
        <asp:Button ID="btnGenerisi" runat="server" Text="Generiši Recept" cssClass="boja" OnClick="btnGenerisi_Click" />
        <br /><br />
        <asp:Label ID="lblRezultati" runat="server" Text=""></asp:Label>
      <asp:GridView ID="gvRezultati" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:TemplateField HeaderText="Naziv Recepta" HeaderStyle-CssClass="header-text-white">
            <ItemTemplate>
                <a href='<%# "PretragaRecepta.aspx?search=" + Eval("Naziv") %>' class="gridview-item" style="color: #ff0000;"><%# Eval("Naziv") %></a>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Opis" HeaderText="Opis" ItemStyle-CssClass="gridview-item"  HeaderStyle-CssClass="header-text-white"/>
        <asp:BoundField DataField="Komentar" HeaderText="Komentar" ItemStyle-CssClass="gridview-item" HeaderStyle-CssClass="header-text-white"/>
    </Columns>
</asp:GridView>


    </div>
          <style>
    
    html, body {
        height: 100%; 
        margin: 0;
        padding: 0; 
        background-image: url('/images/Default.png');
        background-size: cover; 
        background-repeat:no-repeat;
    }
     p, input[type="text"],br{
         
        background-color: rgba(255, 255, 255, 0.8); 
        padding: 10px; 
        border-radius: 5px;
    }
      h2 {
        background-color: #000;
        color: #fff; 
        padding: 10px; 
        border-radius: 5px; 
    }
      .gridview-item {
   background-color: rgba(255, 255, 255, 0.8);
    padding: 10px; 
    border-radius: 5px;
    margin-right: 10px; 

}
      .header-text-white {
    color: #fff; 
     background-color: grey; 
}
     .header-text-white a {
    color: darkred; 
}
     .boja{
         background-color:darkred;
         color:white;
     }
</style>
</asp:Content>
