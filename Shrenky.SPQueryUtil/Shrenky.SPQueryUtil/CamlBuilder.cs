using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shrenky.SPQueryUtil
{
    public class CamlBuilder
    {
        public static string BuildCaml(SPList list, params IFilter[] Filters)
        {
            string query = string.Empty;
            if (Filters != null && Filters.Length > 0)
            {
                StringBuilder builder = new StringBuilder();
                foreach (IFilter filter in Filters)
                {
                    builder.Append(filter.BuildQuery());
                }
                query = string.Format(ExpressionStringTemplate.Where, builder.ToString());
                query = QueryHelper.CheckAndRetunQueryWithFieldType(list, query);
            }

            return query;
        }
    }
}
