namespace UnificadorPDF.Interfaces
{
    internal interface IValidation
    {
        void ValidateFiles(string[] files);
        void ValidateOutput(string outputPath);
    }
}
