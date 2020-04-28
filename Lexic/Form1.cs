using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lexic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Части
        /// </summary>
        Dictionary<string, string> parts = new Dictionary<string, string>();

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                parts = new Dictionary<string, string>();

                int i = 0;
                string subText = "";
                foreach (char s in textBox1.Text + " ")
                {
                    if (Lexema.IsOperator(subText) &&
                        (s == ' ' || s == '<' || s == '>' || s == ';'))
                    {
                        i++;
                        parts.Add(i.ToString() + " " + subText, "Operator");
                        subText = "";
                    }
                    else if (Lexema.IsArithmOperator(subText) &&
                        (s == ' ' || s == '(' || Char.IsDigit(s) || Char.IsLetter(s)))
                    {
                        i++;
                        parts.Add(i.ToString() + " " + subText, "Oper");
                        subText = "";
                    }
                    else if (Lexema.IsNumber(subText) &&
                        (s == ' ' || s == ';' || s == ')'))
                    {
                        i++;
                        parts.Add(i.ToString() + " " + subText, "Number");
                        subText = "";
                    }
                    else if (Lexema.CanBeVariable(subText) &&
                        !Lexema.IsOperator(subText) &&
                        (s == ' ' || s == '<' || s == '>' || s == ';' ||
                        s == '+' || s == '-' || s == '*' || s == '/'))
                    {
                        i++;
                        parts.Add(i.ToString() + " " + subText, "Variable");
                        subText = "";
                    }
                    else if (Lexema.IsSemicolon(subText))
                    {
                        i++;
                        parts.Add(i.ToString() + " " + subText, "Semicolon");
                        subText = "";
                    }
                    else if (Lexema.IsIO(subText))
                    {
                        i++;
                        parts.Add(i.ToString() + " " + subText, "IO");
                        subText = "";
                    }
                    else if (Lexema.IsBracket(subText))
                    {
                        i++;
                        parts.Add(i.ToString() + " " + subText, "Bracket");
                        subText = "";
                    }
                    else if (Lexema.IsIf(subText) &&
                        (s == ' ' || s == '('))
                    {
                        i++;
                        parts.Add(i.ToString() + " " + subText, "If");
                        subText = "";
                    }
                    else if (subText == Environment.NewLine || subText == " ")
                    {
                        subText = "";
                    }

                    subText += s;
                }




                textBox2.Clear();
                foreach (KeyValuePair<string, string> pair in parts)
                {
                    textBox2.Text += Environment.NewLine + 
                        pair.Key.PadRight(20) + " " + pair.Value;
                }
            }
        }
    }
}
