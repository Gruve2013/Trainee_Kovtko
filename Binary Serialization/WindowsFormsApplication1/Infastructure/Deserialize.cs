using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace BinarySerialization
{
   public class Deserialize
    {
      
        public void CreateFolder(string root, Folder foulder)
        {
            DirectoryInfo mainFolder = new DirectoryInfo(root + @"\" + foulder.Name);
            mainFolder.Create();
            CreateFiles(mainFolder, foulder.Files);
            CreateSubFolders(mainFolder,foulder.SubFolders);
        }
        private void CreateFiles(DirectoryInfo root, File[] files)
        {
            foreach (File file in files)
            {
                System.IO.File.WriteAllBytes(root.FullName + @"\" + file.Name, file.Data);
            }
        }

        private void CreateSubFolders(DirectoryInfo dir, Folder[] foulders)
        {
            foreach (Folder a in foulders)
            {
                DirectoryInfo subFoulder = dir.CreateSubdirectory(a.Name);
                CreateFiles(subFoulder, a.Files);
                CreateSubFolders(subFoulder, a.SubFolders);
            }
        }
    }
}
