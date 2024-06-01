<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="VacationsTypes.aspx.cs" Inherits="HR_Salaries.Pages.Vacancies.VacanciesTypes" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
    </div>

    <div class="row">
        <asp:GridView ID="gvValues" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="grid" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvValues_SelectedIndexChanged">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#6c757d" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    </div>
    <div class="row">
        <br />
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label36" runat="server" Text="العنوان : "></asp:Label>

        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtDesc" runat="server" CssClass="txt"></asp:TextBox>
        </div>

        <div class="columnleft">
            <asp:Label ID="Label37" runat="server" Text="النوع : "></asp:Label>

        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlType" runat="server" CssClass="ddl">
                <asp:ListItem Value="0">يرجى الإختيار</asp:ListItem>
                <asp:ListItem Value="1">براتب تام</asp:ListItem>
                <asp:ListItem Value="2">براتب الأسمي فقط</asp:ListItem>
                <asp:ListItem Value="3">بدون راتب</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="columnleft">
        </div>
        <div class="columnRight">
            <asp:CheckBox ID="chbIsActive" runat="server" CssClass="chb" Text="فعال ؟" />
        </div>

        <div class="columnleft">
        </div>
        <div class="columnRight">
        </div>
    </div>
    <div class="row">

        <asp:Button ID="btnSubmit" runat="server" Text="التالي" CssClass="btn" OnClick="btnSubmit_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
