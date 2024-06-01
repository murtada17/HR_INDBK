<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="MDir_DMS.Pages.Courses.Courses" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
    </div>
    <div class="row">
        <div class="row">
            <div class="columnleft">
                نوع العملية :
            </div>
            <div class="columnRight" style="text-align: right">
                <asp:RadioButton ID="RBAdd" runat="server" AutoPostBack="True" GroupName="type" OnCheckedChanged="RBAdd_CheckedChanged" Text="إضافة" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="RBEdit" runat="server" AutoPostBack="True" GroupName="type" OnCheckedChanged="RBAdd_CheckedChanged" Text="تعديل" />
            </div>
            <div class="columnleft">
            </div>
            <div class="columnRight">
            </div>
        </div>
    </div>
    <asp:Panel ID="pGrid" runat="server" DefaultButton="btnSubmit" Visible="false">
        <div class="row">
            <asp:GridView ID="gvCourses" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowSorting="True" CssClass="grid" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnPageIndexChanging="gvCourses_PageIndexChanging" OnSelectedIndexChanging="gvCourses_SelectedIndexChanging" AllowPaging="True">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#00959a" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
        </div>
    </asp:Panel>
    <asp:Panel ID="pForm" runat="server" DefaultButton="btnSubmit" BorderColor="#333333" Visible="false">
    <div class="row"></div>

    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label23" runat="server" Text="عنوان الدورة :"></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtCourseDesc" runat="server" CssClass="txt"></asp:TextBox>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label22" runat="server" Text="نوع الدورة :"></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlCourseType" runat="server" CssClass="ddl">
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label21" runat="server" Text="مكان انعقاد الدورة (دولة) : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlCountry" runat="server" CssClass="ddl">
            </asp:DropDownList>
        </div>

        <div class="columnleft">
            <asp:Label ID="Label24" runat="server" Text="مكان انعقاد الدورة (مدينة) :"></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlCity" runat="server" CssClass="ddl">
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label25" runat="server" Text="الجهة المنظمة للدورة :"></asp:Label>
        </div>
        <div class="columnRight" style="text-align: right">

            <asp:DropDownList ID="ddlinstitute" runat="server" CssClass="ddl">
            </asp:DropDownList>

        </div>

        <div class="columnleft">
            <asp:Label ID="Label1" runat="server" Text="اجور الدورة :"></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtFees" runat="server" CssClass="txt"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="columnleft">
        </div>
        <div class="columnRight" style="text-align: right">
        </div>

        <div class="columnleft">
            <asp:Label ID="Label7" runat="server" Text="العملة :"></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlCcy" runat="server" CssClass="ddl">
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label2" runat="server" Text="للفترة (من تاريخ) :"></asp:Label>
        </div>
        <div class="columnRight" style="text-align: right">

            <asp:TextBox ID="txtStartDate" runat="server" CssClass="txt"></asp:TextBox>

        </div>

        <div class="columnleft">
            <asp:Label ID="Label3" runat="server" Text="للفترة (إلى تاريخ) :"></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtEndDate" runat="server" CssClass="txt"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label30" runat="server" Text="رقم الامر الاداري :"></asp:Label>
        </div>
        <div class="columnRight" style="text-align: right">

            <asp:TextBox ID="txtOrderNo" runat="server" CssClass="txt"></asp:TextBox>

        </div>

        <div class="columnleft">
            <asp:Label ID="Label31" runat="server" Text="تاريخ الامر الاداري :"></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtOrderDate" runat="server" CssClass="txt"></asp:TextBox>
        </div>
    </div>
    <div class="row"></div>
    <div class="row">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" OnClick="btnSubmit_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="btnCancel_Click" CausesValidation="False" UseSubmitBehavior="False" />
    </div>
    <hr />

    <div class="row"></div>
    <div class="row">الموظفين المشاركين&nbsp;</div>
        <div class="row">
            <asp:GridView ID="gvCourseEmp" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowSorting="True" CssClass="grid" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnPageIndexChanging="gvCourseEmp_PageIndexChanging" OnSelectedIndexChanging="gvCourseEmp_SelectedIndexChanging" AllowPaging="True">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#00959a" Font-Bold="True" ForeColor="White" />
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
                <div class="columnleft">

                    <asp:Label ID="Label26" runat="server" Text="عنوان التخصيص (عربي) :"></asp:Label>

                </div>
                <div class="columnRight">

                    <asp:TextBox ID="txtValueDescAR" runat="server" CssClass="txt"></asp:TextBox>

                </div>
                <div class="columnleft">

                    <asp:Label ID="Label27" runat="server" Text="عنوان التخصيص (أنكليزي) :"></asp:Label>

                </div>
                <div class="columnRight">
                    <asp:TextBox ID="txtValueDescEN" runat="server" CssClass="txt"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="columnleft">
                    <asp:Label ID="Label28" runat="server" Text="مبلغ \ نسبة التخصيص :"></asp:Label>
                </div>
                <div class="columnRight">
                    <asp:TextBox ID="txtValue" runat="server" CssClass="txt"></asp:TextBox>
                </div>
                <div class="columnleft">
                    <asp:Label ID="Label29" runat="server" Text="فعال؟ :"></asp:Label>
                </div>
                <div class="columnRight" style="text-align: right">
                    <asp:CheckBox ID="chbValueActive" runat="server" />
                </div>
            </div>
        </asp:Panel>

        <div class="row"></div>
        <div class="row">
            <asp:Button ID="btnEdit" runat="server" Text="تعديل" CssClass="btn" OnClick="btnEdit_Click" />
        </div>
    </asp:Panel>
</asp:Content>
