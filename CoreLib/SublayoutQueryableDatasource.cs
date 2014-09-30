namespace CoreLib
{
    using Sitecore.Data.Items;
    using Sitecore.Diagnostics;
    using Sitecore.Pipelines.GetRenderingDatasource;

    /*
     http://sitecoreblog.blogspot.in/2012/06/datasources-queryable.html
     * If you have a multisite solution and if you want to use the field "Datasource Location" and "Datasource template" on you sublayout to open the datasource selection dialog when you add this sublayout on your page in page edit mode, you are not able to select the folder dynamically. by default sitecore only allow to select a folder like /sitecore/content/MyDatas. The idea of this module is to enable the possibility to select this folder relatively to the current item with an XPath query as you do in the fields for example. After installing this module you will be able to select this folder with a query syntaxt like this one for example: 
     *     query:ancestor-or-self::*[@@templatename = 'Website Root']/Data/Demo  
     */

    public class SublayoutQueryableDatasource
    {
        public void Process(GetRenderingDatasourceArgs args)
        {
            Assert.IsNotNull(args, "args");
            string text = args.RenderingItem["Datasource Location"];
            if (!string.IsNullOrEmpty(text))
            {
                if (text.StartsWith("query:") && !string.IsNullOrEmpty(args.ContextItemPath))
                {
                    Item item = args.ContentDatabase.GetItem(args.ContextItemPath);
                    if (item != null)
                    {
                        text = text.Remove(0, 6);
                        Item item2 = item.Axes.SelectSingleItem(text);
                        if (item2 != null)
                        {
                            args.DatasourceRoots.Add(item2);
                        }
                    }
                }
            }
        }
    }
}
