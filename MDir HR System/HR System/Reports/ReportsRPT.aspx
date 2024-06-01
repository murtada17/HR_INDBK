<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="ReportsRPT.aspx.cs" Inherits="HR_Salaries.Reports.ReportsRPT" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">

    function printTrigger(name) {
        var getMyFrame = document.getElementById("ctl00_ContentPlaceHolder2_iFramePdf");
        getMyFrame.focus();
        getMyFrame.contentWindow.print();
        Confirm(name)
    }

    function Confirm(name) {

        var par = "{'name':'" + name + "'}";
        $.ajax({
            type: "POST",
            url: "ReportsRPT.aspx/OnConfirm",
            data: par,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
            },
            failure: function (response) {
                alert(response.d);
            },
            error: function (response) {
                alert(response.d);
            }
        });
    }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div dir="rtl">
        <div class="content">
            <div class="container">
                <div class="col-lg-13">
                    <div class="sub-content">
                        <div class="list-group">


                            <div class="row">
                                <asp:Label ID="lblMessage" runat="server" CssClass="Error" Text=""></asp:Label>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3"></div>
                                <div class="col-6 col-md-3"></div>
                                <div class="col-6 col-md-3"></div>
                                <div class="col-6 col-md-3"></div>
                            </div>

                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label1" runat="server" Text="التقرير : "></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="ddlReport" runat="server" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" OnSelectedIndexChanged="ddlReport_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label4" runat="server" Text="نوع الأمر الاداري :"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="ddlOrderType" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label2" runat="server" Text="الدرجة العلمية :"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="ddlLicenseDigree" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label3" runat="server" Text="أسم الشهادة :"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="ddlLicenseName" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label32" runat="server" Text="الفرع : "></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="ddlSBranch" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label33" runat="server" Text="القسم : "></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="ddlSDep" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label9" runat="server" Text="الفرع للامر الاداري : "></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="ddlOtherBranch" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label10" runat="server" Text="القسم للامر الاداري : "></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="ddlOtherDep" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label5" runat="server" Text="الشعبة : "></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="ddlSection" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label6" runat="server" Text="سبب قطع علاقة العمل : "></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="ddlResignReason" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label7" runat="server" Text="نوع الاجازة : "></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="ddlVacationType" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label8" runat="server" Text="الجنس : "></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label11" runat="server" Text="الأسم العربي :"></asp:Label>

                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:TextBox ID="txtFNameARS" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>

                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label12" runat="server" Text=" الأسم الإنكليزي :"></asp:Label>

                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:TextBox ID="txtFNameENS" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>

                                </div>
                            </div>

                            <asp:Panel ID="pnlJoinDate" runat="server">
                                <div class="row">
                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label13" runat="server" Text="تاريخ التعيين :"></asp:Label>

                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:TextBox ID="txtJoinDateFrom" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="txtJoinDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtJoinDateFrom" PopupPosition="BottomRight" Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>
                                    </div>
                                    <div class="col-6 col-md-3">

                                        <asp:Label CssClass="lbl" Width="100%" ID="Label14" runat="server" Text="إلى :"></asp:Label>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:TextBox ID="txtJoinDateTo" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender9" runat="server" Enabled="True" TargetControlID="txtJoinDateTo" PopupPosition="BottomRight" Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlEmployeementStartDate" runat="server">
                                <div class="row">
                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label15" runat="server" Text="تاريخ المباشرة من :"></asp:Label>

                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:TextBox ID="txtEmployeementStartDateFrom" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtEmployeementStartDateFrom" PopupPosition="BottomRight" Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label16" runat="server" Text=" إلى :"></asp:Label>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:TextBox ID="txtEmployeementStartDateTo" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" Enabled="True" TargetControlID="txtEmployeementStartDateTo" PopupPosition="BottomRight" Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlBirthDate" runat="server">
                                <div class="row">

                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label17" runat="server" Text=" تاريخ الميلاد :"></asp:Label>

                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:TextBox ID="txMDirrthDateFrom" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="txMDirrthDateFrom" PopupPosition="BottomRight" Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>
                                    </div>

                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label18" runat="server" Text="إلى :"></asp:Label>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:TextBox ID="txMDirrthDateTo" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender8" runat="server" Enabled="True" TargetControlID="txMDirrthDateTo" PopupPosition="BottomRight" Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlLeaveDate" runat="server">
                                <div class="row">

                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label19" runat="server" Text="تاريخ الانفكاك من :"></asp:Label>

                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:TextBox ID="txtLeaveDateFrom" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" TargetControlID="txtLeaveDateFrom" PopupPosition="BottomRight" Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label20" runat="server" Text="إلى :"></asp:Label>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:TextBox ID="txtLeaveDateTo" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" Enabled="True" TargetControlID="txtLeaveDateTo" PopupPosition="BottomRight" Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlStartDate" runat="server">
                                <div class="row">

                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label21" runat="server" Text="تاريخ الاجازة :"></asp:Label>

                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:TextBox ID="txtStartDate" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" TargetControlID="txtStartDate" PopupPosition="BottomRight" Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label22" runat="server" Text="إلى :"></asp:Label>

                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:TextBox ID="txtEndDate" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" Enabled="True" TargetControlID="txtEndDate" PopupPosition="BottomRight" Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlOrderDate" runat="server">
                                <div class="row">

                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label23" runat="server" Text="تاريخ الامر \ الطلب\ الحضور :"></asp:Label>

                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:TextBox ID="txtOrderDateFrom" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender10" runat="server" Enabled="True" TargetControlID="txtOrderDateFrom" PopupPosition="BottomRight" Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label24" runat="server" Text="إلى :"></asp:Label>

                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:TextBox ID="txtOrderDateTo" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender11" runat="server" Enabled="True" TargetControlID="txtOrderDateTo" PopupPosition="BottomRight" Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlIDNo" runat="server">
                                <div class="row">
                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label25" runat="server" Text="رقم الهوية :"></asp:Label>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:TextBox ID="txtID_No" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                                    </div>
                                    <div class="col-6 col-md-3"></div>
                                    <div class="col-6 col-md-3"></div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlEmployee" runat="server">
                                <div class="row">
                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label26" runat="server" Text="موظفي الملاك؟ :"></asp:Label>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:RadioButtonList ID="rblEmployees" runat="server">
                                            <asp:ListItem Value="true" Text="موظفي الملاك"></asp:ListItem>
                                            <asp:ListItem Value="false" Text="العقود"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="col-6 col-md-3"></div>
                                    <div class="col-6 col-md-3"></div>
                                </div>
                            </asp:Panel>
                            <div class="row">
                                <div class="col-6 col-md-3"></div>
                                <div class="col-6 col-md-3">
                                    <asp:Button Style="font-size: unset;" ID="btnGenrate" runat="server" Text="سحب التقرير" CssClass="btn btn-primary" Width="100%" OnClick="btnGenrate_Click" ValidationGroup="Submit" />
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:Button Style="font-size: unset;" ID="btnPrint" runat="server" Text="طباعة التقرير" CssClass="btn btn-primary" Width="100%" OnClick="btnPrint_Click" ValidationGroup="Submit" />
                                </div>
                                <div class="col-6 col-md-3"></div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">صيغة الملف :</div>
                                <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="ddlFormat" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%">
                                        <asp:ListItem Selected="True" Value="0">يرجى الأختيار</asp:ListItem>
                                        <asp:ListItem Value="1">Adobe PDF</asp:ListItem>
                                        <asp:ListItem Value="2">Microsoft Excel</asp:ListItem>
                                        <asp:ListItem Value="3">Microsoft Excel (Data Only)</asp:ListItem>
                                        <asp:ListItem Value="4">Rich Text File</asp:ListItem>
                                        <asp:ListItem Value="5" Enabled="False">Seperated Values</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:Button Style="font-size: unset;" ID="btnExport" runat="server" Text="حفظ التقرير" CssClass="btn btn-primary" Width="100%" OnClick="btnExport_Click" ValidationGroup="Submit" />
                                </div>
                                <div class="col-6 col-md-3"></div>
                            </div>
                            <div class="row">
                                <iframe runat="server" id="iFramePdf" height="600" width="800" style="display: none"></iframe>
                            </div>
                 
<div class="row">
                                <div class="col-6 col-md-12">
                                    <center>
                                        <CR:CrystalReportViewer ID="crvReports" runat="server" AutoDataBind="True" Height="50px" ToolPanelWidth="200px" Width="350px" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"
                                            HasCrystalLogo="False" HasRefreshButton="True" HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False" SeparatePages="False" ToolPanelView="None"
                                            GroupTreeStyle-ShowLines="False" OnLoad="CrystalReportViewer1_Load" PrintMode="Pdf" Visible="False" HasExportButton="False" HasPrintButton="False" HasSearchButton="True" />
                                    </center>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
