<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="WebUISite.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <%--<script src="Scripts/jquery-1.8.0.js"></script>--%>
    <link href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" rel="stylesheet" />

    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>

    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>

    <link href="http://jqueryui.com/resources/demos/style.css" rel="stylesheet" />
    <script src="Scripts/MagnificPopup.js"></script>

    <style type="text/css">
        .draggable {
            width: 90px;
            height: 90px;
            padding: 0.5em;
            float: left;
            margin: 0 10px 10px 0;
        }

        #draggable, #draggable2 {
            margin-bottom: 20px;
        }

        #draggable {
            cursor: n-resize;
        }

        #draggable2 {
            cursor: e-resize;
        }

        #containment-wrapper {
            width: 95%;
            height: 150px;
            border: 2px solid #ccc;
            padding: 10px;
        }

        h3 {
            clear: left;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("#draggable").draggable({ axis: "y" });
            $("#draggable2").draggable({ axis: "x" });
            $("#draggable3").draggable({ containment: "#containment-wrapper", scroll: false });
            $("#draggable5").draggable({ containment: "parent" });
            $("#tuotuo").draggable({ containment: "body" });
            $("#tuotuo2").draggable({ containment: "#tuotuo" });
            $("#tuotuo3").draggable({ containment: "#tuotuo2", axis: "x", scroll: true });
        });
    </script>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="tuotuo" style="width: 200px; height: 200px; background: #808080;">
            <div id="tuotuo2" style="width: 100px; height: 100px; background: #ff6a00;">
                <div id="tuotuo3" style="width: 50px; height: 50px; background: #b6ff00;"></div>
            </div>
        </div>
        <div id="draggable" class="draggable ui-widget-content">
            <p>I can be dragged only vertically</p>
        </div>
        <div id="draggable2" class="draggable ui-widget-content">
            <p>I can be dragged only horizontally</p>
        </div>
        <h3>Or to within another DOM element:</h3>
        <div id="containment-wrapper">
            <div id="draggable3" class="draggable ui-widget-content">
                <p>I'm contained within the box</p>
            </div>
            <div class="draggable ui-widget-content">
                <p id="draggable5" class="ui-widget-header">I'm contained within my parent</p>
            </div>
        </div>
    </form>
</body>
</html>
