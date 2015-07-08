using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shrenky.SPQueryUtil.Operators
{
    public class Lt : QueryExpression
    {
        public Lt(string fieldName, string value) : base(fieldName, value) { }

        //<Lt>
        //  <FieldRef Name="DeadLine"></FieldRef>
        //  <Value Type="DateTime"><Today/></Value>
        //</Lt>
        public override string BuildExpression()
        {
            return string.Format(ExpressionStringTemplate.Lt, this.fieldName, this.ValuetypeString, this.value);
        }
    }
}
