<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreePanelView.aspx.cs"
    Inherits="DemoWebApp.ASPX.Examples.TreePanelView" EnableSessionState="true" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
</head>
<body>
    <ext:ResourceManager runat="server" />
    <form id="form1" runat="server">
    <ext:TreePanel ID='TreePanel1' runat='server' Region='West' Padding='5' Width='250'
        Title='Tree Panel' RootVisible='False' DisplayField='name'>
        <Store>
            <ext:TreeStore ID="treeStore1" runat="server">
                <Model>
                    <ext:Model runat="server">
                        <Fields>
                            <ext:ModelField Name="name" />
                        </Fields>
                    </ext:Model>
                </Model>
                <Root>
                    <ext:Node NodeID="root" Expanded="True" AllowDrop="False">
                        <Children>
                            <ext:Node AllowDrag="False" EmptyChildren="True" Leaf="True" Checked="False">
                                <CustomAttributes>
                                    <ext:ConfigItem Name="name" Value="Tree Top" Mode="Value" />
                                </CustomAttributes>
                            </ext:Node>
                        </Children>
                    </ext:Node>
                </Root>
            </ext:TreeStore>
        </Store>
        <Listeners>
            <CheckChange Handler="var node = Ext.get(this.getView().getNode(item));
                                      node[checked ? 'addCls' : 'removeCls']('complete')" />
            <Render Handler="this.getRootNode().expand(true);" Delay="50" />
        </Listeners>
    </ext:TreePanel>
    <%--    <ext:Button runat="server">
        <Listeners>
            <Click Handler="App.direct.AddChild();"></Click>
        </Listeners>
    </ext:Button>--%>
    </form>
</body>
</html>
