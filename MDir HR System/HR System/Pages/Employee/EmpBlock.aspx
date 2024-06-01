<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="EmpBlock.aspx.cs" Inherits="HR_Salaries.Pages.Employee.EmpBlock" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
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
            <div class="columnleft">
                <asp:Label ID="Label27" runat="server" Text="الاسم الكامل (عربي) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlNameAR" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlName_SelectedIndexChanged" CssClass="ddl">
                </asp:DropDownList>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label1" runat="server" Text="الاسم الكامل (أنكليزي) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlNameEN" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlName_SelectedIndexChanged" CssClass="ddl">
                </asp:DropDownList>
            </div>
        </div>

    <br />
    <div class="row">
        <asp:Button style="font-size: unset;" ID="btnSubmit" runat="server" Text="حجب" CssClass="btn" OnClick="btnSubmit_Click" />
        <asp:Button style="font-size: unset;" ID="btnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
