<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="SendManage.aspx.cs" Inherits="HR_Salaries.Pages.Al_Send_Manage.SendManage" %>
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
                            </div>
                            <div class="col-6 col-md-3">
                            </div>
                            <div class="col-6 col-md-3">
                                
                               
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:Label ID="Label2" runat="server" Text="التعديل على الملف المرسل" ></asp:Label>
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

                             <div class="row">
                            <div class="col-6 col-md-3">
                            </div>
                            <div class="col-6 col-md-3">
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" ID="dat_RecordDate" runat="server" Width="100%"  required TabIndex="1" ></asp:TextBox>
 
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dat_RecordDate"
                                    Format="yyyyMMdd" >
                                </cc1:CalendarExtender>                            

                            </div>
                            <div class="col-6 col-md-3">
                                <asp:Label ID="Label6" runat="server" Text=": التاريخ" ></asp:Label>
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

                            
                            <div class="row">
                                <div class="col-6 col-md-3">
                         
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:Label ID="Label5" runat="server" Text="تعديل الملف ليكون جاهز للأرسال " ></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                              
                                </div>
                                <div class="col-6 col-md-3">
                                <asp:Button style="font-size: unset;" ID="btnIsSendManage" Width="100%" CssClass="btn btn-success" runat="server" Text="تعـــــديل" onClick="btnIsSendManage_Click" />
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

                             <div class="row">
                                <div class="col-6 col-md-3">
                         
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:Label ID="Label7" runat="server" Text="جعل الملف مرسل مسبقا حسب التاريخ المحدد" ></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                              
                                </div>
                                <div class="col-6 col-md-3">
                                <asp:Button style="font-size: unset;" ID="btnIsSendManage_not" Width="100%" CssClass="btn btn-success" runat="server" Text="تعـــــديل" onClick="btnIsSendManage_not_Click" />
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


                             <div class="row">
                                <div class="col-6 col-md-3">
                         
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:Label ID="Label1" runat="server" Text="تحويل الجميع الى وضع الارسال مسبقا - فارغ AL" ></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                              
                                </div>
                                <div class="col-6 col-md-3">
                                <asp:Button style="font-size: unset;" ID="btn_notSendAll" Width="100%" CssClass="btn btn-success" runat="server" Text="تعـــــديل" onClick="btn_notSendAll_Click" />
                                </div>
                            </div>



                            <asp:Panel ID="Pal_select" runat="server">
                            <div class="row">
                                <div class="col-6 col-md-3">
                         
                                </div>
                                <div class="col-6 col-md-3">
                                <asp:Button style="font-size: unset; color:red;" ID="btn_yes" Width="100%" CssClass="btn btn-success" runat="server" Text="نعم" onClick="btnyes_Click" />
                                </div>
                                <div class="col-6 col-md-3">   
                                <asp:Button style="font-size: unset;" ID="btn_no" Width="100%" CssClass="btn btn-success" runat="server" Text="لا" onClick="btnno_Click" />
                                </div>
                                <div class="col-6 col-md-3">
                                </div>
                            </div>
                            </asp:Panel>

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






                            <div class="row">
                            <div class="col-6 col-md-3">
                            </div>
                            <div class="col-6 col-md-3">
                            </div>
                            <div class="col-6 col-md-3">
                            <asp:Label ID="lbl_SendCount" runat="server" Text="" ></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                            <asp:Label ID="Label3" runat="server" Text="عدد السجلات الجاهزة للارسال " ></asp:Label>
                            </div>
                            
                            </div>


                            <div class="row">
                            <div class="col-6 col-md-3">
                            </div>
                            <div class="col-6 col-md-3">
                            </div>
                            <div class="col-6 col-md-3">
                            <asp:Label ID="lbl_NotSendCount" runat="server" Text="" ></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                            <asp:Label ID="Label8" runat="server" Text="عدد السجلات المرسلة مسبقا" ></asp:Label>
                            </div>
                            
                            </div>
                        </div>

















                        

                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
