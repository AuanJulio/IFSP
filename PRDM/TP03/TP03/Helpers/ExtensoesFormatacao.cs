using System.Globalization;

namespace TP03.Helpers
{
    public static class ExtensoesFormatacao
    {
        private static readonly CultureInfo PtBr = new("pt-BR");
        public static string ParaReais(this decimal valor) => valor.ToString("C", PtBr);
    }
}
