<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataManagement.aspx.cs" Inherits="ZSPrj.Views.DataManag.DataManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="../../Content/easyui/themes/bootstrap/easyui.css" />
    <link rel="stylesheet" href="../../Content/easyui/themes/icon.css" />
    <script src="../../Scripts/jquery-3.4.1.min.js"></script>
    <script src="../../Content/easyui/jquery.easyui.min.js"></script>
    <script src="../../Content/easyui/locale/easyui-lang-zh_CN.js"></script>
    <link href="../../Content/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
</head>
<body class="easyui-layout">

    <div class="easyui-accordion" data-options="region:'north'" style="width: 100%;height:250px">
        <%--数据查询--%>
        <div id="dig" title="数据查询" data-options="iconCls:'icon-ok'" style="overflow: auto; padding: 10px;">
            <%--第一行--%>
            <span style="margin-left: 7%"></span>
            <input class="easyui-textbox" label="学生编号:" id="stuid" style="width: 20%;" data-options="prompt:'请输入学生编号'" />
            &nbsp;&nbsp;&nbsp;
            <input class="easyui-combobox" name="SourceIId" label="第一来源:" id="stulya" style="width: 20%;" data-options="
                    url: '../../Handler/DataManag/DataManagement.ashx?para=ly',
                    method: 'get',
                    valueField: 'SoureId',
                    textField: 'SourceName',
                    label: '第一来源:',
                    prompt:'请选择第一来源'
                    "/>
            &nbsp;&nbsp;&nbsp;
            <%--老师--%>
            <input class="easyui-textbox" label="学生姓名:" id="stunameaa" style="width: 20%;" data-options="prompt:'请输入学生姓名'" />
            &nbsp;&nbsp;&nbsp;
                  <input class="easyui-combobox" name="TeacherId" id="TeacherIdaa" style="width:20%;" data-options="
                    url: '../../Handler/DataManag/DataManagement.ashx?para=ls',
                    method: 'get',
                    valueField: 'PIid',
                    textField: 'PIName',
                    label: '请选择信息上传者:',
                   prompt:'请选择信息上传者'
                    "/>
            <%--第二行--%>
            <p></p>
            <span style="margin-left: 7%"></span>
             <input class="easyui-textbox" label="高中:" style="width: 20%;" data-options="prompt:'请输入所在高中'" />
           
            &nbsp;&nbsp;&nbsp;
            <input class="easyui-textbox" label="班级:" style="width: 20%;" data-options="prompt:'请输入所在班级'" />
            &nbsp;&nbsp;&nbsp;
             <input class="easyui-combobox" name="sub" style="width:20%;" data-options="
                    url: '../../Handler/DataManag/DataManagement.ashx?para=km',
                    method: 'get',
                    valueField: 'Did',
                    textField: 'Degree',
                    label: '学&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;历:',
                   prompt:'请选择学历'
                    "/>
            &nbsp;&nbsp;&nbsp;
           <input class="easyui-textbox" label="QQ号:" style="width: 20%;" data-options="prompt:'请输入QQ号'" />
            
            <%--第三行--%>
            <p></p>
            <span style="margin-left: 7%"></span>
            <input class="easyui-textbox" label="QQ号:" style="width: 20%;" data-options="prompt:'请输入手机号'" />
            <%--<select class="easyui-combobox" name="state" label="分数段:" style="width: 20%;">
                <option value="">请选择分数段</option>
                <option value="AK">Alaska</option>
            </select>--%>
            &nbsp;&nbsp;&nbsp;
            <input class="easyui-combobox" name="Academyid" style="width:20%;" data-options="
                    url: '../../Handler/DataManag/DataManagement.ashx?para=zy',
                    method: 'get',
                    valueField: 'AId',
                    textField: 'AName',
                    label: '请选择专业:',
                    prompt:'请选择专业'
                    "/>
           
            &nbsp;&nbsp;&nbsp;
            <select class="easyui-combobox" name="state" label="激活状态:" style="width: 20%;">
                <option value="">请选择激活状态</option>
                <option value="1">已激活</option>
                <option value="1">未激活</option>
            </select>
            &nbsp;&nbsp;&nbsp;
            <%-- <select class="easyui-combobox" name="state" label="QQ添加状态:" style="width: 20%;">
                <option value="">请选择QQ添加状态</option>
                <option value="AK">Alaska</option>
            </select>--%>
            <a class="easyui-linkbutton" iconCls="icon-search" style="width: 20%" name="name" onclick="SelectWhere()">查询</a>
            <%--第四行--%>
           <%-- <p></p>
            <span style="margin-left: 7%"></span>
            <input class="easyui-textbox" label="实际分数:" style="width: 20%;" data-options="prompt:'最低分数'" />
             &nbsp;&nbsp;&nbsp;
            <input class="easyui-textbox" label="至:" style="width: 20%;" data-options="prompt:'最高分数'" />--%>
            <%--<select class="easyui-combobox" name="state" label="已填志愿:" style="width: 20%;">
                <option value="">请选择已填志愿</option>
                <option value="AK">Alaska</option>
            </select>
            &nbsp;&nbsp;&nbsp;
            <select class="easyui-combobox" name="state" label="有截图:" style="width: 20%;">
                <option value="">请选择是否有截图</option>
                <option value="AK">Alaska</option>
            </select>--%>
            <%--&nbsp;&nbsp;&nbsp;--%>
            <%-- <select class="easyui-combobox" name="state" label="咨询分量:" style="width: 20%;">
                <option value="">请选择咨询分量</option>
                <option value="AK">A分量</option>
                 <option value="AK">B分量</option>
            </select>--%>
           <%-- <select class="easyui-combobox" name="state" label="已过线:" style="width: 20%;">
                <option value="">请选择是否过线</option>
                <option value="AK">Alaska</option>
            </select>--%>
            <%--&nbsp;&nbsp;&nbsp;--%>
           <%-- <select class="easyui-combobox" name="state" label="已录取:" style="width: 20%;">
                <option value="">请选择是否录取</option>
                <option value="AK">Alaska</option>
            </select>--%>
            <%--第五行--%>
           <%-- <p></p>
            <span style="margin-left: 7%"></span>
            <select class="easyui-combobox" name="state" label="已报道:" style="width: 20%;">
                <option value="">请选择是否报道</option>
                <option value="AK">Alaska</option>
            </select>
            &nbsp;&nbsp;&nbsp;
             <input class="easyui-textbox" label="高中:" style="width: 20%;" data-options="prompt:'请选择所在高中'" />
             &nbsp;&nbsp;&nbsp;
             <input class="easyui-textbox" label="班级:" style="width: 20%;" data-options="prompt:'请选择所在班级'" />
              &nbsp;&nbsp;&nbsp;
            <select class="easyui-combobox" name="state" label="线上推广来源:" style="width: 20%;">
                <option value="">请选择线上推广来源</option>
                <option value="AK">Alaska</option>
            </select>--%>
            <%--第六行--%>
            <%--<p></p>
            <span style="margin-left: 7%"></span>
            
            &nbsp;&nbsp;&nbsp;
            <select class="easyui-combobox" name="state" label="省份:" style="width: 20%;">
                <option value="">请选择省份</option>
                <option value="AK">Alaska</option>
            </select> 
            &nbsp;&nbsp;&nbsp;
            <select class="easyui-combobox" name="state" label="市区:" style="width: 20%;">
                <option value="">请选择所在市区</option>
                <option value="AK">Alaska</option>
            </select>
            
            --%>
            <%--第七行--%>
           <%-- <p></p>
            <span style="margin-left: 7%"></span>
            <input class="easyui-textbox" label="微信号:" style="width: 20%;" data-options="prompt:'请输入学生微信号'" />
            &nbsp;&nbsp;&nbsp;
            <select class="easyui-combobox" name="state" label="预报名:" style="width: 20%;">
                <option value="">请选择是否预报名</option>
                <option value="AK">Alaska</option>
            </select>
            &nbsp;&nbsp;&nbsp;
            <select  class="easyui-combobox" name="state" label="已上门:" style="width: 20%;">
                <option value="">请选择是否已上门</option>
                <option value="AK">Alaska</option>
            </select>
            &nbsp;&nbsp;&nbsp;
            <select class="easyui-combobox" name="state" label="分配状态:" style="width: 20%;">
                <option value="">请选择分配状态</option>
                <option value="AK">Alaska</option>
            </select>--%>
        </div>
    </div>
    <p></p>
    <p></p>
    <p></p>

    <div class="easyui-accordion" data-options="region:'center'" style="width: 100%;">
    <table id="dg" class="easyui-datagrid"  style="width: 100%;" >
        <%-- 要冻结的列 --%>
        <thead data-options="frozen:true">
            <tr>
                <th data-options="field:'StudentID',width:120">ID</th>
                <th data-options="field:'SourceName',width:120">第一来源</th>
                <th data-options="field:'STUName',width:120">学生姓名</th>
            </tr>
        </thead>
        <%-- 正常移动的列 --%>
        <thead>
            <tr>
                <th field="RName" width="120" data-options="formatter:TCCT">咨询记录</th>
                <th field="SchoolName" width="120">高中</th>
                <th field="ClassName" width="120">班级</th>
                <th field="Degree" width="120">学历</th>
                <th field="EditOutTime" width="120">最后一次修改</th>
                <th field="QQId" width="120">QQ号</th>
                <th field="PhoneID" width="120">手机</th>
                <th field="AName" width="120">专业</th>
                <th field="Flag" width="120">激活状态</th>
                <th field="QQFlag" width="120">QQ添加状态</th>
                <th field="ScoreSegment" width="120">分数段</th>
                <th field="ActualScore" width="120">实际分数</th>
                <th field="NoteInfo" width="120">备注信息</th>
                <th field="ConsultingComponents" width="120">咨询分量</th>
                <th field="IsSchool" width="120">是否处理</th>
                <th field="PIName" width="120">咨询人</th>
            </tr>
        </thead>
    </table>
 </div>
    <div id="toolbar1">
        <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-add" plain="true" onclick="newUser()">添加</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-remove" plain="true" onclick="DeleteUser()">删除</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-man" plain="true" onclick="editUser()">分配</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-tip" plain="true" onclick="destroyUser()">查看校区记录</a>
         <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-redo" plain="true" onclick="Transfer()">转介绍到其他校区</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-redo" plain="true" onclick="Transfer()">批量转介绍到其他校区</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-print" plain="true" onclick="Exportcurrent()">导出当前</a>
         <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-print" plain="true" onclick="ExportAll()">导出所有</a>
    </div>
    <input type="hidden" name="SelectPa" id="SelectPa" value="" />

     <%--学院添加--%>
    <div id="dlg_QX" title="学院添加" class="easyui-dialog" style="width:50%" data-options="closed:true,modal:true,border:'thin',buttons:'#dlg-bu'">
        <form id="fm" class="contact-form" method="post" style="margin:0;padding:20px 50px">
             <input name="StudentID" type="hidden" id="StudentID"   label=":" style="width:90px"/>

             <input class="easyui-textbox" label="学生姓名:" name="STUName" style="width: 44%;" data-options="prompt:'请输入学生姓名'" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input class="easyui-textbox" label="所在高中:" name="SchoolName" style="width: 44%;" data-options="prompt:'请选择所在高中'" />
            <p></p>
            <input class="easyui-textbox" label="所在班级:" style="width: 44%;" name="ClassName" data-options="prompt:'请选择所在班级'" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <input class="easyui-combobox" name="sub" style="width:44%;" data-options="
                    url: '../../Handler/DataManag/DataManagement.ashx?para=km',
                    method: 'get',
                    valueField: 'Did',
                    textField: 'Degree',
                    label: '学&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;历:',
                   prompt:'请选择学历'
                    "/>
            <p></p>
            <select data-options="prompt:'请选择'" class="easyui-combobox" name="ScoreCrosses" label="分数是否过线:" style="width: 44%;">
                 <option value="1">是</option>
                 <option value="0">否</option>
            </select>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <select data-options="prompt:'请选择'" class="easyui-combobox" name="WhetherAccept" label="是否录取:" style="width: 44%;">
                
                 <option value="1">是</option>
                 <option value="0">否</option>
            </select>
            <p></p>
             <select  data-options="prompt:'请选择是否预报名'" class="easyui-combobox" name="WhetherPrepare" label="是否预报名:" style="width: 44%">
                 <option value="1">已预报名</option>
                 <option value="0">未预报名</option>
            </select>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <select  class="easyui-combobox" name="SourceIId" label="第一来源:" style="width: 44%;" data-options="
                    url: '../../Handler/DataManag/DataManagement.ashx?para=ly',
                    method: 'get',
                    valueField: 'SoureId',
                    textField: 'SourceName',
                    label: '第一来源:',
                prompt:'请选择第一来源'
                    ">
            </select>
            <p></p>
            <input class="easyui-textbox" label="QQ号:" style="width: 44%;" name="QQId" data-options="prompt:'请输入QQ号输入'" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <input class="easyui-combobox" name="TeacherId" style="width:44%;" data-options="
                    url: '../../Handler/DataManag/DataManagement.ashx?para=ls',
                    method: 'get',
                    valueField: 'PIid',
                    textField: 'PIName',
                    label: '分配老师:',
                   prompt:'请选择分配老师'
                    "/>
             <p></p>
            <input class="easyui-textbox" label="手机号:" style="width: 44%;" name="PhoneID" data-options="prompt:'请输入学生手机号'" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input class="easyui-textbox" label="学生分数:" style="width: 44%;" name="ActualScore" data-options="prompt:'请输入学生分数'" />
             
              <p></p>
             <input class="easyui-combobox" name="Academyid" style="width:96%;" data-options="
                    url: '../../Handler/DataManag/DataManagement.ashx?para=zy',
                    method: 'get',
                    valueField: 'AId',
                    textField: 'AName',
                    label: '请选择专业:',
                    prompt:'请选择专业'
                    "/>
        </form>
    </div>
    <div id="dlg-bu">
        <a href="javascript:void(0)" class="easyui-linkbutton c6" iconcls="icon-ok" onclick="saveuser()" style="width:90px">提交</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-cancel" onclick="javascript:$('#dlg_QX').dialog('close')" style="width:90px">取消</a>
   </div>


    <%--咨询记录查询--%>
    <div id="dlg_a" title="咨询记录查询" class="easyui-dialog" style="width:50%" data-options="closed:true,modal:true,border:'thin',buttons:'#dlg-buttons'">
       <table id="dg_a" class="easyui-datagrid"  style="width: 100%;" >
        <thead>
            <tr>
                <th field="RID" width="120">ID</th>
                <th field="PIName" width="120">咨询人</th>
                <th field="STUName" width="120">学生姓名</th>
                <th field="RTime" width="120">咨询时间</th>
                <th field="Recs" width="120">咨询记录</th>
            </tr>
        </thead>
    </table>
    </div>

    <div id="dlg-buttonsA">
        <a href="javascript:void(0)" class="easyui-linkbutton c6" iconcls="icon-ok" onclick="saveuser()" style="width:90px">提交</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-cancel" onclick="javascript:$('#dlg_a').dialog('close')" style="width:90px">取消</a>
   </div>

    <div id="toolbaraa">
        <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-add" plain="true" onclick="newUserT()">添加</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-edit" plain="true" onclick="GetModuleInfoT()">修改</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-tip" plain="true" onclick="DelectUserT()">删除</a>
    </div>
    <input type="hidden" name="SelectPaa" id="SelectPaa" value="" />

    <div id="dlg_add" title="增加咨询记录" class="easyui-dialog" style="width:70%;height:300px" data-options="closed:true,modal:true,border:'thin',buttons:'#dlg-buttonsb'">
        <form id="addfmm" class="contact-form" method="post" style="margin:0;padding:20px 50px">
            <p></p>
            <input type="hidden" name="RID" id="RID" value="" />
            <p></p>
             <input class="easyui-combobox" name="RName" id="RName" style="width:100%;" data-options="
                    url: '../../Handler/DataManag/DataManagement.ashx?para=ls',
                    method: 'get',
                    valueField: 'PIid',
                    textField: 'PIName',
                    label: '咨询人:',
                   prompt:'请选择咨询人'
                    "/>
            <p></p>
               <input class="easyui-textbox" label="咨询记录:" style="width: 100%;" name="Recs" id="Recs" data-options="prompt:'请输入咨询记录'" />
        </form>
 </div>
   <div id="dlg-buttonsb">
        <a href="javascript:void(0)" class="easyui-linkbutton c6" iconcls="icon-ok" onclick="saveuserT()" style="width:90px">提交</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-cancel" onclick="javascript:$('#dlg_add').dialog('close')" style="width:90px">取消</a>
    </div>
     <%--  <div id="dlg_updateaa" title="修改咨询记录" class="easyui-dialog" style="width:70%;height:300px" data-options="closed:true,modal:true,border:'thin',buttons:'#dlg-buttonsbaa'">
        <form id="addfmma" class="contact-form" method="post" style="margin:0;padding:20px 50px">
            <p></p>
            <input type="text" name="RID" id="RID" value="" />
            <p></p>
             <input class="easyui-combobox" name="RName" id="RNameaa" style="width:100%;" data-options="
                    url: '../../Handler/DataManag/DataManagement.ashx?para=ls',
                    method: 'get',
                    valueField: 'PIid',
                    textField: 'PIName',
                    label: '咨询人:',
                   prompt:'请选择咨询人'
                    "/>
            <p></p>
               <input class="easyui-textbox" label="咨询记录:" style="width: 100%;" name="Recs" id="Recsaa" data-options="prompt:'请输入咨询记录'" />
        </form>
 </div>
     <div id="dlg-buttonsbaa">
        <a href="javascript:void(0)" class="easyui-linkbutton c6" iconcls="icon-ok" onclick="saveuserTa()" style="width:90px">提交</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-cancel" onclick="javascript:$('#dlg_updateaa').dialog('close')" style="width:90px">取消</a>
    </div>--%>

    <%--分配--%>
      <div id="dlg_Q" title="分配" class="easyui-dialog" style="width:70%" data-options="closed:true,modal:true,border:'thin',buttons:'#dlg-buttonsT'">
        <form id="fmm" class="contact-form" method="post" style="margin:0;padding:20px 50px">
            <span style="margin-left:25%"></span>
             <input class="easyui-combobox" name="TeacherId" style="width:44%;" data-options="
                    url: '../../Handler/DataManag/DataManagement.ashx?para=ls',
                    method: 'get',
                    valueField: 'PIid',
                    textField: 'PIName',
                    label: '分配老师:',
                   prompt:'请选择分配老师'
                    "/>
            <p></p>
             <div class="easyui-accordion" data-options="region:'center'" style="width: 100%;">
    <table id="dgg" class="easyui-datagrid"  style="width: 100%;height:300px" >
        <thead>
            <tr>
                <th data-options="field:'StudentID',width:120">ID</th>
                <th data-options="field:'STUName',width:120">学生姓名</th>
                 <th field="SchoolName" width="120">高中</th>
                <th field="ClassName" width="120">班级</th>
                <th field="Degree" width="120">学历</th>
                <th field="AName" width="120">专业</th>
                <th field="PIName" width="120">咨询人</th>
            </tr>
        </thead>
    </table>
 </div>
        </form>
 </div>
     <div id="dlg-buttonsT">
        <a href="javascript:void(0)" class="easyui-linkbutton c6" iconcls="icon-ok" onclick="saveuser()" style="width:90px">提交</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-cancel" onclick="javascript:$('#dlg_QX').dialog('close')" style="width:90px">取消</a>
   </div>

    <%--转介绍到其他校区--%>
       <div id="dlg_Qa" title="分配" class="easyui-dialog" style="width:70%;height:500px" data-options="closed:true,modal:true,border:'thin',buttons:'#dlg-buttonsaa'">
           <p></p>
           <p></p>
           <span style="margin-left:30%"></span>
           <input type="hidden" id="iddd"  name="iddd" value="" />
          <input class="easyui-combotree" name="AName" id="AName" style="width:50%;"/>
           <p></p>
           <p></p>
		 <form id="Turn-fm" class="contact-form" method="post" novalidate style="margin: 0; padding: 20px 50px">
            <table id="dgga" class="easyui-datagrid"  style="width: 100%;" >
        <thead>
            <tr>
                 <th data-options="field:'StudentID',width:120">ID</th>
                <th data-options="field:'SourceName',width:120">第一来源</th>
                <th data-options="field:'STUName',width:120">学生姓名</th>
                <th field="SchoolName" width="120">高中</th>
                <th field="AName" width="120">专业</th>
                <th field="ClassName" width="120">班级</th>
            </tr>
        </thead>
    </table>
        </form>
 </div>
    <div id="dlg-buttonsaa">
        <a href="javascript:void(0)" class="easyui-linkbutton c6" iconcls="icon-ok" onclick="saveuserBO()" style="width:90px">提交</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-cancel" onclick="javascript:$('#dlg_QX').dialog('close')" style="width:90px">取消</a>
   </div>
</body>
</html>
<script>
    //咨询记录修改
    function GetModuleInfoT() {
        var row = $("#dg_a").datagrid("getSelected");
        if (row) {
            $("#dlg_add").dialog('open').dialog('center').dialog('setTitle', '咨询记录修改');
            $("#RID").val(row.RID);
            $("#Recs").textbox('setText', row.Recs);
            $("#RName").combobox('setText', row.PIName);
            $("#SelectPaa").val("2")
        } else {
            $.messager.show({
                title: '提示消息',
                msg: '请选择修改行',
                showType: 'show'
            });
        }
       
    }
    function saveuserTa(){
        var row = $("#dg_a").datagrid("getSelected");//获取当前行数据
        var f = $("#addfmm").serializeArray();
        var d = {};
        $.each(f, function () {
            d[this.name] = this.value
        })
        $.ajax({
            url: "../../Handler/DataManag/DataManagement.ashx?para=edddd",
            data: {
                forms: JSON.stringify(d),
                sid: row.RID
            },
            success: function (res) {
                $.messager.show({
                    title: '提示消息',
                    msg: res,
                    showType: 'show'
                });
                $("#dlg_add").dialog('close');
                $("#dlg_a").dialog('close');
                $('#dg').datagrid('reload');
            }
        })
    }

    //主页人员删除
    function DeleteUser() {
        var row1 = $('#dg').datagrid('getSelected');
        $.ajax({
            url: "../../Handler/DataManag/DataManagement.ashx?para=deletea",
            data: {
                id: row1.StudentID
            },
            success: function (res) {
                $.messager.show({
                    title: '提示消息',
                    msg: res,
                    showType: 'show'
                });
                $('#dg').datagrid('reload');
            }
        })
    }
    //查询
    function SelectWhere() {
        var ida = $("#stuid").textbox('getText');
        var idt = $("#stulya").combobox('getText');
        var idtr = $("#stunameaa").textbox('getText');
        var idf = $("#TeacherIdaa").combobox('getText');
        $('#dg').datagrid({
            url: '../../Handler/DataManag/DataManagement.ashx?para=list&ida=' + ida + "&idt=" + idt + "&idtr=" + idtr + "&idf=" + idf,
            pagination: true,     //分页
            singleSelect: true,   //单行选中
        })
        $('#stuid').textbox("setText", '');
        $('#stulya').combobox("setText", '');
        $('#stunameaa').textbox("setText", '');
        $('#TeacherIdaa').combobox("setText", '');
    }

    //转校区
    function saveuserBO() {
        var row = $("#dgga").datagrid("getSelections");
        var AId = $("#AName").combotree('getValue')
        for (var i = 0; i < row.length; i++) {
            $.ajax({
                url: "../../Handler/DataManag/DataManagement.ashx?para=AddTemporarytransfer",
                data: {
                    AId: AId,
                    ZXSJId: row[i]["StudentID"],
                    tid: row[i]["PIName"]
                },
                success: function (res) {
                    $.messager.show({
                        title: '提示消息',
                        msg: res,
                        showType: 'show'
                    });
                    $("#dlg_Qa").dialog('close');
                    $('#dg').datagrid('reload');
                }
            })
        }
    }


    $(function () {
        mainselect();
    })
    //咨询记录弹框
    function TCCT(value) {
        return "<a href='###' onclick='as()'>" + value + "条</a>"
    }
    function as() {
        $("#dlg_a").dialog('open').dialog('center').dialog('setTitle', '咨询记录');
        var row = $("#dg").datagrid("getSelected");//获取当前行数据
        $('#dg_a').datagrid({
            url: '../../Handler/DataManag/DataManagement.ashx?para=zxjl&id=' + row.StudentID,
            pagination: true,     //分页
            toolbar: toolbaraa,   //工具栏
            singleSelect: true,  //单行选中
        });
        $('#dlg_a').form('clear');
        $("#SelectPa").val("1")
    }
    function newUserT() {
        $("#dlg_add").dialog('open').dialog('center').dialog('setTitle', '新增');
        $('#dlg_add').form('clear');
        $("#SelectPaa").val("1")
    }

    
    function saveuserT() {
        if (($("#SelectPaa").val() == "1")) {
            var row = $("#dg").datagrid("getSelected");//获取当前行数据
            var f = $("#addfmm").serializeArray();
            var d = {};
            $.each(f, function () {
                d[this.name] = this.value
            })
            if (($("#SelectPaa").val() == "1")) {
                delete d.RID
            };
            $.ajax({
                url: "../../Handler/DataManag/DataManagement.ashx?para=add",
                data: {
                    forms: JSON.stringify(d),
                    STUName: row.StudentID,
                    na: row.PIName
                },
                success: function (res) {
                    $.messager.show({
                        title: '提示消息',
                        msg: res,
                        showType: 'show'
                    });
                    $("#dlg_add").dialog('close');
                    $("#dlg_a").dialog('close');
                    $('#dg').datagrid('reload');
                }
            })
        } else {
         var row = $("#dg").datagrid("getSelected");//获取当前行数据
            var f = $("#addfmm").serializeArray();
            var d = {};
            $.each(f, function () {
                d[this.name] = this.value
            })
            if (($("#SelectPaa").val() == "1")) {
                delete d.RID
            };
            $.ajax({
                url: "../../Handler/DataManag/DataManagement.ashx?para=edddd",
                data: {
                    forms: JSON.stringify(d),
                    STUName: row.StudentID,
                    na: row.PIName,
                },
                success: function (res) {
                    $.messager.show({
                        title: '提示消息',
                        msg: res,
                        showType: 'show'
                    });
                    $("#dlg_add").dialog('close');
                    $("#dlg_a").dialog('close');
                    $('#dg').datagrid('reload');
                }
            })
        }
    }

    function DelectUserT() {
        var row = $("#dg_a").datagrid("getSelected");//获取当前行数据
        if (row) {
            $.messager.confirm('警告', '确定删除?', function (r) {
                if (r) {
                    $.ajax({
                        url: "../../Handler/DataManag/DataManagement.ashx?para=delete",
                        data: { id: row.RID },
                        success: function (data) {
                            $.messager.show({
                                title: '提示消息',
                                msg: data,
                                showType: 'show'
                            });
                            $("#dlg_QX").dialog('close');
                            $("#dlg_a").dialog('close');
                            $('#dg').datagrid('reload');
                        }
                    })
                }
            })
        } else {
            $.messager.confirm('警告', '请选中一行内容后重试')
        }
    }
    //咨询记录结束
    //主页面显示
    function mainselect() {
        $('#dg').datagrid({
            url: '../../Handler/DataManag/DataManagement.ashx?para=list',
            pagination: true,     //分页
            toolbar: toolbar1,   //工具栏
            singleSelect: true,  //单行选中
            fit: true,
            //fitColumns: true,//自适应宽度
            collapsible: true,
        });
    }

    
    
    //新增
    function newUser() {
        $("#dlg_QX").dialog('open').dialog('center').dialog('setTitle', '新增');
        $('#dlg_QX').form('clear');
        $("#SelectPa").val("1")
    }

    //保存 修改
    function saveuser() {
        alert($("#SelectPa").val())
        var row = $('#dgg').datagrid('getSelected');
        if ($("#SelectPa").val() == "1") {
            var f = $("#fm").serializeArray();
            var d = {};
            $.each(f, function () {
                d[this.name] = this.value
            })
            if (($("#SelectPa").val() == "1")) {
                delete d.StudentID
            };
            $.ajax({
                url: "../../Handler/DataManag/DataManagement.ashx?para=addUser",
                data: {
                    forms: JSON.stringify(d),
                },
                success: function (res) {
                    $.messager.show({
                        title: '提示消息',
                        msg: res,
                        showType: 'show'
                    });
                    $("#dlg_QX").dialog('close');
                    $('#dg').datagrid('reload');
                }
            })
        } else if (($("#SelectPa").val() == "2")) {
            var f = $("#fmm").serializeArray();
            var d = {};
            $.each(f, function () {
                d[this.name] = this.value
            })
            $.ajax({
                url: "../../Handler/DataManag/DataManagement.ashx?para=editUser",
                data: {
                    forms: JSON.stringify(d),
                    id: row.StudentID
                },
                success: function (res) {
                    $.messager.show({
                        title: '提示消息',
                        msg: res,
                        showType: 'show'
                    });
                    $("#dlg_Q").dialog('close');
                    $('#dg').datagrid('reload');
                }
            })
        }
    }
    //分配
    function editUser() {
        $("#dlg_Q").dialog('open').dialog('center').dialog('setTitle', '分配');
        $('#dgg').datagrid({
            url: '../../Handler/DataManag/DataManagement.ashx?para=listT',
            pagination: true,     //分页
            checkbox: true,
        });
        $('#dlg_Q').form('clear');
        $("#SelectPa").val("2")
    }
    //导出当前页数据
    function Exportcurrent() {
        $.ajax({
            url: "../../Handler/DataManag/DataManagement.ashx?para=Expo",
            data: {},
            success: function (res) {
                $.messager.show({
                    title: '提示消息',
                    msg: '当前页面数据表格导出成功',
                    showType: 'show'
                });
            }
        })
    }
    //导出所有数据
    function ExportAll() {
        $.ajax({
            url: "../../Handler/DataManag/DataManagement.ashx?para=ExpoAll",
            data: {},
            success: function (res) {
                $.messager.show({
                    title: '提示消息',
                    msg: '所有数据表格导出成功',
                    showType: 'show'
                });
            }
        })
    }

    //转介绍导其他校区
    function Transfer() {
        $("#dlg_Qa").dialog('open').dialog('center').dialog('setTitle', '转介绍到其他校区');
        var row = $("#dg").datagrid("getSelected");//获取当前行数据
        $('#dgga').datagrid({
            url: '../../Handler/DataManag/DataManagement.ashx?para=list',
            pagination: true,     //分页
        });
        $('#AName').combotree({
            prompt: '请选择或输入',
            url: '../../Handler/Mange/Management.ashx?para=dropdown',
            method: 'get',
            valueField: 'AId',
            textField: 'AName',
            panelHeight: 'auto',
            label: '学院名称:',
        })
        $('#dlg_Qa').form('clear');
    }
</script>
<script src="../../Scripts/script.js"></script>