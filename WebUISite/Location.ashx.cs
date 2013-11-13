using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebUISite
{
    /// <summary>
    /// Location1 的摘要说明
    /// </summary>
    public class Location : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.Charset = "utf-8";
            var ak = context.Request.QueryString["ak"];
            var ip = context.Request.QueryString["ip"];
            var coor = context.Request.QueryString["coor"];
            WebClient client = new WebClient();
            string js = client.DownloadString(string.Format("http://api.map.baidu.com/location/ip?ak={0}&ip={1}&coor={2}", ak, ip, coor));
            context.Response.Write(js);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}