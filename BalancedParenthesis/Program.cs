using System.Linq;
using System.Text.RegularExpressions;

namespace BalancedParenthesis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool b = IsBalanced("abcd()ad({ef)))][ada");
        }

        public static bool IsBalanced(string s)
        {
            Regex rgxSymbols = new Regex(@"[^\(\{\[\)\}\]]+");  // open and close brackets, 1 or more times
            string OpenSymbols = "({[";
            bool balanced = true;
            string onlySymbols = rgxSymbols.Replace(s, "");
            char[] chars = onlySymbols.ToCharArray();

            SymbolCounter sc = new SymbolCounter();

            foreach (char c in chars)
            {
                if (OpenSymbols.Contains(c))
                {
                    sc.ProcessOpeningSymbol(c);
                }
                else
                {
                    balanced = sc.ProcessClosingSymbol(c);
                    if (!balanced)
                        return false;
               }
            }

            return sc.Brackets == 0 && sc.CurlyBrackets == 0 && sc.SquareBrackets == 0;
        }
    }

}

