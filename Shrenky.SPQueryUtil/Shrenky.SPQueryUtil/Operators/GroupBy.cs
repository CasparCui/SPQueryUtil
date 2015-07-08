using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shrenky.SPQueryUtil.Operators
{
    public class GroupBy : QueryExpression
    {
        public GroupBy(string fieldName) : base(fieldName, string.Empty) { }

        //<GroupBy>
        //  <FieldRef Name="Status"></FieldRef>
        //</GroupBy>
        public override string BuildExpression()
        {
            return string.Format(ExpressionStringTemplate.GroupBy, this.fieldName);
        }
    }
}
