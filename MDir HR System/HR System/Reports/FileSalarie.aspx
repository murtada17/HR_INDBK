<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="FileSalarie.aspx.cs" Inherits="HR_Salaries.Reports.FileSalarie" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row">
        <asp:Label ID="lblMessage" runat="server" CssClass="Error" Text=""></asp:Label>
    </div>
    <div class="row">
        <div class="col-6 col-md-3"> 
            <asp:DropDownList ID="ddlConEmp" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%">
                  <asp:ListItem Value="Salaries" Text="رواتب موظفي الملاك"></asp:ListItem>
                <asp:ListItem Value="Contacts" Text=" رواتب العقود"></asp:ListItem>
                <asp:ListItem Value="4Year" Text=" رواتب 4سنوات"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-6 col-md-3">
            <asp:DropDownList ID="ddlSBranchUplo" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%">
            </asp:DropDownList>
        </div>
        <div class="col-6 col-md-3">
      
        </div>
        <div class="col-6 col-md-3"></div>
    </div>
    <br />
    <asp:Panel runat="server" ID="PnUpload" Visible="false">
        <div class="row">
            <div class="col-6 col-md-3"></div>

            <div class="col-6 col-md-3">
                <asp:FileUpload ID="fuDocs" runat="server" />
            </div>
            <div class="col-6 col-md-3">
                <asp:Button Style="font-size: unset;" ID="btnUpload" runat="server" Text="رفع التقرير" CssClass="btn btn-primary" Width="100%" OnClick="btnUpload_Click" />
            </div>
            <div class="col-6 col-md-3">
                
            </div>
        </div>

        <div class="row">
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="PnDown" Visible="false">
        <div class="row">
            <div class="col-6 col-md-3"></div>

            <div class="col-6 col-md-3">
                <asp:Button Style="font-size: unset;" ID="btnDown" runat="server" Text="تحميل التقرير" CssClass="btn btn-primary" Width="100%" OnClick="btnDown_Click" />
            </div>

            <div class="col-6 col-md-3">
            </div>
            <div class="col-6 col-md-3">
            </div>
        </div>
    </asp:Panel>
</asp:Content>
