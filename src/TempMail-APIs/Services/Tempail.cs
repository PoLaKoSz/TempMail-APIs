using PoLaKoSz.TempMail.DataAccessLayer.Web;
using PoLaKoSz.TempMail.Models;
using System;
using System.Threading.Tasks;

namespace PoLaKoSz.TempMail.Services
{
    public class Tempail : MailService
    {
        public Details Details { get; private set; }



        public Tempail()
            : this(new HttpClient()) { }

        public Tempail(IHttpClient httpClient)
            : base(new Uri("https://tempail.com/en/"), httpClient)
        {
            Details = new Details();
        }



        public async Task NewMail()
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

        public async Task<Email> GetMail(string id)
        {
            throw new NotImplementedException();
        }
    }
}
