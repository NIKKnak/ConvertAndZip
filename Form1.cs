using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

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

/*            Timer timer = new Timer();
            timer.Interval = 5000;
            timer.Start();*/



            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string pathDirrectory = dialog.SelectedPath;





                //Directory.GetFiles(pathDirrectory, "*.xps").Length > 0


                while (true)
                {

                    try
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
                    catch {
                        Thread.Sleep(5000);
                    
                    }


                    



                }










            }




        }
    }
}
