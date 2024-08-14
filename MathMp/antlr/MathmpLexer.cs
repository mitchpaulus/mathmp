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
		T__0=1, GREEK=2, CARET=3, LPAREN=4, RPAREN=5, LSQUARE=6, RSQUARE=7, LBRACE=8, 
		RBRACE=9, OPERATOR=10, FORWARDSLASH=11, DOT=12, SQRT=13, IDENTIFIER=14, 
		PERIOD=15, NUMBER=16, WS=17;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "GREEK", "CARET", "LPAREN", "RPAREN", "LSQUARE", "RSQUARE", "LBRACE", 
		"RBRACE", "OPERATOR", "FORWARDSLASH", "DOT", "SQRT", "IDENTIFIER", "PERIOD", 
		"NUMBER", "WS"
	};


	public MathmpLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public MathmpLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'\\n'", null, "'^'", "'('", "')'", "'['", "']'", "'{'", "'}'", 
		null, "'/'", "'dot'", "'sqrt'", null, "'.'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, "GREEK", "CARET", "LPAREN", "RPAREN", "LSQUARE", "RSQUARE", 
		"LBRACE", "RBRACE", "OPERATOR", "FORWARDSLASH", "DOT", "SQRT", "IDENTIFIER", 
		"PERIOD", "NUMBER", "WS"
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
		4,0,17,120,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
		1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
		3,1,65,8,1,1,2,1,2,1,3,1,3,1,4,1,4,1,5,1,5,1,6,1,6,1,7,1,7,1,8,1,8,1,9,
		1,9,1,10,1,10,1,11,1,11,1,11,1,11,1,12,1,12,1,12,1,12,1,12,1,13,4,13,95,
		8,13,11,13,12,13,96,1,14,1,14,1,15,4,15,102,8,15,11,15,12,15,103,1,15,
		1,15,4,15,108,8,15,11,15,12,15,109,3,15,112,8,15,1,16,4,16,115,8,16,11,
		16,12,16,116,1,16,1,16,0,0,17,1,1,3,2,5,3,7,4,9,5,11,6,13,7,15,8,17,9,
		19,10,21,11,23,12,25,13,27,14,29,15,31,16,33,17,1,0,4,5,0,43,43,45,45,
		61,61,916,916,8706,8706,2,0,65,90,97,122,1,0,48,57,3,0,9,10,13,13,32,32,
		129,0,1,1,0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,
		0,0,0,0,13,1,0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,
		0,23,1,0,0,0,0,25,1,0,0,0,0,27,1,0,0,0,0,29,1,0,0,0,0,31,1,0,0,0,0,33,
		1,0,0,0,1,35,1,0,0,0,3,64,1,0,0,0,5,66,1,0,0,0,7,68,1,0,0,0,9,70,1,0,0,
		0,11,72,1,0,0,0,13,74,1,0,0,0,15,76,1,0,0,0,17,78,1,0,0,0,19,80,1,0,0,
		0,21,82,1,0,0,0,23,84,1,0,0,0,25,88,1,0,0,0,27,94,1,0,0,0,29,98,1,0,0,
		0,31,101,1,0,0,0,33,114,1,0,0,0,35,36,5,10,0,0,36,2,1,0,0,0,37,38,5,100,
		0,0,38,39,5,101,0,0,39,65,5,108,0,0,40,41,5,97,0,0,41,42,5,108,0,0,42,
		43,5,112,0,0,43,44,5,104,0,0,44,65,5,97,0,0,45,46,5,98,0,0,46,47,5,101,
		0,0,47,48,5,116,0,0,48,65,5,97,0,0,49,50,5,103,0,0,50,51,5,97,0,0,51,52,
		5,109,0,0,52,53,5,109,0,0,53,65,5,97,0,0,54,55,5,100,0,0,55,56,5,101,0,
		0,56,57,5,108,0,0,57,58,5,116,0,0,58,65,5,97,0,0,59,60,5,68,0,0,60,61,
		5,101,0,0,61,62,5,108,0,0,62,63,5,116,0,0,63,65,5,97,0,0,64,37,1,0,0,0,
		64,40,1,0,0,0,64,45,1,0,0,0,64,49,1,0,0,0,64,54,1,0,0,0,64,59,1,0,0,0,
		65,4,1,0,0,0,66,67,5,94,0,0,67,6,1,0,0,0,68,69,5,40,0,0,69,8,1,0,0,0,70,
		71,5,41,0,0,71,10,1,0,0,0,72,73,5,91,0,0,73,12,1,0,0,0,74,75,5,93,0,0,
		75,14,1,0,0,0,76,77,5,123,0,0,77,16,1,0,0,0,78,79,5,125,0,0,79,18,1,0,
		0,0,80,81,7,0,0,0,81,20,1,0,0,0,82,83,5,47,0,0,83,22,1,0,0,0,84,85,5,100,
		0,0,85,86,5,111,0,0,86,87,5,116,0,0,87,24,1,0,0,0,88,89,5,115,0,0,89,90,
		5,113,0,0,90,91,5,114,0,0,91,92,5,116,0,0,92,26,1,0,0,0,93,95,7,1,0,0,
		94,93,1,0,0,0,95,96,1,0,0,0,96,94,1,0,0,0,96,97,1,0,0,0,97,28,1,0,0,0,
		98,99,5,46,0,0,99,30,1,0,0,0,100,102,7,2,0,0,101,100,1,0,0,0,102,103,1,
		0,0,0,103,101,1,0,0,0,103,104,1,0,0,0,104,111,1,0,0,0,105,107,5,46,0,0,
		106,108,7,2,0,0,107,106,1,0,0,0,108,109,1,0,0,0,109,107,1,0,0,0,109,110,
		1,0,0,0,110,112,1,0,0,0,111,105,1,0,0,0,111,112,1,0,0,0,112,32,1,0,0,0,
		113,115,7,3,0,0,114,113,1,0,0,0,115,116,1,0,0,0,116,114,1,0,0,0,116,117,
		1,0,0,0,117,118,1,0,0,0,118,119,6,16,0,0,119,34,1,0,0,0,7,0,64,96,103,
		109,111,116,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
