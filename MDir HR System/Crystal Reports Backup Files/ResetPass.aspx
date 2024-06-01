<%@ Page Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true"
    CodeBehind="ResetPass.aspx.cs" Inherits="HR_Salaries.Pages.User.ResetPass" Title="Reset User(s) Password" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label1" runat="server" Text="أسم المستخدم : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlUserName" runat="server" AutoPostBack="True" CausesValidation="True" CssClass="ddl">
            </asp:DropDownList>
        </div>
        <div class="columnleft"></div>
        <div class="columnRight"></div>
    </div>
    <div class="row">
        <div class="columnleft"></div>
        <div class="columnRight"></div>
        <div class="columnleft"></div>
        <div class="columnRight"></div>
    </div>
    <div class="row">
        <asp:Button ID="btnReset" runat="server" Text="إعادة" CssClass="btn"
            OnClick="btnReset_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
