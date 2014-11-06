using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTCC.Corlib.CustomItems.Folders;
using DTCC.Corlib.CustomItems.Shared;
using Sitecore.Data;
using Sitecore.Security.Authentication;


namespace DTCC.Web.Tools {
    public partial class login : System.Web.UI.Page {

        // Get web database
        private Database _webDB = null;
        private Database WEBDB {
            get {
                if (_webDB == null)
                    _webDB = Sitecore.Configuration.Factory.GetDatabase("master");
                return _webDB;
            }
        }


        protected void Page_Load(object sender, EventArgs e) {
            LoadData();
        }

        protected void btnLogin_Click(object sender, EventArgs e) {
            if (Page.IsValid) {
                string urlRef = String.Empty;
                if (Request.UrlReferrer != null) {
                    urlRef = Request.UrlReferrer.AbsolutePath;
                }

                //get user
                string userName = "sitecore\\" + txtUserName.Text;
                var user = Sitecore.Security.Accounts.User.FromName(userName, true);
                bool result = AuthenticationManager.Login(userName, txtPassword.Text);
                if (result && user.Domain.Name.ToLower() == "sitecore") {
                    Response.Redirect("/tools/importpdf.aspx");
                }
                else {
                    lblMessage.Visible = true;
                }
            }


        }

        /// <summary>
        /// Load data from sitecore
        /// </summary>
        private void LoadData() {

            SiteItem objSite = SiteItem.GetSiteRoot(WEBDB);
            if (objSite != null) {
                // sitelogo.Item = objSite;
                logoImage.ImageUrl = objSite.SiteLogo.MediaUrl.Replace("/sitecore/admin", "");
                GlobalsItem objGlobals = objSite.GetGlobalsFolder();
                if (objGlobals != null) {
                    ImportPDFSettingsItem objImportPDFSettings = objGlobals.GetImportPDFSettingsItem();
                    
                }
            }

        }
    }
}