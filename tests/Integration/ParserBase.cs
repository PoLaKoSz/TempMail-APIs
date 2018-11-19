using System.IO;

namespace PoLaKoSz.TempMail.Tests.Integration
{
    internal abstract class ParserBase
    {
        private static readonly string _rootDir;
        private readonly string _actualDir;



        static ParserBase()
        {
            _rootDir = "StaticResources/";
        }

        public ParserBase(string subFolder)
        {
            _actualDir = Path.Combine(_rootDir, subFolder);
        }



        protected string GetHtmlData(string fileName)
        {
            return File.ReadAllText(Path.Combine(_actualDir, fileName + ".html"));
        }
    }
}
