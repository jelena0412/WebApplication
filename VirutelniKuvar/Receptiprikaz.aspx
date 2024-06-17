<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Receptiprikaz.aspx.cs" Inherits="VirutelniKuvar.Receptiprikaz" MasterPageFile="~/Site.Master" %>

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
                     <li class="nav-item"><a class="nav-link" runat="server" href="~/Receptiprikaz.aspx">Recepti</a></li>
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
    <div class="container">
        <h1>Recepti</h1>
        <div class="table-responsive">
            <asp:Repeater ID="RepeaterRecepti" runat="server">
                <HeaderTemplate>
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>Naziv</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Naziv") %></td>
                        <td>
                            <asp:Button ID="btnDetaljnije" runat="server" Text="Detaljnije" OnClick="PrikaziDetalje" CommandArgument='<%# Eval("Naziv") %>' CssClass="btn btn-primary" />
                            <asp:Panel ID="PanelDetalji" runat="server" Visible="false">
                                <td colspan="2">
                                    <p>Opis: <%# Eval("Opis") %></p>
                                    <p>Komentar: <%# Eval("Komentar") %></p>
                                    <p>Ocena <%# Eval("Ocena") %></p>
                                </td>
                            </asp:Panel>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                        </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
    <style>
         
       html, body {
            margin: 0; 
            padding: 0;
            background-image: url('/images/Default.png'); 
            background-size: cover; 
            background-repeat: no-repeat; 
            height: 100px; 
        }
       
        p {
            background-color: rgba(0, 0, 0, 0.8); 
            padding: 10px; 
            border-radius: 5px;
            color:white;
        }
        h1 {
            color: white;
             background-color: rgba(0, 0, 0, 0.86); 
             text-align: center;
        }
       table {
    background-color: rgba(255, 255, 255, 0.86); 
    font-size: 14px; 
    width: 80%; 
    margin: 0 auto; 
    border-collapse: collapse;
}

th, td {
    color: black; 
    background-color: rgba(255, 255, 255, 0.86); 
    border: 2px solid black; 
    text-align: center;
    padding: 2px 5px; 
}
th {
    width: 60%; 
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


