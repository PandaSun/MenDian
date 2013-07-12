<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="mendian.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Demo</title>

<script type="text/javascript" src="http://api.map.baidu.com/api?v=1.5&ak=155a13775b05964774d4812b0d5c58e3"></script>

 
</head>
<body>
    <form id="form1" runat="server">

    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1">
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>

    </form>

    <div id="mymap" style="width: 800px; height: 436px; background-color: #00FFFF;" 
        align="center"></div>
</body>


 <script type="text/javascript">
     var map = new BMap.Map("mymap");            // 创建Map实例
     var point = new BMap.Point(116.404, 39.915);    // 创建点坐标
     map.centerAndZoom(point, 15);                     // 初始化地图,设置中心点坐标和地图级别。
     map.enableScrollWheelZoom();                            //启用滚轮放大缩小
</script>


</html>
