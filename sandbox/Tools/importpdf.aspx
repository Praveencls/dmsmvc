<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="importpdf.aspx.cs" Inherits="DTCC.Web.sitecore.admin.importpdf" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="/Presentation/Includes/css/style.css" />
    <link rel="stylesheet" type="text/css" href="/Presentation/Includes/css/custom-style.css" />
    <link rel="stylesheet" type="text/css" href="/Presentation/Includes/css/jquery-ui/jquery-ui-1.10.2.custom.min.css" />
    <style type="text/css">
        .ui-datepicker, .ui-datepicker table tr td
        {
            font-size: 10px;
            line-height: 14px;
        }

        .datepicker
        {
            float: left;
        }

            .datepicker + img
            {
                float: left;
                margin-left: 5px;
            }
        #article_desc
        {
            min-width:900px;
        }

        #cbFlag, #cbHoliday
        {
            float: left;
            margin-right:10px;
        }

        .article_content_sm #article_desc div span.cbText,.article_content_sm #article_desc div span.info-text
        {
            color: #898989;
            float: left;
            font-size: 14px;
            font-weight: normal;
            line-height: 11px;
            margin: 4px 0 0;
            width: 200px;
        }

    	.helper-message {
    		font-weight: normal;
    		display: block;
    		width: 130px;
    		font-size: 12px;
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
                                <asp:image id="logoImage" runat="server" style="float: left;" />
                            </a>
                        </h1>
                    </div>
                    <nav class="font_tradegothic_bold">&nbsp;</nav>
                </div>
                <div id="vertical_header" class="cf">
                    <div class="wrapper">
                        <h2 id="heading_blue" class="font_tradegothic_bold">
                            <sc:fieldrenderer id="frTitle" runat="server" fieldname="Title" />
                        </h2>
                    </div>
                </div>
            </header>
            <div class="article_content_sm article_content">
                <div class="left-col" style="float:right;">
                                <asp:Button ValidationGroup="vgLogin" Text="Logout" CssClass="btn-login" runat="server"
                                    ID="btnLogout" OnClick="btnLogout_Click" />
                            </div>
                <div class="wrapper ">
                    <div id="article_desc" class="cf">
                        <asp:panel id="pnlImportPDF" cssclass="page-container" runat="server">
                            <div class="body-copy">
                                <sc:FieldRenderer ID="frDescription" runat="server" FieldName="Description" />
                            </div>
                            <div class="form-container">
                                <div class="row">
                                    <div class="left-col">Issuing Subsidiary:</div>
                                    <div class="right-col">
                                        <asp:DropDownList ID="ddlSubsidiary" AutoPostBack="true" OnSelectedIndexChanged="ddlSubsidiary_SelectedIndexChanged" CssClass="drop_list" runat="server" />
                                        <asp:RequiredFieldValidator ID="rfvSubsidiary" CssClass="rfvErrorMessage" ControlToValidate="ddlSubsidiary" Display="Dynamic" ValidationGroup="vgImportPDF" ErrorMessage="*" runat="server" ></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="left-col">Notice Number:</div>
                                    <div class="right-col">
                                        <asp:TextBox ID="tbNoticeNumber" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvNoticenumber" CssClass="rfvErrorMessage"  ControlToValidate="tbNoticeNumber" Display="Dynamic" ValidationGroup="vgImportPDF" ErrorMessage="*" runat="server"></asp:RequiredFieldValidator>
                                        <div class="info-text">Example Format: B#1234</div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="left-col">Title:</div>
                                    <div class="right-col">
                                        <asp:TextBox ID="tbTitle" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvTitle" ControlToValidate="tbTitle" CssClass="rfvErrorMessage"  Display="Dynamic" ValidationGroup="vgImportPDF" ErrorMessage="*" runat="server"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

								<div class="row">
                                    <div class="left-col">Subject:</div>
                                    <div class="right-col">
                                        <asp:TextBox ID="tbSubject" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvSubject" ControlToValidate="tbSubject" CssClass="rfvErrorMessage"  Display="Dynamic" ValidationGroup="vgImportPDF" ErrorMessage="*" runat="server"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="left-col">
										Category:
										<br />
										<em class="helper-message">Hold the CTRL key to select or to de-select a Category.</em>
                                    </div>
                                    <div class="right-col">
                                        <asp:ListBox ID="lbCategories" SelectionMode="Multiple" Enabled="false" runat="server"></asp:ListBox>
										<asp:RequiredFieldValidator ID="rfvCategory" ControlToValidate="lbCategories" CssClass="rfvErrorMessage"  Display="Dynamic" ValidationGroup="vgImportPDF" ErrorMessage="*" runat="server" InitialValue=""></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="left-col">Date:</div>
                                    <div class="right-col">
                                        <asp:TextBox ID="tbDate" runat="server" placeholder="07/14/2007" CssClass="datepicker"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvDate" ControlToValidate="tbDate" Display="Dynamic" CssClass="rfvErrorMessage"  ValidationGroup="vgImportPDF" ErrorMessage="*" runat="server"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="left-col">Upload PDF:</div>
                                    <div class="right-col">
                                        <asp:FileUpload ID="fuPDFUpload" runat="server" accept="application/pdf" />
                                        <asp:RequiredFieldValidator ID="rfvPDFUpload" ControlToValidate="fuPDFUpload" Display="Dynamic" CssClass="rfvErrorMessage"  ValidationGroup="vgImportPDF" ErrorMessage="*" runat="server"></asp:RequiredFieldValidator>
                                        <div class="info-text">
                                            Example Format: GOV123.13.pdf
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="left-col">&nbsp;</div>
                                    <div class="right-col cb-col">
                                        <asp:CheckBox ID="cbFlag" runat="server" />
                                        <span class="cbText">Flag this important notice.</span><span class="info-text">*Only for revised notices</span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="left-col">&nbsp;</div>
                                    <div class="right-col">
                                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" ValidationGroup="vgImportPDF" />
                                    </div>
                                </div>
                            </div>
                        </asp:panel>
                        <asp:panel id="pnlThanks" runat="server" csscass="thanks-container" visible="false">
                           <sc:FieldRenderer ID="frThankyouMessage" runat="server" FieldName="Thank You Message" />
                        </asp:panel>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hfSaveAction" runat="server" Value="" />
    </form>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <script src="/Presentation/Includes/js/jquery-ui-1.10.2.custom.min.js"></script>
    <%--<script src="/Presentation/Includes/js/jquery.selectbox-0.2.js"></script>
    <script src="/Presentation/Includes/js/script.js"></script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            //datepicker
            $(".datepicker").datepicker({
                showOn: "button",
                buttonImage: "/Presentation/includes/images/calendar-icon.png",
                buttonImageOnly: true
            });
            //Add hypen after each 4 charactor
            $('#tbNoticeNumber').keyup(function () {
                var value = $(this).val().split("-").join(""); // remove hyphens
                value = value.match(new RegExp('.{1,4}', 'g')).join("-");
                $(this).val(value);
            });
        });

    </script>
</body>
</html>
