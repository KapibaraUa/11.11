using System;
using System.IO;

namespace FileSystemHw
{
    public class FileWordReplacer
    {
        public void ReplaceWord(string filePath, string searchWord, string replaceWord)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found", filePath);

            if (string.IsNullOrEmpty(searchWord))
                throw new ArgumentException("Search word cannot be empty");

            string content = File.ReadAllText(filePath);

            int replacementsCount = 0;
            int index = 0;

            while ((index = content.IndexOf(searchWord, index, StringComparison.Ordinal)) != -1)
            {
                replacementsCount++;
                index += searchWord.Length;
            }

            string updatedContent = content.Replace(searchWord, replaceWord);
            File.WriteAllText(filePath, updatedContent);

            Console.WriteLine($"File: {filePath}");
            Console.WriteLine($"Search word: {searchWord}");
            Console.WriteLine($"Replace word: {replaceWord}");
            Console.WriteLine($"Total replacements: {replacementsCount}");
        }
    }
}