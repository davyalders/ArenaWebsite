<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Ranking.aspx.cs" Inherits="Arena.Ranking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Main.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id ="wrap">
       
    <div id="reg4">
            <asp:GridView runat="server" AutoGenerateColumns="false" ID="gridView1" CssClass="DDGridView">
       <Columns>
        <asp:BoundField HeaderText="Rank" DataField="Rank" />
        <asp:BoundField HeaderText="Username" DataField="Username" />
      </Columns>
        </asp:GridView>
    </div>

   <div id="reg5">
    <asp:GridView runat="server" AutoGenerateColumns="false" ID="gridView2" CssClass="DDGridView">
        <Columns>
        <asp:BoundField HeaderText="Kills" DataField="Kills" />
        <asp:BoundField HeaderText="Lives left" DataField="Livesleft" />
         <asp:BoundField HeaderText="Hp left" DataField="Hpleft" />
         <asp:BoundField HeaderText="Tijd in seconden" DataField="Tijd" />
      </Columns>
    </asp:GridView>
    </div>
    </div>

</asp:Content>
