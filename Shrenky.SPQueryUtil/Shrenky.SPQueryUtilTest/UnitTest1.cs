using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shrenky.SPQueryUtil;
using Microsoft.SharePoint;
using Shrenky.SPQueryUtil.Joins;
using Shrenky.SPQueryUtil.Operators;

namespace Shrenky.SPQueryUtilTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SPList list = null;
            SPFilter filter = new SPFilter(list);
            filter.GetItems(new And(new Eq("title", "123"), new Eq("cole1", "a"), new Eq("col2", "b")));
            string s = filter.QueryString;

        }
    }
}
