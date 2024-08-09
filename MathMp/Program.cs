using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace MathMp;

class Program
{
    static int Main(string[] args)
    {
        int i = 0;

        string? filepath = null;

        MathMlStyle style = MathMlStyle.Web;

        while (i < args.Length)
        {
            var arg = args[i];
            if (arg == "--help")
            {
                PrintHelp();
            }
            else if (arg == "--word")
            {
                style = MathMlStyle.Word;
            }
            else if (arg == "--tex")
            {
                style = MathMlStyle.Tex;
            }
            else
            {
                filepath = arg;
                if (i != args.Length - 1)
                {
                    Console.Error.Write("More than one filepath was provided.\n");
                    return 1;
                }
            }

            i++;
        }

        if (filepath == null && !Console.IsInputRedirected)
        {
            PrintHelp();
            return 0;
        }

        var stream = Console.IsInputRedirected ? new AntlrInputStream(Console.In) : new AntlrFileStream(filepath);

        MathmpLexer lex = new MathmpLexer(stream);
        CommonTokenStream tokenStream = new CommonTokenStream(lex);
        MathmpParser parser = new MathmpParser(tokenStream);

        var tree = parser.file();

        MathmpBaseVisitor<string> visitor;
        if (style == MathMlStyle.Tex)
        {
            visitor = new TexVisitor();
        }
        else
        {
            visitor = new MathMpVisitor(style);
        }

        // MathMpVisitor visitor = new MathMpVisitor(style);

        foreach (var mathLine in tree.math())
        {
            string output = visitor.Visit(mathLine);
            Console.Write(output);
            Console.Write('\n');
        }

        return 0;
    }

    public static void PrintHelp()
    {
         Console.Write("mathmp [--word|--tex] FILEPATH\n");
         Console.Write("\n");
         Console.Write("OPTIONS\n");
         Console.Write(" --word  Print to MathML that MS Word understands\n");
         Console.Write(" --tex   Print to Tex format\n");
    }
}

public enum MathMlStyle
{
    Word,
    Web,
    Tex,
}

public class MathMpVisitor : MathmpBaseVisitor<string>
{
    private readonly MathMlStyle _style;

    public MathMpVisitor(MathMlStyle style)
    {
        _style = style;
    }

    public override string VisitOperatorExp(MathmpParser.OperatorExpContext context)
    {
        return $"<mo>{context.GetText()}</mo>";
    }

    public override string VisitMath(MathmpParser.MathContext context)
    {
        var contents = context.expression().Select(Visit);
        var joined = string.Join("", contents);
        return $"<math xmlns=\"http://www.w3.org/1998/Math/MathML\">{joined}</math>";
    }

    public override string VisitSubscriptExp(MathmpParser.SubscriptExpContext context)
    {
        return $"<msub>{Visit(context.expression(0))}{Visit(context.expression(1))}</msub>";
    }

    public override string VisitDotExp(MathmpParser.DotExpContext context) => $"<mover accent=\"true\">{Visit(context.expression())}<mo>.</mo></mover>";

    public override string VisitIdentifierExp(MathmpParser.IdentifierExpContext context) => $"<mo>{context.GetText()}</mo>";

    public override string VisitDivExp(MathmpParser.DivExpContext context)
    {
        return $"<mfrac>{Visit(context.expression(0))}{Visit(context.expression(1))}</mfrac>";
    }

    public override string VisitBracedExp(MathmpParser.BracedExpContext context) => "<mrow>" +  string.Join("", context.expression().Select(Visit)) + "</mrow>";


    public override string VisitParenExp(MathmpParser.ParenExpContext context)
    {
        return _style == MathMlStyle.Word
            ? $"<mfenced><mrow>{Visit(context.expression())}</mrow></mfenced>"
            : $"<mo>(</mo>{Visit(context.expression())}<mo>)</mo>";
    }
}

public class TexVisitor : MathmpBaseVisitor<string>
{

    public override string VisitOperatorExp(MathmpParser.OperatorExpContext context)
    {
        return context.GetText();
    }

    public override string VisitMath(MathmpParser.MathContext context)
    {
        var contents = context.expression().Select(Visit);
        var joined = string.Join("", contents);
        return $"\\[{joined}\\]";
    }

    public override string VisitSubscriptExp(MathmpParser.SubscriptExpContext context)
    {
        return $"{{{Visit(context.expression(0))}}}_{{{Visit(context.expression(1))}}}";
    }

    public override string VisitDotExp(MathmpParser.DotExpContext context) => $"\\dot{{{Visit(context.expression())}}}";

    public override string VisitIdentifierExp(MathmpParser.IdentifierExpContext context) => context.GetText();

    public override string VisitDivExp(MathmpParser.DivExpContext context)
    {
        return $"\\frac{{{Visit(context.expression(0))}}}{{{Visit(context.expression(1))}}}";
    }

    public override string VisitBracedExp(MathmpParser.BracedExpContext context) => "{" + string.Join("", context.expression().Select(Visit)) + "}";


    public override string VisitParenExp(MathmpParser.ParenExpContext context)
    {
        return $"\\left({Visit(context.expression())}\\right)";
    }
}
