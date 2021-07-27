<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PowerInfoView.aspx.cs" Inherits="ZSPrj.Views.PowerInfo.PowerInfoView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="../../Content/easyui/themes/bootstrap/easyui.css" />
    <link rel="stylesheet" href="../../Content/easyui/themes/icon.css" />
    <script src="../../Scripts/jquery-3.4.1.min.js"></script>
    <script src="../../Content/easyui/jquery.easyui.min.js"></script>
     <script src="../../Content/easyui/locale/easyui-lang-zh_CN.js"></script>
</head>
<body>
    <div class="easyui-accordion" style="width:100%;">
    <%--数据查询--%>
        <div title="获取查询" data-options="iconCls:'icon-ok'" style="overflow:auto;padding:10px;">
            <span style="margin-left:30%">权限组名称</span>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <input name="PowerName" id="PowerName"   label="模块名称:" style="width:90px"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <span>是否有效</span>
             <select  name="Flag" id="Flag" label="是否有效:" labelPosition="top" style="width:100px;">
                     <option value="1">请选择</option>
                     <option value="1">有效</option>
                     <option value="0">无效</option>
                   </select>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <a class="easyui-linkbutton" iconCls="icon-search" name="name" onclick="SelectWhere()">查询</a>
        </div> 
    </div> 
        <%--权限组列表--%>
    <table id="dg" title="权限组列表" class="easyui-datagrid" style="width:100%;height:500px">
        <div style="height:50px"></div>
    <thead data-options="frozen:true"> 
    <tr>
        <th field="PowerID" width="90" " >编号</th>
        <th field="PowerName" width="200" >权限组名称</th>
        <th field="ModuleMeno" width="200">备注</th>
        <th field="Flag" width="80">状态</th>
    </tr>
    </thead>
    </table>
   <%--修改权限组框--%>
    <div id="dlg_QX" title="操作权限组" class="easyui-dialog" style="width:1000px" data-options="closed:true,modal:true,border:'thin',buttons:'#dlg-buttons'">
    <form id="fm" class="contact-form" method="post" novalidate style="margin:0;padding:20px 50px">
         <input name="PowerID" type="hidden" id="PowerID"   label=":" style="width:90px"/>
         权限组名称 <input name="PowerName" id="PowerName2"   label=":" style="width:90px"/>
         权限组备注 <input name="ModuleMeno" id="ModuleMeno"   label=":" style="width:90px"/>
        <table id="dgM" title="模块组" class="easyui-datagrid" style="width:800px;height:300px">
    <thead > 
    <tr>
        <th field="" checkbox="true"></th>
        <th field="ModuleName" width="100" " >模块名称</th> 
        <th field="ModuleUrl" width="200" >模块地址</th>
        <th field="ModuleMeno" width="200">模块备注</th>
    </tr>
    </thead>
    </table>
               
    </form>
    </div>
    
     <div id="toolbar1">
        <a href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-add" plain="true" onclick="newUser()">添加</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-edit" plain="true" onclick="GetModuleInfo()">修改</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-remove" plain="true" onclick="destroyUser()">删除</a>
     </div>
   
    <%--修改button--%>
    <div id="dlg-buttons">
        <a href="javascript:void(0)" class="easyui-linkbutton c6" iconcls="icon-ok" onclick="saveuser()" style="width:90px">提交</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-cancel" onclick="javascript:$('#dlg').dialog('close'); $('#fm').form('clear');" style="width:90px">重置</a>
   </div>
    <input type="hidden" id="ZancunID" name="name" value="" />
</body>
</html>
<script >
    $(function () {
        SelectPowerInfoToList()
    })
    //分页显示
    function SelectPowerInfoToList() {
        $("#dg").datagrid({
            url: "../../Handler/PowerInfoHandler.ashx?para=SelectPowerInfoToList",
            pagination: true,     //分页
            toolbar: toolbar1,   //工具栏
            singleSelect: true   //单行选中
        })
    }
    
    //删除
    function destroyUser() {
        var row1 = $('#dg').datagrid('getSelected');
        if (row1) {
            $.messager.confirm('警告', '确定删除?', function (r) {
                if (r) {
                    $.ajax({
                        url: "../../Handler/PowerInfoHandler.ashx?para=destroy",
                        data: { id: row1.PowerID },
                        success: function (data) {
                            $.messager.show({
                                title: '提示消息',
                                msg: data,
                                showType: 'show'
                            });
                            $("#dlg_QX").dialog('close');
                            $('#dg').datagrid('reload');
                        }
                    })
                }
            })
        } else {
            $.messager.confirm('警告', '请选中一行内容后重试')
        }
    }
        
    //权限组显示
    function newUser() {
        $("#dlg_QX").dialog('open')
        $("#ZancunID").val("1")
        $("#dgM").datagrid({
            url: "../../Handler/ModuleInfoHandler.ashx?para=SelectModuleInfoToList",
        })
    }
    //提交
    function saveuser() {
        var f = $("#fm").serializeArray();
        var PowerName = $("#PowerName2").val();

        var PowerId = $("#PowerID").val();
        var d = {};
        $.each(f, function () {
            d[this.name] = this.value
        })
        if (($("#ZancunID").val() == "1") ){
            delete d.PowerID
        }
        var row = $('#dgM').datagrid('getSelections');
        $.ajax({
            url: "../../Handler/PowerInfoHandler.ashx?para=" + ($("#ZancunID").val() == "1" ? "addUser" : "editUser"),
            data: {
                forms: JSON.stringify(d),
            },
            success: function (res) {
                if (($("#ZancunID").val() == "1" )) {
                    for (var i = 0; i < row.length; i++) {
                        $.ajax({
                            url: "../../Handler/PowerInfoHandler.ashx?para=addPowerInfo",
                            data: {
                                ModuleId: row[i].Mid,
                                PowerId: PowerId,
                                PowerName: PowerName
                            },
                            success: function (data) {
                                $.messager.show({
                                    title: '提示消息',
                                    msg: data,
                                    showType: 'show'
                                });
                                $("#dlg_QX").dialog('close');
                                $('#dg').datagrid('reload');
                            }
                        })
                    }
                } else if (($("#ZancunID").val() == "2")) {
                    $.ajax({
                        url: "../../Handler/PowerInfoHandler.ashx?para=delPowerInfo",
                        data: {
                            PowerName: PowerName
                        },
                        success: function (data) {
                            for (var i = 0; i < row.length; i++) {
                                $.ajax({
                                    url: "../../Handler/PowerInfoHandler.ashx?para=addPowerInfo",
                                    data: {
                                        ModuleId: row[i].Mid,
                                        PowerId: PowerId,
                                        PowerName: PowerName
                                    },
                                    success: function (data) {
                                        $.messager.show({
                                            title: '提示消息',
                                            msg: data,
                                            showType: 'show'
                                        });
                                        $("#dlg_QX").dialog('close');
                                        $('#dg').datagrid('reload');
                                    }
                                })
                            }
                        }
                    })
                }
                
            }
        })
        
       
    }
    //条件查询
    function SelectWhere() {
        var name = $("#PowerName").val();
        var Flag = $("#Flag").val();
        var ModuleUrl = $("#ModuleUrl").val();
        $("#dg").datagrid({
            url: "../../Handler/PowerInfoHandler.ashx?para=Selectlist&PowerName=" + name + "&Flag=" + Flag,
            pagination: true,     //分页
            toolbar: toolbar1,   //工具栏
            //singleSelect: true   //单行选中
        })
    }
    //获取权限组
    function GetModuleInfo() {
        if ($("#dg").datagrid("getChecked")) {

            $("#ZancunID").val("2")
            var row = $("#dg").datagrid("getSelected");
            $("#dlg_QX").dialog('open')
            $('#fm').form('load', row);
            $("#dgM").datagrid({
                url: "../../Handler/ModuleInfoHandler.ashx?para=SelectModuleInfoToList",
                //toolbar: toolbar1,   //工具栏
            })
            $.ajax({
                url: "../../Handler/PowerInfoHandler.ashx?para=GetModuleInfo",
                data: {
                    id: row.PowerID
                },
                dataType: "json",
                success: function (res) {
                    for (var i = 0; i < res.mInfo.length; i++) {
                        for (var j = 0; j < res.pmInfo.length; j++) {
                            if (res.mInfo[i].Mid == res.pmInfo[j].ModuleId) {

                                $("#dgM").datagrid('checkRow', i)
                            }
                        }
                    }
                }
            })

        }

    }

</script>
<script src="../../Scripts/script.js"></script>