<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="ExtNo.aspx.cs" Inherits="HR_Salaries.Pages.ExtNo.ExtNo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="row" style="text-align: center">
        <asp:HiddenField ID="hfEmpID" Value="0" runat="server" />
        <asp:HiddenField ID="hfExtID" runat="server" Value="0" />
        <asp:HiddenField ID="hfOtherExtID" runat="server" Value="0" />
        <asp:Label ID="lblMessage" runat="server" CssClass="Error" Text=""></asp:Label>
        <br />
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label32" runat="server" Text="الفرع : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlSBranch" runat="server" AutoPostBack="True" CssClass="ddl" OnSelectedIndexChanged="ddlSBranch_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label33" runat="server" Text="القسم : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlSDep" runat="server" AutoPostBack="True" CssClass="ddl" OnSelectedIndexChanged="ddlSBranch_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label3" runat="server" Text="الشعبة : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlSection" runat="server" AutoPostBack="True" CssClass="ddl" OnSelectedIndexChanged="ddlSBranch_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="columnleft"></div>
        <div class="columnRight"></div>
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
            <asp:Label ID="Label2" runat="server" Text="رقم الهاتف الداخلي :"></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtExtNo" runat="server" CssClass="txt" MaxLength="15"></asp:TextBox>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label4" runat="server" Text="رقم الهاتف الداخلي آخر :"></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtOtherExtNo" runat="server" CssClass="txt" MaxLength="15"></asp:TextBox>
        </div>
        </div>
        <div class="row"></div>
        <div class="row">
            <asp:Button ID="btnSubmit" runat="server" Text="تعديل" CssClass="btn" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="btnCancel_Click" CausesValidation="False" UseSubmitBehavior="False" />
        </div>
        <div class="row"></div>
    </div>
</asp:Content>
