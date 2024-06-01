<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="Payments.aspx.cs" Inherits="HR_Salaries.Pages.Salaries.Payments" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <div class="row" style="text-align: center">
            <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
            <br />

        </div>
        <div class="row"></div>
        <div class="row">
            <div class="col-md-3">
                <asp:Label CssClass="lbl" Width="100%" ID="Label2" runat="server" Text="فئة الترحيل : "></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:RadioButtonList ID="rblType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblType_SelectedIndexChanged">
                    <asp:ListItem Value="false">موظفي الملاك</asp:ListItem>
                    <asp:ListItem Value="true">العقود</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="col-md-3">

            </div>
            <div class="col-md-3">
            </div>
        </div>
        <div class="row"></div>
        <div class="row">
            <div class="col-6 col-md-12">
                <center>
                    <CR:CrystalReportViewer ID="crvReports" runat="server" AutoDataBind="True" Height="50px" ToolPanelWidth="200px" Width="350px" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"
                        HasCrystalLogo="False" HasRefreshButton="True" HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False" SeparatePages="False" ToolPanelView="None"
                        GroupTreeStyle-ShowLines="False" PrintMode="Pdf" Visible="False" HasSearchButton="True" />
                </center>
            </div>
        </div>
        <div class="row">
        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:Label CssClass="lbl" Width="100%" ID="Label35" runat="server" Text="الشهر : "></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="ddlMonths" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%">
                    <asp:ListItem Value="0">يرجى الاختيار</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlMonths" Display="Dynamic" ErrorMessage="الرجاء اختيار الشهر" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="Submit" ValueToCompare="0">* الرجاء اختيار الفرع</asp:CompareValidator>
            </div>
            <div class="col-md-3">
                <asp:Label CssClass="lbl" Width="100%" ID="Label34" runat="server" Text="السنة : "></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtYear" runat="server" MaxLength="20" Style="text-align: left;" CssClass="txt"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtYear" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Submit">* الرجاء ادخال السنة</asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:Label CssClass="lbl" Width="100%" ID="Label1" runat="server" Text="الرمز التعريفي : "></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtReference" runat="server" MaxLength="5" Style="text-align: left;" CssClass="txt"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtYear" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Submit">* الرجاء ادخال السنة</asp:RequiredFieldValidator>
            </div>

            <div class="col-md-3">
            </div>
            <div class="col-md-3">
            </div>
        </div>
        <div class="row">
            <div class="col-6 col-md-3"></div>
            <div class="col-6 col-md-3">
                <asp:Button Style="font-size: unset;" ID="btnSubmit" runat="server" Text="ترحيل" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
            </div>
            <div class="col-6 col-md-3"></div>
            <div class="col-6 col-md-3">
                <asp:Button Style="font-size: unset;" ID="btnCancel" runat="server" Text="إلغاء" CssClass="btn btn-primary" OnClick="btnCancel_Click" CausesValidation="False" UseSubmitBehavior="False" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-3" style="width: 99.61%" dir="rtl">
                <asp:GridView ID="gvPayment" runat="server" BackColor="White" BorderColor="#CCCCCC"
                    BorderStyle="None" BorderWidth="1px" CellPadding="3"
                    CssClass="table table-striped table-bordered table-condensed"
                    AutoGenerateColumns="False" AutoGenerateDeleteButton="False"
                    AutoGenerateSelectButton="True" AllowSorting="True">
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
        </div>
    </div>
</asp:Content>
