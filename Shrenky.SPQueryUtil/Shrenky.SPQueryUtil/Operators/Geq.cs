using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shrenky.SPQueryUtil.Operators
{
    public class Geq : QueryExpression
    {
        public Geq(string fieldName, string value) : base(fieldName, value) { }

        //<Geq>
        //  <FieldRef Name="DeadLine"></FieldRef>
        //  <Value Type="DateTime"><Today/></Value>
        //</Geq>
        public override string BuildExpression()
        {
            return string.Format(ExpressionStringTemplate.Geq, this.fieldName, this.ValuetypeString, this.value);
        }
    }
}
