<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="ReportsRDLC.aspx.cs" Inherits="MDir_DMS.Reports.ReportsRDLC" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
       <div class="row">
        <asp:Label ID="lblMessage" runat="server" CssClass="Error" Text=""></asp:Label>
    </div>
    <div class="row">
        <div class="columnleft"></div>
        <div class="columnRight"></div>
        <div class="columnleft"></div>
        <div class="columnRight"></div>
    </div>   
<%--    <div class="row">
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
            الأسم العربي :
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtFNameARS" runat="server" MaxLength="20" CssClass="txt" AutoPostBack="True" OnTextChanged="ddlSBranch_SelectedIndexChanged"></asp:TextBox>

        </div>
        <div class="columnleft">
            الأسم الإنكليزي :
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtFNameENS" runat="server" MaxLength="20" CssClass="txt" AutoPostBack="True" OnTextChanged="ddlSBranch_SelectedIndexChanged"></asp:TextBox>

        </div>
    </div>    --%>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label1" runat="server" Text="التقرير : "></asp:Label></div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlReport" runat="server" AutoPostBack="True" CssClass="ddl" OnSelectedIndexChanged="ddlReport_SelectedIndexChanged">
            </asp:DropDownList></div>
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
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana"
             WaitMessageFont-Size="14pt" Width="99%" Height="800px">
        </rsweb:ReportViewer>
    </div>
    
</asp:Content>
