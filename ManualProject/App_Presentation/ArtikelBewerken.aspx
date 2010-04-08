﻿<%@ Page Language="VB" MasterPageFile="~/App_Presentation/MasterPage.master" AutoEventWireup="false" CodeFile="ArtikelBewerken.aspx.vb" Inherits="App_Presentation_ArtikelBewerken" title="Untitled Page"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Artikel Bewerken</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderTitel" runat="server">
    Artikel Bewerken
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divLoggedIn" runat="server">
    <asp:UpdatePanel ID="updZoeken" runat="server" UpdateMode="Conditional">
<ContentTemplate>

<table>
<tr>
<th align="left">Zoekopdracht verfijnen</th>
</tr>
<tr>
<td class="lbl"><asp:Label ID="lblVersieVerfijnen" runat="server" Text="Versie: "></asp:Label></td>
<td><asp:DropDownList ID="ddlVersieVerfijnen" runat="server" Width="100%"></asp:DropDownList></td>
<td><span style="vertical-align:middle" id='tipVersieVerfijnen'><img src="CSS/images/help.png" alt=''/></span></td>
</tr>
<tr>
<td class="lbl"><asp:Label ID="lblTaalVerfijnen" runat="server" Text="Taal: "></asp:Label></td>
<td><asp:DropDownList ID="ddlTaalVerfijnen" runat="server" Width="100%"></asp:DropDownList></td>
<td><span style="vertical-align:middle" id='tipTaalVerfijnen'><img src="CSS/images/help.png" alt=''/></span></td>
</tr>
<tr>
<td class="lbl"><asp:Label ID="lblBedrijfVerfijnen" runat="server" Text="Bedrijf: "></asp:Label></td>
<td><asp:DropDownList ID="ddlBedrijfVerfijnen" runat="server" Width="100%"></asp:DropDownList></td>
<td><span style="vertical-align:middle" id='tipBedrijfVerfijnen'><img src="CSS/images/help.png" alt=''/></span></td>
</tr>
<tr>
<td class="lbl"><asp:Label ID="lblFinaalVerfijnen" runat="server" Text="Artikel is finaal: "></asp:Label></td>
<td><asp:DropDownList ID="ddlIsFInaalVerfijnen" runat="server" Width="100%"></asp:DropDownList></td>
<td><span style="vertical-align:middle" id='tipIsFinaalVerfijnen'><img src="CSS/images/help.png" alt=''/></span></td>
</tr>
<tr>
<th align="left">Zoeken op...</th>
</tr>
<tr>
    <td class="lbl">
        <asp:Label ID="lblZoekTitel" runat="server" Text="Titel of trefwoord: "></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtZoekTitel" runat="server" Width="100%"></asp:TextBox>
        <asp:CustomValidator ID="vleZoekTitel" runat="server" 
            ClientValidationFunction="ValideerZoekTerm" ControlToValidate="txtZoekTitel" 
            Display="None" ErrorMessage="Gelieve een zoekterm in te geven." 
            OnServerValidate="ValideerZoekTerm" ValidateEmptyText="true" 
            ValidationGroup="zoekTitel"></asp:CustomValidator>
        <cc2:ValidatorCalloutExtender ID="extSearchTitel" runat="server" 
            TargetControlID="vleZoekTitel">
        </cc2:ValidatorCalloutExtender>
    </td>
    <td>
        <span ID="tipZoekTitel" style="vertical-align: middle">
        <img alt="" src="CSS/images/help.png" /></span></td>
    <tr>
        <td class="lbl">
            <asp:Label ID="lblZoekTag" runat="server" Text="Artikeltag: "></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtZoekTag" runat="server" Width="100%"></asp:TextBox>
            <asp:CustomValidator ID="vleZoekTag" runat="server" 
                ClientValidationFunction="ValideerZoekTerm" ControlToValidate="txtZoekTag" 
                Display="None" ErrorMessage="Gelieve een tag in te geven." 
                OnServerValidate="ValideerZoekTerm" ValidateEmptyText="true" 
                ValidationGroup="zoekTitel"></asp:CustomValidator>
            <cc2:ValidatorCalloutExtender ID="extZoekTag" runat="server" 
                TargetControlID="vleZoekTag">
            </cc2:ValidatorCalloutExtender>
        </td>
        <td>
            <span ID="tipZoekTag" style="vertical-align: middle">
            <img alt="" src="CSS/images/help.png" /></span></td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="btnZoek" runat="server" Text="Zoeken" 
                ValidationGroup="zoekTitel" Width="100%" />
        </td>
        <td>
            <asp:UpdateProgress ID="prgZoeken" runat="server" 
                AssociatedUpdatePanelID="updZoeken" DisplayAfter="0">
                <ProgressTemplate>
                    <div style="vertical-align: middle">
                        <img src="CSS/Images/ajaxloader.gif" /> Even wachten aub...
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </td>
    </tr>

</table>
                        
<script type="text/javascript">
<!--
function ValideerZoekTerm (source, args)
{
    // Default Value
    args.IsValid = true;

    var resultaten = document.getElementById('<%=txtZoekTag.clientID%>').value + document.getElementById('<%=txtZoekTitel.clientID%>').value;
    
    if( resultaten === '' )
        args.isValid = false;
    
}
-->
</script>

<br />
<div id="divResultatenTonen" runat="server" visible="false">
<ul class="list-menu">
            <li><a href="#" onclick="Effect.toggle('divZoekResultaten', 'slide'); return false;"><span class="l"></span><span class="r"></span>
                <span class="t"><img src="CSS/images/magnify.png" border="0" style="vertical-align:middle;" />&nbsp;Resultaten Openen / Sluiten</span></a> </li>
</ul>

</div>
<div id="divZoekResultaten" style="display:none;">
<div id="gridview">
            <asp:GridView ID="grdvLijst" runat="server" AutoGenerateColumns="False" Visible="false" Width="100%">
        <Columns>
            <asp:BoundField DataField="Titel" HeaderText="Titel" SortExpression="Titel" />
            <asp:BoundField DataField="Tag" HeaderText="Tag" SortExpression="Tag" />
            <asp:BoundField DataField="Versie" HeaderText="Versie" 
                SortExpression="Versie" />
            <asp:BoundField DataField="Naam" HeaderText="Bedrijf" SortExpression="Bedrijf" />
            <asp:BoundField DataField="Taal" HeaderText="Taal" SortExpression="Taal" />
            <asp:BoundField DataField="Is_final" HeaderText="Finale Versie" 
                SortExpression="Is_final" />
            <asp:CommandField ButtonType="Image" 
                SelectImageUrl="~/App_Presentation/CSS/images/wrench.png" 
                ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
</div>

</div>


</ContentTemplate>
</asp:UpdatePanel>
<br />
    <asp:UpdatePanel ID="updBewerken" runat="server" UpdateMode="conditional">
    <ContentTemplate>

<div runat="server" id="divInvullen">
    
        <asp:UpdatePanel ID="updCategorie" runat="server" UpdateMode="conditional">
    <ContentTemplate>
    
<table>
<tr>
<td class="lbl">   <asp:Label ID="lblTitel" runat="server" Text="Titel: " ></asp:Label></td> 
    <td> <asp:TextBox ID="txtTitel" runat="server" Width="100%"></asp:TextBox>
        <asp:RequiredFieldValidator
        ID="vleTitel" runat="server" ErrorMessage="Gelieve een titel in te geven." 
        ControlToValidate="txtTitel" Display="None" ValidationGroup="bewerkTekst"></asp:RequiredFieldValidator>
    <cc2:ValidatorCalloutExtender
            ID="extTitel" runat="server" TargetControlID="vleTitel">
        </cc2:ValidatorCalloutExtender>
    </td> 
    <td>
    <span style="vertical-align:middle" id='tipTitel'><img src="CSS/images/help.png" alt=''/></span>
    </td>
  </tr>
  <tr>  
   <td class="lbl">  <asp:Label ID="lblTag" runat="server" Text="Tag:"></asp:Label></td> 
   <td>  <asp:TextBox ID="txtTag" runat="server" Width="100%"></asp:TextBox>
   <asp:RequiredFieldValidator
        ID="vleTag" runat="server" Display="None" 
        ErrorMessage="Gelieve een tag in te geven. Deze mag enkel letters, nummers en een underscore ( _ ) bevatten." 
        ControlToValidate="txtTag" ValidationGroup="bewerkTekst"></asp:RequiredFieldValidator>
    <cc2:ValidatorCalloutExtender
            ID="extTag" runat="server" TargetControlID="vleTag">
        </cc2:ValidatorCalloutExtender>
    <cc2:FilteredTextBoxExtender ID="fltTag" runat="server" 
        FilterType="Custom, Numbers, UppercaseLetters, LowercaseLetters" TargetControlID="txtTag" 
        ValidChars="_"></cc2:FilteredTextBoxExtender>
   </td>
   <td>
   <span style="vertical-align:middle" id='tipTag'><img src="CSS/images/help.png" alt=''/></span>
   </td>
  </tr>
<tr>
<td class="lbl"><asp:Label ID="lblTaal" runat="server" Text="Taal:"></asp:Label></td>
<td><asp:DropDownList ID="ddlTaal" runat="server" AutoPostBack="true" Width="100%">
    </asp:DropDownList>
</td>
<td>
<span style="vertical-align:middle" id='tipTaal'><img src="CSS/images/help.png" alt=''/></span>
</td>
</tr>

<tr>
<td class="lbl"><asp:Label ID="lblBedrijf" runat="server" Text="Bedrijf:"></asp:Label></td>
<td><asp:DropDownList ID="ddlBedrijf" runat="server" AutoPostBack="true" Width="100%">
    </asp:DropDownList>
</td>
<td>
<span style="vertical-align:middle" id='tipBedrijf'><img src="CSS/images/help.png" alt=''/></span>
</td>
</tr>

<tr>
<td class="lbl"><asp:Label ID="lblVersie" runat="server" Text="Versie:"></asp:Label></td>
<td><asp:DropDownList ID="ddlVersie" runat="server" AutoPostBack="true" Width="100%"> 
    </asp:DropDownList>
</td>
<td>
<span style="vertical-align:middle" id='tipVersie'><img src="CSS/images/help.png" alt=''/></span>
</td>
</tr>

<tr>
<td class="lbl"><asp:Label ID="lblCategorie" runat="server" Text="Categorie:"></asp:Label></td>
<td><asp:DropDownList ID="ddlCategorie" runat="server" Width="100%"></asp:DropDownList>
    <asp:Label ID="lblGeenCategorie" runat="server" Text="Er zijn geen categorieën beschikbaar." Visible="false"></asp:Label>
</td>
<td>
<span style="vertical-align:middle" id='tipCategorie'><img src="CSS/images/help.png" alt=''/></span>
</td>
<td>
    <asp:UpdateProgress ID="prgCategorie" runat="server" AssociatedUpdatePanelID="updCategorie">
    <ProgressTemplate>
    <div class="update">
    <img src="CSS/Images/ajaxloader.gif" />
    Bezig met ophalen van categoriëen...
    </div>
    </ProgressTemplate>
    </asp:UpdateProgress>
</td>
</tr>

<tr>
<td class="lbl"><asp:Label ID="lblIs_final" runat="server" Text="Finale versie: " 
        Visible="true"></asp:Label></td>
        <td><asp:CheckBox ID="ckbFinal" runat="server" Visible="true" />
        <span style="vertical-align:middle" id='tipFinaal'><img src="CSS/images/help.png" alt=''/></span>
        </td>
</tr>
 
    </table>  

</ContentTemplate>
</asp:UpdatePanel>

<asp:UpdatePanel ID="updContent" runat="server" UpdateMode="Conditional">
<ContentTemplate>

<table>
<tr>
<td align="center">Sjabloon selecteren&nbsp;<span style="vertical-align:middle" id='tipSjabloon'><img src="CSS/images/help.png" alt=''/></span></td>
<td align="center">Afbeelding toevoegen&nbsp;<span style="vertical-align:middle" id='tipUpload'><img src="CSS/images/help.png" alt=''/></span></td>
</tr>
<tr>
<td align="center"><asp:ListBox runat="server" ID="lstSjablonen" width="100%"></asp:ListBox></td>
<td align="center">
<asp:UpdatePanel runat="server" id="updAfbeelding" UpdateMode="Conditional">
<ContentTemplate>

<asp:FileUpload runat="server" ID="uplAfbeelding" onchange="checkExtensies(this);" width="100%" />
    <asp:UpdateProgress ID="prgAfbeelding" runat="server" AssociatedUpdatePanelID="updAfbeelding">
    <ProgressTemplate>
    <div class="update">
    <img src="CSS/Images/ajaxloader.gif" />
    Bezig met uploaden...
    </div>
    </ProgressTemplate>
    </asp:UpdateProgress>
    
    <script type="text/javascript">

function checkExtensies( filename )
{
    var lijst = filename.value.split('.');
    var ext = lijst.pop();

    if(  ext == 'gif' || ext == 'jpg' || ext == 'jpeg' || ext == 'png' )
    {
        document.getElementById('lblFeedback').innerHTML = '';
        document.getElementById('lblFeedback').style.display = 'none';
        document.getElementById('<%=btnImageToevoegen.ClientID %>').style.display = 'inline';
        return true;
    }
    else
    {
        document.getElementById('lblFeedback').innerHTML = 'Dit is geen geldige afbeelding.<br/> Enkel JPEG, GIF en PNG-afbeeldingen zijn toegestaan.';
        document.getElementById('lblFeedback').style.display = 'inline';
        document.getElementById('<%=btnImageToevoegen.ClientID %>').style.display = 'none';
        return false;
    }
}

</script>
    
</ContentTemplate>
<Triggers>
<asp:PostBackTrigger ControlID="btnImageToevoegen" />
</Triggers>
</asp:UpdatePanel>
</td>
</tr>
<tr>
<td align="center"><asp:Button runat="server" ID="btnSjablonen" Text="Sjabloon Toevoegen" width="100%" CausesValidation="false" style="vertical-align:middle;" /></td>
<td align="center"><asp:button runat="server" ID="btnImageToevoegen" Text="Afbeelding Toevoegen"  width="100%" CausesValidation="false"  style="vertical-align:middle;" /><span id="lblFeedback"  style="vertical-align:middle;display:none"></span></td>
</tr>
</table>
<br />
    <div>
    <a href="#" onclick="VeranderEditorScherm(200);">Vergroot Editor</a>
    &nbsp;|&nbsp;
    <a href="#" onclick="VeranderEditorScherm(-200);">Verklein Editor</a>
    </div>

<cc1:Editor ID="Editor1" runat="server" CssClass="editorWindow"/>


</ContentTemplate>
</asp:UpdatePanel>

</div>
<br />
<div style="text-align:center;">
        <asp:Button ID="btnUpdate" runat="server" Text="Artikel Wijzigen" Visible="false" ValidationGroup="bewerkTekst"/>
    <asp:UpdateProgress ID="prgUpdaten" runat="server" AssociatedUpdatePanelID="updBewerken">
    <ProgressTemplate>
    <div class="update">
    <img src="CSS/Images/ajaxloader.gif" />
    Bezig met opslaan...
    </div>
    </ProgressTemplate>
    </asp:UpdateProgress>
    <div runat="server" id="divFeedback" visible="false">
        <asp:Image ID="imgResultaat" runat="server" />&nbsp;<asp:Label ID="lblresultaat" runat="server"></asp:Label><br />
    </div>

</div>

</ContentTemplate>
</asp:UpdatePanel>
</div>
</asp:Content>


