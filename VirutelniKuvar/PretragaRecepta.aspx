<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PretragaRecepta.aspx.cs" Inherits="VirutelniKuvar.PretragaRecepta" MasterPageFile="~/Site.Master" %>

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
    <div class="container mt-5 " >
        <h1>Pretraga recepata</h1>
        <div class="form-group">
            <label for="txtNazivRecepta">Naziv recepta:</label>
            <asp:TextBox ID="txtNazivRecepta" runat="server" CssClass="form-control" />
        </div>
        <asp:Button ID="btnPretraga" runat="server" Text="Pretraži" CssClass="btn btn-primary mt-2" OnClick="btnPretraga_Click" />
        <asp:GridView ID="gvRecepti" runat="server" CssClass="table table-striped mt-4" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Naziv" HeaderText="Naziv" />
                <asp:BoundField DataField="Opis" HeaderText="Opis" />
                <asp:BoundField DataField="Ocena" HeaderText="Ocena" />
                <asp:BoundField DataField="Komentar" HeaderText="Komentar" />
                <asp:TemplateField HeaderText="Sastojci">
                    <ItemTemplate>
                        <ul>
                            <asp:Repeater ID="rptSastojci" runat="server" DataSource='<%# Eval("Stavka") %>'>
                                <ItemTemplate>
                                    <li>
                                        <%# Eval("Sastojak.naziv_sastojka") %> - <%# Eval("kolicina") %> <%# Eval("Sastojak.mera") %>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </ItemTemplate>
                </asp:TemplateField>
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
     p, col{
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
      .table {
    background-color: rgba(255, 255, 255, 0.8);
    border-radius: 5px; 
    padding: 10px; 
}

.table th {
    background-color: #808080; 
    color: white;
}

.table td {
    background-color: #f8f9fa; 
}

.table-striped tbody tr:nth-of-type(odd) {
    background-color: #808080;
}

.table-striped tbody tr:nth-of-type(even) {
    background-color: white; 
}
</style>
</asp:Content>
