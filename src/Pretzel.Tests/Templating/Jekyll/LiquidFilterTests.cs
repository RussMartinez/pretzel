﻿using System;
using System.Web;
using Pretzel.Logic.Liquid;
using Xunit;

namespace Pretzel.Tests.Templating.Jekyll
{
    public class LiquidFilterTests
    {
        [Fact]
        public void DateToXmlSchema_ForExpectedDate_ReturnsCorrectString()
        {
            Assert.Equal("2014-01-01T01:00:00+01:00", DateToXmlSchemaFilter.date_to_xmlschema(new DateTime(2014, 1, 1, 0, 0, 0, DateTimeKind.Utc)));
        }

        [Fact]
        public void DateToRfc822_ForExpectedDate_ReturnsCorrectString()
        {
            Assert.Equal("Wed, 01 Jan 2014 00:00:00 +0000", DateToRfc822FormatFilter.date_to_rfc822(new DateTime(2014, 01, 01, 0, 0, 0, DateTimeKind.Utc)));
        }

        [Fact]
        public void DateToString_ForExpectedDate_ReturnsCorrectString()
        {
            var date = new DateTime(2008, 11, 07);
            Assert.Equal(date.ToString("dd MMM yyyy"), DateToStringFilter.date_to_string(date));
        }

        [Fact]
        public void DateToString_WithNoDate_ReturnsNothing()
        {
            Assert.Equal("", DateToStringFilter.date_to_string(""));
        }

        [Fact]
        public void DateToLongString_ForExpectedDate_ReturnsCorrectString()
        {
            Assert.Equal("07 November 2008", DateToLongStringFilter.date_to_long_string(new DateTime(2008, 11, 07)));
        }

        [Fact]
        public void CgiEscape_ForGivenString_ReturnsEscapedString()
        {
            Assert.Equal("foo%2Cbar%3Bbaz%3F", CgiEscapeFilter.cgi_escape(@"foo,bar;baz?"));
        }

        [Fact]
        public void UriEscape_ForGivenString_ReturnsEscapedString()
        {
            Assert.Equal("foo,%20bar%20%5Cbaz?", UriEscapeFilter.uri_escape(@"foo, bar \baz?"));
        }

        [Fact]
        public void NumberOfWords_ForGiveString_ReturnsCorrectCount()
        {
            Assert.Equal(4.ToString(), NumberOfWordsFilter.number_of_words("This is a test"));
        }
    }
}
