namespace MathMpLib;

public class MathMpRtfVisitor : MathmpBaseVisitor<string>
{
    private static readonly Dictionary<string, int> GreekUnicode = new()
    {
        { "del", 0x2202 },
        { "alpha", 0x03B1 },
        { "beta", 0x03B2 },
        { "gamma", 0x03B3 },
        { "delta", 0x03B4 },
        { "Delta", 0x0394 },
        { "rho", 0x03C1 },
        { "nu", 0x03BD },
        { "eta", 0x03B7 },
        { "omega", 0x03C9 },
        { "Sigma", 0x03A3 },
    };

    private static readonly Dictionary<string, int> AbbrevUnicode = new()
    {
        { "approx", 0x2248 },
        { "cdot", 0x22C5 },
    };

    private static string Uni(int codePoint) => $"\\u{codePoint}?";

    // Italic math run (for variables/identifiers) - matches Word's format
    private static string Run(string text) => $"{{\\i {{\\mr\\mscr0\\msty2 {text}}}}}";

    // Normal/upright math run (for numbers, operators, text)
    private static string NormalRun(string text) => $"{{{{\\mr\\mscr0\\msty0 {text}}}}}";

    // Control properties for structure elements (fractions, sub/superscripts, etc.)
    private const string CtrlPr = "{\\mctrlPr\\i }";

    public override string VisitMath(MathmpParser.MathContext context)
    {
        var inner = string.Join("", context.expression().Select(Visit));
        return $"{{\\mmath{{\\*\\moMathPara {{\\*\\moMath {inner}}}}}}}";
    }

    public override string VisitIdentifierExp(MathmpParser.IdentifierExpContext context)
    {
        var text = context.GetText();
        return string.Join("", text.Select(c => Run(c.ToString())));
    }

    public override string VisitNumberExp(MathmpParser.NumberExpContext context) =>
        NormalRun(context.GetText());

    public override string VisitOperatorExp(MathmpParser.OperatorExpContext context) =>
        NormalRun(context.GetText());

    public override string VisitDivExp(MathmpParser.DivExpContext context)
    {
        var num = Visit(context.expression(0));
        var den = Visit(context.expression(1));
        return $"{{\\mf{{\\mfPr{CtrlPr}}}{{\\mnum {num}}}{{\\mden {den}}}}}";
    }

    public override string VisitSuperscriptExp(MathmpParser.SuperscriptExpContext context)
    {
        var baseExpr = Visit(context.expression(0));
        var supExpr = Visit(context.expression(1));
        return $"{{\\msSup{{\\msSupPr{CtrlPr}}}{{\\me {baseExpr}}}{{\\msup {supExpr}}}}}";
    }

    public override string VisitSubscriptExp(MathmpParser.SubscriptExpContext context)
    {
        var baseExpr = Visit(context.expression(0));
        var subExpr = Visit(context.expression(1));
        return $"{{\\msSub{{\\msSubPr{CtrlPr}}}{{\\me {baseExpr}}}{{\\msub {subExpr}}}}}";
    }

    public override string VisitSquaredExp(MathmpParser.SquaredExpContext context)
    {
        var baseExpr = Visit(context.expression());
        return $"{{\\msSup{{\\msSupPr{CtrlPr}}}{{\\me {baseExpr}}}{{\\msup {NormalRun("2")}}}}}";
    }

    public override string VisitSqrtExp(MathmpParser.SqrtExpContext context)
    {
        var expr = Visit(context.expression());
        return $"{{\\mrad{{\\mradPr{{\\mdegHide1}}{CtrlPr}}}{{\\mdeg}}{{\\me {expr}}}}}";
    }

    public override string VisitDotExp(MathmpParser.DotExpContext context)
    {
        string opTypeText = context.OpType.Text;
        int charCode = opTypeText switch
        {
            "dot" => 0x0307,
            "hat" => 0x0302,
            "bar" => 0x0305,
            _ => throw new Exception($"We don't handle the op type {opTypeText} yet.")
        };

        var expr = Visit(context.expression());
        return $"{{\\macc{{\\maccPr{{\\mchr {Uni(charCode)}}}{CtrlPr}}}{{\\me {expr}}}}}";
    }

    public override string VisitParenExp(MathmpParser.ParenExpContext context)
    {
        var inner = string.Join("", context.expression().Select(Visit));
        return $"{{\\md{{\\mdPr{CtrlPr}}}{{\\me {inner}}}}}";
    }

    public override string VisitSquareExp(MathmpParser.SquareExpContext context)
    {
        var inner = string.Join("", context.expression().Select(Visit));
        return $"{{\\md{{\\mdPr{{\\mbegChr [}}{{\\mendChr ]}}{CtrlPr}}}{{\\me {inner}}}}}";
    }

    public override string VisitBracedExp(MathmpParser.BracedExpContext context) =>
        string.Join("", context.expression().Select(Visit));

    public override string VisitGreekExp(MathmpParser.GreekExpContext context)
    {
        var text = context.greek().GetText();
        if (GreekUnicode.TryGetValue(text, out int codePoint))
        {
            return text == "Sigma"
                ? NormalRun(Uni(codePoint))
                : Run(Uni(codePoint));
        }

        return Run("?");
    }

    public override string VisitAbbrevExp(MathmpParser.AbbrevExpContext context)
    {
        if (AbbrevUnicode.TryGetValue(context.GetText(), out int codePoint))
        {
            return NormalRun(Uni(codePoint));
        }

        return NormalRun("?");
    }

    public override string VisitStringExp(MathmpParser.StringExpContext context) =>
        NormalRun(context.Contents());

    public override string VisitSingleQuoteStrExp(MathmpParser.SingleQuoteStrExpContext context) =>
        NormalRun(context.GetText()[1..]);

    public override string VisitSumExp(MathmpParser.SumExpContext context)
    {
        var lower = Visit(context.expression(0));
        var upper = Visit(context.expression(1));
        return $"{{\\mnary{{\\mnaryPr{{\\mchr {Uni(0x2211)}}}{CtrlPr}}}{{\\msub {lower}}}{{\\msup {upper}}}{{\\me}}}}";
    }
}
