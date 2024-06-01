<%@ Page Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true"
    CodeBehind="ResetPass.aspx.cs" Inherits="HR_Salaries.Pages.User.ResetPass" Title="Reset User(s) Password" %>
<asp:Content ID="head1" ContentPlaceHolderID="head" runat="server">
   
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     
    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
    </div>
      <div class="content">
        <div class="container">
            <div class="col-lg-13">
                <div class="sub-content">
                    <div class="list-group">
    <div class="row">
           <div class="col-md-3"></div>
        <div class="col-md-3">
            <asp:Label ID="Label1" CssClass="lbl"  Width="100%"  runat="server" Text="أسم المستخدم : "></asp:Label>
        </div>
        <div class="col-md-3">
            <asp:DropDownList ID="ddlUserName" runat="server" AutoPostBack="True" CausesValidation="True" Width="100%" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split">
            </asp:DropDownList>
        </div>
     
        <div class="col-md-3"></div>
    </div>
    <br />
    <div class="row">
           <div class="col-md-2"></div>
           <div class="col-md-2"></div>
       <div class="col-md-2">              <asp:Button style="font-size: unset;" ID="btnReset" runat="server" Text="إعادة" width="100%" CssClass="btn btn-success" OnClick="btnReset_Click" /></div> 
       <div class="col-md-2">                  <asp:Button style="font-size: unset;" ID="btnCancel" runat="server" Text="إلغاء" width="100%" CssClass="btn btn-danger" OnClick="btnCancel_Click" /></div>
           <div class="col-md-2"></div>
           <div class="col-md-2"></div>
                               </div>
                     </div>
                 </div>
             </div>
         </div>
               </div>
</asp:Content>
