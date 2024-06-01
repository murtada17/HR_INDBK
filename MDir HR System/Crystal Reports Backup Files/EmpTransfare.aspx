<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="EmpTransfare.aspx.cs" Inherits="MDir_DMS.Pages.Employee.EmpTransfare" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <asp:Panel ID="pSearch" runat="server">
        <div class="row" style="text-align: center">

            <asp:Label ID="lblMessage" runat="server" CssClass="Error" Text=""></asp:Label><asp:HiddenField ID="hfEmpID" Value="0" runat="server" />
            <br />
        </div>
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
                <asp:Label ID="Label1" runat="server" Text="الاسم الكامل (أنكليزي) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlNameEN" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlName_SelectedIndexChanged" CssClass="ddlltr">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">

            <div class="columnleft"></div>
            <div class="columnRight"></div>
            <div class="columnleft"></div>
            <div class="columnRight">
                <asp:Button ID="btnGetInfo" runat="server" Text="جلب المعلومات" CssClass="btn" OnClick="btnGetInfo_Click" />
            </div>
        </div>
        <div class="row"></div>
    </asp:Panel>
    <hr />
    <asp:Panel ID="pEdit" runat="server" Enabled="False" BorderColor="#333333">
        <div class="row">
        </div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label35" runat="server" Text="الفرع : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlIBranchs" runat="server" CssClass="ddl">
                </asp:DropDownList>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label34" runat="server" Text="القسم : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlIDepartment" runat="server" CssClass="ddl">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label2" runat="server" Text="الشعبة : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlSection" runat="server" CssClass="ddl">
                </asp:DropDownList>
            </div>
            <div class="columnleft">
            </div>
            <div class="columnRight">
            </div>
        </div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label4" runat="server" Text="بموجب الأمر الإداري المرقم :"></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="txt"></asp:TextBox>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label6" runat="server" Text="بتاريخ :"></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtOrderDate" runat="server" CssClass="txt" CausesValidation="True">dd/MM/yyyy</asp:TextBox>
                <asp:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtOrderDate" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </div>
        </div>
        <div class="row">
            <div class="columnleft">
            </div>
            <div class="columnRight">
            </div>
            <div class="columnleft">
            </div>
            <div class="columnRight">
            </div>
        </div>

        <div class="row">
            
        <div class="columnleft" style="width: 99.61%" dir="rtl">
                <asp:GridView ID="gvTransformation" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="grid" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" AutoGenerateSelectButton="false"  AllowSorting="True" OnPageIndexChanging="gvTransformation_PageIndexChanging" OnSelectedIndexChanged="gvTransformation_SelectedIndexChanged" >
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
        </div>
        <div class="row">
            <asp:Button ID="btnTransfare" runat="server" Text="نقل" CssClass="btn" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnTempTran" runat="server" CssClass="btn" OnClick="btnSubmit_Click" Text="تنسيب" />
            <asp:Button ID="btnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="btnCancel_Click" CausesValidation="False" UseSubmitBehavior="False" />
        </div>


    </asp:Panel>
</asp:Content>
