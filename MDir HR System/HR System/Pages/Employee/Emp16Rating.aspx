<%@ Page Title="استمارة الراتب الـ 16" Language="C#" MasterPageFile="~/Pages/TBIMaster.Master" AutoEventWireup="true" CodeBehind="Emp16Rating.aspx.cs" Inherits="HR_Salaries.Pages.Employee.Emp16Rating" MaintainScrollPositionOnPostback="true"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" type="text/javascript">
    $(document).ready(function () {

      

    });

    function validateName() {
        document.getElementById("ctl00_ContentPlaceHolder2_lblMessage").innerText = "";
       
        var name = document.getElementById("ctl00_ContentPlaceHolder2_txtName").value;
        if (name) {
        }
        else {
            document.getElementById("ctl00_ContentPlaceHolder2_lblMessage").innerText = "يرجى اختيار احد الموظفين";
            return;
        }
       
        }
    function Confirm() {
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden";
        confirm_value.name = "confirm_value";
        if (confirm("هل تم تقييم جميع الموظفين؟ سيتم ازالة صلاحية الصفحة عند الضغط على نعم")) {
            confirm_value.value = "نعم";
        } else {
            confirm_value.value = "لا";
        }
        document.forms[0].appendChild(confirm_value);
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    <div class="row" style="text-align: center">

        <asp:HiddenField ID="hfEmpID" Value="0" runat="server" />
          
     <br />  
        <asp:HiddenField ID="hfCount" Value="0" runat="server" />
    </div>


    <div style="overflow: auto; white-space: nowrap;" align="center">

        <div class="row" style="text-align: center; width: 98.5%; overflow-x: auto; white-space: nowrap;" dir="rtl">
           
       
            <asp:GridView ID="GridView1" runat="server" DataGridViewTriState="True" BackColor="White" CssClass="table"
                AutoSizeRowsMode="false" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" dir="rtl" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateSelectButton="True" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowSorting="true" AllowPaging="true" PageSize="15">
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
       <div class="row" style="border-style:ridge;"><asp:Label ID="Label1" runat="server" Text="عدد الموظفين الكلي : "></asp:Label>
                <asp:Label ID="Lbltotal" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Label2" runat="server" Text="عدد الموظفين المسموح لهم بتقييم ممتاز (25%) : "></asp:Label>
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
    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" CssClass="Error" Text="" Visible="true"></asp:Label>
    </div>
    <asp:Panel ID="pnlRate" runat="server">
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label6" runat="server" Text="اسم الموظف : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtName" runat="server" MaxLength="20" CssClass="txt" AutoPostBack="True" ReadOnly="True" BackColor="lavender" ForeColor="gray" onkeyup="validateName()"></asp:TextBox>

            </div>
            <div class="columnleft">
                <asp:Label ID="Label10" runat="server" Text="درجة التقييم : "></asp:Label>
            </div>
            <div class="columnRight">
                 <asp:DropDownList ID="ddlDegree" runat="server" CssClass="ddl" AutoPostBack="True">
                </asp:DropDownList>
            </div>
            
                 </div>
      
        </asp:Panel>

  
    <div class="row">
        <asp:Button ID="btnSubmit" runat="server" Text="تقييم" CssClass="btn" OnClick="btnSubmit_Click" />
        <asp:Button ID="BtnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="BtnCancel_Click" CausesValidation="False" UseSubmitBehavior="False" />
    </div>

      <div class="row" style=" width:500px; border-style:ridge; text-align:center; border-color:navy;margin: auto;" >
         <asp:Label ID="Label13" runat="server" BackColor="Red" ForeColor="White">عند الانتهاء من جميع التقييمات لكل الموظفين بشكل نهائي يرجى الضغط على الزر التالي ليتم ارسالها الى قسم الموارد البشرية :</asp:Label> 
        
         <br />
         <br />
         <asp:Button ID="btnEnd" runat="server" Text="ارسال" CssClass="btn" OnClick="btnEnd_Click" OnClientClick = "Confirm()"/>
    </div>

</asp:Content>
