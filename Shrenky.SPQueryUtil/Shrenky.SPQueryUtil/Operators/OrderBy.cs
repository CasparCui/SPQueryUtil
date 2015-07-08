using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shrenky.SPQueryUtil.Operators
{
    public class OrderBy : QueryExpression
    {
        public OrderBy(string fieldName) : base(fieldName, string.Empty) { }

        //<OrderBy>
        //  <FieldRef Name="Status"></FieldRef>
        //</OrderBy>
        public override string BuildExpression()
        {
            return string.Format(ExpressionStringTemplate.OrderBy, this.fieldName);
        }
    }
}
