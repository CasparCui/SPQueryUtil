using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shrenky.SPQueryUtil
{
    public class Eq : QueryExpression
    {
        public Eq(string fieldName, string value) : base(fieldName, value) { }

        //<Eq>
        //  <FieldRef Name="Status"></FieldRef>
        //  <Value Type="Text">Completed</Value>
        //</Eq>
        public override string BuildExpression()
        {
            return string.Format(ExpressionStringTemplate.Eq, this.fieldName, this.ValuetypeString, this.value);
        }
    }
}
