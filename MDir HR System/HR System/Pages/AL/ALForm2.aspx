<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="ALForm2.aspx.cs" Inherits="HR_Salaries.Pages.ALForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div dir="ltr">
    <asp:Label CssClass="lbl" Width="100%" ID="lblMessage" runat="server" ></asp:Label>
    <div class="content">
        <div class="container">
            <div class="row">
                <div class="col-lg-13">
                    <div class="sub-content">
                        <div class="list-group">
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label25" runat="server" Text="EMPLOYMENT_STATUS" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="EMPLOYMENT_STATUS" runat="server" AutoPostBack="True"  CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1"></asp:DropDownList>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label26" runat="server" Text="CLIENT_BRANCH" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="CLIENT_BRANCH" runat="server" MaxLength="3" required TabIndex="2"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label27" runat="server" Text="VAT_REG_NUMBER"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="VAT_REG_NUMBER" runat="server" MaxLength="15"></asp:TextBox>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label28" runat="server" Text="REGISTRATION_NUMBER"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="REGISTRATION_NUMBER" runat="server" MaxLength="15"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label29" runat="server" Text="CLIENT_ORGANIZATION"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="CLIENT_ORGANIZATION" runat="server" MaxLength="8"></asp:TextBox>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label30" runat="server" Text="BANK_CLEARING_NUMBER"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="BANK_CLEARING_NUMBER" runat="server" MaxLength="8"></asp:TextBox>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label31" runat="server" Text="BANK_TEL_NUMBER"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="BANK_TEL_NUMBER" runat="server" MaxLength="15"></asp:TextBox>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label32" runat="server" Text="BANK_REFERECE"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="BANK_REFERECE" runat="server" MaxLength="8"></asp:TextBox>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label33" runat="server" Text="NOTE_TEXT"></asp:Label>
                                </div>

                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="NOTE_TEXT" runat="server" MaxLength="100"></asp:TextBox>
                                </div>


                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label34" runat="server" Text="EMPLOYMENT_POSITION"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="EMPLOYMENT_POSITION" runat="server" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" ></asp:DropDownList>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label35" runat="server" Text="EMPLOYER_NAME"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="EMPLOYER_NAME" runat="server" MaxLength="35"></asp:TextBox>
                                </div>

                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label36" runat="server" Text="EMPLOYMENT_DATE"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="EMPLOYMENT_DATE" runat="server" TextMode="Date" ></asp:TextBox>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label37" runat="server" Text="WORKING_SECTOR"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="WORKING_SECTOR" runat="server" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" ></asp:DropDownList>
                                </div>

                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label38" runat="server" Text="RISK_GROUP"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="RISK_GROUP" runat="server" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" ></asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label39" runat="server" Text="MOBILE_NO1"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="MOBILE_NO1" runat="server" MaxLength="15"></asp:TextBox>
                                </div>


                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label40" runat="server" Text="MOBILE_NO2" ></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="MOBILE_NO2" runat="server" MaxLength="15"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label41" runat="server" Text="FATHERS_NAME_L2"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="FATHERS_NAME_L2" runat="server" MaxLength="35"></asp:TextBox>
                                </div>

                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label42" runat="server" Text="CLIENT_NUMBER_RBS"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="CLIENT_NUMBER_RBS" runat="server" MaxLength="20"></asp:TextBox>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label43" runat="server" Text="PARINT_CLIENT_NUMBER_RBS"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="PARINT_CLIENT_NUMBER_RBS" runat="server" MaxLength="20"></asp:TextBox>
                                </div>

                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label44" runat="server" Text="SETTLEMENT_BANK_NAME"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="SETTLEMENT_BANK_NAME" runat="server" MaxLength="35"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label45" runat="server" Text="SETTLEMENT_BANK_CITY"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="SETTLEMENT_BANK_CITY" runat="server" MaxLength="20"></asp:TextBox>
                                </div>


                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label46" runat="server" Text="BANK_GUARANTEE"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="BANK_GUARANTEE" runat="server" MaxLength="18"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label47" runat="server" Text="SERVICE_CONTRACT_ID" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="SERVICE_CONTRACT_ID" runat="server" MaxLength="3" Text="400" required TabIndex="3"></asp:TextBox>
                                </div>

                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label48" runat="server" Text="SERVICE_ID"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="SERVICE_ID" runat="server" MaxLength="3"></asp:TextBox>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label49" runat="server" Text="EXTENTION_FLAG"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="EXTENTION_FLAG" runat="server" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" ></asp:DropDownList>
                                </div>

                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label50" runat="server" Text="CLIENT_NUMBER"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="CLIENT_NUMBER" runat="server" MaxLength="8"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label51" runat="server" Text="CONDITION_SET" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="CONDITION_SET" runat="server" MaxLength="3" Text="001" required TabIndex="4"></asp:TextBox>
                                </div>

                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label52" runat="server" Text="CLIENT_LIMIT" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="CLIENT_LIMIT" runat="server" MaxLength="18" Text="0" required TabIndex="5"></asp:TextBox>
                                </div>


                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label53" runat="server" Text="LIMIT_CURRENCY" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="LIMIT_CURRENCY" runat="server" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="6"></asp:DropDownList>
                                </div>

                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label54" runat="server" Text="COUNTER_BANK_ACCOUNT" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="COUNTER_BANK_ACCOUNT" runat="server" MaxLength="35" required TextMode="Number" TabIndex="7"></asp:TextBox>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label55" runat="server" Text="DOMICILIATION_COUNTER_BANK_ACCOUNT_"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="DOMICILIATION_COUNTER_BANK_ACCOUNT_" runat="server" MaxLength="16"></asp:TextBox>
                                </div>

                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label56" runat="server" Text="COUNTER_BANK_ACCT_NAME"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="COUNTER_BANK_ACCT_NAME" runat="server" MaxLength="20"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label57" runat="server" Text="SETTLEMENT_METHOD" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="SETTLEMENT_METHOD" runat="server" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="8"></asp:DropDownList>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label58" runat="server" Text="CLIENT_LEVEL" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="CLIENT_LEVEL" runat="server" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="9"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label59" runat="server" Text="BILLING_LEVEL" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="BILLING_LEVEL" runat="server" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="10"></asp:DropDownList>
                                </div>

                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label60" runat="server" Text="PARENT_APPL_NUMBER"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="PARENT_APPL_NUMBER" runat="server" MaxLength="10"></asp:TextBox>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label61" runat="server" Text="CONTRACT_REFERENCE" ForeColor="red"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="CONTRACT_REFERENCE" runat="server" MaxLength="8" required TabIndex="11"></asp:TextBox>
                                </div>

                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label62" runat="server" Text="INSTITUTION_ACC_OFFICER"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="INSTITUTION_ACC_OFFICER" runat="server" MaxLength="3" Text="001" required></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label63" runat="server" Text="PROVIDER_ACCT_OFFICER" ></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="PROVIDER_ACCT_OFFICER" runat="server" MaxLength="3" TextMode="Number" Text="002" required></asp:TextBox>
                                </div>

                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label64" runat="server" Text="CARD_NUMBER"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="CARD_NUMBER" runat="server" TextMode="Number" MaxLength="19"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label65" runat="server" Text="EXPIRY_DATE"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="EXPIRY_DATE" runat="server" TextMode="Date"></asp:TextBox>
                                </div>

                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label66" runat="server" Text="MOTHERS_MAIDEN_NAME"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                  <asp:TextBox CssClass="txt" Width="100%" ID="MOTHERS_MAIDEN_NAME" runat="server" MaxLength="25"></asp:TextBox>
                                </div>

                            </div>

                        


                        <div class="row">
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label67" runat="server" Text="RESIDENCE_STATUS" ForeColor="Red"></asp:Label></div>
                            <div class="col-6 col-md-3">
                                <asp:DropDownList ID="RESIDENCE_STATUS" runat="server" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="12"></asp:DropDownList></div>
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label68" runat="server" Text="COMPANY_NAME"></asp:Label></div>
                            <div class="col-6 col-md-3">
                              <asp:TextBox CssClass="txt" Width="100%" ID="COMPANY_NAME" runat="server" MaxLength="35"></asp:TextBox></div>
                          </div>

                        <div class="row">   <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label69" runat="server" Text="TIME_WITH_PRESENT_EMPLOYER"></asp:Label></div>
                            <div class="col-6 col-md-3">
                              <asp:TextBox CssClass="txt" Width="100%" ID="TIME_WITH_PRESENT_EMPLOYER" runat="server" MaxLength="3"></asp:TextBox></div>
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label70" runat="server" Text="INCOME"></asp:Label></div>
                            <div class="col-6 col-md-3">
                                <asp:DropDownList ID="INCOME" runat="server" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" ></asp:DropDownList></div>
                       
                          </div>





                            <div class="row">   <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label1" runat="server" Text="Bank Contact name"></asp:Label></div>
                            <div class="col-6 col-md-3">
                              <asp:TextBox CssClass="txt" Width="100%" ID="Bank_Contact_Name" runat="server" MaxLength="3"></asp:TextBox></div>
                            <div class="col-6 col-md-3">
                            <div class="col-6 col-md-3">
                       
                          </div>

                        <div class="row">  
                            
                            
                            
                            
                            <div class="col-6 col-md-3">
                            </div>

                            <div class="col-6 col-md-3">
                                <asp:Button style="font-size: unset;" ID="btnSend" runat="server" Text="التالي" width="100%" CssClass="btn btn-success" OnClick="btnSend_Click" />
                            </div>
                            <div class="col-6 col-md-3">
                            </div>
                            <div class="col-6 col-md-3">
                            </div>
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
