using NUnit.Framework;
using PoLaKoSz.TempMail.Models;
using PoLaKoSz.TempMail.Parsers;
using System;

namespace PoLaKoSz.TempMail.Tests.Integration.Parsers
{
    class TempmParserTests : ParserBase
    {
        public TempmParserTests()
            : base("Tempm") { }



        [Test]
        public void Can_Extract_Email_Address()
        {
            string sourceCode = base.GetHtmlData("main_page");
            Details actual = TempmParser.MainPage(sourceCode);
            Assert.That(actual.EmailAddress, Is.EqualTo("samira.el.9822i@3ntxtrts3g4eko.ml"));
        }

        [Test]
        public void Can_Extract_Emails_With_Content()
        {
            string sourceCode = base.GetHtmlData("has_emails");
            var details = TempmParser.MainPage(sourceCode);

            Assert.That(details, Is.Not.Null, "details");
            Assert.That(details.InBox.Count, Is.EqualTo(2), "details.InBox.Count");

            var firstEmail = details.InBox[0];
            Assert.That(firstEmail.ID, Is.EqualTo("/3ntxtrts3g4eko.ml/samira.el.9822i/6aaf0bb653084b388840d3924c797090"), "firstEmail.ID");
            Assert.That(firstEmail.Sender, Is.EqualTo("polakosz@freemail.hu"), "firstEmail.Sender");
            Assert.That(firstEmail.Title, Is.EqualTo("asdasdasd"), "firstEmail.Title");
            Assert.That(firstEmail.Date, Is.EqualTo(new DateTime(2018, 11, 19, 15, 27, 07, DateTimeKind.Utc)), "firstEmail.Date");

            var secondEmail = details.InBox[1];
            Assert.That(secondEmail.ID, Is.EqualTo("/3ntxtrts3g4eko.ml/samira.el.9822i/ef571552b3d9610c41e3d0c598e848c2"), "secondEmail.ID");
            Assert.That(secondEmail.Sender, Is.EqualTo("polakosz@freemail.hu"), "secondEmail.Sender");
            Assert.That(secondEmail.Title, Is.EqualTo("asdasdasdasdasd"), "secondEmail.Title");
            Assert.That(secondEmail.Date, Is.EqualTo(new DateTime(2018, 11, 19, 15, 22, 35, DateTimeKind.Utc)), "secondEmail.Date");
        }

        [Test]
        public void Can_Extract_Email_Body()
        {
            string sourceCode = base.GetHtmlData("mail_selected");
            Email email = new Email("", "", "", new DateTime());
            string expectedBody = "This<br>\n<br>\nis<br>\n<br>\na multy<br>\n<br>\nline body";

            TempmParser.Email(sourceCode, email);

            Assert.That(email, Is.Not.Null, "email");
            Assert.That(email.Body, Is.EqualTo(expectedBody), "email.Body");
        }
    }
}
