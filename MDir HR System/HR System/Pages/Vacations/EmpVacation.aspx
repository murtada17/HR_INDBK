<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="EmpVacation.aspx.cs" Inherits="HR_Salaries.Pages.Vacations.EmpVacation" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="content">
        <div class="container">
            <div class="col-lg-12">
                <div class="sub-content">
                    <div class="list-group">
                        <div class="row" style="text-align: center">
                            <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="Label32" runat="server" Text="الفرع : "></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlSBranch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSBranch_SelectedIndexChanged" Width="100%" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="Label33" runat="server" Text="القسم : "></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlSDep" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSBranch_SelectedIndexChanged" Width="100%" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="Label13" runat="server" Text="الشعبة : "></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlSection" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSBranch_SelectedIndexChanged" Width="100%" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-3">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="Label27" runat="server" Text="الاسم الكامل (عربي) : "></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlNameAR" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlName_SelectedIndexChanged" Width="100%" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="Label5" runat="server" Text="الاسم الكامل (أنكليزي) : "></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlNameEN" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlName_SelectedIndexChanged" Width="100%" CssClass="btn ddlltr btn-secondary dropdown-toggle dropdown-toggle-split">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <%--<div class="row">
        <div class="col-md-3">
            نوع العملية :
        </div>
        <div class="col-md-3" style="text-align: right">
            <asp:RadioButton ID="RBAdd" runat="server" GroupName="type" Text="إضافة" OnCheckedChanged="RBAdd_CheckedChanged" AutoPostBack="True" Checked="true" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="RBEdit" runat="server" GroupName="type" Text="حذف" OnCheckedChanged="RBAdd_CheckedChanged" AutoPostBack="True" />

        </div>
        <div class="col-md-3"></div>
        <div class="col-md-3"></div>
    </div>--%>
                        <asp:Panel ID="pGrid" runat="server" DefaultButton="btnSubmit" Visible="false">
                            <div class="row">
                                <div class="col-md-3" style="width: 99.61%" dir="rtl">
                                </div>

                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pForm" runat="server" DefaultButton="btnSubmit">
                        </asp:Panel>
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="Label2" runat="server" Text="نوع الاجازة :"></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlVicationType" runat="server" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" OnSelectedIndexChanged="ddlVicationType_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="Label34" runat="server" Text="رصيد الإجازات : "></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lblVicationBalance" runat="server" Text="0" BackColor="Green" ForeColor="LightGray"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="Label9" runat="server" Text="بموجب الأمر الاداري :"></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtOrderNo" runat="server" MaxLength="15" CssClass="txt" AutoPostBack="True" OnTextChanged="txtStartDate_TextChanged"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="Label10" runat="server" Text="بتاريخ : "></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtOrderDate" runat="server" MaxLength="0" CssClass="txt" AutoPostBack="True" OnTextChanged="txtOrderDate_TextChanged"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" TargetControlID="txtOrderDate" DefaultView="Months" Format="dd/MM/yyyy" PopupPosition="BottomRight"></ajaxToolkit:CalendarExtender>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="Label11" runat="server" Text="ملاحظات :"></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtNote" runat="server" CssClass="txt"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="Label12" runat="server" Text="تاريخ المباشرة :"></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lblStartDate" runat="server" Text="0" BackColor="Green" ForeColor="LightGray"></asp:Label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="Label14" runat="server" Text="تاريخ الاستحقاق : "></asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="lblMaturity" runat="server" Text="0" BackColor="Green" ForeColor="LightGray"></asp:Label>
                            </div>
                        </div>
                        <div class="row" runat="server" id="divDate" style="display: none">
                            <div class="row">
                                <div class="col-md-3">
                                    <asp:Label ID="Label3" runat="server" Text="إبتداً من :"></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtStartDate" runat="server" MaxLength="15" CssClass="txt" AutoPostBack="True" OnTextChanged="txtStartDate_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtStartDate" DefaultView="Months" Format="dd/MM/yyyy" PopupPosition="BottomRight"></ajaxToolkit:CalendarExtender>

                                </div>
                                <div class="col-md-3">
                                    <asp:Label ID="Label4" runat="server" Text="إلى :"></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtEndDate" runat="server" CssClass="txt" AutoPostBack="True" OnTextChanged="txtStartDate_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="txtEndDate" DefaultView="Months" Format="dd/MM/yyyy" PopupPosition="BottomRight"></ajaxToolkit:CalendarExtender>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <asp:Label ID="Label8" runat="server" Text="عدد الايام :"></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtDaysCount" runat="server" CssClass="txt" AutoPostBack="True" OnTextChanged="txtDaysCount_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-md-3"></div>
                                <div class="col-md-3"></div>
                            </div>
                        </div>
                        <div class="row" runat="server" id="divTime" style="display: none">
                            <div class="row'">
                                <div class="col-md-3">
                                    <asp:Label ID="Label1" runat="server" Text="من الساعة :"></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtTimeStart" runat="server" MaxLength="15" CssClass="txt" OnTextChanged="txtTimeStart_TextChanged" AutoPostBack="True">08:00</asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <asp:Label ID="Label6" runat="server" Text="إلى الساعة :"></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtTimeEnd" runat="server" MaxLength="15" CssClass="txt" OnTextChanged="txtTimeStart_TextChanged" AutoPostBack="True">15:00</asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <asp:Label ID="Label7" runat="server" Text="ليوم :"></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtTimeDate" runat="server" MaxLength="15" CssClass="txt" AutoPostBack="True" OnTextChanged="txtTimeStart_TextChanged"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtTimeDate" DefaultView="Months" Format="dd/MM/yyyy" PopupPosition="BottomRight"></ajaxToolkit:CalendarExtender>
                                </div>
                                <div class="col-md-3">
                                </div>
                                <div class="col-md-3">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <asp:HiddenField ID="hfEmpID" runat="server" Value="0" />
                            <asp:HiddenField ID="hfVicationTypeID" runat="server" Value="0" />
                            <asp:HiddenField ID="hfStartDate" runat="server" Value="0" />
                            <asp:HiddenField ID="hfEndDate" runat="server" Value="0" />
                            <asp:HiddenField ID="hfDays" runat="server" Value="0" />
                            <asp:HiddenField ID="hfHours" runat="server" Value="0" />
                            <asp:HiddenField ID="hfBalance" runat="server" Value="0" />
                        </div>
                        <div class="row">
                            <div class="col-6 col-md-2">
                            </div>
                            <div class="col-6 col-md-2">
                            </div>
                            <div class="col-6 col-md-2">
                                <asp:Button ID="btnSubmit" Style="font-size: unset;" runat="server" Text="التالي" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                            </div>
                            <div class="col-6 col-md-2">
                                <asp:Button ID="btnCancel" Style="font-size: unset;" runat="server" Text="إلغاء" CssClass="btn btn-danger" OnClick="btnCancel_Click" CausesValidation="False" UseSubmitBehavior="False" />
                            </div>
                            <div class="col-6 col-md-2">
                            </div>
                            <div class="col-6 col-md-2">
                            </div>
                        </div>
                        <div class="row" style="text-align: right">
                            <asp:RadioButton ID="rbGrid" GroupName="view" runat="server" Text="الاجازات" AutoPostBack="True" OnCheckedChanged="rbGrid_CheckedChanged" />
                            <asp:RadioButton ID="rbReport" GroupName="view" runat="server" Text="تقرير الاجازات" AutoPostBack="True" OnCheckedChanged="rbGrid_CheckedChanged" />
                        </div>
                        <div class="row">
                            <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="vwGrid" runat="server">
                                    <div class="col-md-3" style="width: 99.61%" dir="rtl">
                                        <asp:GridView ID="gvEmpVications" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="grid" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" AutoGenerateSelectButton="false" OnPageIndexChanging="gvEmpVications_PageIndexChanging" AllowSorting="True" OnRowDeleted="gvEmpVications_RowDeleted" OnRowDeleting="gvEmpVications_RowDeleting">
                                            <EditRowStyle Wrap="false" />
                                            <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>
                                            <HeaderStyle BackColor="#6c757d" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                            <PagerStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>
                                            <RowStyle ForeColor="#000066"></RowStyle>
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                                            <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>
                                            <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>
                                            <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>
                                            <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
                                        </asp:GridView>
                                    </div>
                                </asp:View>
                                <asp:View ID="vwReport" runat="server">

                                    <div class="row">
                                        <center>

                                            <CR:CrystalReportViewer ID="crvReports" runat="server" AutoDataBind="True" Height="50px" ToolPanelWidth="200px" Width="350px" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" HasCrystalLogo="False" HasRefreshButton="True" HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False" SeparatePages="False" ToolPanelView="None" GroupTreeStyle-ShowLines="False" OnLoad="CrystalReportViewer1_Load" Visible="False" />
                                        </center>
                                    </div>
                                </asp:View>
                            </asp:MultiView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--</asp:Panel>--%>
</asp:Content>
