using System.Collections.Specialized;

namespace MiniCompiler
{
    public partial class Form1 : Form
    {
        string[] identifiers = { "int", "float", "string", "double", "char", "bool" };
        string[] operators = { "+", "-", "/", "%", "*", "&&", "||", "<", ">", "=", "!" };
        string[] brackets = { "(", ")", "{", "}" };
        string[] punctuation = { ",", ";" };
        string[] reservedWords = { "for", "while", "if", "do", "return", "break", "continue", "end" };

        int loc = 0;
        string abudubi="";
        public Form1()
        {
            InitializeComponent();

        }
        int intf = 5;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        string goodjob="";
        private void button1_Click(object sender, EventArgs e)
        {
            string code = textBox1.Text+" ";
            bool sympol = false;
           // MessageBox.Show(code);
            for (int i = 0; i <code.Length; i++)
            {
                //
                sympol = false;
                if (code[i] != ' ' && code[i] != '\n' && code[i] != '\r')
                {
                    for(int j = 0; j < operators.Length; j++)
                    {
                        if (""+code[i] == operators[j])
                        {
                            sympol = true;
                            break;
                        }
                    }
                    for (int j = 0; j < brackets.Length; j++)
                    {
                        if (""+code[i] == brackets[j])
                        {
                            sympol = true;
                            break;
                        }
                    }
                    for (int j = 0; j < punctuation.Length; j++)
                    {
                        if (""+code[i] == punctuation[j])
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

                        if(goodjob==""&&abudubi!="")
                        {
                            goodjob = "Variable";
                        }
                        
                        if(abudubi!= "")
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
                    for (int n=0;n< identifiers.Length;n++)
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
                    if (goodjob == "" && abudubi != "")
                    {
                        goodjob = "Variable";
                    }
                    if(goodjob !=  "")
                    {
                    listBox1.Items.Add(abudubi+" is "+goodjob);
                    }
                    abudubi = "";
                    
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
