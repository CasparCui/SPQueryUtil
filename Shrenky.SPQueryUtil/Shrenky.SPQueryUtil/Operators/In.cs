using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shrenky.SPQueryUtil.Operators
{
    public class In : QueryExpression
    {
        public In(string fieldName, string value) : base(fieldName, value) { }

        //<In>
        //  <FieldRef Name="ID"></FieldRef>
        //  <Value Type="Number">1</Value>
        //</In>
        public override string BuildExpression()
        {
            return string.Format(ExpressionStringTemplate.In, this.fieldName, this.ValuetypeString, this.value);
        }
    }
}
