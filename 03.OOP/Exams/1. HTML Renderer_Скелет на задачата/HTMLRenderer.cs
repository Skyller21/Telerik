using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace HTMLRenderer
{
    public interface IElement
    {
        string Name { get; }
        string TextContent { get; set; }
        IEnumerable<IElement> ChildElements { get; }
        void AddElement(IElement element);
        void Render(StringBuilder output);
        string ToString();
    }

    public interface ITable : IElement
    {
        int Rows { get; }
        int Cols { get; }
        IElement this[int row, int col] { get; set; }
    }

    public interface IElementFactory
    {
        IElement CreateElement(string name);
        IElement CreateElement(string name, string content);
        ITable CreateTable(int rows, int cols);
    }

    public class HTMLElementFactory : IElementFactory
    {
        public IElement CreateElement(string name)
        {
            return new HTMLElement(name);
        }

        public IElement CreateElement(string name, string content)
        {
            return new HTMLElement(name, content);
        }

        public ITable CreateTable(int rows, int cols)
        {
            return new HTMLTable(rows, cols);
        }
    }

    public class HTMLElement : IElement
    {
        public HTMLElement(string name)
        {
            this.Name = name;
            this.ChildElements = new List<IElement>();
        }
        public HTMLElement(string name, string content)
            : this(name)
        {

            this.TextContent = content;


        }

        public string Name { get; protected set; }

        public virtual string TextContent { get; set; }

        public virtual IEnumerable<IElement> ChildElements { get; private set; }

        public virtual void AddElement(IElement element)
        {

            var list = new List<IElement>(this.ChildElements);
            list.Add(element);
            this.ChildElements = list;
        }

        public virtual void Render(StringBuilder output)
        {

            if (!string.IsNullOrWhiteSpace(this.Name))
            {
                output.AppendFormat("<{0}>", this.Name);
            }

            if (!string.IsNullOrWhiteSpace(this.TextContent))
            {
                for (int i = 0; i < this.TextContent.Length; i++)
                {
                    char symbol = this.TextContent[i];
                    switch (symbol)
                    {
                        case '<':
                            output.Append("&lt;");
                            break;
                        case '>':
                            output.Append("&gt;");
                            break;
                        case '&':
                            output.Append("&amp;");
                            break;
                        default:
                            output.Append(symbol);
                            break;
                    }
                }
            }

            foreach (var childElement in this.ChildElements)
            {
                output.Append(childElement.ToString());
            }

            if (!string.IsNullOrWhiteSpace(this.Name))
            {
                output.AppendFormat("</{0}>", this.Name);
            }


        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            this.Render(output);

            return output.ToString();
        }
    }



    public class HTMLTable : HTMLElement, ITable
    {
        private int rows;
        private int cols;
        public IElement[,] MyMatrix { get; private set; }
        public HTMLTable(int rows, int cols)
            : base("table")
        {
            this.Rows = rows;
            this.Cols = cols;
            this.MyMatrix = new IElement[rows, cols];
        }
        public int Rows
        {
            get { return this.rows; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The rows cannot be less than zero");
                }
                this.rows = value;
            }
        }

        public int Cols
        {
            get { return this.cols; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The cols cannot be less than zero");
                }
                this.cols = value;
            }
        }

        public IElement this[int row, int col]
        {
            get
            {
                if (row < 0 || col < 0 || col >= this.Cols || row >= this.Rows || col >= this.Cols)
                {
                    throw new ArgumentOutOfRangeException("The position is outside the boundaries of the table");
                }
                return this.MyMatrix[row, col];
            }
            set
            {
                if ((row < 0 || col < 0 || row >= this.Rows || col >= this.Cols) || !(value is HTMLElement))
                {
                    throw new ArgumentOutOfRangeException("The position is outside the boundaries of the table");
                }
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.MyMatrix[row, col] = value;
            }
        }

        public override IEnumerable<IElement> ChildElements
        {
            get
            {
                throw new InvalidOperationException("HTML tables do not have child elements!");
            }
        }

        public override string TextContent
        {
            get
            {
                throw new InvalidOperationException("Cannot get text content of HTML table because it does not have such!");
            }

            set
            {
                throw new InvalidOperationException("Cannot set text content of HTML table because it does not have such!");
            }
        }

        public override void AddElement(IElement element)
        {
            throw new InvalidOperationException("HTML tables do not have child elements so such cannot be added!");
        }

        public override void Render(StringBuilder output)
        {
            output.AppendFormat("<{0}>", this.Name);

            for (int row = 0; row < this.Rows; row++)
            {
                output.Append("&lt;");

                for (int col = 0; col < this.Cols; col++)
                {
                    output.Append("&lt;");

                    output.Append(this.MyMatrix[row, col].ToString());

                    output.Append("&gt;");
                }

                output.Append("&gt;");
            }

            output.AppendFormat("</{0}>", this.Name);
        }



    }










































    public class HTMLRendererCommandExecutor
    {
        static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using HTMLRenderer;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}
