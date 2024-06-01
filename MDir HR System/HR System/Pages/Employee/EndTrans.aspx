<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="EndTrans.aspx.cs" Inherits="HR_Salaries.Pages.Employee.EndTrans" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" CssClass="Error" Text=""></asp:Label><asp:HiddenField ID="hfEmpID" Value="0" runat="server" />
        <br />
    </div>
    <div class="row">
        <div class="columnleft" style="text-align: right">
            <asp:RadioButton ID="rbTempTrans" runat="server" Text="إنهاء تنسيب" GroupName="Type" AutoPostBack="True" OnCheckedChanged="rbTempTrans_CheckedChanged" />
        </div>
        <div class="columnRight" style="text-align: right">
            <asp:RadioButton ID="rbTransfare" runat="server" Text="إلغاء نقل" GroupName="Type" AutoPostBack="True" OnCheckedChanged="rbTempTrans_CheckedChanged" />
        </div>
        <div class="columnleft"></div>
        <div class="columnRight"></div>
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
            <asp:Label ID="Label1" runat="server" Text="الاسم الكامل (أنكليزي) : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlNameEN" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlName_SelectedIndexChanged" CssClass="ddl">
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label34" runat="server" Text="بموجب الأمر الاداري المرقم :"></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtAdminOrderNo" runat="server" CssClass="txt" MaxLength="15"></asp:TextBox>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label5" runat="server" Text="بتاريخ :"></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtOrderDate" runat="server" CssClass="txt" CausesValidation="True" OnTextChanged="txtOrderDate_TextChanged">yyyy/MM/dd</asp:TextBox>
            <asp:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtOrderDate" Format="yyyy/MM/dd">
            </asp:CalendarExtender>
        </div>
    </div>
    <div class="row">
        <div class="columnleft">
        </div>
        <div class="columnRight">
        </div>
        <div class="columnleft">
        </div>
        <div class="columnRight">
        </div>
    </div>

    <div class="row">
        <asp:Button style="font-size: unset;" ID="btnEndTempTrans" runat="server" Text="إنهاء تنسيب" CssClass="btn" OnClick="btnSubmit_Click" />
        <asp:Button style="font-size: unset;" ID="btnEndTrans" runat="server" Text="إلغاء نقل" CssClass="btn" OnClick="btnSubmit_Click" />
        <asp:Button style="font-size: unset;" ID="btnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="btnCancel_Click" CausesValidation="False" UseSubmitBehavior="False" />

    </div>

    <div class="row">

        <div class="columnleft" style="width: 99.61%" dir="rtl">
            <asp:GridView ID="gvTransformation" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="grid" AutoGenerateColumns="False" AutoGenerateSelectButton="false" AllowSorting="True" OnPageIndexChanging="gvTransformation_PageIndexChanging">
                <EditRowStyle Wrap="false" />
                <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>
                <HeaderStyle BackColor="#5f6b89" Font-Bold="True" ForeColor="White"></HeaderStyle>
                <PagerStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>
                <RowStyle ForeColor="#000066"></RowStyle>
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>
                <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>
                <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>
                <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
            </asp:GridView>
        </div>
    </div>
    <div class="row"></div>
</asp:Content>
