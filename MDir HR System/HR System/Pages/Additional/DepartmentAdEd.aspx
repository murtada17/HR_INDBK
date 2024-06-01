<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="DepartmentAdEd.aspx.cs"
     Inherits="HR_Salaries.Pages.Additional.DepartmentAdEd" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row" style="text-align: center">
        <asp:Label Width="100%" ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
    </div>
         <div class="container">
            <div class="col-lg-13">
                <div class="sub-content">
                    <div class="list-group">
    <div class="row" style="text-align: center">
        <div class="col-md-1"></div>
         <div class="col-md-10">
        <asp:GridView ID="gvDepartment" runat="server" CssClass="grid" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="gvBranch_PageIndexChanging" AutoGenerateSelectButton="True" OnSelectedIndexChanging="gvBranch_SelectedIndexChanging">
            <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>

            <HeaderStyle BackColor="#5f6b89" Font-Bold="True" ForeColor="White"></HeaderStyle>

            <PagerStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>

            <RowStyle ForeColor="#000066"></RowStyle>

            <SelectedRowStyle BackColor="#92AED1" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

            <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

            <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>

            <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

            <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
        </asp:GridView>
    </div>
         <div class="col-md-1"></div>
           </div>
    <div class="row">
        <div class="col-md-3">
            &nbsp;
        </div>
        <div class="col-md-3">
        </div>
        <div class="col-md-3">
        </div>
        <div class="col-md-3">
        </div>
    </div>
    <asp:Panel ID="pnlControls" runat="server">
        <div class="row">
            <div class="col-md-3">
                <asp:Label CssClass="lbl" Width="100%" ID="Label3" runat="server" Text="الأسم (عربي)"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtNameAR" runat="server" CssClass="txt" Width="100%" MaxLength="50"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Label CssClass="lbl" Width="100%" ID="Label4" runat="server" Text="الأسم (أنكليزي)"></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtNameEN" runat="server" CssClass="txt" Width="100%" MaxLength="50"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-3" style="text-align: right">
                <asp:CheckBox ID="chbActive" runat="server" Text="فعال؟" />
            </div>
            <div class="col-md-3">
            </div>
            <div class="col-md-3">
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                &nbsp;
            </div>
            <div class="col-md-3">
            </div>
            <div class="col-md-3">
            </div>
            <div class="col-md-3">
            </div>
        </div>
    </asp:Panel>

    <div class="row">
         <div class="col-6 col-md-2">
                                    </div>
                                    <div class="col-6 col-md-2">
                                    </div>
                                    <div class="col-6 col-md-2">
                                          <asp:Button style="font-size: unset;" ID="btnSubmit" runat="server" CssClass="btn btn-success" Width="100%" Text="تنفيذ" OnClick="btnSubmit_Click" />
                                         
                                     </div>
                                    <div class="col-6 col-md-2">
                                            <asp:Button style="font-size: unset;" ID="btnCancel" runat="server" CssClass="btn btn-danger" Width="100%" Text="إلغاء" OnClick="btnCancel_Click" />
                                   
                                     </div>
                                    <div class="col-6 col-md-2">
                                    </div>
                                    <div class="col-6 col-md-2">
                                    </div>
      
    
    </div>
                            </div>
                      </div>
                  </div>
              </div>
            
              
</asp:Content>
