using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shrenky.SPQueryUtil
{
    public class SPFilter : IFilter
    {
        private SPList QueryOnList { get; set; }
        private List<IFilter> Filters { get; set; }

        public string QueryString
        {
            get 
            {
                return BuildQuery();
            }
        }
        public SPFilter(SPList list)
        {
            this.QueryOnList = list;
        }
        public void GetItems(params IFilter[] fitlers)
        {
            this.Filters = new List<IFilter>(fitlers);
        }

        public SPListItemCollection GetItems() 
        {
            SPQuery query = new SPQuery();
            query.Query = QueryString;
            return QueryOnList.GetItems(query);
        }


        public string BuildQuery()
        {
            string query = string.Empty;
            if (Filters != null)
            {
                StringBuilder builder = new StringBuilder();
                foreach (IFilter filter in this.Filters)
                {
                    builder.Append(filter.BuildQuery());
                }
                query =  string.Format(ExpressionStringTemplate.Where, builder.ToString());
                query = QueryHelper.CheckAndRetunQueryWithFieldType(QueryOnList, query);
            }

            return query;
        }
    }
}
