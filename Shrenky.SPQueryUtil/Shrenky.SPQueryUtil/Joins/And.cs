using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shrenky.SPQueryUtil.Joins
{
    public class And : IFilter
    {
        private List<IFilter> Expressions { get; set; }
        public And(params IFilter[] expressions)
        {
            this.Expressions = new List<IFilter>(expressions);
        }

        public string BuildQuery()
        {
            string query = string.Empty;
            StringBuilder builder = new StringBuilder();
            int childNodeCount = 0;
            foreach (IFilter expression in Expressions)
            {
                if(childNodeCount < 2)
                {
                    childNodeCount = childNodeCount + 1;
                    builder.Append(expression.BuildQuery());
                    query = builder.ToString();
                }
                else
                {
                    query = string.Format(ExpressionStringTemplate.And, builder.ToString());
                    builder.Clear();
                    builder.Append(query);
                    builder.Append(expression.BuildQuery());
                    query = builder.ToString();
                }
            }
            return string.Format(ExpressionStringTemplate.And, query); ;
        }
    }
}
