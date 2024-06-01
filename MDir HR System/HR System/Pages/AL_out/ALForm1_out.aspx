<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="ALForm1_out.aspx.cs" Inherits="HR_Salaries.Pages.ALForm1_out" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <asp:Label ID="lblMessage" runat="server"  ></asp:Label>
    <div class="content">
        <div class="container">
            <div class="col-lg-13">
                <div class="sub-content">
                    <div class="list-group">
                        
                        <div dir="ltr">
                         <asp:Panel ID="Panel2" runat="server" Visible="true">

                        <div class="row">



                        </div>





                        <div class="row">
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label1" runat="server" Width="100%" Text="RECORD_DATE" ForeColor="red">
                                </asp:Label>
                                
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" ID="RECORD_DATE" runat="server" Width="100%"  TextMode="Date" required TabIndex="1" ></asp:TextBox>
                                 
                             

                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="RECORD_DATE"
                                    Format="yyyy-MM-dd">
                                </cc1:CalendarExtender>

                            </div>
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label3" runat="server"  Text="INSTITUTION_NUMBER" ForeColor="red"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" Width="100%" ID="INSTITUTION_NUMBER" runat="server" MaxLength="8" Text="00000154" required TabIndex="1" ></asp:TextBox>
                            
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label123" runat="server" Width="100%" Text="LAST_NAME" ForeColor="red"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" ID="LAST_NAME" runat="server" Width="100%" MaxLength="25" required TabIndex="1"></asp:TextBox>
                            </div>


                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label4" runat="server" Width="100%" Text="FIRST_NAME" ForeColor="red"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" ID="FIRST_NAME" runat="server" Width="100%" MaxLength="15" required TabIndex="1"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label5" runat="server" Width="100%" Text="BIRTH_NAME"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" ID="BIRTH_NAME" runat="server" Width="100%" MaxLength="20" ></asp:TextBox>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label6" runat="server" Width="100%" Text="FATHER_NAME"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" ID="FATHER_NAME" runat="server" Width="100%" MaxLength="20" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">

                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label7" runat="server" Width="100%" Text="EMBOSS LINE 1" ForeColor="red"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" ID="EMBOSS_LINE_1" runat="server" Width="100%" MaxLength="26" required TabIndex="1"></asp:TextBox>
                            </div>
                              <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" ID="Label2" runat="server" Width="100%" Text="EMBOSS LINE 2"></asp:Label></div>
                                <div class="col-6 col-md-3">
                                    <asp:TextBox CssClass="txt" ID="EMBOSS_LINE_2" runat="server" Width="100%" MaxLength="26"></asp:TextBox></div>
                        </div>
                        <div class="row">    <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label8" runat="server" Width="100%" Text="EMBOSS LINE 3"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" ID="EMBOSS_LINE_3" runat="server" Width="100%" MaxLength="26"></asp:TextBox>
                            </div>
                        
                           
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label10" runat="server" Width="100%" Text="TITLE" ForeColor="red"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:DropDownList ID="TITLE" runat="server" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">    <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label11" runat="server" Width="100%" Text="MARITAL_STATUS" ForeColor="red"></asp:Label>
                            </div>
                        
                            <div class="col-6 col-md-3">
                                <asp:DropDownList ID="MARITAL_STATUS" runat="server"  AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1"></asp:DropDownList>
                            </div>
                         
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label13" runat="server" Width="100%" Text="TEL_PRIVATE" ForeColor="red"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" Width="100%" ID="TEL_PRIVATE" runat="server"  MaxLength="15" required TabIndex="1"></asp:TextBox>
                            </div>


                        </div>
                        <div class="row">    <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label130" runat="server" Width="100%" Text="TEL_WORK" ForeColor="red"></asp:Label>
                            </div>
                        
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" ID="TEL_WORK" runat="server" Width="100%" MaxLength="15" TabIndex="1"></asp:TextBox>
                            </div>
                       
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label14" runat="server" Width="100%" Text="FAX_PRIVATE"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" ID="FAX_PRIVATE" runat="server" Width="100%" MaxLength="15"></asp:TextBox>
                            </div>
                       </div>
                        <div class="row">     <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label15" runat="server" Width="100%" Text="FAX_WORK"></asp:Label>
                            </div>
                        
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" ID="FAX_WORK" runat="server" Width="100%" MaxLength="15"></asp:TextBox>
                            </div>
                           

                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label16" runat="server" Width="100%" Text="ID_NUMBER"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" ID="ID_NUMBER" runat="server" Width="100%" MaxLength="15"></asp:TextBox>
                            </div>
                           </div>
                        <div class="row">  <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label17" runat="server" Width="100%" Text="PASSPORT_NUMBER"></asp:Label>
                            </div>
                        
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" ID="PASSPORT_NUMBER" runat="server" Width="100%" MaxLength="15"></asp:TextBox>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label18" runat="server" Width="100%" Text="DRIVING_LICENSE"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" ID="DRIVING_LICENSE" runat="server" Width="100%" MaxLength="15"></asp:TextBox>
                            </div>


                         </div>
                        <div class="row">   <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label19" runat="server" Width="100%" Text="BIRTH_DATE" ForeColor="red"></asp:Label>
                            </div>
                       
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" ID="BIRTH_DATE" runat="server" Width="100%" TextMode="Date" required TabIndex="1" ></asp:TextBox>
                            </div> 
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label20" runat="server" Width="100%" Text="BIRTH_PLACE"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" ID="BIRTH_PLACE" runat="server" Width="100%" MaxLength="15"></asp:TextBox>
                            </div>
                         </div>
                        <div class="row">   <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label21" runat="server" Width="100%" Text="CLIENT_COUNTRY" ForeColor="red"></asp:Label>
                            </div>
                        
                            <div class="col-6 col-md-3">
                                <asp:DropDownList ID="CLIENT_COUNTRY" runat="server"  AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1"></asp:DropDownList>
                            </div>
                           

                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label213" runat="server" Width="100%" Text="CLIENT_CITY"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" ID="CLIENT_CITY" runat="server" Width="100%" MaxLength="13"></asp:TextBox>
                            </div>

                         </div>
                        <div class="row">    <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label23" runat="server" Width="100%" Text="CLIENT_LANGUAGE" ForeColor="red"></asp:Label>
                            </div>
                    
                            <div class="col-6 col-md-3">
                                <asp:DropDownList ID="CLIENT_LANGUAGE" runat="server"  AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1"></asp:DropDownList>
                            </div>    
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label24" runat="server"  Text="NATIONALITY" ForeColor="red"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:DropDownList ID="NATIONALITY" runat="server"  AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1"></asp:DropDownList>
                            </div>
                            </div>

                            
                           
                            

                             <div class="row">   
                                 
                                 
                                <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label9" runat="server" Width="100%" Text="Employee ID Number" ForeColor="red"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" ID="txtEmpID" runat="server" Width="100%" MaxLength="8" TabIndex="1"></asp:TextBox>
                            </div>



                            <div class="col-6 col-md-3">
                            </div>
                            

                         </div>



                            <div class="row">  

                                  <div class="col-6 col-md-3">
                            </div>
                                <div class="col-6 col-md-3">
                            </div>

                            <div class="col-6 col-md-3">
                                <asp:Button style="font-size: unset;" ID="btnSend" runat="server" Text="التالي" width="100%" CssClass="btn btn-success" OnClick="btnSend_Click" />
                            </div>    
                            <div class="col-6 col-md-3">
                                <asp:Label ID="lblempid" runat="server" Text=""></asp:Label>
                            </div>

                              

                                 <div class="col-6 col-md-3">
                            </div>
                                <div class="col-6 col-md-3">
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

