<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Baidu.aspx.cs" Inherits="WebUISite.Baidu" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <style type="text/css">
        body, html, #allmap {
            width: 100%;
            height: 100%;
            overflow: hidden;
            margin: 0;
        }

        #l-map {
            height: 100%;
            width: 78%;
            float: left;
            border-right: 2px solid #bcbcbc;
        }

        #r-result {
            height: 100%;
            width: 20%;
            float: left;
        }
    </style>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=4089b75950b02d507659eb4bd1f19c4a"></script>
    <script src="Scripts/jquery-1.8.0.js"></script>
    <script src="Scripts/Area.js"></script>
    <title>鼠标点击拾取坐标<%=Request.ServerVariables["REMOTE_ADDR"].ToString()%></title>
    <script type="text/javascript">        //119.84.126.222
        jQuery(document).ready(function () {
            // 百度地图API功能
            var map = new BMap.Map("l-map");
            map.centerAndZoom("北京", 12);                   // 初始化地图,设置城市和地图级别。
            map.enableScrollWheelZoom();                            //启用滚轮放大缩小
            map.addEventListener("click", function (e) {
                document.getElementById("r-result").innerHTML = e.point.lng + ", " + e.point.lat;
            });

            jQuery("#IP").click(function (e) {
                //http://api.map.baidu.com/location/ip?ak=F454f8a5efe5e577997931cc01de3974&ip=202.198.16.3&coor=bd09ll
                //jQuery.get("http://api.map.baidu.com/location/ip", { ak: '4089b75950b02d507659eb4bd1f19c4a', ip: '119.1.197.77', coor: 'bd09ll' }, function (data) {

                jQuery.get("/Location.ashx", { ak: "4089b75950b02d507659eb4bd1f19c4a", ip: "119.84.126.222", coor: "bd09ll" }, function (local) {
                    var city = local.content.address_detail.city;
                    //map.centerAndZoom(city, 12);                   // 初始化地图,设置城市和地图级别。
                    //-----------------------------
                    var point = new BMap.Point(local.content.point.x, local.content.point.y);//new BMap.Point(116.417854, 39.921988);//
                    map.centerAndZoom(point, 12);
                    var opts = {
                        width: 200,     // 信息窗口宽度
                        height: 60,     // 信息窗口高度
                        title: "海底捞王府井店", // 信息窗口标题
                        enableMessage: true,//设置允许信息窗发送短息
                        message: "亲耐滴，晚上一起吃个饭吧？戳下面的链接看下地址喔~"
                    }
                    var infoWindow = new BMap.InfoWindow("地址：北京市东城区王府井大街88号乐天银泰百货八层", opts);  // 创建信息窗口对象
                    map.openInfoWindow(infoWindow, point); //开启信息窗口
                    //-----------------------------
                }, "json");
            });
            /*
            {  
            address: "CN|吉林|长春|None|CERNET|1|None",  
            content: 
            {  
                address: "吉林省长春市",  
                    address_detail: 
                    {  
                        city: "长春市",  
                        city_code: 53,  
                        district: "",  
                        province: "吉林省",  
                        street: "",  
                        street_number: ""  
                    },  
                    point: 
                    {       
                        x: "125.31364243",      
                        y: "43.89833761"  
                    }  
                },  
                status: 0  
            } 
            */
            var area = new Area();
            jQuery("#Province").html("<option value='0'>请选择</option>" + area.getNextOption("0", "2488"));
            jQuery("#City").html("<option value='0'>请选择</option>" + area.getNextOption("2488", "2489"));
            jQuery("#Area").html("<option value='0'>请选择</option>" + area.getNextOption("2489", "2491"));
            //监听各个下拉列表
            jQuery("select").change(function () {
                var value = jQuery(this).val();
                var id = jQuery(this).attr("id");
                var options = "<option value='0'>请选择</option>" + area.getNextOption(value, null);
                if (id == "Province") {
                    jQuery("#City").html(options);
                    jQuery("#Area").html("<option value='0'>请选择</option>");
                } else if (id == "City") {
                    jQuery("#Area").html(options);
                }

                var city = jQuery(this).children("option[selected=selected]").html();
                map.centerAndZoom(city, 12);                   // 初始化地图,设置城市和地图级别。
            });
        });
    </script>
</head>
<body>
    <form runat="server" id="form1">
        <asp:Button ID="GetLocal" runat="server" Text="查询" OnClick="GetLocal_Click" />
        <select id="Province" name="Province" style="width: 100px;"></select>&nbsp;&nbsp;<select id="City" name="City" style="width: 100px;"></select>&nbsp;&nbsp;<select id="Area" name="Area" style="width: 100px;"></select>
    </form>
    <input type="button" value="查询" id="IP" />
    <div id="l-map"></div>
    <div id="r-result"></div>
</body>
</html>
<%--
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
<style type="text/css">
body, html,#allmap {width: 100%;height: 100%;overflow: hidden;margin:0;}
</style>
<script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=您的密钥"></script>
<title>纯文本的信息窗口</title>
</head>
<body>
<div id="allmap"></div>
</body>
</html>
<script type="text/javascript">

    // 百度地图API功能
    var map = new BMap.Map("allmap");
    var point = new BMap.Point(116.417854, 39.921988);
    map.centerAndZoom(point, 15);
    var opts = {
        width: 200,     // 信息窗口宽度
        height: 60,     // 信息窗口高度
        title: "海底捞王府井店", // 信息窗口标题
        enableMessage: true,//设置允许信息窗发送短息
        message: "亲耐滴，晚上一起吃个饭吧？戳下面的链接看下地址喔~"
    }
    var infoWindow = new BMap.InfoWindow("地址：北京市东城区王府井大街88号乐天银泰百货八层", opts);  // 创建信息窗口对象
    map.openInfoWindow(infoWindow, point); //开启信息窗口
</script>
--%>