using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shrenky.SPQueryUtil
{
    public static class ExpressionStringTemplate
    {
        //Operators expression
        public static string Eq = "<Eq><FieldRef Name=\"{0}\"></FieldRef><Value Type=\"{1}\">{2}</Value></Eq>";
        public static string BeginsWith = "<BeginsWith><FieldRef Name=\"{0}\"></FieldRef><Value Type=\"{1}\">{2}</Value></BeginsWith>";
        public static string Contains = "<Contains><FieldRef Name=\"{0}\"></FieldRef><Value Type=\"{1}\">{2}</Value></Contains>";
        public static string DateRangesOverlap = "<DateRangesOverlap><FieldRef Name=\"{0}\"></FieldRef><Value Type=\"{1}\">{2}</Value></DateRangesOverlap>";
        public static string Geq = "<Geq><FieldRef Name=\"{0}\"></FieldRef><Value Type=\"{1}\">{2}</Value></Geq>";
        public static string Gt = "<Gt><FieldRef Name=\"{0}\"></FieldRef><Value Type=\"{1}\">{2}</Value></Gt>";
        public static string In = "<In><FieldRef Name=\"{0}\"></FieldRef><Value Type=\"{1}\">{2}</Value></In>";
        public static string Includes = "<Includes><FieldRef Name=\"{0}\"></FieldRef><Value Type=\"{1}\">{2}</Value></Includes>";
        public static string Leq = "<Leq><FieldRef Name=\"{0}\"></FieldRef><Value Type=\"{1}\">{2}</Value></Leq>";
        public static string Lt = "<Lt><FieldRef Name=\"{0}\"></FieldRef><Value Type=\"{1}\">{2}</Value></Lt>";
        public static string Neq = "<Neq><FieldRef Name=\"{0}\"></FieldRef><Value Type=\"{1}\">{2}</Value></Neq>";
        public static string NotIncludes = "<NotIncludes><FieldRef Name=\"{0}\"></FieldRef><Value Type=\"{1}\">{2}</Value></NotIncludes>";

        public static string IsNotNull = "<IsNotNull><FieldRef Name=\"{0}\"></FieldRef></IsNotNull>";
        public static string IsNull = "<IsNull><FieldRef Name=\"{0}\"></FieldRef></IsNull>";
        public static string GroupBy = "<GroupBy><FieldRef Name=\"{0}\"></FieldRef></GroupBy>";
        public static string OrderBy = "<OrderBy><FieldRef Name=\"{0}\"></FieldRef></OrderBy>";

        //Joins
        public static string Where = "<Where>{0}</Where>";
        public static string And = "<And>{0}</And>";
        public static string Or = "<Or>{0}</Or>";
    }
}
