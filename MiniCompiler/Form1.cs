using System.Collections.Specialized;
using System.Reflection.Emit;

namespace MiniCompiler
{
    public partial class Form1 : Form
    {
        string[] identifiers = { "int", "float", "string", "double", "char", "bool" };
        string[] operators = { "+", "-", "/", "%", "*", "&&", "||", "<", ">", "=", "!" };
        string[] brackets = { "(", ")", "{", "}" };
        string[] punctuation = { ",", ";" };
        string[] reservedWords = { "for", "while", "if", "do", "return", "break", "continue", "end" };

        string abudubi = "";
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            StyleUI();

        }
        void StyleUI()
        {
            this.BackColor = Color.FromArgb(24, 24, 36);

            int margin = 100;
            int spacing = 60;

            int totalWidth = this.ClientSize.Width - (margin * 2) - spacing;
            int halfWidth = totalWidth / 2;

            int height = this.ClientSize.Height - 120;

            label1.Text = "Source Code";
            label2.Text = "Tokens Output";

            label1.ForeColor = Color.FromArgb(180, 180, 200);
            label2.ForeColor = Color.FromArgb(180, 180, 200);

            label1.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            label2.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            label1.Left = margin;
            label1.Top = 20;

            textBox1.Left = margin;
            textBox1.Top = label1.Bottom + 10;
            textBox1.Width = halfWidth;
            textBox1.Height = height;

            textBox1.BackColor = Color.FromArgb(32, 32, 48);
            textBox1.ForeColor = Color.White;
            textBox1.Font = new Font("Consolas", 18);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Multiline = true;
            textBox1.ScrollBars = ScrollBars.Vertical;

            label2.Left = textBox1.Right + spacing;
            label2.Top = 20;

            listBox1.Left = textBox1.Right + spacing;
            listBox1.Top = label2.Bottom + 10;
            listBox1.Width = halfWidth;
            listBox1.Height = height;

            listBox1.BackColor = Color.FromArgb(32, 32, 48);
            listBox1.ForeColor = Color.LightGreen;
            listBox1.Font = new Font("Consolas", 18);
            listBox1.BorderStyle = BorderStyle.None;

            button1.Text = "Run";
            button1.BackColor = Color.FromArgb(0, 122, 204);
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

            button1.Width = 100;
            button1.Height = 35;

            button1.Left = this.ClientSize.Width - button1.Width - margin;
            button1.Top = this.ClientSize.Height - button1.Height - 20 - 20;

            // Hover
            button1.MouseEnter += (s, e) =>
                button1.BackColor = Color.FromArgb(30, 144, 255);

            button1.MouseLeave += (s, e) =>
                button1.BackColor = Color.FromArgb(0, 122, 204);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void Scanner(string code)
        {
            string goodjob = "";
            bool sympol = false;
            for (int i = 0; i < code.Length; i++)
            {
                sympol = false;
                if (code[i] != ' ' && code[i] != '\n' && code[i] != '\r')
                {
                    for (int j = 0; j < operators.Length; j++)
                    {
                        if ("" + code[i] == operators[j])
                        {
                            sympol = true;
                            break;
                        }
                    }
                    for (int j = 0; j < brackets.Length; j++)
                    {
                        if ("" + code[i] == brackets[j])
                        {
                            sympol = true;
                            break;
                        }
                    }
                    for (int j = 0; j < punctuation.Length; j++)
                    {
                        if ("" + code[i] == punctuation[j])
                        {
                            sympol = true;
                            break;
                        }
                    }
                    if (sympol)
                    {
                        goodjob = "";
                        for (int n = 0; n < identifiers.Length; n++)
                        {
                            if (abudubi == identifiers[n])
                            {
                                goodjob = "identifier";
                                break;
                            }

                        }
                        for (int n = 0; n < reservedWords.Length; n++)
                        {
                            if (abudubi == reservedWords[n])
                            {
                                goodjob = "reservedWord";
                                break;
                            }
                        }
                        bool isNumber = true;
                        for (int k = 0; k < abudubi.Length; k++)
                        {
                            if (abudubi[k] < '0' || abudubi[k] > '9')
                            {
                                isNumber = false;
                                break;
                            }
                        }

                        if (goodjob == "" && abudubi != "")
                        {
                            if (isNumber)
                            {
                                goodjob = "Number";
                            }
                            else
                            {
                                goodjob = "Variable";
                            }
                        }

                        if (abudubi != "")
                        {
                            listBox1.Items.Add(abudubi + " is " + goodjob);
                        }
                        abudubi = "";

                        abudubi = "" + code[i];
                        goodjob = "";
                        for (int n = 0; n < operators.Length; n++)
                        {
                            if (abudubi == operators[n])
                            {
                                goodjob = "operator";
                                break;
                            }
                        }
                        for (int n = 0; n < brackets.Length; n++)
                        {
                            if (abudubi == brackets[n])
                            {
                                goodjob = "bracket";
                                break;
                            }
                        }
                        for (int n = 0; n < punctuation.Length; n++)
                        {
                            if (abudubi == punctuation[n])
                            {
                                goodjob = "punctuation";
                                break;
                            }
                        }
                        listBox1.Items.Add(abudubi + " is " + goodjob);
                        abudubi = "";
                        sympol = false;
                    }
                    else
                    {
                        abudubi += code[i];
                    }
                }
                else
                {
                    //comparing
                    goodjob = "";
                    for (int n = 0; n < identifiers.Length; n++)
                    {
                        if (abudubi == identifiers[n])
                        {
                            goodjob = "identifier";
                            break;
                        }
                    }

                    for (int n = 0; n < operators.Length; n++)
                    {
                        if (abudubi == operators[n])
                        {
                            goodjob = "operator";
                            break;
                        }
                    }

                    for (int n = 0; n < brackets.Length; n++)
                    {
                        if (abudubi == brackets[n])
                        {
                            goodjob = "bracket";
                            break;
                        }
                    }

                    for (int n = 0; n < punctuation.Length; n++)
                    {
                        if (abudubi == punctuation[n])
                        {
                            goodjob = "punctuation";
                            break;
                        }
                    }

                    for (int n = 0; n < reservedWords.Length; n++)
                    {
                        if (abudubi == reservedWords[n])
                        {
                            goodjob = "reservedWord";
                            break;
                        }
                    }
                    bool isNum = true;
                    for (int k = 0; k < abudubi.Length; k++)
                    {
                        if (abudubi[k] < '0' || abudubi[k] > '9')
                        {
                            isNum = false;
                            break;
                        }
                    }

                    if (goodjob == "" && abudubi != "")
                    {
                        if (isNum)
                        {
                            goodjob = "Number";
                        }
                        else
                        {
                            goodjob = "Variable";
                        }
                    }
                    if (goodjob != "")
                    {
                        listBox1.Items.Add(abudubi + " is " + goodjob);
                    }
                    abudubi = "";

                }
            }
        }
        void SemanticAnalyzer(string code)
        {
            string[] token = new string[1000];
            int tokenCount = 0;
            string word = "";

            for (int i = 0; i < code.Length; i++)
            {
                if (code[i] == ' ' || code[i] == '\n' || code[i] == '\r' || code[i] == '\t')
                {
                    if (word != "")
                    {
                        token[tokenCount] = word;
                        tokenCount++;
                        word = "";
                    }
                }
                else
                {
                    string two = "";

                    if (i + 1 < code.Length)
                        two = "" + code[i] + code[i + 1];

                    if (two == "&&" || two == "||" || two == "==" || two == "!=" || two == "<=" || two == ">=")
                    {
                        if (word != "")
                        {
                            token[tokenCount] = word;
                            tokenCount++;
                            word = "";
                        }

                        token[tokenCount] = two;
                        tokenCount++;
                        i++;
                    }
                    else if (
                        code[i] == '+' || code[i] == '-' || code[i] == '*' || code[i] == '/' ||
                        code[i] == '%' || code[i] == '<' || code[i] == '>' || code[i] == '=' ||
                        code[i] == '!' || code[i] == '(' || code[i] == ')' || code[i] == '{' ||
                        code[i] == '}' || code[i] == ',' || code[i] == ';'
                    )
                    {
                        if (word != "")
                        {
                            token[tokenCount] = word;
                            tokenCount++;
                            word = "";
                        }

                        token[tokenCount] = "" + code[i];
                        tokenCount++;
                    }
                    else
                    {
                        word += code[i];
                    }
                }
            }

            if (word != "")
            {
                token[tokenCount] = word;
                tokenCount++;
            }

            int p = 0;
            int ifBlocks = 0;
            bool error = false;

            while (p < tokenCount && !error)
            {
                if (ifBlocks > 0 && token[p] == "{")
                {
                    ifBlocks++;
                    p++;
                }
                else if (ifBlocks > 0 && token[p] == "}")
                {
                    ifBlocks--;
                    p++;
                }
                else if (token[p] == "if")
                {
                    p++;

                    if (p >= tokenCount || token[p] != "(")
                    {
                        listBox1.Items.Add("Error: expected ( after if");
                        error = true;
                    }
                    else
                    {
                        p++;

                        if (p >= tokenCount || token[p] == ")")
                        {
                            listBox1.Items.Add("Error: expected condition inside if");
                            error = true;
                        }
                        else
                        {
                            while (p < tokenCount && token[p] != ")" && !error)
                            {
                                bool isNumber = true;
                                bool isVariable = true;

                                if (token[p] == "&&" || token[p] == "||" || token[p] == "==" ||
                                    token[p] == "!=" || token[p] == "<" || token[p] == ">" ||
                                    token[p] == "<=" || token[p] == ">=")
                                {
                                    isNumber = false;
                                    isVariable = false;
                                }

                                for (int x = 0; x < token[p].Length; x++)
                                {
                                    if (token[p][x] < '0' || token[p][x] > '9')
                                        isNumber = false;
                                }

                                if (token[p][0] >= '0' && token[p][0] <= '9')
                                    isVariable = false;

                                for (int x = 0; x < identifiers.Length; x++)
                                {
                                    if (token[p] == identifiers[x])
                                        isVariable = false;
                                }

                                for (int x = 0; x < reservedWords.Length; x++)
                                {
                                    if (token[p] == reservedWords[x])
                                        isVariable = false;
                                }

                                for (int x = 0; x < token[p].Length; x++)
                                {
                                    bool goodChar = false;

                                    if (token[p][x] >= 'a' && token[p][x] <= 'z')
                                        goodChar = true;

                                    if (token[p][x] >= 'A' && token[p][x] <= 'Z')
                                        goodChar = true;

                                    if (token[p][x] >= '0' && token[p][x] <= '9')
                                        goodChar = true;

                                    if (!goodChar)
                                        isVariable = false;
                                }

                                if (!isNumber && !isVariable)
                                {
                                    listBox1.Items.Add("Error: expected variable or number in if condition");
                                    error = true;
                                }
                                else
                                {
                                    p++;

                                    if (p >= tokenCount || !(token[p] == "==" || token[p] == "!=" ||
                                        token[p] == "<" || token[p] == ">" || token[p] == "<=" || token[p] == ">="))
                                    {
                                        listBox1.Items.Add("Error: expected relational operator in if condition");
                                        error = true;
                                    }
                                    else
                                    {
                                        p++;

                                        if (p >= tokenCount || token[p] == ")" || token[p] == "&&" || token[p] == "||")
                                        {
                                            listBox1.Items.Add("Error: expected value after relational operator");
                                            error = true;
                                        }
                                        else
                                        {
                                            p++;

                                            if (p < tokenCount && (token[p] == "&&" || token[p] == "||"))
                                            {
                                                p++;

                                                if (p >= tokenCount || token[p] == ")")
                                                {
                                                    listBox1.Items.Add("Error: expected condition after logical operator");
                                                    error = true;
                                                }
                                            }
                                            else if (p < tokenCount && token[p] != ")")
                                            {
                                                listBox1.Items.Add("Error: expected && or || or )");
                                                error = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if (!error)
                        {
                            if (p >= tokenCount || token[p] != ")")
                            {
                                listBox1.Items.Add("Error: expected ) after if condition");
                                error = true;
                            }
                            else
                            {
                                p++;

                                if (p >= tokenCount || token[p] != "{")
                                {
                                    listBox1.Items.Add("Error: expected { after if");
                                    error = true;
                                }
                                else
                                {
                                    ifBlocks++;
                                    p++;
                                }
                            }
                        }
                    }
                }
                else
                {
                    p++;
                }
            }

            if (!error)
            {
                if (ifBlocks != 0)
                    listBox1.Items.Add("Error: expected } after if block");
                else
                    listBox1.Items.Add("Semantic Analyzer: No IF Errors");
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string code = textBox1.Text + " ";
            Scanner(code);
            listBox1.Items.Add("-------------------------------------------");
            SemanticAnalyzer(code);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
   
        }
    }
}
