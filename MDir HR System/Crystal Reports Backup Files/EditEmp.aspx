<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="EditEmp.aspx.cs" Inherits="HR_Salaries.Pages.Employee.EditEmployee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Panel ID="pSearch" runat="server" DefaultButton="btnSubmit">
        <div class="row" style="text-align: center">
            <asp:RegularExpressionValidator ID="uplValidator" runat="server" ControlToValidate="fuPhoto"
                ErrorMessage="only jpg, bmp & gif formats are allowed"
                ValidationExpression="(.+\.([Jj][Pp][Gg])|.+\.([Bb][Mm][Pp])|.+\.([Gg][Ii][Ff]))" CssClass="Error" ForeColor=""></asp:RegularExpressionValidator>

            <br />

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
                <asp:DropDownList ID="ddlNameEN" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlName_SelectedIndexChanged" CssClass="ddl">
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
    <asp:Panel ID="pEdit" runat="server" DefaultButton="btnSubmit" Enabled="False" BorderColor="#333333">
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
                <asp:Label ID="Label36" runat="server" Text="الأسم الأول (أنكليزي) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtFNameEN" runat="server" MaxLength="20" CssClass="txtltr"></asp:TextBox>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label37" runat="server" Text="الأسم الأول (عربي) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtFNameAR" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label38" runat="server" Text="أسم الأب (أنكليزي) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtMNameEN" runat="server" MaxLength="20" CssClass="txtltr"></asp:TextBox>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label39" runat="server" Text="أسم الأب (عربي) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtMNameAR" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label40" runat="server" Text="اللقب (أنكليزي) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtLNameEN" runat="server" MaxLength="20" CssClass="txtltr"></asp:TextBox>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label41" runat="server" Text="اللقب (عربي) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtLNameAR" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label31" runat="server" Text="أسم الأم (أنكليزي) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtMotherNameEN" runat="server" MaxLength="20" CssClass="txtltr"></asp:TextBox>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label22" runat="server" Text="أسم الأم (عربي) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtMotherNameAR" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
            </div>
        </div>


        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label42" runat="server" Text="رقم الهاتف : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtPhone" runat="server" MaxLength="15" CssClass="txt"></asp:TextBox>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label43" runat="server" Text="عنوان السكن : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtAddress" runat="server" MaxLength="255" CssClass="txt"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label44" runat="server" Text="تاريخ الميلاد : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txMDirrthDate" runat="server" MaxLength="15" CssClass="txt" AutoPostBack="True" OnTextChanged="txtJoinDate_TextChanged"></asp:TextBox>
                <asp:CalendarExtender ID="txMDirrthDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txMDirrthDate" PopupPosition="BottomRight" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </div>

            <div class="columnleft">
                <asp:Label ID="Label45" runat="server" Text="تاريخ التعيين : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtJoinDate" runat="server" MaxLength="15" CssClass="txt" AutoPostBack="True" OnTextChanged="txtJoinDate_TextChanged"></asp:TextBox>
                <asp:CalendarExtender ID="txtJoinDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtJoinDate" PopupPosition="BottomRight" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
            </div>
        </div>
        <%--<div class="row">
            <div class="columnleft">
                <asp:Label ID="Label46" runat="server" Text="البريد الألكتروني الخاص : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtEmailPer" runat="server" MaxLength="255" CssClass="txt"></asp:TextBox>
            </div>

            <div class="columnleft">
                <asp:Label ID="Label47" runat="server" Text="البريد الألكتروني الداخلي : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtEmailInt" runat="server" MaxLength="255" CssClass="txt"></asp:TextBox>
            </div>
        </div>--%>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label48" runat="server" Text="التحصيل الدراسي : "></asp:Label>
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
                <asp:Label ID="Label49" runat="server" Text="الجنس : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlGender" runat="server" CssClass="ddl">
                </asp:DropDownList>
            </div>

            <div class="columnleft">
                <asp:Label ID="Label50" runat="server" Text="الحالة الزوجية : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlMarital" runat="server" CssClass="ddl">
                </asp:DropDownList>
            </div>
        </div>


        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label51" runat="server" Text="أسم الشخص للاتصال في الحالات الطارئة : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtContactName" runat="server" MaxLength="50" CssClass="txt"></asp:TextBox>
            </div>

            <div class="columnleft">
                <asp:Label ID="Label52" runat="server" Text="رقم الهاتف : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtContactPhone" runat="server" MaxLength="15" CssClass="txt"></asp:TextBox>
            </div>
        </div>


        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label53" runat="server" Text="عدد الأطفال : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtChildren" runat="server" MaxLength="2" CssClass="txt"></asp:TextBox>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label54" runat="server" Text="رقم الهاتف الداخلي : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtLandLine" runat="server" MaxLength="10" CssClass="txt"></asp:TextBox>
            </div>

        </div>

        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label55" runat="server" Text="صورة شخصية : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:FileUpload ID="fuPhoto" runat="server" Enabled="False" />

            </div>
            <div class="columnleft">
                <asp:Label ID="Label56" runat="server" Text="صنف الدم : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlBloodType" runat="server" CssClass="ddl">
                </asp:DropDownList>

            </div>
            <div class="columnleft">
                <asp:Label ID="Label2" runat="server" Text="رصيد الإجازات : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtVicationBalance" runat="server" CssClass="txt" MaxLength="3"></asp:TextBox>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label30" runat="server" Text="أخرى : "></asp:Label>
            </div>
            <div class="columnRight" style="text-align: right">
                <asp:CheckBox ID="chbIsActive" runat="server" Text="فعــــــــــال" Checked="True" />
                <br />
                <asp:CheckBox ID="chbIsBlocked" runat="server" Text="حجــــــــــب" />
            </div>
        </div>
        <div class="row">
            <div class="columnleft" style="vertical-align: top">
                <asp:Label ID="Label57" runat="server" Text="ملاحظات : "></asp:Label>
            </div>
            <div class="columnRight" style="width: 680px">
                <asp:TextBox ID="txtNotes" runat="server" Width="98%" TextMode="MultiLine" Height="51px" CssClass="txt"></asp:TextBox>
            </div>
        </div>
        <div class="row">
        </div>
        <div class="row">
            <asp:Button ID="btnSubmit" runat="server" Text="تعديل" CssClass="btn" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="btnCancel_Click" CausesValidation="False" UseSubmitBehavior="False" />
        </div>


    </asp:Panel>
</asp:Content>
