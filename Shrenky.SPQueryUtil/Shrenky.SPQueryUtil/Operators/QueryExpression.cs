using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shrenky.SPQueryUtil.Operators
{
    public abstract class QueryExpression : IFilter
    {
        #region fields

        protected string fieldName;
        protected string value;

        #endregion

        #region constructor

        public QueryExpression(string fieldName, string value)
        {
            this.fieldName = fieldName;
            this.value = value;
        }

        #endregion

        #region properties

        protected string ValuetypeString
        {
            get
            {
                return "TypePlaceHolder";
            }
        }

        #endregion


        public string BuildQuery()
        {
            return this.BuildExpression();
        }

        public abstract string BuildExpression();
    }
}
