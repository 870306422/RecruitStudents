<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Management.aspx.cs" Inherits="ZSPrj.Views.StuDateManagement.Management" %>

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
        <div id="dig" title="数据查询" data-options="iconCls:'icon-ok'" style="overflow:auto;padding:10px;">
            <span style="margin-left:42%">学院专业名称：</span>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <input name="PowerName" id="PowerName"   label="" style="width:90px"/>
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <a class="easyui-linkbutton" iconCls="icon-search" name="name" onclick="SelectWhere()">查询</a>
        </div> 
    </div> 
    <div style="height:50px"></div>
       <%-- --%>
  <table id="tg" title="学院列表" class="easyui-treegrid" style="width:100%;height:900px;">
		<thead>
			<tr>
				<th data-options="field:'name'" width="30%">名称</th>
				<th data-options="field:'PIName'" width="20%" align="right">负责人</th>
			</tr>
		</thead>
	</table>
   <div id="toolbar1">
        <a href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-add" plain="true" onclick="newUser()">添加</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-edit" plain="true" onclick="GetModuleInfo()">修改</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-remove" plain="true" onclick="destroyUser()">删除</a>
   </div>
     <%--修改权限组框--%>
    <div id="dlg" title="操作权限组" class="easyui-dialog" style="width:400px" data-options="closed:true,modal:true,border:'thin',buttons:'#dlg-buttons'">
        <form id="fm" class="contact-form" method="post" novalidate style="margin:0;padding:20px 50px">
             <input name="AId" type="hidden" id="AId" />
            <br />
              <input class="easyui-combotree"  id="AName" name="AName" label="学院名称:" style="width:100%;"/>
            <br />
              <input class="easyui-textbox" name="ANameT" id="ANameT" label="学院/专业名称:"  style="width:100%;"/>
            <br />
            <input class="easyui-combobox"  id="PIName" name="PIName" label="负责人:" style="width:100%;"/>
            <input type="hidden" name="name" id="asd" value="" />
        </form>
    </div>
    <div id="dlg-buttons">
        <a href="javascript:void(0)" class="easyui-linkbutton c6" iconcls="icon-ok" onclick="saveuser()" style="width:90px">提交</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-cancel" onclick="javascript:$('#dlg').dialog('close'); $('#fm').form('clear');" style="width:90px">取消</a>
   </div>
    <input type="hidden" id="textselect" value="" />
</body>
</html>
<script type="text/javascript">
        $(function () {
            mainselect();
        })
        function mainselect() {
            $('#tg').treegrid({
                url: '../../Handler/Mange/Management.ashx?para=list',
                method: 'get',
                rownumbers: true,
                checked: true,
                animate: true,
                toolbar: toolbar1,   //工具栏
                idField: 'id',
                treeField: 'name'
            });
        }
        //查询
        function SelectWhere() {
            var inquire = $("#PowerName").val();
            $('#tg').treegrid({
                url: '../../Handler/Mange/Management.ashx?para=list&inq=' + inquire,
                method: 'get',
                rownumbers: true,
                animate: true,
                idField: 'id',
                treeField: 'name',
            });
            $('#PowerName').val("");
        }
        //增加弹出层
        function newUser() {
                $("#dlg").dialog('open').dialog('center').dialog('setTitle', '增加学院');
            $('#AName').combotree({
                    prompt: '请选择或输入',
                    url: '../../Handler/Mange/Management.ashx?para=dropdown',
                    method: 'get',
                    valueField: 'AId',
                    textField: 'AName',
                    panelHeight: 'auto',
                    label: '学院名称:',
                })
            $('#PIName').combobox({
                prompt: '请选择或输入',
                url: '../../Handler/Mange/Management.ashx?para=dropdownT',
                method: 'get',
                valueField: 'PIid',
                textField: 'PIName',
                panelHeight: 'auto',
                label: '专业负责人:',
            })
                $("#textselect").val("1");
        }

        //删除
    function destroyUser() {
        var row1 = $('#tg').datagrid('getSelected');
        var id = row1.id;
        if (row1) {
            $.messager.confirm('警告', '确定删除?', function (r) {
                if (r) {
                    $.ajax({
                        url: "../../Handler/Mange/Management.ashx?para=Del",
                        data: {
                            AId: id
                        },
                        success: function (data) {
                            $.messager.show({
                                title: '提示消息',
                                msg: data,
                                showType: 'show'
                            });
                            mainselect();
                        }
                    })
                }
            })
        }
    }

    //修改弹出
    function GetModuleInfo() {
        $("#dlg").dialog('open').dialog('center').dialog('setTitle', '修改学院');
        $('#AName').combotree({
            prompt: '请选择或输入',
            url: '../../Handler/Mange/Management.ashx?para=dropdown',
            method: 'get',
            valueField: 'AId',
            textField: 'AName',
            panelHeight: 'auto',
            label: '学院名称:',
        })
        $('#PIName').combobox({
            prompt: '请选择或输入',
            url: '../../Handler/Mange/Management.ashx?para=dropdownT',
            method: 'get',
            valueField: 'PIid',
            textField: 'PIName',
            panelHeight: 'auto',
            label: '专业负责人:',
        })
        $("#AId").val($("#tg").datagrid('getSelected').id);
        //专业&学院 名称
        //$("#AName").combotree('setValues', $("#tg").datagrid('getSelected').name);
        $("#ANameT").textbox('setValue', $("#tg").datagrid('getSelected').name);
        //专业&学院 负责人
        $('#PIName').combobox('setValue', $("#tg").datagrid('getSelected').PIName);

        $("#AName").combotree({
            //Aid newValue
            onChange: function (newValue, oldValue) {
                $.ajax({
                    url: "../../Handler/Mange/Management.ashx?para=selectpwd",
                    data: {
                        aid: newValue
                    },
                    dataType: "json",
                    success: function (res) {
                        $("#asd").val(newValue);
                    }
                   
                })
            }
        });
        $("#textselect").val("2");
    }


        //增加或修改
    function saveuser() {
            $.ajax({
                url: "../../Handler/Mange/Management.ashx?para=" + ($("#textselect").val() == "1" ? "addHead" : "editHead"),
                data: {
                    AName: $("#AName").combobox('getText'),
                    ANameT: $("#ANameT").val(),
                    Head: $("#PIName").val(),

                    asd: $("#asd").val(),
                    aid: $("#AId").val(),
                    anamea: $("#ANameT").textbox('getValue'),
                    hid: $('#PIName').combobox('getValue')
                },
                success: function (res) {
                    $.messager.show({
                        title: '提示消息',
                        msg: res,
                        showType: 'show'
                    });
                    $("#dlg").dialog('close');
                    mainselect();
                }
            })
        }
</script>
<script src="../../Scripts/script.js"></script>