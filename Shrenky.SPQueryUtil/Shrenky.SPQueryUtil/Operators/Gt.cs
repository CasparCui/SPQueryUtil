using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shrenky.SPQueryUtil.Operators
{
    public class Gt : QueryExpression
    {
        public Gt(string fieldName, string value) : base(fieldName, value) { }

        //<Gt>
        //  <FieldRef Name="DeadLine"></FieldRef>
        //  <Value Type="DateTime"><Today/></Value>
        //</Gt>
        public override string BuildExpression()
        {
            return string.Format(ExpressionStringTemplate.Gt, this.fieldName, this.ValuetypeString, this.value);
        }
    }
}
