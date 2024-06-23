using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;
using UnificadorPDF.Interfaces;

namespace UnificadorPDF
{
    internal class FilesManager : IFileManager
    {
        private IGui _gui;

        internal FilesManager(IGui gui)
        {
            _gui = gui;
        }

        public string MargePDFs(string[] files, string outputPath)
        {
            outputPath = GenerateFileName(outputPath);            

            PdfDocument? merged = new PdfDocument(outputPath);

            foreach (var file in files)
            {
                merged = ForeachMargePdf(file, merged);                
            }

            merged.Close();

            return outputPath;
        }

        private PdfDocument ForeachMargePdf(string file, PdfDocument merged)
        {
            _gui.ShowMessage(string.Format("Lendo o PDF {0}.", file));

            using (PdfDocument filePdf = PdfReader.Open(file, PdfDocumentOpenMode.Import))
            {
                CopyPages(filePdf, merged);
            }

            return merged;
        }

        public string[] GetFiles(string folderPath)
        {
            var files = new string[1];

            if (Directory.Exists(folderPath))
            {
                files = Directory.GetFiles(folderPath);
            }

            return files;
        }

        private string GenerateFileName(string outputPath)
        {
            var pdfName = string.Format("{0}.pdf", Guid.NewGuid());
            outputPath = string.Format(@"{0}/{1}", outputPath, pdfName);

            return outputPath;
        }

        private void CopyPages(PdfDocument from, PdfDocument to)
        {
            for (int i = 0; i < from.PageCount; i++)
            {
                to.AddPage(from.Pages[i]);
            }
        }
    }
}
