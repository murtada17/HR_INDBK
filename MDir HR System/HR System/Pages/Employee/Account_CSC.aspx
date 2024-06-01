<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="Account_CSC.aspx.cs" Inherits="HR_Salaries.Pages.Employee.Account_CSC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="content">
        <div class="container">
            <div class="col-lg-12">
                <div class="sub-content">
                    <div class="list-group">
                        <div class="row" style="text-align: center">
                            <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
                            <asp:HiddenField ID="hfEmpID" Value="0" runat="server" />
                        </div>
                        <div class="row">
                            <div class="col-6 col-md-3">
                                <asp:Label ID="Label24" runat="server" Text="الفرع : "></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:DropDownList ID="ddlSBranch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSBranch_SelectedIndexChanged" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split">
                                </asp:DropDownList>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:Label ID="Label26" runat="server" Text="القسم : "></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:DropDownList ID="ddlSDep" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSBranch_SelectedIndexChanged" CssClass="ddl btn btn-secondary dropdown-toggle dropdown-toggle-split">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-6 col-md-3">
                                <asp:Label ID="Label1" runat="server" Text="الموظف : "></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:Label ID="Label2" runat="server" Text="Account Number (CSC) : "></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox ID="txtIdNo" runat="server" MaxLength="5" CssClass="txt" OnTextChanged="ddlSBranch_SelectedIndexChanged" TextMode="Number"></asp:TextBox>

                            </div>
                        </div>
                        <div class="row"></div>
                          <div class="row">
          <div class="col-6 col-md-2"></div>
        <div class="col-6 col-md-2"></div>
            <div class="col-6 col-md-2"> <asp:Button Style="font-size: unset;" ID="btnSubmit" runat="server" Text="إضافة" CssClass="btn btn-success"  OnClick="btnSubmit_Click" /></div>
                <div class="col-6 col-md-2"><asp:Button Style="font-size: unset;" ID="btnCancel" runat="server" Text="إلغاء" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
    </div></div>
        <div class="col-6 col-md-2"></div>
     <div class="col-6 col-md-2"></div>
       </div> 
</div>
                     
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
