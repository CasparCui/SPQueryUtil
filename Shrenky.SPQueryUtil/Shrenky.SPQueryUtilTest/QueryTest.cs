﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shrenky.SPQueryUtil;
using Microsoft.SharePoint;
using Shrenky.SPQueryUtil.Joins;
using Shrenky.SPQueryUtil.Operators;

namespace Shrenky.SPQueryUtilTest
{
    [TestClass]
    public class QueryTest
    {
        string siteUrl = @"http://sp2013test";
        string webUrl = @"/query";
        string listName = "QueryCamlTestList";
        SPQuery spQuery = new SPQuery();

        SPList TestList { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            using (SPSite site = new SPSite("http://sp2013test"))
            {
                using (SPWeb web = site.OpenWeb(webUrl))
                {
                    TestList = web.Lists.TryGetList(this.listName);
                    if (TestList == null)
                    {
                        Guid listId = web.Lists.Add(this.listName, "Test list for SPQueryUtil querystring", SPListTemplateType.GenericList);
                        web.Update();
                        TestList = web.Lists[listId];
                        TestList.Fields.Add("TextCol", SPFieldType.Text, false);
                        TestList.Fields.Add("MultiTextCol", SPFieldType.Note, false);
                        TestList.Fields.Add("NumberCol", SPFieldType.Number, false);
                        TestList.Fields.Add("DateTimeCol", SPFieldType.DateTime, false);
                        TestList.Fields.Add("BoolCol", SPFieldType.Boolean, false);
                        TestList.Fields.Add("ChoiceCol", SPFieldType.Choice, false);
                        TestList.Fields.Add("MultiChoiceCol", SPFieldType.MultiChoice, false);
                        TestList.Fields.Add("GuidCol", SPFieldType.Guid, false);
                        TestList.Fields.Add("UrlCol", SPFieldType.URL, false);
                        TestList.Fields.Add("UserCol", SPFieldType.User, false);
                        TestList.Update();

                        SPListItem textItem = TestList.AddItem();
                        textItem["TextCol"] = "text1";
                        textItem.Update();
                        SPListItem textItemMulti = TestList.AddItem();
                        textItemMulti["MultiTextCol"] = "Multi text";
                        textItemMulti.Update();
                        SPListItem numberItem = TestList.AddItem();
                        numberItem["NumberCol"] = 100;
                        numberItem.Update();
                        SPListItem dateTimeCol = TestList.AddItem();
                        dateTimeCol["DateTimeCol"] = new DateTime(2000, 1, 1, 5, 10, 59);
                        dateTimeCol.Update();
                        SPListItem boolItem = TestList.AddItem();
                        boolItem["BoolCol"] = true;
                        boolItem.Update();
                        SPListItem choiceItem = TestList.AddItem();
                        choiceItem["ChoiceCol"] = "choice1";
                        choiceItem.Update();
                        var choicevalues = new SPFieldMultiChoiceValue();
                        choicevalues.Add("Green");
                        choicevalues.Add("Blue");
                        SPListItem chioceItemMulti = TestList.AddItem();
                        chioceItemMulti["MultiChoiceCol"] = choicevalues;
                        chioceItemMulti.Update();
                        SPListItem guidItem = TestList.AddItem();
                        guidItem["GuidCol"] = new Guid("96D74029-8482-4C52-8C4F-4A4040A77BC5");
                        guidItem.Update();
                        SPListItem urlItem = TestList.AddItem();
                        urlItem["UrlCol"] = "http://www.google.com";
                        urlItem.Update();
                        //SPListItem userItem = TestList.AddItem();
                        //textItemMulti["UserCol"] = "";
                        //userItem.Update();
                    }
                }

                using (SPWeb web = site.OpenWeb(this.webUrl))
                {
                    TestList = web.Lists[this.listName];
                }
            }
        }

        [TestCleanup]
        public void TestClear()
        {
            using (SPSite site = new SPSite("http://sp2013test"))
            {
                using (SPWeb web = site.OpenWeb(this.webUrl))
                {
                    TestList = web.Lists.TryGetList(this.listName);
                    if (TestList != null)
                    {
                        web.Lists[TestList.Title].Delete();
                        web.Update();
                    }
                }
            }
        }

        [TestMethod]
        public void TestEq()
        {
            //Text Field
            string caml = CamlBuilder.BuildCaml(TestList, new Eq("textcol", "text1"));
            Assert.IsNotNull(caml);
            this.spQuery.Query = caml;
            var items = this.TestList.GetItems(this.spQuery);
            Assert.IsTrue(items.Count == 1);

            //Number Field            
            caml = CamlBuilder.BuildCaml(TestList, new Eq("numbercol", "100"));
            Assert.IsNotNull(caml);
            this.spQuery.Query = caml;
            items = this.TestList.GetItems(this.spQuery);
            Assert.IsTrue(items.Count == 1);

            //DateTime Field
            DateTime dt = new DateTime(2000, 1, 1, 5, 10, 59);
            string dts = Microsoft.SharePoint.Utilities.SPUtility.CreateISO8601DateTimeFromSystemDateTime(dt);
            caml = CamlBuilder.BuildCaml(TestList, new Eq("datetimecol", dts));
            Assert.IsNotNull(caml);
            this.spQuery.Query = caml;
            items = this.TestList.GetItems(this.spQuery);
            Assert.IsTrue(items.Count == 1);

            //Bool Field
            caml = CamlBuilder.BuildCaml(TestList, new Eq("BoolCol", "1"));
            Assert.IsNotNull(caml);
            this.spQuery.Query = caml;
            items = this.TestList.GetItems(this.spQuery);
            Assert.IsTrue(items.Count == 1);
        }

        [TestMethod]
        public void TestAnd()
        {
            string caml = CamlBuilder.BuildCaml(TestList, new And(new Eq("textCol", "text1"), new Eq("ID", "1")));
            Assert.IsNotNull(caml);
            this.spQuery.Query = caml;
            var items = this.TestList.GetItems(this.spQuery);
            Assert.IsTrue(items.Count == 1);
        }

        [TestMethod]
        public void TextOr()
        {
            string caml = CamlBuilder.BuildCaml(TestList, new Or(new Eq("textCol", "text1"), new Eq("ID", "2")));
            Assert.IsNotNull(caml);
            this.spQuery.Query = caml;
            var items = this.TestList.GetItems(this.spQuery);
            Assert.IsTrue(items.Count == 2);

            caml = CamlBuilder.BuildCaml(TestList, new Or(new Eq("textCol", "text1"), new Eq("ID", "2"), new Eq("ID", "3")));
            Assert.IsNotNull(caml);
            this.spQuery.Query = caml;
            items = this.TestList.GetItems(this.spQuery);
            Assert.IsTrue(items.Count == 3);
        }
    }
}
