using System;

namespace PoLaKoSz.TempMail.Models
{
    public class Email
    {
        public string ID { get; }
        public string Sender { get; }
        public string Title { get; }
        public string Body { get; private set; }
        public DateTime Date { get; }



        public Email(string id, string sender, string title, DateTime date)
        {
            ID = id;
            Sender = sender;
            Title = title;
            Body = "";
            Date = date;
        }



        internal void SetBody(string body)
        {
            if (Body == "")
            {
                Body = body;
            }
            else
            {
                throw new InvalidOperationException("Email body can only be changed once!");
            }
        }
    }
}
