using System;
using System.IO;

namespace FileSystemHw
{
    public class FileContentReverser
    {
        public void ReverseFile(string sourcePath, string destinationPath)
        {
            if (!File.Exists(sourcePath))
                throw new FileNotFoundException("Source file not found", sourcePath);

            string content = File.ReadAllText(sourcePath);
            char[] chars = content.ToCharArray();
            Array.Reverse(chars);

            string reversedContent = new string(chars);
            File.WriteAllText(destinationPath, reversedContent);

            Console.WriteLine($"Reversed content saved to: {destinationPath}");
        }
    }
}