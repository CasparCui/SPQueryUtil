using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shrenky.SPQueryUtil.Operators
{
    public class Includes : QueryExpression
    {
        public Includes(string fieldName, string value) : base(fieldName, value) { }

        //<Includes>
        //  <FieldRef Name="Status"></FieldRef>
        //  <Value Type="Text">Completed</Value>
        //</Includes>
        public override string BuildExpression()
        {
            return string.Format(ExpressionStringTemplate.Includes, this.fieldName, this.ValuetypeString, this.value);
        }
    }
}
