<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="HR_Salaries.Pages.Employee.Attendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

    <div class="row>
        <asp:Label ID="lblMessage" runat="server" CssClass="Error" Text=""></asp:Label><asp:HiddenField ID="hfEmpID" Value="0" runat="server" />
    </div>
    <div class="row">
        <div class="columnleft">لتحميل الحظور لتاريخ</div>
        <div class="columnRight">
                <asp:TextBox ID="txtDate" runat="server" MaxLength="15" CssClass="txt" AutoPostBack="True"></asp:TextBox>
                <asp:CalendarExtender ID="txtDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtDate" PopupPosition="BottomRight" Format="dd/MM/yyyy"></asp:CalendarExtender>
        </div>
        <div class="columnleft"></div>
        <div class="columnRight">
        </div>
    </div>
    <div class="row">
        <div class="columnleft"></div>
        <div class="columnRight"></div>
        <div class="columnleft"></div>
        <div class="columnRight"></div>
    </div>
    <div class="row">
        <asp:Button ID="btnSubmit" runat="server" Text="تحميل" CssClass="btn" OnClick="btnSubmit_Click" ValidationGroup="Submit" />
        <asp:Button ID="btnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="btnCancel_Click" CausesValidation="False" UseSubmitBehavior="False" />
    </div>
</asp:Content>
