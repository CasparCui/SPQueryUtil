using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Shrenky.SPQueryUtil
{
    public static class QueryHelper
    {
        public static string CheckAndRetunQueryWithFieldType(SPList list, string oldQuery)
        {
            string newQuery = string.Empty;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(oldQuery);

            return newQuery;
        }

    }
}
