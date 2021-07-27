<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="ZSPrj.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="Content/easyui/themes/bootstrap/easyui.css" />
    <link rel="stylesheet" href="Content/easyui/themes/icon.css" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Content/easyui/jquery.easyui.min.js"></script>
    <link href="Content/tailwind.min.css" rel="stylesheet" />
    <link href="Content/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
   <style>
        #Menua a{
            display:block;
            line-height:80px;
            text-decoration:none;
            font-size:15px;
            color:#808080;
        }
        
        #Menua li{
            height:80px;
            animation-name: example;
            list-style-type:none;
        }
        #Menua a:hover{
            color:#2d3748;
        }

        #Menua ul li:hover{
             transition: background 0.5s;
             background-color:#fff;
        }

        #Menua{
            background-color:#2d3748;
        }
        
      nav a {
        display: flex; 
        height: 100%;
        align-items: center;
        padding: 0 15px;
      }
      nav a:hover {
        color: #fff;
      }
      nav li > ul {
        background: #2d3748;
        position: absolute;
        overflow: hidden;
        min-width: 160px;
        opacity: 0;
        visibility: hidden;
        transition: ease all 0.3s;
      }
      nav li > ul a {
        line-height: 40px;
      }
      nav li:hover > ul {
        visibility: visible;
        opacity: 1;
      }
      /*消息样式*/
    
#badge {
    width: 20px;
    height: 10px;
    line-height: 20px;  /* 数值与height相同，使数字垂直居中 */
    text-align: center;  /* 使数字水平居中 */
    /*background-color: red;*/
    color: white;
    font-size: 12px;
    font-weight: 700;
    border-radius: 50%;  /* 使正方形变圆形，矩形变椭圆形 */
    position: relative;
    bottom: 40px;
    left: 55px;
}
       
    </style>
</head>
<%--<a href="">Views/PowerInfo/PowerInfoView.aspx</a>
<a href="Views/Modeue/ModeueInfoView.aspx">Views/Modeue/ModeueInfoView.aspx</a>--%>
<body class="easyui-layout">
     <%--   上方开始--%>
         <div data-options="region:'north'" style="height:52px">
             <nav class="flex items-center justify-between bg-gray-800 text-gray-500 px-4 h-12">
                  <div class="flex items-center h-full">
                        <div style="width:320px;height:48px;text-align:center; line-height:48px;"><i class="fa fa-scribd"></i>  Happy Cloud</div>
                            <ul class="ml-4 flex items-stretch h-full">
                              <li>
                                        <a href="###" id="picture" onclick="aa()" >消息提示</a>
                                        <div onload="aa()" id="badge"></div>
                                  <%--<%= Session["a"]%>--%>
                                  
                              </li>
                              <li>
                                <a href="###">欢迎您!<label id="GetName"></label></a>
                              </li>
                              <li>
                                <a href="###">【<label id="PowerName"></label>】</a>
                              </li>
                              <li>
                                <a href="###">切换权限</a>
                              </li>
                              <li>
                                <a href="###" onclick="EditPwd()">修改密码</a>
                              </li>
                              <li>
                                <a href="SignOut.aspx">退出登录</a>
                              </li>
                            </ul>
                  </div>
      
                </nav>
        </div>
    <a href="">Views/DataManag/DataManagement.aspx</a>
   <%-- 上方结束--%>
        <div data-options="region:'south',split:false" style="height:30px;"></div> 
    <%--   中部开始--%>

    <%--左侧导航--%>
     <div id="Menua" data-options="region:'west'" title="招生管理" style="width:320px;padding:10px">
            
        </div>
    <%--iframe--%>
        <div data-options="region:'center',title:''">
             <iframe id="sz-iframe" src="Views/WebForm1.aspx" name="mainIframe" frameborder="0" style=" width:100%;min-height:600px; height:900px">
             </iframe>
        </div>
        <%-- 中部结束--%>

    <div id="dlg" class="easyui-dialog" style="width:400px" data-options="closed:true,modal:true,border:'thin',buttons:'#dlg-buttons'">
    <form id="fm" class="contact-form" method="post" novalidate style="margin:0;padding:20px 50px">
        <div style="margin-bottom:10px">
            <span>新&nbsp;密&nbsp;码:</span>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input name="OldPIpwd" id="OldPIpwd" class="easyui-textbox" required="true" label="" style="width:70%">
        </div>
        <div style="margin-bottom:10px">
            <span>请重复输入密码:</span>
            <input name="NewPIpwd" id="NewPIpwd" class="easyui-textbox" required="true" label="" style="width:70%">
        </div>
    </form>
   </div>
    <div id="dlg-buttons">
        <a href="javascript:void(0)" class="easyui-linkbutton c6" iconcls="icon-ok" onclick="saveuser()" style="width:90px;">保存</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-cancel" onclick="javascript:$('#dlg').dialog('close'); $('#fm').form('clear');" style="width:90px">取消</a>
    </div>
    <input type="button" name="name" value="asdasda" onclick="GetName()" />
      <%--暂存记录表--%>
    <div id="ZCJL-dlgg" title="暂存记录表" class="easyui-dialog" style="width: 800px" data-options="closed:true,modal:true,border:'thin',buttons:'#ZCJL-buttons'">
        <table id="ZCJL-dgg" title="" class="easyui-datagrid" style="width: 800px; height: 380px">
            <thead data-options="frozen:true">
                <%--//冻结想要的列--%>
                <tr>
                    <th field="" checkbox="true"></th>
                    <th field="TtId" width="120">编号</th>
                    <th field="STUName" width="120">学生姓名</th>
                    <th field="AName" width="120">二级学院</th>
                    <th field="SecondSchool" width="120">二级学院id</th>
                </tr>
            </thead>
        </table>
        <div id="ZCJL-buttons">
            <a href="javascript:void(0)" class="easyui-linkbutton c6" iconcls="icon-ok" onclick="saveconfirm()" style="width: 90px">确认分配</a>
            <a href="javascript:void(0)" class="easyui-linkbutton c6" iconcls="icon-ok" onclick="savecancel()" style="width: 90px">取消分配</a>
            <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-cancel" onclick="javascript:$('#ZCJL-dlgg').dialog('close');" style="width: 90px">重置</a>
        </div>
    </div>
    <input type="button" name="name" value="asdasda" onclick="GetName()" />
    <input type="button" name="name" id="tem" value="<%= Session["TEM"]%>" />
     <input type="button" name="name" id="temw" value="<%= Session["PIa"]%>" />
    
</body>
</html>
<script>

    setInterval(function () {
        var id = $("#temw").val();
        $.ajax({
            url: "Handler/Temporarytransfer.ashx?para=transfe&id=" + id,
            data: {},
            success: function (res) {
                //alert(res)
                $("#badge").html(res);
                //(int)res.Rows[0]["num"];
                //alert(res);
            }
        })
    }, 1000);

    $(function () {
        GetFourMenu();
        GetName();
    })
    function aa() {
        $("#ZCJL-dlgg").dialog('open');
        TurnZXSJToList()
    }


    //确认分配
    function saveconfirm() {
        var row = $("#ZCJL-dgg").datagrid('getSelections');
        if (row) {
            for (var i = 0; i < row.length; i++) {
                $.ajax({
                    url: "../../Handler/Temporarytransfer.ashx?para=saveconfirm",
                    data: {
                        id: row[i]["StudentID"],
                        SsName: row[i]["SecondSchool"],
                        tid: row[i]["TtId"],
                        Stuname: row[i]["STUName"]
                    },
                    success: function (res) {
                        $.messager.show({
                            title: '提示消息',
                            msg: res,
                            showType: 'show'
                        });
                        $('#ZCJL-dlgg').dialog('close');
                    }
                })
            }
        } else {
            $('#ZCJL-dlgg').dialog('close');
        }
    }

    //取消分配
    function savecancel() {
        var row = $("#ZCJL-dgg").datagrid('getSelections');
        if (row) {
            for (var i = 0; i < row.length; i++) {
                $.ajax({
                    url: "../../Handler/Temporarytransfer.ashx?para=savecancel",
                    data: {
                        id: row[i]["TtId"]
                    },
                    success: function (res) {
                        $.messager.show({
                            title: '提示消息',
                            msg: res,
                            showType: 'show'
                        });
                        $('#ZCJL-dlgg').dialog('close')
                    }
                })
            }
        } else {
            $('#ZCJL-dlgg').dialog('close');
        }
    }

    function TurnZXSJToList() {
        var id = $("#temw").val();
        //alert(id)
        $("#ZCJL-dgg").datagrid({
            url: "Handler/Temporarytransfer.ashx?para=TurnZXSJToList&id="+id,
            pagination: true,     //分页
        })
    }
    //左侧导航获取
    function GetFourMenu() {
        $.ajax({
            url: "/Handler/ModuleInfoHandler.ashx?para=GetFourMenu",
            data: {},
            dataType: "json",
            success: function (res) {
                var ht = "";
                for (var i = 0; i < res.length; i++) {
                    ht += "<ul id='menu'><li><img style='padding-left:90px;float:left;padding-top:25px' src='icon/巡查管理.svg' /><a target='mainIframe' href=" + res[i].ModuleUrl + ">" + res[i].ModuleName + "</a></li></ul>";
                }
                $("#Menua").html(ht);
            }
        })
    }
    //弹框出现
    function EditPwd() {
        $("#dlg").dialog('open').dialog('center').dialog('setTitle', '修改密码');
    }
    //修改密码
    function saveuser() {
        var OldPIpwd = $("#OldPIpwd").val();
        var NewPIpwd = $("#NewPIpwd").val();
        if (OldPIpwd == NewPIpwd) {
            $.ajax({
                url: "/Handler/ModuleInfoHandler.ashx?para=savePIPwd",
                data: {
                    NewPIpwd: NewPIpwd
                },
                success: function (res) {
                    $.messager.show({
                        title: '提示消息',
                        msg: res,
                        showType: 'show'
                    });
                    $("#dlg").dialog('close')
                    $("#fm").form('clear')
                }
            })
        } else {
            $.messager.show({
                title: '提示消息',
                msg: "两次输入密码不一致",
                showType: 'show'
            });
        }
        
    }
    function GetName() {
        $.ajax({
            url: "/Handler/ModuleInfoHandler.ashx?para=GetName",
            data: {},
            success: function (res) {
                $("#GetName").html(res)
            }
        })
        $.ajax({
            url: "/Handler/ModuleInfoHandler.ashx?para=GetPID",
            data: {},
            success: function (res) {
                $("#PowerName").html(res)
            }
        })
    }

</script>
<script src="Scripts/script.js"></script>