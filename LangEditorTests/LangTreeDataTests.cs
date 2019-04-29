using Microsoft.VisualStudio.TestTools.UnitTesting;
using LangEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangEditor.Tests {
    [TestClass()]
    public class LangTreeDataTests {
        [TestMethod()]
        public void parseLineTestEmptyText() {
            (string[] texts, string last) = LangTreeData.parseLine("");
            CollectionAssert.AreEqual(texts, new string[0]);
            Assert.AreEqual(last, "");
        }

        [TestMethod()]
        public void parseLineTestNoValidNoHasEqualText() {
            (string[] texts, string last) = LangTreeData.parseLine("aaaa");
            CollectionAssert.AreEqual(texts, new string[0]);
            Assert.AreEqual(last, "");
        }

        [TestMethod()]
        public void parseLineTestLastEmpty() {
            (string[] texts, string last) = LangTreeData.parseLine("aaaa=");
            CollectionAssert.AreEqual(texts, new string[1] { "aaaa" });
            Assert.AreEqual(last, "");
        }

        [TestMethod()]
        public void parseLineTestSingle() {
            (string[] texts, string last) = LangTreeData.parseLine("aaaa=bbb");
            CollectionAssert.AreEqual(texts, new string[1] { "aaaa" });
            Assert.AreEqual(last, "bbb");
        }

        [TestMethod()]
        public void parseLineTestMulti() {
            (string[] texts, string last) = LangTreeData.parseLine("aaaa.cccc=bbb");
            CollectionAssert.AreEqual(texts, new string[2] { "aaaa", "cccc" });
            Assert.AreEqual(last, "bbb");
        }

        [TestMethod()]
        public void groupingSingleTest() {
            string code = @"
aaa=ccc
bbb=ccc
";
            List<LangTreeData> list = LangTreeData.grouping(code);
            CollectionAssert.AreEqual(list, new LangTreeData[2] {
                new LangTreeData("aaa", false),
                new LangTreeData("bbb", false)
            }.ToList());
        }

        [TestMethod()]
        public void groupingMultiTest() {
            string code = @"
aaa.ccc=1
aaa.ddd=2
aaa=3
bbb.eee=4
bbb.fff=5
bbb=6
";
            List<LangTreeData> list = LangTreeData.grouping(code);
            LangTreeData elem1 = new LangTreeData("aaa", false);
            elem1.Children.Value.Add(new LangTreeData("ccc", false));
            elem1.Children.Value.Add(new LangTreeData("ddd", false));
            LangTreeData elem2 = new LangTreeData("bbb", false);
            elem2.Children.Value.Add(new LangTreeData("eee", false));
            elem2.Children.Value.Add(new LangTreeData("fff", false));
            CollectionAssert.AreEqual(list, new LangTreeData[2] {elem1, elem2}.ToList());
        }

        [TestMethod()]
        public void groupingMultiConcatTest() {
            string code = @"
aaa.ccc=1
";
            List<LangTreeData> list = LangTreeData.grouping(code);
            LangTreeData elem1 = new LangTreeData("aaa.ccc", false);
            CollectionAssert.AreEqual(list, new LangTreeData[1] { elem1 }.ToList());
        }
    }
}