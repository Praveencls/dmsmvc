using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace mvc5.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Rio" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Rio : IRio
    {
        public string EchoWithGet(string id, string allFields)
        {
            return "You said " + id + " secondary: " + allFields;
        }

        public string EchoWithGet1(string s)
        {
            return "You said " + s;
        }

        public CmsItem EchoWithGet2(string a, string b)
        {
            // return "You said " + a + " and x: " + b;
            var item = _database.GetItem(new ID(a));
            if (item != null)
            {
                bool _allFields = string.IsNullOrEmpty(b) && b == "true" ? true : false;
                var cmsItem = new CmsItem(item, _allFields);
                return cmsItem;
            }

            return null;
        }

        public string EchoWithPost(string c)
        {
            return "You said " + c;
        }

        private readonly Database _database =
           Sitecore.Configuration.Factory.GetDatabase("master");

        public List<CmsItem> GetChildItemsByPath(string url, bool allFields)
        {
            var childlist = new List<CmsItem>();
            var item = _database.GetItem(url);
            if (item != null)
            {
                foreach (Item childItem in item.GetChildren())
                {
                    var cmsItem = new CmsItem(childItem, allFields);
                    childlist.Add(cmsItem);
                }

                if (childlist.Count > 0)
                    return childlist;
            }
            return null;
        }

        public string AddItem(CmsItem itemData)
        {
            if (itemData != null)
            {
                Item item = null;
                if (IsInPermittedHostList())
                {
                    Item parentItem = _database.GetItem(new ID(itemData.ParentId));
                    TemplateItem template = _database.GetTemplate(itemData.TemplateName);

                    if (parentItem != null && template != null)
                    {
                        using (new Sitecore.SecurityModel.SecurityDisabler())
                        {
                            parentItem.Editing.BeginEdit();
                            try
                            {
                                item = parentItem.Add(itemData.Name, template);
                            }
                            finally
                            {
                                parentItem.Editing.EndEdit();
                            }
                            UpdateFields(ref item, itemData);
                        }
                    }
                }
                return item != null ? item.ID.ToString() : Guid.Empty.ToString();
            }
            return Guid.Empty.ToString();
        }

        public CmsItem GetItemById(string id, string allFields)
        {
            var item = _database.GetItem(new ID(id));
            if (item != null)
            {
                bool _allFields = string.IsNullOrEmpty(allFields) && allFields == "true" ? true : false;
                var cmsItem = new CmsItem(item, _allFields);
                return cmsItem;
            }

            return null;
        }

        public string GetItemIdByPath(string path)
        {
            var item = _database.GetItem(path);
            return item != null ? item.ID.ToString() : Guid.Empty.ToString();
        }

        public string UpdateItem(CmsItem cmsItem)
        {

            var item = _database.GetItem(new ID(cmsItem.Id));
            if (item != null)
            {
                UpdateFields(ref item, cmsItem);
            }

            return item != null ? item.ID.ToString() : Guid.Empty.ToString();
        }

        public string GetFieldByItemId(string id, string fieldName)
        {
            Item item = null;
            if (IsInPermittedHostList())
            {
                item = _database.GetItem(new ID(id));
            }
            if (item != null)
            {
                var fieldData = item[fieldName];
                return fieldData;
            }
            return "";
        }

        private static bool IsInPermittedHostList()
        {
            bool statusCode = false;

            if (System.Web.Configuration.WebConfigurationManager.AppSettings.Count > 0)
            {
                string hosts = System.Web.Configuration.WebConfigurationManager
                .AppSettings.Get("RioPermittedHosts");
                var hostlist = hosts.Split(new[] { ';' });
                if (hostlist.Length > 0)
                {
                    statusCode =
                    hostlist.Any(host =>
                    OperationContext.Current.IncomingMessageProperties.Via.Host == host);
                }
            }
            if (statusCode == false)
            {
                WebOperationContext ctx = WebOperationContext.Current;
                if (ctx != null)
                    ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            return statusCode;
        }

        private static void UpdateFields(ref Item item, CmsItem cmsItem)
        {
            foreach (var field in cmsItem.Fields)
            {
                AddFieldData(ref item, field);
            }
        }

        private static void AddFieldData(ref Item item, CmsField field)
        {
            if (item.Fields[field.Name] != null)
            {
                item.Editing.BeginEdit();

                if (item.Fields[field.Name].Type != null
                    && item.Fields[field.Name].Type == "General Link")
                {
                    LinkField linkfield = item.Fields[field.Name];
                    linkfield.Url = field.Data;
                }
                else
                {
                    item.Fields[field.Name].Value = field.Data;
                }

                item.Editing.EndEdit();
            }
        }


    }
}