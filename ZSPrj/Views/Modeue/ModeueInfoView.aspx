<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModeueInfoView.aspx.cs" Inherits="ZSPrj.Views.Modeue.ModeueInfoView" %>

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
        
        <div title="获取查询" data-options="iconCls:'icon-ok'" style="overflow:auto;padding:10px;">
            <span style="margin-left:30%">模块名称</span>
    <input name="UserName" id="UserName"   label="模块名称:" style="width:90px"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <span>模块地址</span>
    <input name="ModuleUrl" id="ModuleUrl"   label="模块地址:" style="width:90px"/>
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
            <table id="dg"title="模块数据" class="easyui-datagrid" style="width:100%;height:500px">
                <div style="height:50px"></div>
    <thead data-options="frozen:true"> <%--//冻结想要的列--%>
    <tr>
        <th field="" checkbox="true"></th>
        <th field="Mid" width="50" " >编号</th> <%--//设置列的排序--%>
        <th field="ModuleName" width="120" >名称</th>
        <th field="ModuleUrl" width="200">链接地址</th>
        <th field="ModuleIcon" width="80">图标</th>
        <th field="ModuleMeno" width="80">备注</th>
        <th field="Flag" width="80">是否有效</th>
    </tr>
    </thead>
</table>
             <div id="toolbar1">
    <a href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-add" plain="true" onclick="newUser()">添加</a>
    <a href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-edit" plain="true" onclick="editUser()">修改</a>
    <a href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-remove" plain="true" onclick="destroyUser()">删除</a>
 </div>
  <div id="dlg" class="easyui-dialog" style="width:400px" data-options="closed:true,modal:true,border:'thin',buttons:'#dlg-buttons'">
    <%--添加修改框--%>
    <form id="fm" class="contact-form" method="post" novalidate style="margin:0;padding:20px 50px">
        <table>
            <input class="easyui-textbox" name="Mid" type="hidden" value=""  />
            <tr><td>名称:</td> <td> <input class="easyui-textbox" name="ModuleName" value="" /></td></tr>
            <tr><td>链接地址:</td> <td> <input class="easyui-textbox" name="ModuleUrl" value="" /></td></tr>
            <tr><td>图标:</td> <td> <input class="easyui-textbox" name="ModuleIcon" value="" /></td></tr>
            <tr><td>备注:</td> <td> <input class="easyui-textbox" name="ModuleMeno" value="" /></td></tr>
        </table>
               
    </form>
  </div>
    <%--修改button--%>
    <div id="dlg-buttons">
    <a href="javascript:void(0)" class="easyui-linkbutton c6" iconcls="icon-ok" onclick="saveuser()" style="width:90px">save</a>
    <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-cancel" onclick="javascript:$('#dlg').dialog('close');" style="width:90px">cancel</a>
   </div>
    <input  type="hidden" id="ZancunID" name="name" value="" />
</body>
</html>
<script>
    $(function () {
        SelectPowerInfoToList()
    })
    //分页显示
    function SelectPowerInfoToList() {

        $("#dg").datagrid({
            url: "../../Handler/ModuleInfoHandler.ashx?para=SelectModuleInfoToList",
            pagination: true,     //分页
            toolbar: toolbar1,   //工具栏
        })
    }
    //删除
    function destroyUser() {
        var row = $('#dg').datagrid('getSelections');
        if (confirm("确定删除吗？")) {
            for (var i = 0; i < row.length; i++) {
                $.ajax({
                    url: "../../Handler/ModuleInfoHandler.ashx?para=destroy",
                    data: { id: row[i].Mid },
                    success: function (data) {
                        $.messager.show({
                            title: '提示消息',
                            msg: data,
                            showType: 'show'
                        });
                        $("#dlg").dialog('close');
                        $('#dg').datagrid('reload');
                    }
                })
            }
        }
    }
    //添加弹出框
    function newUser() {
        $('#dlg').dialog('open').dialog('center').dialog('setTitle', '模块组操作');
        $("#ZancunID").val("1")
    }
    //修改弹出框
    function editUser() {
        var row = $('#dg').datagrid('getSelected');
        if (row) {
            $("#dlg").dialog('open')
            $("#ZancunID").val("2")
            $('#dlg').dialog('open').dialog('center').dialog('setTitle', '模块组操作');
            $('#fm').form('load', row);

        } else {
            alert("请先选择要修改的数据")
        }
    }
    //添加-删除
    function saveuser() {
        var f = $("#fm").serializeArray();
        var d = {};
        $.each(f, function () {
            d[this.name] = this.value
        })
        if (($("#ZancunID").val() == "1")) {
            delete d.Mid
        }
        $.ajax({
            url: "../../Handler/ModuleInfoHandler.ashx?para=" + ($("#ZancunID").val() == "1" ? "addUser" : "editUser"),
            data: {
                forms: JSON.stringify(d),
            },
            success: function (res) {
                $.messager.show({
                    title: '提示消息',
                    msg: res,
                    showType: 'show'
                });
                $("#dlg").dialog('close');
                $('#dg').datagrid('reload');
            }
        })

    }
    //条件查询
    function SelectWhere() {
        var name = $("#UserName").val();
        var Flag = $("#Flag").val();
        var ModuleUrl = $("#ModuleUrl").val();
        $("#dg").datagrid({
            url: "../../Handler/ModuleInfoHandler.ashx?para=Selectlist&UserName=" + name + "&Flag=" + Flag + "&ModuleUrl=" + ModuleUrl,
            pagination: true,     //分页
            toolbar: toolbar1,   //工具栏
        })
    }

</script>
<script src="../../Scripts/script.js"></script>