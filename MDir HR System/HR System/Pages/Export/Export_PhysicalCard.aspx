<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="Export_PhysicalCard.aspx.cs" Inherits="HR_Salaries.Pages.Export_PhysicalCard.Export_PhysicalCard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div dir="ltr">
        <div class="content">
            <div class="container">
                <div class="col-lg-13">
                    <div class="sub-content">
                        <div class="list-group">
                            <div class="row">
                                <div class="col-6 col-md-12">
                                    <asp:Label ID="lblMessage" runat="server" Text="" BackColor="Red"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="ddlInstitution" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" Visible="False"></asp:DropDownList>
                               
                                    
                                </div>
                                <div class="col-6 col-md-3">
                            <asp:Button style="font-size: unset;" ID="btnAlExport_out" Width="100%" CssClass="btn btn-success" runat="server" Text="Al CSV Export OUT" OnClick="btnAlExport_OUT_Click" Visible="False" />

                                </div>
                                <div class="col-6 col-md-3">
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:Button style="font-size: unset;" ID="btnAlExport" Width="100%" CssClass="btn btn-success" runat="server" Text="Al CSV Export" OnClick="btnAlExport_Click" Visible="False" />
                                </div>
                            </div>

                            <div class="row">

                                <div class="col-6 col-md-4">
                                    <hr style="color: black; background-color: black; height: 5px;    width: 380px;" />
                                </div>                                                              
                                <div class="col-6 col-md-4">                                        
                                    <hr style="color: #28a745; background-color: #28a745; height: 5px;    width: 380px;" />
                                </div>                                                             
                                <div class="col-6 col-md-4">                                       
                                    <hr style="color: #f00; background-color: #f00; height: 5px;    width: 355px;" />
                                </div>                                                              
                               

                            </div>
                        </div>



                        <div class="row">
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" Width="100%" ID="SequenceNumber" runat="server" TextMode="Number" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" runat="server" Text="Sequence Number"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" Width="100%" ID="txtBankId" runat="server" TextMode="Number" Text="00000154" Enabled="false"></asp:TextBox>

                            </div>
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label1" runat="server" Text="Bank Id Number"></asp:Label>

                            </div>
                        </div>




                        <div class="row">
                            <div class="col-6 col-md-3">
                            </div>
                            <div class="col-6 col-md-3">
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" Width="100%" ID="txtLayoutVersion" runat="server" TextMode="Number" Text="0001" Enabled="false"></asp:TextBox>

                            </div>
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label4" runat="server" Text="Layout Version"></asp:Label>

                            </div>
                        </div>

                         <div class="row">
                 
                 <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" ID="dat_Processing" runat="server" Width="100%"  required TabIndex="1" ></asp:TextBox>
 
                             <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dat_Processing"
                                    Format="yyyy-MM-dd">
                                </cc1:CalendarExtender>
                </div>
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label9" runat="server" Width="100%" Text="Processing DATE" ForeColor="Red"></asp:Label>
                 </div>

                            
		
                <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" ID="dat_Batch" runat="server" Width="100%"  required TabIndex="1" ></asp:TextBox>
 
                             <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="dat_Batch"
                                    Format="yyyy-MM-dd">
                                </cc1:CalendarExtender>
                </div>
<div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label10" runat="server" Width="100%" Text="Batch Date" ForeColor="Red"></asp:Label>
                </div>


                        </div>
                        <div class="row">
                 
                 <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" ID="dat_Transaction_Date" runat="server" Width="100%"  required TabIndex="1" ></asp:TextBox>
 
                             <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="dat_Transaction_Date"
                                    Format="yyyy-MM-dd">
                                </cc1:CalendarExtender>
                </div>
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" ID="Label11" runat="server" Width="100%" Text="Transaction Date" ForeColor="Red"></asp:Label>
                 </div>

                            
		
                <div class="col-6 col-md-3">
                               
                             <asp:TextBox CssClass="txt" ID="dat_Time" runat="server" Width="100%"  required TabIndex="1" ></asp:TextBox>
                </div>
                <div class="col-6 col-md-3">
                            <asp:Label CssClass="lbl" ID="Label12" runat="server" Width="100%" Text="Time Processing" ForeColor="Red"></asp:Label>
                            <asp:Label CssClass="lbl" ID="Label13" runat="server" Width="100%" Text="Time from 0-23, Format HHMMSS" ForeColor="Red"></asp:Label>
                </div>


                        </div>

                        <div class="row">
                            <div class="col-6 col-md-3">
                                <asp:DropDownList CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" ID="ddlTraType" runat="server"></asp:DropDownList>

                            </div>
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label5" runat="server" Text="Transaction Type"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" Width="100%" ID="txtDSlipNu" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label3" runat="server" Text="Deposit Slip Number"></asp:Label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-6 col-md-3">
                                <asp:DropDownList CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" ID="dllCurrency" runat="server" OnSelectedIndexChanged="dllCurrency_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label7" runat="server" Text="Batch Currency"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:DropDownList CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" ID="dllTraCategory" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label6" runat="server" Text="Transaction Category"></asp:Label>
                            </div>
                        </div>



                        <div class="row">
                            <div class="col-6 col-md-3">
                                <asp:TextBox ID="txt_cardnumber" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:Label ID="Label2" runat="server" Text="رقم البطاقة"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" Width="100%" ID="SlipNumber" runat="server" TextMode="Number"></asp:TextBox>

                            </div>
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label8" runat="server" Text="Slip Number"></asp:Label>
                            </div>
                        </div>



                        <div class="row">
                            <div class="col-6 col-md-3">
                            </div>
                            <div class="col-6 col-md-3">
                            </div>
                            <div class="col-6 col-md-3">
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:Button style="font-size: unset;" ID="btnBatchExport" runat="server" Width="100%" CssClass="btn btn-success" Text="Batch File Export" OnClick="btnBatchExport_Click" />

                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
