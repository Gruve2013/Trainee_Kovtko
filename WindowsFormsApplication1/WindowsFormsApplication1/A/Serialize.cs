using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApplication1.A
{
   public class Serialize
    {
        public Folder GetFolder(string root)
        {
            var dirInfo = new DirectoryInfo(root);
            var directory = new Folder
            {
                Name = dirInfo.Name,
                Files = GetFiles(root).ToArray(),
                SubFolders = GetSubFolders(root).ToArray()
            };
            return directory;
        }
        private IEnumerable<Folder> GetSubFolders(string root)
        {
            foreach (var folder in Directory.GetDirectories(root))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(folder);
                Folder directory = new Folder
                {
                    Name = dirInfo.Name,
                    Files = GetFiles(folder).ToArray(),
                    SubFolders = GetSubFolders(folder).ToArray()
                };
                yield return directory;
            }
        }

        private IEnumerable<File> GetFiles(string dir)
        {
            foreach (var file in Directory.GetFiles(dir))
            {
                FileInfo info = new FileInfo(file);

                yield return new File
                {
                    Data = System.IO.File.ReadAllBytes(file),
                    Name = info.Name
                };
            }
        }
    }
}
