using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shrenky.SPQueryUtil.Operators
{
    public class IsNotNull : QueryExpression
    {
        public IsNotNull(string fieldName) : base(fieldName, string.Empty) { }

        //<IsNotNull>
        //  <FieldRef Name="Template"></FieldRef>
        //</IsNotNull>
        public override string BuildExpression()
        {
            return string.Format(ExpressionStringTemplate.IsNotNull, this.fieldName);
        }
    }
}
