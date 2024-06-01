<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="ALForm3.aspx.cs" Inherits="HR_Salaries.Pages.ALForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div dir="ltr">
    <asp:Label CssClass="lbl" Width="100%" ID="lblMessage" runat="server"  ></asp:Label>
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="sub-content">
                        <div class="list-group">
                            <div class="row">
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label71" runat="server" Text="DATE_OF_APP"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:TextBox CssClass="txt" ID="DATE_OF_APPLICATION" runat="server" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label72" runat="server" Text="SECURE_REG_IND"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:DropDownList ID="SECURE_REGISTRATION_INDICATOT" runat="server" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%"></asp:DropDownList>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label73" runat="server" Text="CMO_REG_IND"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:DropDownList ID="CMO_REGISTRATION_INDICATOR" runat="server" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label74" runat="server" Text="CMO_MOBILE_NUM"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:TextBox CssClass="txt" ID="CMO_MOBILE_NUMBER" runat="server" Width="100%" MaxLength="15"></asp:TextBox>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label75" runat="server" Text="COM_STIKER_REG _INDSSSSS"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:DropDownList ID="COM_STIKER_REGISTRATION_INDICATRO" runat="server" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%"></asp:DropDownList>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label76" runat="server" Text="IBAN_NUMBER"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:TextBox CssClass="txt" ID="IBAN_NUMBER" runat="server" Width="100%" MaxLength="35"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label77" runat="server" Text="STICKER_CARD"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:DropDownList ID="STICKER_CARD" runat="server" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%"></asp:DropDownList>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label78" runat="server" Text="DELIVERY_METHOD" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:DropDownList ID="DELIVERY_METHOD" runat="server" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1"></asp:DropDownList>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label79" runat="server" Text="ADDR_LINE_1" ForeColor="Red" ></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:TextBox CssClass="txt" ID="ADDR_LINE_1" runat="server" Width="100%" MaxLength="35" required TabIndex="2"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label80" runat="server" Text="ADDR_LINE_2"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:TextBox CssClass="txt" ID="ADDR_LINE_2" runat="server" Width="100%" MaxLength="35" ></asp:TextBox>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label81" runat="server" Text="ADDR_LINE_3"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:TextBox CssClass="txt" ID="ADDR_LINE_3" runat="server" Width="100%" MaxLength="35"></asp:TextBox>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label82" runat="server" Text="STATE"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:TextBox CssClass="txt" ID="STATE" runat="server" Width="100%" MaxLength="35"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label83" runat="server" Text="OTHER"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:TextBox CssClass="txt" ID="OTHER" runat="server" Width="100%" MaxLength="35"></asp:TextBox>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label84" runat="server" Text="POST_CODE"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:TextBox CssClass="txt" ID="POST_CODE" runat="server" Width="100%" MaxLength="20"></asp:TextBox>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label85" runat="server" Text="ADDRESS_CLIENT_CITY"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:TextBox CssClass="txt" ID="ADDRESS_CLIENT_CITY" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label86" runat="server" Text="EMAIL_ADDRESS"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:TextBox CssClass="txt" ID="EMAIL_ADDRESS" runat="server" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label87" runat="server" Text="EMAIL_ADDRESS2"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:TextBox CssClass="txt" ID="EMAIL_ADDRESS2" runat="server" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label88" runat="server" Text="ADR1_NAME_OF_CLIE"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:TextBox CssClass="txt" ID="ADR1_NAME_OF_CLIENT" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label89" runat="server" Text="ADR 2 STREET 1"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:TextBox CssClass="txt" ID="ADR2STREET1" runat="server" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label90" runat="server" Text="ADR 3 STREET 2"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:TextBox CssClass="txt" ID="ADR3STREET2" runat="server" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label91" runat="server" Text="ADR 4 STATE"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:TextBox CssClass="txt" ID="ADR4_STATE" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label92" runat="server" Text="ADR5_OTHER"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:TextBox CssClass="txt" ID="ADR5_OTHER" runat="server" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label93" runat="server" Text="POST_CODE1"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:TextBox CssClass="txt" ID="POST_CODE1" runat="server" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label94" runat="server" Text="ADDRESS CLIENT CITY 1"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:TextBox CssClass="txt" ID="ADDRESS_CLIENT_CITY1" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-2">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label95" runat="server" Text="EMAIL_ADDRESS1"></asp:Label>
                                </div>
                                <div class="col-6 col-md-2">
                                    <asp:TextBox CssClass="txt" ID="EMAIL_ADDRESS1" runat="server" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-6 col-md-2">
                                </div>
                                <div class="col-6 col-md-2">
                                </div>
                                <div class="col-6 col-md-2">
                                </div>
                                <div class="col-6 col-md-2">
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-4">
                                </div>


                                <div class="col-md-4" style="text-align: center;">
                                    <asp:Button style="font-size: unset;" ID="btnSend" runat="server" Text="حفـــظ" Width="50%" CssClass="btn btn-success" OnClick="btnSend_Click" />
                                </div>
                                <div class="col-6 col-md-4">
                                </div>
                            </div>
                        </div>








                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
