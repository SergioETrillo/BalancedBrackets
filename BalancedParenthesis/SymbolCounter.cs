using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedParenthesis
{
    public class SymbolCounter
    {
        internal int Brackets { get; set; }
        internal int CurlyBrackets { get; set; }
        internal int SquareBrackets { get; set; }

        private Stack<char> symbols { get; set; }

        public SymbolCounter()
        {
            Brackets = 0;
            CurlyBrackets = 0;
            SquareBrackets = 0;
            symbols = new Stack<char>();
        }

        public void ProcessOpeningSymbol(char c)
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
        }

        public bool ProcessClosingSymbol(char c)
        {
            bool balanced = true;

            if (symbols.Count == 0)
                return false;

            char CurrentSymbol = symbols.Pop();
            if (!MatchingSymbol(CurrentSymbol, c))
                return false;

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

            return balanced;
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

