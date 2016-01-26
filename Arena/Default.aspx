<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Arena.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id ="reg2">
         <h1>Welkom bij Arena of legends</h1>
        <p>Op deze website kunt u informatie vinden over het spel Arena of Legends. Dit spel is gemaakt door een groep studenten van Fontys Hogeschool voor ICT.</p>
         <div id="slider">

            <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:Timer ID="Timer1" runat="server" Interval="6000" OnTick="Timer1_Tick"></asp:Timer>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" RenderMode="Inline">
                <ContentTemplate>
                    <asp:Image ID="Image1" runat="server"/>
                </ContentTemplate>               
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick"/>
                </Triggers>
            </asp:UpdatePanel>
        </div>
        
      
       <p>Download hier het spel!</p> <asp:Button ID="Button1" runat="server" Text="Download" OnClick="Button1_Click" />
    </div>
   
</asp:Content>
