<%@ Page Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true"
    CodeBehind="CreateUser.aspx.cs" Inherits="HR_Salaries.Pages.User.CreateUser" Title="New User Account" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row" style="text-align: center">
        <asp:Label   ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
    </div>
        <div class="content">
        <div class="container">
            <div class="col-lg-13">
                <div class="sub-content">
                    <div class="list-group">
    <div class="row">
        <div class="col-md-3">
             <asp:Label CssClass="lbl"  Width="100%" ID="Label24" runat="server" Text="الفرع : "></asp:Label>
        </div>
        <div class="col-md-3">
              <asp:DropDownList Width="100%" ID="ddlSBranch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSBranch_SelectedIndexChanged" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split">
            </asp:DropDownList>
        </div>
        <div class="col-md-3">
             <asp:Label CssClass="lbl"  Width="100%" ID="Label26" runat="server" Text="القسم : "></asp:Label>
        </div>
        <div class="col-md-3">
              <asp:DropDownList Width="100%"  ID="ddlSDep" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSBranch_SelectedIndexChanged" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split">
            </asp:DropDownList>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-md-3">
             <asp:Label CssClass="lbl"  Width="100%" ID="Label1" runat="server" Text="الموظف : "></asp:Label>
        </div>
        <div class="col-md-3">
              <asp:DropDownList  ID="ddlEmployee" runat="server" Width="100%" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
        </div>
        <div class="col-md-3">
             <asp:Label CssClass="lbl"  Width="100%" ID="Label4" runat="server" Text="أسم المستخدم : "></asp:Label>
        </div>
        <div class="col-md-3">
            <asp:TextBox ID="txtAccountName" runat="server" CssClass="txt"></asp:TextBox>
        </div>
    </div>
    <div class="row" style="display: none">
         <div class="col-md-3"></div>
        <div class="col-md-3">
             <asp:Label CssClass="lbl"  Width="100%" ID="Label2" runat="server" Text="كلمة السر : " Visible="False"></asp:Label>
        </div>
        <div class="col-md-3">
            <asp:TextBox ID="txtUserPass" runat="server" TextMode="Password" Width="250px"
                Visible="False"></asp:TextBox>
        </div>
         <div class="col-md-3"></div>
    </div>
    <div class="row" style="display: none">
         <div class="col-md-3"></div>
        <div class="col-md-3">
             <asp:Label CssClass="lbl"  Width="100%" ID="Label6" runat="server" Text="إعادة كلمة السر : "
                Visible="False"></asp:Label>
        </div>
        <div class="col-md-3">
            <asp:TextBox ID="txtPassConf" runat="server" TextMode="Password" Width="250px"
                Visible="False"></asp:TextBox>
        </div>
       
        <div class="col-md-3"></div>
    </div>
    <div class="row">
         <div class="col-md-3"></div>
        <div class="col-md-3">
             <asp:Label CssClass="lbl"  Width="100%" ID="Label5" runat="server" Text="نوع المستخدم : "></asp:Label>
        </div>
        <div class="col-md-3">
              <asp:DropDownList Width="100%" ID="ddlUserType" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split">
            </asp:DropDownList>
        </div>
       
        <div class="col-md-3"></div>
    </div>
    <br />
    <div class="row">
         <div class="col-md-2"></div>
         <div class="col-md-2"></div>
      <div class="col-md-2">  <asp:Button style="font-size: unset;" ID="btnSubmit" runat="server" Text="إضافة" width="100%" CssClass="btn btn-success" OnClick="btnSubmit_Click" /></div> 
        <div class="col-md-2">  <asp:Button style="font-size: unset;" ID="btnCancel" runat="server" Text="إلغاء" width="100%" CssClass="btn btn-danger" OnClick="btnCancel_Click" /></div> 
         <div class="col-md-2"></div>
         <div class="col-md-2"></div>
    </div>

                             </div>
                     </div>
                 </div>
             </div>
          
</asp:Content>
