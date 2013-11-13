using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization.Json;

namespace WebUISite
{
    public partial class Baidu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GetLocal_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.DownloadFile("http://api.map.baidu.com/location/ip?ak=F454f8a5efe5e577997931cc01de3974&ip=58.42.230.88&coor=bd09ll", "C:\\ip.json");
            byte[] buffer = client.DownloadData("http://api.map.baidu.com/location/ip?ak=F454f8a5efe5e577997931cc01de3974&ip=202.198.16.3&coor=bd09ll");
            string js = client.DownloadString("http://api.map.baidu.com/location/ip?ak=F454f8a5efe5e577997931cc01de3974&ip=202.198.16.3&coor=bd09ll");
            Response.Write(js);
        }
    }

    [Serializable]
    public class LocationInfo
    {
        public string address { get; set; }
        public string content { get; set; }
        /*
    {  
        address: "CN|北京|北京|None|CHINANET|1|None",   #地址  
        content:       #详细内容  
        {  
            address: "北京市",   #简要地址  
            address_detail:      #详细地址信息  
            {  
                city: "北京市",        #城市  
                city_code: 131,       #百度城市代码  
                district: "",           #区县  
                province: "北京市",   #省份  
                street: "",            #街道  
                street_number: ""    #门址  
            },  
            point:               #百度经纬度坐标值  
            {  
                x: "116.39564504",  
                y: "39.92998578"  
            }  
        },  
        status: 0     #返回状态码  
    } 
         */
    }
}