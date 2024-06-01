<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true"
    CodeBehind="NewEmp.aspx.cs" Inherits="HR_Salaries.Pages.Employee.NewEmp" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
        <br />
        <asp:RegularExpressionValidator ID="uplValidator" runat="server" ControlToValidate="fuPhoto"
            ErrorMessage="only jpg, bmp & gif formats are allowed"
            ValidationExpression="(.+\.([Jj][Pp][Gg])|.+\.([Bb][Mm][Pp])|.+\.([Gg][Ii][Ff]))"></asp:RegularExpressionValidator>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label10" runat="server" Text="الفرع : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlBranchs" runat="server" CssClass="ddl">
            </asp:DropDownList>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label11" runat="server" Text="القسم : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="ddl">
            </asp:DropDownList>
        </div>
    </div>

    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label30" runat="server" Text="الأسم الأول (عربي) : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtFNameAR" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label1" runat="server" Text="الأسم الأول (أنكليزي) : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtFNameEN" runat="server" MaxLength="20" CssClass="txtltr"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label31" runat="server" Text="أسم الأب (عربي) : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtMNameAR" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label4" runat="server" Text="أسم الأب (أنكليزي) : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtMNameEN" runat="server" MaxLength="20" CssClass="txtltr"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label32" runat="server" Text="اللقب (عربي) : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtLNameAR" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label3" runat="server" Text="اللقب (أنكليزي) : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtLNameEN" runat="server" MaxLength="20" CssClass="txtltr"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label22" runat="server" Text="أسم الأم (عربي) : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtMotherNameAR" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label7" runat="server" Text="أسم الأم (أنكليزي) : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtMotherNameEN" runat="server" MaxLength="20" CssClass="txtltr"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label6" runat="server" Text="رقم الهاتف : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtPhone" runat="server" MaxLength="15" CssClass="txt"></asp:TextBox>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label12" runat="server" Text="عنوان السكن : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtAddress" runat="server" MaxLength="255" CssClass="txt"></asp:TextBox>
        </div>
    </div>



    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label28" runat="server" Text="تاريخ الميلاد : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txMDirrthDate" runat="server" MaxLength="15" CssClass="txt" AutoPostBack="True" OnTextChanged="txtJoinDate_TextChanged"></asp:TextBox>
            <asp:CalendarExtender ID="txMDirrthDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txMDirrthDate" PopupPosition="BottomRight" Format="dd/MM/yyyy">
            </asp:CalendarExtender>
        </div>

        <div class="columnleft">
            <asp:Label ID="Label29" runat="server" Text="تاريخ التعيين : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtJoinDate" runat="server" MaxLength="15" CssClass="txt" AutoPostBack="True" OnTextChanged="txtJoinDate_TextChanged"></asp:TextBox>
            <asp:CalendarExtender ID="txtJoinDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtJoinDate" PopupPosition="BottomRight" Format="dd/MM/yyyy">
            </asp:CalendarExtender>
        </div>
    </div>


    <%--<div class="row">
        <div class="columnleft">
            <asp:Label ID="Label17" runat="server" Text="البريد الألكتروني الخاص : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtEmailPer" runat="server" MaxLength="255" CssClass="txt"></asp:TextBox>
        </div>

        <div class="columnleft">
            <asp:Label ID="Label18" runat="server" Text="البريد الألكتروني الداخلي : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtEmailInt" runat="server" MaxLength="255" CssClass="txt"></asp:TextBox>
        </div>
    </div>--%>


    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label13" runat="server" Text="التحصيل الدراسي : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlLicenseDigree" runat="server" CssClass="ddl">
            </asp:DropDownList>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label24" runat="server" Text="أسم الشهادة : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlLicenseName" runat="server" CssClass="ddl">
            </asp:DropDownList>
        </div>

    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label5" runat="server" Text="الجنس : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlGender" runat="server" CssClass="ddl">
            </asp:DropDownList>
        </div>

        <div class="columnleft">
            <asp:Label ID="Label2" runat="server" Text="الحالة الزوجية : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlMarital" runat="server" CssClass="ddl">
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label15" runat="server" Text="أسم الشخص للاتصال في الحالات الطارئة : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtContactName" runat="server" MaxLength="50" CssClass="txt"></asp:TextBox>
        </div>

        <div class="columnleft">
            <asp:Label ID="Label16" runat="server" Text="رقم الهاتف : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtContactPhone" runat="server" MaxLength="15" CssClass="txt"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label14" runat="server" Text="عدد الأطفال : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtChidrenNo" runat="server" MaxLength="2" CssClass="txt"></asp:TextBox>
        </div>
        <div class="columnleft">
            <asp:Label ID="Label19" runat="server" Text="رقم الهاتف الداخلي : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtLandLine" runat="server" MaxLength="10" CssClass="txt"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label20" runat="server" Text="صورة شخصية : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:FileUpload ID="fuPhoto" runat="server" />

        </div>

        <%--        <div class="columnleft">
            <asp:Label ID="Label21" runat="server" Text="Basic Salary : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtBasicSalary" runat="server"  MaxLength="8" TextMode="Number" CssClass="txt"></asp:TextBox>
        </div>

    </div>
    <div class="row">
        <div class="columnleft">
            <asp:Label ID="Label22" runat="server" Text="Visa Card No. : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:TextBox ID="txtVISANo" runat="server"  MaxLength="13" TextMode="Number" CssClass="txt"></asp:TextBox>
        </div>--%>
        <div class="columnleft">
            <asp:Label ID="Label23" runat="server" Text="صنف الدم : "></asp:Label>
        </div>
        <div class="columnRight">
            <asp:DropDownList ID="ddlBloodType" runat="server" CssClass="ddl">
            </asp:DropDownList>

        </div>
        <%--<div class="columnleft"></div>
        <div class="columnRight"></div>--%>
    </div>
    <div class="row">
        <div class="columnleft" style="vertical-align: top">
            <asp:Label ID="Label25" runat="server" Text="ملاحظات : "></asp:Label>
        </div>
        <div class="columnRight" style="width: 680px">
            <asp:TextBox ID="txtNotes" runat="server" Width="100%" TextMode="MultiLine" Height="51px" CssClass="txt"></asp:TextBox>
        </div>
    </div>
    <br />
    <div class="row">
        <asp:Button ID="btnSubmit" runat="server" Text="إضافة" CssClass="btn" OnClick="btnSubmit_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
