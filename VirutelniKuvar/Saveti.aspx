<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Saveti.aspx.cs" Inherits="VirutelniKuvar.Saveti" MasterPageFile="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NavigationContent" runat="server">
  
    <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-dark" style="height: 56px;">
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
    <h1>Saveti i Trikovi</h1>
     <div style="background-color: rgba(255, 255, 255, 0.8); padding: 10px; border-radius: 5px;color:darkred">
        

        <p>Ovde možete pronaći korisne savete i trikove vezane za kuvanje i pripremu hrane.</p>
        <ul>
            <li>Koristite oštar nož za lakše seckanje povrća.</li>
            <li>Prethodno zagrejte tiganj pre dodavanja ulja za brže prženje.</li>
            <li>Čuvajte svežu peršunovu travu u čaši vode u frižideru kako bi duže ostala sveža.</li>
        </ul>
         </div>
        <h1>Anketa</h1>
           <div style="background-color: rgba(255, 255, 255, 0.8); padding: 10px; border-radius: 5px;color:darkred">
        
        <asp:Label ID="lblAnketa" runat="server" Text="Koliko često koristite recepte sa ove stranice?"></asp:Label>
        <asp:RadioButtonList ID="rblOdgovori" runat="server">
            <asp:ListItem Text="Svaki dan"></asp:ListItem>
            <asp:ListItem Text="Nekoliko puta nedeljno"></asp:ListItem>
            <asp:ListItem Text="Nekoliko puta mesečno"></asp:ListItem>
            <asp:ListItem Text="Retko"></asp:ListItem>
        </asp:RadioButtonList>
               </div>
           <div style="background-color: rgba(255, 255, 255, 0.8); padding: 10px; border-radius: 5px; color:darkred">
        <asp:Label ID="lblDrugoPitanje" runat="server" Text="Koje vrste recepata vas najviše zanimaju?"></asp:Label>
        <asp:RadioButtonList ID="rblDrugoPitanje" runat="server">
            <asp:ListItem Text="Predjela"></asp:ListItem>
            <asp:ListItem Text="Glavna jela"></asp:ListItem>
            <asp:ListItem Text="Deserti"></asp:ListItem>
            <asp:ListItem Text="Salate"></asp:ListItem>
        </asp:RadioButtonList>
               </div>
        <br />
        <asp:Button ID="btnGlasaj" runat="server" Text="Glasaj" OnClick="btnGlasaj_Click" AutoPostBack="True" />

        <asp:Label ID="lblPoruka" runat="server" Text=""></asp:Label>
    </div>
     <style>
     html, body {
         margin: 0; 
         padding: 0; 
         background-image: url('/images/Default.png');
         background-size: cover;
         background-repeat: no-repeat; 
         min-height: 100vh; 
     }
    
     p {
         background-color: rgba(255, 255, 255, 0.8);
         padding: 10px; 
         border-radius: 5px; 
     }
     h1 {
         color: #fff; 
     }
     
         </style>
</asp:Content>
