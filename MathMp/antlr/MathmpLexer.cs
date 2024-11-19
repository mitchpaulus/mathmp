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
		T__0=1, GREEK=2, APPROX=3, CDOT=4, SQUARED=5, CARET=6, LPAREN=7, RPAREN=8, 
		LSQUARE=9, RSQUARE=10, LBRACE=11, RBRACE=12, OPERATOR=13, FORWARDSLASH=14, 
		STRING=15, SINGLE_QUOTE_STR=16, DOT=17, SQRT=18, IDENTIFIER=19, PERIOD=20, 
		NUMBER=21, WS=22, COMMENT=23;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "GREEK", "APPROX", "CDOT", "SQUARED", "CARET", "LPAREN", "RPAREN", 
		"LSQUARE", "RSQUARE", "LBRACE", "RBRACE", "OPERATOR", "FORWARDSLASH", 
		"STRING", "ESC", "SINGLE_QUOTE_STR", "DOT", "SQRT", "IDENTIFIER", "PERIOD", 
		"NUMBER", "WS", "COMMENT"
	};


	public MathmpLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public MathmpLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'\\n'", null, "'approx'", "'cdot'", "'\\u00B2'", "'^'", "'('", 
		"')'", "'['", "']'", "'{'", "'}'", null, "'/'", null, null, "'dot'", "'sqrt'", 
		null, "'.'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, "GREEK", "APPROX", "CDOT", "SQUARED", "CARET", "LPAREN", "RPAREN", 
		"LSQUARE", "RSQUARE", "LBRACE", "RBRACE", "OPERATOR", "FORWARDSLASH", 
		"STRING", "SINGLE_QUOTE_STR", "DOT", "SQRT", "IDENTIFIER", "PERIOD", "NUMBER", 
		"WS", "COMMENT"
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
		4,0,23,194,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
		1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
		1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,1,92,8,1,1,2,1,2,
		1,2,1,2,1,2,1,2,1,2,1,3,1,3,1,3,1,3,1,3,1,4,1,4,1,5,1,5,1,6,1,6,1,7,1,
		7,1,8,1,8,1,9,1,9,1,10,1,10,1,11,1,11,1,12,1,12,1,13,1,13,1,14,1,14,1,
		14,5,14,129,8,14,10,14,12,14,132,9,14,1,14,1,14,1,15,1,15,1,15,1,15,3,
		15,140,8,15,1,16,1,16,4,16,144,8,16,11,16,12,16,145,1,17,1,17,1,17,1,17,
		1,18,1,18,1,18,1,18,1,18,1,19,4,19,158,8,19,11,19,12,19,159,1,20,1,20,
		1,21,4,21,165,8,21,11,21,12,21,166,1,21,1,21,4,21,171,8,21,11,21,12,21,
		172,3,21,175,8,21,1,22,4,22,178,8,22,11,22,12,22,179,1,22,1,22,1,23,1,
		23,1,23,1,23,5,23,188,8,23,10,23,12,23,191,9,23,1,23,1,23,1,130,0,24,1,
		1,3,2,5,3,7,4,9,5,11,6,13,7,15,8,17,9,19,10,21,11,23,12,25,13,27,14,29,
		15,31,0,33,16,35,17,37,18,39,19,41,20,43,21,45,22,47,23,1,0,5,7,0,43,45,
		61,61,176,176,916,916,8706,8706,8776,8776,8901,8901,2,0,65,90,97,122,1,
		0,48,57,3,0,9,10,13,13,32,32,2,0,10,10,13,13,211,0,1,1,0,0,0,0,3,1,0,0,
		0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,13,1,0,0,0,0,15,1,
		0,0,0,0,17,1,0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,0,23,1,0,0,0,0,25,1,0,0,0,
		0,27,1,0,0,0,0,29,1,0,0,0,0,33,1,0,0,0,0,35,1,0,0,0,0,37,1,0,0,0,0,39,
		1,0,0,0,0,41,1,0,0,0,0,43,1,0,0,0,0,45,1,0,0,0,0,47,1,0,0,0,1,49,1,0,0,
		0,3,91,1,0,0,0,5,93,1,0,0,0,7,100,1,0,0,0,9,105,1,0,0,0,11,107,1,0,0,0,
		13,109,1,0,0,0,15,111,1,0,0,0,17,113,1,0,0,0,19,115,1,0,0,0,21,117,1,0,
		0,0,23,119,1,0,0,0,25,121,1,0,0,0,27,123,1,0,0,0,29,125,1,0,0,0,31,139,
		1,0,0,0,33,141,1,0,0,0,35,147,1,0,0,0,37,151,1,0,0,0,39,157,1,0,0,0,41,
		161,1,0,0,0,43,164,1,0,0,0,45,177,1,0,0,0,47,183,1,0,0,0,49,50,5,10,0,
		0,50,2,1,0,0,0,51,52,5,100,0,0,52,53,5,101,0,0,53,92,5,108,0,0,54,55,5,
		97,0,0,55,56,5,108,0,0,56,57,5,112,0,0,57,58,5,104,0,0,58,92,5,97,0,0,
		59,60,5,98,0,0,60,61,5,101,0,0,61,62,5,116,0,0,62,92,5,97,0,0,63,64,5,
		103,0,0,64,65,5,97,0,0,65,66,5,109,0,0,66,67,5,109,0,0,67,92,5,97,0,0,
		68,69,5,100,0,0,69,70,5,101,0,0,70,71,5,108,0,0,71,72,5,116,0,0,72,92,
		5,97,0,0,73,74,5,68,0,0,74,75,5,101,0,0,75,76,5,108,0,0,76,77,5,116,0,
		0,77,92,5,97,0,0,78,79,5,114,0,0,79,80,5,104,0,0,80,92,5,111,0,0,81,82,
		5,110,0,0,82,92,5,117,0,0,83,84,5,101,0,0,84,85,5,116,0,0,85,92,5,97,0,
		0,86,87,5,111,0,0,87,88,5,109,0,0,88,89,5,101,0,0,89,90,5,103,0,0,90,92,
		5,97,0,0,91,51,1,0,0,0,91,54,1,0,0,0,91,59,1,0,0,0,91,63,1,0,0,0,91,68,
		1,0,0,0,91,73,1,0,0,0,91,78,1,0,0,0,91,81,1,0,0,0,91,83,1,0,0,0,91,86,
		1,0,0,0,92,4,1,0,0,0,93,94,5,97,0,0,94,95,5,112,0,0,95,96,5,112,0,0,96,
		97,5,114,0,0,97,98,5,111,0,0,98,99,5,120,0,0,99,6,1,0,0,0,100,101,5,99,
		0,0,101,102,5,100,0,0,102,103,5,111,0,0,103,104,5,116,0,0,104,8,1,0,0,
		0,105,106,5,178,0,0,106,10,1,0,0,0,107,108,5,94,0,0,108,12,1,0,0,0,109,
		110,5,40,0,0,110,14,1,0,0,0,111,112,5,41,0,0,112,16,1,0,0,0,113,114,5,
		91,0,0,114,18,1,0,0,0,115,116,5,93,0,0,116,20,1,0,0,0,117,118,5,123,0,
		0,118,22,1,0,0,0,119,120,5,125,0,0,120,24,1,0,0,0,121,122,7,0,0,0,122,
		26,1,0,0,0,123,124,5,47,0,0,124,28,1,0,0,0,125,130,5,34,0,0,126,129,3,
		31,15,0,127,129,9,0,0,0,128,126,1,0,0,0,128,127,1,0,0,0,129,132,1,0,0,
		0,130,131,1,0,0,0,130,128,1,0,0,0,131,133,1,0,0,0,132,130,1,0,0,0,133,
		134,5,34,0,0,134,30,1,0,0,0,135,136,5,92,0,0,136,140,5,34,0,0,137,138,
		5,92,0,0,138,140,5,92,0,0,139,135,1,0,0,0,139,137,1,0,0,0,140,32,1,0,0,
		0,141,143,5,39,0,0,142,144,7,1,0,0,143,142,1,0,0,0,144,145,1,0,0,0,145,
		143,1,0,0,0,145,146,1,0,0,0,146,34,1,0,0,0,147,148,5,100,0,0,148,149,5,
		111,0,0,149,150,5,116,0,0,150,36,1,0,0,0,151,152,5,115,0,0,152,153,5,113,
		0,0,153,154,5,114,0,0,154,155,5,116,0,0,155,38,1,0,0,0,156,158,7,1,0,0,
		157,156,1,0,0,0,158,159,1,0,0,0,159,157,1,0,0,0,159,160,1,0,0,0,160,40,
		1,0,0,0,161,162,5,46,0,0,162,42,1,0,0,0,163,165,7,2,0,0,164,163,1,0,0,
		0,165,166,1,0,0,0,166,164,1,0,0,0,166,167,1,0,0,0,167,174,1,0,0,0,168,
		170,5,46,0,0,169,171,7,2,0,0,170,169,1,0,0,0,171,172,1,0,0,0,172,170,1,
		0,0,0,172,173,1,0,0,0,173,175,1,0,0,0,174,168,1,0,0,0,174,175,1,0,0,0,
		175,44,1,0,0,0,176,178,7,3,0,0,177,176,1,0,0,0,178,179,1,0,0,0,179,177,
		1,0,0,0,179,180,1,0,0,0,180,181,1,0,0,0,181,182,6,22,0,0,182,46,1,0,0,
		0,183,184,5,47,0,0,184,185,5,47,0,0,185,189,1,0,0,0,186,188,8,4,0,0,187,
		186,1,0,0,0,188,191,1,0,0,0,189,187,1,0,0,0,189,190,1,0,0,0,190,192,1,
		0,0,0,191,189,1,0,0,0,192,193,6,23,0,0,193,48,1,0,0,0,12,0,91,128,130,
		139,145,159,166,172,174,179,189,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
