<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToggledOn.aspx.cs" Inherits="nToggleWebTestApp.ToggledOn" %>
<%@ Register assembly="nToggle" namespace="nToggle" tagprefix="nToggle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <nToggle:FeatureToggle ID="FeatureToggle1" FeatureName="TestFeatureOn" runat="server" >
    Turned On
    </nToggle:FeatureToggle>
    <nToggle:FeatureToggle ID="FeatureToggle2" FeatureName="TestFeatureOn" Reversed="true" runat="server" >
    Turned On But Reversed
    </nToggle:FeatureToggle>
</body>
</html>
