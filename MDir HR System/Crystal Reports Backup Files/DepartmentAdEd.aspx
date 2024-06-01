<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="DepartmentAdEd.aspx.cs" Inherits="MDir_DMS.Pages.Additional.DepartmentAdEd" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
    </div>
    <div class="row" style="text-align: center">
        <asp:GridView ID="gvDepartment" runat="server" CssClass="grid" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="gvBranch_PageIndexChanging" AutoGenerateSelectButton="True" OnSelectedIndexChanging="gvBranch_SelectedIndexChanging">
            <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>

            <HeaderStyle BackColor="#00959a" Font-Bold="True" ForeColor="White"></HeaderStyle>

            <PagerStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>

            <RowStyle ForeColor="#000066"></RowStyle>

            <SelectedRowStyle BackColor="#92AED1" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

            <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

            <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>

            <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

            <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
        </asp:GridView>
    </div>
    <div class="row">
        <div class="columnleft">
            &nbsp;
        </div>
        <div class="columnRight">
        </div>
        <div class="columnleft">
        </div>
        <div class="columnRight">
        </div>
    </div>
    <asp:Panel ID="pnlControls" runat="server">
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label3" runat="server" Text="الأسم (عربي)"></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtNameAR" runat="server" CssClass="txt" MaxLength="50"></asp:TextBox>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label4" runat="server" Text="الأسم (أنكليزي)"></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtNameEN" runat="server" CssClass="txt" MaxLength="50"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="columnleft">
            </div>
            <div class="columnRight" style="text-align: right">
                <asp:CheckBox ID="chbActive" runat="server" Text="فعال؟" />
            </div>
            <div class="columnleft">
            </div>
            <div class="columnRight">
            </div>
        </div>
        <div class="row">
            <div class="columnleft">
                &nbsp;
            </div>
            <div class="columnRight">
            </div>
            <div class="columnleft">
            </div>
            <div class="columnRight">
            </div>
        </div>
    </asp:Panel>

    <div class="row">
        <asp:Button ID="btnSubmit" runat="server" CssClass="btn" Text="تنفيذ" OnClick="btnSubmit_Click" />
        <asp:Button ID="btnCancel" runat="server" CssClass="btnCancel" Text="إلغاء" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
