using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerialization
{
   public class Serialize
    {
        public Folder GetFolder(string root)
        {
            DirectoryInfo info = new DirectoryInfo(root);
            return new Folder
            {
                Name = info.Name,
                Files = GetFiles(root).ToArray(),
                SubFolders = GetSubFolders(root).ToArray()
            };
        }
        private IEnumerable<Folder> GetSubFolders(string root)
        {
            foreach (var folder in Directory.GetDirectories(root))
            {

                yield return GetFolder(folder);
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
