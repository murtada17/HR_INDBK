<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="Allowance.aspx.cs" Inherits="HR_Salaries.Pages.Allowances.EmpAllowance" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
    </div>
      <div class="content">
        <div class="container">
            <div class="col-lg-12">
                <div class="sub-content">
                    <div class="list-group"> 
    <div class="row">
        <div class="columnleft" style="width: 80%">
            <asp:GridView ID="gvAllowances" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="grid" AutoGenerateColumns="False" AllowPaging="True" AutoGenerateSelectButton="True" OnPageIndexChanging="gvAllowances_PageIndexChanging" OnSelectedIndexChanging="gvAllowances_SelectedIndexChanging" >
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#5f6b89" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>

        </div>
           </div>
     <br />
            
            <div class="row">
                <div class="col-md-2">
                </div>
              <div class="col-md-2">
                </div>
            
                <div class="col-md-2">
                      <asp:Button style="font-size: unset;" ID="btnAdd" runat="server" Text="إضافة" CssClass="btn btn-success"  Width="100%" OnClick="btnAdd_Click" />
                    
                </div>
              <div class="col-md-2">   </div>
                  <div class="col-md-2">
                </div>
              <div class="col-md-2">
                </div>
               
              
            </div>
          


   
                         </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
