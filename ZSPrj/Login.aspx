<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ZSPrj.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body {
          color: #b5b5b5;
          font-family: "PingFang SC","Helvetica Neue",Helvetica,"Microsoft Yahei","WenQuanYi Micro Hei",Arial,Verdana,sans-serif;
          background-color: #3A4565;
        }

        .left {
          float: left;
        }

        .right {
          float: right;
        }

        .clear-fix {
          clear: both;
        }

        .line {
          border-bottom: 1px solid #ececec;
        }

        .panel {
           
          width: 600px;
          margin: auto;
        }

        .panel--title {
          color: #3A4565;
          font-size: 20px;
          font-weight: 400;
          text-align: left;
          padding: 30px 0px 20px 25px;
        }

        .panel--wrapper {
          width: 100%;
          float: left;
          position: relative;
        }

        .panel--box {
          width: 50%;
          float: left;
          z-index: 1;
          position: absolute;
          border-radius: 4px;
          transition: all 0.5s;
          opacity: 0.1;
          margin-top: 40px;
          background-color: #ffffff;
        }

        .panel--box.active {
          z-index: 2;
          opacity: 1;
        }

        .panel--box:first-child {
          left: 0;
          transform: translateX(30%) scale(0.8);
          animation: box-1--out 0.5s;
          transform-origin: center right;
        }

        .panel--box:first-child.active {
          transform: translateX(35%);
          animation: box-1 0.5s;
        }

        .panel--box:last-child {
          right: 0;
          transform: translateX(-30%) scale(0.8);
          animation: box-2--out 0.5s;
          transform-origin: center left;
        }

        .panel--box:last-child.active {
          animation: box-2 0.5s;
          transform: translateX(-35%);
        }

        .sign--input {
          border-left: 5px solid transparent;
          transition: all 0.3s linear;
        }

        .sign--input:hover {
          background: #F0F0F0;
          border-left: 5px solid #6172a4;
        }

        .sign--input input {
          width: 290px;
          padding: 20px 0px;
          background: transparent;
          border: 0;
          outline: none;
          color: #222;
          margin: 0 auto;
          text-indent: 20px;
          font-weight: bold;
        }

        .sign--input input::-webkit-input-placeholder {
          color: #777;
          font-weight: bold;
        }

        .sign--checkbox {
          padding: 30px 0px;
          font-size: 12px;
          text-indent: 20px;
          line-height: 15px;
          margin-left: 25px;
          display: inline-block;
        }

        .sign--checkbox input {
          display: none;
        }

        .sign--checkbox label {
          display: block;
          position: absolute;
          margin-top: 2px;
          width: 6px;
          height: 6px;
          border-radius: 2px;
          content: "";
          transition: all 0.5s ease-in-out;
          cursor: pointer;
          border: 3px solid white;
          box-shadow: 0px 0px 0px 2px #ccc;
        }

        .sign--checkbox input:checked ~ label {
          background: #3A4565;
          border: 3px solid white;
          box-shadow: 0px 0px 0px 2px #3A4565;
        }

        .sign--button {
          background-color: #3A4565;
          border: 0;
          height: 30px;
          border-radius: 3px;
          color: white;
          font-weight: bold;
          padding: 0px 25px;
          cursor: pointer;
          transition: background 0.3s ease-in-out;
          margin: 23px 20px 0 50px;
        }

        .sign--button:hover {
          background: #272f45;
        }

        .sign--button--outline {
          background-color: transparent;
          border: 1px solid #3A4565;
          color: #3A4565;
        }

        .sign--button--outline:hover {
          background-color: transparent;
          border: 1px solid #272f45;
          color: #272f45;
        }

        .sign__forgot {
          margin-top: 25px;
          display: block;
          font-size: 13px;
          text-align: left;
          font-weight: bold;
          color: #b5b5b5;
          padding: 0px 0px 25px 25px;
        }

        .sign__forgot h3 {
          font-size: 16px;
          font-weight: normal;
          margin-bottom: 15px;
        }

        .sign__forgot a {
          color: #777;
        }

        .sign--link {
          width: 32px;
          height: 32px;
          display: block;
          border-radius: 0 3px 3px 0;
          position: absolute;
          right: -52px;
          background: #E68C51;
          cursor: pointer;
          border-right: none;
          top: 35px;
          line-height: 32px;
          color: #fff;
          padding: 0 10px 0px 10px;
          font-size: 14px;
          text-decoration: none;
        }

        .sign--link:hover {
          background: #e06f24;
          transition: all 0.2s linear;
        }

        .signup__link {
          width: 64px;
          left: -84px;
          right: auto;
          border-radius: 3px 0 0 3px;
          text-align: center;
        }

        .signup__title {
          text-align: right;
          padding: 30px 25px 20px 0px;
        }

        .signup__button {
          margin: 20px;
        }

        @keyframes box-1 {
          0% {
            transform: translateX(30%) scale(0.8);
            z-index: 1;
          }
          49% {
            transform: translateX(0) scale(0.9);
            z-index: 1;
          }
          50% {
            transform: translateX(0) scale(0.9);
            z-index: 2;
          }
          100% {
            transform: translateX(35%) scale(1);
            z-index: 2;
          }
        }

        @keyframes box-1--out {
          0% {
            transform: translateX(35%) scale(1);
            z-index: 2;
          }
          49% {
            transform: translateX(0) scale(0.9);
            z-index: 2;
          }
          50% {
            transform: translateX(0) scale(0.9);
            z-index: 1;
          }
          100% {
            transform: translateX(30%) scale(0.8);
            z-index: 1;
          }
        }

        @keyframes box-2 {
          0% {
            transform: translateX(-30%) scale(0.8);
            z-index: 1;
          }
          49% {
            transform: translateX(0) scale(0.9);
            z-index: 1;
          }
          50% {
            transform: translateX(0) scale(0.9);
            z-index: 2;
          }
          100% {
            transform: translateX(-35%) scale(1);
            z-index: 2;
          }
        }

        @keyframes box-2--out {
          0% {
            transform: translateX(-35%) scale(1);
            z-index: 2;
          }
          49% {
            transform: translateX(0) scale(0.9);
            z-index: 2;
          }
          50% {
            transform: translateX(0) scale(0.9);
            z-index: 1;
          }
          100% {
            transform: translateX(-30%) scale(0.8);
            z-index: 1;
          }
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel">
    <div class="panel--wrapper">
        <div class="active panel--box sign signin">
            <a class="sign--link" href="/Login/sign/signin" id="signUp">
                注册
            </a>
            <div class="panel--header">
                <h2 class="panel--title">登录</h2>
            </div>
            <div class="panel--body">
                <div class="sign--input">
                    <asp:TextBox name="username" placeholder="请输入您的账号" ID="txtPIUser" runat="server" autofocus ></asp:TextBox>
                </div>
                <div class="sign--input">
                    <asp:TextBox name="password" placeholder="请输入您的密码" ID="txtPIpwd" runat="server" autofocus ></asp:TextBox>
                </div>
                <div>
                    <div class="sign--checkbox">
                        <input id="remember" checked="checked" name="remember" type="checkbox"/>
                        <label for="remember"></label>记住我
                    </div>
                    <asp:Button class="sign--button right login-btn" ID="btn1" Text="登录" runat="server" OnClick="Button2_Click" />
                    <div class="line"></div>
                </div>
                <div class="sign__forgot">
                   <asp:Label ID="lagMsg" runat="server" ></asp:Label>
                </div>
            </div>
        </div>
        <div class="panel--box sign signup">
            <a class="sign--link signup__link" href="/Login/sign/signin" id="signIn">
                马上登录
            </a>
            <div class="panel--header">
                <h2 class="panel--title signup__title">注册</h2>
            </div>
            <div class="panel--body">
                <div class="sign--input">
                    <input name="username" id="username" placeholder="用户名" type="text" autofocus/>
                </div>
                <div class="sign--input">
                    <input name="password" id="password" placeholder="密码" type="password"/>
                </div>
                <div class="panel--border-bottom">
                    <div class="line"></div>
                    <asp:Button class="sign--button right login-btn" ID="Button2" Text="注册" runat="server" OnClick="Button2_Click" />
                </div>
            </div>
        </div>
    </div>
</div>
    </form>
</body>
</html>
<script src="../../Scripts/script.js"></script>