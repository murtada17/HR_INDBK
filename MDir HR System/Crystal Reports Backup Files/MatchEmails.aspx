<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="MatchEmails.aspx.cs" Inherits="MDir_DMS.Pages.Email.MatchEmails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row" style="text-align: center">
        <asp:HiddenField ID="hfEmpID" Value="0" runat="server" />
        <asp:HiddenField ID="hfEmailID" runat="server" Value="0" />
        <asp:Label ID="lblMessage" runat="server" CssClass="Error" Text=""></asp:Label>
        <br />
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label2" runat="server" Text="البريد الألكتروني : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlEmail" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEmail_SelectedIndexChanged" CssClass="ddlltr">
            </asp:DropDownList>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label3" runat="server" Text="نوعه "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlEmailType" runat="server" CssClass="ddl">
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
            <asp:DropDownList ID="ddlNameEN" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlName_SelectedIndexChanged" CssClass="ddlltr">
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">

        <div class="columnleft">
            <asp:Label ID="Label5" runat="server" Text="اخرى :"></asp:Label>
        </div>
        <div class="columnRight">
            <asp:CheckBox ID="chbIsActive" runat="server" Checked="True" Text="فعــــــــــال" />
        </div>
        <div class="columnleft">
        </div>
        <div class="columnRight">
        </div>
    </div>
    <div class="row"></div>
    <div class="row">
        <asp:Button ID="btnSubmit" runat="server" Text="ربط المعلومات" CssClass="btn" OnClick="btnSubmit_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="btnCancel_Click" CausesValidation="False" UseSubmitBehavior="False" />
    </div>


</asp:Content>
