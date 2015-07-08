using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shrenky.SPQueryUtil.Operators
{
    public class Leq : QueryExpression
    {
        public Leq(string fieldName, string value) : base(fieldName, value) { }

        //<Leq>
        //  <FieldRef Name="DeadLine"></FieldRef>
        //  <Value Type="DateTime"><Today/></Value>
        //</Leq>
        public override string BuildExpression()
        {
            return string.Format(ExpressionStringTemplate.Leq, this.fieldName, this.ValuetypeString, this.value);
        }
    }
}
