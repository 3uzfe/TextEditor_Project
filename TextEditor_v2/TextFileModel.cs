using System.IO;

namespace TextEditor.Models
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
