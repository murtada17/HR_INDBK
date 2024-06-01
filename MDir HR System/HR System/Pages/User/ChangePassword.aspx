<%@ Page Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="HR_Salaries.Pages.User.ChangePassword"
    Title="Change User Password" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row" style="text-align: center">
        <asp:Label  ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
    </div>
     <div class="content">
        <div class="container">

            <div class="col-lg-13">
                <div class="sub-content">
                    <div class="list-group">
                        <div class="row">
     <div class="col-6 col-md-3"></div>
       
        <div class="col-6 col-md-3">
            <asp:Label CssClass="lbl"  Width="100%" ID="Label1" runat="server" Text="كلمة السر القديمة : "></asp:Label>
        </div>
        <div class="col-6 col-md-3">
            <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"
                Width="250px" CssClass="txt"></asp:TextBox>
        </div>
       <div class="col-6 col-md-3"></div>
    </div>
    <div class="row">
         <div class="col-6 col-md-3"></div>
       
        <div class="col-6 col-md-3">
            <asp:Label CssClass="lbl"  Width="100%"  ID="Label2" runat="server" Text="كلمة السر الجديدة : "></asp:Label>
        </div>
        <div class="col-6 col-md-3">
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"
                Width="250px" CssClass="txt"></asp:TextBox>
        </div>
        <div class="col-6 col-md-3"></div>
    </div>
    <div class="row">
           <div class="col-6 col-md-3"></div>
        
        <div class="col-6 col-md-3">
            <asp:Label CssClass="lbl"  Width="100%" ID="Label3" runat="server" Text="إعد كلمة السر الجديدة : "></asp:Label>
        </div>
        <div class="col-6 col-md-3">
            <asp:TextBox ID="txtConfirmNewPassword" runat="server" Width="250px"
                TextMode="Password" CssClass="txt"></asp:TextBox>
        </div>
     <div class="col-6 col-md-3"></div>
    </div>
    <br />
    <div class="row">
           <div class="col-6 col-md-2"></div>
          <div class="col-6 col-md-2"></div>
           <div class="col-6 col-md-2">  <asp:Button style="font-size: unset;" ID="btnChange" runat="server" Text="تغيير" width="100%" CssClass="btn btn-success" OnClick="btnChange_Click" /></div>
     <div class="col-6 col-md-2">  <asp:Button style="font-size: unset;" ID="btnCancel" runat="server" Text="إلغاء" width="100%" CssClass="btn btn-danger" OnClick="btnCancel_Click" /></div>
        <div class="col-6 col-md-2"></div>
          <div class="col-6 col-md-2"></div>
    </div>
                             </div>
                     </div>
                 </div>
             </div>
         </div>
</asp:Content>
