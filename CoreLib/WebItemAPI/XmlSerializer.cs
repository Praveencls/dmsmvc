using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Sitecore.ItemWebApi;
using Sitecore.ItemWebApi.Serialization;

namespace CoreLib.WebItemAPI
{
    public class XmlSerializer : ISerializer
    {
        public string SerializedDataMediaType
        {
            get
            {
                return "text/xml";
            }
        }

        public string Serialize(object value)
        {
            return Serialize((Dynamic)value).ToString();
        }

        private XElement Serialize(Dynamic value)
        {
            var element = XElement.Parse("<object/>");

            foreach (var property in value)
            {
                var propertyName = string.Format("_{0}", property.Key);
                propertyName = propertyName.Replace("{", "");
                propertyName = propertyName.Replace("}", "");
                propertyName = propertyName.Replace(" ", "-");

                var child = XElement.Parse(string.Format("<{0}/>", propertyName));
                var array = property.Value as Dynamic[];

                if (array != null)
                {
                    foreach (var item in array)
                    {
                        child.Add(Serialize(item));
                    }
                }
                else if (property.Value is Dynamic)
                {
                    child.Add(Serialize((Dynamic)property.Value));
                }
                else
                {
                    child.Add(property.Value.ToString());
                }

                element.Add(child);
            }

            return element;
        }
    }
}
