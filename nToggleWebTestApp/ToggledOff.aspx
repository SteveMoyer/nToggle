<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToggledOff.aspx.cs" Inherits="nToggleWebTestApp.ToggledOff" %>

<%@ Register assembly="nToggle" namespace="nToggle" tagprefix="nToggle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
  <nToggle:WebFeatureToggle ID="WebFeatureToggle1" EnabledBy="TestFeatureOff" runat="server" >
    <span id="enabledby"> Feature Turned Off</span>
    </nToggle:WebFeatureToggle>
    <nToggle:WebFeatureToggle ID="WebFeatureToggle2" RemovedBy="TestFeatureOff"  runat="server" >
    <span id="removedby">Feature Turned Off But Toggle is remove by feature</span>
    </nToggle:WebFeatureToggle>
  
</body>
</html>
