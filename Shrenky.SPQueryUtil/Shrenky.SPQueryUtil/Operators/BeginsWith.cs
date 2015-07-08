using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shrenky.SPQueryUtil.Operators
{
    public class BeginsWith : QueryExpression
    {
        public BeginsWith(string fieldName, string value) : base(fieldName, value) { }

        //<BeginsWith>
        //  <FieldRef Name="Status"></FieldRef>
        //  <Value Type="Text">Completed</Value>
        //</BeginsWith>
        public override string BuildExpression()
        {
            return string.Format(ExpressionStringTemplate.BeginsWith, this.fieldName, this.ValuetypeString, this.value);
        }
    }
}
