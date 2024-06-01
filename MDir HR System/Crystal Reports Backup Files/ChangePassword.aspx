<%@ Page Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="HR_Salaries.Pages.User.ChangePassword"
    Title="Change User Password" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label1" runat="server" Text="كلمة السر القديمة : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"
                Width="250px" CssClass="txtltr"></asp:TextBox>
        </div>
        <div class="columnleft"></div>
        <div class="columnRight"></div>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label2" runat="server" Text="كلمة السر الجديدة : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"
                Width="250px" CssClass="txtltr"></asp:TextBox>
        </div>
        <div class="columnleft"></div>
        <div class="columnRight"></div>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label3" runat="server" Text="إعد كلمة السر الجديدة : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtConfirmNewPassword" runat="server" Width="250px"
                TextMode="Password" CssClass="txtltr"></asp:TextBox>
        </div>
        <div class="columnleft"></div>
        <div class="columnRight"></div>
    </div>
    <br />
    <div class="row">
        <asp:Button ID="btnChange" runat="server" Text="تغيير" CssClass="btn"
            OnClick="btnChange_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
