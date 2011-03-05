<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToggledInCodeBehind.aspx.cs" Inherits="nToggleWebTestApp.ToggledInCodeBehind" %>
<%@ Register assembly="nToggle" namespace="nToggle" tagprefix="nToggle" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <nToggle:WebFeatureToggle ID="WebFeatureToggle" EnabledBy="TestFeatureOff" runat="server" >
    <span id="enabledby"> Feature Turned Off</span>
    </nToggle:WebFeatureToggle>
    </div>
    </form>
</body>
</html>
