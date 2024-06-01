<%@ Page Title="تقييم الموظفين" Language="C#" MasterPageFile="~/Pages/TBIMaster.Master" AutoEventWireup="true" CodeBehind="EmpRating.aspx.cs" Inherits="HR_Salaries.Pages.Employee.EmpRating" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            document.getElementById("ctl00_ContentPlaceHolder2_txtSum").readOnly = true;
            document.getElementById("ctl00_ContentPlaceHolder2_txtDegree").readOnly = true;
            document.getElementById("ctl00_ContentPlaceHolder2_txtDegreeCeo").readOnly = true;
    
        });

        function validateSumScript() {
            document.getElementById("ctl00_ContentPlaceHolder2_lblMessage").innerText = "";
            var resp = Number(document.getElementById("ctl00_ContentPlaceHolder2_txtresp").value);
            var conf = Number(document.getElementById("ctl00_ContentPlaceHolder2_txtconf").value);
            var inst = Number(document.getElementById("ctl00_ContentPlaceHolder2_txtinst").value);
            var sers = Number(document.getElementById("ctl00_ContentPlaceHolder2_txtsers").value);
            var rel = Number(document.getElementById("ctl00_ContentPlaceHolder2_txtrel").value);
            var comm = Number(document.getElementById("ctl00_ContentPlaceHolder2_txtcomm").value);
            var sum = Number(document.getElementById("ctl00_ContentPlaceHolder2_txtSum").value);
            
            var name = document.getElementById("ctl00_ContentPlaceHolder2_txtName").value;
            if (name) {
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder2_lblMessage").innerText = "يرجى اختيار احد الموظفين";
                return;
            }
            if (resp && conf && inst && sers && rel && comm) {
                if (resp > 30 || resp < 1) {
                    document.getElementById("ctl00_ContentPlaceHolder2_lblMessage").innerText = "الرجاء ادخال رقم اقل من 30";
                    return;
                }
                if (conf > 20 || conf < 1) {
                    document.getElementById("ctl00_ContentPlaceHolder2_lblMessage").innerText = "الرجاء ادخال رقم اقل من 20";
                    return;
                }
                if (inst > 15 || inst < 1) {
                    document.getElementById("ctl00_ContentPlaceHolder2_lblMessage").innerText = "الرجاء ادخال رقم اقل من 15";
                    return;
                }
                if (sers > 15 || sers < 1) {
                    document.getElementById("ctl00_ContentPlaceHolder2_lblMessage").innerText = "الرجاء ادخال رقم اقل من 15";
                    return;
                }
                if (rel > 10 || rel < 1) {
                    document.getElementById("ctl00_ContentPlaceHolder2_lblMessage").innerText = "الرجاء ادخال رقم اقل من 10";
                    return;
                }
                if (comm > 10 || comm < 1) {
                    document.getElementById("ctl00_ContentPlaceHolder2_lblMessage").innerText = "الرجاء ادخال رقم اقل من 10";
                    return;
                }
                sum = resp + conf + inst + sers + rel + comm;
                document.getElementById("ctl00_ContentPlaceHolder2_txtSum").value = sum;
                if (sum > 100) {
                    document.getElementById("ctl00_ContentPlaceHolder2_lblMessage").innerText = "يرجى اعادة التقييم لزيادة التقييم عن 100";
                    return;
                }
                var Degree = "";
              
                if (sum < 49)
                {
                    document.getElementById("ctl00_ContentPlaceHolder2_txtDegree").value = "ضعيف";
                    document.getElementById("ctl00_ContentPlaceHolder2_ddlSumDegree").selectedIndex = "3";
                }
                else if ((sum > 49) && (sum < 60))
                {
                    document.getElementById("ctl00_ContentPlaceHolder2_txtDegree").value = "مقبول";
                    document.getElementById("ctl00_ContentPlaceHolder2_ddlSumDegree").selectedIndex = "5";
                }
                else if ((sum > 59) && (sum < 70))
                {
                    document.getElementById("ctl00_ContentPlaceHolder2_txtDegree").value = "متوسط";
                    document.getElementById("ctl00_ContentPlaceHolder2_ddlSumDegree").selectedIndex = "4";
                }
                else if((sum > 69) && (sum < 80))
                {
                    document.getElementById("ctl00_ContentPlaceHolder2_txtDegree").value = "جيد";
                    document.getElementById("ctl00_ContentPlaceHolder2_ddlSumDegree").selectedIndex = "1";
                }
                else if((sum > 79) && (sum < 90))
                {
                    document.getElementById("ctl00_ContentPlaceHolder2_txtDegree").value = "جيد جداً";
                    document.getElementById("ctl00_ContentPlaceHolder2_ddlSumDegree").selectedIndex = "2";
                }
                else if ((sum > 89) && (sum <= 100))
                {
                    document.getElementById("ctl00_ContentPlaceHolder2_txtDegree").value = "ممتاز";
                    document.getElementById("ctl00_ContentPlaceHolder2_ddlSumDegree").selectedIndex = "6";
                }else
                {
                    document.getElementById("ctl00_ContentPlaceHolder2_ddlSumDegree").selectedIndex = "0";
                }
               
               
                return;
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder2_lblMessage").innerText = "الرجاء التأكد من جميع الحقول: فارغ - يحتوي على حرف - 0";
                return;
            }
        }
        function validateSumCeoScript() {
            document.getElementById("ctl00_ContentPlaceHolder2_txtDegreeCeo").readOnly = true;
            document.getElementById("ctl00_ContentPlaceHolder2_lblMessage").innerText = "";
            var sumCeo = Number(document.getElementById("ctl00_ContentPlaceHolder2_txtSumCeo").value);
            var name = document.getElementById("ctl00_ContentPlaceHolder2_txtNameCeo").value;
            if (name) {
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder2_lblMessage").innerText = "يرجى اختيار احد الموظفين";
                return;
            }
            if (sumCeo) {
                if (sumCeo > 100) {
                    document.getElementById("ctl00_ContentPlaceHolder2_lblMessage").innerText = "يرجى اعادة التقييم لزيادة التقييم عن 100";
                    return;
                }
                var DegreeCeo = "";

                if (sumCeo < 49) {
                    document.getElementById("ctl00_ContentPlaceHolder2_txtDegreeCeo").value = "ضعيف";
                    document.getElementById("ctl00_ContentPlaceHolder2_ddlDegreeCeo").selectedIndex = "3";
                }
                else if ((sumCeo > 49) && (sumCeo < 60)) {
                    document.getElementById("ctl00_ContentPlaceHolder2_txtDegreeCeo").value = "مقبول";
                    document.getElementById("ctl00_ContentPlaceHolder2_ddlDegreeCeo").selectedIndex = "5";
                }
                else if ((sumCeo > 59) && (sumCeo < 70)) {
                    document.getElementById("ctl00_ContentPlaceHolder2_txtDegreeCeo").value = "متوسط";
                    document.getElementById("ctl00_ContentPlaceHolder2_ddlDegreeCeo").selectedIndex = "4";
                }
                else if ((sumCeo > 69) && (sumCeo < 80)) {
                    document.getElementById("ctl00_ContentPlaceHolder2_txtDegreeCeo").value = "جيد";
                    document.getElementById("ctl00_ContentPlaceHolder2_ddlDegreeCeo").selectedIndex = "1";
                }
                else if ((sumCeo > 79) && (sumCeo < 90)) {
                    document.getElementById("ctl00_ContentPlaceHolder2_txtDegreeCeo").value = "جيد جداً";
                    document.getElementById("ctl00_ContentPlaceHolder2_ddlDegreeCeo").selectedIndex = "2";
                }
                else if ((sumCeo > 89) && (sumCeo <= 100)) {
                    document.getElementById("ctl00_ContentPlaceHolder2_txtDegreeCeo").value = "ممتاز";
                    document.getElementById("ctl00_ContentPlaceHolder2_ddlDegreeCeo").selectedIndex = "6";
                } else {
                    document.getElementById("ctl00_ContentPlaceHolder2_ddlDegreeCeo").selectedIndex = "0";
                }


                return;
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder2_lblMessage").innerText = "الرجاء التأكد من جميع الحقول: فارغ - يحتوي على حرف - 0";
                return;
            }
        }
        


            //    var Degree = "";
            //    switch (sum) {
            //        case 0 - 49:
            //            Degree = "ضعيف";
            //            break;
            //        case 50 - 59:
            //            Degree = "مقبول";
            //            break;
            //        case 60 - 69:
            //            Degree = "متوسط";
            //            break;
            //        case 70 - 79:
            //            Degree = "جيد";
            //            break;
            //        case 80 - 89:
            //            Degree = "جيد جداً";
            //            break;
            //        case 90 - 100:
            //            Degree = "ممتاز";
            //            break;
            //        default:
            //            Degree = "درجة التقييم";
            //            document.getElementById("ctl00_ContentPlaceHolder2_txtDegree").innerText = Degree;
            //    }
                
            //    return;
            //}
           
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("هل تم تقييم جميع الموظفين؟ سيتم ازالة صلاحية الصفحة عند الضغط على نعم")) {
                confirm_value.value = "نعم";
            } else {
                confirm_value.value = "لا";
            }
            document.forms[0].appendChild(confirm_value);
        }
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    <div class="row" style="text-align: center">

        <asp:HiddenField ID="hfEmpID" Value="0" runat="server" />
         <asp:TextBox ID="hfEmpDep" runat="server" MaxLength="20" CssClass="txt" AutoPostBack="True" visible="false" BackColor="lavender" ForeColor="gray"></asp:TextBox>
          
     <br />  
        <asp:HiddenField ID="hfCount" Value="0" runat="server" />
    </div>
    <div class="row" style=" width:500px; border-style:ridge; text-align:center; border-color:navy;margin: auto;" >
         <asp:Label ID="Label17" runat="server" BackColor="Red" ForeColor="White">يرجى تقييم جميع الموظفين دون استثناء لأغراض العلاوة والحافز. </asp:Label> 
        
         <br />
        </div>

    <div style="overflow: auto; white-space: nowrap;" align="center">

        <div class="row" style="text-align: center; width: 98.5%; overflow-x: auto; white-space: nowrap;" dir="rtl">

            <asp:GridView ID="GridView1" runat="server" DataGridViewTriState="True" BackColor="White" CssClass="table"
                AutoSizeRowsMode="false" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" dir="rtl" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateSelectButton="True" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowSorting="true" AllowPaging="true" PageSize="15">
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF"/>

                <PagerSettings Mode="NumericFirstLast" />
                <PagerStyle ForeColor="#000066" HorizontalAlign="Center" BackColor="#C6C3C6" />
                <RowStyle ForeColor="#000066" />
                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#594B9C" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#33276A" />

            </asp:GridView>
            <br />
        </div>

        <br />
    </div>
    <div class="row" style="border-style:ridge;"><asp:Label ID="Label15" runat="server" Text="عدد الموظفين الكلي : "></asp:Label>
                <asp:Label ID="Lbltotal" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Label16" runat="server" Text="عدد الموظفين المسموح لهم بتقييم ممتاز (25%) : "></asp:Label>
                <asp:Label ID="lblExc" runat="server"></asp:Label>
                
            </div>
    <div class="row" style="text-align: center">
        <asp:Label ID="lblMessage" runat="server" CssClass="Error" Text="" Visible="true"></asp:Label>
    </div>
    <asp:Panel ID="pnlCeos" runat="server" Visible="false">
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label6" runat="server" Text="اسم الموظف : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtNameCeo" runat="server" MaxLength="20" CssClass="txt" AutoPostBack="True" ReadOnly="True" BackColor="lavender" ForeColor="gray" onkeyup="validateSumScript()"></asp:TextBox>

            </div>
             <div class="columnleft">
            </div>
            <div class="columnRight">
            </div>
            </div>
            
             <div class="row">

            <div class="columnleft">
                <asp:Label ID="Label8" runat="server" Text="مجموع التقييم (100): ">

                </asp:Label>
                </div>
                <div class="columnRight">
                <asp:TextBox ID="txtSumCeo" runat="server" MaxLength="20" CssClass="txt" onkeyup="validateSumCeoScript()"></asp:TextBox>
             </div>
                    <div class="columnleft">
                <asp:Label ID="Label12" runat="server" Text="درجة التقييم : "></asp:Label>

            </div>
             <div class="columnRight">
            <asp:TextBox ID="txtDegreeCeo" runat="server" MaxLength="20" CssClass="txt" onkeyup="validateSumCeoScript()"></asp:TextBox>
            </div>
            
                 </div>
        <div class="row" style="display:none">  
            <div class="columnleft">
                <asp:Label ID="Label10" runat="server" Text="درجة التقييم : "></asp:Label>
            </div>
            <div class="columnRight">
                 <asp:DropDownList ID="ddlDegreeCeo" runat="server" CssClass="ddl" AutoPostBack="True">
                </asp:DropDownList>
            </div>
            <div class="columnleft">
            </div>
            <div class="columnRight">
            </div>
             </div>
        <div class="row">
        <asp:Button ID="btnCeo" runat="server" Text="تقييم" CssClass="btn" OnClick="btnCeo_Click" visible="false"/>
            </div>
        </asp:Panel>

    <asp:Panel ID="pnlEdit" runat="server" Visible="false">
        
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label4" runat="server" Text="اسم الموظف : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtName" runat="server" MaxLength="20" CssClass="txt" AutoPostBack="True" ReadOnly="True" BackColor="lavender" ForeColor="gray" onkeyup="validateSumScript()"></asp:TextBox>

            </div>
            <div class="columnleft">
            </div>
            <div class="columnRight">
            </div>
        </div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label1" runat="server" Text="القدرة على تنفيذ الاعمال وتحمل المسؤولية (30) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtresp" runat="server" MaxLength="20" CssClass="txt" onkeyup="validateSumScript()">30</asp:TextBox>

            </div>
            <div class="columnleft">
                <asp:Label ID="Label2" runat="server" Text="المحافظة على سرية المعلومات (20) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtconf" runat="server" MaxLength="20" CssClass="txt" onkeyup="validateSumScript()">20</asp:TextBox>

            </div>
        </div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label3" runat="server" Text="الالتزام بالتوجيهات والتعليمات (15) : "></asp:Label>

            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtinst" runat="server" MaxLength="20" CssClass="txt" onkeyup="validateSumScript()">15</asp:TextBox>

            </div>
            <div class="columnleft">
                <asp:Label ID="Label7" runat="server" Text="الاهتمام والجدية في العمل (15) : "></asp:Label>

            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtsers" runat="server" MaxLength="20" CssClass="txt" onkeyup="validateSumScript()">15</asp:TextBox>

            </div>

        </div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label9" runat="server" Text="العلاقة مع زملائه ورئيسه المباشر (10) : "></asp:Label>

            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtrel" runat="server" MaxLength="20" CssClass="txt" onkeyup="validateSumScript()">10</asp:TextBox>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label5" runat="server" Text="الالتزام بالدوام الرسمي (10) : "></asp:Label>

            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtcomm" runat="server" MaxLength="20" CssClass="txt" onkeyup="validateSumScript()">10</asp:TextBox>

            </div>

        </div>
        <div class="row">

            <div class="columnleft">
                <asp:Label ID="Label11" runat="server" Text="مجموع التقييم (100): ">

                </asp:Label>

            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtSum" runat="server" MaxLength="20" CssClass="txt" onkeyup="validateSumScript()"></asp:TextBox>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label14" runat="server" Text="درجة التقييم : "></asp:Label>

            </div>
             <div class="columnRight">
            <asp:TextBox ID="txtDegree" runat="server" MaxLength="20" CssClass="txt" onkeyup="validateSumScript()"></asp:TextBox>
            </div>
        

        </div>
     
        <div class="row" style="display:none">
           <div class="columnRight">
                 <asp:DropDownList ID="ddlSumDegree" runat="server" CssClass="ddl" ForeColor="gray" AutoPostBack="true">
                </asp:DropDownList>
            </div>
            </div>

    </asp:Panel>
    <div class="row">
        <asp:Button ID="btnSubmit" runat="server" Text="تقييم" CssClass="btn" OnClick="btnSubmit_Click" visible="false"/>
        <asp:Button ID="BtnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="BtnCancel_Click" CausesValidation="False" UseSubmitBehavior="False" />
    </div>
   
     <div class="row" style=" width:500px; border-style:ridge; text-align:center; border-color:navy;margin: auto;" >
         <asp:Label ID="Label13" runat="server" BackColor="Red" ForeColor="White">عند الانتهاء من جميع التقييمات لكل الموظفين بشكل نهائي يرجى الضغط على الزر التالي ليتم ارسالها الى قسم الموارد البشرية :</asp:Label> 
        
         <br />
         <br />
         <asp:Button ID="btnEnd" runat="server" Text="ارسال" CssClass="btn" OnClick="btnEnd_Click" OnClientClick = "Confirm()"/>
    </div>
</asp:Content>

