<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="AddOrder.aspx.cs" Inherits="HR_Salaries.Pages.AdminOrder.AddOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
    </div>
    <div class="row">
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
            <asp:Label ID="Label5" runat="server" Text="الاسم الكامل (أنكليزي) : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlNameEN" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlName_SelectedIndexChanged" CssClass="ddlltr">
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label1" runat="server" Text="نوع الامر الاداري : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlOrderType" runat="server" AutoPostBack="True" CssClass="ddl">
            </asp:DropDownList>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label4" runat="server" Text="ملاحظات : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtOrderDesc" runat="server" CssClass="txt" CausesValidation="True"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label2" runat="server" Text="رقمه : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtOrderNo" runat="server" CssClass="txt" CausesValidation="True"></asp:TextBox>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label3" runat="server" Text="تاريخه : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtOrderDate" runat="server" CssClass="txt" CausesValidation="True">yyyy/MM/dd</asp:TextBox>
            <asp:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtOrderDate" Format="yyyy/MM/dd">
            </asp:CalendarExtender>
        </div>
    </div>
    <div class="row">
        <asp:HiddenField ID="hfEmpID" runat="server" Value="0" />
    </div>
    <div class="row">
        <asp:Button ID="btnSubmit" runat="server" Text="التالي" CssClass="btn" OnClick="btnSubmit_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="btnCancel_Click" CausesValidation="False" UseSubmitBehavior="False" />
    </div>
</asp:Content>
