using System.Text;
using Antlr4.Runtime;
using MathMpLib;

namespace MathMpVba;

class Program
{
    static int Main(string[] args)
    {
        string inputFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.Create) + "\\MathMp\\input.mp";

        ErrorListener errorListener = new();
        AntlrFileStream stream = new AntlrFileStream(inputFile);
        MathmpLexer lex = new MathmpLexer(stream);
        lex.RemoveErrorListeners();
        lex.AddErrorListener(errorListener);
        CommonTokenStream tokenStream = new CommonTokenStream(lex);
        MathmpParser parser = new MathmpParser(tokenStream);
        parser.RemoveErrorListeners();
        parser.AddErrorListener(errorListener);
        var tree = parser.file();
        string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string mathMpDir = Path.Combine(localAppData, "MathMp");

        if (errorListener.Messages.Any())
        {
            StringBuilder b = new StringBuilder();
            foreach (var errorMessage in errorListener.Messages)
            {
                b.AppendLine(errorMessage);
                if (!errorMessage.EndsWith('\n')) b.Append('\n');
            }

            File.WriteAllText(mathMpDir + "\\error.log", b.ToString());
            return 1;
        }

        MathmpBaseVisitor<string> visitor = new MathMpVisitor(MathMlStyle.Word);

        // MathMpVisitor visitor = new MathMpVisitor(style);
        StringBuilder outBuilder = new StringBuilder();
        foreach (var mathLine in tree.math())
        {
            string output = visitor.Visit(mathLine);
            outBuilder.Append(output);
            outBuilder.Append('\n');
        }
        File.WriteAllText(mathMpDir + "\\output.txt", outBuilder.ToString());

        return 0;

    }
}
