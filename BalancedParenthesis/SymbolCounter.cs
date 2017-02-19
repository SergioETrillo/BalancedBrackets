using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedParenthesis
{


    public class SymbolCounter
    {
        int Brackets, CurlyBrackets, SquareBrackets;


        Stack<char> symbols;

        public SymbolCounter()
        {
            Brackets = 0;
            CurlyBrackets = 0;
            SquareBrackets = 0;
            Stack<char> symbols = new Stack<char>();
        }

        public SymbolsStats ProcessOpeningSymbol(char c)
        {
            symbols.Push(c);
            switch (c)
            {

                case '(':
                    Brackets++;
                    break;
                case '{':
                    CurlyBrackets++;
                    break;
                case '[':
                    SquareBrackets++;
                    break;
            }

            SymbolsStats result = new SymbolsStats()
            {
                countOfBrackets = Brackets,
                countOfCurlyBrackets = CurlyBrackets,
                countOfSquareBrackets = SquareBrackets
            };

            return result;
            //var tuple = new Tuple<int, int, int>(Brackets, CurlyBrackets, SquareBrackets);

            //return tuple;

        }

        public SymbolsStats ProcessClosingSymbol(char c)
        {
            bool balanced = true;
            if (symbols.Count == 0)
                 balanced = false;
            char CurrentSymbol = symbols.Pop();

            if (!MatchingSymbol(CurrentSymbol, c))
                balanced = false;

            switch (c)
            {
                case ')':
                    Brackets--;
                    break;
                case '}':
                    CurlyBrackets--;
                    break;
                case ']':
                    SquareBrackets--;
                    break;
            }


            SymbolsStats result = new SymbolsStats()
            {
                countOfBrackets = Brackets,
                countOfCurlyBrackets = CurlyBrackets,
                countOfSquareBrackets = SquareBrackets,
                unbalanced = !balanced

            };

            return result;
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

