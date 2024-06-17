<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Statistika.aspx.cs" Inherits="VirutelniKuvar.Statistika" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Statistika</h2>
    <asp:Literal ID="LiteralStatistika" runat="server"></asp:Literal>

    <div class="chart-container" style="display: flex; justify-content: center;">
      
        <div style="max-width: 400px; margin: 0 10px;">
            <h3 style="text-align: center;">Broj registrovanih korisnika</h3>
            <canvas id="chartBrojKorisnika" width="400" height="250"></canvas>
        </div>

     
        <div class="chart-container" style="max-width: 400px; margin: 0 10px;">
            <h3 style="text-align: center;">Prosečna ocena recepata</h3>
            <canvas id="chartProsecnaOcena" width="400" height="250"></canvas>
        </div>

        
        <div  class="chart-container3"style="max-width: 400px; margin: 0 10px;">
            <h3 style="text-align: center;">Najpopularniji recepti</h3>
            <canvas id="chartNajpopularnijiRecepti" width="400" height="250"></canvas>
        </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script>
        document.addEventListener('DOMContentLoaded', function () {
            
            var brojKorisnika = <%= GetBrojRegistrovanihKorisnika() %>;
            var prosecnaOcena = <%= GetProsecnaOcenaRecepata() %>;
            var najpopularnijiRecepti = <%= Newtonsoft.Json.JsonConvert.SerializeObject(GetNajpopularnijiRecepti()) %>;

           
            var ctxBrojKorisnika = document.getElementById('chartBrojKorisnika').getContext('2d');
            var chartBrojKorisnika = new Chart(ctxBrojKorisnika, {
                type: 'bar',
                data: {
                    labels: ['Broj korisnika'],
                    datasets: [{
                        label: 'Broj registrovanih korisnika',
                        data: [brojKorisnika],
                        backgroundColor: 'rgba(255, 99, 132, 0.2)',
                        borderColor: 'rgba(255, 99, 132, 1)',
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    },
                }
            });

           
            var ctxProsecnaOcena = document.getElementById('chartProsecnaOcena').getContext('2d');
            var chartProsecnaOcena = new Chart(ctxProsecnaOcena, {
                type: 'pie',
                data: {
                    labels: ['Prosečna ocena'],
                    datasets: [{
                        label: 'Prosečna ocena recepata',
                        data: [prosecnaOcena, 5 - prosecnaOcena], 
                        backgroundColor: [
                            'rgba(54, 162, 235, 0.2)',
                            'rgba(255, 206, 86, 0.2)'
                        ],
                        borderColor: [
                            'rgba(54, 162, 235, 1)',
                            'rgba(255, 206, 86, 1)'
                        ],
                        borderWidth: 1
                    }]
                },
            });

         
            var ctxNajpopularnijiRecepti = document.getElementById('chartNajpopularnijiRecepti').getContext('2d');
            var chartNajpopularnijiRecepti = new Chart(ctxNajpopularnijiRecepti, {
                type: 'doughnut',
                data: {
                    labels: najpopularnijiRecepti,
                    datasets: [{
                        label: 'Najpopularniji recepti',
                        data: najpopularnijiRecepti.map(() => 1), 
                        backgroundColor: najpopularnijiRecepti.map((_, i) => `rgba(${i * 50 % 255}, ${(i * 100) % 255}, ${(i * 150) % 255}, 0.2)`),
                        borderColor: najpopularnijiRecepti.map((_, i) => `rgba(${i * 50 % 255}, ${(i * 100) % 255}, ${(i * 150) % 255}, 1)`),
                        borderWidth: 1
                    }]
                },
            });
        });
    </script>
    <style>
        html, body {
            height: 100%;
            margin: 0;
            padding: 0;
            background-image: url('/images/Default.png');
            background-size: cover; 
            background-repeat: no-repeat;
        }
        .chart-container {
        background-color: rgba(255, 255, 255, 0.8);
        border-radius: 10px; 
        padding: 20px; 
    }
        .chart-container3{
            margin-left:1px;
        }
    </style>
</asp:Content>
