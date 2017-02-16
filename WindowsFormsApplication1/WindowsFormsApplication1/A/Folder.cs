using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.A
{
    [Serializable]
   public class Folder
    {
        public Folder[] SubFolders { get; set; }
        public File[] Files { get; set; }
        public string Name { get; set; }

    }
}
