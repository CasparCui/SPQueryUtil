using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shrenky.SPQueryUtil.Operators
{
    public class Contains : QueryExpression
    {
        public Contains(string fieldName, string value) : base(fieldName, value) { }
        //<Contains>
        //  <FieldRef Name="Status"></FieldRef>
        //  <Value Type="Text">Completed</Value>
        //</Contains>
        public override string BuildExpression()
        {
            return string.Format(ExpressionStringTemplate.Contains, this.fieldName, this.ValuetypeString, this.value);
        }
    }
}
