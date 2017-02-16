using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using WindowsFormsApplication1.A;
namespace WindowsFormsApplication1
{
    public partial class BinarySerialization : Form
    {
       
        public BinarySerialization()
        {
            InitializeComponent();
        }

        private void Serialize_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowserDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                Serialize serialize = new Serialize();
                Folder folder = serialize.GetFolder(folderBrowserDialog1.SelectedPath);
                BinaryFormatter binFormat = new BinaryFormatter();
                using (FileStream stream = new FileStream("Cat.dat", FileMode.OpenOrCreate))
                {
                    binFormat.Serialize(stream, folder);
                }
            }
        }

        private void Deserialize_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowserDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                Deserialize deSerialize = new Deserialize();
                BinaryFormatter formater = new BinaryFormatter();
                using (FileStream stream = new FileStream("Cat.dat", FileMode.Open))
                {
                    Folder folder = (Folder)formater.Deserialize(stream);
                    deSerialize.CreateFolder(folderBrowserDialog1.SelectedPath, folder);
                }
               
            }
        }
    }
}
