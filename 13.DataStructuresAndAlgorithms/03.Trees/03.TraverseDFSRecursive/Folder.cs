using System.Collections.Generic;

namespace _03.TraverseDFSRecursive
{
    using System.IO;

    public class Folder
    {
        public Folder(string path)
        {
            this.FolderPath = path;
            this.Files = new List<File>();
            this.SubFolders = new List<Folder>();
            this.IsUsed = false;
            this.Name = Path.GetFileName(path);
        }

        public bool IsUsed { get; set; }

        public string Name { get; set; }

        public string FolderPath { get; set; }

        public IList<File> Files { get; set; }

        public IList<Folder> SubFolders { get; set; }
    }
}
