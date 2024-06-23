using UnificadorPDF.Interfaces;

namespace UnificadorPDF
{
    internal class Gui : IGui
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string GetContent()
        {
            return Console.ReadLine();
        }

        public void ShowStopMessage(string message)
        {
            ShowMessage(message);
            GetContent();
        }

        public string GetOriginPath()
        {

            ShowMessage("Por favor, informe o caminho da pasta que contenha os PDFs:");
            string folderPath = GetContent();

            return folderPath;
        }

        public string GetOutputPath()
        {
            ShowMessage("Por favor, informe o caminho de saida:");
            string folderPath = GetContent();

            return folderPath;
        }
    }
}
