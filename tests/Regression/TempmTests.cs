using NUnit.Framework;
using PoLaKoSz.TempMail.Services;
using System.Threading.Tasks;

namespace PoLaKoSz.TempMail.Tests.Regression
{
    class TempmTests
    {
        private Tempm _service;



        [OneTimeSetUp]
        public void Init()
        {
            _service = new Tempm();
        }



        [Test]
        public async Task Should_Load_Main_Page_Without_Exception()
        {
            await _service.NewMail();
        }
    }
}
