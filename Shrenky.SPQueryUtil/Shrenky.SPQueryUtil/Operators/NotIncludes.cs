using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shrenky.SPQueryUtil.Operators
{
    public class NotIncludes : QueryExpression
    {
        public NotIncludes(string fieldName, string value) : base(fieldName, value) { }

        //<NotIncludes>
        //  <FieldRef Name="Status"></FieldRef>
        //  <Value Type="Text">Completed</Value>
        //</NotIncludes>
        public override string BuildExpression()
        {
            return string.Format(ExpressionStringTemplate.NotIncludes, this.fieldName, this.ValuetypeString, this.value);
        }
    }
}
