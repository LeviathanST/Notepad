namespace Interface {
    public interface IDocumentController {
        public void New (string name, string typeFile, string workingDirectory);
        public void New (string name, string typeFile);
        public string LoadFromFile (string pathFile);
        public void WriteToFile(string pathFile, string[] lines);
    }
}
