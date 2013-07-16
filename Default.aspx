<%@ Page Title="主页" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="mendian._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table>
<tr><td>区域:<asp:CheckBoxList ID="cbl_Quyu" runat="server" AutoPostBack="True" 
        RepeatColumns="10" RepeatDirection="Horizontal" Width="1130px">
    <asp:ListItem Selected="True">不限</asp:ListItem>
    <asp:ListItem>黄浦区</asp:ListItem>
    <asp:ListItem>徐汇区</asp:ListItem>
    <asp:ListItem>长宁区</asp:ListItem>
    <asp:ListItem>静安区</asp:ListItem>
    <asp:ListItem>普陀区</asp:ListItem>
    <asp:ListItem>闸北区</asp:ListItem>
    <asp:ListItem>浦东区</asp:ListItem>
    <asp:ListItem>虹口区</asp:ListItem>
    <asp:ListItem>杨浦区</asp:ListItem>
    </asp:CheckBoxList>
    </td></tr>
<tr><td>公司:<asp:CheckBoxList ID="cbl_GongSi" runat="server" AutoPostBack="True" 
        RepeatColumns="15" RepeatDirection="Horizontal" Width="1130px">
    </asp:CheckBoxList>
    </td></tr>
<tr><td><div id="mymap" style="width: 1160px; height: 800px" align="center"></div></td></tr>
</table>

<script type="text/javascript">
    var map = new BMap.Map("mymap");                        // 创建Map实例
    map.centerAndZoom(new BMap.Point(121.477755,31.224322), 14);     // 初始化地图,设置中心点坐标和地图级别
    map.addControl(new BMap.NavigationControl());               // 添加平移缩放控件
    map.addControl(new BMap.ScaleControl());                    // 添加比例尺控件
    map.addControl(new BMap.OverviewMapControl({ isOpen: true }));               //添加缩略地图控件
    map.enableScrollWheelZoom();                            //启用滚轮放大缩小
    map.addControl(new BMap.MapTypeControl());          //添加地图类型控件
    map.setCurrentCity("上海");          // 设置地图显示的城市 此项是必须设置的
                     <% GetMenDian(); %>;   
                    for (i = 0; i < MenDians.length; i++) {
                    var zuobiao = new Array();
                    zuobiao=MenDians[i].split(",");
                       var marker1 = new BMap.Marker(new BMap.Point(zuobiao[1], zuobiao[2]));
                           map.addOverlay(marker1); 
var sContent =
"<h2 style='margin:0 0 5px 0;padding:0.2em 0'>爱戴美瞳站</h2>" + 
"<img style='float:right;margin:4px' id='imgDemo' src='pic/aidaizhaofeng.jpg' width='139' height='104' title='爱戴美瞳站'/>" + 
"<p style='margin:0;line-height:1.5;font-size:13px;text-indent:2em'>地址:长宁区长宁路999号兆丰广场1楼(近汇川路)    联系电话:(021)52419789</p>" + 
"</div>";
     var infoWindow1 = new BMap.InfoWindow(sContent );
    marker1.addEventListener("click", function () { this.openInfoWindow(infoWindow1); });
                    }
</script>

    </asp:Content>
