using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentSystem.Models;
using DocumentSystem.Interfaces;

namespace DocumentSystem
{
    public class DocumentSystem
    {
        public static IList<IDocument> documentList = new List<IDocument>();
        static void Main()
        {
            IList<string> allCommands = ReadAllCommands();
            
            ExecuteCommands(allCommands);
            
        }

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "")
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                ExecuteCommand(cmd, parameters);
            }
        }

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmd == "AddTextDocument")
            {
                AddTextDocument(cmdAttributes);
            }
            else if (cmd == "AddPDFDocument")
            {
                AddPdfDocument(cmdAttributes);
            }
            else if (cmd == "AddWordDocument")
            {
                AddWordDocument(cmdAttributes);
            }
            else if (cmd == "AddExcelDocument")
            {
                AddExcelDocument(cmdAttributes);
            }
            else if (cmd == "AddAudioDocument")
            {
                AddAudioDocument(cmdAttributes);
            }
            else if (cmd == "AddVideoDocument")
            {
                AddVideoDocument(cmdAttributes);
            }
            else if (cmd == "ListDocuments")
            {
                ListDocuments();
            }
            else if (cmd == "EncryptDocument")
            {
                EncryptDocument(parameters);
            }
            else if (cmd == "DecryptDocument")
            {
                DecryptDocument(parameters);
            }
            else if (cmd == "EncryptAllDocuments")
            {
                EncryptAllDocuments();
            }
            else if (cmd == "ChangeContent")
            {
                ChangeContent(cmdAttributes[0], cmdAttributes[1]);
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }

        private static void AddTextDocument(string[] attributes)
        {
            var doc = new TextDocument("");
            AddDocument(attributes, doc);
            
        }

        

        private static void AddPdfDocument(string[] attributes)
        {
            var doc = new PDFDocument("");
            AddDocument(attributes, doc);
        }

        private static void AddWordDocument(string[] attributes)
        {
            var doc = new WordDocument("");
            AddDocument(attributes, doc);
        }

        private static void AddExcelDocument(string[] attributes)
        {
            var doc = new ExcelDocument("");
            AddDocument(attributes, doc);
        }

        private static void AddAudioDocument(string[] attributes)
        {
            var doc = new AudioDocument("");
            AddDocument(attributes, doc);
        }

        private static void AddVideoDocument(string[] attributes)
        {
            var doc = new VideoDocument("");
            AddDocument(attributes, doc);
        }

        private static void ListDocuments()
        {
            
        }

        private static void EncryptDocument(string name)
        {

            var docs = documentList.Where(x => x.Name == name);
            
                if (docs.Any())
                {
                    foreach (var doc in docs)
                    {
                        var encryptableDoc = doc as IEncryptable;
                        if (encryptableDoc != null)
                        {
                            encryptableDoc.Encrypt();
                            Console.WriteLine("Document encrypted: {0}", doc.Name);
                        }
                        else
                        {
                            Console.WriteLine("Document does not support encryption: {0}", doc.Name);
                        }
                    }


                }
                else
                {
                    Console.WriteLine("Document not found: {0}", name);
                }
        }

        private static void DecryptDocument(string name)
        {
            var docs = documentList.Where(x => x.Name == name);
            foreach (var doc in docs)
                if (docs.Any())
                {
                    
                        var decryptableDoc = docs as IEncryptable;
                        if (decryptableDoc != null)
                        {
                            decryptableDoc.Encrypt();
                            Console.WriteLine("Document decrypted: {0}", doc.Name);
                        }
                        else
                        {
                            Console.WriteLine("Document does not support decryption: {0}", doc.Name);
                        }

                    
                }
                else
                {
                    Console.WriteLine("Document not found: {0}", doc.Name);
                }
        }

        private static void EncryptAllDocuments()
        {
            var encryptableDocs = documentList.Where(d => d is IEncryptable).Select(d => d as IEncryptable);

            if (encryptableDocs.Any())
            {
                foreach (var doc in encryptableDocs)
                {
                    doc.Encrypt();
                }
                Console.WriteLine("All documents encrypted");
            }
            else
            {
                Console.WriteLine("No encryptable documents found");
            }
        }

        private static void ChangeContent(string name, string content)
        {
            var editableDocs = documentList.Where(d => d.Name == name);
            if (editableDocs.Any())
            {
                foreach (var doc in editableDocs)
                {
                    var editableDoc = doc as IEditable;
                    if (editableDoc != null)
                    {
                        editableDoc.ChangeContent(content);
                        Console.WriteLine("Document content changed: {0}", name);
                    }
                    else
                    {
                        Console.WriteLine("Document is not editable: {0}",name);
                    }
                }
            }
            else
            {
                Console.WriteLine("Document not found: {0}", name);
            }
        }

        private static void AddDocument(string[] attributes, IDocument doc) //TODO Make it generic!!!!
        {
            foreach (var attr in attributes)
            {
                string[] keyValue = attr.Split('=');
                doc.LoadProperty(keyValue[0], keyValue[1]);
            }

            if (!string.IsNullOrEmpty(doc.Name.ToString()))
            {
                Console.WriteLine("Document added {0}", doc.Name);
            }
            else
            {
                Console.WriteLine("Document has no name");
            }

            documentList.Add(doc);
        }
    }

}
