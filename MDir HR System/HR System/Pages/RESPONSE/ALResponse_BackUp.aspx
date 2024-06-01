<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="ALResponse_BackUp.aspx.cs" Inherits="HR_Salaries.Pages.RESPONSE.ALResponse_BackUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
    <div class="content">
        <div class="container">

            <div class="col-lg-13">
                <div class="sub-content">
                    <div class="list-group">
                        <div class="row">
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label1" runat="server" Width="100%" Text="اختيار الملف"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </div>
                            <div class="col-6 col-md-3">
                            </div>
                            <div class="col-6 col-md-3">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6 col-md-12">
                                <asp:Button style="font-size: unset;" ID="btnUpload" runat="server" Text="تحميل الملف" class="btn" OnClick="btnUpload_Click"/>
                            </div>


                            <div class="col-6 col-md-3">
                            </div>
                            <div class="col-6 col-md-3">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
