using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
namespace mvc5.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRio" in both code and config file together.
    [ServiceContract]
    public interface IRio
    {
        [OperationContract]
        [WebGet(UriTemplate = "GetItemById?id={id}&allFields={allFields}")]
        string EchoWithGet(string id, string allFields);

        [OperationContract]
        [WebGet(UriTemplate = "xml?s={s}")]
        string EchoWithGet1(string s);

        [OperationContract]
        [WebGet(UriTemplate = "xml1?a={a}&b={b}")]
        CmsItem EchoWithGet2(string a, string b);

        [OperationContract]
        [WebInvoke]
        string EchoWithPost(string s);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json)]
        List<CmsItem> GetChildItemsByPath(string url, bool allFields);

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json)]
        string AddItem(CmsItem itemData);


        CmsItem GetItemById(string id, string allFields);

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json)]
        string GetItemIdByPath(string path);

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json)]
        string UpdateItem(CmsItem cmsItem);

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json)]
        string GetFieldByItemId(string id, string fieldName);
    }

    [DataContract]
    public class CmsItem
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Path { get; set; }
        [DataMember]
        public string TemplateName { get; set; }
        [DataMember]
        public string TemplateId { get; set; }
        [DataMember]
        public string ParentId { get; set; }

        [DataMember]
        public List<CmsField> Fields = new List<CmsField>();

        public CmsItem()
        {

        }

        public CmsItem(Item item, bool includeStandard)
        {
            Update(item);
            item.Fields.ReadAll();
            foreach (Field field in item.Fields)
            {
                if (!string.IsNullOrEmpty(field.Name))
                {
                    if (!field.Name.StartsWith("__") || includeStandard)
                        Fields.Add(new CmsField(field));
                }
            }
        }

        public void Update(Item item)
        {
            Name = item.Name;
            Id = item.ID.ToString();
            Title = item.DisplayName;
            Path = item.Paths.FullPath;
            TemplateName = item.TemplateName;
            TemplateId = item.TemplateID.ToString();
            ParentId = item.ParentID.ToString();
        }

    }

    [DataContract]
    public class CmsField
    {
        public CmsField()
        {
        }

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Data { get; set; }

        public CmsField(Field field)
        {
            Name = field.Name;
            Type = !string.IsNullOrEmpty(field.Type) ? field.Type : "Unknown Type";
            Data = field.GetValue(true);
        }
    }
}