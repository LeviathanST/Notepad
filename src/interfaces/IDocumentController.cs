namespace Interface {
    public interface IDocumentController {
        public string LoadFromFile (string pathFile);
        public void WriteToFile(string pathFile, string[] lines);
    }
}
