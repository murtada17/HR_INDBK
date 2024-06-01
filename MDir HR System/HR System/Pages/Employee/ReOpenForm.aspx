<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/TBIMaster.Master" AutoEventWireup="true" CodeBehind="ReOpenForm.aspx.cs" Inherits="HR_Salaries.Pages.Employee.ReOpenForm" %>
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

     <div class="row">
        <asp:Button ID="btnSubmit" runat="server" Text="اعادة الاستمارة" CssClass="btn" OnClick="btnSubmit_Click"/>
        <asp:Button ID="BtnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="BtnCancel_Click" CausesValidation="False" UseSubmitBehavior="False" />

    </div>




    <br />
    <br /><br /><br /><br />
    <div class="row" id="div1"  runat="server" >
        <div class="columnleft">
            <asp:Label ID="Label1" runat="server" Text="فتح/غلق الاستمارة للجميع: "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlRateOpen" runat="server" CssClass="ddl" AutoPostBack="True">
            </asp:DropDownList>

        </div>
           <div class="columnleft">
          
        </div>
        <div class="columnRight">
           
            </asp:DropDownList>

        </div>
        </div>

    <div class="row">
        <asp:Button ID="Open" runat="server" Text="فتح" CssClass="btn" OnClick="Open_Click"/>
        <asp:Button ID="close" runat="server" Text="غلق" CssClass="btnCancel" OnClick="close_Click" CausesValidation="False" UseSubmitBehavior="False" />

    </div>
</asp:Content>

