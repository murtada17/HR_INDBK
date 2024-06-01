<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="BranchAdEd.aspx.cs" Inherits="MDir_DMS.Pages.Additional.BranchAdEd" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
    </div>
    <div class="row" style="text-align: center">
        <asp:GridView ID="gvBranch" runat="server" CssClass="grid" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="gvBranch_PageIndexChanging" AutoGenerateSelectButton="True" OnSelectedIndexChanging="gvBranch_SelectedIndexChanging">
            <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>

            <HeaderStyle BackColor="#00959a" Font-Bold="True" ForeColor="White"></HeaderStyle>

            <PagerStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>

            <RowStyle ForeColor="#000066"></RowStyle>

            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

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

                <asp:Label ID="Label1" runat="server" Text="رقم الفرع"></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtNumber" runat="server" CssClass="txt" MaxLength="4"></asp:TextBox>
            </div>
            <div class="columnleft">
            </div>
            <div class="columnRight" style="text-align: right">
                <asp:CheckBox ID="chbActive" runat="server" Text="فعال؟" />
            </div>
        </div>
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
                <asp:Label ID="Label5" runat="server" Text="المدينة"></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtCity" runat="server" CssClass="txt" MaxLength="50"></asp:TextBox>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label6" runat="server" Text="العنوان"></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtAddress" runat="server" CssClass="txt" MaxLength="255"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label7" runat="server" Text="رقم الهاتف"></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="txt" MaxLength="50"></asp:TextBox>
            </div>
        <div class="columnleft">
            <asp:Label ID="Label2" runat="server" Text="البريد الألكتروني : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlEmail" runat="server" AutoPostBack="True" CssClass="ddlltr">
            </asp:DropDownList>
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
