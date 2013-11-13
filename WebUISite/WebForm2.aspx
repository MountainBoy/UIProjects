<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebUISite.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/jquery-1.8.0.js"></script>
    <script src="Scripts/jquery.ui.core.js"></script>
    <script src="Scripts/jquery.ui.widget.js"></script>
    <script src="Scripts/jquery.ui.mouse.js"></script>
    <script src="Scripts/jquery.ui.sortable.js"></script>
    <style type="text/css">
        ul {
            list-style: square;
            top: 50%;
            position: absolute;
        }

            ul li {
                /*display: inline-block;*/
                border: 1px solid green;
                width: 320px;
                height: 16px;
                padding: 3px;
                margin-bottom: 5px;
                text-align: center;
            }

        #DragUL li {
            height: 25px;
            position: relative;
        }
    </style>
    <script type="text/ecmascript">
        $(document).ready(function () {
            $LI = "";
        });
        $(function () {
            $("#Sortable").sortable({
                placeholder: "ui-state-highlight"
            });
            $("#Sortable").disableSelection();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ul id="Sortable">
                <li>1</li>
                <li>2</li>
                <li>3</li>
                <li>4</li>
                <li>5</li>
                <li>6</li>
                <li>7</li>
            </ul>
        </div>
        <script type="text/ecmascript">
            var beginMoving = false;
            function MouseDownToMove(obj) {
                obj.style.zIndex = 1;
                obj.mouseDownY = event.clientY;
                obj.mouseDownX = event.clientX;
                beginMoving = true;
                obj.setCapture();
            }//欢迎来到站长特效网，我们的网址是www.zzjs.net，很好记，zz站长，js就是js特效，本站收集大量高质量js代码，还有许多广告代码下载。
            function MouseMoveToMove(obj) {
                if (!beginMoving) {
                    return false;
                }
                obj.style.top = (event.clientY - obj.mouseDownY);
                obj.style.left = (event.clientX - obj.mouseDownX);
            }
            function MouseUpToMove(obj) {
                if (!beginMoving) {
                    return false;
                }
                obj.releaseCapture();
                obj.style.top = 0;
                obj.style.left = 0;
                obj.style.zIndex = 0;
                beginMoving = false;
                var tempTop = event.clientY - obj.mouseDownY;
                var tempRowIndex = (tempTop - (tempTop % 25)) / 25;
                if (tempRowIndex + obj.rowIndex < 0) {
                    tempRowIndex = -1;
                }
                else {
                    tempRowIndex = tempRowIndex + obj.rowIndex;
                }
                if (tempRowIndex >= obj.parentElement.rows.length - 1) {
                    tempRowIndex = obj.parentElement.rows.length - 1;
                }
                obj.parentElement.moveRow(obj.rowIndex, tempRowIndex);
            }//欢迎来到站长特效网，我们的网址是www.zzjs.net，很好记，zz站长，js就是js特效，本站收集大量高质量js代码，还有许多广告代码下载。
        </script>
        <div>
            <ul id="DragUL" style="left: 50%;">
                <li onmousedown="MouseDownToMove(this)" onmousemove="MouseMoveToMove(this)" onmouseup="MouseUpToMove(this);">1</li>
                <li onmousedown="MouseDownToMove(this)" onmousemove="MouseMoveToMove(this)" onmouseup="MouseUpToMove(this);">2</li>
                <li onmousedown="MouseDownToMove(this)" onmousemove="MouseMoveToMove(this)" onmouseup="MouseUpToMove(this);">3</li>
                <li onmousedown="MouseDownToMove(this)" onmousemove="MouseMoveToMove(this)" onmouseup="MouseUpToMove(this);">4</li>
                <li onmousedown="MouseDownToMove(this)" onmousemove="MouseMoveToMove(this)" onmouseup="MouseUpToMove(this);">5</li>
                <li onmousedown="MouseDownToMove(this)" onmousemove="MouseMoveToMove(this)" onmouseup="MouseUpToMove(this);">6</li>
                <li onmousedown="MouseDownToMove(this)" onmousemove="MouseMoveToMove(this)" onmouseup="MouseUpToMove(this);">7</li>
            </ul>
        </div>
    </form>
</body>
</html>
