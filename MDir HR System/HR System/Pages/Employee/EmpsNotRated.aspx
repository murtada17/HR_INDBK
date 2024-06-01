<%@ Page Title="الموظفين غير المقيمين" Language="C#" MasterPageFile="~/Pages/TBIMaster.Master" AutoEventWireup="true" CodeBehind="EmpsNotRated.aspx.cs" Inherits="HR_Salaries.Pages.Employee.EmpsNotRated" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" CssClass="Error" Text=""></asp:Label><asp:HiddenField ID="hfEmpID" Value="0" runat="server" />
            <br />
        
     </div>
     <div class="row" id="divName"  runat="server" style="display:none">
        
               <asp:CheckBox ID="chk" runat="server" OnCheckedChanged="chkNot_CheckedChanged" Text="غير مقيم" AutoPostBack="true"/>
            </div>



     <div style="overflow: auto; white-space: nowrap;" align="center">

        <div class="row" style="text-align: center; width: 98.5%; overflow-x: auto; white-space: nowrap;" dir="rtl">

            <asp:GridView ID="GridView2" runat="server" DataGridViewTriState="True" BackColor="White" CssClass="table"
                AutoSizeRowsMode="false" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
                GridLines="None" dir="rtl" AutoGenerateColumns="False"
                OnPageIndexChanged="GridView2_PageIndexChanged" OnPageIndexChanging="GridView2_PageIndexChanging"
                AllowSorting="true" AllowPaging="true" PageSize="15">
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" Width="50px" />

                <PagerSettings Mode="NumericFirstLast" />
                <PagerStyle ForeColor="#000066" HorizontalAlign="Center" BackColor="#C6C3C6" />
                <RowStyle ForeColor="#000066" />
                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#594B9C" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#33276A" />

            </asp:GridView>
            
            <br />
        </div>

        <br />
    </div>

     <div class="row">
        <asp:Button ID="btnNotRated" runat="server" Text="تحميل المقيمين/غير المقيمين" CssClass="btn" OnClick="btnNotRated_Click"/>
    </div>
</asp:Content>

