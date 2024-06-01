<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptTester.aspx.cs" Inherits="MDir_DMS.Reports.ReportSource.rptTester" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ToolkitScriptManager ID="ScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div class="row">
            <asp:Label ID="lblMessage" runat="server" CssClass="Error" Text=""></asp:Label>
        </div>
        <div>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="95%" Height="1800px">
                <LocalReport ReportEmbeddedResource="MDir_DMS.Reports.ReportSource.rdlcYearly.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="HRDataSetTableAdapters.DataTable1TableAdapter"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
