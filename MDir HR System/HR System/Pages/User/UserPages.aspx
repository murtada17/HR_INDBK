<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="UserPages.aspx.cs" Inherits="HR_Salaries.Pages.User.UserPages" %>

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
        <div class="col-md-3">
            <asp:Label ID="Label1" CssClass="lbl"  Width="100%"  runat="server" Text="أسم المستخدم : "></asp:Label>
        </div>
        <div class="col-md-3">
            <asp:DropDownList ID="ddlUserName" runat="server" AutoPostBack="True" CausesValidation="True" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" OnSelectedIndexChanged="ddlUserName_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="col-md-3"></div>
        <div class="col-md-3"></div>
    </div>
        <div class="row">
        <div class="col-md-3">
            <asp:Label ID="Label3" CssClass="lbl"  Width="100%"  runat="server" Text="الصفحة : "></asp:Label>
        </div>
        <div class="col-md-3" style="text-align: right">
            <asp:CheckBoxList ID="chbPages" runat="server"></asp:CheckBoxList>
        </div>
        <div class="col-md-3">
            <asp:Label ID="Label2" CssClass="lbl"  Width="100%"  runat="server" Text="التقرير : "></asp:Label>
        </div>
        <div class="col-md-3" style="text-align: right">
            <asp:CheckBoxList ID="chbReports" runat="server"></asp:CheckBoxList>
        </div>
    </div>
    <div class="row">


     <div class="col-md-2"></div>
     <div class="col-md-2"></div>
   <div class="col-md-2">       <asp:Button style="font-size: unset;" ID="btnSubmit" runat="server"  Text="التالي" width="100%" CssClass="btn btn-success" OnClick="btnSubmit_Click" /></div>
         
 <div class="col-md-2">             <asp:Button style="font-size: unset;" ID="btnCancel" runat="server"  Text="إلغاء" width="100%" CssClass="btn btn-danger" OnClick="btnCancel_Click" /></div>
     <div class="col-md-2"></div>
     <div class="col-md-2"></div>

     
    </div>
                          </div>
                     </div>
                 </div>
             </div>
         </div>
    
</asp:Content>
