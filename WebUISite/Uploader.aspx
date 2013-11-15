<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Uploader.aspx.cs" Inherits="WebUISite.Uploader" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
        .uImg {
            width: 200px;
            height: 150px;
            border: 1px solid #808080;
            padding: 2px;
            margin: 2px;
        }
    </style>
    <script src="Scripts/jquery-1.8.0.js"></script>
    <script src="Scripts/jquery.form.js"></script>
    <script type="text/ecmascript">
        var images = {
            "Image":
                [
                { "Url": "http://localhost:5597/temp/Chrysanthemum.jpg", "Name": "Chrysanthemum.jpg" },
                { "Url": "http://localhost:5597/temp/Desert.jpg", "Name": "Desert.jpg" },
                { "Url": "http://localhost:5597/temp/Hydrangeas.jpg", "Name": "Hydrangeas.jpg" },
                { "Url": "http://localhost:5597/temp/Jellyfish.jpg", "Name": "Jellyfish.jpg" },
                { "Url": "http://localhost:5597/temp/Koala.jpg", "Name": "Koala.jpg" },
                { "Url": "http://localhost:5597/temp/Lighthouse.jpg", "Name": "Lighthouse.jpg" },
                { "Url": "http://localhost:5597/temp/Penguins.jpg", "Name": "Penguins.jpg" },
                { "Url": "http://localhost:5597/temp/Tulips.jpg", "Name": "Tulips.jpg" }
                ]
        };
        jQuery(document).ready(function () {
            jQuery("#Upload").click(function () {
                jQuery("#form1").ajaxSubmit(function (jada) {
                    //alert(jada.Image[0].Url);
                    //var img = '<img src="" style="width: 200px; height: 150px; border: 1px solid #808080; padding: 2px; margin: 2px;" />';
                    var imgs = "";
                    jQuery(jada.Image).each(function () {
                        //jQuery(img).attr("src", this.Url).appendTo(jQuery("#content"));
                        imgs += '<img src="' + this.Url + '" class="uImg" />';
                        jQuery("#content").html(imgs);
                    });
                });
            });
        });
    </script>
    <title></title>
</head>
<body>
    <form action="FileSaver.ashx" id="form1" runat="server" enctype="multipart/form-data">
        <div>
            <input type="file" id="file1" name="file1" multiple="multiple" />
            <input type="button" value="ＯＫ" id="Upload" />
        </div>
        <div id="content"></div>
        <%--<div>
            <asp:FileUpload ID="UploadFile" runat="server" AllowMultiple="true" />
            <asp:Button ID="UploadButton" runat="server" Text="Upload" OnClick="UploadButton_Click" />
        </div>--%>
    </form>
</body>
</html>
