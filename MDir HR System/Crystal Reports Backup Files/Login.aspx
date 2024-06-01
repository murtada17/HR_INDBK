<%@ Page Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="HR_Salaries.Login" Title="Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label1" runat="server" Text="ÃÓã ÇáãÓÊÎÏã : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtUserName" runat="server" CssClass="txtltr"></asp:TextBox>
        </div>
        <div class="columnleft"></div>
        <div class="columnRight"></div>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label2" runat="server" Text="ßáãÉ ÇáÓÑ : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="txtltr"></asp:TextBox>
        </div>
        <div class="columnleft"></div>
        <div class="columnRight"></div>
    </div>
    <br />
    <div class="row">
        <asp:Button ID="btnLogin" runat="server" Text="ÊÓÌíá ÇáÏÎæá" CssClass="btn" OnClick="btnLogin_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="ÅáÛÇÁ" CssClass="btnCancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
