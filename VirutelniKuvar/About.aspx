<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="VirutelniKuvar.About" MasterPageFile="~/Site.Master" %>

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
    
    <div class="container mt-4" style="margin-top: 56px;">
        <div class="row">
            <div class="col-sm-12">
                <h1>O nama</h1>
                <p>Virtuelni Kuvar je revolucionarna platforma koja vam omogućava da istražujete, delite i kreirate recepte iz udobnosti vašeg doma. Bez obzira da li ste iskusni kulinarski majstor ili tek početnik, ovo je mesto gde možete pronaći inspiraciju i zajedno sa drugima uživati u magiji kuvanja.</p>
                <p>Naša misija je da olakšamo ljudima da se povežu kroz ljubav prema hrani. Verujemo da je kuvanje više od same pripreme jela – to je umetnost, strast i način izražavanja. Zato smo kreirali zajednicu gde svi mogu da se osećaju dobrodošlo i slobodno da dele svoje kulinarske kreacije.</p>
                <p>Kroz našu platformu možete pristupiti stotinama recepata iz celog sveta, učiti nove tehnike i trikove, i postati deo globalne kulinarske zajednice. Naši recepti su detaljno objašnjeni i prilagođeni svima, od početnika do profesionalaca.</p>
                <p>Osim recepata, nudimo i brojne alate i resurse koji će vam pomoći da unapredite svoje kuvarske veštine. Pronađite savršeni recept za svaku priliku, saznajte nutritivne vrednosti jela, i pratite najnovije trendove u kulinarstvu.</p>
                <p>Pridružite nam se i otkrijte kako kuvanje može biti zabavno i inspirativno. Hvala što ste deo Virtuelnog Kuvara – zajedno činimo kuvanje magičnim!</p>
            </div>
        </div>
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
