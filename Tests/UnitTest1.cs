using Antlr4.Runtime;
using MathMp;

namespace Tests;

public class Tests
{
    [Test]
    public void Test1()
    {
        string input = "T.plen = ({ dot V.tot T.dis - dot V.pri T.sa }/ { dot V.tot - dot V.pri }) \n";


        AntlrInputStream stream = new AntlrInputStream(input);
        MathmpLexer lex = new MathmpLexer(stream);
        CommonTokenStream tokenStream = new CommonTokenStream(lex);
        MathmpParser parser = new MathmpParser(tokenStream);

        var tree = parser.math();

        MathMpVisitor visitor = new MathMpVisitor(MathMlStyle.Word);

        string output = visitor.Visit(tree);

        Console.WriteLine(output);
    }
}
