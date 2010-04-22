﻿<%@ Page Language="VB" MasterPageFile="~/App_Presentation/MasterPage.master" AutoEventWireup="false" CodeFile="Module.aspx.vb" Inherits="App_Presentation_Module" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/App_Presentation/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitel" Runat="Server">
    <asp:Label ID="lblTitel" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="gridview">
    <asp:UpdatePanel ID="updModuleOverzicht" runat="server">
   <ContentTemplate>

    <asp:DropDownList ID="ddlModule" runat="server"  
         AutoPostBack="true">
    </asp:DropDownList>
       <asp:Label ID="lblDropdown" runat="server" Text=""></asp:Label>
       &nbsp;&nbsp;
       <asp:CheckBox ID="ckbModules" runat="server" AutoPostBack="True" 
           Checked="True" />
       <asp:Label ID="lblCkb" runat="server" 
           Text=""></asp:Label>
    <asp:GridView ID="grdvmodule" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="ArtikelID" DataSourceID="sqldsModule" AllowPaging="true" PagerStyle-CssClass="gridview_pager" AllowSorting="true" PageSize="30" Width="100%">
        <Columns>
            <asp:BoundField DataField="Titel" HeaderText="Titel" SortExpression="Titel" />
            <asp:BoundField DataField="ArtikelID" HeaderText="ArtikelID" 
                InsertVisible="False" ReadOnly="True" SortExpression="ArtikelID" />
            <asp:TemplateField Headertext="">
            <ItemTemplate >
            <asp:HyperLink ID="HyperLink1" runat="server"  NavigateUrl='<%# DataBinder.Eval(Container.DataItem,"ArtikelID","Page.aspx?id={0}") %>'><asp:Image ID="Image1" runat="server" ImageUrl="~/App_Presentation/CSS/images/magnify.png" /></asp:HyperLink>
            </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <pagertemplate>
         <asp:label id="lblPagina" text="Pagina:" runat="server"/><br />      
        </pagertemplate>
                <PagerStyle CssClass="gridview_pager" />
    </asp:GridView>    
    </ContentTemplate>
    </asp:UpdatePanel></div>
    <asp:SqlDataSource ID="sqldsModule" runat="server" 
        ConnectionString="Data Source=PC_VAN_FRANK\SQLEXPRESS;Initial Catalog=Reference_manual;Persist Security Info=True;User ID=beerend;Password=beerend!" 
        ProviderName="System.Data.SqlClient" SelectCommand="Manual_getArtikelsByModule" 
        SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlModule" Name="Module" 
                PropertyName="SelectedValue" Type="String" />
            <asp:SessionParameter Name="FK_taal" SessionField="Taal" Type="Int32" />
            <asp:SessionParameter DefaultValue="" Name="FK_versie" SessionField="Versie" 
                Type="Int32" />
            <asp:SessionParameter DefaultValue="" Name="FK_Bedrijf" SessionField="Bedrijf" 
                Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:ObjectDataSource ID="objdModule" runat="server" 
        DeleteMethod="Delete" InsertMethod="Insert" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="ManualTableAdapters.tblModuleTableAdapter" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_moduleID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="_module" Type="String" />
            <asp:Parameter Name="Original_moduleID" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="_module" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
</asp:Content>

