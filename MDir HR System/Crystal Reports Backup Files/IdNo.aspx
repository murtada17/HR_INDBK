<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="IdNo.aspx.cs" Inherits="HR_Salaries.Pages.Employee.IdNo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
        <asp:HiddenField ID="hfEmpID" Value="0" runat="server" />
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label24" runat="server" Text="الفرع : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlSBranch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSBranch_SelectedIndexChanged" CssClass="ddl">
            </asp:DropDownList>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label26" runat="server" Text="القسم : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlSDep" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSBranch_SelectedIndexChanged" CssClass="ddl">
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
    </div>
    <hr />
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label1" runat="server" Text="الموظف : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="ddl" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label2" runat="server" Text="رقم الهوية : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtIdNo" runat="server" MaxLength="5" CssClass="txt" OnTextChanged="ddlSBranch_SelectedIndexChanged" TextMode="Number"></asp:TextBox>

        </div>
    </div>
    <div class="row"></div>
    <div class="row">
        <asp:Button ID="btnSubmit" runat="server" Text="إضافة" CssClass="btn" OnClick="btnSubmit_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
