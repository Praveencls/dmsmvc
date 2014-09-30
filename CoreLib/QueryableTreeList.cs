
namespace CoreLib
{
    using Sitecore.Data.Items;
    using Sitecore.Shell.Applications.ContentEditor;
    using Sitecore;

    //http://www.cognifide.com/blogs/sitecore/reduce-multisite-chaos-with-sitecore-queries/

    public class QueryableTreeList : TreeList
    {
        public new string Source
        {
            get { return base.Source; }
            set
            {
                string dataSource = StringUtil
                    .ExtractParameter("DataSource", value).Trim();
                if (dataSource.StartsWith("query:"))
                {
                    base.Source = value.Replace(dataSource, ResolveQuery(dataSource));
                }
                else
                {
                    base.Source = value.StartsWith("query:") ? ResolveQuery(value) : value;
                }
            }
        }

        private string ResolveQuery(string query)
        {
            query = query.Substring("query:".Length);
            Item contextItem = Sitecore.Context.ContentDatabase.Items[ItemID];
            Item queryItem = contextItem.Axes.SelectSingleItem(query);
            if (queryItem != null)
            {
                return queryItem.Paths.FullPath;
            }
            return string.Empty;
        }
    }
}
