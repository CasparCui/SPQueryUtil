using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shrenky.SPQueryUtil
{
    public static class ExpressionStringTemplate
    {
        //QueryExpression
        public static string Eq = "<Eq><FieldRef Name=\"{0}\"><FieldRef><Value Type=\"{1}\">{2}</Value></Eq>";
        
        //filters
        public static string Where = "<Where>{0}</Where>";
        public static string And = "<And>{0}</And>";
        public static string Or = "<Or>{0}</Or>";
    }
}
