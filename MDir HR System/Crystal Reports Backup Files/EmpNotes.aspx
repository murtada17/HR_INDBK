<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="EmpNotes.aspx.cs" Inherits="MDir_DMS.Pages.Employee.EmpNotes" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Panel ID="pSearch" runat="server" DefaultButton="btnGetInfo">
        <div class="row" style="text-align: center">
            <asp:RegularExpressionValidator ID="uplValidator" runat="server" ControlToValidate="fuPhoto"
                ErrorMessage="only jpg, bmp & gif formats are allowed"
                ValidationExpression="(.+\.([Jj][Pp][Gg])|.+\.([Bb][Mm][Pp])|.+\.([Gg][Ii][Ff]))" CssClass="Error" ForeColor=""></asp:RegularExpressionValidator>
            <asp:Label ID="lblMessage" runat="server" CssClass="Error" Text=""></asp:Label>
            <br />
        </div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label32" runat="server" Text="الفرع : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlSBranch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSBranch_SelectedIndexChanged" CssClass="ddl">
                </asp:DropDownList>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label33" runat="server" Text="القسم : "></asp:Label>
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
        <div class="row">

            <div class="columnleft"></div>
            <div class="columnRight"></div>
            <div class="columnleft"></div>
            <div class="columnRight">
                <asp:Button ID="btnGetInfo" runat="server" Text="جلب المعلومات" CssClass="btn" OnClick="btnGetInfo_Click" />
            </div>
        </div>
        <div class="row"></div>
    </asp:Panel>
    <asp:Panel ID="pEdit" runat="server" DefaultButton="btnSubmit" Enabled="False" BorderColor="#333333">
        <div class="row">


        </div>
    </asp:Panel>
</asp:Content>
