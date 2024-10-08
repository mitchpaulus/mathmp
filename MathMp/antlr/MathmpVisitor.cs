//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Mathmp.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="MathmpParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public interface IMathmpVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="MathmpParser.file"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFile([NotNull] MathmpParser.FileContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MathmpParser.math"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMath([NotNull] MathmpParser.MathContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>IdentifierExp</c>
	/// labeled alternative in <see cref="MathmpParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifierExp([NotNull] MathmpParser.IdentifierExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>SuperscriptExp</c>
	/// labeled alternative in <see cref="MathmpParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSuperscriptExp([NotNull] MathmpParser.SuperscriptExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>OperatorExp</c>
	/// labeled alternative in <see cref="MathmpParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOperatorExp([NotNull] MathmpParser.OperatorExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>StringExp</c>
	/// labeled alternative in <see cref="MathmpParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStringExp([NotNull] MathmpParser.StringExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>SquaredExp</c>
	/// labeled alternative in <see cref="MathmpParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSquaredExp([NotNull] MathmpParser.SquaredExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>SqrtExp</c>
	/// labeled alternative in <see cref="MathmpParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSqrtExp([NotNull] MathmpParser.SqrtExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>SquareExp</c>
	/// labeled alternative in <see cref="MathmpParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSquareExp([NotNull] MathmpParser.SquareExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>GreekExp</c>
	/// labeled alternative in <see cref="MathmpParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGreekExp([NotNull] MathmpParser.GreekExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>DivExp</c>
	/// labeled alternative in <see cref="MathmpParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDivExp([NotNull] MathmpParser.DivExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>DotExp</c>
	/// labeled alternative in <see cref="MathmpParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDotExp([NotNull] MathmpParser.DotExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>SubscriptExp</c>
	/// labeled alternative in <see cref="MathmpParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSubscriptExp([NotNull] MathmpParser.SubscriptExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>ParenExp</c>
	/// labeled alternative in <see cref="MathmpParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParenExp([NotNull] MathmpParser.ParenExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>BracedExp</c>
	/// labeled alternative in <see cref="MathmpParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBracedExp([NotNull] MathmpParser.BracedExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>SingleQuoteStrExp</c>
	/// labeled alternative in <see cref="MathmpParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSingleQuoteStrExp([NotNull] MathmpParser.SingleQuoteStrExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>NumberExp</c>
	/// labeled alternative in <see cref="MathmpParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumberExp([NotNull] MathmpParser.NumberExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>AbbrevExp</c>
	/// labeled alternative in <see cref="MathmpParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAbbrevExp([NotNull] MathmpParser.AbbrevExpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MathmpParser.operator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOperator([NotNull] MathmpParser.OperatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MathmpParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifier([NotNull] MathmpParser.IdentifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MathmpParser.number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumber([NotNull] MathmpParser.NumberContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MathmpParser.greek"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGreek([NotNull] MathmpParser.GreekContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MathmpParser.abbrev"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAbbrev([NotNull] MathmpParser.AbbrevContext context);
}
