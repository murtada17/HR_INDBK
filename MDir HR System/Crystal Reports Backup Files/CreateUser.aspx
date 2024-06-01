<%@ Page Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true"
    CodeBehind="CreateUser.aspx.cs" Inherits="HR_Salaries.Pages.User.CreateUser" Title="New User Account" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label24" runat="server" Text="الفرع : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlSBranch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSBranch_SelectedIndexChanged" CssClass="ddl">
            </asp:DropDownList>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label26" runat="server" Text="القسم : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlSDep" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSBranch_SelectedIndexChanged" CssClass="ddl">
            </asp:DropDownList>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label1" runat="server" Text="الموظف : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="ddl" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label4" runat="server" Text="أسم المستخدم : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtAccountName" runat="server" CssClass="txtltr"></asp:TextBox>
        </div>
    </div>
    <div class="row" style="display: none">
        <div class="columnleft">
            <asp:Label ID="Label2" runat="server" Text="كلمة السر : " Visible="False"></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtUserPass" runat="server" TextMode="Password" Width="250px"
                Visible="False"></asp:TextBox>
        </div>
    </div>
    <div class="row" style="display: none">
        <div class="columnleft">
            <asp:Label ID="Label6" runat="server" Text="إعادة كلمة السر : "
                Visible="False"></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtPassConf" runat="server" TextMode="Password" Width="250px"
                Visible="False"></asp:TextBox>
        </div>
        <div class="columnleft"></div>
        <div class="columnRight"></div>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label5" runat="server" Text="نوع المستخدم : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlUserType" runat="server" CssClass="ddl">
            </asp:DropDownList>
        </div>
        <div class="columnleft"></div>
        <div class="columnRight"></div>
    </div>
    <br />
    <div class="row">
        <asp:Button ID="btnSubmit" runat="server" Text="إضافة" CssClass="btn" OnClick="btnSubmit_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
