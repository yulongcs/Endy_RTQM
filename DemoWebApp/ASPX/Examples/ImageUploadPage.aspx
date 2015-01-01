<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageUploadPage.aspx.cs"
    Inherits="DemoWebApp.ASPX.Examples.ImageUploadPage" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <style>
        .images-view .x-panel-body
        {
            background: white;
            font: 11px Arial, Helvetica, sans-serif;
        }
        
        .images-view .thumb-wrap
        {
            float: left;
            margin: 4px;
            margin-right: 0;
            padding: 5px;
        }
        
        .images-view .thumb-wrap span
        {
            display: block;
            overflow: hidden;
            text-align: center;
            width: 86px;
        }
        
        .images-view .thumb
        {
            background: #dddddd;
            padding: 3px;
            padding-bottom: 0;
        }
        
        .images-view .thumb img
        {
            height: 60px;
            width: 80px;
        }
        
        .images-view .x-item-selected
        {
            background: #eff5fb no-repeat right bottom;
            border: 1px solid #99bbe8;
            padding: 4px;
        }
        
        .images-view .x-item-selected .thumb
        {
            background: transparent;
        }
        
        .images-view .x-item-over
        {
            border: 1px solid #dddddd;
            background: #efefef repeat-x left top;
            padding: 4px;
        }
    </style>
    <ext:XScript runat="server">
        <Script type="text/javascript">
            var prepareData = function (data) {
                data.shortName = Ext.util.Format.ellipsis(data.name, 15);

                return data;
            };
            
            var selectionChanged = function (selModel, selected) {
			    var l = selected.length, s = l != 1 ? 's' : '';
			    #{listPanel}.setTitle('' + l + ' item' + s + ' selected');
		    };
        </Script>
    </ext:XScript>
</head>
<body>
    <ext:ResourceManager runat="server" Theme="Gray" />
    <form runat="server">
    <h1>Image Upload Example</h1>
    <ext:FormPanel runat="server" ID="BasicForm" Width="500" Frame="True" Title="Image Upload Form"
        PaddingSummary="10px 10px 0 10px">
        <Defaults>
            <ext:Parameter Name="anchor" Value="95%" Mode="Value" />
            <ext:Parameter Name="allowBlank" Value="false" Mode="Raw" />
            <ext:Parameter Name="msgTarget" Value="side" Mode="Value" />
        </Defaults>
        <Items>
            <ext:TextField runat="server" ID="photoName" FieldLabel="Name" />
            <ext:FileUploadField ID="FileUpload" runat="server" EmptyText="Select an image" FieldLabel="Photo"
                ButtonText="" Icon="ImageAdd">
            </ext:FileUploadField>
        </Items>
        <Listeners>
            <ValidityChange Handler="#{SaveButton}.setDisabled(!valid);" />
        </Listeners>
        <Buttons>
            <ext:Button ID="SaveButton" runat="server" Text="Save" Disabled="true">
                <DirectEvents>
                    <Click OnEvent="UploadClick" Before="if (!#{BasicForm}.getForm().isValid()) { return false; } 
                                Ext.Msg.wait('Uploading your image...', 'Uploading');" Failure="Ext.Msg.show({ 
                                title   : 'Error', 
                                msg     : 'Error during uploading', 
                                minWidth: 200, 
                                modal   : true, 
                                icon    : Ext.Msg.ERROR, 
                                buttons : Ext.Msg.OK 
                            });">
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button runat="server" Text="Reset">
                <Listeners>
                    <Click Handler="#{BasicForm}.getForm().reset();" />
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:FormPanel>
    <ext:Panel ID="listPanel" runat="server" Frame="True" Width="500" Height="300" Collapsible="True"
        Layout="FitLayout" Cls="images-view" Title="Image List 1">
        <Items>
            <ext:DataView runat="server" MultiSelect="True" EmptyText="No images to display"
                OverItemCls="x-item-over" ID="ImageView" TrackOver="True" ItemSelector="div.thumb-wrap">
                <Store>
                    <ext:Store ID="Store1" runat="server">
                        <Model>
                            <ext:Model runat="server" IDProperty="name">
                                <Fields>
                                    <ext:ModelField Name="name" />
                                    <ext:ModelField Name="url" />
                                </Fields>
                            </ext:Model>
                        </Model>
                    </ext:Store>
                </Store>
                <Tpl runat="server">
                    <Html>
                        <tpl for=".">
                                    <div id="{name}" class="thumb-wrap">
                                        <div class="thumb"><img src="{url}" title="{name}"/></div>
                                        <span>{shortName}</span>
                                    </div>
                                </tpl>
                    </Html>
                </Tpl>
                <PrepareData Fn="prepareData" />
                <Listeners>
                    <SelectionChange Fn="selectionChanged" />
                </Listeners>
                <Plugins>
                    <ext:DataViewDragSelector runat="server" />
                    <ext:DataViewLabelEditor runat="server" DataIndex="name" />
                </Plugins>
            </ext:DataView>
        </Items>
        <Buttons>
            <ext:Button runat="server" Text="Delete selected">
                <DirectEvents>
                    <Click OnEvent="btnDelete">
                        <ExtraParams>
                            <ext:Parameter Name="Values" Value="#{ImageView}.getRowsValues({selectedOnly:true})"
                                Mode="Raw" Encode="True" />
                        </ExtraParams>
                    </Click>
                </DirectEvents>
            </ext:Button>
        </Buttons>
    </ext:Panel>
    <br />
    <ext:Panel runat="server" Width="650" Height="300" Title="Image List 2" Layout="Fit">
        <Items>
            <ext:GridPanel ID="gp" runat="server">
                <Store>
                    <ext:Store runat="server">
                        <Model>
                            <ext:Model runat="server" IDProperty="name">
                                <Fields>
                                    <ext:ModelField Name="name" />
                                    <ext:ModelField Name="url" />
                                    <ext:ModelField Name="lastmod" />
                                </Fields>
                            </ext:Model>
                        </Model>
                    </ext:Store>
                </Store>
                <ColumnModel>
                    <Columns>
                        <ext:TemplateColumn runat="server" Text="File" DataIndex="url" TemplateString='<img style="width:60px;height:45px;" src="{url}">' />
                        <ext:Column runat="server" Text="File" Flex="35" DataIndex="name" />
                        <ext:TemplateColumn runat="server" Text="Last Modified" Flex="30" DataIndex="lastmod"
                            TemplateString='{lastmod:date("m-d h:i a")}' />
                    </Columns>
                </ColumnModel>
            </ext:GridPanel>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
