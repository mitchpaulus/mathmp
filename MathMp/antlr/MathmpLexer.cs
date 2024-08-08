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

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public partial class MathmpLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, CARET=2, LPAREN=3, RPAREN=4, LBRACE=5, RBRACE=6, OPERATOR=7, FORWARDSLASH=8, 
		DOT=9, SQRT=10, IDENTIFIER=11, PERIOD=12, NUMBER=13, WS=14;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "CARET", "LPAREN", "RPAREN", "LBRACE", "RBRACE", "OPERATOR", "FORWARDSLASH", 
		"DOT", "SQRT", "IDENTIFIER", "PERIOD", "NUMBER", "WS"
	};


	public MathmpLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public MathmpLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'\\n'", "'^'", "'('", "')'", "'{'", "'}'", null, "'/'", "'dot'", 
		"'sqrt'", null, "'.'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, "CARET", "LPAREN", "RPAREN", "LBRACE", "RBRACE", "OPERATOR", 
		"FORWARDSLASH", "DOT", "SQRT", "IDENTIFIER", "PERIOD", "NUMBER", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Mathmp.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static MathmpLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,14,79,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,6,
		2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,1,0,1,
		0,1,1,1,1,1,2,1,2,1,3,1,3,1,4,1,4,1,5,1,5,1,6,1,6,1,7,1,7,1,8,1,8,1,8,
		1,8,1,9,1,9,1,9,1,9,1,9,1,10,4,10,56,8,10,11,10,12,10,57,1,11,1,11,1,12,
		4,12,63,8,12,11,12,12,12,64,1,12,1,12,4,12,69,8,12,11,12,12,12,70,1,13,
		4,13,74,8,13,11,13,12,13,75,1,13,1,13,0,0,14,1,1,3,2,5,3,7,4,9,5,11,6,
		13,7,15,8,17,9,19,10,21,11,23,12,25,13,27,14,1,0,5,4,0,40,41,43,43,45,
		45,61,61,2,0,65,90,97,122,1,0,48,57,3,0,46,46,48,48,57,57,3,0,9,10,13,
		13,32,32,82,0,1,1,0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,
		0,0,11,1,0,0,0,0,13,1,0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,0,0,0,0,21,
		1,0,0,0,0,23,1,0,0,0,0,25,1,0,0,0,0,27,1,0,0,0,1,29,1,0,0,0,3,31,1,0,0,
		0,5,33,1,0,0,0,7,35,1,0,0,0,9,37,1,0,0,0,11,39,1,0,0,0,13,41,1,0,0,0,15,
		43,1,0,0,0,17,45,1,0,0,0,19,49,1,0,0,0,21,55,1,0,0,0,23,59,1,0,0,0,25,
		62,1,0,0,0,27,73,1,0,0,0,29,30,5,10,0,0,30,2,1,0,0,0,31,32,5,94,0,0,32,
		4,1,0,0,0,33,34,5,40,0,0,34,6,1,0,0,0,35,36,5,41,0,0,36,8,1,0,0,0,37,38,
		5,123,0,0,38,10,1,0,0,0,39,40,5,125,0,0,40,12,1,0,0,0,41,42,7,0,0,0,42,
		14,1,0,0,0,43,44,5,47,0,0,44,16,1,0,0,0,45,46,5,100,0,0,46,47,5,111,0,
		0,47,48,5,116,0,0,48,18,1,0,0,0,49,50,5,115,0,0,50,51,5,113,0,0,51,52,
		5,114,0,0,52,53,5,116,0,0,53,20,1,0,0,0,54,56,7,1,0,0,55,54,1,0,0,0,56,
		57,1,0,0,0,57,55,1,0,0,0,57,58,1,0,0,0,58,22,1,0,0,0,59,60,5,46,0,0,60,
		24,1,0,0,0,61,63,7,2,0,0,62,61,1,0,0,0,63,64,1,0,0,0,64,62,1,0,0,0,64,
		65,1,0,0,0,65,66,1,0,0,0,66,68,5,46,0,0,67,69,7,3,0,0,68,67,1,0,0,0,69,
		70,1,0,0,0,70,68,1,0,0,0,70,71,1,0,0,0,71,26,1,0,0,0,72,74,7,4,0,0,73,
		72,1,0,0,0,74,75,1,0,0,0,75,73,1,0,0,0,75,76,1,0,0,0,76,77,1,0,0,0,77,
		78,6,13,0,0,78,28,1,0,0,0,5,0,57,64,70,75,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
