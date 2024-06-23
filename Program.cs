using UnificadorPDF.Interfaces;

namespace UnificadorPDF
{
    internal class Program
    {
        private static IGui _gui { get; set; }

        static void Main(string[] args)
        {
            _gui = new Gui();

            try
            {
                TryMain();
            }
            catch (Exception ex)
            {
                CatchMain(ex);                
            }           
        }

        private static void CatchMain(Exception ex)
        {
            _gui.ShowStopMessage(ex.Message);
        }

        private static void TryMain()
        {
            var filesManager = new FilesManager(_gui);
            var validation = new Validation();
            var core = new Core(_gui, filesManager, validation);
            core.Execute();
        }
    }
}