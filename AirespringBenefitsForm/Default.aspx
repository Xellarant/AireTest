<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AirespringBenefitsForm.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formBenefitsManagement" runat="server">
        <div>
            <strong>New Employee Record</strong><br />
            <br />
            EmployeeID<br />
            <input id="tbEmployeeID" name="tbEmployeeID" placeholder="XXXX123" type="text" /><br />
            <br />
            Last Name<br />
            <input id="tbLastName" name="tbLastName" placeholder="LastName" type="text" /><br />
            <br />
            First Name<br />
            <input id="tbFirstName" name="tbFirstName" placeholder="FirstName" type="text" /><br />
            <br />
            Phone Number<br />
            <input id="tbPhoneNumber" name="tbPhoneNumber" pattern="[\(]\d{3}[\)][ ]\d{3}[\-]\d{4}" placeholder="(XXX) XXX-XXXX" title="(XXX) XXX-XXXX" type="text" /><br />
            <br />
            Zip Code<br />
            <input id="tbZipCode" name="tbZip" placeholder="XXXXX" type="text" /><br />
            <br />
            Hire Date<br />
            <input id="tbHireDate" name="tbHireDate" pattern="\d{2}[\/]\d{2}[\/]\d{4}" placeholder="MM/DD/YYYY" title="MM/DD/YYYY" type="text" /><br />
            <br />
            <br />
            <asp:Button ID="btSubmitNewEmployee" runat="server" OnClick="btSubmitNewEmployee_Click" Text="Submit" />
            <br />
            <br />
            <asp:GridView ID="gvEmployees" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
