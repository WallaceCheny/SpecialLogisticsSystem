var viewSetting = {
    viewSplitter_PaneResized: function (s, e) {
        if (e.pane.name === "GridPane") {
            var gridMain = window[gridConfig.gridMainID];
            if (gridMain != undefined) {
                gridMain.SetHeight(e.pane.GetClientHeight() - 60);
                return;
            }
            var grid = window[gridConfig.gridID];
            var tree = window[gridConfig.treeID];
            if (grid == undefined && tree == undefined) return;
            var viewMenu = window[gridConfig.viewMenuID];
            if (gridConfig.ChangeSize != "true") return;
            if (grid != undefined) {
                grid.SetWidth(e.pane.GetClientWidth());
                if ($('#' + gridConfig.searchID).length > 0) {
                    grid.SetHeight(e.pane.GetClientHeight() - viewMenu.GetMainElement().offsetHeight - 34);
                }
                else {
                    grid.SetHeight(e.pane.GetClientHeight() - viewMenu.GetMainElement().offsetHeight);
                }
            }
            else if (tree != undefined) {
                tree.SetWidth(e.pane.GetClientWidth());
                tree.SetHeight(e.pane.GetClientHeight() - viewMenu.GetMainElement().offsetHeight - $('#' + gridConfig.searchID).height());
            }
        }
    },
    lookup_New: function (s, e) {
        //e.processOnServer = confirm('Are you sure you want to delete this item?');
        $.ajax({
            type: "POST",
            url: "/UIHelpers/AjaxHelper.ashx",
            dataType: 'text',
            data: { method: 'getmenu', action: s.cpNewUrl },
            success: function (json) {
                if (json) {
                    var parament = json.split("?"); //分切变量 url 分隔符号为 "?"
                    if (parament.length > 0) {
                        var detailparament = parament[1].split("&");
                        var menuname = "";
                        var menuid = "";
                        for (var i = 0; i < detailparament.length; i++) {
                            var result = detailparament[i].split("=");
                            if (result[0] == "menu_id") {
                                menuid = detailparament[i];
                            }
                            else if (result[0] == "menu_name") {
                                menuname = result[1];
                            }
                        }
                        addTab(menuid, unescape(menuname), s.cpNewUrl, 'frame', '');
                    }
                }
            }
        });
    },
    lookup_Cancel: function (s, e) {
        var gridLookUp = window[s.cpClientInstanceName];
        if (gridLookUp != undefined) {
            gridLookUp.GetGridView().UnselectRows();
            gridLookUp.HideDropDown();
        }
    },
    lookup_Refresh: function (s, e) {
        var gridLookUp = window[s.cpClientInstanceName];
        if (gridLookUp != undefined) {
            gridLookUp.GetGridView().Refresh();
        }
    },
    lookup_Confirm: function (s, e) {
        var gridLookUp = window[s.cpClientInstanceName];
        if (gridLookUp != undefined) {
            gridLookUp.ConfirmCurrentSelection();
            gridLookUp.HideDropDown();
        }
    },
    checkBox_CheckedChanged: function (s, e) {
        var grid = window[s.cpClientInstanceName];
        if (grid != undefined) {
            grid.SelectAllRowsOnPage(s.GetChecked());
        }
    },
    treeList_EndCallback: function (s, e) {
        if (s.cp_callbackMsg != undefined && s.cp_callbackMsg != "") {
            showMsg({ msg: s.cp_callbackMsg });
            s.cp_callbackMsg = "";
        }
        if (window[gridConfig.viewSplitterID] != undefined) {
            window[gridConfig.viewSplitterID].GetPaneByName("GridPane").RaiseResizedEvent();
        }
    },
    grid_EndCallback: function (s, e) {
        //弹出消息
        if (s.cp_callbackMsg != undefined && s.cp_callbackMsg != "") {
            showMsg({ msg: s.cp_callbackMsg });
            s.cp_callbackMsg = "";
        }
        //弹出对话窗体：如打印
        if (s.cp_showPopup != undefined && s.cp_showPopup != "") {
            if (window[gridConfig.popupID] != undefined) {
                $("#btn_print_construct_pin").attr('url', s.cp_showPopup);
                window[gridConfig.popupID].Show();
            }
            s.cp_showPopup = "";
        }
        if (window[gridConfig.viewSplitterID] != undefined) {
            window[gridConfig.viewSplitterID].GetPaneByName("GridPane").RaiseResizedEvent();
        }
        //关闭弹出窗体
        if (s.cp_PopupMsg != undefined && s.cp_PopupMsg != "") {
            window[gridConfig.popupID].Hide();
            showMsg({ msg: s.cp_PopupMsg });
            s.cp_PopupMsg = "";
        }
        var gridSub = window[gridConfig.gridSubID];
        if (gridSub != undefined) {
            gridSub.SetHeight(parseInt(gridConfig.gridSubHeight));
        }
    },
    gridSub_EndCallback: function (s, e) {
        var gridSub = window[gridConfig.gridSubID];
        if (gridSub != undefined) {
            gridSub.SetHeight(parseInt(gridConfig.gridSubHeight));
        }
        if (s.cp_Finish != undefined && s.cp_Finish != "") {
            window[gridConfig.gridID].UpdateEdit();
        }
    },
    viewMenu_ItemClick: function (s, e) {
        var name = e.item.name;
        var text = e.item.GetText();
        e.processOnServer = (name == "XLSX" || name == "XLS");
        var grid = window[gridConfig.gridID];
        var gridSub = window[gridConfig.gridSubID];
        var tree = window[gridConfig.treeID];
        //if (grid == undefined && tree == undefined && gridSub == undefined) return;
        switch (name) {
            case 'add':
                {
                    grid.AddNewRow();
                }
                break;
            case 'edit':
                {
                    var index = grid.GetFocusedRowIndex();
                    grid.StartEditRow(index);
                } break;
            case 'settle':
                {
                    switch (text) {
                        case '客户结算':
                            if (grid.GetSelectedRowCount() > 0) {
                                var index = grid.GetFocusedRowIndex();
                                grid.GetSelectedFieldValues("settle_name", function (results) {
                                    if (results[0] == "未结算") {
                                        grid.StartEditRow(index);
                                    }
                                    else { showMsg({ msg: '该运单已结算！' }); }
                                });
                            }
                            else showMsg({ msg: '请选择要结算的运单' });
                            break;
                        case '司机结算':
                            if (grid.GetSelectedRowCount() > 0) {
                                var index = grid.GetFocusedRowIndex();
                                grid.GetSelectedFieldValues("pre_settle_name;arrive_settle_name;back_settle_name", function (results) {
                                    if (results[0][0] == "未结" || results[0][1] == "未结"
									|| results[0][2] == "未结") {
                                        grid.StartEditRow(index);
                                    }
                                    else { showMsg({ msg: '该车次无需结算！' }); }
                                });
                            }
                            else showMsg({ msg: '请选择要结算的车次' });
                            break;
                        case '服务商结算':
                            if (grid.GetSelectedRowCount() > 0) {
                                var index = grid.GetFocusedRowIndex();
                                grid.GetSelectedFieldValues("settle_name", function (results) {
                                    if (results[0] == "未结算") {
                                        grid.StartEditRow(index);
                                    }
                                    else { showMsg({ msg: '该中转单无需结算！' }); }
                                });
                            }
                            else showMsg({ msg: '请选择要结算的中转单' });
                            break;
                        case '回扣发放':
                            if (grid.GetSelectedRowCount() > 0) {
                                var index = grid.GetFocusedRowIndex();
                                grid.GetSelectedFieldValues("settle_name", function (results) {
                                    if (results[0] == "未结算") {
                                        grid.StartEditRow(index);
                                    }
                                    else { showMsg({ msg: '该运单无需结算！' }); }
                                });
                            }
                            else showMsg({ msg: '请选择要结算的运单' });
                            break;
                    }
                }
                break;
            case 'save':
                var valid = ASPxClientEdit.ValidateGroup('validGroup');
                if (valid) {
                    if (gridConfig.isSaveSub == "true") {
                        var valid = ASPxClientEdit.ValidateGroup('validSubGroup');
                        if (valid) {
                            gridSub.UpdateEdit();
                            return;
                        }
                    }
                    grid.UpdateEdit();
                }
                break;
            case 'save_call':
                var valid = ASPxClientEdit.ValidateGroup('validGroup');
                if (valid) {
                    window[gridConfig.callBackID].PerformCallback(name);
                }
                break;
            case 'delete':
                if (grid.GetSelectedRowCount() > 0) {
                    var index = grid.GetFocusedRowIndex();
                    showConfirm({ msg: '确定' + text + '选中的记录吗?', callback: function () { grid.DeleteRow(index); } });
                }
                else showMsg({ msg: '请选择要' + text + '的记录' });
                break;
            case 'cancel': grid.CancelEdit(); break;
            case 'add_tree':
                tree.StartEditNewNode(); break;
            case 'edit_tree': tree.StartEdit(tree.GetFocusedNodeKey()); break;
            case 'delete_tree':
                showConfirm({ msg: '确定删除选中记录吗?', callback: function () { tree.DeleteNode(tree.GetFocusedNodeKey()); } });
                break;
            case 'save_tree': tree.UpdateEdit(); break;
            case 'cancel_tree': tree.CancelEdit(); break;
            case 'set_password':
                if (grid.GetSelectedRowCount() > 0)
                    showConfirm({ msg: '确定对选中记录的默认密码重置?', callback: function () { grid.PerformCallback('setPassword'); showMsg({ msg: '重置成功' }); } });
                else showMsg({ msg: '请选择要重置的记录' });
                break;
            case 'add_sub': gridSub.AddNewRow(); break;
            case 'edit_sub': var index = gridSub.GetFocusedRowIndex(); gridSub.StartEditRow(index); break;
            case 'delete_sub':
                if (gridSub.GetSelectedRowCount() > 0) {
                    var index = gridSub.GetFocusedRowIndex();
                    gridSub.DeleteRow(index);
                }
                else showMsg({ msg: '请选择要删除的记录' });
                break;
            case 'save_sub':
                var valid = ASPxClientEdit.ValidateGroup('validSubGroup');
                if (valid)
                    gridSub.UpdateEdit();
                break;
            case 'cancel_sub': gridSub.CancelEdit(); break;
            case 'signed':
            case 'add_popup':
                switch (text) {
                    case '签收':
                        {
                            if (grid.GetSelectedRowCount() > 0) {
                                var index = grid.GetFocusedRowIndex();
                                grid.GetSelectedFieldValues("bill_statue", function (results) {
                                    if (results[0] != "Received") {
                                        window[gridConfig.popupID].Show();
                                    }
                                    else { showMsg({ msg: '该运单已签收！' }); }
                                });
                            }
                            else showMsg({ msg: '请选择要签收的运单' });
                        }
                        break;
                    default:
                        window[gridConfig.popupID].Show();
                        break;
                }

                break;
            case 'save_popup':
                var valid = ASPxClientEdit.ValidateGroup('validSubGroup');
                if (valid)
                    grid.PerformCallback(name);
                break;
            case 'cancel_popup':
                window[gridConfig.popupID].Hide();
                break;
            case 'add_select':
                window[gridConfig.popupSelectedID].Show();
                break;
            case 'cancel_select_popup':
                window[gridConfig.popupSelectedID].Hide();
                break;
            case 'selectd_popup':
                var gridTemp = window[gridConfig.popupSelectedGridID];
                var selectRowCount = gridTemp.GetSelectedRowCount();
                if (selectRowCount > 0) {
                    gridTemp.GetSelectedFieldValues("id", function (results) {
                        SpecialLogisticsSystem.Util.InsertToDetail(results, gridConfig.popupSelectedID);
                    });
                    //gridTemp.UnselectRows();
                } else showMsg({ msg: '请选择需要托运的产品' });
                break;
            case 'print':
                if (window[gridConfig.popupID] != undefined) {
                    if (grid.GetSelectedRowCount() > 0) {
                        var index = grid.GetFocusedRowIndex();
                        grid.GetRowValues(index, 'id;', function OnGetRowValues(values) {
                            var url = '';
                            if (text == "打印运单") {
                                url = '/Print/PrintWay.aspx?id=' + values[0];
                                $("#btn_print_construct_pin").attr('url', url);
                                window[gridConfig.popupID].Show();
                            }
                            else {
                                url = '/Reports/ReportStowage.aspx?id=' + values[0];
                                //$("#btn_print_construct_pin").attr('url', url);
                                addTab("", text, url, 'frame', 'print');
                            }
                            //addTab("", text, url, 'frame', 'print');
                            //window.open(url, 'newwindow', 'height=100,width=400,top=0,left=0,toolbar=no,menubar=no,scrollbars=no,resizable=no,location=no, status=no')
                          
                        });
                    }
                    else showMsg({ msg: '请选择需要打印对象' });
                }
                break;
            case 'confirm':
            case 'instorage':
            case 'outstorage':
                showConfirm({ msg: '确定执行【' + text + '】吗?', callback: function () { grid.PerformCallback(name); } });
                break;
            case 'refresh': SpecialLogisticsSystem.Util.ReLocation(); break;
            case 'word_help': SpecialLogisticsSystem.Util.Help(); break;
            case 'video_help': SpecialLogisticsSystem.Util.VideoHelp(); break;
            case 'message': pop_Sms.Show(); break;
            case 'cancel_sms': pop_Sms.Hide(); break;
        }
    },
    Search: function (filterCondition) {
        var grid = window[gridConfig.gridID];
        if (grid != undefined) {
            grid.ApplyFilter(JSON.stringify(filterCondition));
        }
        else {
            var chart = window[gridConfig.chartID];
            chart.PerformCallback(JSON.stringify(filterCondition));
        }
    },
    SearchInner: function (filterCondition) {
        var grid = window[gridConfig.popupGridID];
        grid.ApplyFilter(JSON.stringify(filterCondition));
    }
};
