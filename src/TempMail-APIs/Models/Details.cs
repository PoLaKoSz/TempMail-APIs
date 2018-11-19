using System;
using System.Collections.Generic;

namespace PoLaKoSz.TempMail.Models
{
    public class Details
    {
        public DateTime AliveDate { get; private set; }
        public string EmailAddress { get; private set; }
        public List<Email> InBox { get; private set; }



        public Details()
        {
            AliveDate = new DateTime(1990, 01, 01);
            EmailAddress = "";
            InBox = new List<Email>();
        }



        public void SetEmailAddress(string email)
        {
            if (EmailAddress == "")
            {
                EmailAddress = email;
            }
            else
            {
                throw new InvalidOperationException("Email address can change only once!");
            }
        }

        public void SetAliveDate(DateTime newDate)
        {
            if (AliveDate != new DateTime(1990, 01, 01))
            {
                AliveDate = newDate;
            }
            else
            {
                throw new InvalidOperationException("Alive date can change only once!");
            }
        }

        public void AddEmail(Email email)
        {
            InBox.Add(email);
        }
    }
}
