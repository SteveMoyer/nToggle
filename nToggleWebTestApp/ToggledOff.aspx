<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToggledOff.aspx.cs" Inherits="nToggleWebTestApp.ToggledOff" %>

<%@ Register assembly="nToggle" namespace="nToggle" tagprefix="nToggle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
  <nToggle:FeatureToggle ID="FeatureToggle1" FeatureName="TestFeatureOff" runat="server" >
    Turned Off
    </nToggle:FeatureToggle>
    <nToggle:FeatureToggle ID="FeatureToggle2" FeatureName="TestFeatureOff" Reversed="true" runat="server" >
    Turned Off But Reversed
    </nToggle:FeatureToggle>
  
</body>
</html>
