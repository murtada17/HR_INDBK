<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true"
    CodeBehind="Employee.aspx.cs" Inherits="HR_Salaries.Pages.Employee.Employee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">



    <script type="text/javascript" language="javascript">

        window.onload = function () {
            readonly
        }
        function readonly() {
            txtDDate.Attributes.Add("readonly", "readonly")
        }
        $(function () {
            var name = $("#name"),
              allFields = $([]).add(name),
              tips = $(".validateTips");

            function updateTips(t) {
                tips
                  .text(t)
                  .addClass("ui-state-highlight");
                setTimeout(function () {
                    tips.removeClass("ui-state-highlight", 1500);
                }, 500);
            }

            function checkLength(o, n, min, max) {
                if (o.value.length > max || o.value.length < min) {
                    //o.addClass("ui-state-error");
                    updateTips(" طول " + n + " يجب ان يكون بين " +
                      min + " و " + max + ".");
                    return false;
                } else {
                    return true;
                }
            }

            $("#dialog-form").dialog({
                autoOpen: false,
                height: 300,
                width: 550,
                modal: true,
                buttons: {
                    "إلغاء": function () {
                        $(this).dialog("close");
                    },
                    "إضافة": function () {
                        var bValid = true;
                        //allFields.removeClass("ui-state-error");

                        // bValid = bValid && checkLength(LicenseNameAR, "اسم الشهادة (عربي)", 3, 55);
                        //  bValid = bValid && checkLength(LicenseNameEN, "اسم الشهادة (انكليزي)", 3, 55);

                        if (bValid) {
                            // var e = document.getElementById("ddlParent");
                            // var ParentID = e.options[e.selectedIndex].value;
                            //////////////
                            var obj = {};
                            var LicenseNameAR = $.trim($("[id*=LicenseNameAR]").val());
                            var LicenseNameEN = $.trim($("[id*=LicenseNameEN]").val());
                            $.ajax({
                                type: "POST",
                                data: { 'LicenseNameAR': LicenseNameAR, 'LicenseNameEN': LicenseNameEN },
                                url: "../../Script/WS1.asmx/AddLicense",
                                success: function (data) {
                                    if (data.d == 1) {
                                        window.location.reload();
                                        $(this).dialog("close");
                                    }
                                    else if (data.d == -1) {
                                        alert("حدث خطأ، الرجاء إعادة المحاولة.");
                                    }
                                    else if (data.d == 0) {
                                        alert("هذه الشهادة موجودة حاليا.");
                                    }
                                },
                                error: function (jqXHR, textStatus, errorThrown) {
                                    alert("The following error occured: " + textStatus + "-" + jqXHR + "-" + errorThrown, errorThrown + "___");
                                }
                            });
                            ////////////////// 
                            $(this).dialog("close");
                        }
                        else {
                            alert("الرجاء ملء جميع المعلومات.");
                        }
                    }
                },
                close: function () {
                    allFields.val("").removeClass("ui-state-error");
                }
            });

            $("#BtnAddLicense")
              .button()
              .click(function () {
                  $("#dialog-form").dialog("open");
                  return false;
              });

        });
    </script>

    <div id="dialog-form" title="إضافة شهادة جديدة" dir="rtl" style="font-family: 'Sakkal Majalla', Arial">
        <fieldset>
            <div class="row">
                <div class="columnleft">
                    <label for="name">أسم الشهادة (عربي)</label>
                </div>
                <div class="columnRight">
                    <input type="text" name="name" id="LicenseNameAR" class="txt" />
                </div>
                <div class="columnleft">
                    <label for="name">أسم الشهادة (أنكليزي)</label>
                </div>
                <div class="columnRight">
                    <input type="text" name="name" id="LicenseNameEN" class="txt" />
                </div>
            </div>
            <div class="row" style="display: none;">
                <div class="columnleft">
                    <label for="name">المؤسسة الأم</label>
                </div>
                <div class="columnRight">
                    <select name="ddlParent" runat="server" id="ddlParent" class=" ddl">
                        <option value="0">مؤسسة ام</option>
                    </select>
                </div>
            </div>
        </fieldset>
    </div>

    <div class="row" style="text-align: center">
        <asp:RegularExpressionValidator ID="uplValidator" runat="server" ControlToValidate="fuPhoto"
            ErrorMessage="only jpg, bmp & gif formats are allowed"
            ValidationExpression="(.+\.([Jj][Pp][Gg])|.+\.([Bb][Mm][Pp])|.+\.([Gg][Ii][Ff]))" CssClass="Error" ForeColor=""></asp:RegularExpressionValidator>

        <br />

        <asp:Label ID="lblMessage" runat="server" CssClass="Error" Text=""></asp:Label><asp:HiddenField ID="hfEmpID" Value="0" runat="server" />

    </div>
    <div class="row">
        <div class="columnleft">
            نوع العملية :
        </div>
        <div class="columnRight" style="text-align: right">
            <asp:RadioButton ID="RBAdd" runat="server" GroupName="type" Text="إضافة" OnCheckedChanged="RBAdd_CheckedChanged" AutoPostBack="True" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="RBEdit" runat="server" GroupName="type" Text="تعديل" OnCheckedChanged="RBAdd_CheckedChanged" AutoPostBack="True" />

        </div>
        <div class="columnleft">
        </div>
        <div class="columnRight">
        </div>
    </div>

    <asp:Panel ID="pGrid" runat="server" DefaultButton="btnSubmit" Visible="false">
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
                <asp:Label ID="Label3" runat="server" Text="الشعبة : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlSection" CssClass="ddl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSBranch_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="columnleft">
                رقم الهوية
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtsID_No" runat="server" MaxLength="20" CssClass="txt" AutoPostBack="True" OnTextChanged="ddlSBranch_SelectedIndexChanged"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="columnleft">
                الأسم العربي :
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtFNameARS" runat="server" MaxLength="20" CssClass="txt" AutoPostBack="True" OnTextChanged="ddlSBranch_SelectedIndexChanged"></asp:TextBox>

            </div>
            <div class="columnleft">
                ترتيب بحسب :
            </div>
            <div class="columnRight">
                <asp:RadioButton ID="RBName" runat="server" GroupName="SortType" Text="الاسم" AutoPostBack="True" OnCheckedChanged="ddlSBranch_SelectedIndexChanged" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="RBDate" runat="server" GroupName="SortType" Text="تاريخ التعيين" AutoPostBack="True" OnCheckedChanged="ddlSBranch_SelectedIndexChanged" />

            </div>
        </div>
        <div class="row">
            <div class="columnleft" style="width: 99.61%" dir="rtl">
                <asp:GridView ID="gvEmployees" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="grid" AutoGenerateColumns="False" AutoGenerateDeleteButton="False" AutoGenerateSelectButton="True" OnSelectedIndexChanging="gvEmployees_SelectedIndexChanging" OnPageIndexChanging="gvEmployees_PageIndexChanging" AllowSorting="True">
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
    </asp:Panel>
    <asp:Panel ID="pForm" runat="server" DefaultButton="btnSubmit" BorderColor="#333333" Visible="false">
        <div class="row">
        </div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label35" runat="server" Text="الفرع : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlIBranchs" runat="server" CssClass="ddl">
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlIBranchs" Display="Dynamic" ErrorMessage="الرجاء اختيار الفرع" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="Submit" ValueToCompare="0">* الرجاء اختيار الفرع</asp:CompareValidator>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label34" runat="server" Text="القسم : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlIDepartment" runat="server" CssClass="ddl" AutoPostBack="True" OnSelectedIndexChanged="ddlIDepartment_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlIDepartment" Display="Dynamic" ErrorMessage="الرجاء اختيار القسم" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="Submit" ValueToCompare="0">* الرجاء اختيار القسم</asp:CompareValidator>
            </div>
        </div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label1" runat="server" Text="الشعبة : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlISection" runat="server" CssClass="ddl">
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToValidate="ddlISection" Display="Dynamic" ErrorMessage="الرجاء اختيار الفرع" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="Submit" ValueToCompare="0">* الرجاء اختيار الشعبة</asp:CompareValidator>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label58" runat="server" Text="الجنس : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlGender" runat="server" CssClass="ddl">
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator9" runat="server" ControlToValidate="ddlGender" Display="Dynamic" ErrorMessage=" الرجاء اختيار الجنس" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="Submit" ValueToCompare="0">*  الرجاء اختيار الجنس</asp:CompareValidator>
            </div>
        </div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label36" runat="server" Text="الأسم الأول (أنكليزي) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtFNameEN" runat="server" MaxLength="20" CssClass="txtltr"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFNameEN" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Submit">* الرجاء ادخال الاسم</asp:RequiredFieldValidator>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label37" runat="server" Text="الأسم الأول (عربي) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtFNameAR" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFNameAR" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Submit">* الرجاء ادخال الاسم</asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label38" runat="server" Text="أسم الأب (أنكليزي) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtMNameEN" runat="server" MaxLength="20" CssClass="txtltr"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMNameEN" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Submit">* الرجاء ادخال الاسم</asp:RequiredFieldValidator>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label39" runat="server" Text="أسم الأب (عربي) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtMNameAR" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMNameAR" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Submit">* الرجاء ادخال الاسم</asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label40" runat="server" Text="اللقب (أنكليزي) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtLNameEN" runat="server" MaxLength="20" CssClass="txtltr"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLNameEN" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Submit">* الرجاء ادخال الاسم</asp:RequiredFieldValidator>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label41" runat="server" Text="اللقب (عربي) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtLNameAR" runat="server" MaxLength="20" CssClass="txt"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtLNameAR" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Submit">* الرجاء ادخال الاسم</asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPhone" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Submit">* الرجاء ادخال رقم الهاتف</asp:RequiredFieldValidator>
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
                <asp:Label ID="Label59" runat="server" Text="بموجب الامر الاداري المرقم : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtAdminOrderNo" runat="server" CssClass="txt" MaxLength="15"></asp:TextBox>
            </div>

            <div class="columnleft">
                <asp:Label ID="Label50" runat="server" Text="الحالة الزوجية : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlMarital" runat="server" CssClass="ddl">
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="ddlMarital" Display="Dynamic" ErrorMessage=" الرجاء اختيار الحالة الزوجية" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="Submit" ValueToCompare="0">*  الرجاء اختيار الحالة الزوجية</asp:CompareValidator>
            </div>
        </div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label48" runat="server" Text="التحصيل الدراسي : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlLicenseDigree" runat="server" CssClass="ddl">
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="ddlLicenseDigree" Display="Dynamic" ErrorMessage=" الرجاء اختيار التحصيل الدراسي" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="Submit" ValueToCompare="0">* الرجاء اختيار التحصيل الدراسي</asp:CompareValidator>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label24" runat="server" Text="أسم الشهادة : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlLicenseName" runat="server" CssClass="ddl" Width="84.4%">
                </asp:DropDownList>
                <button id="BtnAddLicense" style="width: 27px; text-align: right; height: 27px;">
                    <img alt="" src="../../img/Visualpharm-Must-Have-Add.ico" width="25px" height="25px" />
                </button>

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
                <asp:Label ID="Label7" runat="server" Text="رقم الهوية : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtIdNo" runat="server" MaxLength="10" CssClass="txt"></asp:TextBox>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label56" runat="server" Text="صنف الدم : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlBloodType" runat="server" CssClass="ddl">
                </asp:DropDownList>

            </div>
        </div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label6" runat="server" Text="نسخة من المستمسكات : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:FileUpload ID="fuDocs" runat="server" />
            </div>
            <div class="columnleft">
                <asp:Label ID="Label55" runat="server" Text="صورة شخصية : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:FileUpload ID="fuPhoto" runat="server" />

            </div>
        </div>

        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label2" runat="server" Text="رصيد الإجازات : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtVicationBalance" runat="server" CssClass="txt" MaxLength="3"></asp:TextBox>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label4" runat="server" Text="تاريخ الاستحقاق : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtMaturityDate" runat="server" CssClass="txt"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtMaturityDate" PopupPosition="BottomRight" Format="yyyy-MM-dd">
                </asp:CalendarExtender>
            </div>
        </div>
        <div class="row">

            <div class="columnleft">
                <asp:Label ID="Label5" runat="server" Text="منصب : "></asp:Label>
            </div>
            <div class="columnRight" style="text-align: right">
                <asp:CheckBox ID="chbIsCEOAssist" runat="server" Text="معاون مدير عام" />
                <br />
                <asp:CheckBox ID="chbIsManager" runat="server" Text="مدير قسم \ مدير فرع" />
                <br />
                <asp:CheckBox ID="chbIsManagerAssist" runat="server" Text="معاون مدير قسم \ معاون مدير فرع" />
                <br />
                <asp:CheckBox ID="chbIsSectionManager" runat="server" Text="مسؤول شعبة" />
            </div>
            <div class="columnleft">
                <asp:Label ID="Label30" runat="server" Text="أخرى : "></asp:Label>
            </div>
            <div class="columnRight" style="text-align: right">
                <asp:CheckBox ID="chbIsActive" runat="server" Text="فعــــــــــال" Checked="True" />
                <br />
                <asp:CheckBox ID="chbIsBlocked" runat="server" Text="حجــــــــــب" />
                <br />
                <asp:CheckBox ID="chbIsActing" runat="server" Text="وكالــــــة" />
                <br />
                <asp:CheckBox ID="chbIsTemp" runat="server" Text="منسب من جهة خارجية" />

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
            <div runat="server" id="links" style="direction: ltr"></div>
        </div>
        <div class="row">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Submit" ShowSummary="False" />
        </div>
        <div class="row">
            <asp:Button ID="btnSubmit" runat="server" Text="تعديل" CssClass="btn" OnClick="btnSubmit_Click" ValidationGroup="Submit" />
            <asp:Button ID="btnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="btnCancel_Click" CausesValidation="False" UseSubmitBehavior="False" />
        </div>


    </asp:Panel>
</asp:Content>
