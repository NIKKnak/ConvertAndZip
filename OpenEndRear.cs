using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertAndZip
{
    internal class OpenEndRear
    {
        async public void Start()
        {
            using FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string pathDirrectory = dialog.SelectedPath;

                await Task.Run(() =>
                {
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
                        catch
                        {
                            Thread.Sleep(5000);
                        }
                    }
                });
            }
        }
    }
}