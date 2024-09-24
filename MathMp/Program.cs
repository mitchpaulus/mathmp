using System.Text;
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

        bool replaceCompile = false;

        while (i < args.Length)
        {
            var arg = args[i];
            i++;

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
            else if (arg == "compile")
            {
                replaceCompile = true;
                if (i < args.Length)
                {
                    filepath = args[i];
                    i++;
                }
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

        }

        if (filepath == null && !Console.IsInputRedirected)
        {
            PrintHelp();
            return 0;
        }


        if (replaceCompile)
        {
            string allContent = filepath is null ? Console.In.ReadToEnd() : File.ReadAllText(filepath!);

            Replacer r = new Replacer(allContent, MathMlStyle.Tex);
            var (success, output) = r.Replace();
            if (!success)
            {
                Console.Error.Write("Error compiling math formulas.\n");
                foreach (var e in r.ErrorListener.Messages)
                {
                    Console.Error.Write(e);
                    if (!e.EndsWith('\n')) Console.Error.Write('\n');
                }

                return 1;
            }

            Console.Write(output);
        }
        else
        {

            var stream = Console.IsInputRedirected ? new AntlrInputStream(Console.In) : new AntlrFileStream(filepath);

            ErrorListener errorListener = new();

            MathmpLexer lex = new MathmpLexer(stream);
            lex.RemoveErrorListeners();
            lex.AddErrorListener(errorListener);

            CommonTokenStream tokenStream = new CommonTokenStream(lex);
            MathmpParser parser = new MathmpParser(tokenStream);
            parser.RemoveErrorListeners();
            parser.AddErrorListener(errorListener);

            var tree = parser.file();

            if (errorListener.Messages.Any())
            {
                foreach (var errorMessage in errorListener.Messages)
                {
                    Console.Error.Write(errorMessage);
                    if (!errorMessage.EndsWith('\n')) Console.Error.Write('\n');
                }

                return 1;
            }

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

public class Greek
{
    public static Dictionary<string, string> Map = new()
    {
        { "del", "\u2202" },
        { "delta", "δ" },
        { "Delta", "Δ" },
        { "rho", "ρ"},
    };
}

public class Abbrevs
{
    public static Dictionary<string, string> Map = new()
    {
        { "approx", "\u2248" },
        { "cdot", "\u00B7" },
    };
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

    public override string VisitSuperscriptExp(MathmpParser.SuperscriptExpContext context)
    {
        return $"<msup>{Visit(context.expression(0))}{Visit(context.expression(1))}</msup>";
    }

    public override string VisitDotExp(MathmpParser.DotExpContext context) => $"<mover accent=\"true\">{Visit(context.expression())}<mo>.</mo></mover>";

    public override string VisitIdentifierExp(MathmpParser.IdentifierExpContext context)
    {
        StringBuilder b = new(context.GetText().Length * 10 + 14);
        b.Append("<mrow>");
        foreach (var c in context.GetText()) b.Append($"<mi>{c}</mi>");
        b.Append("</mrow>");
        return b.ToString();
    }

    public override string VisitDivExp(MathmpParser.DivExpContext context)
    {
        return $"<mfrac>{Visit(context.expression(0))}{Visit(context.expression(1))}</mfrac>";
    }

    public override string VisitBracedExp(MathmpParser.BracedExpContext context) => "<mrow>" +  string.Join("", context.expression().Select(Visit)) + "</mrow>";


    public override string VisitParenExp(MathmpParser.ParenExpContext context)
    {
        return _style == MathMlStyle.Word
            ? $"<mfenced><mrow>{string.Join("", context.expression().Select(Visit))}</mrow></mfenced>"
            : $"<mo>(</mo>{string.Join("", context.expression().Select(Visit))}<mo>)</mo>";
    }

    public override string VisitSquareExp(MathmpParser.SquareExpContext context)
    {
        return _style == MathMlStyle.Word
            ? $"<mfenced open=\"[\" close=\"]\"><mrow>{string.Join("", context.expression().Select(Visit))}</mrow></mfenced>"
            : $"<mo>[</mo>{string.Join("", context.expression().Select(Visit))}<mo>]</mo>";
    }

    public override string VisitNumberExp(MathmpParser.NumberExpContext context) => $"<mn>{context.GetText()}</mn>";

    public override string VisitGreekExp(MathmpParser.GreekExpContext context)
    {
        List<string> replacements = context.greek().GREEK().Select(g => Greek.Map.GetValueOrDefault(g.GetText(), "Not Implemented")).ToList();
        return $"<mi>{string.Join("", replacements)}</mi>";
    }

    public override string VisitSqrtExp(MathmpParser.SqrtExpContext context)
    {
        return $"<msqrt>{Visit(context.expression())}</msqrt>";
    }

    public override string VisitSquaredExp(MathmpParser.SquaredExpContext context)
    {
        return $"<msup>{Visit(context.expression())}<mn>2</mn></msup>";
    }

    public override string VisitAbbrevExp(MathmpParser.AbbrevExpContext context)
    {
        return $"<mo>{Abbrevs.Map[context.GetText()]}</mo>";
    }

    public override string VisitStringExp(MathmpParser.StringExpContext context)
    {
        return $"<mi mathvariant=\"normal\">{context.Contents()}</mi>";
    }

    public override string VisitSingleQuoteStrExp(MathmpParser.SingleQuoteStrExpContext context)
    {
        return $"<mi mathvariant=\"normal\">{context.GetText()[1..]}</mi>";
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
        return $"\\left({context.expression().Select(Visit)}\\right)";
    }

    public override string VisitNumberExp(MathmpParser.NumberExpContext context) => context.GetText();
}

public class ErrorListener : IAntlrErrorListener<IToken>, IAntlrErrorListener<int>
{
    public readonly List<string>  Messages = new();

    public void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
    {
        Messages.Add(msg);
    }

    public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
    {
        Messages.Add(msg);
    }
}

public static class Extensions
{
    public static string Contents(this MathmpParser.StringExpContext stringExpContext)
    {
        string text = stringExpContext.GetText();
        StringBuilder b = new StringBuilder(text.Length - 2);
        bool inEscape = false;
        for (int i = 1; i < text.Length - 1; i++)
        {
            if (inEscape)
            {
                if (text[i] == '\"')
                {
                    b.Append('\"');
                }
                else
                {
                    b.Append('\\');
                    b.Append(text[i]);
                }
            }
            else
            {
                if (text[i] == '\\')
                {
                    inEscape = true;
                }
                else
                {
                    b.Append(text[i]);
                }
            }
        }

        return b.ToString();
    }
}

public class Replacer
{
    private readonly string _allContent;
    private readonly MathmpLexer _lexer;
    private readonly CommonTokenStream _commonTokenStream;
    private readonly MathmpParser _parser;
    public readonly ErrorListener ErrorListener;
    private readonly MathMpVisitor _visitor;

    public Replacer(string allContent, MathMlStyle style)
    {
        _allContent = allContent;

        _lexer = new MathmpLexer(new AntlrInputStream(""));
        ErrorListener = new ErrorListener();
        _lexer.RemoveErrorListeners();
        _lexer.AddErrorListener(ErrorListener);
        CommonTokenStream tokenStream = new CommonTokenStream(_lexer);
        MathmpParser parser = new MathmpParser(tokenStream);
        parser.RemoveErrorListeners();
        parser.AddErrorListener(ErrorListener);
        _commonTokenStream = new CommonTokenStream(_lexer);
        _parser = new MathmpParser(_commonTokenStream);
        _visitor = new MathMpVisitor(style);
    }

    public (bool, string) Compile(string inputText)
    {
        _lexer.Reset();
        _lexer.SetInputStream(new AntlrInputStream(inputText));

        _commonTokenStream.SetTokenSource(_lexer);
        _parser.Reset();

        ErrorListener.Messages.Clear();
        var tree = _parser.math();

        if (ErrorListener.Messages.Any()) return (false, "");

        StringBuilder b = new StringBuilder();
        b.Append(_visitor.Visit(tree));

        return (true, b.ToString());
    }

    public (bool, string) Replace()
    {
        // _lexer.SetInputStream();
        StringBuilder b = new StringBuilder(_allContent.Length * 2);
        bool inFormula = false;

        StringBuilder currentFormula = new StringBuilder(200);
        foreach (var c in _allContent)
        {
            if (inFormula)
            {
                if (c == '`')
                {
                    inFormula = false;
                    // Compute formula for replacement.
                    (var success, string replacement) = Compile(currentFormula.ToString());
                    if (!success) return (false, "");
                    b.Append(replacement);
                    currentFormula.Clear();
                }
                else
                {
                    currentFormula.Append(c);
                }
            }
            else
            {
                if (c == '`')
                {
                    inFormula = true;
                }
                else
                {
                    b.Append(c);
                }
            }
        }

        return (true, b.ToString());
    }
}
