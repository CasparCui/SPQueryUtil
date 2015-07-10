using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.SharePoint;
using Shrenky.SPQueryUtil.Joins;
using Shrenky.SPQueryUtil;
using Shrenky.SPQueryUtil.Operators;

namespace Shrenky.SPQueryUtilTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (SPSite site = new SPSite("http://sp2013test"))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    SPList list = web.Lists["Staff b"];
                    SPFilter filter = new SPFilter(list);
                    filter.GetItems(new And(new Eq("3L Code", "TET"), new Eq("Seniority", "99"), new Eq("start Contract", "0")));
                    string s = filter.QueryString;
                    Console.WriteLine(s);
                    Console.ReadLine();
                }
            }
        }
    }
}
