<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/TBIMaster.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="EmpList.aspx.cs" Inherits="HR_Salaries.Pages.Employee.HREmpRating" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="row" style="text-align: center">

        <asp:HiddenField ID="hfEmpID" Value="0" runat="server" />
         <asp:TextBox ID="hfEmpDep" runat="server" MaxLength="20" CssClass="txt" AutoPostBack="True" visible="false" BackColor="lavender" ForeColor="gray"></asp:TextBox>
          
     <br />  
        <asp:HiddenField ID="hfCount" Value="0" runat="server" />
    </div>

     
    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" CssClass="Error" Text="" Visible="true"></asp:Label>
    </div>
    <div class="row" id="divddl"  runat="server" >
        <div class="columnleft">
            <asp:Label ID="Label2" runat="server" Text="نوع التقييم : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlRateType" runat="server" CssClass="ddl" AutoPostBack="True">
            </asp:DropDownList>

        </div>

        <div class="columnleft">
            <asp:Label ID="Label6" runat="server" Text="اسم المدير : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlRateManager" runat="server" CssClass="ddl" AutoPostBack="True" >
            </asp:DropDownList>

        </div>
    </div>


    <div style="overflow: auto; white-space: nowrap;" align="center">

        <div class="row" style="text-align: center; width: 98.5%; overflow-x: auto; white-space: nowrap;" dir="rtl">

            <asp:GridView ID="GridView1" runat="server" DataGridViewTriState="True" BackColor="White" CssClass="table"
                AutoSizeRowsMode="false" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" dir="rtl" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging"  AllowSorting="true" AllowPaging="true" PageSize="15">
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF"/>

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
    <div class="row" style="border-style:ridge;"><asp:Label ID="Label15" runat="server" Text="عدد الموظفين الكلي : "></asp:Label>
                <asp:Label ID="Lbltotal" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Label16" runat="server" Text="عدد الموظفين المسموح لهم بتقييم ممتاز (25%) : "></asp:Label>
                <asp:Label ID="lblExc" runat="server"></asp:Label>
                 <br />
                <asp:Label ID="Label4" runat="server" Text="عدد الموظفين المسموح لهم بتقييم جيد جداً (35%) : "></asp:Label>
                <asp:Label ID="lblVery" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Label3" runat="server" Text="عدد الموظفين المسموح لهم بتقييم جيد (25%) : "></asp:Label>
                <asp:Label ID="lblGood" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Label5" runat="server" Text="عدد الموظفين المسموح لهم بتقييم متوسط (15%) : "></asp:Label>
                <asp:Label ID="lblInter" runat="server"></asp:Label>
            </div>
    

    <div class="row">
        <asp:Button ID="btnSubmit" runat="server" Text="عرض" CssClass="btn" OnClick="btnSubmit_Click"/>
        <asp:Button ID="BtnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="BtnCancel_Click" CausesValidation="False" UseSubmitBehavior="False" />
        <asp:Button ID="btnPrint" runat="server" Text="تحميل" CssClass="btn"  OnClick="btnPrint_Click"/> 
    </div>
   
</asp:Content>

