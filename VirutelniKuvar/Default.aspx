<%@ Page Title="Početna stranica" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VirutelniKuvar.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
       
        <section class="row" aria-labelledby="pageTitle">
            
            <p class="lead">Dobrodošli na Virtuelni Kuvar - vašu kulinarsku destinaciju za inspiraciju, deljenje i kreiranje recepata!</p>
           
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="exploreTitle">
                <h2 id="exploreTitle">Pretražite</h2>
                <p>
                    Pretražite našu obilnu biblioteku recepata iz celog sveta i pronađite nove ideje za kulinarske poduhvate.
                </p>
                <p>
                    <a class="btn btn-default" href="PretragaRecepta.aspx">Pretražite recepte &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="shareTitle">
                <h2 id="shareTitle">Registrujte se</h2>
                <p>
                    Registrujte se kako biste imali pristup svim funkcijama naše platforme.
                </p>
                <p>
                    <a class="btn btn-default" href="Registracija.aspx">Registrujte se &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="createTitle">
                <h2 id="createTitle">Kreirajte</h2>
                <p>
                    Kreirajte svoje recepte, dodajte slike i podelite svoje kulinarsko umeće sa svetom putem Virtuelnog Kuvara.
                </p>
                <p>
                    <a class="btn btn-default" href="ReceptUnos.aspx">Kreirajte recept &raquo;</a>
                </p>
            </section>
        </div>
    </main>
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
        }
          h2 {
            background-color: #000; 
            color: #fff;
            padding: 10px; 
            border-radius: 5px; 
        }
    </style>
</asp:Content>
