using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using System.Collections;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;

namespace SoftwareAcademy
{
    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public class Teacher:ITeacher
    {
        private string name;
        
        public Teacher(string name)
        {
            this.Name = name;
            this.CoursesTeached = new List<ICourse>();
        }

        public ICollection<ICourse> CoursesTeached { get; private   set; }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Cannot be null");
                }
                this.name = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            this.CoursesTeached.Add(course);
        }

        public override string ToString()
        {
           // Teacher: Name=(teacher name); Courses=[(course names – comma separated)]

            StringBuilder result = new StringBuilder();
            result.Append(String.Format("Teacher: Name={0}", this.Name));
            if (this.CoursesTeached.Any())
            {
                List<string> arrCourseNames = new List<string>();
                foreach (var course  in this.CoursesTeached)
                {
                    arrCourseNames.Add(course.Name);
                }
                result.Append(String.Format("; Courses=[{0}]", string.Join(", ", arrCourseNames)));
            }
            return result.ToString();
            
        }
    }


    public abstract class Course : ICourse
    {
        protected string name;
        protected ICollection<string> topics;

        protected Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.Topics = new List<string>();
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Cannot be null");
                }
                this.name = value;
            }
        }

        public ITeacher Teacher{get; set; }
        public ICollection<string> Topics
        {
            get { return new List<string>(this.topics); }
            set
            {
                if (value.Count < 0)
                {
                    throw new ArgumentOutOfRangeException("Cannot be negative");
                }
                this.topics = value;
            }
        }

        public void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }

        public override string ToString()
        {
            //(course type): Name=(course name); Teacher=(teacher name); Topics=[(course topics – comma separated)]; Lab=(lab name – when applicable); Town=(town name – when applicable);

            StringBuilder result = new StringBuilder();
            
            result.Append(String.Format("{0}: Name={1}",this.GetType().Name, this.Name));
            if (this.Teacher != null)
            {
                result.Append(String.Format("; Teacher={0}", this.Teacher.Name));
            }
            if (this.Topics.Any())
            {
                result.Append(String.Format("; Topics=[{0}]", String.Join(", ",this.Topics)));
            }

            return result.ToString();

        }
    }


    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public LocalCourse(string name, ITeacher teacher,string lab ) : base(name, teacher)
        {
            this.Lab = lab;
        }
        public string Lab
        {
            get { return this.lab; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Cannot be null");
                }
                this.lab = value;
            }
        }


        public override string ToString()
        {
            //(course type): Name=(course name); Teacher=(teacher name); Topics=[(course topics – comma separated)]; Lab=(lab name – when applicable); Town=(town name – when applicable);
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.Append(String.Format("; Lab={0}", this.Lab));
            return result.ToString();
        }
    }


    public class OffsiteCourse : Course, IOffsiteCourse
    {

        private string town;

        public OffsiteCourse(string name, ITeacher teacher,string town ) : base(name, teacher)
        {
            this.Town = town;
        }
        public string Town
        {
            get { return this.town; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Cannot be null");
                }
                this.town = value;
            }
        }

        public override string ToString()
        {
            //(course type): Name=(course name); Teacher=(teacher name); Topics=[(course topics – comma separated)]; Lab=(lab name – when applicable); Town=(town name – when applicable);
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.Append(String.Format("; Town={0}", this.Town));
            return result.ToString();
        }
    }























    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }

    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            return new Teacher(name);
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
           return new LocalCourse(name, teacher, lab);
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            return new OffsiteCourse(name, teacher, town);
        }
    }



































    public class SoftwareAcademyCommandExecutor
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
                  using SoftwareAcademy;

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
