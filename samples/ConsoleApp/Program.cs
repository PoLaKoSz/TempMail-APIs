using PoLaKoSz.TempMail.Services;

namespace PoLaKoSz.Samples.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var tmpMailService = new Tempm();
            tmpMailService.NewMail().GetAwaiter().GetResult();
            //tmpMailService.ReNew();
            tmpMailService.ReFresh();
            //tmpMailService.Delete();
        }
    }
}
