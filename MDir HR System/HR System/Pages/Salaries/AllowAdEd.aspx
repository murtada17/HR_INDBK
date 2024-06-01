<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="AllowAdEd.aspx.cs" Inherits="HR_Salaries.Pages.Salaries.AllowAdEd" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row" style="text-align: center">
        <asp:Label Width="100%" ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
    </div>
    <div class="content">
        <div class="container">
            <div class="col-lg-12">
                <div class="sub-content">
                    <div class="list-group">
                        <div class="row"></div>
                        <div class="row"></div>
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label23" runat="server" Text="عنوان المخصص (عربي) : "></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtAllowTitleAR" runat="server" CssClass="txt" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label22" runat="server" Text="عنوان المخصص (أنكليزي) : "></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtAllowTitleEN" runat="server" Style="text-align: left;" CssClass="txt" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label21" runat="server" Text="رمز الدليل المحاسبي : "></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtGLCode" runat="server" MaxLength="7" CssClass="txt" Width="100%"></asp:TextBox>
                            </div>

                            <div class="col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label24" runat="server" Text="نوع المخصص : "></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlType" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label25" runat="server" Text="نوع التخصيص :"></asp:Label>
                            </div>
                            <div class="col-md-3" style="text-align: right">

                                <asp:RadioButtonList ID="rblIsPercentage" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblIsPercentage_SelectedIndexChanged" AutoPostBack="True">

                                    <asp:ListItem Value="false">قطعي</asp:ListItem>
                                    <asp:ListItem Value="true" Selected="True">نسبي</asp:ListItem>
                                </asp:RadioButtonList>

                            </div>

                            <div class="col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label1" runat="server" Text="فعال؟ : "></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:CheckBox Style="text-align: right; padding-top: 15px;" Width="100%" ID="chbActive" Checked="true" runat="server" />
                            </div>
                        </div>
                        <div class="row"></div>
                        <div class="row">
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-2">
                                <asp:Button Style="font-size: unset;" ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-success" Width="100%" OnClick="btnSubmit_Click" />
                            </div>
                            <div class="col-md-2">
                                <asp:Button Style="font-size: unset;" ID="btnCancel" runat="server" Text="إلغاء" CssClass="btn btn-danger" Width="100%" OnClick="btnCancel_Click" CausesValidation="False" UseSubmitBehavior="False" />
                            </div>
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-2">
                            </div>
                        </div>
                        <hr />

                        <div class="row">&nbsp;</div>
                        <asp:Panel ID="pnlValues" Enabled="false" runat="server">
                            <div class="row">
                            </div>
                            <div class="row">
                                <asp:GridView ID="gvValues" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowSorting="True" CssClass="grid" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnPageIndexChanging="gvValues_PageIndexChanging" OnSelectedIndexChanging="gvValues_SelectedIndexChanging" AllowPaging="True">
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
                            <div class="row">&nbsp;</div>

                            <asp:Panel ID="pnlControls" runat="server">
                                <div class="row">
                                    <div class="col-md-3">

                                        <asp:Label CssClass="lbl" Width="100%" ID="Label26" runat="server" Text="عنوان التخصيص (عربي) :"></asp:Label>

                                    </div>
                                    <div class="col-md-3">

                                        <asp:TextBox ID="txtValueDescAR" runat="server" CssClass="txt" Width="100%"></asp:TextBox>

                                    </div>
                                    <div class="col-md-3">

                                        <asp:Label CssClass="lbl" Width="100%" ID="Label27" runat="server" Text="عنوان التخصيص (أنكليزي) :"></asp:Label>

                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtValueDescEN" runat="server" Style="text-align: left;" CssClass="txt" Width="100%"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label28" runat="server" Text="مبلغ \ نسبة التخصيص :"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtValue" runat="server" CssClass="txt" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label29" runat="server" Text="فعال؟ :"></asp:Label>
                                    </div>
                                    <div class="col-md-3" style="text-align: right">
                                        <asp:CheckBox Style="text-align: right; padding-top: 15px;" Width="100%" ID="chbValueActive" runat="server" Checked="true" />
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:HiddenField ID="hfParentID" runat="server" Value="0" />
                            <asp:HiddenField ID="hfValueID" runat="server" Value="0" />
                            <asp:HiddenField ID="hfValueTypeID" runat="server" Value="0" />
                            <br />
                            <div class="row">
                                <div class="col-md-2">
                                </div>
                                <div class="col-md-2">
                                </div>

                                <div class="col-md-2">
                                    <asp:Button Style="font-size: unset;" ID="btnEdit" runat="server" Text="تعديل" CssClass="btn btn-success" Width="100%" OnClick="btnEdit_Click" />
                                </div>
                                <div class="col-md-2"></div>
                                <div class="col-md-2">
                                </div>
                                <div class="col-md-2">
                                </div>

                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
