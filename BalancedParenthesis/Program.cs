using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
            Regex rgxSymbols = new Regex(@"[^\(\{\[\)\}\]]+");
            string OpenSymbols = "({[";

            string onlySymbols = rgxSymbols.Replace(s, "");

            char[] chars = onlySymbols.ToCharArray();
            int BalanceBracketsCount = 0;
            int BalanceCurlyBracketsCount = 0;
            int BalanceSquareBracketsCount = 0;
            Stack<char> Symbols = new Stack<char>();

            SymbolCounter sc = new SymbolCounter();
            SymbolsStats st = new SymbolsStats();

            foreach (char c in chars)
            {
                if (OpenSymbols.Contains(c))
                {
                    //st = sc.ProcessOpeningSymbol(c);
                    Symbols.Push(c);
                    switch (c)
                    {

                        case '(':
                            BalanceBracketsCount++;
                            break;
                        case '{':
                            BalanceCurlyBracketsCount++;
                            break;
                        case '[':
                            BalanceSquareBracketsCount++;
                            break;
                    }
                }
                else
                {
                    if (Symbols.Count == 0)
                        return false;
                    char CurrentSymbol = Symbols.Pop();

                    if (!MatchingSymbol(CurrentSymbol, c))
                        return false;
                    switch (c)
                    {

                        case ')':
                            BalanceBracketsCount--;
                            break;
                        case '}':
                            BalanceCurlyBracketsCount--;
                            break;
                        case ']':
                            BalanceSquareBracketsCount--;
                            break;
                    }

                }

                }

                if (BalanceBracketsCount < 0 || BalanceBracketsCount < 0|| BalanceSquareBracketsCount < 0)
                    return false;

            return BalanceBracketsCount == 0 && BalanceBracketsCount == 0 && BalanceSquareBracketsCount == 0;

        }

        private static bool MatchingSymbol(char symbol, char c)
        {
            bool result = false;

            switch (symbol)
            {
                case '(':
                    result = c == ')';
                    break;
                case '{':
                    result = c == '}';
                    break;
                case '[':
                    result = c == ']';
                    break;
            }

            return result;
        }
    }

}

