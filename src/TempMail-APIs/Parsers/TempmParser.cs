using HtmlAgilityPack;
using PoLaKoSz.TempMail.Models;
using System;

namespace PoLaKoSz.TempMail.Parsers
{
    public static class TempmParser
    {
        /// <summary>
        /// Parse the main page of the Tempm webpage
        /// </summary>
        /// <exception cref="NodeNotFoundException"></exception>
        public static Details MainPage(string sourceCode)
        {
            Details details = new Details();

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(sourceCode);

            GetEmailAddress(htmlDocument, details);
            GetEmails(htmlDocument, details);

            return details;
        }

        public static void Email(string sourceCode, Email email)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(sourceCode);
            HtmlNode emailNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@id=\"email-table\"]/div[@id=\"iddelet2\"]//div[@class=\"e7m mess_bodiyy\"]/p");

            if (emailNode == null)
                throw new NodeNotFoundException("emailNode");

            email.SetBody(emailNode.InnerHtml);
        }


        private static void GetEmailAddress(HtmlDocument htmlDocument, Details details)
        {
            HtmlNode emailAddressNode = htmlDocument.DocumentNode.SelectSingleNode("//span[@id=\"email_ch_text\"]");

            if (emailAddressNode == null)
            {
                throw new NodeNotFoundException("emailAddressNode");
            }

            details.SetEmailAddress(emailAddressNode.InnerText);
        }

        private static void GetEmails(HtmlDocument htmlDocument, Details details)
        {
            HtmlNode emailTableNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@id=\"email-table\"]");

            if (emailTableNode == null)
                return;

            var emailNodeCollection = emailTableNode.SelectNodes("./a");

            if (emailNodeCollection == null)
                throw new NodeNotFoundException("emailNodeCollection");

            foreach (var emailNode in emailNodeCollection)
            {
                string id = emailNode.GetAttributeValue("href", "");

                var moreDetailsNode = emailNode.SelectNodes("./div");

                if (moreDetailsNode == null)
                    throw new NodeNotFoundException("moreDetailsNode");
                else if (moreDetailsNode.Count != 3)
                    throw new NodeNotFoundException("moreDetailsNode should have 3 node!");

                string sender = moreDetailsNode[0].InnerText;
                string title = moreDetailsNode[1].InnerText;

                DateTime date = DateTime.Parse(moreDetailsNode[2].InnerText);
                date = DateTime.SpecifyKind(date, DateTimeKind.Utc);

                details.InBox.Add(new Email(id, sender, title, date));
            }
        }
    }
}
