<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GaugeChart.aspx.cs" Inherits="DemoWebApp.ASPX.Examples.GaugeChart" MasterPageFile="~/Master/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Title" runat="server">
    <ul>
        <li><a href="/ASPX/Home.aspx">Home</a>/</li>
        <li><span class="MenuTitle">Examples</span>/</li>
        <li><span class="c3">Gauge</span></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
  <ext:Panel ID="Panel1" 
            runat="server"
            Title="Gauge Charts"
            Width="300"
            Height="150">
            <LayoutConfig>
                <ext:HBoxLayoutConfig Align="Stretch" />
            </LayoutConfig>
             <Items>
    <ext:Chart 
                    ID="Chart3" 
                    runat="server"
                    StyleSpec="background:#fff;"
                    InsetPadding="25"
                    Flex="1">
                    <AnimateConfig Easing="BounceOut" Duration="500" />
                    <Store>
                        <ext:Store ID="Store1" 
                            runat="server" 
                             Data="<%# Ext.Net.Examples.ChartData.GenerateData() %>" 
                            AutoDataBind="true">                           
                            <Model>
                                <ext:Model ID="Model1" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="Name" />
                                        <ext:ModelField Name="Data1" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <Axes>
                        <ext:GaugeAxis Minimum="0" Maximum="100" Steps="10" Margin="-5" />
                    </Axes>
                    <Series>
                        <ext:GaugeSeries AngleField="Data1" Donut="50" ColorSet="#3AA8CB,#ddd"  Needle="True"  />
                    </Series>
                </ext:Chart>
                 </Items>
                    </ext:Panel>
</asp:Content>