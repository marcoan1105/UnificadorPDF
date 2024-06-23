namespace UnificadorPDF.Interfaces
{
    internal interface IFileManager
    {
        string MargePDFs(string[] files, string outputPath);
        string[] GetFiles(string folderPath);
    }
}
