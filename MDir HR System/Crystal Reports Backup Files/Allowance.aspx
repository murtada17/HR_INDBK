<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="Allowance.aspx.cs" Inherits="HR_Salaries.Pages.Allowances.EmpAllowance" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
    </div>
    <div class="row">
        <div class="columnleft" style="width: 80%">
            <asp:GridView ID="gvAllowances" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="grid" AutoGenerateColumns="False" AllowPaging="True" AutoGenerateSelectButton="True" OnPageIndexChanging="gvAllowances_PageIndexChanging" OnSelectedIndexChanging="gvAllowances_SelectedIndexChanging" >
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#00959a" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>

        </div>
        <div class="columnRight" style="width: 15%; vertical-align: top;">
            <div class="row"></div>
            <div class="row">
                <asp:Button ID="Button1" runat="server" Text="إضافة" CssClass="btn" Width="75px" OnClick="btnAdd_Click" />
            </div>
            <div class="row">
            </div>
            <div class="row">
            </div>
        </div>


    </div>
</asp:Content>
