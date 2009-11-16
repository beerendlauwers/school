﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="nieuwe gebruiker.aspx.vb" Inherits="App_Presentation_Webpaginas_nieuwe_gebruiker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server">
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server">
                <ContentTemplate>
                    <table border="0">
                        <tr>
                            <td align="center" colspan="2">
                                Sign Up for Your New Account</td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User 
                                Name:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                    ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                    ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                    ControlToValidate="Password" ErrorMessage="Password is required." 
                                    ToolTip="Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" 
                                    AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" 
                                    ControlToValidate="ConfirmPassword" 
                                    ErrorMessage="Confirm Password is required." 
                                    ToolTip="Confirm Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
                                    ControlToValidate="Email" ErrorMessage="E-mail is required." 
                                    ToolTip="E-mail is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Security 
                                Question:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" 
                                    ControlToValidate="Question" ErrorMessage="Security question is required." 
                                    ToolTip="Security question is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Security 
                                Answer:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" 
                                    ControlToValidate="Answer" ErrorMessage="Security answer is required." 
                                    ToolTip="Security answer is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblVoornaam" runat="server" Text="Voornaam"></asp:Label>
                            </td>
                        <td>
                            <asp:TextBox ID="txtVoornaam" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="AnswerRequired0" runat="server" 
                                ControlToValidate="txtVoornaam" ErrorMessage="Voornaam moet ingevuld zijn." 
                                ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                        <td align="right">
                                <asp:Label ID="lblNaam" runat="server" Text="Naam"></asp:Label>
                            </td>
                            <td style="font-weight: 700">
                                <asp:TextBox ID="txtNaam" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="AnswerRequired1" runat="server" 
                                    ControlToValidate="txtNaam" ErrorMessage="Naam moet ingevuld zijn." 
                                    ToolTip="Security answer is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                        <td align="right">
                                <asp:Label ID="lblGeboorte" runat="server" Text="Geboortedatum"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtGeboorte" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="AnswerRequired2" runat="server" 
                                    ControlToValidate="txtGeboorte" 
                                    ErrorMessage="Geboortedatum moet ingevuld zijn." 
                                    ToolTip="Security answer is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                        <td align="right">
                                <asp:Label ID="lblIdentiteitsnr" runat="server" Text="Identiteitsnummer"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtIdentiteitsNr" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="AnswerRequired3" runat="server" 
                                    ControlToValidate="txtIdentiteitsNr" 
                                    ErrorMessage="Identiteitsnummer moet ingevuld zijn." 
                                    ToolTip="Security answer is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                        <td align="right">
                                <asp:Label ID="lblRijbewijsnr" runat="server" Text="Rijbewijsnummer"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRijbewijsNr" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="AnswerRequired4" runat="server" 
                                    ControlToValidate="txtRijbewijsNr" 
                                    ErrorMessage="Rijbewijsnummer moet ingevuld zijn." 
                                    ToolTip="Security answer is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                                          
                        <tr>
                        <td align="right">
                                <asp:Label ID="lblTelefoon" runat="server" Text="Telefoon"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTelefoon" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="AnswerRequired5" runat="server" 
                                    ControlToValidate="txtTelefoon" ErrorMessage="Telefoon moet ingevuld zijn." 
                                    ToolTip="Security answer is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                        <td align="right">
                                <asp:Label ID="lblBTW" runat="server" Text="BTW-nummer"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBTW" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:CompareValidator ID="PasswordCompare" runat="server" 
                                    ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                    Display="Dynamic" 
                                    ErrorMessage="The Password and Confirmation Password must match." 
                                    ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="color:Red;">
                                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep runat="server" />
        </WizardSteps>
    </asp:CreateUserWizard>
    </form>
</body>
</html>