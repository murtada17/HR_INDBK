<%@ Page Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="HR_Salaries.Pages.User.Login" Title="Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div dir="rtl"></div>
      <div class="content">
        <div class="container" style="height:500px">

            <div class="col-lg-13">
                <div class="sub-content">
                    <div class="list-group">
    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
    </div>
    <div class="row">
          <div class="col-6 col-md-2"></div>
          <div class="col-6 col-md-2"></div>
        <div class="col-6 col-md-2">
            <asp:Label ID="Label1" runat="server" Text="��� �������� : "></asp:Label>
        </div>
        <div class="col-6 col-md-2">
            <asp:TextBox ID="txtUserName" runat="server" CssClass="txtltr"></asp:TextBox>
        </div>
        <div class="col-6 col-md-2"></div>
        <div class="col-6 col-md-2"></div>
    </div>
    <div class="row">
          <div class="col-6 col-md-2"></div>
          <div class="col-6 col-md-2"></div>
       <div class="col-6 col-md-2">
            <asp:Label ID="Label2" runat="server" Text="���� ���� : "></asp:Label>
        </div>
        <div class="col-6 col-md-2">
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="txtltr"></asp:TextBox>
        </div>
        <div class="col-6 col-md-2"></div>
        <div class="col-6 col-md-2"></div>
    </div>
    <br />
    <div class="row">
          <div class="col-6 col-md-2"></div>
        <div class="col-6 col-md-2"></div>
            <div class="col-6 col-md-2">     <asp:Button style="font-size: unset;" ID="btnLogin" runat="server" Text="����� ������" width="100%" CssClass="btn btn-success" OnClick="btnLogin_Click" /></div>
                <div class="col-6 col-md-2">   <asp:Button style="font-size: unset;" ID="btnCancel" runat="server" Text="�����" width="100%" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
    </div></div>
        <div class="col-6 col-md-2"></div>
     <div class="col-6 col-md-2"></div>
       </div> 
</div>
    </div>
     </div>
                </div>
                 
</asp:Content>
