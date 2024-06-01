<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/TBIMaster.Master" AutoEventWireup="true" CodeBehind="AllowAd.aspx.cs"
    Inherits="HR_Salaries.Pages.Salaries.AllowAdEd" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="Error"></asp:Label>
    </div>
    <div class="row"></div>
    <fieldset>
        <div class="row"></div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label23" runat="server" Text="عنوان المخصص (عربي) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtAllowTitleAR" runat="server" CssClass="txt"></asp:TextBox>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label22" runat="server" Text="عنوان المخصص (أنكليزي) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtAllowTitleEN" runat="server" CssClass="txtltr"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label21" runat="server" Text="رمز الدليل المحاسبي : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtGLCode" runat="server" MaxLength="13" CssClass="txt"></asp:TextBox>
            </div>

            <div class="columnleft">
                <asp:Label ID="Label24" runat="server" Text="نوع المخصص : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlType" runat="server" CssClass="ddl">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label25" runat="server" Text="نوع التخصيص :"></asp:Label>
            </div>
            <div class="columnRight" style="text-align: right">

                <asp:RadioButtonList ID="rblIsPercentage" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblIsPercentage_SelectedIndexChanged" AutoPostBack="True">

                    <asp:ListItem Value="false">قطعي</asp:ListItem>
                    <asp:ListItem Value="true" Selected="True">نسبي</asp:ListItem>
                </asp:RadioButtonList>

            </div>

            <div class="columnleft">
                <asp:Label ID="Label1" runat="server" Text="فعال؟ : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:CheckBox ID="chbActive" runat="server" />
            </div>
        </div>
        <div class="row"></div>
        <div class="row">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="btnCancel_Click" CausesValidation="False" UseSubmitBehavior="False" />
        </div>
    </fieldset>

    <div class="row">&nbsp;</div>
    <fieldset>
        <asp:Panel ID="pnlValues" Enabled="false" runat="server">
            <div class="row">
            </div>
            <div class="row">
                <asp:GridView ID="gvValues" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowSorting="True" CssClass="grid" AutoGenerateEditButton="True" OnRowEditing="gvAllowances_RowEditing">
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
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

            <div class="row"></div>
            <div class="row">
                <asp:Button ID="btnEdit" runat="server" Text="تعديل" CssClass="btn" OnClick="btnEdit_Click" />
            </div>
        </asp:Panel>
    </fieldset>


</asp:Content>
