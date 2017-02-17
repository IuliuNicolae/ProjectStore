<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RegisterNewCustomer.aspx.cs" Inherits="RegisterNewCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" Runat="Server">



    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Registration Page</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;First name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="textBoxFName" Display="Dynamic" ErrorMessage="Name field could not be empty" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="textBoxFName" runat="server" Width="124px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server" ControlToValidate="textBoxFName" Display="Dynamic" ErrorMessage="The name must contain only letters" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$">*</asp:RegularExpressionValidator>
    </p>
    <p>
        Last Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="textBoxFName" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*</asp:RequiredFieldValidator>
&nbsp;<asp:TextBox ID="textBoxLName" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="textBoxFName" Display="Dynamic" ErrorMessage="The last name must contain only letters" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$">*</asp:RegularExpressionValidator>
    </p>
    <p>
        Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ControlToValidate="textBoxPass" Display="Dynamic" ErrorMessage="Password field could not be empty" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="textBoxPass" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="textBoxPass" Display="Dynamic" ErrorMessage="Password is to weak" ForeColor="Red" ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,10})$">*</asp:RegularExpressionValidator>
    </p>
    <p>
        Repeat password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass2" runat="server" ControlToValidate="textBoxPass2" Display="Dynamic" ErrorMessage="Password confirmation field could not be empty" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="textBoxPass2" runat="server"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidatorPass2" runat="server" ControlToCompare="textBoxPass" ControlToValidate="textBoxPass2" Display="Dynamic" ErrorMessage="The pasword is not the same" ForeColor="Red">*</asp:CompareValidator>
    </p>
    <p>
        Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ControlToValidate="textBoxEmail" Display="Dynamic" ErrorMessage="Email field could not be empty" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="textBoxEmail" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="textBoxEmail" Display="Dynamic" ErrorMessage="Email is not valid" ValidationExpression="^(?(&quot;&quot;)(&quot;&quot;.+?&quot;&quot;@q)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&amp;'\*\+/=\?\^`\{\}\|~\w])*)(?&lt;=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[com]{3}))$" ForeColor="Red">*</asp:RegularExpressionValidator>
    </p>
    <p>
        Adress:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidatorStreet" runat="server" ControlToValidate="textBoxStreet" Display="Dynamic" ErrorMessage="Street field could not be empty" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="textBoxStreet" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="textBoxStreet" ErrorMessage="Street error" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" Display="Dynamic">*</asp:RegularExpressionValidator>
    </p>
    <p>
        Phone:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" runat="server" ControlToValidate="textBoxPhone" Display="Dynamic" ErrorMessage="Phone field could not be empty" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="textBoxPhone" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhone" runat="server" ControlToValidate="textBoxPhone" Display="Dynamic" ErrorMessage="Phone error" ForeColor="Red" ValidationExpression="^[0-9]{1,10}$">*</asp:RegularExpressionValidator>
    </p>
    <p>
        </p>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <p>
        &nbsp;&nbsp;<input type="button" id="Button10"  value="Registration" onclick="insert();"  />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>

    <script type="text/javascript">
        function insert() {
           
            var fName = document.getElementById('<%= textBoxFName.ClientID %>').value;
            
            var lName = document.getElementById('<%= textBoxLName.ClientID %>').value;
            var pass = document.getElementById('<%= textBoxPass.ClientID %>').value;
            var email = document.getElementById('<%= textBoxEmail.ClientID %>').value;
            var adress = document.getElementById('<%= textBoxStreet.ClientID %>').value;
            var phone = document.getElementById('<%= textBoxPhone.ClientID %>').value;

            var xmlhttp = new XMLHttpRequest();
            xmlhttp.open("GET", "insertMovie.aspx?fnm=" + fName + "&lnm=" + lName + "&pass=" + pass + "&em=" + email + "&adr=" + adress + "&ph=" + phone, false);
            xmlhttp.send();


             document.getElementById('<%= textBoxFName.ClientID %>').value="";
            
            document.getElementById('<%= textBoxLName.ClientID %>').value="";
          document.getElementById('<%= textBoxPass.ClientID %>').value="";
            document.getElementById('<%= textBoxEmail.ClientID %>').value="";
            document.getElementById('<%= textBoxStreet.ClientID %>').value="";
            document.getElementById('<%= textBoxPhone.ClientID %>').value = "";
            alert("Succes");

            
        }
    </script>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
</asp:Content>

