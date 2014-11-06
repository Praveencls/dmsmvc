using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTCC.Corlib;
using DTCC.Corlib.CustomItems.Folders;
using DTCC.Corlib.CustomItems.Shared;
using DTCC.Corlib.CustomItems.Shared.PDFs;
using DTCC.Corlib.Extensions;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Publishing;
using Sitecore.Security.Accounts;
using Sitecore.SecurityModel;
using Sitecore.Sites;

namespace DTCC.Web.sitecore.admin {
    public partial class importpdf : System.Web.UI.Page {
        // Get master database
        private Database _masterDB = null;
        private Database MASTERDB {
            get {
                if (_masterDB == null)
                    _masterDB = Sitecore.Configuration.Factory.GetDatabase("master");
                return _masterDB;
            }
        }

        // Get web database
        private Database _webDB = null;
        private Database WEBDB {
            get {
                if (_webDB == null)
                    _webDB = Sitecore.Configuration.Factory.GetDatabase("web");
                return _webDB;
            }
        }

		private Database[] _publishingTargets = null;
		private Database[] PublishingTargets {
			get {
				if (_publishingTargets == null) {
					_publishingTargets = new Database[] { WEBDB };
				}

				return _publishingTargets;
			}
		}

		private TemplateItem _mediaFolderTemplateItem = null;
		private TemplateItem MediaFolderTemplateItem {
			get {
				if (_mediaFolderTemplateItem == null) {
					_mediaFolderTemplateItem = MASTERDB.GetTemplate(new ID("{FE5DD826-48C6-436D-B87A-7C4210C7413B}"));
				}

				return _mediaFolderTemplateItem;
			}
		}

        protected void Page_Load(object sender, EventArgs e) {
            User user = Sitecore.Context.User;
            if (!user.IsAuthenticated) {
                SiteContext site = Sitecore.Context.Site;
                if (site != null) {
                    base.Response.Redirect(string.Format("{0}?returnUrl={1}", "/tools/login.aspx", HttpUtility.UrlEncode(base.Request.Url.PathAndQuery)));
                }
            }
            else {
                if (!IsPostBack) {
                    if (MASTERDB != null) {

                        FillDropDownLists();
                        // Show import pdf
                        pnlImportPDF.Visible = true;
                        // Hide Thanks message
                        pnlThanks.Visible = false;
                    }

                }
                LoadData();
            }

        }

        /// <summary>
        /// Load data from sitecore
        /// </summary>
        private void LoadData() {

            SiteItem objSite = SiteItem.GetSiteRoot(MASTERDB);
            if (objSite != null) {
                // sitelogo.Item = objSite;
                logoImage.ImageUrl = objSite.SiteLogo.MediaUrl.Replace("/sitecore/admin", "");
                GlobalsItem objGlobals = objSite.GetGlobalsFolder();
                if (objGlobals != null) {
                    ImportPDFSettingsItem objImportPDFSettings = objGlobals.GetImportPDFSettingsItem();
                    if (objImportPDFSettings != null) {
                        frTitle.Item = frDescription.Item = objImportPDFSettings;
                        frThankyouMessage.Item = objImportPDFSettings;
                    }
                }
            }

        }
        /// <summary>
        /// Fill DDLs
        /// </summary>
        private void FillDropDownLists() {

            // Get Site item
            SiteItem objSite = SiteItem.GetSiteRoot(MASTERDB);
            if (objSite != null) {

                // Gets Subsidiary from global
                var subsidiary = SiteItem.GetSubsidiary(objSite);
                ddlSubsidiary.Items.Add(new ListItem(SiteItem.GetDictionaryItemValue(objSite, Constants.FILTER_BY_SUBSIDIARY), ""));

                if (subsidiary.Any()) {
                    foreach (TagItem tagItem in subsidiary) {
                        if (!string.IsNullOrEmpty(tagItem.Name)) {
                            ddlSubsidiary.Items.Add(new ListItem(tagItem.FullName.Raw, tagItem.InnerItem.ID.ToString()));
                        }
                    }
                }
            }
        }

		List<Item> itemsToPublish = new List<Item>();

        protected void btnSubmit_Click(object sender, EventArgs e) {
			itemsToPublish = new List<Item>();

            Page.Validate("vgImportPDF");
            if (Page.IsValid) {
                if (fuPDFUpload.HasFile && fuPDFUpload.PostedFile.ContentType.ToString().Equals("application/pdf")) {

                    try {
                        string filename = Path.GetFileName(fuPDFUpload.FileName);
                        string path = Sitecore.Configuration.Settings.GetSetting("MediaExportPath");
						string fullPath = path + "/" + filename;
                        fuPDFUpload.SaveAs(fullPath);
						Item mediaItem = CreateMediaItem(fullPath, filename);
						if (mediaItem != null) {
                            CreatePDFItem(mediaItem);
							// Show import pdf
                            pnlImportPDF.Visible = false;
							// Hide Thanks message
                            pnlThanks.Visible = true;
						}

						IEnumerable<string> pathOfItemsToBePublished = itemsToPublish.Select(i => i.Paths.Path);

						using (new SecurityDisabler()) {
							foreach (Item i in itemsToPublish) {
								PublishManager.PublishItem(i, PublishingTargets, WEBDB.Languages, false, true);
							}
						}
                        try {
                            if (File.Exists(fullPath)) {
                                File.Delete(fullPath);
                            }
                        }
                        catch { }
                    }
                    catch (Exception ex) {
                        Response.Write(ex.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Create pdf items in globals & fill fields of created item
        /// </summary>
        /// <param name="mediaItem"></param>
		private void CreatePDFItem(Item mediaItem) {
			if (MASTERDB != null) {
				// Get Globals folder
				SiteItem objSite = SiteItem.GetSiteRoot(MASTERDB);
				if (objSite != null) {
					PDFRootItem objPDFRoot = objSite.GetGlobalsFolder().GetPDFRootItem();
					TemplateItem template = MASTERDB.GetTemplate(ImportantNoticeItem.TemplateId);
					if (objPDFRoot != null && template != null) {
						// Sanitize Sitecore item name
						string sanitizedName = ItemUtil.ProposeValidItemName(tbTitle.Text);
						string strDate = tbDate.Text.Replace("/", "");
						DateTime date = DateTime.ParseExact(strDate, "MMddyyyy", CultureInfo.InvariantCulture);
						if (date != null && !string.IsNullOrEmpty(sanitizedName)) {
                            using (new Sitecore.SecurityModel.SecurityDisabler()) {
								// Create item
								ImportantNoticeItem createdPDFItem = objPDFRoot.InnerItem.Add(sanitizedName, template);
								if (createdPDFItem != null) {
									//Begin editing
									createdPDFItem.InnerItem.Editing.BeginEdit();

									// Date
									createdPDFItem.InnerItem.Fields["Date"].Value = date.ToString("yyyyMMddTHHmmss", CultureInfo.InvariantCulture);
									// Title
									createdPDFItem.InnerItem.Fields["Title"].Value = sanitizedName;
									// Subject
									createdPDFItem.InnerItem.Fields["Subject"].Value = tbSubject.Text;
									
									// Subsidiary Tag + Category tag
									string tags = ddlSubsidiary.SelectedValue;

									foreach (ListItem li in lbCategories.Items) {
										if (li.Selected) {
											tags += "|" + li.Value;
										}
									}

									createdPDFItem.Tags.GetField("Tag").Value = tags;
									
									// Document ID
									createdPDFItem.InnerItem.Fields["Document ID"].Value = tbNoticeNumber.Text;
									// Flag
									createdPDFItem.InnerItem.Fields["Flag"].Value = cbFlag.Checked ? "1" : "";
									// PDF File
									string strPDFFile = String.Format("<file mediaid=\"{0}\" src=\"~/media/{1}.ashx\" />", mediaItem.ID.ToString(), mediaItem.ID.ToShortID().ToString());
									createdPDFItem.InnerItem.Fields["PDF File"].Value = strPDFFile;
									//Close the editing state
									createdPDFItem.InnerItem.Editing.EndEdit();

									itemsToPublish.Add(createdPDFItem.InnerItem.Parent.Parent.Parent);
									itemsToPublish.Add(createdPDFItem.InnerItem.Parent.Parent);
									itemsToPublish.Add(createdPDFItem.InnerItem.Parent);
									itemsToPublish.Add(createdPDFItem);
								}
							}
						}
					}
				}
			}
		}

        private void PublishItem(Item item, Database database) {
			using (new SecurityDisabler()) {
				PublishManager.PublishItem(item, PublishingTargets, WEBDB.Languages, false, true);
			}
        }

        /// <summary>
        /// This method will upload pdf file to media library
        /// </summary>
        /// <param name="fullPath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private Item CreateMediaItem(string fullPath, string fileName) {
            // Create the options
            Sitecore.Resources.Media.MediaCreatorOptions options = new Sitecore.Resources.Media.MediaCreatorOptions();
			// Store the file in the database, not as a file
            options.FileBased = false;
            options.Language = Sitecore.Globalization.Language.Parse(Sitecore.Configuration.Settings.DefaultLanguage);
			// Remove file extension from item name
            options.IncludeExtensionInItemName = false;
			// Overwrite any existing file with the same name
            options.KeepExisting = false;
			// Do not make a versioned template
			options.Versioned = false;
			// Set the database
            options.Database = Sitecore.Configuration.Factory.GetDatabase("master");
			Item mediaItem = null;

			// set the path
			string sitecorePath = Constants.SITECORE_PATH_TO_PDF_UPLOAD;

			Item pdfFolder = MASTERDB.GetItem(sitecorePath);

			if (pdfFolder != null) {
				DateTime dt = DateTime.Parse(tbDate.Text);

				Item yearFolder = pdfFolder.GetChildren().FirstOrDefault(i => i.Name == dt.Year.ToString());

				if (yearFolder == null) {
					using (new SecurityDisabler()) {
						yearFolder = pdfFolder.Add(dt.Year.ToString(), MediaFolderTemplateItem);
						itemsToPublish.Add(yearFolder);
					}
				}

				Item monthFolder = null;

				if (yearFolder != null) {
					monthFolder = yearFolder.GetChildren().FirstOrDefault(i => i.Name == dt.Month.ToString());

					if (monthFolder == null) {
						using (new SecurityDisabler()) {
							monthFolder = yearFolder.Add(dt.Month.ToString(), MediaFolderTemplateItem);
							itemsToPublish.Add(monthFolder);
						}
					}
				}

				Item dayFolder = null;

				if (monthFolder != null) {
					dayFolder = monthFolder.GetChildren().FirstOrDefault(i => i.Name == dt.Day.ToString());

					if (dayFolder == null) {
						using (new SecurityDisabler()) {
							dayFolder = monthFolder.Add(dt.Day.ToString(), MediaFolderTemplateItem);
							itemsToPublish.Add(dayFolder);
						}
					}
				}

				if (dayFolder != null) {
					options.Destination = string.Format("{0}/{1}/{2}/{3}/{4}", sitecorePath, yearFolder.Name, monthFolder.Name, dayFolder.Name, fileName.Replace(".pdf", ""));
				}
				else {
					options.Destination = string.Format("{0}/{1}", sitecorePath, fileName.Replace(".pdf", ""));
				}

				using (new Sitecore.SecurityModel.SecurityDisabler()) {
					mediaItem = Sitecore.Resources.Media.MediaManager.Creator.CreateFromFile(@fullPath, options);
					itemsToPublish.Add(mediaItem);
				}
			}

            return mediaItem;
        }

        protected void btnLogout_Click(object sender, EventArgs e) {
            System.Web.Security.FormsAuthentication.SignOut();
            Session.Abandon();
            base.Response.Redirect(string.Format("{0}?returnUrl={1}", "/tools/login.aspx", HttpUtility.UrlEncode(base.Request.Url.PathAndQuery)));
        }


        protected void ddlSubsidiary_SelectedIndexChanged(object sender, EventArgs e) {
            if (!ddlSubsidiary.SelectedItem.Value.Trim().IsNullOrEmpty()) {
				if (lbCategories.Items.Count > 0) {
					lbCategories.Items.Clear();
				}

                LoadCategoryTags(ddlSubsidiary.SelectedItem.Value);
				lbCategories.Enabled = true;
            }
            else {
				lbCategories.Enabled = false;
            }
        }

        /// <summary>
        /// Function to load category tag
        /// </summary>
        /// <param name="subsidiaryTag">Subisdiary Tag Id Value</param>
        private void LoadCategoryTags(string subsidiaryTagId) {
            // Gets Category from global
            Item itm = Sitecore.Context.Database.GetItem(subsidiaryTagId);
            var categories = itm.GetChildren().FilterByContextLanguageVersion().Select(t => new CategoryTagItem(t)).ToList();
            if (categories != null && categories.Any()) {
                foreach (CategoryTagItem tagItem in categories) {
                    if (!string.IsNullOrEmpty(tagItem.FullName.Raw)) {
						lbCategories.Items.Add(new ListItem(tagItem.FullName.Raw, tagItem.InnerItem.ID.ToString()));
                    }
                }
            }
        }
    }

}