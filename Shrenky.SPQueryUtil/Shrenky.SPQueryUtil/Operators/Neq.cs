using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shrenky.SPQueryUtil.Operators
{
    public class Neq : QueryExpression
    {
        public Neq(string fieldName, string value) : base(fieldName, value) { }

        //<Neq>
        //  <FieldRef Name="Status"></FieldRef>
        //  <Value Type="Text">Completed</Value>
        //</Neq>
        public override string BuildExpression()
        {
            return string.Format(ExpressionStringTemplate.Neq, this.fieldName, this.ValuetypeString, this.value);
        }
    }
}
