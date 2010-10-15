<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToggledOn.aspx.cs" Inherits="nToggleWebTestApp.ToggledOn" %>
<%@ Register assembly="nToggle" namespace="nToggle" tagprefix="nToggle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <nToggle:FeatureToggle ID="FeatureToggle1" EnabledBy="TestFeatureOn" runat="server" >
    <span id="enabledby">Turned On</span>
    </nToggle:FeatureToggle>
    <nToggle:FeatureToggle ID="FeatureToggle2" RemovedBy="TestFeatureOn" runat="server" >
    <span id="removedby">Turned On But Reversed</span>
    </nToggle:FeatureToggle>
</body>
</html>
