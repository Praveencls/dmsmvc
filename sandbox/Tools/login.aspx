<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DTCC.Web.Tools.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="/Presentation/Includes/css/style.css" />
    <link rel="stylesheet" type="text/css" href="/Presentation/Includes/css/custom-style.css" />
    <link rel="stylesheet" type="text/css" href="/Presentation/Includes/css/jquery-ui/jquery-ui-1.10.2.custom.min.css" />
    <style type="text/css">
        .ui-datepicker, .ui-datepicker table tr td {
            font-size: 10px;
            line-height: 14px;
        }

        .datepicker {
            float: left;
        }

            .datepicker + img {
                float: left;
                margin-left: 5px;
            }

        #article_desc {
            min-width: 900px;
        }

        #cbFlag, #cbHoliday {
            float: left;
            margin-right: 10px;
        }

        .article_content_sm #article_desc div span.cbText, .article_content_sm #article_desc div span.info-text {
            color: #898989;
            float: left;
            font-size: 14px;
            font-weight: normal;
            line-height: 11px;
            margin: 4px 0 0;
            width: 200px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div id="container">
            <header>

                <div id="header_elements" class="cf">&nbsp;</div>
                <div id="navigation_elements" class="cf">
                    <div class="wrapper">
                        <h1 id="logo">
                            <a href="/">
                                <%--<sc:FieldRenderer ID="sitelogo" FieldName="site logo" runat="server" Parameters="style=float:left;" />--%>
                                <asp:Image ID="logoImage" runat="server" Style="float: left;" />
                            </a>
                        </h1>
                    </div>
                    <nav class="font_tradegothic_bold">&nbsp;</nav>
                </div>
                <div id="vertical_header" class="cf">
                    <div class="wrapper">
                        <h2 id="heading_blue" class="font_tradegothic_bold">Login To Upload Important Notice
                        </h2>
                    </div>
                </div>
            </header>

            <div class="article_content_sm article_content">
                <div class="wrapper ">
                    <div id="article_desc" class="cf">

                        <div class="row">
                                <asp:Label runat="server" ID="lblMessage" ForeColor="red" Visible="false" Text="Invalid User Name or Password"></asp:Label>
                            </div>
                        <div class="row">
                            <div class="left-col">User Name:</div>
                            <div class="right-col">
                                <asp:TextBox ValidationGroup="vgLogin" runat="server" ID="txtUserName" CssClass="txt-width-other"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="left-col">Password:</div>
                            <div class="right-col">
                                <asp:TextBox ValidationGroup="vgLogin" TextMode="Password" runat="server" ID="txtPassword"
                                    CssClass="txt-width-other"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="left-col">&nbsp;</div>
                            <div class="right-col">
                                <asp:Button ValidationGroup="vgLogin" Text="Login" CssClass="btn-login" runat="server"
                                    ID="btnLogin" OnClick="btnLogin_Click" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>


        </div>
    </form>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <script src="/Presentation/Includes/js/jquery-ui-1.10.2.custom.min.js"></script>
</body>
</html>
