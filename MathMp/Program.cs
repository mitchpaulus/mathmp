using Antlr4.Runtime.Tree;

namespace MathMp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

public enum MathMlStyle
{
    Word,
    Web,
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
