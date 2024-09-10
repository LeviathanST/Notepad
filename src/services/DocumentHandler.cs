using System.Text;
using Error;
using Utils;

namespace Service {
    public class DocumentHandler {
        
        public static void CreateOne (string nameFile, string typeFile, string workingDirectory) {
            string pathFile = $"{workingDirectory}\\{nameFile}.{typeFile}";
            if (File.Exists(pathFile)) {
                int fileCount = Directory.GetFiles(new FileInfo(pathFile).DirectoryName, $"{nameFile}*.{typeFile}").Length;
                nameFile = nameFile + $"{fileCount}";
            }

            File.Create(pathFile);
        }

        public static string LoadFromFile (string? pathFile)
        {
            if (string.IsNullOrEmpty(pathFile)) {
                Logger.Warn("Your path is null or empty");
                throw new ArgumentException("Your path is null or empty, please put your path file!");
            }

            else if (Directory.Exists(pathFile)) {
                Logger.Warn($"{pathFile} is a directory!");
                throw new IsDirectoryException("Your choice is a directory, please put a file!");
            }

            else if (!File.Exists(pathFile)) {
                Logger.Warn($"{pathFile} NOT FOUND!");
                throw new FileNotFoundException($"{pathFile} NOT FOUND!");
            }

            using (StreamReader sr = new StreamReader(pathFile))  {
                StringBuilder sb = new StringBuilder ();
                string line;
                while ((line = sr.ReadLine()) != null) {
                    sb.AppendLine(line);
                }
                return sb.ToString();
                }
        }

        public static void WriteToFile (string pathFile, string content) {
            File.WriteAllText(pathFile, content);
        }
        public static void WriteToFile (string pathFile, string[] lines) {
            if (string.IsNullOrEmpty(pathFile)) {
                Logger.Warn("Your path is null or empty");
                throw new ArgumentException("Your path is null or empty, please put your path file!");
            }

            else if (Directory.Exists(pathFile)) {
                Logger.Warn($"{pathFile} is a directory!");
                throw new IsDirectoryException("Your choice is a directory, please put a file!");
            }

            else if (!File.Exists(pathFile)) {
                Logger.Warn($"{pathFile} NOT FOUND!");
                throw new FileNotFoundException($"{pathFile} NOT FOUND!");
            }


           using (StreamWriter sw = new StreamWriter(pathFile)) {
                foreach (string line in lines)
                {
                   sw.WriteLine(line);
                }
           } 
        }
    }
}