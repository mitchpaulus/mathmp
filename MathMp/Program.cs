using System.Text;
using Antlr4.Runtime;
using MathMpLib;

namespace MathMp;

class Program
{
    static int Main(string[] args)
    {
        int i = 0;
        string? filepath = null;

        MathMlStyle style = MathMlStyle.Web;

        // Compile mode is taking Markdown or HTML or something that has equations in backticks, ``, and doing replacements on all of them.
        bool replaceCompile = false;
        bool vba = false;
        string vbaEq = "";

        while (i < args.Length)
        {
            var arg = args[i];
            i++;

            if (arg == "--help" || arg == "-h")
            {
                PrintHelp();
                return 0;
            }
            else if (arg == "--word")
            {
                style = MathMlStyle.Word;
            }
            else if (arg == "--tex")
            {
                style = MathMlStyle.Tex;
            }
            else if (arg == "--omath")
            {
                style = MathMlStyle.OMath;
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
            else if (arg == "vba")
            {
                if (i >= args.Length)
                {
                    Console.Error.WriteLine("Usage: MathMp vba <EQUATION>\n");
                    return 1;
                }
                var eq = args[i++];
                vba = true;
            }
            else
            {
                filepath = arg;
                if (i != args.Length)
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

        if (vba)
        {
            //
            // var stream = Console.IsInputRedirected ? new AntlrInputStream(Console.In) : new AntlrFileStream(filepath);

            ErrorListener errorListener = new();
            var stream = new AntlrInputStream(vbaEq);
            MathmpLexer lex = new MathmpLexer(stream);
            lex.RemoveErrorListeners();
            lex.AddErrorListener(errorListener);
            CommonTokenStream tokenStream = new CommonTokenStream(lex);
            MathmpParser parser = new MathmpParser(tokenStream);
            parser.RemoveErrorListeners();
            parser.AddErrorListener(errorListener);
            var tree = parser.file();
            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string mathMpDir = Path.Combine(localAppData, "MathMp");

            if (errorListener.Messages.Any())
            {
                StringBuilder b = new StringBuilder();
                foreach (var errorMessage in errorListener.Messages)
                {
                    b.AppendLine(errorMessage);
                    if (!errorMessage.EndsWith('\n')) b.Append('\n');
                }

                File.WriteAllText(mathMpDir + "\\error.log", b.ToString());
                return 1;
            }

            MathmpBaseVisitor<string> visitor = new MathMpVisitor(MathMlStyle.Word);

            // MathMpVisitor visitor = new MathMpVisitor(style);
            StringBuilder outBuilder = new StringBuilder();
            foreach (var mathLine in tree.math())
            {
                string output = visitor.Visit(mathLine);
                outBuilder.Append(output);
                outBuilder.Append('\n');
            }
            File.WriteAllText(mathMpDir + "\\output.log", outBuilder.ToString());
        }
        else if (replaceCompile)
        {
            string allContent = filepath is null ? Console.In.ReadToEnd() : File.ReadAllText(filepath!);

            Replacer r = new Replacer(allContent, style);
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
            if (style == MathMlStyle.OMath)
            {
                visitor = new OMathVisitor();
            }
            else if (style == MathMlStyle.Tex)
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
         Console.Write("mathmp [--word|--tex|--omath] FILEPATH\n");
         Console.Write("mathmp [--word|--tex|--omath] compile FILEPATH\n");
         Console.Write("\n");
         Console.Write("OPTIONS\n");
         Console.Write(" --word  Print to MathML that MS Word understands\n");
         Console.Write(" --tex   Print to Tex format\n");
         Console.Write(" --omath Print to Office Math (OMML) XML\n");
    }
}
