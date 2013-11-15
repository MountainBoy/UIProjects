using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace WebUISite
{
    /// <summary>
    /// FileSaver 的摘要说明
    /// </summary>
    public class FileSaver : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            /*             
          myObject = {
          "first": "John",
          "last": "Doe",
          "age": 39,
          "sex": "M",
          "salary": 70000,
          "registered": true,
          "interests": [ "Reading", "Mountain Biking", "Hacking" ],
          "favorites": {
            "color": "Blue",
            "sport": "Soccer",
            "food": "Spaghetti"
          }, 
          "skills": [
            {
              "category": "JavaScript",
              "tests": [
                { "name": "One", "score": 90 },
                { "name": "Two", "score": 96 }
              ] 
            },
            {
              "category": "CouchDB",
              "tests": [
                { "name": "One", "score": 79 },
                { "name": "Two", "score": 84 }
              ] 
            },
            {
              "category": "Node.js",
              "tests": [
                { "name": "One", "score": 97 },
                { "name": "Two", "score": 93 }
              ] 
            }
          ]
        }
             */
            context.Response.ContentType = "application/json";
            HttpFileCollection hfc = context.Request.Files;
            var count = hfc.Count;
            StringBuilder sb = new StringBuilder();
            //var holder = "{ \"Image\" : [ { \"Url\" : \"{0}\", \"Name\" : \"{1}\" } ] }";
            var jade = " \"Url\" : \"{0}\", \"Name\" : \"{1}\" ";

            for (var i = 0; i < count; i++)
            {
                try
                {
                    HttpPostedFile hpf = hfc[i] as HttpPostedFile;
                    var ct = hpf.ContentType;
                    hpf.SaveAs(Path.Combine(HttpContext.Current.Server.MapPath("~/temp"), hpf.FileName));
                    if (i > 0)
                    {
                        sb.Append(", ");
                    }
                    var str = "{" + string.Format(jade, "http://localhost:5597/temp/" + hpf.FileName, hpf.FileName) + "}";
                    sb.Append(str);
                }
                catch (Exception e)
                {
                    context.Response.Write(e.Message + "<br />");
                    continue;
                }
                //context.Response.Write(k + "<br />");
                //context.Response.Write(context.Request.Files[k.ToString()].FileName);
                //context.Request.SaveAs("C:\\Http.txt", true);}

                //HttpPostedFile fs = hfc["file1"];
                //fs.SaveAs("C:\\" + fs.FileName);
            }
            //var holder = "{ \"Image\" : [ { \"Url\" : \"{0}\", \"Name\" : \"{1}\" } ] }";
            context.Response.Write("{ \"Image\" : [ " + sb.ToString() + " ] }");
            //context.Response.Write("<br />Hello World");
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