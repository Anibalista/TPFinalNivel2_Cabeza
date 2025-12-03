using System.Linq;

namespace Negocio
{
    public static class Validadores
    {
        public static bool EsCaracterDecimal(char input)
        {
            return char.IsDigit(input) || input == '.' || char.IsControl(input);
        }

        public static bool EsNumeroDecimal(string input)
        {
            decimal numero = 0;
            return decimal.TryParse(input, out numero) || input.Count(c => c.Equals(",") || c.Equals(".")) < 2;
        }

        
    }
}
