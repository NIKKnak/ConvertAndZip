using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertAndZip
{
    public class CopyTextFile
    {
        public void ConvertFile(string fileName)
        {

            string fileNameToFind = "1.fpage"; // искомый файл

            using (ZipArchive archive = ZipFile.OpenRead(fileName))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(fileNameToFind, StringComparison.OrdinalIgnoreCase))
                    {
                        using (StreamReader reader = new StreamReader(entry.Open()))
                        {
                            string fileContent = reader.ReadToEnd();

                            // Поиск всех значений UnicodeString в файле
                            string pattern = @"UnicodeString\s*=\s*""([^""]*)""";
                            MatchCollection matches = Regex.Matches(fileContent, pattern);

                            if (matches.Count > 0)
                            {
                                // Создание нового файла + запись
                                string archiveFileName = Path.GetFileNameWithoutExtension(fileName);
                                string newFilePath = Path.Combine(Path.GetDirectoryName(fileName), $"{archiveFileName}.txt");
                                using (StreamWriter writer = new StreamWriter(newFilePath))
                                {
                                    foreach (Match match in matches)
                                    {
                                        string unicodeString = match.Groups[1].Value;
                                        writer.WriteLine(unicodeString);
                                    }
                                }
                                //MessageBox.Show("Файл успешно создан!");
                            }
                            else
                            {
                                MessageBox.Show("UnicodeString не найден!");
                            }
                            break;
                        };
                    }
                }
            }
            File.Delete(fileName);
        }
    }










}

