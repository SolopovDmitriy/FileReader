using System.IO;

namespace Library
{
     class FileReader
    {
        static public string ReadTxtFile(string path)
        {           
            if (!File.Exists(path))
            {
                return null;
            }           
            string readText = File.ReadAllText(path);
            return readText;
        }
    }
}