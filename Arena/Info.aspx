<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="Arena.Info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="reg2">
    <h2>Het spel</h2>
    <p>Arena of Legends is een 2d Brawler. Dit houdt in dat je tegen een andere speler vecht.   </p>
     <p>Je begint het spel met een aantal hitpoints en een aantal levens, wanneer je hitpoints op 0 geraken verlies je 1 leven.</p>
     <p>Wanneer je de tegenstander op 0 levens krijgt, win je het spel!
    </p>
        <h2>Score</h2>
     <p>De beste scores worden bij Rankings op deze website getoond.</p>
     <h2>Controls</h2>
       <h3>Bewegen</h3>
        <p>Je kunt naar links en naar rechts bewegen door op de pijltoetsen te drukken.</p>
        <h3>Springen</h3>
        <p>Je kunt springen door de pijltoets naar boven in te drukken.</p>
        <h3>Aanvallen</h3>
        <p>Je kunt een andere speler aanvallen door op de A toets te drukken.</p>
        <h3>Speciale aanval</h3>
        <p>Je kunt een krachtige speciale aanval uitvoeren wanneer je de S toets indrukt. Let op, deze heeft een cooldown!</p>
        <h2>Gemaakt door</h2>
        <ul id ="l">
            <li>Davy Alders</li>
            <li>Rico Clark</li>
            <li>Bart Memelink</li>
            <li>Chris van Gils</li>
            <li>Tjidde Nieuwenhuijzen</li>
        </ul>

        </div>
</asp:Content>
