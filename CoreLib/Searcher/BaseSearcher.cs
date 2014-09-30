using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Sitecore.Search;
using scSearchContrib.Searcher;

namespace CoreLib.Searcher
{
    public abstract class BaseSearcher
    {
        protected QueryOccurance GetCondition(DropDownList list)
        {
            var selectedValue = int.Parse(list.SelectedValue);

            switch (selectedValue)
            {
                case 0:
                    return QueryOccurance.Must;
                case 1:
                    return QueryOccurance.MustNot;
                case 2:
                    return QueryOccurance.Should;
                default:
                    return QueryOccurance.Must;
            }
        }

        public abstract List<SkinnyItem> GetSkinnyItems(string databaseName, string indexName, string language, string templateFilter, bool searchBaseTemplates, string locationFilter, string fullTextQuery);
    }
}
