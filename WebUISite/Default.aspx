<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebUISite.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="Scripts/jquery-1.8.0.js"></script>
    <title></title>
    <style type="text/css">
        #target {
            border: 1px solid red;
            /*padding: 10px;*/
            width: 320px;
            height: 240px;
        }

        .widget {
            width: 100%;
            height: 100%;
            border: 1px dashed green;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <fieldset>
            <legend>add()</legend>
            <div id="target">target</div>
            <div id="footdiv">footer</div>
            <script type="text/javascript">
                $("#target").add("div").addClass("widget");
                $("div").css("border", "1px solid black")
                .add("p")
                .css("background", "yellow");

                $("#footdiv").clone().add("<footer>Footer</footer>").appendTo(document.body);
                $("#footdiv").add(document.getElementById("target")).css("border", "1px solid red");
            </script>
        </fieldset>
        <fieldset>
            <legend>addBack()</legend>
            <ul>
                <li>1</li>
                <li>2</li>
                <li class="third-item">3</li>
                <li>4</li>
                <li>5</li>
            </ul>
            <script type="text/javascript">
                $("li.third-item").nextAll().addBack().css("background-color", "red");
            </script>
            <style type="text/css">
                p, div {
                    margin: 5px;
                    padding: 5px;
                }

                .border {
                    border: 2px solid red;
                }

                .background {
                    background: yellow;
                }

                .left, .right {
                }
            </style>
        </fieldset>
        <fieldset>
            <legend>&gt;</legend>
            <ul class="childrens">
                <li><a>1</a></li>
                <li>2</li>
                <li>3</li>
            </ul>
            <script type="text/javascript">
                var $childrens = $(".childrens").children("li");//.children();//
                //alert($childrens.length);
                var $_childrens = $(".childrens > li");
                //alert($_childrens.length);
                $(".childrens > li:even").css("background", "yellowgreen");
            </script>
        </fieldset>
        <fieldset>
            <legend>live bind</legend>
            <input type="button" value="bind" class="bind" />
            <input type="button" value="live" class="live" />
            <label id="foo">foo</label>&nbsp;<label id="bar">bar</label>
            <script type="text/ecmascript">
                $(document).ready(function () {
                    $("<input type=\"button\" value=\"bind2\" class=\"bind\" />").insertAfter(".bind");
                    $(".bind").bind("click", function () {
                        alert("Bind");
                    });
                    $(".live").live("click", function () {
                        alert("Live");
                    });
                    $("<input type=\"button\" value=\"bind3\" class=\"bind\" />").insertAfter(".bind:gt(0)");
                    $("<input type=\"button\" value=\"live2\" class=\"live\" />").insertAfter(".live");
                    $("<input type=\"button\" value=\"live3\" class=\"live\" />").insertAfter(".live");

                    var message = "Spoon!";
                    $("#foo").bind("click", { msg: message }, function (event) {
                        alert(event.data.msg);
                    });

                    message = "Not in the face!";
                    $("#bar").bind("click", { msg: message }, function (event) {
                        alert(event.data.msg);
                    });
                });
            </script>
        </fieldset>
        <fieldset>
            <legend>closest</legend>
            <style type="text/css">
                table {
                    width: 100%;
                    height: 24px;
                }

                table, tr, td {
                    border: 1px solid black;
                }
            </style>
            <table>
                <tr>
                    <td>
                        <input type="button" value="XXX" class="x" /></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <input type="button" value="XXX" class="xxx" /></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <input type="button" value="XXX" class="x" /></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
            <script type="text/ecmascript">
                $(".xxx").closest("tr").css("background-color", "green");
            </script>
        </fieldset>
        <fieldset>
            <legend>Dropdown List</legend>
            <div style="padding-top: 640px; padding-bottom: 640px;">
                <label id="msg" style="padding: 64px; font-size: large; color: aquamarine;"></label>
                <div id="_DropdownModal" style="border: 1px solid green; width: 320px;"><!--XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX<br />--></div>
            </div>
            <script type="text/javascript">
                var DroDro = function (input, items) {
                    this.Items = { "Items": [{ "k": "k1", "v": "v1" }] };
                    this.SelectedItems = new Array();
                    this.SelectedValues = new Array();
                    this.Size = 5;
                    this.Items = items;
                    this.MultiChoice = false;
                    this.Width = 320;
                    this.Height = 240;
                    this.Input = jQuery("#" + input);

                    if (input == undefined || target == "") {
                        throw new exception("没有提供选择框");
                    }
                    var container = '<div id="DropdownModal_' + input + '" style="width: ' + this.Width + 'px; height: auto; opacity: 0; border: 1px solid #beb2b2;"></div>';
                    this.Container = jQuery(container);

                    this.Init = function () {
                        var _item = '<label id="Label0" class="kv" k="" v="">abc</label>';
                        var _br = '<br />';

                        var _Container = this.Container;
                        var _SelectedItems = this.SelectedItems;
                        var _SelectedValues = this.SelectedValues;
                        var _Size = this.Size;
                        var _MultiChoice = this.MultiChoice;
                        var _Input = this.Input;

                        if (this.Items.length > 0) {
                            var _flag = 1;
                            jQuery(this.Items).each(function (index) {
                                var _selected = (this.s == true) ? true : false;
                                var _id = input + '_Drop_' + index;
                                var it = '<span id="' + _id + '" class="' + input + '" k="' + this.k + '" v="' + this.v + '" status="' + _selected + '">' + this.v + '</span>';

                                if (_selected == true) {
                                    _SelectedItems.push(_id);
                                    _SelectedValues.push(this.k);
                                    it = '<span id="' + _id + '" class="' + input + '" k="' + this.k + '" v="' + this.v + '" status="' + _selected + '" style="border: 1px solid red;">' + this.v + '</span>';
                                }

                                if (_flag++ == _Size) {
                                    it += "<br />";
                                    _flag = 1;
                                }

                                jQuery(it).appendTo(_Container);

                                jQuery("#" + _id).live("click", function () {
                                    if (jQuery(this).attr("status") == "false") {
                                        if (_MultiChoice == false) {
                                            jQuery("." + input).attr("status", false).css("border", "1px solid #beb2b2");
                                            _SelectedItems.splice(0, _SelectedItems.length);
                                            _SelectedValues.splice(0, _SelectedValues.length);
                                            _Input.html("");
                                        }
                                        jQuery(this).attr("status", true).css("border", "solid 1px red");
                                        _SelectedItems.push(jQuery(this).attr("id"));
                                        _SelectedValues.push(jQuery(this).attr("v"));
                                    }
                                    else {
                                        jQuery(this).attr("status", false).css("border", "solid 1px #beb2b2");
                                        var _index = _SelectedItems.indexOf(jQuery(this).attr("id"));
                                        _SelectedItems.splice(_index, 1);
                                        _SelectedValues.splice(_index, 1);
                                    }
                                    _Input.html(_SelectedValues.join(";"));
                                    jQuery("#msg").html(_SelectedItems.length);
                                });
                            });
                            _Input.parent().append(_Container);
                        }

                        _Input.click(function (e) {
                            _Container.animate({ opacity: 1 }, function () {
                                jQuery("#msg").html("Finished");
                            });
                        });

                        _Container.mou(function (e) {
                            _Container.animate({ opacity: 0 }, function () {
                                jQuery("#msg").html("Finished");
                            });
                        });
                    }
                }
            </script>
            <script type="text/javascript">
                var _items = {
                    "Items":
                        [
                            { "k": "k1", "v": "v1v1v1v1v1v1v1v1v1v1v1v1", "s": false },
                            { "k": "k2", "v": "v2", "s": true },
                            { "k": "k3", "v": "v3", "s": false },
                            { "k": "k4", "v": "v4v4v4v4v4v4v4v4v4v4v4v4v4", "s": false },
                            { "k": "k5", "v": "v5", "s": false },
                            { "k": "k6", "v": "v6", "s": false },
                            { "k": "k7", "v": "v7", "s": false },
                            { "k": "k8", "v": "v8", "s": false },
                            { "k": "k9", "v": "v9", "s": false },
                            { "k": "k10", "v": "10", "s": false },
                            { "k": "k11", "v": "v11", "s": false },
                            { "k": "k12", "v": "v12", "s": false }
                        ]
                };
                var drop = new DroDro("_DropdownModal", _items.Items);
                drop.MultiChoice = true;
                drop.Size = 24;
                drop.Init();

            </script>
            <style type="text/css">
                ._DropdownModal {
                    padding: 5px;
                    margin: 5px;
                    border: 1px solid #beb2b2;
                    cursor: pointer;
                    display: inline-block;
                }

                ._DropdownModal:hover {
                    background-color: #ffef73;
                }

                #msg {
                    color: red;
                    padding: 10px;
                }
            </style>
<%--            <div id="DropdownModal">
                <label id="Label0" class="kv" k="" v="">abc</label>
                <label id="Label1" class="kv" k="" v="">abc</label>
                <label id="Label2" class="kv" k="" v="">abc</label>
                <label id="Label3" class="kv" k="" v="">abc</label>
            </div>
            --%>
        </fieldset>
    </form>
</body>
</html>
