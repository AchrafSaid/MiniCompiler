using System.Collections.Specialized;

namespace MiniCompiler
{
    public partial class Form1 : Form
    {
        string[] identifiers = { "int", "float", "string","double","char","bool" };
        string[] operators ={"+", "-", "/", "%", "*","&&", "||", "<", ">", "=", "!"};
        string[] brackets ={"(", ")", "{", "}"};
        string[] punctuation ={",", ";"};
        string[] reservedWords ={"for", "while", "if", "do","return", "break", "continue", "end"};


        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = textBox1.Text;

        }
    }
}
