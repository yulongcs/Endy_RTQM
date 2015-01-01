<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreePanelControl.aspx.cs"
    Inherits="DemoWebApp.ASPX.Examples.TreePanelControl" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
</head>
<body>
    <ext:ResourceManager runat="server" />
    <form id="form1" runat="server">
    <ext:Button ID="btnNew" runat="server" Text="New Item" Icon="Add">
        <Listeners>
            <Click Handler="parent.App.ContentPlaceHolder_Body_panelView.getBody().App.direct.AddChild();" />
        </Listeners>
    </ext:Button>
    <br />
    <ext:Button ID="btnRemove" runat="server" Text="Remove Item" Icon="Delete">
        <Listeners>
            <Click Handler="parent.App.ContentPlaceHolder_Body_panelView.getBody().App.direct.RemoveChild();" />
        </Listeners>
    </ext:Button>
    <br />
    <ext:Button ID="btnChange" runat="server" Text="Change Item" Icon="ImageEdit">
        <Listeners>
            <Click Handler="parent.App.ContentPlaceHolder_Body_panelView.getBody().App.direct.ChangeItem();" />
        </Listeners>
    </ext:Button>
    </form>
</body>
</html>
