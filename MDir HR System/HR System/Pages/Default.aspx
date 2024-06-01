<%@ Page Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="HR_Salaries.Pages.Default" Title="M-Direction| HR system" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container" style ="height:500px;">
        <div class="row" style="text-align: center">
            <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
        </div>


        <div class="row">

            <div class="columnRight" style="text-align: right">
                <asp:Label ID="lblVersion" runat="server" Text="" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
