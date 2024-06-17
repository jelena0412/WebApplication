<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registracija.aspx.cs" Inherits="VirutelniKuvar.Registracija" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NavigationContent" runat="server">
  <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-dark" style="height: 90px;">
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
    <div class="d-flex justify-content-start align-items-center vh-50">

        <div class="container2">
            <h1>Registracija</h1>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />
            <div class="form-group">
                <label for="ime">Ime:</label>
                <asp:TextBox ID="tbIme" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbIme" ErrorMessage="Ime je obavezno." CssClass="text-danger" />
            </div>
            <div class="form-group">
                <label for="prezime">Prezime:</label>
                <asp:TextBox ID="tbPrezime" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbPrezime" ErrorMessage="Prezime je obavezno." CssClass="text-danger" />
            </div>
            <div class="form-group">
                <label for="korisnickoIme">Korisničko ime:</label>
                <asp:TextBox ID="tbKorisnickoIme" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbKorisnickoIme" ErrorMessage="Korisničko ime je obavezno." CssClass="text-danger" />
            </div>
            <div class="form-group">
                <label for="lozinka">Lozinka:</label>
                <asp:TextBox ID="tbLozinka" runat="server" CssClass="form-control" TextMode="Password" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbLozinka" ErrorMessage="Lozinka je obavezna." CssClass="text-danger" />
            </div>
            <div class="form-group">
                <label for="potvrdaLozinke">Potvrda lozinke:</label>
                <asp:TextBox ID="tbPotvrdaLozinke" runat="server" CssClass="form-control" TextMode="Password" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbPotvrdaLozinke" ErrorMessage="Potvrda lozinke je obavezna." CssClass="text-danger" />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="tbPotvrdaLozinke" ControlToCompare="tbLozinka" ErrorMessage="Lozinke se ne poklapaju." CssClass="text-danger" />
            </div>
            <div class="form-group">
                <label for="email">Email:</label>
                <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbEmail" ErrorMessage="Email je obavezan." CssClass="text-danger" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbEmail" ErrorMessage="Neispravan format email adrese." CssClass="text-danger" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" />
            </div>
            <div class="form-group">
                <label for="brojTelefona">Broj telefona:</label>
                <asp:TextBox ID="tbBrojTelefona" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbBrojTelefona" ErrorMessage="Broj telefona je obavezan." CssClass="text-danger" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbBrojTelefona" ErrorMessage="Broj telefona mora imati 10 cifara." CssClass="text-danger" ValidationExpression="^\d{10}$" />
            </div>
            <asp:Button ID="btnRegistrujSe" runat="server" Text="Registruj se" CssClass="btn btn-primary" OnClick="btnRegistrujSe_Click"/>
            <div class="form-group mt-3">
                <asp:HyperLink ID="lnkPrijava" runat="server" NavigateUrl="~/Prijava.aspx">Već imate nalog? Prijavite se</asp:HyperLink>
            </div>
        </div>
    </div>
    <style>
        html, body {
            
            margin: 0; 
            padding: 0; 
            background-image: url('/images/Default.png'); 
            background-size: cover; 
            background-repeat:no-repeat;
            height: 100%; 
        }
       
        .d-flex {
            display: flex;
        }
        .justify-content-center {
            justify-content: center;
        }
        .align-items-center {
            align-items: center;
        }
        .vh-100 {
            height: 100vh;
        }
        .container {
           
            padding: 20px; 
            border-radius: 5px; 
            width: 100%; 
            max-width: 1300px; 
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); 
        }
        .container2 {
        background-color: rgba(255, 255, 255, 0.8); 
        padding: 20px; 
        border-radius: 5px; 
        width: 100%; 
        max-width: 500px; 
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); 
}
        h1, p {
            text-align: center; 
        }
        .form-group label {
            display: block; 
            margin-bottom: 5px; 
            font-weight: bold; 
        }
        .form-group {
            margin-bottom: 15px; 
        }
        .btn {
            width: 100%; 
        }
        .form-group.mt-3 {
            text-align: center; 
        }
         .navbar-brand {
            margin-right: 20px; 
            font-size: 24px; 
            font-weight: bold; 
            color: white; 
        }
        .navbar-nav .nav-item .nav-link {
            color: rgba(255, 255, 255, 0.8); 
        }
    </style>
</asp:Content>