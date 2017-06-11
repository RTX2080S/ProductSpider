﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductSpider.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSpider.Services.UnitTest
{
    [TestClass]
    public class ContentReaderTests
    {
        private IContentReader contentReader;

        [TestInitialize]
        public void Can_create_ContentReader()
        {
            contentReader = new ContentReader();
        }

        [TestMethod]
        public void ContentReader_get_correct_result_1()
        {
            string document = "<p>abc</p>";
            var expected = "abc";
            contentReader.SetContext(document);
            var actual = contentReader.ReadContent("<p>", "</p>");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ContentReader_get_correct_result_when_tags_not_set()
        {
            string document = "<p>abc</p>";
            var expected = string.Empty;
            contentReader.SetContext(document);
            var actual = contentReader.ReadContent("", null);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ContentReader_get_correct_result_when_tags_not_exist()
        {
            string document = "<p>abc</p>";
            var expected = string.Empty;
            contentReader.SetContext(document);
            var actual = contentReader.ReadContent("<a>", "</a>");

            Assert.AreEqual(expected, actual);
        }

        [TestCleanup]
        public void Cleanup_ContentReader()
        {
            contentReader = null;
        }
    }
}
