<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceptUnos.aspx.cs" Inherits="VirutelniKuvar.ReceptUnos" MasterPageFile="~/Site.Master" %>
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
                    <li class="nav-item"><a class="nav-link" runat="server" href="~/Prijava">Prijava</a></li>
                    <li class="nav-item"><a class="nav-link" runat="server" href="~/GeneratorRecapata.aspx">Moji sastojci</a></li>
                    <li class="nav-item"><a class="nav-link" runat="server" href="~/Statistika.aspx">Statistika</a></li>
                     <li class="nav-item"><a class="nav-link" runat="server" href="~/Saveti.aspx">Saveti i trikovi</a></li>
                </ul>
            </div>
        </div>
    </nav>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="text-center mb-4">Unos recepta</h2>
        
        <asp:Panel CssClass="needs-validation" runat="server">
            <div class="form-group mb-3">
                <label for="txtNaziv">Naziv:</label>
                <asp:TextBox ID="txtNaziv" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group mb-3">
                <label for="txtOpis">Opis:</label>
                <asp:TextBox ID="txtOpis" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group mb-3">
                <label for="txtKomentar">Komentar:</label>
                <asp:TextBox ID="txtKomentar" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group mb-3">
                <label for="txtOcena">Ocena:</label>
                <asp:TextBox ID="txtOcena" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group mb-3">
                <label>Sastojci i mere:</label>
                <table class="table table-bordered" id="sastojciTable">
                    <thead class="thead-light">
                        <tr>
                            <th>Naziv Sastojka</th>
                            <th>Mera</th>
                            <th>Količina</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr id="row1">
                            <td><asp:TextBox ID="txtNazivSastojka1" runat="server" CssClass="form-control" /></td>
                            <td><asp:TextBox ID="txtMera1" runat="server" CssClass="form-control" /></td>
                            <td><asp:TextBox ID="txtKolicina1" runat="server" CssClass="form-control" /></td>
                            <td><asp:Button ID="Button1" runat="server" Text="Sledeci" OnClick="btnUnesiSastojak_Click"/></td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <asp:Button ID="btnUnesiRecept" runat="server" Text="Unesi recept" CssClass="btn btn-primary" OnClick="btnUnesiRecept_Click" />
        </asp:Panel>
    </div>


<style>
    body {
        margin: 0; 
        background-image: url('/images/Default.png'); 
        background-size: cover; 
        background-repeat: no-repeat; 
    }

    
    .needs-validation {
        background-color: rgba(255, 255, 255, 0.8); 
        padding: 20px; 
        border-radius: 10px; 
        width: 70%; 
        margin: auto; 
        margin-top: 50px; 
    }

    .btn {
        color: white;
        background-color: black; 
        border: none; 
    }

    td:first-child {
        color: black; 
        width: 60%; 
    }
</style>
</asp:Content>