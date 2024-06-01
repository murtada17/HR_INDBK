<%@ Page Title="إضافة\ تعديل موظف" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true"
    CodeBehind="Employee.aspx.cs" Inherits="HR_Salaries.Pages.Employee.Employee" %>
<%@ MasterType VirtualPath="~/Pages/MDirMaster.Master" %> 

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript" language="javascript">

        window.onload = function () {
            readonly
        }
        function readonly() {
            txtDDate.Attributes.Add("readonly", "readonly")
        }
        jQuery_ui(function () {
            var name = jQuery_ui("#name"),
                allFields = jQuery_ui([]).add(name),
                tips = jQuery_ui(".validateTips");

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

            jQuery_ui("#dialog-form").dialog({
                autoOpen: false,
                height: 300,
                width: 550,
                modal: true,
                buttons: {
                    "إلغاء": function () {
                        jQuery_ui(this).dialog("close");
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
                            var LicenseNameAR = jQuery_ui.trim(jQuery_ui("[id*=LicenseNameAR]").val());
                            var LicenseNameEN = jQuery_ui.trim(jQuery_ui("[id*=LicenseNameEN]").val());
                            jQuery_ui.ajax({
                                type: "POST",
                                data: { 'LicenseNameAR': LicenseNameAR, 'LicenseNameEN': LicenseNameEN },
                                url: "../../Script/WS1.asmx/AddLicense",
                                success: function (data) {
                                    if (data.d == 1) {
                                        window.location.reload();
                                        jQuery_ui(this).dialog("close");
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
                            jQuery_ui(this).dialog("close");
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

            jQuery_ui("#BtnAddLicense")
                .button()
                .click(function () {
                    jQuery_ui("#dialog-form").dialog("open");
                    return false;
                });

        });
    </script>

    <div id="dialog-form" title="إضافة شهادة جديدة" dir="rtl" style="font-family: 'Sakkal Majalla', Arial;">
        <fieldset style="background: #206fff; border: 10px; border-radius: 10px;">
            <div class="content">
                <div class="container" style="background: #d2d2d2;">
                    <div class="col-lg-12">
                        <div class="sub-content">
                            <div class="list-group">
                                <div class="row">
                                    <div class="col-md-6">
                                        <label class="lbl" for="name">أسم الشهادة (عربي)</label>
                                    </div>
                                    <div class="col-md-6">
                                        <input type="text" name="name" id="LicenseNameAR" class="txt" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <label class="lbl" for="name">أسم الشهادة (أنكليزي)</label>
                                    </div>
                                    <div class="col-md-6">
                                        <input type="text" name="name" id="LicenseNameEN" class="txt" />
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </fieldset>
    </div>
    <div class="content">
        <div class="container">
            <div class="col-lg-12">
                <div class="sub-content">
                    <div class="list-group">
                        <div class="row" style="text-align: center">
                            <asp:RegularExpressionValidator ID="uplValidator" runat="server" ControlToValidate="fuPhoto"
                                ErrorMessage="only jpg, bmp & gif formats are allowed"
                                ValidationExpression="(.+\.([Jj][Pp][Gg])|.+\.([Bb][Mm][Pp])|.+\.([Gg][Ii][Ff]))" CssClass="Error" ForeColor=""></asp:RegularExpressionValidator>

                            <br />

                            <asp:Label Width="100%" ID="lblMessage" runat="server" CssClass="Error" Text=""></asp:Label><asp:HiddenField ID="hfEmpID" Value="0" runat="server" />

                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                نوع العملية :
                            </div>
                            <div class="col-md-3" style="text-align: right">
                                <asp:RadioButton ID="RBAdd" runat="server" GroupName="type" Text="إضافة" OnCheckedChanged="RBAdd_CheckedChanged" AutoPostBack="True" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="RBEdit" runat="server" GroupName="type" Text="تعديل" OnCheckedChanged="RBAdd_CheckedChanged" AutoPostBack="True" />

                            </div>
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-3">
                            </div>

                            <asp:Panel ID="pGrid" runat="server" DefaultButton="btnSubmit" Visible="false">
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label32" runat="server" Text="الفرع : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddlSBranch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSBranch_SelectedIndexChanged" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="0">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label33" runat="server" Text="القسم : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddlSDep" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSBranch_SelectedIndexChanged" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="11">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label3" runat="server" Text="الشعبة : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddlSection" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSBranch_SelectedIndexChanged" TabIndex="1">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        رقم الهوية
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtsID_No" runat="server" MaxLength="20" CssClass="txt" Width="100%" AutoPostBack="True" OnTextChanged="ddlSBranch_SelectedIndexChanged"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        الأسم العربي :
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtFNameARS" runat="server" MaxLength="20" CssClass="txt" Width="100%" AutoPostBack="True" OnTextChanged="ddlSBranch_SelectedIndexChanged"></asp:TextBox>

                                    </div>
                                    <div class="col-md-3">
                                        ترتيب بحسب :
                                    </div>
                                    <div class="col-md-3">
                                        <%--<asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>--%>
                                        <asp:RadioButton ID="RBName" runat="server" GroupName="SortType" Text="الاسم" AutoPostBack="True" OnCheckedChanged="ddlSBranch_SelectedIndexChanged" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="RBDate" runat="server" GroupName="SortType" Text="تاريخ التعيين" AutoPostBack="True" OnCheckedChanged="ddlSBranch_SelectedIndexChanged" />

                                    </div>
                                </div>
                                <div class="row" style="width:99.5%; margin-left:auto; margin-right:auto">
                                    <asp:GridView ID="gvEmployees" runat="server" BackColor="White" BorderColor="#CCCCCC"
                                        BorderStyle="None" BorderWidth="1px" CellPadding="3"
                                        CssClass="table table-striped table-bordered table-condensed"
                                        AutoGenerateColumns="False" AutoGenerateDeleteButton="False"
                                        AutoGenerateSelectButton="True" OnSelectedIndexChanging="gvEmployees_SelectedIndexChanging" OnPageIndexChanging="gvEmployees_PageIndexChanging" AllowSorting="True">
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
                            </asp:Panel>
                            <asp:Panel ID="pForm" runat="server" DefaultButton="btnSubmit" BorderColor="#333333" Visible="false">
                                <div class="row">
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label35" runat="server" Text="الفرع : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddlIBranchs" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%">
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlIBranchs" Display="Dynamic" ErrorMessage="الرجاء اختيار الفرع" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="Submit" ValueToCompare="0">* الرجاء اختيار الفرع</asp:CompareValidator>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label34" runat="server" Text="القسم : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddlIDepartment" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlIDepartment_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlIDepartment" Display="Dynamic" ErrorMessage="الرجاء اختيار القسم" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="Submit" ValueToCompare="0">* الرجاء اختيار القسم</asp:CompareValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label1" runat="server" Text="الشعبة : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddlISection" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%">
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToValidate="ddlISection" Display="Dynamic" ErrorMessage="الرجاء اختيار الفرع" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="Submit" ValueToCompare="0">* الرجاء اختيار الشعبة</asp:CompareValidator>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label58" runat="server" Text="الجنس : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="12">
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="CompareValidator9" runat="server" ControlToValidate="ddlGender" Display="Dynamic" ErrorMessage=" الرجاء اختيار الجنس" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="Submit" ValueToCompare="0">*  الرجاء اختيار الجنس</asp:CompareValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label36" runat="server" Text="الأسم الأول (أنكليزي) : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtFNameEN" runat="server" MaxLength="20" Style="text-align: left;" CssClass="txt" autocomplete="off" TabIndex="2"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFNameEN" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Submit">* الرجاء ادخال الاسم</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label37" runat="server" Text="الأسم الأول (عربي) : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtFNameAR" runat="server" MaxLength="20" CssClass="txt" autocomplete="off" Width="100%" TabIndex="13"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFNameAR" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Submit">* الرجاء ادخال الاسم</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label38" runat="server" Text="أسم الأب (أنكليزي) : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtMNameEN" runat="server" MaxLength="20" Style="text-align: left;" CssClass="txt" autocomplete="off" TabIndex="3"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMNameEN" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Submit">* الرجاء ادخال الاسم</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label39" runat="server" Text="أسم الأب (عربي) : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtMNameAR" runat="server" MaxLength="20" CssClass="txt" autocomplete="off" Width="100%" TabIndex="14"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMNameAR" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Submit">* الرجاء ادخال الاسم</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label40" runat="server" Text="اللقب (أنكليزي) : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtLNameEN" runat="server" MaxLength="20" Style="text-align: left;" CssClass="txt" autocomplete="off" TabIndex="4"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLNameEN" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Submit">* الرجاء ادخال الاسم</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label41" runat="server" Text="اللقب (عربي) : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtLNameAR" runat="server" MaxLength="20" CssClass="txt" autocomplete="off" Width="100%" TabIndex="15"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtLNameAR" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Submit">* الرجاء ادخال الاسم</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label31" runat="server" Text="أسم الأم (أنكليزي) : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtMotherNameEN" runat="server" MaxLength="20" Style="text-align: left;" CssClass="txt" autocomplete="off" TabIndex="5"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label22" runat="server" Text="أسم الأم (عربي) : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtMotherNameAR" runat="server" MaxLength="20" CssClass="txt" autocomplete="off" Width="100%" TabIndex="16"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label42" runat="server" Text="رقم الهاتف : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtPhone" runat="server" MaxLength="15" CssClass="txt" autocomplete="off" Width="100%" TabIndex="6"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPhone" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Submit">* الرجاء ادخال رقم الهاتف</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label43" runat="server" Text="عنوان السكن : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtAddress" runat="server" MaxLength="255" CssClass="txt" autocomplete="off" Width="100%" TabIndex="17"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label44" runat="server" Text="تاريخ الميلاد : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txMDirrthDate" runat="server" MaxLength="15" CssClass="txt" autocomplete="off" Width="100%" AutoPostBack="True" OnTextChanged="txtJoinDate_TextChanged" TabIndex="7"></asp:TextBox>
                                        <asp:CalendarExtender ID="txMDirrthDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txMDirrthDate" PopupPosition="BottomRight" Format="yyyy-MM-dd"></asp:CalendarExtender>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label45" runat="server" Text="تاريخ التعيين : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtJoinDate" runat="server" MaxLength="15" CssClass="txt" autocomplete="off" Width="100%" AutoPostBack="True" OnTextChanged="txtJoinDate_TextChanged" TabIndex="18"></asp:TextBox>
                                        <asp:CalendarExtender ID="txtJoinDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtJoinDate" PopupPosition="BottomRight" Format="yyyy-MM-dd"></asp:CalendarExtender>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label2" runat="server" Text="رصيد الإجازات : " Visible="false"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtVicationBalance" runat="server" CssClass="txt" autocomplete="off" Width="100%" MaxLength="3" Visible="false"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label4" runat="server" Text="تاريخ الاستحقاق : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtMaturityDate" runat="server" CssClass="txt" autocomplete="off" Width="100%" TabIndex="19"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtMaturityDate" PopupPosition="BottomRight" Format="yyyy-MM-dd"></asp:CalendarExtender>
                                    </div>
                                </div>
                                <%--<div class="row">
            <div class="col-md-3">
                <asp:Label class="lbl" width="100%" ID="Label46" runat="server" Text="البريد الألكتروني الخاص : "></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtEmailPer" runat="server" MaxLength="255"  CssClass="txt" autocomplete="off" Width="100%"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label class="lbl" width="100%" ID="Label47" runat="server" Text="البريد الألكتروني الداخلي : "></asp:Label>
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtEmailInt" runat="server" MaxLength="255"  CssClass="txt" autocomplete="off" Width="100%"></asp:TextBox>
            </div>
        </div>--%>

                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label59" runat="server" Text="بموجب الامر الاداري المرقم : " Visible="false"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtAdminOrderNo" runat="server" CssClass="txt" autocomplete="off" Width="100%" MaxLength="15" Visible="false"></asp:TextBox>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label54" runat="server" Text="رقم الهاتف الداخلي : " Visible="false"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtLandLine" runat="server" MaxLength="10" CssClass="txt" autocomplete="off" Width="100%" Visible="false"></asp:TextBox>
                                    </div>


                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label48" runat="server" Text="التحصيل الدراسي : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddlLicenseDigree" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="8">
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="ddlLicenseDigree" Display="Dynamic" ErrorMessage=" الرجاء اختيار التحصيل الدراسي" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="Submit" ValueToCompare="0">* الرجاء اختيار التحصيل الدراسي</asp:CompareValidator>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label24" runat="server" Text="أسم الشهادة : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddlLicenseName" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="82.5%" TabIndex="20">
                                        </asp:DropDownList>
                                        <button id="BtnAddLicense" style="width: 35px; text-align: center; height: 36px; background-color: #5a6268">
                                            <img alt="" src="../../img/Visualpharm-Must-Have-Add.ico" width="25px" height="25px" />
                                        </button>

                                    </div>

                                </div>

                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label51" runat="server" Text="أسم الشخص للاتصال في الحالات الطارئة : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtContactName" runat="server" MaxLength="50" CssClass="txt" autocomplete="off" Width="100%" TabIndex="9"></asp:TextBox>
                                    </div>

                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label52" runat="server" Text="رقم الهاتف : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtContactPhone" runat="server" MaxLength="15" CssClass="txt" autocomplete="off" Width="100%" TabIndex="21"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label53" runat="server" Text="عدد الأطفال : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtChildren" runat="server" MaxLength="2" CssClass="txt" Width="100%" TabIndex="10"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label50" runat="server" Text="الحالة الزوجية : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddlMarital" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="22">
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="ddlMarital" Display="Dynamic" ErrorMessage=" الرجاء اختيار الحالة الزوجية" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="Submit" ValueToCompare="0">*  الرجاء اختيار الحالة الزوجية</asp:CompareValidator>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label7" runat="server" Text="رقم الهوية : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtIdNo" runat="server" MaxLength="10" CssClass="txt" autocomplete="off" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label56" runat="server" Text="صنف الدم : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddlBloodType" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="23">
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="ddlBloodType" Display="Dynamic" ErrorMessage="الرجاء اختيار فصيلة الدم" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="Submit" ValueToCompare="0">* الرجاء اختيار فصيلة الدم</asp:CompareValidator>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label6" runat="server" Text="نسخة من المستمسكات : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:FileUpload ID="fuDocs" runat="server" />
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label55" runat="server" Text="صورة شخصية : "></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:FileUpload ID="fuPhoto" runat="server" />

                                    </div>
                                </div>


                                <div class="row">

                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label5" runat="server" Text="منصب : "></asp:Label>
                                    </div>
                                    <div class="col-md-3" style="text-align: right">
                                        <asp:CheckBox ID="chbIsCEO" runat="server" Text="مدير عام" />
                                        <br />
                                        <asp:CheckBox ID="chbIsCEOAssist" runat="server" Text="معاون مدير عام" />
                                        <br />
                                        <asp:CheckBox ID="chbIsManager" runat="server" Text="مدير قسم \ مدير فرع" />
                                        <br />
                                        <asp:CheckBox ID="chbIsManagerAssist" runat="server" Text="معاون مدير قسم \ معاون مدير فرع" />
                                        <br />
                                        <asp:CheckBox ID="chbIsSectionManager" runat="server" Text="مسؤول شعبة" />
                                        <br />
                                        <asp:CheckBox ID="chbIsExpert" runat="server" Text="خبير" />
                                        <br />
                                        <asp:CheckBox ID="chbIsEmployee" runat="server" Text="موظف" />
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label30" runat="server" Text="أخرى : "></asp:Label>
                                    </div>
                                    <div class="col-md-3" style="text-align: right">
                                        <asp:CheckBox ID="chbIsActive" runat="server" Text="فعــــــــــال" Checked="True" />
                                        <br />
                                        <asp:CheckBox ID="chbIsActing" runat="server" Text="وكالــــــة" />
                                        <br />
                                        <asp:CheckBox ID="chbIsTemp" runat="server" Text="منسب من جهة خارجية" />
                                        <br />
                                        <asp:CheckBox ID="chbIsContract" runat="server" Text="عقد" />
                                        <br />
                                        <asp:CheckBox ID="chbIsDaily" runat="server" Text="اجور يومية" />
                                        <br />
                                        <asp:CheckBox ID="chbIsBlocked" runat="server" Text="حجــــــــــب" Visible="false" />

                                    </div>
                                </div>
                                <div class="row">
                                    <%--<div class="col-6 col-md-3"> </div>--%>
                                    <div class="col-md-3" style="vertical-align: top">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label57" runat="server" Text="ملاحظات : "></asp:Label>
                                    </div>
                                    <div class="col-md-9" style="width: 680px">
                                        <asp:TextBox ID="txtNotes" runat="server" Width="98%" TextMode="MultiLine" Height="51px" CssClass="txt"></asp:TextBox>
                                    </div>
                                    <%--<div class="col-6 col-md-3"> </div>--%>
                                </div>
                                <div class="row">
                                    <div runat="server" id="links" style="direction: ltr"></div>
                                </div>
                                <div class="row">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Submit" ShowSummary="False" />
                                </div>
                                <div class="row">
                                    <div class="col-6 col-md-2">
                                    </div>
                                    <div class="col-6 col-md-2">
                                    </div>
                                    <div class="col-6 col-md-2">
                                        <asp:Button Style="font-size: unset;" ID="btnSubmit" runat="server" Text="تعديل" CssClass="btn btn-success" OnClick="btnSubmit_Click" ValidationGroup="Submit" />
                                    </div>
                                    <div class="col-6 col-md-2">
                                        <asp:Button Style="font-size: unset;" ID="btnCancel" runat="server" Text="إلغاء" CssClass="btn btn-danger" OnClick="btnCancel_Click" CausesValidation="False" UseSubmitBehavior="False" />
                                    </div>
                                    <div class="col-6 col-md-2">
                                    </div>
                                    <div class="col-6 col-md-2">
                                    </div>
                                </div>
                            </asp:Panel>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
