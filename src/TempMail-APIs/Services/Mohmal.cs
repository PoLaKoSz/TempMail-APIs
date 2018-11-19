using PoLaKoSz.TempMail.DataAccessLayer.Web;
using System;
using System.Threading.Tasks;

namespace PoLaKoSz.TempMail.Services
{
    public class Mohmal : MailService
    {
        public DateTime AliveDate { get; }
        public string EmailAddress { get; }



        public Mohmal()
            : this(new HttpClient()) { }

        public Mohmal(IHttpClient httpClient)
            : base(new Uri("https://www.mohmal.com/en/"), httpClient)
        {
            AliveDate = new DateTime();
            EmailAddress = "";
        }



        public async Task<bool> NewMail()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ReNew()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ReFresh()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete()
        {
            throw new NotImplementedException();
        }
    }
}
