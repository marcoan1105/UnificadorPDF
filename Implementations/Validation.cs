using UnificadorPDF.Interfaces;

namespace UnificadorPDF
{
    internal class Validation : IValidation
    {
        public void ValidateFiles(string[] files)
        {
            if (files.Length == 0)
            {
                throw new Exception(string.Format("Nenhum arquivo encontrado. Verifique a pasta {0} e tente novamente.", files));
            }
        }

        public void ValidateOutput(string outputPath)
        {
            if (!Directory.Exists(outputPath))
            {
                throw new Exception(string.Format("O diretório de destino não foi encontrado. Verifique a pasta {0} e tente novamente.", outputPath));
            }
        }
    }
}
