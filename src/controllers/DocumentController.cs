using Interface;
using Model;
using Service;

namespace Controller {
    public class DocumentController : IDocumentController {
        private Setting s;

        public DocumentController (Setting s) {
            this.s = s; 
        }

        /// <summary>
        /// If alwaysAskWorkingDirectory = true 
        /// </summary>
        /// <param name="typeFile"></param>
        /// <param name="workingDirectory"></param>
        public void New (string name, string typeFile, string workingDirectory) {
            DocumentHandler.CreateOne(name, typeFile, workingDirectory);
        }
        
        /// <summary>
        /// If alwaysAskWorkingDirectory = false 
        /// </summary>
        /// <param name="typeFile"></param>
        public void New (string name, string typeFile) {
            DocumentHandler.CreateOne(name, typeFile, s.WorkingDirectory); 
        }


        public string LoadFromFile (string pathFile) {
           string content = DocumentHandler.LoadFromFile(pathFile);
           return content;
        }

        public void WriteToFile (string pathFile, string[] lines) {
            DocumentHandler.WriteToFile(pathFile, lines);
        }

    }
}