using System.Text;
using Antlr4.Runtime;

namespace MathMpLib;

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
        { "del", "&#x2202;" },
        { "delta", "&#x03B4;" },
        { "Delta", "&#x0394;" },
        { "rho", "&#x03C1;"},
        { "nu", "&#x03BD;"},
        { "eta", "&#x03B7;"},
        { "omega", "&#x03C9;"},
        { "Sigma", "&#x03A3;"},
    };
}

public class Abbrevs
{
    public static Dictionary<string, string> Map = new()
    {
        { "approx", "&#x2248;" },
        { "cdot", "&#x22C5;" },
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
        return _style == MathMlStyle.Word
            ? $"<math xmlns=\"http://www.w3.org/1998/Math/MathML\">{joined}</math>"
            : $"<math xmlns=\"http://www.w3.org/1998/Math/MathML\"><mstyle displaystyle=\"true\">{joined}</mstyle></math>";
    }

    public override string VisitSubscriptExp(MathmpParser.SubscriptExpContext context)
    {
        return $"<msub>{Visit(context.expression(0))}{Visit(context.expression(1))}</msub>";
    }

    public override string VisitSuperscriptExp(MathmpParser.SuperscriptExpContext context)
    {
        return $"<msup>{Visit(context.expression(0))}{Visit(context.expression(1))}</msup>";
    }

    public override string VisitDotExp(MathmpParser.DotExpContext context)
    {
        string opTypeText = context.OpType.Text;

        string charText;
        if (opTypeText == "dot")
        {
            charText = ".";
        }
        else if (opTypeText == "hat")
        {
            charText = "^";
        }
        else if (opTypeText == "bar")
        {
            charText = "&#xAF;";
        }
        else
        {
            throw new Exception("We don't handle the op type {opTypeText} yet.");
        }

        return _style == MathMlStyle.Word
           ? $"<mover accent=\"true\">{Visit(context.expression())}<mo>{charText}</mo></mover>"
           : $"<mover>{Visit(context.expression())}<mo>{charText}</mo></mover>";
    }

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
            : $"<mrow><mo>(</mo>{string.Join("", context.expression().Select(Visit))}<mo>)</mo></mrow>";
    }

    public override string VisitSquareExp(MathmpParser.SquareExpContext context)
    {
        return _style == MathMlStyle.Word
            ? $"<mfenced open=\"[\" close=\"]\"><mrow>{string.Join("", context.expression().Select(Visit))}</mrow></mfenced>"
            : $"<mrow><mo>[</mo>{string.Join("", context.expression().Select(Visit))}<mo>]</mo></mrow>";
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
        return $"\\left({string.Join("", context.expression().Select(Visit))}\\right)";
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
    private readonly MathmpBaseVisitor<string> _visitor;

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
        if (style == MathMlStyle.Tex)
        {
            _visitor = new TexVisitor();
        }
        else
        {
            _visitor = new MathMpVisitor(style);
        }
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
