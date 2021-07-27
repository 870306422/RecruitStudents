<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="ZSPrj.Views.PeopleInfor.UserInfo" %>

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
    <%--人员查询--%>
        <div id="dig" title="数据查询" data-options="iconCls:'icon-ok'" style="overflow:auto;padding:10px;">
            <span style="margin-left:35%">账号查询：</span>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <input name="PowerName" id="PowerName"   label="" style="width:90px"/>
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <input class="easyui-combobox"  id="PINamet" name="PIName" label="姓名查询：" style="width:200px;"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <select id="sel">
                <option value="">请选择</option>
                <option value="1">男</option>
                <option value="2">女</option>
            </select>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <a class="easyui-linkbutton" iconCls="icon-search" name="name" onclick="SelectWhere()">查询</a>
        </div> 
    </div> 
    <div style="height:50px"></div>
       <%-- 人员信息表--%>
  <table id="tg" title="人员信息表" class="easyui-datagrid" style="width:100%;height:900px;">
		<thead>
			<tr>
				<th data-options="field:'PIUser'" width="30%">登录账号</th>
				<th data-options="field:'PIName'" width="20%" align="right">人员姓名</th>
			    <th data-options="field:'PISex'" width="20%" align="right">性别</th>
            </tr>
		</thead>
	</table>
   <div id="toolbar1">
        <a href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-add" plain="true" onclick="newUser()">添加</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-edit" plain="true" onclick="GetModuleInfo()">修改</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-remove" plain="true" onclick="destroyUser()">删除</a>
   </div>
     <%--操作人员信息--%>
    <div id="dlgg" title="操作权限组" class="easyui-dialog" style="width:600px" data-options="closed:true,modal:true,border:'thin',buttons:'#dlg-buttons'">
        <form id="fm" class="contact-form" method="post" novalidate style="margin:0;padding:20px 50px">
             <input name="AId" type="hidden" id="AId" />
            <span style="height:20px"></span>
              <input class="easyui-textbox"  id="AName" name="AName" label="登录账号:" style="width:45%;"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <input class="easyui-textbox" name="PIName" id="PIName" label="人员姓名:"  style="width:45%;"/>
            <p></p>
            <input class="easyui-textbox"  id="PIpwd" name="PIpwd" label="登录密码:" style="width:45%;"/>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <select class="easyui-combobox" id="PISex" name="PISex" label="人员性别:" style="width:200px;" data-options="selected:true">
                    <option value="">请选择</option>
                    <option value="1">男</option>
                    <option value="0">女</option>
            </select>
            <p></p>
             <input class="easyui-combobox"  id="PIAccount" name="PIAccount" label="选中权限:" style="width:100%;"/>
            <input type="hidden" name="name" id="asd" value="" />
        </form>
    </div>
    <div id="dlg-buttons">
        <a href="javascript:void(0)" class="easyui-linkbutton c6" iconcls="icon-ok" onclick="saveuser()" style="width:90px">提交</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-cancel" onclick="javascript:$('#dlgg').dialog('close')" style="width:90px">Cancel</a>
   </div>
    <input type="hidden" id="textselect" value="" />
</body>
</html>
<script>
    $(function () {
        mainselect();
    })
    function mainselect() {
        $('#tg').datagrid({
            url: '../../Handler/PersonnelInformation/PersonnelInform.ashx?para=list',
            pagination: true,     //分页
            toolbar: toolbar1,   //工具栏
            singleSelect: true   //单行选中
        });
        //下拉框
        $('#PINamet').combobox({
            prompt: '请选择或输入',
            url: '../../Handler/Mange/Management.ashx?para=dropdownT',
            method: 'get',
            valueField: 'PIid',
            textField: 'PIName',
            panelHeight: 'auto',
            label: '专业负责人:',
        })
    }
    
    //查询
    function SelectWhere() {
        var inquire = $("#PowerName").val();
        var name = $('#PINamet').combobox('getText');
        var nv = $("#sel").val();
        $('#tg').datagrid({
            url: "../../Handler/PersonnelInformation/PersonnelInform.ashx?para=listT&inquire=" + inquire + "&name=" + name + "&nv=" + nv,
            pagination: true,     //分页
        });
        $("#PowerName").val("");
        $('#PINamet').combobox('setText', "");
        $("#sel").val("");
    }

    //新增
    function newUser() {
        $("#dlgg").dialog('open').dialog('center').dialog('setTitle', '增加操作人员信息');
        $('#PIAccount').combobox({
            prompt: '请选择或输入',
            url: '../../Handler/PersonnelInformation/PersonnelInform.ashx?para=Head',
            method: 'get',
            valueField: 'PowerID',
            textField: 'PowerName',
            panelHeight: 'auto',
            label: '选择权限:',
        })
        $("#textselect").val("1")
    }
    //修改弹窗
    function GetModuleInfo() {
        var row = $("#tg").datagrid("getChecked");
        var roww = $("#tg").datagrid("getSelected");
        if (roww) {
            $("#textselect").val("2")
            $("#AId").val(row[0]["PIid"]);
            $("#dlgg").dialog('open').dialog('center').dialog('setTitle', '修改操作人员信息');
            $("#AName").textbox('setText', row[0]["PIUser"]);
            $("#PIName").textbox('setText', row[0]["PIName"]);
            $("#PIpwd").textbox('setText', row[0]["PIpwd"]);
            $("#PISex").combobox('setValue', row[0]["PISex"]);
            $('#PIAccount').combobox({
                prompt: '请选择或输入',
                url: '../../Handler/PersonnelInformation/PersonnelInform.ashx?para=Head',
                method: 'get',
                valueField: 'PowerID',
                textField: 'PowerName',
                panelHeight: 'auto',
                value: 'PowerID',
                label: '选择权限:',
            })
            $("#PIAccount").combobox('setValue', row[0]["PIAccount"]);
        } else {
            $.messager.show({
                title: '提示消息',
                msg: '请选中一行',
                showType: 'show'
            });
        }
    }

    //保存 修改
    function saveuser() {
        var AName = $("#AName").textbox('getText');
        var PIName = $("#PIName").textbox('getText');
        var PIpwd = $("#PIpwd").textbox('getText');
        var PISex = $("#PISex").combobox('getValue');
        var PIAccount = $("#PIAccount").combobox('getValue');
        $.ajax({
            url: "../../Handler/PersonnelInformation/PersonnelInform.ashx?para=" + ($('#textselect').val() == "1" ? 'insert' : 'update'),
            data: {
                AId: $("#AId").val(),
                AName: AName,
                PIName: PIName,
                PIpwd: PIpwd,
                PISex: PISex,
                PIAccount: PIAccount
            },
            success: function (res) {
                $.messager.show({
                    title: '提示消息',
                    msg: res,
                    showType: 'show'
                });
                $("#dlgg").dialog('close');
                $('#tg').datagrid('reload');
            }
        })
    }

    //删除
    function destroyUser() {
        var row1 = $('#tg').datagrid('getSelected');
        if (row1) {
            $.messager.confirm('警告', '确定删除?', function (r) {
                if (r) {
                    $.ajax({
                        url: "../../Handler/PersonnelInformation/PersonnelInform.ashx?para=delete",
                        data: { id: row1.PIid },
                        success: function (data) {
                            $.messager.show({
                                title: '提示消息',
                                msg: data,
                                showType: 'show'
                            });
                            $("#dlgg").dialog('close');
                            $('#tg').datagrid('reload');
                        }
                    })
                }
            })
        } else {
            $.messager.confirm('警告', '请选中一行内容后重试')
        }
    }
</script>
<script src="../../Scripts/script.js"></script>