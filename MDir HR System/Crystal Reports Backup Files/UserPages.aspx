<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="UserPages.aspx.cs" Inherits="HR_Salaries.Pages.User.UserPages" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label1" runat="server" Text="أسم المستخدم : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlUserName" runat="server" AutoPostBack="True" CausesValidation="True" CssClass="ddl" OnSelectedIndexChanged="ddlUserName_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="columnleft"></div>
        <div class="columnRight"></div>
    </div>
        <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label3" runat="server" Text="الصفحة : "></asp:Label>
        </div>
        <div class="columnRight" style="text-align: right">
            <asp:CheckBoxList ID="chbPages" runat="server"></asp:CheckBoxList>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label2" runat="server" Text="التقرير : "></asp:Label>
        </div>
        <div class="columnRight" style="text-align: right">
            <asp:CheckBoxList ID="chbReports" runat="server"></asp:CheckBoxList>
        </div>
    </div>
    <div class="row">
        <asp:Button ID="btnSubmit" runat="server" Text="التالي" CssClass="btn"
            OnClick="btnSubmit_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
