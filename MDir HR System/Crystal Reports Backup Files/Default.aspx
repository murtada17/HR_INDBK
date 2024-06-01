<%@ Page Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="HR_Salaries.Pages.Default" Title="Trade Bank of Iraq" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
    </div>
    <center>

        <div class="row">
            <div class="columnleft"></div>
            <div class="columnRight"></div>
            <div class="columnleft"></div>
            <div class="columnRight" style="text-align:right">
                <asp:Label ID="lblVersion" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </center>
</asp:Content>
