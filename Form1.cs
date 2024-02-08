using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ConvertAndZip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();





            if (dialog.ShowDialog() == DialogResult.OK)
            {

                    string pathDirrectory = dialog.SelectedPath;

                while (Directory.GetFiles(pathDirrectory, "*.xps").Length > 0)
                {



                    string[] dirrectoriesName = Directory.GetDirectories(pathDirrectory);
                    string[] fileNames = Directory.GetFiles(pathDirrectory);

                    string dirrectoryName = Path.GetFileName(dirrectoriesName[0]);
                    string fileName = Path.GetFileNameWithoutExtension(fileNames[0]);

                    string fileNameForTransmission = fileNames[0];// костыль

                    if (dirrectoryName == fileName)
                    {
                        CopyTextFile copyTextFile = new CopyTextFile();
                        copyTextFile.ConvertFile(fileNameForTransmission);

                        ZipArhiv zipArhiv = new ZipArhiv();
                        zipArhiv.zip(pathDirrectory);

                    }



                }



                


                



            }




        }
    }
}
