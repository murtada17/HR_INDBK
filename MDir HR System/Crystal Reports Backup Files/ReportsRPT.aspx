<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="ReportsRPT.aspx.cs" Inherits="MDir_DMS.Reports.ReportsRPT" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

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
    <iframe id="iFrame2Pdf" runat="server" style="display: none;"></iframe>
    <div class="row">
        <asp:Label ID="lblMessage" runat="server" CssClass="Error" Text=""></asp:Label>
    </div>
    <div class="row">
        <div class="columnleft"></div>
        <div class="columnRight"></div>
        <div class="columnleft"></div>
        <div class="columnRight"></div>
    </div>

    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label1" runat="server" Text="التقرير : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlReport" runat="server" AutoPostBack="True" CssClass="ddl" OnSelectedIndexChanged="ddlReport_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label4" runat="server" Text="نوع الأمر الاداري :"></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlOrderType" runat="server" CssClass="ddl">
            </asp:DropDownList>
        </div>
    </div>

    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label2" runat="server" Text="الدرجة العلمية :"></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlLicenseDigree" runat="server" CssClass="ddl">
            </asp:DropDownList>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label3" runat="server" Text="أسم الشهادة :"></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlLicenseName" runat="server" CssClass="ddl">
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label32" runat="server" Text="الفرع : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlSBranch" runat="server" CssClass="ddl">
            </asp:DropDownList>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label33" runat="server" Text="القسم : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlSDep" runat="server" CssClass="ddl">
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label9" runat="server" Text="الفرع للامر الاداري : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlOtherBranch" runat="server" CssClass="ddl">
            </asp:DropDownList>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label10" runat="server" Text="القسم للامر الاداري : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlOtherDep" runat="server" CssClass="ddl">
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label5" runat="server" Text="الشعبة : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlSection" runat="server" CssClass="ddl">
            </asp:DropDownList>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label6" runat="server" Text="سبب قطع علاقة العمل : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlResignReason" runat="server" CssClass="ddl">
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label7" runat="server" Text="نوع الاجازة : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlVacationType" runat="server" CssClass="ddl">
            </asp:DropDownList>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label8" runat="server" Text="الجنس : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlGender" runat="server" CssClass="ddl">
            </asp:DropDownList>
        </div>
    </div>

    <div class="row">
        <div class="columnleft">
            الأسم العربي :
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtFNameARS" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>

        </div>
        <div class="columnleft">
            الأسم الإنكليزي :
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtFNameENS" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>

        </div>
    </div>

    <asp:Panel ID="pnlJoinDate" runat="server">
        <div class="row">
            <div class="columnleft">
                تاريخ التعيين :
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtJoinDateFrom" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="txtJoinDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtJoinDateFrom" PopupPosition="BottomRight" Format="yyyy/MM/dd">
                </ajaxToolkit:CalendarExtender>
            </div>
            <div class="columnleft">إلى :</div>
            <div class="columnRight">
                <asp:TextBox ID="txtJoinDateTo" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender9" runat="server" Enabled="True" TargetControlID="txtJoinDateTo" PopupPosition="BottomRight" Format="yyyy/MM/dd">
                </ajaxToolkit:CalendarExtender>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlEmployeementStartDate" runat="server">
        <div class="row">
            <div class="columnleft">
                تاريخ المباشرة من :
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtEmployeementStartDateFrom" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtEmployeementStartDateFrom" PopupPosition="BottomRight" Format="yyyy/MM/dd">
                </ajaxToolkit:CalendarExtender>
            </div>
            <div class="columnleft">إلى :</div>
            <div class="columnRight">
                <asp:TextBox ID="txtEmployeementStartDateTo" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" Enabled="True" TargetControlID="txtEmployeementStartDateTo" PopupPosition="BottomRight" Format="yyyy/MM/dd">
                </ajaxToolkit:CalendarExtender>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlBirthDate" runat="server">
        <div class="row">

            <div class="columnleft">
                تاريخ الميلاد :
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txMDirrthDateFrom" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" TargetControlID="txMDirrthDateFrom" PopupPosition="BottomRight" Format="yyyy/MM/dd">
                </ajaxToolkit:CalendarExtender>
            </div>

            <div class="columnleft">إلى :</div>
            <div class="columnRight">
                <asp:TextBox ID="txMDirrthDateTo" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender8" runat="server" Enabled="True" TargetControlID="txMDirrthDateTo" PopupPosition="BottomRight" Format="yyyy/MM/dd">
                </ajaxToolkit:CalendarExtender>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlLeaveDate" runat="server">
        <div class="row">

            <div class="columnleft">
                تاريخ الانفكاك من :
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtLeaveDateFrom" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" TargetControlID="txtLeaveDateFrom" PopupPosition="BottomRight" Format="yyyy/MM/dd">
                </ajaxToolkit:CalendarExtender>
            </div>
            <div class="columnleft">إلى :</div>
            <div class="columnRight">
                <asp:TextBox ID="txtLeaveDateTo" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" Enabled="True" TargetControlID="txtLeaveDateTo" PopupPosition="BottomRight" Format="yyyy/MM/dd">
                </ajaxToolkit:CalendarExtender>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlStartDate" runat="server">
        <div class="row">

            <div class="columnleft">
                تاريخ الاجازة :
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtStartDate" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" TargetControlID="txtStartDate" PopupPosition="BottomRight" Format="yyyy/MM/dd">
                </ajaxToolkit:CalendarExtender>
            </div>
            <div class="columnleft">
                إلى :
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtEndDate" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" Enabled="True" TargetControlID="txtEndDate" PopupPosition="BottomRight" Format="yyyy/MM/dd">
                </ajaxToolkit:CalendarExtender>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlOrderDate" runat="server">
        <div class="row">

            <div class="columnleft">
                تاريخ الامر \ الطلب\ الحضور :
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtOrderDateFrom" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender10" runat="server" Enabled="True" TargetControlID="txtOrderDateFrom" PopupPosition="BottomRight" Format="yyyy/MM/dd">
                </ajaxToolkit:CalendarExtender>
            </div>
            <div class="columnleft">
                إلى :
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtOrderDateTo" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender11" runat="server" Enabled="True" TargetControlID="txtOrderDateTo" PopupPosition="BottomRight" Format="yyyy/MM/dd">
                </ajaxToolkit:CalendarExtender>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlIDNo" runat="server">
        <div class="row">
            <div class="columnleft">رقم الهوية</div>
            <div class="columnRight">
                <asp:TextBox ID="txtID_No" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
            </div>
            <div class="columnleft"></div>
            <div class="columnRight"></div>
        </div>
    </asp:Panel>
    <div class="row">
        <div class="columnleft"></div>
        <div class="columnRight"></div>
        <div class="columnleft"></div>
        <div class="columnRight"></div>
    </div>
    <div class="row">
        <asp:Button ID="btnGenrate" runat="server" Text="سحب التقرير" CssClass="btn" OnClick="btnGenrate_Click" ValidationGroup="Submit" />
        <asp:Button ID="btnPrint" runat="server" Text="طباعة التقرير" CssClass="btn" OnClick="btnPrint_Click" ValidationGroup="Submit" />

    </div>
    <div class="row">
        <div class="columnleft">صيغة الملف :</div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlFormat" runat="server" CssClass="ddl">
                <asp:ListItem Selected="True" Value="0">يرجى الأختيار</asp:ListItem>
                <asp:ListItem Value="1">Adobe PDF</asp:ListItem>
                <asp:ListItem Value="2">Microsoft Excel</asp:ListItem>
                <asp:ListItem Value="3">Microsoft Excel (Data Only)</asp:ListItem>
                <asp:ListItem Value="4">Rich Text File</asp:ListItem>
                <asp:ListItem Value="5" Enabled="False">Seperated Values</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="columnleft">
            <asp:Button ID="btnExport" runat="server" Text="حفظ التقرير" CssClass="btn" OnClick="btnExport_Click" ValidationGroup="Submit" />
        </div>
        <div class="columnRight"></div>
    </div>
    <div class="row"></div>
    <div class="row">
        <center>
            <CR:CrystalReportViewer ID="crvReports" runat="server" AutoDataBind="True" Height="50px" ToolPanelWidth="200px" Width="350px" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"
                HasCrystalLogo="False" HasRefreshButton="True" HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False" SeparatePages="False" ToolPanelView="None"
                GroupTreeStyle-ShowLines="False" OnLoad="CrystalReportViewer1_Load" PrintMode="Pdf" Visible="False" HasExportButton="False" HasPrintButton="False" HasSearchButton="True" />
        </center>
    </div>
</asp:Content>
