using System;

namespace Lexic
{
    class Lexema
    {
        /// <summary>
        /// Оператор cin / cout
        /// </summary>
        public static bool IsOperator(string text)
        {
            return (text == "cout" || text == "cin" || text == "endl");
        }

        /// <summary>
        /// Арифметический Оператор
        /// </summary>
        public static bool IsArithmOperator(string text)
        {
            return (text == "<" || text == ">" || text == "==" || text == "=" ||
                    text == "+" || text == "-" || text == "*" || text == "/");
        }

        /// <summary>
        /// Число
        /// </summary>
        public static bool IsNumber(string text)
        {
            int x;
            return Int32.TryParse(text, out x);
        }

        /// <summary>
        /// Похоже на переменную
        /// </summary>
        public static bool CanBeVariable(string text)
        {
            bool CanBe = true;

            if (text.Length == 0 || !Char.IsLetter(text[0]))
                CanBe = false;
            else 
                foreach (char s in text)
                {
                    if (s != '_' && !Char.IsDigit(s) && !Char.IsLetter(s))
                        CanBe = false;
                }
            return CanBe;
        }

        /// <summary>
        /// ;
        /// </summary>
        public static bool IsSemicolon(string text)
        {
            return (text == ";");
        }

        /// <summary>
        /// Ввод-вывод
        /// </summary>
        public static bool IsIO(string text)
        {
            return (text == "<<" || text == ">>");
        }
        
        /// <summary>
        /// Скобка
        /// </summary>
        public static bool IsBracket(string text)
        {
            return (text == "(" || text == ")");
        }

        /// <summary>
        /// Условие
        /// </summary>
        public static bool IsIf(string text)
        {
            return (text == "if" || text == "else");
        }
    }
}
