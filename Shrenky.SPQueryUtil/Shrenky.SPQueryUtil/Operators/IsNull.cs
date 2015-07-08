using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shrenky.SPQueryUtil.Operators
{
    public class IsNull : QueryExpression
    {
        public IsNull(string fieldName) : base(fieldName, string.Empty) { }

        //<IsNull>
        //  <FieldRef Name="Template"></FieldRef>
        //</IsNull>
        public override string BuildExpression()
        {
            return string.Format(ExpressionStringTemplate.IsNull, this.fieldName);
        }
    }
}
