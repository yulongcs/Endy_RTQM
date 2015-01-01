<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="TreePanel.aspx.cs" Inherits="DemoWebApp.ASPX.Examples.TreePanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Title" runat="server">
    <ul>
        <li><a href="/ASPX/Home.aspx">Home</a> </li>
        <li><span class="MenuTitle">Example</span> </li>
        <li><span class="c3">Tree Panel</span> </li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <ext:Panel runat="server" Width="1220" Height="600" Layout="HBoxLayout">
        <LayoutConfig>
            <ext:HBoxLayoutConfig Align="Stretch" />
        </LayoutConfig>
        <Items>
            <ext:Panel ID="panelView" runat="server" Title="Tree Panel View" BodyPadding="10"
                Flex="1">
                <Loader Url="TreePanelView.aspx" Mode="Frame" runat="server">
                    <LoadMask ShowMask="True" />
                </Loader>
            </ext:Panel>
            <ext:Panel ID="panelControl" runat="server" Title="Tree Panel Control" BodyPadding="10"
                Flex="1">
                <Loader runat="server" Url="TreePanelControl.aspx" Mode="Frame">
                    <LoadMask ShowMask="True" />
                </Loader>
            </ext:Panel>
        </Items>
    </ext:Panel>
</asp:Content>
