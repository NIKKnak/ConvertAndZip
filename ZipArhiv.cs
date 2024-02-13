using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertAndZip
{
    internal class ZipArhiv
    {

        public void zip(string pathDirrectory)
        {                        
                // Получаем список файлов и подпапок в выбранной директории
                string[] files1 = Directory.GetFiles(pathDirrectory);
                string[] directories1 = Directory.GetDirectories(pathDirrectory);

                // Группировка файлов и папок по именам (без расшиения) 
                var fileAndDirectoryNames = files1.Select(f => Path.GetFileNameWithoutExtension(f))
                    .Concat(directories1.Select(d => Path.GetFileName(d))).ToArray();

                var groups = fileAndDirectoryNames.GroupBy(x => x);

                // Архивация и удаление файлов и папок
                foreach (var group in groups)
                {
                    if (group.Count() > 1)
                    {
                        var itemsToArchive = files1.Where(f => Path.GetFileNameWithoutExtension(f) == group.Key)
                            .Concat(directories1.Where(d => Path.GetFileName(d) == group.Key));

                        string zipPath = Path.Combine(pathDirrectory, group.Key + ".zip");
                        using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Create))
                        {
                            foreach (var item in itemsToArchive)
                            {
                                if (File.Exists(item)) // Если это файл, добавляем его в архив и удаляем
                                {
                                    archive.CreateEntryFromFile(item, Path.GetFileName(item));
                                    File.Delete(item);
                                }
                                else // Если это папка, архивируем ее целиком и удаляем
                                {
                                    ZipDirectory(item, archive, pathDirrectory);
                                    Directory.Delete(item, true);
                                }
                            }
                        }
                    }
                }
            }
        











        private void ZipDirectory(string directory, ZipArchive archive, string rootDirectory)
        {
            foreach (string file in Directory.GetFiles(directory, "*", SearchOption.AllDirectories))
            {
                string entryName = Path.GetRelativePath(rootDirectory, file);
                archive.CreateEntryFromFile(file, entryName);
                File.Delete(file);
            }
        }










    }
}
