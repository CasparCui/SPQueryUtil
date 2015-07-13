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
        #region fields
        
        private string query;
        private SPList QueryOnList { get; set; }
        private SPView QueryOnView { get; set; }
        private List<IFilter> Filters { get; set; }

        #endregion

        #region Properties
        
        public string QueryString
        {
            get 
            {
                //if (string.IsNullOrEmpty(this.query))
                {
                    this.query = this.BuildQuery();
                }

                return this.query;
            }
        }

        public uint RowLimit { get; set; }

        /*
            "Scope=\"Recursive\"";
         */
        public string ViewAttributes { get; set; }

        /*
         string.Concat(
            "<FieldRef Name='AssignedTo' />",
            "<FieldRef Name='LinkTitle' />",
            "<FieldRef Name='DueDate' />",
            "<FieldRef Name='Priority' />");*/
        public string ViewFields { get; set; }

        public bool ViewFieldsOnly { get; set; }

        #endregion

        #region Constructors

        public SPFilter(SPList list)
        {
            this.QueryOnList = list;
        }

        public SPFilter(SPView view)
        {
            this.QueryOnView = view;
            this.QueryOnList = view.ParentList;
        }

        #endregion

        #region public methods

        public SPListItemCollection GetItems(params IFilter[] filters)
        {
            this.Filters = new List<IFilter>(filters);
            return GetItems();
        }

        #endregion

        #region private methods
        
        private SPListItemCollection GetItems() 
        {
            SPQuery query = this.QueryOnView == null ? new SPQuery() : new SPQuery(this.QueryOnView);
            query.Query = QueryString;
            query.RowLimit = this.RowLimit;
            query.ViewAttributes = this.ViewAttributes;
            query.ViewFields = this.ViewFields;
            query.ViewFieldsOnly = this.ViewFieldsOnly;
            return QueryOnList.GetItems(query);
        }

        public string BuildQuery(params IFilter[] filters)
        {
            this.Filters = new List<IFilter>(filters);
            return BuildQuery();
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

        #endregion
    }
}
