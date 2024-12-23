using System.IO;

namespace TextEditor_v2
{
    public class TextFileModel
    {
        public string Content { get; set; }

        public void Load(string filePath)
        {
            Content = File.ReadAllText(filePath);
        }

        public void Save(string filePath)
        {
            File.WriteAllText(filePath, Content);
        }
    }
}
