<%@ Page Title="نتائج تقييم الراتب الـ 16" Language="C#" MasterPageFile="~/Pages/TBIMaster.Master" AutoEventWireup="true" CodeBehind="Emp16RatingResult.aspx.cs" Inherits="HR_Salaries.Pages.Employee.Emp16RatingResult" MaintainScrollPositionOnPostback="true"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
 <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" CssClass="Error" Text=""></asp:Label><asp:HiddenField ID="hfEmpID" Value="0" runat="server" />
            <br />
        
     </div>

     <div class="row" id="divtxt"  runat="server" style="display:none">
        <div class="columnleft">
            <asp:Label ID="Label4" runat="server" Text="الفرع : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtbranch" runat="server" MaxLength="20" CssClass="txt" ReadOnly="true"></asp:TextBox>
            </div>

   

        <div class="columnleft">
            <asp:Label ID="Label5" runat="server" Text="القسم : "></asp:Label>
        </div>
        <div class="columnRight">
           <asp:TextBox ID="txtdep" runat="server" MaxLength="20" CssClass="txt" ReadOnly="true"></asp:TextBox>

        </div>
    </div>
     <div class="row" id="divddl"  runat="server" style="display:none">
        <div class="columnleft">
            <asp:Label ID="Label1" runat="server" Text="الفرع : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlIBranchs" runat="server" CssClass="ddl" AutoPostBack="True" OnSelectedIndexChanged="ddlbranchs_SelectedIndexChanged">
            </asp:DropDownList>

        </div>

        <div class="columnleft">
            <asp:Label ID="Label6" runat="server" Text="القسم : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlIDepartment" runat="server" CssClass="ddl" AutoPostBack="True" >
            </asp:DropDownList>

        </div>
    </div>
    <div class="row" id="div5" runat="server">
        <div class="columnleft">
            <asp:Label ID="Label2" runat="server" Text="من : " ></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtStartDate" runat="server" MaxLength="15" CssClass="txt" AutoPostBack="True" OnTextChanged="txtJoinDate_TextChanged"></asp:TextBox>
            <asp:CalendarExtender ID="txtBirthDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtStartDate" PopupPosition="BottomRight" Format="yyyy/MM/dd">
            </asp:CalendarExtender>

        </div>
        <div class="columnleft">
            <asp:Label ID="Label3" runat="server" Text="الى : " ></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtEndDate" runat="server" MaxLength="15" CssClass="txt" AutoPostBack="True" OnTextChanged="txtJoinDate_TextChanged" ></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtEndDate" PopupPosition="BottomRight" Format="yyyy/MM/dd">
            </asp:CalendarExtender>
        </div>
    </div>
     <div class="row" style="border-style:ridge;">
                <asp:Label ID="Label8" runat="server" Text="عدد الموظفين لتقييم ممتاز : "></asp:Label>
                <asp:Label ID="lblExc" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Label9" runat="server" Text="عدد الموظفين لتقييم جيد جداً : "></asp:Label>
                <asp:Label ID="lblVery" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Label10" runat="server" Text="عدد الموظفين لتقييم جيد : "></asp:Label>
                <asp:Label ID="lblGood" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Label11" runat="server" Text="عدد الموظفين لتقييم متوسط : "></asp:Label>
                <asp:Label ID="lblInter" runat="server"></asp:Label>
         <br />
         <asp:Label ID="Label7" runat="server" Text="عدد الموظفين لتقييم مقبول : "></asp:Label>
                <asp:Label ID="lblOK" runat="server"></asp:Label>
            </div>
      <div style="overflow: auto; white-space: nowrap;" align="center">

        <div class="row" style="text-align: center; width: 98.5%; overflow-x: auto; white-space: nowrap;" dir="rtl">

            <asp:GridView ID="GridView1" runat="server" DataGridViewTriState="True" BackColor="White" CssClass="table"
                AutoSizeRowsMode="false" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
                GridLines="None" dir="rtl" AutoGenerateColumns="False"
                OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging"
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
        <asp:Button ID="btnSubmit" runat="server" Text="بحث" CssClass="btn" OnClick="btnSubmit_Click"/>
        <asp:Button ID="BtnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="BtnCancel_Click" CausesValidation="False" UseSubmitBehavior="False" />
        <asp:Button ID="btnPrint" runat="server" Text="تحميل" CssClass="btn"  OnClick="btnPrint_Click"/>
    </div>
</asp:Content>

