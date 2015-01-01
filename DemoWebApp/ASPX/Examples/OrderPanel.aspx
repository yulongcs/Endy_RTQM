<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="OrderPanel.aspx.cs" Inherits="DemoWebApp.ASPX.Examples.OrderPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var SetOrderPanel = function (panel) {
            var childPanels = panel.items.items;
            var toolBar = <%=tbToolBar.ClientID %>;
            for (var i = 0; i < childPanels.length; i++) {
                    if (toolBar.isHidden()) {
                        childPanels[i].header.show();
                    } else {
                        childPanels[i].header.hide();
                    }
            }
            if (toolBar.isHidden()) {
                toolBar.show();
            } else {
                toolBar.hide();
            }
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Title" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <webezi:Panel runat="server" ID="plOrder" Width="500" Height="500" Title="Order Panel">
        <LayoutConfig>
            <ext:VBoxLayoutConfig Align="Stretch" DefaultMargins="5" />
        </LayoutConfig>
        <Tools>
            <ext:Tool Type="Gear" ToolTip="Setting">
                <Listeners>
                    <Click Handler="SetOrderPanel(#{plOrder});">
                    </Click>
                </Listeners>
            </ext:Tool>
        </Tools>
        <TopBar>
            <webezi:Toolbar runat="server" ID="tbToolBar" Hidden="True">
                <Items>
                    <webezi:Button runat="server" ID="btAddPanel" Icon="Add" Text="Add Panel">
                        <Menu>
                            <webezi:Menu runat="server">
                                <Items>
                                    <ext:CheckMenuItem runat="server" ID="chkMenu1" Text="Panel 1" Hidden="True" HideOnClick="True">
                                        <DirectEvents>
                                            <Click OnEvent="MenuItem_Click">
                                            </Click>
                                        </DirectEvents>
                                    </ext:CheckMenuItem>
                                    <ext:CheckMenuItem runat="server" ID="chkMenu2" Text="Panel 2" Hidden="True" HideOnClick="True">
                                        <DirectEvents>
                                            <Click OnEvent="MenuItem_Click">
                                            </Click>
                                        </DirectEvents>
                                    </ext:CheckMenuItem>
                                    <ext:CheckMenuItem runat="server" ID="chkMenu3" Text="Panel 3" Hidden="True" HideOnClick="True">
                                        <DirectEvents>
                                            <Click OnEvent="MenuItem_Click">
                                            </Click>
                                        </DirectEvents>
                                    </ext:CheckMenuItem>
                                    <ext:MenuItem ID="menuNoItem" runat="server" Text="No Item" CanActivate="false" HideOnClick="false"
                                        Disabled="True" Hidden="True" />
                                </Items>
                            </webezi:Menu>
                        </Menu>
                    </webezi:Button>
                    <webezi:ToolbarFill runat="server" />
                    <webezi:Button runat="server" Text="Save" Icon="DatabaseSave" OnDirectClick="SaveSetting_Click" />
                </Items>
            </webezi:Toolbar>
        </TopBar>
        <Items>
            <webezi:Panel ID="Panel1" runat="server" Frame="true" Flex="1">
                <Tools>
                    <ext:Tool Type="Close" ToolTip="Setting" OnDirectClick="ChildPanel_Close" />
                </Tools>
                <Listeners>
                    <Render Handler="this.header.hide();" />
                </Listeners>
            </webezi:Panel>
            <webezi:Panel ID="Panel2" runat="server" Frame="true" Flex="1">
                <Tools>
                    <ext:Tool Type="Close" ToolTip="Setting" OnDirectClick="ChildPanel_Close" />
                </Tools>
                <Listeners>
                    <Render Handler="this.header.hide();" />
                </Listeners>
            </webezi:Panel>
            <webezi:Panel ID="Panel3" runat="server" Frame="true" Flex="1">
                <Tools>
                    <ext:Tool Type="Close" ToolTip="Setting" OnDirectClick="ChildPanel_Close" />
                </Tools>
                <Listeners>
                    <Render Handler="this.header.hide();" />
                </Listeners>
            </webezi:Panel>
        </Items>
        <Plugins>
            <ext:BoxReorderer ID="BoxReorderer1" runat="server" />
        </Plugins>
    </webezi:Panel>
</asp:Content>
