﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NieuweReservatieAanmaken.aspx.vb" Inherits="App_Presentation_NieuweReservatieAanmaken" EnableEventValidation="false" MasterPageFile="~/App_Presentation/MasterPage.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Main" ContentPlaceHolderID="plcMain" runat="server">

<script type='text/javascript'>
    function onddlCategorieChangeHandler(dd){
    	var dd2=$get('ddlKleur');
        dd2.selectedIndex=0;
        var cdd=$find('cddKleur');
        if(cdd!=null){
            cdd.set_SelectedValue('','');
            cdd._onParentChange(null,false);
        }
    }
</script>

    <asp:ScriptManager ID="scmManager" runat="server"></asp:ScriptManager>
    <div>
    <asp:UpdatePanel ID="updOverview" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <table>
        <tbody>
        <tr>
        <td>Autocategorie:</td>
        <td>
            <asp:DropDownList ID="ddlCategorie" runat="server">
            </asp:DropDownList>
            <cc1:CascadingDropDown ID="ccdCategorie" runat="server" Category="Categorie" 
                PromptText="Categorie" ServiceMethod="GeefCategorien" 
                TargetControlID="ddlCategorie" ServicePath="~/App_Presentation/WebServices/AutoService.asmx">
            </cc1:CascadingDropDown>
            <asp:Label ID="lblCategorieVerkeerd" runat="server"></asp:Label>
        </td>
        </tr>
        <tr>
        <td>Begindatum:</td>
        <td>
            <asp:TextBox ID="txtBegindatum" runat="server" CausesValidation="True"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valBegindatum" runat="server" ControlToValidate="txtBegindatum" ErrorMessage="Dit veld is verplicht."></asp:RequiredFieldValidator>
        </td>
        </tr>
        <tr>
        <td>Einddatum:</td>
        <td>
            <asp:TextBox ID="txtEinddatum" runat="server" CausesValidation="True"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valEinddatum" runat="server" ControlToValidate="txtBegindatum" ErrorMessage="Dit veld is verplicht."></asp:RequiredFieldValidator>
        </td>
        </tr>
        </tbody>
        </table>
        <asp:Label ID="lblDatumVerkeerd" runat="server"></asp:Label>
        <br /><br />
        Extra opties:<br />
        <table>
        <tbody>
        <tr>
        <td>Kleur</td>
        <td>Merk</td>
        </tr>
        <tr>
        <td>
        <asp:DropDownList ID="ddlKleur" runat="server"></asp:DropDownList>
        <cc1:CascadingDropDown ID="ccdKleur" runat="server" Category="Kleur" 
                ParentControlID="ddlCategorie" PromptText="Kleur Kiezen..." 
                ServiceMethod="GeefKleurPerCategorie" 
                ServicePath="~/App_Presentation/WebServices/AutoService.asmx" TargetControlID="ddlKleur">
        </cc1:CascadingDropDown>
        </td>
        <td>
        <asp:DropDownList ID="ddlMerk" runat="server"></asp:DropDownList>
        <cc1:CascadingDropDown ID="ccdMerk" runat="server" Category="Merk" 
                ParentControlID="ddlCategorie" PromptText="Merk Kiezen..." 
                ServiceMethod="GeefMerkenVoorCategorie" 
                ServicePath="~/App_Presentation/WebServices/AutoService.asmx" TargetControlID="ddlMerk">
        </cc1:CascadingDropDown>
        </td>
        </tr>
        </tbody>
        </table>

        <br />
            <asp:Button ID="btnToonOverzicht" Text="Geef beschikbare auto's" runat="server"/>
        <br />
        <br />
                
        Overzicht:<br />
        <asp:PlaceHolder ID="plcOverzicht" runat="server"></asp:PlaceHolder>
        <br />
        <asp:Repeater ID="repOverzicht" runat="server">
          <ItemTemplate>
            <a href="Reserveer.aspx?autoID=<%# DataBinder.Eval(Container.DataItem, "autoID") %>&begindat=<%# DataBinder.Eval(Container.DataItem, "begindat") %>&einddat=<%# DataBinder.Eval(Container.DataItem, "einddat") %>">
            <%# DataBinder.Eval(Container.DataItem, "modelnaam") %>, <%#DataBinder.Eval(Container.DataItem, "autoKleur")%><br />
            <%#DataBinder.Eval(Container.DataItem, "autoKenteken")%><br />
            </a>
          </ItemTemplate>
        </asp:Repeater>
            <asp:Label ID="lblGeenAutos" runat="server" Text="Label" Visible="false"></asp:Label>
        <br />
        </ContentTemplate>
        <Triggers>
        <%--
            <asp:AsyncPostBackTrigger ControlID="ddlCategorie" />
            <asp:AsyncPostBackTrigger ControlID="txtBegindatum" />
            <asp:AsyncPostBackTrigger ControlID="txtEinddatum" />  
        --%>
        </Triggers>
        </asp:UpdatePanel>
    
    </div>
    <asp:ObjectDataSource ID="odsReservatie" runat="server" 
        DataObjectTypeName="Reservatie&amp;" DeleteMethod="DeleteReservatie" 
        InsertMethod="InsertReservatie" SelectMethod="GetAllReservaties" 
        TypeName="ReservatieBLL">
        <DeleteParameters>
            <asp:Parameter Name="reservatieID" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
    <br />
</asp:Content>