namespace UnificadorPDF.Interfaces
{
    internal interface IGui
    {
        void ShowMessage(string message);
        string GetContent();
        void ShowStopMessage(string message);
        string GetOriginPath();
        string GetOutputPath();
    }
}
