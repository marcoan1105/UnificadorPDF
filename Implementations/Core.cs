using UnificadorPDF.Interfaces;

namespace UnificadorPDF
{
    internal class Core : ICore
    {
        internal IGui _gui { get; set; }
        internal IFileManager _fileManager { get; set; }

        private IValidation _validation;

        internal Core(IGui gui, IFileManager fileManager, IValidation validation)
        {
            _gui = gui;
            _fileManager = fileManager;
            _validation = validation;
        }

        public void Execute()
        {
            string folderPath = _gui.GetOriginPath();
            string outputPath = _gui.GetOutputPath();

            _validation.ValidateOutput(outputPath);

            string[] files = _fileManager.GetFiles(folderPath);

            _validation.ValidateFiles(files);

            string fileOutput = _fileManager.MargePDFs(files, outputPath);

            _gui.ShowStopMessage(string.Format("O PDF foi unificado e salvo em {0}", fileOutput));
        }
    }
}
