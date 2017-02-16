using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
namespace BinarySerialization
{
    public partial class MainWindow : Form
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Serialize_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowser.ShowDialog();
            if (res == DialogResult.OK)
            {
                Serialize serialize = new Serialize();
                Folder folder = serialize.GetFolder(folderBrowser.SelectedPath);
                BinaryFormatter binFormat = new BinaryFormatter();
                using (FileStream stream = new FileStream("Cat.dat", FileMode.OpenOrCreate))
                {
                    binFormat.Serialize(stream, folder);
                }
            }
        }

        private void Deserialize_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowser.ShowDialog();
            if (res == DialogResult.OK)
            {
                Deserialize deSerialize = new Deserialize();
                BinaryFormatter formater = new BinaryFormatter();
                using (FileStream stream = new FileStream("Cat.dat", FileMode.Open))
                {
                    deSerialize.CreateFolder(folderBrowser.SelectedPath, (Folder)formater.Deserialize(stream));
                }
               
            }
        }
    }
}
