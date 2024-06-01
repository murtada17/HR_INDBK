<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="EmpSalary.aspx.cs" Inherits="HR_Salaries.Pages.Allowances.Allowances" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
        <br />
    </div>
    <asp:Panel ID="pSearch" runat="server" DefaultButton="btnSubmit">
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label32" runat="server" Text="الفرع : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlSBranch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSBranch_SelectedIndexChanged" CssClass="ddl">
                </asp:DropDownList>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label33" runat="server" Text="القسم : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlSDep" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSBranch_SelectedIndexChanged" CssClass="ddl">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label27" runat="server" Text="الاسم الكامل (عربي) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlNameAR" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlName_SelectedIndexChanged" CssClass="ddl">
                </asp:DropDownList>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label6" runat="server" Text="الاسم الكامل (أنكليزي) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlNameEN" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlName_SelectedIndexChanged" CssClass="ddl">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">

            <div class="columnleft"></div>
            <div class="columnRight"></div>
            <div class="columnleft"></div>
            <div class="columnRight" style="text-align: right">
                <asp:Button ID="btnGetInfo" runat="server" Text="جلب المعلومات" CssClass="btn" OnClick="btnGetInfo_Click" />
            </div>
        </div>
        <div class="row"></div>
    </asp:Panel>
    <asp:Panel ID="pnlData" runat="server" Enabled="False" CssClass="pnl">
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label21" runat="server" Text="الراتب الأسمي : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtBasicSalary" runat="server" MaxLength="8" CssClass="txt"></asp:TextBox>
            </div>

            <div class="columnleft">
                <asp:Label ID="Label22" runat="server" Text="رقم بطاقة VISA : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtVISANo" runat="server" MaxLength="13" CssClass="txt"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label1" runat="server" Text="بموجب الأمر الإداري :"></asp:Label>
            </div>
            <div class="columnRight">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </div>

            <div class="columnleft">
                <asp:Label ID="Label2" runat="server" Text="المرقم :"></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="txt"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label5" runat="server" Text="بعنوان :"></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtOrderDesc" runat="server" CssClass="txt"></asp:TextBox>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label7" runat="server" Text="بتاريخ :"></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtOrderDate" runat="server" CssClass="txt">dd/MM/yyyy</asp:TextBox>
                <asp:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtOrderDate" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </div>
        </div>

        <div class="row">
            <div class="columnleft"></div>
            <div class="columnRight"></div>
            <div class="columnleft"></div>
            <div class="columnRight" style="text-align: right">
                <asp:Button ID="btnSubmit" runat="server" Text="موافق" CssClass="btn" OnClick="btnSubmit_Click" />
            </div>
        </div>
        <div class="row">
        </div>
        <div class="row">
            <asp:GridView ID="gvValues" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="grid" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" OnRowDeleting="gvValues_RowDeleting" AutoGenerateSelectButton="True" OnSelectedIndexChanging="gvValues_SelectedIndexChanging">
                <EditRowStyle Wrap="false" />
                <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>
                <HeaderStyle BackColor="#00959a" Font-Bold="True" ForeColor="White"></HeaderStyle>
                <PagerStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>
                <RowStyle ForeColor="#000066"></RowStyle>
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>
                <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>
                <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>
                <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
            </asp:GridView>
        </div>
        <div class="row">
        </div>

        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label3" runat="server" Text="أنواع المخصصات : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlValues" runat="server" CssClass="ddl" OnSelectedIndexChanged="ddlValues_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
            </div>

            <div class="columnleft">
                <asp:Label ID="Label4" runat="server" Text="المخصصات : "></asp:Label>
            </div>
            <div class="columnRight">

                <asp:RadioButtonList ID="chblAllowance" runat="server">
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="row">
            <div class="columnleft"></div>
            <div class="columnRight"></div>
            <div class="columnleft"></div>
            <div class="columnRight" style="text-align: right">
                <asp:Button ID="btnAddAllwoance" runat="server" Text="موافق" CssClass="btn" OnClick="btnAddAllwoance_Click" />
            </div>
        </div>
        <div class="row">
            <asp:Button ID="btnCancel" runat="server" Text="إختيار موظف آخر" CssClass="btnCancel" OnClick="btnCancel_Click" CausesValidation="False" UseSubmitBehavior="False" />
        </div>
        <br />
    </asp:Panel>
</asp:Content>

