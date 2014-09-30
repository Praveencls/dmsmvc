using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using scSearchContrib.Searcher;
using scSearchContrib.Searcher.Parameters;
using Sitecore.Data.Items;

namespace CoreLib.Searcher
{
    public static class SitecoreSearcher 
    {
        public static List<SkinnyItem> GetSkinnyItems(string indexName, string templateFilter, bool searchBaseTemplates, string locationFilter, string fullTextQuery)
        {
            var searchParam = new SearchParam
            {
                Database = Sitecore.Context.Database.Name,
                Language = Sitecore.Context.Language.Name,
                TemplateIds = templateFilter,
                LocationIds = locationFilter,
                FullTextQuery = fullTextQuery,
                SearchBaseTemplates = searchBaseTemplates
                //Condition = Sitecore.Search.QueryOccurance.Should,
                //RelatedIds
                
            };

            using (var runner = new QueryRunner(indexName))
            {
                return runner.GetItems(searchParam);
            }
        }

        public static IEnumerable<Item> GetItems(string indexName, string templateFilter, bool searchBaseTemplates, string locationFilter, string fullTextQuery)
        {
            IEnumerable<SkinnyItem> items = GetSkinnyItems(indexName, templateFilter, searchBaseTemplates, locationFilter, fullTextQuery);
            return items.Select(item => Sitecore.Context.Database.GetItem(item.ItemID));
        }

        public static IEnumerable<SkinnyItem> GetItems(string indexName)
        {
            return GetSkinnyItems(indexName, null, false, null, null);
            //return items.Select(item => Sitecore.Context.Database.GetItem(item.ItemID));
        }
    }
}
