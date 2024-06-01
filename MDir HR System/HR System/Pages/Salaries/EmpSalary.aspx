<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="EmpSalary.aspx.cs" Inherits="HR_Salaries.Pages.Allowances.Allowances" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div dir="rtl">
        <div class="content">
            <div class="container">
                <div class="col-lg-13">
                    <div class="sub-content">
                        <div class="list-group">
                            <div class="row" style="text-align: center">
                                <asp:Label Width="100%" ID="lblMessage" runat="server" Text=""></asp:Label>
                                <br />
                            </div>
                            <asp:Panel ID="pSearch" runat="server" DefaultButton="btnSubmit">
                                <div class="row">
                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label32" runat="server" Text="الفرع : "></asp:Label>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:DropDownList ID="ddlSBranch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSBranch_SelectedIndexChanged" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label33" runat="server" Text="القسم : "></asp:Label>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:DropDownList ID="ddlSDep" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSBranch_SelectedIndexChanged" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label27" runat="server" Text="الاسم الكامل (عربي) : "></asp:Label>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:DropDownList ID="ddlNameAR" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlName_SelectedIndexChanged" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label6" runat="server" Text="الاسم الكامل (أنكليزي) : "></asp:Label>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:DropDownList ID="ddlNameEN" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlName_SelectedIndexChanged" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">

                                    <div class="col-6 col-md-3"></div>
                                    <div class="col-6 col-md-3">
                                        <asp:Button Style="font-size: unset;" ID="btnGetInfo" runat="server" Text="جلب المعلومات" CssClass="btn btn-success" OnClick="btnGetInfo_Click" />
                                    </div>
                                    <div class="col-6 col-md-3"></div>
                                    <div class="col-6 col-md-3" style="text-align: right">
                                    </div>
                                </div>
                                <div class="row"></div>
                            </asp:Panel>
                            <asp:Panel ID="pnlData" runat="server" Enabled="False" CssClass="pnl">
                                <div class="row">
                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label21" runat="server" Text="الراتب الأسمي : "></asp:Label>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:TextBox ID="txtBasicSalary" runat="server" MaxLength="8" CssClass="txt"></asp:TextBox>
                                    </div>

                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label22" runat="server" Text="الراتب الاسمي القديم: "></asp:Label>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:TextBox ID="txtOldBasicSalary" runat="server" CssClass="txt" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-6 col-md-3">
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:CheckBox ID="chbSpouseNoWork" runat="server" Text="الزوج عاطل عن العمل\ الزوجة ربة بيت؟" />
                                    </div>

                                    <div class="col-6 col-md-3">
                                    </div>
                                    <div class="col-6 col-md-3">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label1" runat="server" Text="بموجب الأمر الإداري :" Visible="false"></asp:Label>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:FileUpload ID="FileUpload1" runat="server" Visible="false" />
                                    </div>

                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label2" runat="server" Text="المرقم :" Visible="false"></asp:Label>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:TextBox ID="txtOrderNo" runat="server" CssClass="txt" Visible="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label5" runat="server" Text="بعنوان :" Visible="false"></asp:Label>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:TextBox ID="txtOrderDesc" runat="server" CssClass="txt" Visible="false"></asp:TextBox>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label7" runat="server" Text="بتاريخ :" Visible="false"></asp:Label>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:TextBox ID="txtOrderDate" runat="server" CssClass="txt" Visible="false">dd/MM/yyyy</asp:TextBox>
                                        <asp:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtOrderDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-6 col-md-3"></div>
                                    <div class="col-6 col-md-3">
                                        <asp:Button Style="font-size: unset;" ID="btnSubmit" runat="server" Text="تحديث الراتب الاسمي" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                                    </div>
                                    <div class="col-6 col-md-3"></div>
                                    <div class="col-6 col-md-3" style="text-align: right">
                                    </div>
                                </div>
                                <div class="row">
                                </div>

                                <div class="row" style="padding: 0px 0px 0px 0px;">
                                    <div class="col-md-12">
                                        <asp:GridView ID="gvValues" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="grid" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" OnRowDeleting="gvValues_RowDeleting" AutoGenerateSelectButton="True" OnSelectedIndexChanging="gvValues_SelectedIndexChanging">
                                            <EditRowStyle Wrap="false" />
                                            <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>
                                            <HeaderStyle BackColor="#5f6b89" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                            <PagerStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>
                                            <RowStyle ForeColor="#000066"></RowStyle>
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                                            <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>
                                            <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>
                                            <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>
                                            <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
                                        </asp:GridView>
                                    </div>
                                    <div class="col-md-1">
                                    </div>
                                </div>
                                <div class="row">
                                </div>

                                <div class="row">
                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label3" runat="server" Text="أنواع المخصصات : "></asp:Label>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:DropDownList ID="ddlValues" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" OnSelectedIndexChanged="ddlValues_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label4" runat="server" Text="المخصصات : "></asp:Label>
                                    </div>
                                    <div class="col-6 col-md-3">

                                        <asp:RadioButtonList ID="chblAllowance" runat="server">
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-6 col-md-3"></div>
                                    <div class="col-6 col-md-3"></div>
                                    <div class="col-6 col-md-3">
                                        <asp:Button Style="font-size: unset;" ID="btnAddAllwoance" runat="server" Text="إضافة المخصص\ الاستقطاع" CssClass="btn btn-success" OnClick="btnAddAllwoance_Click" />
                                    </div>
                                    <div class="col-6 col-md-3"></div>
                                </div>
                                <div class="row">
                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label8" runat="server" Text="أستقطاعات اخرى : "></asp:Label>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:TextBox ID="txtOtherDeduction" runat="server" CssClass="txt"></asp:TextBox>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:Button Style="font-size: unset;" ID="btnDeduction" runat="server" Text="تحديث الاستقطاعات الاخرى" CssClass="btn btn-success" OnClick="btnDeduction_Click" />
                                    </div>
                                    <div class="col-6 col-md-3">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-6 col-md-3"></div>
                                    <div class="col-6 col-md-3"></div>
                                    <div class="col-6 col-md-3"></div>
                                    <div class="col-6 col-md-3" style="text-align: right">
                                        <asp:Button Style="font-size: unset;" ID="btnCancel" runat="server" Text="إختيار موظف آخر" CssClass="btn btn-primary" OnClick="btnCancel_Click" CausesValidation="False" UseSubmitBehavior="False" />
                                    </div>
                                </div>

                            </asp:Panel>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

