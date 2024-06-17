<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prijava.aspx.cs" Inherits="VirutelniKuvar.Prijava" MasterPageFile="~/Site.Master" %>

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
    <div class="container">
        <div class="content-wrapper">
            <h2>Prijava</h2>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />
            <div class="form-container">
                <div class="form-group">
                    <label for="username">Korisničko ime:</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="Korisničko ime je obavezno." CssClass="text-danger" />
                </div>
                <div class="form-group">
                    <label for="password">Lozinka:</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Lozinka je obavezna." CssClass="text-danger" />
                </div>
                <asp:Button ID="btnPrijava" runat="server" Text="Prijava" CssClass="btn btn-primary btn-crveno" OnClick="btnPrijava_Click" />
                <div class="form-group mt-3">
                    <asp:HyperLink ID="lnkRegistracija" runat="server" NavigateUrl="~/Registracija.aspx" CssClass="crveno">Nemate nalog? Registrujte se</asp:HyperLink>
                </div>
            </div>
        </div>
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
    p {
        background-color: rgba(255, 255, 255, 0.8); 
        padding: 10px; 
        border-radius: 5px; 
        color:white;
    }
    h2 {
        background-color: #000; 
        color: white;
        padding: 10px; 
        border-radius: 5px; 
    }
    .content-wrapper {
        
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        height: 100vh; 
        background-size: cover; 
background-repeat:no-repeat;
    }
    .form-container {
        background-color: rgba(0, 0,0, 0.75); 
       padding: 20px;
        border-radius: 10px;
        width: 300px; 
         margin: auto; 
        margin-top: 5px; 
    }
    .form-group label {
        font-size: 20px; 
        color:white;
    }
    .form-group input[type="text"],
    .form-group input[type="password"] {
        width: 100%;
        height: 40px;
        font-size: 16px; 
        margin-bottom: 10px; 
    }
    .form-group button {
        width: 100%; 
        height: 40px; 
        font-size: 16px; 
    }
    .btn-crveno {
    background-color: darkred; 
    border-color: darkred; 
}

.crveno {
    color: #ff0000; 
}
</style>
</asp:Content>