<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebUISite.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%--jQuery模拟下拉框--%></title>
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
            padding: 64px;
            font-size: large;
            color: red;
        }
    </style>
    <script src="Scripts/jquery-1.8.0.js"></script>
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

            if (input == undefined || input == "") {
                throw new exception("没有提供选择框");
            }
            var container = '<div id="DropdownModal_' + input + '" style="width: ' + this.Width + 'px; height: auto; opacity: 0; border: 1px solid #beb2b2; display: none;"></div>';
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
                var _Width = this.Width;
                var _Height = this.Height;

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
                        _Input.html(_SelectedValues.join(";"));
                    });
                    _Input.parent().append(_Container);
                }

                _Input.click(function (e) {
                    if (!_Container.is(":animated")) {
                        _Container.animate({ opacity: 1 }).show();
                    }
                });

                _Container.mouseleave(function (e) {
                    if (!_Container.is(":animated")) {
                        _Container.animate({ opacity: 0 }).hide();
                    }
                });
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding: 100px;">
            <label id="msg"></label>
            <div id="_DropdownModal" style="border: 1px solid green; width: 320px; height: 24px;"></div>
        </div>
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
                        { "k": "k10", "v": "v10", "s": false },
                        { "k": "k11", "v": "v11", "s": false },
                        { "k": "k12", "v": "v12", "s": false }
                    ]
            };
            var drop = new DroDro("_DropdownModal", _items.Items);
            drop.MultiChoice = true;
            drop.Size = 24;
            drop.Init();
        </script>
    </form>
</body>
</html>
