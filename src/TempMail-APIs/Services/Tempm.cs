using PoLaKoSz.TempMail.DataAccessLayer.Web;
using PoLaKoSz.TempMail.Models;
using PoLaKoSz.TempMail.Parsers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PoLaKoSz.TempMail.Services
{
    public class Tempm : MailService
    {
        private string _deleteID;

        public Details Details { get; private set; }



        public Tempm()
            : this(new HttpClient()) { }

        public Tempm(IHttpClient httpClient)
            : base(new Uri("https://tempm.com/"), httpClient)
        {
            Details = new Details();
        }



        public async Task NewMail()
        {
            string sourceCode = await base.GetAsync();

            Details = TempmParser.MainPage(sourceCode);
            _deleteID = "";
        }

        public async Task<bool> ReNew()
        {
            throw new NotImplementedException();
        }

        public async Task ReFresh()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete()
        {
            throw new NotImplementedException();
        }

        public async Task<Email> GetMail(string id)
        {
            var email = Details.InBox.Where(e => e.ID == id).First();

            string sourceCode = await base.GetAsync(id);

            TempmParser.Email(sourceCode, email);

            return email;
        }
    }
}
